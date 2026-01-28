Imports System.Data

Partial Class Secured_cmsMenu
    Inherits cPageInit_Secured_BS

    Dim _clsLibrary As New clsLibrary
    Dim _clsCMS As New clsCMS
    Dim _clsDB As New clsDatabase

    Dim _dtGV As New DataTable
    'Dim _lblPaging As New Label
    'Dim _btnSearch As New ImageButton
    'Dim _txtSearch As New TextBox
    'Dim _cph As ContentPlaceHolder
    'Dim _ctr As Control
    Dim _strparent_id As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        _strparent_id = IIf(Request("nparent_id") = "", "0", Request("nparent_id"))
        '_cph = Master.FindControl("cphSContent")
        '_ctr = _cph.FindControl("sSearchPaging1")

        If _strparent_id = "0" Then
            lblPageTitle.Text = "Menu Header"
            _gv.Columns(1).Visible = True
            btnReturn.Visible = False
        Else
            lblPageTitle.Text = "Sub Menu"
            _gv.Columns(1).Visible = False
            btnReturn.Visible = True
        End If

        If Not Page.IsPostBack Then
            ' _lblPaging = _ctr.FindControl("lblPaging")
            fillGridView(_txtSearch.Text)
        End If

    End Sub

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs)
        fillGridView(txtSearch.Text.Trim)
    End Sub

    Protected Sub btnBack_Click(sender As Object, e As EventArgs)
        Response.Redirect("cmsMenu.aspx?nparent_id=")
    End Sub

    Protected Sub fillGridView(ByVal _strSearch As String)
        _dtGV = _clsCMS.browseCMSMenu("", _strparent_id, _strSearch)
        _gv.DataSource = _dtGV
        _gv.DataBind()
        If Not IsNothing(Session("NewPageIndex")) Then
            _lblPaging.Text = _clsLibrary.fnSetCurrentPage(Integer.Parse(Session("NewPageIndex").ToString()) + 1, _dtGV)
        Else
            _lblPaging.Text = _clsLibrary.fnSetCurrentPage(0, _dtGV)
        End If
    End Sub

    Protected Sub cmdGVUpdate(ByVal sender As Object, ByVal e As CommandEventArgs)
        Session("AE_STATUS") = "EDIT"
        Response.Redirect("cmsMenuAdd.aspx?ncmsmenuId=" & e.CommandArgument.ToString() & "&nparent_id=" + _strparent_id)
    End Sub

    Protected Sub btnAdd_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles btnAdd.Command
        Session("AE_STATUS") = "ADD"
        Response.Redirect("cmsMenuAdd.aspx?ncmsmenuId=&nparent_id=" + _strparent_id)
    End Sub

    Protected Sub cmdGVSubMenu(ByVal sender As Object, ByVal e As CommandEventArgs)
        Response.Redirect("cmsMenu.aspx?nparent_id=" + e.CommandArgument.ToString())
    End Sub

    Protected Sub _gv_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles _gv.PageIndexChanging
        Session("NewPageIndex") = e.NewPageIndex
        _gv.PageIndex = e.NewPageIndex
        fillGridView(_txtSearch.Text)
        _lblPaging.Text = _clsLibrary.fnSetCurrentPage(e.NewPageIndex + 1, _dtGV)
    End Sub

End Class
