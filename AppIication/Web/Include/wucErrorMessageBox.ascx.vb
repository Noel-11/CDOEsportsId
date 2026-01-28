
Partial Class Include_wucErrorMessageBox
    Inherits System.Web.UI.UserControl

    Public Sub setInformation(ByVal _header As String, ByVal _msg As String)
        lblMsgBoxHeader.Text = _header
        lblMsgBoxMessage.Text = _msg

    End Sub

    Public Sub showErrorMsgBox()
        mpeMessageBox.Show()
    End Sub

End Class
