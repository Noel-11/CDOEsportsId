Imports Microsoft.VisualBasic
Imports System.Data
Public Class clsAuditTrail
    Dim _clsDB As New clsDatabase

    Public Sub New()
        initialize()
    End Sub

    Private _transId As String
    Private _tableName As String
    Private _transType As String
    Private _valueFrom As String
    Private _valueTo As String
    Private _transDate As String
    Private _transDatetime As String
    Private _transBy As String

    Public Property transId As String
        Get
            Return Me._transId
        End Get
        Set(ByVal Value As String)
            Me._transId = Value
        End Set
    End Property

    Public Property tableName As String
        Get
            Return Me._tableName
        End Get
        Set(ByVal Value As String)
            Me._tableName = Value
        End Set
    End Property

    Public Property transType As String
        Get
            Return Me._transType
        End Get
        Set(ByVal Value As String)
            Me._transType = Value
        End Set
    End Property

    Public Property valueFrom As String
        Get
            Return Me._valueFrom
        End Get
        Set(ByVal Value As String)
            Me._valueFrom = Value
        End Set
    End Property

    Public Property valueTo As String
        Get
            Return Me._valueTo
        End Get
        Set(ByVal Value As String)
            Me._valueTo = Value
        End Set
    End Property

    Public Property transDate As String
        Get
            Return Me._transDate
        End Get
        Set(ByVal Value As String)
            Me._transDate = Value
        End Set
    End Property

    Public Property transDatetime As String
        Get
            Return Me._transDatetime
        End Get
        Set(ByVal Value As String)
            Me._transDatetime = Value
        End Set
    End Property

    Public Property transBy As String
        Get
            Return Me._transBy
        End Get
        Set(ByVal Value As String)
            Me._transBy = Value
        End Set
    End Property

    Public Sub initialize()
        _transId = ""
        _tableName = ""
        _transType = ""
        _valueFrom = ""
        _valueTo = ""
        _transDate = ""
        _transDatetime = ""
        _transBy = ""
    End Sub


    Public Function browseAuditTrail(ByVal _criteria As String, Optional ByVal browse_type As String = "BROWSE") As DataTable
        Dim sql As String = ""
        sql = "SELECT trans_id, table_name, trans_type, value_from, value_to, trans_date, trans_datetime, trans_by, FROM tbl_audit_trail"
        Select Case browse_type
            Case "BROWSE"
                sql = sql & " WHERE trans_id LIKE '%" & _criteria & "%' OR table_name LIKE '%" & _criteria & "%' OR trans_type LIKE '%" & _criteria & "%' OR value_from LIKE '%" & _criteria & "%' OR value_to LIKE '%" & _criteria & "%' OR trans_date LIKE '%" & _criteria & "%' OR trans_datetime LIKE '%" & _criteria & "%' OR trans_by LIKE '%" & _criteria & "%' OR  ORDER BY "
        End Select
        Return _clsDB.Fill_DataTable(sql, "tbl_audit_trail")
    End Function


    Public Sub saveAuditTrail()

        With _clsDB.dbUtility
            .fieldItems = "trans_id,table_name,trans_type,value_from,value_to,trans_date,trans_datetime,trans_by"
            .sqlString = .getSQLStatement("tbl_audit_trail", "INSERT")
            _transId = Guid.NewGuid.ToString.Replace("-", "") & DateTime.Now.ToString("MMddyyyymmhhss")
            .ADDPARAM_CMD_String("trans_id", _transId)
            .ADDPARAM_CMD_String("table_name", _tableName)
            .ADDPARAM_CMD_String("trans_type", _transType)
            .ADDPARAM_CMD_String("value_from", _valueFrom)
            .ADDPARAM_CMD_String("value_to", _valueTo)
            .ADDPARAM_CMD_String("trans_date", DateTime.Now.Date)
            .ADDPARAM_CMD_String("trans_datetime", DateTime.Now.ToString)
            .ADDPARAM_CMD_String("trans_by", _transBy)
            .executeUsingCommandFromSQL(True)

        End With
       

    End Sub




End Class
