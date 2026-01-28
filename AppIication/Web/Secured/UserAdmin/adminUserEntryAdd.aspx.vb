Imports System.Data
Partial Class Secured_UserAdmin_adminUserEntryAdd
    Inherits cPageInit_Secured_BS

    Dim _clsUser As New clsUser
    Dim _clsDB As New clsDatabase

    Dim _dtSave As New DataTable
    Dim _dtForm As New DataTable
    Dim _dtLookUp As New DataTable

    Dim _btnOK As New HtmlButton

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ddlUserOffice", "$('#ddlUserOffice').select2({width:'100%'});", True)
        If Not Page.IsPostBack Then
            hfUserID.Value = Session("USERENTRY_ID")
            _clsDB.populateDDLB(ddlUserRoleid, "user_role_name", "user_role_id", "tbl_user_role", "user_role_name", " WHERE is_active='Y' AND last_user <> 'INITIALIZED' ")
            ddlUserRoleid.Items.RemoveAt(0)
            ddlUserRoleid.SelectedValue = "4"

            fillForm()

        End If

        _btnOK = thisMsgBox.FindControl("btnMsgBoxYes")
        AddHandler _btnOK.ServerClick, AddressOf btnOK_Click
    End Sub

    Protected Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        If thisMsgBox.getModalType = "SAVE USER" Then
            saveRecord()
            fillForm()
            thisMsgBox.setModalType("OK")
            thisMsgBox.setInfo("SAVE SUCCESSFUL", "Record has been successfully saved!")
            thisMsgBox.showConfirmBox()

        ElseIf thisMsgBox.getModalType = "CANCEL" Then
            Response.Redirect("adminUserEntry.aspx")
        ElseIf thisMsgBox.getModalType = "RESET" Then
            resetPassword()
            thisMsgBox.setModalType("OK")
            thisMsgBox.setInfo("PASSWORD RESET SUCCESSFUL", "Password has been successfully reset!")
            thisMsgBox.showConfirmBox()
        End If
    End Sub

    Protected Sub fillForm()
        If hfUserID.Value <> "" Then
            With _clsUser
                .getUserInformation(hfUserID.Value)
                hfOldUserID.Value = .userID
                txtUserId.Text = .userID
                txtUserName.Text = .userName
                ddluserroleid.SelectedValue = .userRoleID
                rblIsActive.SelectedValue = .isActive
            End With
            btnresetpassword.Visible = True
        Else
            btnresetpassword.Visible = False
        End If

    End Sub

    Protected Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.ServerClick
        Response.Redirect("adminUserEntry.aspx")
    End Sub

    Protected Sub saveRecord()

        With _clsUser
            .oldUserID = hfOldUserID.Value
            .userID = txtUserId.Text.Trim
            .userName = txtUserName.Text.Trim
            .userRoleID = ddluserroleid.SelectedValue
            .isActive = rblIsActive.SelectedValue
            .lastUser = Session("UserName")
            .saveUser()
            hfUserID.Value = .userID
        End With

    End Sub

    Protected Sub resetPassword()
        With _clsUser
            .userID = hfUserID.Value
            .resetPassword()
        End With

    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        thisMsgBox.setConfirm()
        ' thisMsgBox.setHeader("BLUE")
        Dim dt As New DataTable
        Dim dtUserExist As New DataTable
        If hfOldUserID.Value.ToString = "" Then
            dtUserExist = _clsDB.Fill_DataTable("SELECT user_id FROM tbl_user_info WHERE user_id = '" & txtUserId.Text.Trim & "' LIMIT 1")

            If dtUserExist.Rows.Count > 0 Then
                thisMsgBox.setError("Cannot Save", "User ID " & txtUserId.Text & " Already Exist!")
            Else
                thisMsgBox.setModalType("SAVE USER")
                thisMsgBox.setHeaderText("ADD NEW USER")
                thisMsgBox.setMessage("Save User Information ?")
            End If

        Else
            thisMsgBox.setModalType("SAVE USER")
            thisMsgBox.setHeaderText("UPDATE USER")
            thisMsgBox.setMessage("Update User Information ?")

        End If
        thisMsgBox.showConfirmBox()

    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        thisMsgBox.setConfirm()
        thisMsgBox.setHeader("INDIANRED", "YELLOW")
        If hfTransid.Value.ToString = "" Then
            thisMsgBox.setModalType("CANCEL")
            thisMsgBox.setHeaderText("CANCEL ADD USER")
            thisMsgBox.setMessage("CANCEL adding a new User ?")

        Else
            thisMsgBox.setModalType("CANCEL")
            thisMsgBox.setHeaderText("CANCEL UPDATE USER")
            thisMsgBox.setMessage("CANCEL updating a User ?")

        End If
        thisMsgBox.showConfirmBox()
    End Sub

    Protected Sub btnResetPassword_Click(sender As Object, e As EventArgs) Handles btnresetpassword.Click
        thisMsgBox.setConfirm()
        thisMsgBox.setHeader("BLUE")
        thisMsgBox.setModalType("RESET")
        thisMsgBox.setHeaderText("RESET PASSWORD")
        thisMsgBox.setMessage("RESET Password for this User ?")
        thisMsgBox.showConfirmBox()
    End Sub

End Class
