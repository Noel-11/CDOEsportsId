Imports Microsoft.VisualBasic
Imports System.Data
Public Class clsSmsSent
    Dim _clsDB As New clsDatabase

    Public Sub New()
        initialize()
    End Sub

    Public Property transId As String
    Public Property sentBy As String
    Public Property sentMessage As String
    Public Property recipients As String
    Public Property dateTimeSent As String

    Public Sub initialize()
        transId = ""
        sentBy = ""
        sentMessage = ""
        recipients = ""
        dateTimeSent = ""
    End Sub

    Public Function browseSMSMessages(ByVal _criteria As String) As DataTable
        Dim sql As String = ""

        sql = "SELECT * FROM tbl_sms_sent WHERE sent_by LIKE '%" & _criteria & "%' OR datetime_sent LIKE '%" & _criteria & "%' ORDER BY STR_TO_DATE(datetime_sent,'%m/%d/%Y  %l:%i:%s %p') DESC"

        Return _clsDB.Fill_DataTable(sql, "tbl_sms_sent")
    End Function

    Public Sub saveSentSMSMessage()

        With _clsDB.dbUtility
            .fieldItems = "trans_id,sent_by,sent_message,recipients,datetime_sent"
            .sqlString = .getSQLStatement("tbl_sms_sent", "INSERT")
            transId = DateTime.Now.ToString("MMddyyyymmhhss") & Left(Guid.NewGuid().ToString.Replace("-", ""), 25).ToUpper
            .ADDPARAM_CMD_String("trans_id", transId)
            .ADDPARAM_CMD_String("sent_by", sentBy)
            .ADDPARAM_CMD_String("sent_message", sentMessage)
            .ADDPARAM_CMD_String("recipients", recipients)
            .ADDPARAM_CMD_String("datetime_sent", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            .executeUsingCommandFromSQL(True)
        End With


    End Sub

    Public Sub getSentSMSMessages(ByVal _criteria As String)
        Dim dt As New DataTable

        Dim sql As String = "SELECT * FROM tbl_sms_sent WHERE trans_id = '" & _criteria & "'"

        dt = _clsDB.Fill_DataTable(sql, "tbl_sms_sent")

        If dt.Rows.Count > 0 Then

            transId = dt.Rows(0)("trans_id")
            sentBy = dt.Rows(0)("sent_by")
            sentMessage = dt.Rows(0)("sent_message")
            recipients = dt.Rows(0)("recipients")
            dateTimeSent = dt.Rows(0)("datetime_sent")

        Else
            initialize()
        End If

    End Sub
   
End Class
