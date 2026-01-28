
Partial Class Include_sSearchPaging
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.txtSearch.Attributes.Add("onfocus", "if (this.value== '" + Me.txtSearch.Text + "') { this.value=''}")
            Me.txtSearch.Attributes.Add("onblur", "if (this.value=='') { this.value= '" + Me.txtSearch.Text + "'}")
        End If
    End Sub
End Class
