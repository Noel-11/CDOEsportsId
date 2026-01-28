Imports Microsoft.VisualBasic
Imports System.Data
Public Class clsVisitor


    Dim _clsDB As New clsDatabase

    Public Sub New()
        initialize()
    End Sub

    Private _transId As String
    Private _visitorIp As String
    Private _visitorDate As String
    Private _visitorDatetime As String

#Region "Properties"
    Public Property transId As String
        Get
            Return Me._transId
        End Get
        Set(ByVal Value As String)
            Me._transId = Value
        End Set
    End Property

    Public Property visitorIp As String
        Get
            Return Me._visitorIp
        End Get
        Set(ByVal Value As String)
            Me._visitorIp = Value
        End Set
    End Property

    Public Property visitorDate As String
        Get
            Return Me._visitorDate
        End Get
        Set(ByVal Value As String)
            Me._visitorDate = Value
        End Set
    End Property

    Public Property visitorDatetime As String
        Get
            Return Me._visitorDatetime
        End Get
        Set(ByVal Value As String)
            Me._visitorDatetime = Value
        End Set
    End Property

#End Region


    Public Sub initialize()
        _transId = ""
        _visitorIp = ""
        _visitorDate = ""
        _visitorDatetime = ""
    End Sub


    Public Function browseVisitor(ByVal _criteria As String, Optional ByVal browse_type As String = "BROWSE") As DataTable
        Dim sql As String = ""
        sql = "SELECT trans_id, visitor_ip, visitor_date, visitor_datetime, FROM tbl_visitor " & _
        " WHERE trans_id LIKE '%" & _criteria & "%' OR visitor_ip LIKE '%" & _criteria & "%' OR visitor_date LIKE '%" & _criteria & "%' OR visitor_datetime LIKE '%" & _criteria & "%' OR  ORDER BY "
        Return _clsDB.Fill_DataTable(sql, "tbl_visitor")
    End Function


    Public Sub saveVisitor()

        With _clsDB.dbUtility
            .fieldItems = "trans_id,visitor_ip,visitor_date,visitor_datetime"
            .sqlString = .getSQLStatement("tbl_visitor", "INSERT")
            _transId = DateTime.Now.ToString("MMddyyyymmhhss") & Left(Guid.NewGuid().ToString.Replace("-", ""), 25).ToUpper
            .ADDPARAM_CMD_String("trans_id", _transId)
            .ADDPARAM_CMD_String("visitor_ip", _visitorIp)
            .ADDPARAM_CMD_String("visitor_date", DateTime.Now.Date)
            .ADDPARAM_CMD_String("visitor_datetime", DateTime.Now.ToString)
            .executeUsingCommandFromSQL(True)
        End With
     
    End Sub

    Public Sub getVisitor(ByVal _id As String)
        Dim dt As New DataTable
        dt = _clsDB.Fill_DataTable("SELECT * FROM tbl_visitor WHERE trans_id='" & _id & "'")
        If dt.Rows.Count > 0 Then
            _transId = dt.Rows(0)("trans_id") & ""
            _visitorIp = dt.Rows(0)("visitor_ip") & ""
            _visitorDate = dt.Rows(0)("visitor_date") & ""
            _visitorDatetime = dt.Rows(0)("visitor_datetime") & ""
        Else
            initialize()
        End If
    End Sub

    Public Function getVisitorCount(Optional _today As String = "Y") As Integer
        Dim visitorCount As Integer = 0

        Try
            If _today = "Y" Then

                visitorCount = _clsDB.Get_DB_Item("SELECT COUNT(*) as count FROM tbl_visitor WHERE MONTH(visitor_date)=" & DateTime.Now.Month & " AND DAY(visitor_date)=" & DateTime.Now.Day & " AND YEAR(visitor_date)=" & DateTime.Now.Year)
            ElseIf _today = "ALL" Then
                visitorCount = _clsDB.Get_DB_Item("SELECT COUNT(*) as count FROM tbl_visitor")
            End If

        Catch ex As Exception
            visitorCount = 0
        End Try
    
        Return visitorCount
    End Function
End Class
