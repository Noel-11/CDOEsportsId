Imports Microsoft.VisualBasic
Imports System.Data
Public Class clsUser
    Dim _clsDB As New clsDatabase

    Dim _clsSecurity As New clsDimboMySQL.clsSecurity
    Dim _clsSystemInfo As New clsSystemInfo

    Public Sub New()
        initialize()
    End Sub
    Private _oldUserID As String
    Private _userID As String
    Private _userName As String
    Private _userRoleID As String
    Private _userPassword As String
    Private _isActive As String
    Private _lastUser As String

#Region "Property"
    Public Property oldUserID As String
        Get
            Return Me._oldUserID
        End Get
        Set(ByVal Value As String)
            Me._oldUserID = Value
        End Set
    End Property


    Public Property userID As String
        Get
            Return Me._userID
        End Get
        Set(ByVal Value As String)
            Me._userID = Value
        End Set
    End Property

    Public Property userName As String
        Get
            Return Me._userName
        End Get
        Set(ByVal Value As String)
            Me._userName = Value
        End Set
    End Property

    Public Property userRoleID As String
        Get
            Return Me._userRoleID
        End Get
        Set(ByVal Value As String)
            Me._userRoleID = Value
        End Set
    End Property

    Public Property userPassword As String
        Get
            Return Me._userPassword
        End Get
        Set(ByVal Value As String)
            Me._userPassword = Value
        End Set
    End Property
    Public Property isActive As String
        Get
            Return Me._isActive
        End Get
        Set(ByVal Value As String)
            Me._isActive = Value
        End Set
    End Property

    Public Property lastUser As String
        Get
            Return Me._lastUser
        End Get
        Set(ByVal Value As String)
            Me._lastUser = Value
        End Set
    End Property
