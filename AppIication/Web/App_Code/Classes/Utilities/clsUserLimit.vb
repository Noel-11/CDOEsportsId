Imports Microsoft.VisualBasic
Imports System.Data
Public Class clsUserLimit
    Dim _clsDB As New clsDatabase

    Public Sub New()
        initialize()
    End Sub


#Region "Properties"
    Public Property transId As String

    Public Property userId As String

    Public Property dateFrom As String

    Public Property dateTo As String

    Public Property entryLimit As String

    Public Property entryCount As String

    Public Property isActive As String

    Public Property lastUser As String

    Public Property lastDate As String

#End Region


    Public Sub initialize()
        _transId = ""
        _userId = ""
        _dateFrom = ""
        _dateTo = ""
        _entryLimit = ""
        _entryCount = ""
        _isActive = "Y"
        _lastUser = ""
        _lastDate = ""
    End Sub

    Public Function browseUserLimit(ByVal _criteria As String, ByVal _thisDateFrom As String, ByVal _thisDateTo As String) As DataTable
        Dim sql As String = ""

        Dim sqlWhere As String = ""

        'If _criteria <> "" Then
        '    sqlWhere = "AND user_id LIKE '" & _criteria & "%'"
        'End If

        If _thisDateFrom <> "" Then
            sqlWhere += "AND date_from BETWEEN '" & _thisDateFrom & "' AND '" & _thisDateTo & "'"
        End If

        sql = "SELECT trans_id,user_id, DATE_FORMAT(date_from,'%m/%d/%Y') AS date_from, DATE_FORMAT(date_to,'%m/%d/%Y') AS date_to, entry_limit, is_active,entry_count FROM tbl_user_limit " & _
              "WHERE user_id LIKE '" & _criteria & "%' " & sqlWhere & _
              "ORDER BY date_from DESC"

        Return _clsDB.Fill_DataTable(sql, "tbl_user_limit")
    End Function

    Public Function browseUserLimit(ByVal _criteria As String) As DataTable
        Dim sql As String = ""
        sql = "SELECT trans_id, user_id, date_from, date_to, entry_limit, entry_count, is_active, last_user, last_date, FROM tbl_user_limit " & _
             " WHERE trans_id LIKE '%" & _criteria & "%' OR user_id LIKE '%" & _criteria & "%' OR date_from LIKE '%" & _criteria & "%' OR date_to LIKE '%" & _criteria & "%' OR entry_limit LIKE '%" & _criteria & "%' OR entry_count LIKE '%" & _criteria & "%' OR is_active LIKE '%" & _criteria & "%' OR last_user LIKE '%" & _criteria & "%' OR last_date LIKE '%" & _criteria & "%' OR  ORDER BY "
        Return _clsDB.Fill_DataTable(sql, "tbl_user_limit")
    End Function


    Public Sub saveUserLimit()
        If transId = "" Then
            With _clsDB.dbUtility
                .fieldItems = "trans_id,user_id,date_from,date_to,entry_limit,is_active,create_user,create_date"
                .sqlString = .getSQLStatement("tbl_user_limit", "INSERT")
                _transId = DateTime.Now.ToString("MMddyyyymmhhss") & Left(Guid.NewGuid().ToString.Replace("-", ""), 10).ToUpper
                .ADDPARAM_CMD_String("trans_id", _transId)
                .ADDPARAM_CMD_String("user_id", _userId)
                .ADDPARAM_CMD_String("date_from", _dateFrom)
                .ADDPARAM_CMD_String("date_to", _dateTo)
                .ADDPARAM_CMD_String("entry_limit", _entryLimit)
                .ADDPARAM_CMD_String("is_active", _isActive)
                .ADDPARAM_CMD_String("last_user", _lastUser)
                .ADDPARAM_CMD_String("last_date", DateTime.Now.ToString)
                .executeUsingCommandFromSQL(True)
            End With
        Else
            With _clsDB.dbUtility
                .fieldItems = "user_id,date_from,date_to,entry_limit,is_active,last_user,last_date"
                .sqlString = .getSQLStatement("tbl_user_limit", "UPDATE", "trans_id")
                .ADDPARAM_CMD_String("user_id", _userId)
                .ADDPARAM_CMD_String("date_from", _dateFrom)
                .ADDPARAM_CMD_String("date_to", _dateTo)
                .ADDPARAM_CMD_String("entry_limit", _entryLimit)
                .ADDPARAM_CMD_String("is_active", _isActive)
                .ADDPARAM_CMD_String("last_user", _lastUser)
                .ADDPARAM_CMD_String("last_date", DateTime.Now.ToString)
                .ADDPARAM_CMD_String("trans_id", _transId)
                .executeUsingCommandFromSQL(True)
            End With
        End If
    End Sub


    Public Sub updateEntryCount()

        Dim count As Integer = 0

        Try
            count = _clsDB.Get_DB_Item("SELECT entry_count FROM tbl_user_limit WHERE trans_id = '" & _transId & "' LIMIT 1")
        Catch ex As Exception
            count = 0
        End Try

        count += 1
        With _clsDB.dbUtility
            .fieldItems = "entry_count"
            .sqlString = .getSQLStatement("tbl_user_limit", "UPDATE", "trans_id")
            .ADDPARAM_CMD_String("entry_count", count)
            .ADDPARAM_CMD_String("trans_id", _transId)
            .executeUsingCommandFromSQL(True)
        End With

    End Sub


    Public Sub getUserLimit(ByVal _id As String)
        Dim dt As New DataTable
        dt = _clsDB.Fill_DataTable("SELECT * FROM tbl_user_limit WHERE trans_id='" & _id & "'")
        If dt.Rows.Count > 0 Then
            _transId = dt.Rows(0)("trans_id").ToString
            _userId = dt.Rows(0)("user_id").ToString
            _dateFrom = dt.Rows(0)("date_from").ToString
            _dateTo = dt.Rows(0)("date_to").ToString
            _entryLimit = dt.Rows(0)("entry_limit").ToString
            _entryCount = dt.Rows(0)("entry_count").ToString
            _isActive = dt.Rows(0)("is_active").ToString
            _lastUser = dt.Rows(0)("last_user").ToString
        Else
            initialize()
        End If
    End Sub

End Class
