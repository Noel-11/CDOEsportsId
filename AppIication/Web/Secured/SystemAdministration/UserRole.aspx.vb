Imports System.Data

Partial Class Secured_UserRole
    Inherits cPageInit_Secured_BS

    Dim clsLibrary As New clsLibrary
    Dim _clsUserRole As New clsUserRole

    Dim _dtGV As New DataTable
   
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Session.Remove("USER_ROLE_ID")

        If Not Page.IsPostBack Then
            fillGridView()
        End If

    End Sub

    Protected Sub fillGridView()
        _dtGV = _clsUserRole.browseUserRole(txtSearch.Text.Trim)
        _gv.DataSource = _dtGV
        _gv.DataBind()
        If Not IsNothing(Session("NewPageIndex")) Then
            _lblPaging.Text = clsLibrary.fnSetCurrentPage(Integer.Parse(Session("NewPageIndex").ToString()) + 1, _dtGV)
        Else
            _lblPaging.Text = clsLibrary.fnSetCurrentPage(0, _dtGV)
        End If
    End Sub

    Protected Sub _gv_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles _gv.PageIndexChanging
        Session("NewPageIndex") = e.NewPageIndex
        _gv.PageIndex = e.NewPageIndex
        fillGridView()
        '_lblPaging.Text = clsLibrary.fnSetCurrentPage(e.NewPageIndex + 1, _dtGV)
    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs)
        fillGridView()
    End Sub

    Protected Sub cmdGVUpdate(ByVal sender As Object, ByVal e As CommandEventArgs)
        Session("AE_STATUS") = "EDIT"
        Session("USER_ROLE_ID") = e.CommandArgument.ToString
        Response.Redirect("UserRoleAdd.aspx")
    End Sub


    Protected Sub btnAdd_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles btnAdd.Command
        Session("AE_STATUS") = "ADD"
        Session("USER_ROLE_ID") = ""
        Response.Redirect("UserRoleAdd.aspx")
    End Sub


End Class
