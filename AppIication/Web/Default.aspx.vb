Imports System.Data
Partial Class _Default
    Inherits System.Web.UI.Page

    Dim _clsDB As New clsDatabase

    ' Dim _clsSeniorCitizenInformation As New clsSeniorCitizenInformation

    Dim _clsVisitor As New clsVisitor

    Dim _clsComments As New clsComments

    Dim _clsSMS As New clsSMSSaveDB

    'Dim _clsRegistrationDetails As New clsRegistrationDetails

    Dim _dtGV As New DataTable

    Dim _btnOK As New HtmlButton

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            Session.Remove("SENIOR_ID")
            Session("SENDSMS") = _clsDB.Get_DB_Item("SELECT default_value FROM tbl_system_default WHERE default_desc = 'notify_sms'")
            If Session("VISITED") <> "VISITED" Then
                Session("VISITED") = "VISITED"
                With _clsVisitor
                    .visitorIp = GetIPAddress()
                    .saveVisitor()
                End With
            End If

            lblTodayVisitor.Text = _clsVisitor.getVisitorCount
            lblTotalVisitor.Text = _clsVisitor.getVisitorCount("ALL")

        End If

        _btnOK = thisMsgBox.FindControl("btnMsgBoxYes")
        AddHandler _btnOK.ServerClick, AddressOf btnOK_Click

    End Sub

    Protected Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        If thisMsgBox.getModalType = "COMMENTS" Then
            saveComments()
            thisMsgBox.setModalType("OKCOMMENTS")
            thisMsgBox.setInfo("COMMENT INFO", "COMMENT SENT SUCCESSFULLY")
            thisMsgBox.showConfirmBox()
        ElseIf thisMsgBox.getModalType = "OKCOMMENTS" Then
            Response.Redirect("Default.aspx")
        End If

    End Sub

    Public Shared Function GetIPAddress() As String
        Dim context As System.Web.HttpContext = System.Web.HttpContext.Current
        Dim sIPAddress As String = context.Request.ServerVariables("HTTP_X_FORWARDED_FOR")
        If String.IsNullOrEmpty(sIPAddress) Then
            Return context.Request.ServerVariables("REMOTE_ADDR")
        Else
            Dim ipArray As String() = sIPAddress.Split(New [Char]() {","c})
            Return ipArray(0)
        End If
    End Function

    Protected Sub btnShowNewRegistration_ServerClick(sender As Object, e As EventArgs) Handles btnShowNewRegistration.ServerClick
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mdlCaptcha", "var myModal = new bootstrap.Modal(document.getElementById('mdlCaptcha'), {});  myModal.show();", True)
    End Sub

    Protected Sub btnContinueCaptcha_ServerClick(sender As Object, e As EventArgs) Handles btnContinueCaptcha.ServerClick
        Session("APP_TYPE") = "NEW"
        Session("SENIOR_ID") = DateTime.Now.ToString("MMddyyyymmhhss") & Left(Guid.NewGuid().ToString.Replace("-", ""), 25).ToUpper
        Response.Redirect("scid.aspx")
    End Sub

    'UPDATE
    Protected Sub btnShowUpdateRegistration_ServerClick(sender As Object, e As EventArgs) Handles btnShowUpdateRegistration.ServerClick
        ' dtpUpdateBdate.Value = DateTime.Now.Date.AddYears(-60).ToString("yyyy-MM-dd")
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mdlSeniorUpdate", "var myModal = new bootstrap.Modal(document.getElementById('mdlSeniorUpdate'), {});  myModal.show();", True)
    End Sub

    Protected Sub btnContinueUpdate_ServerClick(sender As Object, e As EventArgs) Handles btnContinueUpdate.ServerClick
        Dim dtCheck As New DataTable

        dtCheck = _clsDB.Fill_DataTable("SELECT senior_id,ref_status,ref_code FROM tbl_senior_citizen_information WHERE ref_code = '" & txtUpdateRefCode.Text.Trim.ToUpper & "' AND is_active = 'Y' LIMIT 1")

        If dtCheck.Rows.Count > 0 Then

            If dtCheck.Rows(0)("ref_status") = "PENDING" Or dtCheck.Rows(0)("ref_status") = "REGISTRATION" Then
                Session("APP_TYPE") = "UPDATE"
                Session("SENIOR_ID") = dtCheck.Rows(0)("senior_id")
                Response.Redirect("scid.aspx")
            Else
                '_clsRegistrationDetails.getRegistrationCommentsSC(dtCheck.Rows(0)("senior_id"), dtCheck.Rows(0)("ref_status"))

                'thisMsgBox.setInfo("Cannot Update", "Registration Status. <br/>" & _
                '                   "Reference No.: " & dtCheck.Rows(0)("ref_code") & "<br/>" & _
                '                   "Status: " & dtCheck.Rows(0)("ref_status") & "<br/>" & _
                '                   "Remarks: " & _clsRegistrationDetails.remarks)
                'thisMsgBox.showConfirmBox()
            End If

        Else
            thisMsgBox.setError("Cannot Update", "Reference/Record not found!")
            thisMsgBox.showConfirmBox()
        End If

    End Sub

    'STATUS
    Protected Sub btnShowRegistrationStatus_ServerClick(sender As Object, e As EventArgs) Handles btnShowRegistrationStatus.ServerClick
        ' dtpStatusBDate.Value = DateTime.Now.Date.AddYears(-60).ToString("yyyy-MM-dd")
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mdlSeniorStatus", "var myModal = new bootstrap.Modal(document.getElementById('mdlSeniorStatus'), {});  myModal.show();", True)
    End Sub

    Protected Sub btnContinueStatus_ServerClick(sender As Object, e As EventArgs) Handles btnContinueStatus.ServerClick
        Dim dtCheck As New DataTable

        dtCheck = _clsDB.Fill_DataTable("SELECT senior_id FROM tbl_senior_citizen_information WHERE ref_code = '" & txtStatusRefCode.Text.Trim.ToUpper & "' AND is_active = 'Y' LIMIT 1")

        If dtCheck.Rows.Count > 0 Then
            Session("APP_TYPE") = "STATUS"
            Session("SENIOR_ID") = dtCheck.Rows(0)("senior_id")
            'Response.Redirect("scid.aspx")

            fillStatusDetails(Session("SENIOR_ID"))
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "btnMdlStatusClose", " document.getElementById('btnMdlStatusClose').click();", True)
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mdlSeniorStatusDetails", "var myModal = new bootstrap.Modal(document.getElementById('mdlSeniorStatusDetails'), {});  myModal.show();", True)
        Else
            thisMsgBox.setError("Cannot Update", "Reference/Record not found!")
            thisMsgBox.showConfirmBox()
        End If

    End Sub

    Private Sub fillStatusDetails(ByVal _thisId As String)

        'With _clsSeniorCitizenInformation
        '    .getSeniorCitizenInformationDetails(_thisId)
        '    txtStatusDetailsName.Text = .lastName & ", " & .firstName & " " & .extName & " " & .middleName
        '    txtStatusDetailsRefCode.Text = .refCode
        '    txtStatusDetailsBdate.Text = .dateOfBirth
        '    txtStatusDetails.Text = .refStatus

        '    _clsRegistrationDetails.getRegistrationCommentsSC(_thisId, .refStatus)

        '    txtStatusRemarks.Text = _clsRegistrationDetails.remarks
        'End With

    End Sub

    'COMMENTS
    Protected Sub btnShowComments_ServerClick(sender As Object, e As EventArgs) Handles btnShowComments.ServerClick

        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mdlComment", "var myModal = new bootstrap.Modal(document.getElementById('mdlComment'), {});  myModal.show();", True)

    End Sub

    Private Sub saveComments()

        With _clsComments
            .initialize()
            .commentName = txtCommentName.Text.Trim.ToUpper
            .commentContactno = txtCommentContact.Text.Trim
            .comment = txtComments.Text.Trim
            .commentIp = GetIPAddress()
            .saveComments()
        End With

        If Session("SENDSMS") = "Y" Then
            If Session("NOTIFYME") = "Y" Then
                Dim celNum() As String = _clsDB.Get_DB_Item("SELECT cel_numbers FROM tbl_notify_sms").ToString.Split(",")
                For Each cel As String In celNum
                    _clsSMS.saveSMSDB("SCID", GetIPAddress(), cel, "SENIOR CITIZEN ID: " & _clsComments.comment & " -" & _clsComments.commentName)
                Next
            End If
        End If

    End Sub

    Protected Sub btnContinueComments_ServerClick(sender As Object, e As EventArgs) Handles btnContinueComments.ServerClick
        thisMsgBox.setModalType("COMMENTS")
        thisMsgBox.setConfirm()
        thisMsgBox.setHeaderText("SUBMIT COMMENTS/SUGGESTIONS")
        thisMsgBox.setMessage("Are you sure to send your comments/suggestions?")
        thisMsgBox.showConfirmBox()
    End Sub

End Class
