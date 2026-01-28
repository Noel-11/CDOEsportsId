Imports System.Data
Partial Class Secured_SystemAdministration_UserEntry
    Inherits cPageInit_Secured

    Dim clsLibrary As New clsLibrary
    Dim _clsDB As New clsDatabase
    Dim _clsUser As New clsUser

    Dim _dtGV As New DataTable
    Dim _lblPaging As New Label
    Dim _btnSearch As New ImageButton
    Dim _txtSearch As New TextBox

    Dim _cph As ContentPlaceHolder
    Dim _ctr As Control


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Session.Remove("USERENTRY_ID")

        _cph = Master.FindControl("cphSContent")
        _ctr = _cph.FindControl("sSearchPaging1")

        If Not Page.IsPostBack Then
            _lblPaging = _ctr.FindControl("lblPaging")
            fillGridView(_txtSearch.Text)
        End If
        getSearchControl()
    End Sub

    Protected Sub getSearchControl()
        _btnSearch = _ctr.FindControl("btnSearch")
        _txtSearch = _ctr.FindControl("txtSearch")
        AddHandler _btnSearch.Command, AddressOf btnSearch_Command
    End Sub

    Protected Sub fillGridView(ByVal _strSearch As String)

        _dtGV = _clsUser.browseUser(_strSearch)
        _gv.DataSource = _dtGV
        _gv.DataBind()
        If Not IsNothing(Session("NewPageIndex")) Then
            _lblPaging.Text = clsLibrary.fnSetCurrentPage(Integer.Parse(Session("NewPageIndex").ToString()) + 1, _dtGV)
        Else
            _lblPaging.Text = clsLibrary.fnSetCurrentPage(0, _dtGV)
        End If
    End Sub

    Protected Sub cmdGVUpdate(ByVal sender As Object, ByVal e As CommandEventArgs)
        Session("AE_STATUS") = "EDIT"
        Session("USERENTRY_ID") = e.CommandArgument.ToString()
        Response.Redirect("UserEntryAdd.aspx")
    End Sub
    'Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
    '    Session("AE_STATUS") = "ADD"
    '    Session("USERENTRY_ID") = ""
    '    Response.Redirect("UserEntryAdd.aspx")
    'End Sub

    Protected Sub _gv_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles _gv.PageIndexChanging
        Session("NewPageIndex") = e.NewPageIndex
        _gv.PageIndex = e.NewPageIndex
        fillGridView(_txtSearch.Text)
        _lblPaging.Text = clsLibrary.fnSetCurrentPage(e.NewPageIndex + 1, _dtGV)
    End Sub

    Protected Sub btnSearch_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        fillGridView(_txtSearch.Text)
    End Sub

 
End Class
