Imports System.Data
Partial Class Secured_SystemAdministration_UserPermission
    Inherits cPageInit_Secured_BS

    Dim _clsLibrary As New clsLibrary
    Dim _clsDB As New clsDatabase
    Dim _clsUser As New clsUser

    Dim _dtGV As New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            fillGridView()
        End If

    End Sub

    Protected Sub fillGridView()

        If Session("UserId") = "admin" Then
            _dtGV = _clsUser.browseUser(txtSearch.Text.Trim, "ADMIN")
        Else
            _dtGV = _clsUser.browseUser(txtSearch.Text.Trim)
        End If


        _gv.DataSource = _dtGV
        _gv.DataBind()
        If Not IsNothing(Session("NewPageIndex")) Then
            _lblPaging.Text = _clsLibrary.fnSetCurrentPage(Integer.Parse(Session("NewPageIndex").ToString()) + 1, _dtGV)
        Else
            _lblPaging.Text = _clsLibrary.fnSetCurrentPage(0, _dtGV)
        End If
    End Sub

    Protected Sub _gv_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles _gv.PageIndexChanging
        Session("NewPageIndex") = e.NewPageIndex
        _gv.PageIndex = e.NewPageIndex
        fillGridView()
        '_lblPaging.Text = _clsLibrary.fnSetCurrentPage(e.NewPageIndex + 1, _dtGV)
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs)
        fillGridView()
    End Sub

    Protected Sub cmdGVUpdate(ByVal sender As Object, ByVal e As CommandEventArgs)
        Response.Redirect("UserPermissionAdd.aspx?nuserid=" + e.CommandArgument.ToString() + "&nuserroleId=" + _clsDB.Get_DB_Item("SELECT user_role_id FROM tbl_user_info WHERE user_id='" & e.CommandArgument.ToString() & "'").ToString)
    End Sub
   
End Class
