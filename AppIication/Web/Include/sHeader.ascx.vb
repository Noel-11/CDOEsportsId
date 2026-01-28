
Partial Class Include_sHeader
    Inherits System.Web.UI.UserControl


    Protected Sub lnkLogout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkLogout.Click
        Session("accPaneIndex") = 0
        Session.Abandon()
        'CType(Application("userList"), Dictionary(Of String, String())).Remove(Session("UserCode").ToString)
        'If Session("_strScript") = "VerifySoloParent.aspx" Then
        '    Response.Redirect("~/EstablishmentAdmin.aspx")
        'Else
        Response.Redirect("~/default.aspx")
        ' End If

    End Sub

    Protected Sub lnkChangePassword_Command(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs) Handles lnkChangePassword.Command
        Response.Redirect("~/Secured/SystemAdministration/adUserChangePassword.aspx?nUserId=" & Session("UserId"))
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("UserId") = Nothing Then
            Session.Abandon()
            'Response.Redirect("~/public/pubAnnouncement.aspx")
            Response.Redirect("~/default.aspx")
        End If
        lblUsername.Text = ": " + Session("UserName").ToString()
    End Sub
End Class
