Imports Microsoft.VisualBasic
Imports System.Data
Public Class clsLoginLog


    Dim _clsDB As New clsDatabase

    Public Sub New()
        initialize()
    End Sub


#Region "Properties"
    Public Property transId As String

    Public Property userId As String

    Public Property loginIp As String

    Public Property loginDatetime As String

    Public Property loginStatus As String

#End Region


    Public Sub initialize()
        _transId = ""
        _userId = ""
        _loginIp = ""
        _loginDatetime = ""
        _loginStatus = ""
    End Sub


    'Public Function browseLoginLog(ByVal _criteria As String) As DataTable
    '    Dim sql As String = ""
    '    sql = "SELECT trans_id, user_id, login_ip, login_datetime, login_status, FROM tbl_login_log " & _
    '    " WHERE trans_id LIKE '%" & _criteria & "%' OR user_id LIKE '%" & _criteria & "%' OR login_ip LIKE '%" & _criteria & "%' OR login_datetime LIKE '%" & _criteria & "%' OR login_status LIKE '%" & _criteria & "%' OR  ORDER BY "
    '    Return _clsDB.Fill_DataTable(sql, "tbl_login_log")
    'End Function

    Public Sub saveLoginLog()

        With _clsDB.dbUtility
            .fieldItems = "trans_id,user_id,login_ip,login_datetime,login_status"
            .sqlString = .getSQLStatement("tbl_login_log", "INSERT")
            _transId = DateTime.Now.ToString("MMddyyyymmhhss") & Left(Guid.NewGuid().ToString.Replace("-", ""), 25).ToUpper
            .ADDPARAM_CMD_String("trans_id", _transId)
            .ADDPARAM_CMD_String("user_id", _userId)
            .ADDPARAM_CMD_String("login_ip", _loginIp)
            .ADDPARAM_CMD_String("login_datetime", _loginDatetime)
            .ADDPARAM_CMD_String("login_status", _loginStatus)
            .executeUsingCommandFromSQL(True)
        End With

    End Sub


    Public Sub getLoginLog(ByVal _id As String)
        Dim dt As New DataTable
        dt = _clsDB.Fill_DataTable("SELECT * FROM tbl_login_log WHERE trans_id='" & _id & "'")
        If dt.Rows.Count > 0 Then
            _transId = dt.Rows(0)("trans_id").ToString
            _userId = dt.Rows(0)("user_id").ToString
            _loginIp = dt.Rows(0)("login_ip").ToString
            _loginDatetime = dt.Rows(0)("login_datetime").ToString
            _loginStatus = dt.Rows(0)("login_status").ToString
        Else
            initialize()
        End If
    End Sub

End Class
