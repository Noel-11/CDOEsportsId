Imports System.Data
Partial Class Secured_SystemAdministration_RolePermissionAdd
    Inherits cPageInit_Secured_BS

    Dim _clsCMS As New clsCMS
    Dim _clsDB As New clsDatabase
    Dim _clsCMSPermission As New clsCMSPermission


    Dim _struserroleid As String
    Dim _ctrControl As Integer = 0
    Dim dtPermission As New DataTable

    Dim _btnOK As New HtmlButton

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        _struserroleid = Request("nuserroleid")

        If Not Page.IsPostBack Then
            Dim _clsRole As New clsUserRole
            _clsRole.getUserRole(_struserroleid)
            lblName.Text = _clsRole.userRoleName
            fillGridView()
        End If

        _btnOK = thisMsgBox.FindControl("btnMsgBoxYes")
        AddHandler _btnOK.ServerClick, AddressOf btnOK_Click

    End Sub
    Protected Sub btnHome_Click(sender As Object, e As EventArgs)
        Response.Redirect("RolePermission.aspx")
    End Sub

    Protected Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If thisMsgBox.getModalType = "SAVE" Then
            saveRecord()

        ElseIf thisMsgBox.getModalType = "CANCEL" Then
            fillGridView()
        End If

    End Sub

    Protected Sub fillGridView()
        Dim dtParent As New DataTable
        Dim dtChild As New DataTable

        dtPermission = _clsDB.Fill_DataTable("SELECT '' as menu_id, '' as menu_type, '' as page_url, 'False' as menu_name, 'False' as can_access, 'False' as can_create, 'False' as can_update, 'False' as can_delete, 'False' as can_report, 'False' as can_export")
        dtPermission.Clear()

        dtParent = _clsCMS.browseParentCMSMenu()
        For Each dr As DataRow In dtParent.Rows

            dtChild = _clsCMS.browseChildCMSMenu(dr("menu_id"))
            Insert_Data(dr, "PARENT")

            For Each drChild As DataRow In dtChild.Rows
                Insert_Data(drChild, "CHILD")
            Next
        Next

        Update_Permission(dtPermission)

        _gv.Columns(0).Visible = True
        _gv.Columns(1).Visible = True
        _gv.Columns(2).Visible = True
        _gv.DataSource = dtPermission
        _gv.DataBind()
        _gv.Columns(0).Visible = False
        _gv.Columns(1).Visible = False
        _gv.Columns(2).Visible = False
    End Sub

    Public Sub Insert_Data(ByVal dr As DataRow, ByVal _menutype As String)
        Dim drc As DataRowCollection
        Dim nr As DataRow

        drc = dtPermission.Rows
        nr = dtPermission.NewRow

        Dim _strPage As String()
        Dim _strScript As String
        _strScript = dr("page_url").ToString()
        _strPage = _strScript.Split("/")
        _strScript = _strPage(_strPage.Length - 1)


        nr("menu_id") = dr("menu_id")
        nr("menu_type") = _menutype
        nr("page_url") = _strScript
        nr("menu_name") = dr("menu_name")
        nr("can_access") = "False"
        nr("can_create") = "False"
        nr("can_update") = "False"
        nr("can_delete") = "False"
        nr("can_report") = "False"
        nr("can_export") = "False"

        drc.Add(nr)
    End Sub
    Public Sub Update_Permission(ByRef dt As DataTable)
        Dim dtParent As New DataTable
        Dim dtChild As New DataTable

        dtParent = _clsCMSPermission.fnModuleRolePermissionParent(_struserroleid)

        If dtParent.Rows.Count > 0 Then
            Dim pctr As Integer = 0
            For Each drParent As DataRow In dtParent.Rows
                For pctr = 0 To dt.Rows.Count - 1
                    If drParent("menu_id") = dt.Rows(pctr)("menu_id") Then
                        dt.Rows(pctr)("can_access") = drParent("can_access")
                        dt.Rows(pctr)("can_create") = drParent("can_create")
                        dt.Rows(pctr)("can_update") = drParent("can_update")
                        dt.Rows(pctr)("can_delete") = drParent("can_delete")
                        dt.Rows(pctr)("can_report") = drParent("can_report")
                        dt.Rows(pctr)("can_export") = drParent("can_export")
                        Exit For
                    End If
                Next

                dtChild = _clsCMSPermission.fnModuleRolePermissionChild(drParent("menu_id"), _struserroleid)

                For Each drChild As DataRow In dtChild.Rows
                    For pctr = 0 To dt.Rows.Count - 1
                        If drChild("menu_id") = dt.Rows(pctr)("menu_id") Then
                            dt.Rows(pctr)("can_access") = drChild("can_access")
                            dt.Rows(pctr)("can_create") = drChild("can_create")
                            dt.Rows(pctr)("can_update") = drChild("can_update")
                            dt.Rows(pctr)("can_delete") = drChild("can_delete")
                            dt.Rows(pctr)("can_report") = drChild("can_report")
                            dt.Rows(pctr)("can_export") = drChild("can_export")
                            Exit For
                        End If
                    Next

                Next
            Next


        End If


    End Sub

    Protected Sub _gv_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles _gv.RowDataBound
        For Each dgr As GridViewRow In _gv.Rows
            If dgr.Cells(0).Text = "PARENT" Then
                dgr.Font.Bold = True
                dgr.BackColor = Drawing.Color.Black
                dgr.ForeColor = Drawing.Color.White
                dgr.Cells(0).FindControl("chkCreate").Visible = False
                dgr.Cells(0).FindControl("chkUpdate").Visible = False
                dgr.Cells(0).FindControl("chkDelete").Visible = False
                dgr.Cells(0).FindControl("chkReport").Visible = False
                dgr.Cells(0).FindControl("chkExport").Visible = False
            End If
        Next
    End Sub

    Public Sub saveRecord()
        Dim dbBoolean As New clsDimboMySQL.clsUtilities

        _clsCMSPermission.deleteRolePermission(_struserroleid)

        For Each gvr As GridViewRow In _gv.Rows

            With _clsCMSPermission
                .accessUserRoleID = _struserroleid
                .accessUserID = ""
                .accessMenuID = gvr.Cells(1).Text
                .accessPageURL = gvr.Cells(2).Text
                .canAccess = dbBoolean.booleanToString(CType(gvr.FindControl("chkAccess"), CheckBox).Checked, "Y", "N")
                .canCreate = dbBoolean.booleanToString(CType(gvr.FindControl("chkCreate"), CheckBox).Checked, "Y", "N")
                .canUpdate = dbBoolean.booleanToString(CType(gvr.FindControl("chkUpdate"), CheckBox).Checked, "Y", "N")
                .canDelete = dbBoolean.booleanToString(CType(gvr.FindControl("chkDelete"), CheckBox).Checked, "Y", "N")
                .canReport = dbBoolean.booleanToString(CType(gvr.FindControl("chkReport"), CheckBox).Checked, "Y", "N")
                .canExport = dbBoolean.booleanToString(CType(gvr.FindControl("chkExport"), CheckBox).Checked, "Y", "N")
                .lastUser = Session("UserName")
                .saveUserPermission()
            End With

        Next

    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        thisMsgBox.setConfirm()

        thisMsgBox.setModalType("SAVE")
        thisMsgBox.setHeaderText("SAVE PERMISSION")
        thisMsgBox.setMessage("Save User Permission ?")


        thisMsgBox.showConfirmBox()

    End Sub

    Protected Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        thisMsgBox.setConfirm()

        thisMsgBox.setModalType("CANCEL")
        thisMsgBox.setHeaderText("CANCEL UPDATING PERMISSION")
        thisMsgBox.setMessage("CANCEL Updating User Permmission ?")
        thisMsgBox.showConfirmBox()
    End Sub

End Class
