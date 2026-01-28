
Partial Class Include_wucMessageBox
    Inherits System.Web.UI.UserControl

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        modalSave()
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        modalCancel()
    End Sub

    Private Sub modalSave()
        hfModalType.Value = "SAVE"
        lblMsgBoxHeader.Text = "CONFIRMATION"
        lblMsgBoxMessage.Text = "Are you sure you want to save this record?"
        btnMsgBoxYes.Text = "Yes"
        btnMsgBoxNo.Visible = True
        mpeMessageBox.Show()
    End Sub

    Private Sub modalCancel()
        hfModalType.Value = "CANCEL"
        lblMsgBoxHeader.Text = "CONFIRMATION"
        lblMsgBoxMessage.Text = "Are you sure you want to cancel saving this record?"
        btnMsgBoxYes.Text = "Yes"
        btnMsgBoxNo.Visible = True
        mpeMessageBox.Show()
    End Sub

    Public Sub modalInfo(Optional ByVal _msg As String = "Save Successful!")
        hfModalType.Value = "INFO"
        lblMsgBoxHeader.Text = "SUCCESSFUL"
        lblMsgBoxMessage.Text = _msg
        btnMsgBoxYes.Text = "OK"
        btnMsgBoxNo.Visible = False
        mpeMessageBox.Show()
    End Sub

    Public Function getModalType() As String
        Return hfModalType.Value.ToString
    End Function

End Class