#End Region

    Public Sub initialize()
        _oldUserID = ""
        _userID = ""
        _userName = ""
        _userRoleID = ""
        _userPassword = ""
        _isActive = ""
        _lastUser = ""
    End Sub


    Public Function browseUser(ByVal _criteria As String, Optional ByVal browse_type As String = "BROWSE") As DataTable
        Dim sql As String = ""
        sql = "SELECT user_id, user_name FROM tbl_user_info"
        Select Case browse_type
            Case "BROWSE"
                sql = sql & " WHERE user_name LIKE '%" & _criteria & "%' AND last_user <> 'INITIALIZED' ORDER BY user_name "
            Case Else
                sql = sql & " WHERE user_name LIKE '%" & _criteria & "%' ORDER BY user_name "
        End Select
        Return _clsDB.Fill_DataTable(sql, "tbl_user_info")
    End Function


    Public Function browseUserAdmin(ByVal _criteria As String, Optional ByVal browse_type As String = "BROWSE") As DataTable
        Dim sql As String = ""
        sql = "SELECT user_id, user_name,is_active FROM tbl_user_info"
        Select Case browse_type
            Case "BROWSE"
                sql = sql & " WHERE user_name LIKE '%" & _criteria & "%' AND user_id <> 'admin' ORDER BY user_name "
        End Select
        Return _clsDB.Fill_DataTable(sql, "tbl_user_info")
    End Function

    Public Sub saveUser()
        If _oldUserID = "" Then
            With _clsDB.dbUtility
                .fieldItems = "user_id,user_name,user_role_id,user_password,is_active,last_user,last_date"
                .sqlString = .getSQLStatement("tbl_user_info", "INSERT")
                .ADDPARAM_CMD_String("user_id", _userID)
                .ADDPARAM_CMD_String("user_name", _userName)
                .ADDPARAM_CMD_String("user_role_id", _userRoleID)
                .ADDPARAM_CMD_String("user_password", _clsSystemInfo.getDefaultPassword)
                .ADDPARAM_CMD_String("is_active", _isActive)
                .ADDPARAM_CMD_String("last_user", _lastUser)
                .ADDPARAM_CMD_String("last_date", DateTime.Now.ToString)
                .executeUsingCommandFromSQL(True)
            End With
        Else
            With _clsDB.dbUtility
                .fieldItems = "user_name,user_role_id,is_active,last_user,last_date"
                .sqlString = .getSQLStatement("tbl_user_info", "UPDATE", "user_id")
                .ADDPARAM_CMD_String("user_name", _userName)
                .ADDPARAM_CMD_String("user_role_id", _userRoleID)
                .ADDPARAM_CMD_String("is_active", _isActive)
                .ADDPARAM_CMD_String("last_user", _lastUser)
                .ADDPARAM_CMD_String("last_date", DateTime.Now.ToString)
                .ADDPARAM_CMD_String("user_id", _oldUserID)
                .executeUsingCommandFromSQL(True)
            End With
        End If
    End Sub

    Public Sub getUserInformation(ByVal _id As String)
        Dim dt As New DataTable
        dt = _clsDB.Fill_DataTable("SELECT * FROM tbl_user_info WHERE user_id='" & _id & "' LIMIT 1")
        If dt.Rows.Count > 0 Then
            _userID = dt.Rows(0)("user_id")
            _userName = dt.Rows(0)("user_name")
            _userRoleID = dt.Rows(0)("user_role_id")
            _userPassword = dt.Rows(0)("user_password")
            _isActive = dt.Rows(0)("is_active")
            If Not IsDBNull(dt.Rows(0)("last_user")) Then
                _lastUser = dt.Rows(0)("last_user")
            Else
                _lastUser = ""
            End If
        Else
            initialize()
        End If
    End Sub

    'Public Sub getUserNamePass(ByVal _id As String)
    '    Dim dt As New DataTable
    '    dt = _clsDB.Fill_DataTable("SELECT * FROM tbl_user_info WHERE user_id='" & _id & "'")
    '    If dt.Rows.Count > 0 Then
    '        _transId = dt.Rows(0)("trans_id")
    '        _userID = dt.Rows(0)("user_id")
    '        _userName = dt.Rows(0)("user_name")
    '        _userRoleID = dt.Rows(0)("user_role_id")
    '        _userPassword = dt.Rows(0)("user_password")
    '        _isActive = dt.Rows(0)("is_active")
    '        _lastUser = dt.Rows(0)("last_user")
    '    Else
    '        initialize()
    '    End If
    'End Sub

    Public Function validateUserLogon(ByVal _struserid As String, ByVal _strpassword As String) As Boolean
        getUserInformation(_struserid)
        Return _clsSecurity.validateSameText(_strpassword, userPassword)
    End Function

    Public Function verifyDefaultPassword(ByVal _strpassword As String) As Boolean
        Dim _clsSystemInfo As New clsSystemInfo
        Return _clsSecurity.validateSameText(_strpassword, _clsSystemInfo.getDefaultPassword)
    End Function

    Public Sub updatePassword()
        With _clsDB.dbUtility
            .fieldItems = "user_password"
            .sqlString = .getSQLStatement("tbl_user_info", "UPDATE", "user_id")
            .ADDPARAM_CMD_String("user_password", _clsSecurity.encryptString(_userPassword))
            .ADDPARAM_CMD_String("user_id", _userID)
            .executeUsingCommandFromSQL(True)
        End With
    End Sub

    Public Sub resetPassword()
        With _clsDB.dbUtility
            .fieldItems = "user_password"
            .sqlString = .getSQLStatement("tbl_user_info", "UPDATE", "user_id")
            .ADDPARAM_CMD_String("user_password", _clsSystemInfo.getDefaultPassword)
            .ADDPARAM_CMD_String("user_id", _userID)
            .executeUsingCommandFromSQL(True)
        End With
    End Sub

    Public Function userExists(ByVal _userID As String) As Boolean
        Return _clsDB.Get_DB_Item("SELECT count(user_id) FROM tbl_user_info WHERE user_id='" & _userID & "'") > 0
    End Function
End Class
