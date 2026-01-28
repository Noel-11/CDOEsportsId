Imports System.Data

Partial Class Secured_UserRoleAdd
    Inherits cPageInit_Secured_BS

    Dim _clsDB As New clsDatabase
    Dim _clsUserRole As New clsUserRole

    Dim _btnOK As New HtmlButton

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        hfUserRoleId.Value = Session("USER_ROLE_ID")
        If Not Page.IsPostBack Then          
            fillForm()
        End If

        _btnOK = thisMsgBox.FindControl("btnMsgBoxYes")
        AddHandler _btnOK.ServerClick, AddressOf btnOK_Click
    End Sub

    Protected Sub btnHome_Click(sender As Object, e As EventArgs)
        Response.Redirect("UserRole.aspx")
    End Sub

    Protected Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If thisMsgBox.getModalType = "SAVE" Then
            saveRecord()

        ElseIf thisMsgBox.getModalType = "CANCEL NEW" Then
            Response.Redirect("UserRole.aspx")
        ElseIf thisMsgBox.getModalType = "CANCEL UPDATE" Then
            fillForm()
        End If

    End Sub
    
    Protected Sub fillForm()
        If hfUserRoleId.Value <> "" Then
            With _clsUserRole
                .getUserRole(hfUserRoleId.Value)
                txtuserrole.Text = .userRoleName
                txtdescription.Text = .userRoleDescription
                rblIsActive.SelectedValue = .isActive
            End With
        End If
    End Sub

    Protected Sub saveRecord()

        With _clsUserRole
            .initialize()
            .userRoleID = hfUserRoleId.Value
            .userRoleName = Trim(txtuserrole.Text)
            .userRoleDescription = Trim(txtdescription.Text)
            .isActive = rblIsActive.SelectedValue
            .lastUser = Session("UserName")
            .saveUserRole()
            Session("USER_ROLE_ID") = .userRoleID
            hfUserRoleId.Value = .userRoleID
        End With

    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Dim dtCheckUserRole As New DataTable

            thisMsgBox.setConfirm()
        If hfUserRoleId.Value.ToString = "" Then
            dtCheckUserRole = _clsDB.Fill_DataTable("SELECT user_role_id FROM tbl_user_role WHERE user_role_name = '" & txtuserrole.Text.Trim & "' LIMIT 1")

            If dtCheckUserRole.Rows.Count > 0 Then
                thisMsgBox.setError("EXIST", "User Role already exists!")
            Else
                thisMsgBox.setModalType("SAVE")
                thisMsgBox.setHeaderText("ADD NEW USER ROLE")
                thisMsgBox.setMessage("Save a new User Role ?")
            End If

        Else
            dtCheckUserRole = _clsDB.Fill_DataTable("SELECT user_role_id FROM tbl_user_role WHERE user_role_name = '" & txtuserrole.Text.Trim & "' AND user_role_id <> '" & hfUserRoleId.Value & "' LIMIT 1")

            If dtCheckUserRole.Rows.Count > 0 Then
                thisMsgBox.setError("EXIST", "User Role already exists!")
            Else
                thisMsgBox.setModalType("SAVE")
                thisMsgBox.setHeaderText("UPDATE USER ROLE")
                thisMsgBox.setMessage("Update User Role?")
            End If

        End If

        thisMsgBox.showConfirmBox()

    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        thisMsgBox.setConfirm()
        thisMsgBox.setHeader("RED", "YELLOW")
        If hfUserRoleId.Value.ToString = "" Then
            thisMsgBox.setModalType("CANCEL NEW")
            thisMsgBox.setHeaderText("CANCEL ADD")
            thisMsgBox.setMessage("CANCEL adding a new User Role ?")
        Else
            thisMsgBox.setModalType("CANCEL UPDATE")
            thisMsgBox.setHeaderText("CANCEL UPDATE")
            thisMsgBox.setMessage("CANCEL update for this User Role ?")
        End If
        thisMsgBox.showConfirmBox()
    End Sub
   

End Class
