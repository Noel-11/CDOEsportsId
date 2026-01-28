Imports System.Data
Partial Class Secured_SystemAdministration_UserEntryAdd
    Inherits cPageInit_Secured_BS

    Dim _clsUser As New clsUser
    Dim _clsDB As New clsDatabase

    'Dim _dtSave As New DataTable
    'Dim _dtForm As New DataTable
    'Dim _dtLookUp As New DataTable

    Dim _btnOK As New HtmlButton

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        hfUserID.Value = Session("USERENTRY_ID")
        If Not Page.IsPostBack Then
            _clsDB.populateDDLB(ddlUserRole, "user_role_name", "user_role_id", "tbl_user_role", "user_role_name", " WHERE is_active='Y' AND last_user <> 'INITIALIZED' ")
            ddlUserRole.Items.RemoveAt(0)
            ddlUserRole.SelectedValue = "4"
            fillForm()
        End If
        _btnOK = thisMsgBox.FindControl("btnMsgBoxYes")
        AddHandler _btnOK.ServerClick, AddressOf btnOK_Click
    End Sub


    Protected Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.ServerClick
        Response.Redirect("UserEntry.aspx")
    End Sub

    Protected Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        If thisMsgBox.getModalType = "SAVE" Then
            saveRecord()
            thisMsgBox.setModalType("OK")
            thisMsgBox.setInfo("SAVE SUCCESSFUL", "Record Successfully SAVED!")
            thisMsgBox.showConfirmBox()
            'Response.Redirect("DocumentAdd.aspx")
        ElseIf thisMsgBox.getModalType = "CANCEL NEW" Then
            Response.Redirect("UserEntry.aspx")
        ElseIf thisMsgBox.getModalType = "CANCEL UPDATE" Then
            Response.Redirect("UserEntryAdd.aspx")
        ElseIf thisMsgBox.getModalType = "RESET PASSWORD" Then
            resetPassword()
            thisMsgBox.setModalType("OK")
            thisMsgBox.setInfo("PASSWORD RESET", "Password has been reset for this User")
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
                ddlUserRole.SelectedValue = .userRoleID
                rblIsActive.SelectedValue = .isActive
            End With
        Else
            btnresetpassword.Visible = False
        End If

    End Sub

    Protected Sub saveRecord()
        Try
            With _clsUser
                .initialize()
                .oldUserID = hfOldUserID.Value
                .userID = txtUserId.Text.Trim
                .userName = txtUserName.Text.Trim
                .userRoleID = ddlUserRole.SelectedValue
                .isActive = rblIsActive.SelectedValue
                .saveUser()
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
      

    End Sub

    Protected Sub resetPassword()
        With _clsUser
            .userID = hfUserID.Value
            .resetPassword()
        End With
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If hfOldUserID.Value = "" And _clsUser.userExists(txtUserId.Text) Then
            thisMsgBox.setInfo("EXIST", "User ID already exists!")
            thisMsgBox.setHeader("RED", "YELLOW")
            thisMsgBox.showConfirmBox()
            Exit Sub
        End If

        thisMsgBox.setConfirm()
        If hfUserID.Value.ToString = "" Then
            thisMsgBox.setModalType("SAVE")
            thisMsgBox.setHeaderText("ADD NEW USER")
            thisMsgBox.setMessage("Save a new User ?")

        Else
            thisMsgBox.setModalType("SAVE")
            thisMsgBox.setHeaderText("UPDATE USER")
            thisMsgBox.setMessage("Update User Info?")

        End If
        thisMsgBox.showConfirmBox()

    End Sub


    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        thisMsgBox.setConfirm()
        thisMsgBox.setHeader("RED", "YELLOW")
        If hfUserID.Value.ToString = "" Then
            thisMsgBox.setModalType("CANCEL NEW")
            thisMsgBox.setHeaderText("CANCEL ADD")
            thisMsgBox.setMessage("CANCEL adding a new User ?")
        Else
            thisMsgBox.setModalType("SAVE UPDATE")
            thisMsgBox.setHeaderText("CANCEL UPDATE")
            thisMsgBox.setMessage("CANCEL update for this User ?")
        End If
        thisMsgBox.showConfirmBox()
    End Sub



    Protected Sub btnResetPassword_Click(sender As Object, e As EventArgs) Handles btnResetPassword.Click
        thisMsgBox.setConfirm()
        thisMsgBox.setHeader("BLUE", "YELLOW")
        thisMsgBox.setModalType("RESET PASSWORD")
        thisMsgBox.setHeaderText("RESET PASSWORD")
        thisMsgBox.setMessage("Reset the password of this User?")
        thisMsgBox.showConfirmBox()
    End Sub

End Class