
Partial Class Secured_adUserChangePassword : Inherits System.Web.UI.Page

    Dim _clsUser As New clsUser
    Dim _btnOK As New Button
    Dim _btnSave As New Button
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack Then
            If Not String.IsNullOrEmpty(txtCurrentPassword.Text.Trim()) Then
                txtCurrentPassword.Attributes.Add("value", txtCurrentPassword.Text)
            End If
            If Not String.IsNullOrEmpty(txtNewPassword.Text.Trim()) Then
                txtNewPassword.Attributes.Add("value", txtNewPassword.Text)
            End If
            If Not String.IsNullOrEmpty(txtRetypePassword.Text.Trim()) Then
                txtRetypePassword.Attributes.Add("value", txtRetypePassword.Text)
            End If
        End If

        _btnOK = thisMsgBox.FindControl("btnMsgBoxYes")
        AddHandler _btnOK.Click, AddressOf btnOK_Click

        _btnSave = thisMsgBox.FindControl("btnSave")
        AddHandler _btnSave.Click, AddressOf btnSave_Click
    End Sub
  
    Protected Function Check_Entries() As String
        Dim strMessage As String = ""

        If Trim(txtCurrentPassword.Text) = "" Then strMessage = "Current password must not be blank"

        If Trim(txtNewPassword.Text) = "" Then strMessage = "New password must not be blank"

        If Trim(txtNewPassword.Text) <> Trim(txtRetypePassword.Text) Then strMessage = "New password and Retype Password must be the same"

        If _clsUser.validateUserLogon(Session("UserId"), txtCurrentPassword.Text) = False Then strMessage = "Please provide the valid Current Password"

        Return strMessage
    End Function

    Protected Sub saveRecord()

        With _clsUser
            .userID = Session("UserId")
            .userPassword = Trim(txtNewPassword.Text)
            .updatePassword()
        End With
    End Sub


    Protected Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If thisMsgBox.getModalType = "SAVE" Then
            saveRecord()
            thisMsgBox.modalInfo("Successfully Changed Password!")            
        ElseIf thisMsgBox.getModalType = "CANCEL" Then
            Response.Redirect("~/Secured/Default.aspx")
        Else
            Response.Redirect("~/Secured/Default.aspx")
        End If

    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim strMessage As String = Check_Entries()

        If strMessage = "" Then
            thisMsgBox.modalSave()
        Else
            thisErrorMsgBox.setInformation("INVALID", strMessage)
            thisErrorMsgBox.showErrorMsgBox()
        End If

    End Sub

End Class
