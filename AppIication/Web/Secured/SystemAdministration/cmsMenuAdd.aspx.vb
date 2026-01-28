Imports System.Data

Partial Class Secured_cmsMenuAdd
    Inherits cPageInit_Secured_BS

    Dim clsLibrary As New clsLibrary
    Dim _clsMainCMS As New clsCMS
    Dim _clsSubCMS As New clsCMS
    Dim _clsDB As New clsDatabase

    Dim _strcmsmenuId As String
    Dim _strparent_id As String
    Dim _intmenulevel As Integer

    Dim _btnOK As New HtmlButton

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _strcmsmenuId = Request("ncmsmenuId")
        _strparent_id = IIf(Request("nparent_id") = Nothing, "0", Request("nparent_id"))

        If _strparent_id = "0" Then
            _intmenulevel = 1
        Else
            _intmenulevel = 2
        End If

        If Not Page.IsPostBack Then
            fillForm()
        End If

        _btnOK = thisMsgBox.FindControl("btnMsgBoxYes")
        AddHandler _btnOK.ServerClick, AddressOf btnOK_Click
    End Sub

    Protected Sub btnHome_Click(sender As Object, e As EventArgs)
        Response.Redirect("cmsMenu.aspx?nparent_id=" & _strparent_id)
    End Sub

    Protected Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If thisMsgBox.getModalType = "SAVE MENU" Then
            saveRecord()
            thisMsgBox.setModalType("OK")
            thisMsgBox.setInfo("SAVE SUCCESSFUL", "Record has been successfully saved!")
            thisMsgBox.showConfirmBox()
        ElseIf thisMsgBox.getModalType = "CANCEL" Then
            fillForm()
        End If
    End Sub

    Protected Sub fillForm()
        If _strcmsmenuId <> "" Then
            With _clsSubCMS
                .getCMSMenu(_strcmsmenuId)
                txtmenu.Text = .menuName
                txtpageurl.Text = .menuPageURL
                txtsortorder.Text = .menuSortOrder
                rdolispublic.SelectedValue = .isPublic
                rdolisactive.SelectedValue = .isActive
            End With
        Else
            If _intmenulevel = 2 Then
                With _clsMainCMS
                    .getCMSMenu(_strparent_id)
                    rdolispublic.SelectedValue = .isPublic
                End With
                rdolispublic.Enabled = False
            End If

        End If
    End Sub

    Protected Sub saveRecord()
        With _clsSubCMS
            .menuID = Trim(_strcmsmenuId)
            .menuParentID = _strparent_id
            .menuName = Trim(txtmenu.Text)
            .menuPageURL = Trim(txtpageurl.Text)
            .menuLevel = _intmenulevel
            .menuSortOrder = Trim(txtsortorder.Text)
            .isPublic = rdolispublic.SelectedValue
            .isActive = rdolisactive.SelectedValue
            .lastUser = Session("UserName")
            .saveCMSMenu()
        End With

       
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        thisMsgBox.setConfirm()
        ' thisMsgBox.setHeader("BLUE")
        If _strcmsmenuId.ToString = "" Then
            thisMsgBox.setModalType("SAVE MENU")
            thisMsgBox.setHeaderText("ADD NEW MENU")
            thisMsgBox.setMessage("Save Menu Information ?")

        Else
            thisMsgBox.setModalType("SAVE MENU")
            thisMsgBox.setHeaderText("UPDATE MENU")
            thisMsgBox.setMessage("Update Menu Information ?")

        End If
        thisMsgBox.showConfirmBox()

    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        thisMsgBox.setConfirm()
        thisMsgBox.setHeader("INDIANRED", "YELLOW")
        If _strcmsmenuId.ToString = "" Then
            thisMsgBox.setModalType("CANCEL")
            thisMsgBox.setHeaderText("CANCEL ADD MENU")
            thisMsgBox.setMessage("CANCEL adding a new Menu ?")

        Else
            thisMsgBox.setModalType("CANCEL")
            thisMsgBox.setHeaderText("CANCEL UPDATE MENU")
            thisMsgBox.setMessage("CANCEL updating a Menu ?")

        End If
        thisMsgBox.showConfirmBox()
    End Sub

End Class
