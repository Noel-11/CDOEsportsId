Imports System.Data
Partial Class Include_wucMainMenuBS
    Inherits System.Web.UI.UserControl

    Dim _clsDB As New clsDatabase
    Dim _clsCMS As New clsCMS
    Dim menuWidth As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Request("MODULE") <> "" Then
            Session("MODULE") = "BUSINESS"
            Response.Redirect("~/Secured/Default.aspx")
        End If

        GetMenuData()

    End Sub

    Private Sub GetMenuData()
        Dim dtMenu As New DataTable
        Dim htmlStringHeadButton As String = ""
        Dim htmlString As String = ""
        Dim urlString As String = ""
        Dim preUrl As String = ConfigurationManager.AppSettings("preUrl").ToString
        dtMenu = _clsCMS.browseSecureCMSMenuHeaderPermissionByModule(Session("UserId"), Session("UserRoleId"), Session("MODULE"))

        Dim menuIcon As String
        Dim subMenu As String

        Dim liList As New LiteralControl

        For Each row As DataRow In dtMenu.Rows
            menuWidth = menuWidth + 180
            urlString = row("page_url").ToString().Replace("~/", preUrl)
            Dim dt As New DataTable
            dt = _clsCMS.browseSecureCMSSubMenuPermission(Session("UserId"), Session("UserRoleId"), row("menu_id").ToString())

            menuIcon = "<i class='bi bi-card-checklist' style='color:black;'></i>"

            If row("page_url") <> "" Then
                htmlString = htmlString & "<li class='nav-item'>"
                htmlString = htmlString & " <a class='nav-link' href='" & urlString & "'>  <i class='bi bi-grid'></i> <span>" & row("menu_name").ToString() & "</span> </a> </li>"

            Else

                Dim _menuId As String = row("menu_name").ToString() & row("menu_id").ToString()

                htmlString = htmlString & "<li class='nav-item'>"
                htmlString = htmlString & " <a class='nav-link collapsed' data-bs-target='" & "#" & row("menu_id").ToString() & "' data-bs-toggle='collapse' href='#'> <i class='bi bi-menu-button-wide'></i><span>" & row("menu_name").ToString() & "</span><i class='bi bi-chevron-down ms-auto'></i> </a>"

                htmlString = htmlString & "<ul id='" & row("menu_id").ToString() & "' class='nav-content collapse' data-bs-parent='#sidebarnav'> "

                For Each childView As DataRow In dt.Rows
                    urlString = childView("page_url").ToString().Replace("~/", preUrl)
                    htmlString = htmlString & "<li style='background-color: #ffffff;margin-bottom: 3px'> <a href='" & urlString & "'> <i class='bi bi-circle'></i><span>" & childView("menu_name").ToString() & "</span> </a> </li>"
                Next

                htmlString = htmlString + "</ul>"
            End If
        Next

        liList.Text = htmlString
        sidebarnav.Controls.Add(liList)
        Session("navMenu") = liList
    End Sub
 
End Class
