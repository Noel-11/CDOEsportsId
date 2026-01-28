
Partial Class Include_wucConfirmBox
    Inherits System.Web.UI.UserControl

    Private Sub modalSave()
        hfModalType.Value = "SAVE"
        lblMsgBoxHeader.Text = "CONFIRMATION"
        lblMsgBoxMessage.Text = "Are you sure you want to save this record?"
        btnMsgBoxYes.Text = "Yes"
        btnMsgBoxNo.Visible = True
    End Sub

    Private Sub modalCancel()
        hfModalType.Value = "CANCEL"
        lblMsgBoxHeader.Text = "CONFIRMATION"
        lblMsgBoxMessage.Text = "Are you sure you want to cancel saving this record?"
        btnMsgBoxYes.Text = "Yes"
        btnMsgBoxNo.Visible = True
    End Sub

    Public Sub modalInfo(Optional ByVal _msg As String = "Save Successful!")
        hfModalType.Value = "INFO"
        lblMsgBoxHeader.Text = "SUCCESSFUL"
        lblMsgBoxMessage.Text = _msg
        btnMsgBoxYes.Text = "OK"
        btnMsgBoxNo.Visible = False
    End Sub

    Private Sub modalUpload()
        btnMsgBoxYes.Text = "Yes"
        btnMsgBoxNo.Visible = True
    End Sub

    Private Sub modalApprove()
        btnMsgBoxYes.Text = "Yes"
        btnMsgBoxNo.Visible = True
    End Sub
    Private Sub modalDelete()
        btnMsgBoxYes.Text = "Yes"
        btnMsgBoxNo.Visible = True
    End Sub
    Public Function getModalType() As String
        Return hfModalType.Value.ToString
    End Function

    Public Sub setModalType(ByVal _modalType As String)
        hfModalType.Value = _modalType
    End Sub

    Public Sub setHeader(ByVal _header As String)
        lblMsgBoxHeader.Text = _header
    End Sub

    Public Sub setMessage(ByVal _msg As String)
        lblMsgBoxMessage.Text = _msg
    End Sub

    Public Sub showConfirmBox()
        Select Case hfModalType.Value
            Case "UPLOAD"
                modalUpload()
            Case "APPROVE"
                modalApprove()
            Case "SAVE"
                modalSave()
            Case "DELETE"
                modalDelete()
            Case "CANCEL"
                modalCancel()
            Case "INFO"
                modalInfo()
        End Select
        mpeMessageBox.Show()
    End Sub


End Class
