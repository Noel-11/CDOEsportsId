Imports System.Data
Partial Class Include_wucMainMenu
    Inherits System.Web.UI.UserControl

    Dim _clsDB As New clsDatabase
    Dim _clsCMS As New clsCMS
    Dim menuWidth As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            GetMenuData()
        End If
    End Sub


    Private Sub GetMenuData()
        Dim table As New DataTable

        table = _clsCMS.browseSecureCMSMenuHeaderPermission(Session("UserId"), Session("UserRoleId"))

        Dim view As New DataView(table)
        'view.RowFilter = "level=1"
        For Each row As DataRowView In view
            menuWidth = menuWidth + 180
            Dim menuItem As New MenuItem(row("menu_name").ToString(), row("menu_id").ToString())
            menuItem.NavigateUrl = row("page_url").ToString()
            mnuMainMenu.Items.Add(menuItem)
            AddChildItems(table, menuItem)
        Next

        mnuMainMenu.Width = menuWidth.ToString
    End Sub

    Private Sub AddChildItems(ByVal table As DataTable, ByVal menuItem As MenuItem)
        Dim dt As New DataTable
        dt = _clsCMS.browseSecureCMSSubMenuPermission(Session("UserId"), Session("UserRoleId"), menuItem.Value.ToString)
        'Dim viewItem As New DataView(table)
        Dim viewItem As New DataView(dt)
        'viewItem.RowFilter = "parentid='" & menuItem.Value.ToString & "'"
        For Each childView As DataRowView In viewItem
            Dim childItem As New MenuItem(childView("menu_name").ToString(), childView("menu_id").ToString())
            childItem.NavigateUrl = childView("page_url").ToString()
            menuItem.ChildItems.Add(childItem)
            AddChildItems(table, childItem)
        Next
    End Sub

   
End Class
