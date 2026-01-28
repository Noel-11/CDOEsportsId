Imports System.Data
Partial Class Secured_DashBoard
    Inherits cPageInit_Secured_BS

    Dim _clsDB As New clsDatabase
   
    Dim _dtGVForInspection As New DataTable
    Dim _dtGVReturnInspection As New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Dim thisYear As Integer = DateTime.Now.Year + 1

            For i = thisYear To (thisYear - 4) Step -1
                ddlChartYear.Items.Add(New ListItem(i, i))
            Next

            ddlChartYear.SelectedValue = DateTime.Now.Year

            getDetails()
           
            getColumnChartStatus()

        End If

    End Sub

    Protected Sub ddlFVFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlFVFilter.SelectedIndexChanged
        lblFVCnt.Text = getStatusCnt("VALIDATION", ddlFVFilter.SelectedValue)
        lblFVFilter.InnerText = ddlFVFilter.SelectedItem.Text
    End Sub

    Protected Sub ddlAPPFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlAPPFilter.SelectedIndexChanged
        lblAPPCnt.Text = getStatusCnt("APPROVED", ddlAPPFilter.SelectedValue)
        lblAPPFilter.InnerText = ddlAPPFilter.SelectedItem.Text
    End Sub

    Protected Sub ddlPenFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlPenFilter.SelectedIndexChanged
        lblPenCnt.Text = getStatusCnt("PENDING", ddlPenFilter.SelectedValue)
        lblPenFilter.InnerText = ddlPenFilter.SelectedItem.Text
    End Sub

    Private Sub getDetails()

        ddlFVFilter.SelectedValue = "Month"
        ddlAPPFilter.SelectedValue = "Month"
        ddlPenFilter.SelectedValue = "Month"

        lblFVCnt.Text = getStatusCnt("VALIDATION", ddlFVFilter.SelectedValue)
        lblFVFilter.InnerText = ddlFVFilter.SelectedItem.Text

        lblAPPCnt.Text = getStatusCnt("APPROVED", ddlAPPFilter.SelectedValue)
        lblAPPFilter.InnerText = ddlAPPFilter.SelectedItem.Text

        lblPenCnt.Text = getStatusCnt("PENDING", ddlPenFilter.SelectedValue)
        lblPenFilter.InnerText = ddlPenFilter.SelectedItem.Text

    End Sub

    Private Function getStatusCnt(ByVal _thisStatus As String, ByVal _thisPeriod As String) As Integer

        Dim _clsDB As New clsDatabase

        Dim sqlWhere As String = ""

        If _thisPeriod = "Today" Then
            sqlWhere += " AND validate_date = '" & DateTime.Now.ToString("yyyy-MM-dd") & "' "
        ElseIf _thisPeriod = "Month" Then
            sqlWhere += " AND DATE_FORMAT(validate_date,'%Y-%m') = '" & DateTime.Now.ToString("yyyy-MM") & "' "
        End If

        Dim dt As New DataTable
        Dim _cnt As Integer = 0

        Dim sql As String = ""

        sql = "SELECT COUNT(*) FROM tbl_senior_citizen_information " & _
              "WHERE ref_status = '" & _thisStatus & "' AND is_active = 'Y' " & sqlWhere

        dt = _clsDB.Fill_DataTable(sql)

        _cnt = dt.Rows(0)(0)

        Return _cnt

    End Function

    Protected Sub btnFV_ServerClick(sender As Object, e As EventArgs) Handles btnFV.ServerClick

        Response.Redirect("Senior/ValidateRegistration.aspx")

    End Sub

    Protected Sub btnApp_ServerClick(sender As Object, e As EventArgs) Handles btnApp.ServerClick

        Session("TAGSTATUS") = "APPROVED"
        Response.Redirect("Senior/TagRegistration.aspx")

    End Sub

    Protected Sub btnPen_ServerClick(sender As Object, e As EventArgs) Handles btnPen.ServerClick
        Session("TAGSTATUS") = "PENDING"
        Response.Redirect("Senior/TagRegistration.aspx")
    End Sub

    Private Sub getColumnChartStatus()

        Dim sql As String = ""
        Dim dt As New DataTable

        Dim insMonths As String = ""
        Dim fVCnt As String = ""
        Dim AppCnt As String = ""
        Dim PenCnt As String = ""

        sql = "SELECT tbl_senior_citizen_information.validate_date AS inspectionMonth," & _
              "COUNT(DISTINCT IF(tbl_senior_citizen_information.ref_status = 'VALIDATION' ,tbl_senior_citizen_information.senior_id,NULL)) AS validation," & _
              "COUNT(DISTINCT IF(tbl_senior_citizen_information.ref_status = 'APPROVED' ,tbl_senior_citizen_information.senior_id,NULL)) AS approved," & _
              "COUNT(DISTINCT IF(tbl_senior_citizen_information.ref_status = 'PENDING' ,tbl_senior_citizen_information.senior_id,NULL)) AS pending " & _
              "FROM tbl_senior_citizen_information " & _
              "WHERE YEAR(tbl_senior_citizen_information.validate_date) = '" & ddlChartYear.SelectedValue & "' " & _
              "GROUP BY MONTH(tbl_senior_citizen_information.validate_date) " & _
              "ORDER BY MONTH(tbl_senior_citizen_information.validate_date)"

        dt = _clsDB.Fill_DataTable(sql)

        Dim cnt As Integer = 0
        Dim prefix As String = ""

        For Each dr As DataRow In dt.Rows

            If cnt > 0 Then
                prefix = ","
            Else
                prefix = ""
            End If

            insMonths += prefix & "'" & CDate(dr("inspectionMonth")).ToString("MMM") & "'"
            fVCnt += prefix & dr("validation")
            AppCnt += prefix & dr("approved")
            PenCnt += prefix & dr("pending")

            cnt += 1
        Next

        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "columnChart", "" & _
                                                                  "document.addEventListener('DOMContentLoaded', () => { " & _
                                                                  "new ApexCharts(document.querySelector('#columnChart'), { " & _
                                                                  "series: [{" & _
                                                                  "name: 'For Validation'," & _
                                                                  "data: [" & fVCnt & "] " & _
                                                                  "}, { " & _
                                                                  "name: 'Approved', " & _
                                                                  "data: [" & AppCnt & "] " & _
                                                                  "}, { " & _
                                                                  "name: 'Pending', " & _
                                                                  "data: [" & PenCnt & "] " & _
                                                                  "}], " & _
                                                                  "chart: { " & _
                                                                  "type: 'bar', " & _
                                                                  "height: 350 " & _
                                                                  "}, " & _
                                                                  "plotOptions:{ " & _
                                                                  "bar: { " & _
                                                                  "horizontal: false, " & _
                                                                  "columnWidth: '55%', " & _
                                                                  "endingShape: 'rounded' " & _
                                                                  "} " & _
                                                                  "}, " & _
                                                                  "dataLabels: { " & _
                                                                  "enabled: false " & _
                                                                  "}, " & _
                                                                  "stroke: { " & _
                                                                  "show: true, " & _
                                                                  "width: 2, " & _
                                                                  "colors: ['transparent'] " & _
                                                                  "}, " & _
                                                                  "xaxis: { " & _
                                                                  "categories: [" & insMonths & "] " & _
                                                                  "}, " & _
                                                                  "yaxis: { " & _
                                                                  "title: { " & _
                                                                  "text: 'Validated Counts' " & _
                                                                  "} " & _
                                                                  "}, " & _
                                                                  "fill: { " & _
                                                                  "opacity: 1 " & _
                                                                  "}, " & _
                                                                  "tooltip: { " & _
                                                                  "y: { " & _
                                                                  "formatter: function(val) { " & _
                                                                  "return val; " & _
                                                                  "} " & _
                                                                  "} " & _
                                                                  "} " & _
                                                                  "}).render();" & _
                                                                  "});", True)

    End Sub


    Private Sub getColumnChartBarangay()

        Dim sql As String = ""
        Dim dt As New DataTable

        Dim catBrgy As String = ""
        Dim brgyCnt As String = ""

        sql = "SELECT tbl_ref_barangay.barangay AS catBrgy," & _
              "COUNT(DISTINCT IF(tbl_senior_citizen_information.ref_status <> 'REGISTRATION' ,tbl_senior_citizen_information.senior_id,NULL)) AS brgyCnt " & _
              "FROM tbl_senior_citizen_information " & _
              "INNER JOIN tbl_ref_barangay ON tbl_senior_citizen_information.address_barangay = tbl_ref_barangay.barangay_code " & _
              "WHERE YEAR(tbl_senior_citizen_information.validate_date) = '" & ddlChartYear.SelectedValue & "' " & _
              "GROUP BY tbl_ref_barangay.barangay " & _
              "ORDER BY tbl_ref_barangay.barangay"

        dt = _clsDB.Fill_DataTable(sql)

        Dim cnt As Integer = 0
        Dim prefix As String = ""

        For Each dr As DataRow In dt.Rows

            If cnt > 0 Then
                prefix = ","
            Else
                prefix = ""
            End If

            catBrgy += prefix & "'" & dr("catBrgy") & "'"
            brgyCnt += prefix & dr("brgyCnt")
          
            cnt += 1
        Next

        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "columnChart", "" & _
                                                                  "document.addEventListener('DOMContentLoaded', () => { " & _
                                                                  "new ApexCharts(document.querySelector('#columnChart'), { " & _
                                                                  "series: [{" & _
                                                                  "name: 'Count'," & _
                                                                  "data: [" & brgyCnt & "] " & _
                                                                  "}], " & _
                                                                  "chart: { " & _
                                                                  "type: 'bar', " & _
                                                                  "height: 350 " & _
                                                                  "}, " & _
                                                                  "plotOptions:{ " & _
                                                                  "bar: { " & _
                                                                  "horizontal: false, " & _
                                                                  "columnWidth: '55%', " & _
                                                                  "endingShape: 'rounded' " & _
                                                                  "} " & _
                                                                  "}, " & _
                                                                  "dataLabels: { " & _
                                                                  "enabled: false " & _
                                                                  "}, " & _
                                                                  "stroke: { " & _
                                                                  "show: true, " & _
                                                                  "width: 2, " & _
                                                                  "colors: ['transparent'] " & _
                                                                  "}, " & _
                                                                  "xaxis: { " & _
                                                                  "categories: [" & catBrgy & "] " & _
                                                                  "}, " & _
                                                                  "yaxis: { " & _
                                                                  "title: { " & _
                                                                  "text: 'Validated Counts' " & _
                                                                  "} " & _
                                                                  "}, " & _
                                                                  "fill: { " & _
                                                                  "opacity: 1 " & _
                                                                  "}, " & _
                                                                  "tooltip: { " & _
                                                                  "y: { " & _
                                                                  "formatter: function(val) { " & _
                                                                  "return val; " & _
                                                                  "} " & _
                                                                  "} " & _
                                                                  "} " & _
                                                                  "}).render();" & _
                                                                  "});", True)

    End Sub


    Protected Sub ddlChartYear_TextChanged(sender As Object, e As EventArgs) Handles ddlChartYear.TextChanged

        Select Case ddlCntBy.SelectedValue
            Case "STATUS"
                getColumnChartStatus()
            Case "BARANGAY"
                getColumnChartBarangay()
        End Select


    End Sub

    Protected Sub ddlCntBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlCntBy.SelectedIndexChanged
        Select Case ddlCntBy.SelectedValue
            Case "STATUS"
                getColumnChartStatus()
            Case "BARANGAY"
                getColumnChartBarangay()
        End Select

    End Sub

 
End Class
