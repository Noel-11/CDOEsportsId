Imports System.Data
Partial Class Secured_UserAdmin_adminUserEntry
    Inherits cPageInit_Secured_BS

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

        _dtGV = _clsUser.browseUserAdmin(txtSearch.Text.Trim)
        _gv.DataSource = _dtGV
        _gv.DataBind()
        If Not IsNothing(Session("NewPageIndex")) Then
            _lblPaging.Text = clsLibrary.fnSetCurrentPage(Integer.Parse(Session("NewPageIndex").ToString()) + 1, _dtGV)
        Else
            _lblPaging.Text = clsLibrary.fnSetCurrentPage(0, _dtGV)
        End If

    End Sub
    Protected Sub btnSearch_Click(sender As Object, e As EventArgs)
        fillGridView()
    End Sub

    Protected Sub cmdGVSelect(ByVal sender As Object, ByVal e As CommandEventArgs)
        Session("AE_STATUS") = "EDIT"
        Session("USERENTRY_ID") = e.CommandArgument.ToString()
        Response.Redirect("adminUserEntryAdd.aspx")
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.ServerClick
        Session("AE_STATUS") = "ADD"
        Session("USERENTRY_ID") = ""
        Response.Redirect("adminUserEntryAdd.aspx")
    End Sub

    Protected Sub _gv_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles _gv.PageIndexChanging
        Session("NewPageIndex") = e.NewPageIndex
        _gv.PageIndex = e.NewPageIndex
        fillGridView()
        lblPaging.Text = clsLibrary.fnSetCurrentPage(e.NewPageIndex + 1, _dtGV)
    End Sub

End Class
