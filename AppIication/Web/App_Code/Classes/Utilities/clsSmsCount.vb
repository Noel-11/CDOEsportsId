Imports Microsoft.VisualBasic
Imports System.Data
Public Class clsSmsCount
    Dim _clsDB As New clsDatabase


    Public Sub New()
        initialize()
    End Sub

    Public Property transId As String
    Public Property sentCount As Integer
    Public Property dateSent As String

    Public Sub initialize()
        transId = ""
        sentCount = 0
        dateSent = ""
    End Sub

    Public Sub saveSentSMSCount()
        If transId = "" Then
            With _clsDB.dbUtility
                .fieldItems = "trans_id,date_sent,sent_count"
                .sqlString = .getSQLStatement("tbl_sms_count", "INSERT")
                transId = DateTime.Now.ToString("MMddyyyymmhhss") & Left(Guid.NewGuid().ToString.Replace("-", ""), 25).ToUpper
                .ADDPARAM_CMD_String("trans_id", transId)
                .ADDPARAM_CMD_String("date_sent", DateTime.Now.Date.ToString("yyyy-MM-dd"))
                .ADDPARAM_CMD_String("sent_count", sentCount)
                .executeUsingCommandFromSQL(True)
            End With
        Else
            With _clsDB.dbUtility
                .fieldItems = "sent_count"
                .sqlString = .getSQLStatement("tbl_sms_count", "UPDATE", "trans_id")
                .ADDPARAM_CMD_String("sent_count", sentCount)
                .ADDPARAM_CMD_String("trans_id", transId)
                .executeUsingCommandFromSQL(True)
            End With
        End If

    End Sub


End Class
