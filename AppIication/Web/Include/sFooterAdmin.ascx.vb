Imports System.Data
Partial Class Include_sFooterAdmin
    Inherits System.Web.UI.UserControl
    Dim _clsDB As New clsDatabase
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Session("UserName") <> "" Then
            ' divRS.Visible = True
            liHelpdesk.Visible = True
        Else
            ' divRS.Visible = False
            liHelpdesk.Visible = False
        End If
    End Sub
End Class
