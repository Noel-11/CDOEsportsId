Imports System.Data
Imports Microsoft.Reporting.WebForms
Imports QRCoder
Imports System.Drawing
Partial Class GenerateId
    Inherits System.Web.UI.Page

    Dim clsLibrary As New clsLibrary
    Dim _clsDB As New clsDatabase
    Dim _clsUser As New clsUser

    Dim _dtGV As New DataTable


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Session.Remove("USERENTRY_ID")

        If Not Page.IsPostBack Then
            fillGridView()
        End If

    End Sub


    Protected Sub fillGridView()

        Dim sql As String = ""

        sql = "SELECT tbl_registered_users.*,tbl_ref_barangay.barangay  FROM tbl_registered_users " & _
              "INNER JOIN tbl_ref_barangay ON tbl_registered_users.barangay_id = tbl_ref_barangay.id " & _
              "WHERE full_name LIKE '%" & txtSearch.Text.Trim & "%' "


        _dtGV = _clsDB.Fill_DataTable(sql)

        _gv.DataSource = _dtGV
        _gv.DataBind()
        If Not IsNothing(Session("NewPageIndex")) Then
            _lblPaging.Text = clsLibrary.fnSetCurrentPage(Integer.Parse(Session("NewPageIndex").ToString()) + 1, _dtGV)
        Else
            _lblPaging.Text = clsLibrary.fnSetCurrentPage(0, _dtGV)
        End If
    End Sub

    Protected Sub cmdGVGenerate(ByVal sender As Object, ByVal e As CommandEventArgs)
        Session("AE_STATUS") = "EDIT"
        hfTransId.Value = e.CommandArgument.ToString()

        Session("ID_PATH") = "~/Secured/Report/rptGenerateId_Front.rdlc"

        generateId(Session("ID_PATH"), "PDF")

        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mdlGenIDReport", "var myModal = new bootstrap.Modal(document.getElementById('mdlGenIDReport'), {});  myModal.show();", True)

    End Sub
   

    Protected Sub _gv_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles _gv.PageIndexChanging
        Session("NewPageIndex") = e.NewPageIndex
        _gv.PageIndex = e.NewPageIndex
        fillGridView()

    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs)
        fillGridView()
    End Sub

#Region "GENERATE ID"
    Protected Sub btnIDFront_ServerClick(sender As Object, e As EventArgs) Handles btnIDFront.ServerClick
        Session("ID_PATH") = "~/Secured/Report/rptGenerateId_Front.rdlc"
        generateId(Session("ID_PATH"), "PDF")
        Session("ID_Page") = "Front"
    End Sub

    Protected Sub btnIDBack_ServerClick(sender As Object, e As EventArgs) Handles btnIDBack.ServerClick
        Session("ID_PATH") = "~/Secured/Report/rptGenerateId_BACK.rdlc"

        generateId(Session("ID_PATH"), "PDF")
        Session("ID_Page") = "Back"
    End Sub

    Protected Sub btnExport_ServerClick(sender As Object, e As EventArgs)
        generateId(Session("ID_PATH"), "IMAGE")
    End Sub

    Private Sub generateId(ByVal _thisPath As String, ByVal _thisType As String)
        ' Variables
        Dim warnings(-1) As Warning
        Dim streamIds(-1) As String
        Dim mimeType As String = String.Empty
        Dim encoding As String = String.Empty
        Dim extension As String = String.Empty

        Dim dtID As New DataTable
        dtID = getIDDetails()

        Dim dsId As New ReportDataSource("ds_id", dtID)

        Dim viewer As ReportViewer = New ReportViewer

        viewer.ProcessingMode = ProcessingMode.Local
        'Secured/Report/rptGenerateId_Front.rdlc
        viewer.LocalReport.ReportPath = Server.MapPath(Session("ID_PATH"))
        viewer.LocalReport.DataSources.Clear()
        viewer.LocalReport.DataSources.Add(dsId)

        If _thisPath = "~/Secured/Report/rptGenerateId_Front.rdlc" Then
            Dim dsQR As New ReportDataSource("ds_QR", getQR(dtID))
            viewer.LocalReport.DataSources.Add(dsQR)
        End If

        If _thisType = "IMAGE" Then

            Dim renderedBytes As Byte()

            renderedBytes = viewer.LocalReport.Render("Image", "<DeviceInfo><OutputFormat>JPEG</OutputFormat></DeviceInfo>", Nothing, Nothing, Nothing, Nothing, Nothing)

            Context.Response.Buffer = False
            Response.Buffer = True
            Response.AddHeader("content-disposition", "attachment;filename=" & dtID.Rows(0)("full_name") & "_" & Session("ID_Page") & ".jpeg")
            Response.ContentType = "image/jpeg"
            Response.BinaryWrite(renderedBytes)
            Context.Response.Flush()

        Else
            Dim bytes() As Byte = viewer.LocalReport.Render("PDF", Nothing, mimeType, encoding, extension, streamIds, warnings)

            Session("pdfBytes") = bytes
            ltEmbedID.Text = String.Format("<object data=""{0}{1}"" type=""application/pdf"" width=""100%"" height=""600px""></object>", ResolveUrl("ReportHandler.ashx"), "")
        End If

    End Sub

    Private Function getQR(ByVal _thisData As DataTable) As DataTable
        Dim dt As New DataTable
        Dim _clsDB As New clsDatabase

        dt = _clsDB.Fill_DataTable("SELECT '' AS qr_code")

        If _thisData.Rows.Count > 0 Then

            Dim qrGenerator As QRCodeGenerator = New QRCodeGenerator

            Dim preUrl As String = ConfigurationManager.AppSettings("preUrl").ToString

            Dim qrStr As String = ""
            Dim _cnt As Integer = 0

            For Each dr As DataRow In _thisData.Rows
                For Each drCol As DataColumn In _thisData.Columns
                    _cnt += 1

                    qrStr += IIf(_cnt > 1, ",", "") & drCol.ColumnName.ToString & ": " & dr(drCol.ColumnName)

                Next
            Next

            Dim qrCodeData As QRCodeData = qrGenerator.CreateQrCode(qrStr, QRCodeGenerator.ECCLevel.Q)
            Dim qrCode As QRCode = New QRCode(qrCodeData)
            Dim qrCodeImage As Bitmap = qrCode.GetGraphic(10, Color.Black, Color.White, CType(Bitmap.FromFile(Server.MapPath("~/Images/ICTlogo2.png")), Bitmap))

            Dim imageConverter As New ImageConverter()
            Dim imageByte As Byte() = DirectCast(imageConverter.ConvertTo(qrCodeImage, GetType(Byte())), Byte())

            dt.Rows(0)("qr_code") = Convert.ToBase64String(imageByte)
        End If

        Return dt

    End Function

    Private Function getIDDetails() As DataTable

        Dim dt As New DataTable

        Dim sql As String = ""

        sql = "SELECT tbl_registered_users.id,id_no, full_name, sex, age, contact_number,tbl_ref_barangay.barangay FROM tbl_registered_users " & _
           "INNER JOIN tbl_ref_barangay ON tbl_registered_users.barangay_id = tbl_ref_barangay.id " & _
           "WHERE tbl_registered_users.id = '" & hfTransId.Value & "' LIMIT 1 "

        dt = _clsDB.Fill_DataTable(sql)

        Return dt

    End Function

#End Region


End Class
