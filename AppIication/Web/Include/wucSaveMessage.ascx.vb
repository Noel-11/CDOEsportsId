
Partial Class Include_wucSaveMessage
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

    Public Sub setModalType(_modal As String)
        hfModalType.Value = _modal
    End Sub

    Public Sub showMessageBox()
        mpeMessageBox.Show()
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Select Case Session("MODULE")
            Case "PERSONAL DATA SHEET"
                btnSave.CssClass = "buttonBlue"
                btnCancel.CssClass = "buttonBlue"
            Case "EMPLOYMENT DETAILS"
                btnSave.CssClass = "buttonGreen"
                btnCancel.CssClass = "buttonGreen"
            Case "LEAVE ADMINISTRATION"
                btnSave.CssClass = "buttonRed"
                btnCancel.CssClass = "buttonRed"
            Case "USER ADMINISTRATION"
                btnSave.CssClass = "buttonBlack"
                btnCancel.CssClass = "buttonBlack"
            Case "PROPERTY MANAGEMENT"
                btnSave.CssClass = "buttonOrange"
                btnCancel.CssClass = "buttonOrange"
            Case "ATTENDANCE MANAGEMENT"
                btnSave.CssClass = "buttonYellow"
                btnCancel.CssClass = "buttonYellow"
        End Select
    End Sub
End Class
