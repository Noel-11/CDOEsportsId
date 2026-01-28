
Partial Class Secured_DPN_DPN
    Inherits System.Web.UI.Page

    Dim _clsDB As New clsDatabase

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            lblDetails.Text = _clsDB.Get_DB_Item("SELECT default_value FROM tbl_system_default WHERE default_desc = 'dpn'")

        End If

    End Sub
End Class
