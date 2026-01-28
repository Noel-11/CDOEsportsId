Imports Microsoft.VisualBasic
Imports System.Data
Public Class clsUserPCBAccess


    Dim _clsDB As New clsDatabase

    Public Sub New()
        initialize()
    End Sub

    Private _transId As String
    Private _userId As String
    Private _pcbProvider As String
    Private _access As String
    Private _lastUser As String

#Region "Properties"
    Public Property transId As String
        Get
            Return Me._transId
        End Get
        Set(ByVal Value As String)
            Me._transId = Value
        End Set
    End Property

    Public Property userId As String
        Get
            Return Me._userId
        End Get
        Set(ByVal Value As String)
            Me._userId = Value
        End Set
    End Property

    Public Property pcbProvider As String
        Get
            Return Me._pcbProvider
        End Get
        Set(ByVal Value As String)
            Me._pcbProvider = Value
        End Set
    End Property

    Public Property access As String
        Get
            Return Me._access
        End Get
        Set(ByVal Value As String)
            Me._access = Value
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
        _transId = ""
        _userId = ""
        _pcbProvider = ""
        _access = ""
        _lastUser = ""
    End Sub


    Public Function browseUsePCBAccess(ByVal _criteria As String, Optional ByVal browse_type As String = "BROWSE") As DataTable
        Dim sql As String = ""
        sql = "SELECT trans_id, user_id, pcb_provider, access, last_user, last_date FROM tbl_user_pcb_access "


        Return _clsDB.Fill_DataTable(sql, "tbl_user_pcb_access")
    End Function


    Public Sub saveUsePCBAccess()
        If _transId = "" Then
            With _clsDB.dbUtility
                .fieldItems = "trans_id,user_id,pcb_provider,access,last_user,last_date"
                .sqlString = .getSQLStatement("tbl_user_pcb_access", "INSERT")
                _transId = DateTime.Now.ToString("MMddyyyymmhhss") & Left(Guid.NewGuid().ToString.Replace("-", ""), 25).ToUpper
                .ADDPARAM_CMD_String("trans_id", _transId)
                .ADDPARAM_CMD_String("user_id", _userId)
                .ADDPARAM_CMD_String("pcb_provider", _pcbProvider)
                .ADDPARAM_CMD_String("access", _access)
                .ADDPARAM_CMD_String("last_user", _lastUser)
                .ADDPARAM_CMD_String("last_date", DateTime.Now.ToString)
                .executeUsingCommandFromSQL(True)
            End With
        Else
            With _clsDB.dbUtility
                .fieldItems = "user_id,pcb_provider,access,last_user,last_date"
                .sqlString = .getSQLStatement("tbl_user_pcb_access", "UPDATE", "trans_id")
                .ADDPARAM_CMD_String("user_id", _userId)
                .ADDPARAM_CMD_String("pcb_provider", _pcbProvider)
                .ADDPARAM_CMD_String("access", _access)
                .ADDPARAM_CMD_String("last_user", _lastUser)
                .ADDPARAM_CMD_String("last_date", DateTime.Now.ToString)
                .ADDPARAM_CMD_String("trans_id", _transId)
                .executeUsingCommandFromSQL(True)
            End With
        End If
    End Sub


    Public Sub getUsePCBAccess(ByVal _id As String)
        Dim dt As New DataTable
        dt = _clsDB.Fill_DataTable("SELECT * FROM tbl_user_pcb_access WHERE trans_id='" & _id & "'")
        If dt.Rows.Count > 0 Then
            _transId = dt.Rows(0)("trans_id") & ""
            _userId = dt.Rows(0)("user_id") & ""
            _pcbProvider = dt.Rows(0)("pcb_provider") & ""
            _access = dt.Rows(0)("access") & ""
            _lastUser = dt.Rows(0)("last_user") & ""
        Else
            initialize()
        End If
    End Sub

End Class
