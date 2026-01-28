Imports Microsoft.VisualBasic
Imports System.Data
Public Class clsComments


    Dim _clsDB As New clsDatabase

    Public Sub New()
        initialize()
    End Sub

    Private _transId As String
    Private _commentName As String
    Private _commentContactno As String
    Private _comment As String
    Private _commentIp As String
    Private _reply As String
    Private _replyCount As Integer
    Private _commentDate As String
    Private _commentDatetime As String

#Region "Properties"
    Public Property transId As String
        Get
            Return Me._transId
        End Get
        Set(ByVal Value As String)
            Me._transId = Value
        End Set
    End Property

    Public Property commentName As String
        Get
            Return Me._commentName
        End Get
        Set(ByVal Value As String)
            Me._commentName = Value
        End Set
    End Property

    Public Property commentContactno As String
        Get
            Return Me._commentContactno
        End Get
        Set(ByVal Value As String)
            Me._commentContactno = Value
        End Set
    End Property

    Public Property comment As String
        Get
            Return Me._comment
        End Get
        Set(ByVal Value As String)
            Me._comment = Value
        End Set
    End Property
    Public Property reply As String
        Get
            Return Me._reply
        End Get
        Set(ByVal Value As String)
            Me._reply = Value
        End Set
    End Property
    Public Property replyCount As Integer
        Get
            Return Me._replyCount
        End Get
        Set(ByVal Value As Integer)
            Me._replyCount = Value
        End Set
    End Property

    Public Property commentIp As String
        Get
            Return Me._commentIp
        End Get
        Set(ByVal Value As String)
            Me._commentIp = Value
        End Set
    End Property

    Public Property commentDate As String
        Get
            Return Me._commentDate
        End Get
        Set(ByVal Value As String)
            Me._commentDate = Value
        End Set
    End Property

    Public Property commentDatetime As String
        Get
            Return Me._commentDatetime
        End Get
        Set(ByVal Value As String)
            Me._commentDatetime = Value
        End Set
    End Property

#End Region

    Public Sub initialize()
        _transId = ""
        _commentName = ""
        _commentContactno = ""
        _comment = ""
        _commentIp = ""
        _reply = ""
        _replyCount = 0
        '  _commentDate = ""
        _commentDatetime = ""
    End Sub

    Public Function browsecomments(ByVal _criteria As String, Optional ByVal browse_type As String = "BROWSE") As DataTable
        Dim sql As String = ""
        sql = "SELECT trans_id,comment_name, comment_contactno, comment,reply,reply_count, comment_ip, comment_date, comment_datetime FROM tbl_comments " & _
        " WHERE comment_name LIKE '%" & _criteria & "%' OR comment LIKE '%" & _criteria & "%'  ORDER BY STR_TO_DATE(comment_datetime,'%Y-%m-%d  %l:%i:%s %p') DESC"
        Return _clsDB.Fill_DataTable(sql, "tbl_comments")
    End Function

    Public Sub savecommentsw()

        With _clsDB.dbUtility
            .fieldItems = "trans_id,comment_name,comment_contactno,comment,comment_ip,comment_date,comment_datetime"
            .sqlString = .getSQLStatement("tbl_comments", "INSERT")
            _transId = DateTime.Now.ToString("MMddyyyymmhhss") & Left(Guid.NewGuid().ToString.Replace("-", ""), 25).ToUpper
            .ADDPARAM_CMD_String("trans_id", _transId)
            .ADDPARAM_CMD_String("comment_name", _commentName)
            .ADDPARAM_CMD_String("comment_contactno", _commentContactno)
            .ADDPARAM_CMD_String("comment", _comment)
            .ADDPARAM_CMD_String("comment_ip", _commentIp)
            .ADDPARAM_CMD_String("comment_date", DateTime.Now.Date)
            .ADDPARAM_CMD_String("comment_datetime", DateTime.Now.ToString)
            .executeUsingCommandFromSQL(True)
        End With

    End Sub
    Public Sub saveComments()
        With _clsDB.dbUtility
            .fieldItems = "trans_id,comment_name,comment_contactno,comment,comment_ip,comment_date,comment_datetime"
            .sqlString = .getSQLStatement("tbl_comments", "INSERT")
            transId = DateTime.Now.ToString("MMddyyyymmhhss") & Left(Guid.NewGuid().ToString.Replace("-", ""), 25).ToUpper
            .ADDPARAM_CMD_String("trans_id", _transId)
            .ADDPARAM_CMD_String("comment_name", _commentName)
            .ADDPARAM_CMD_String("comment_contactno", _commentContactno)
            .ADDPARAM_CMD_String("comment", _comment)
            .ADDPARAM_CMD_String("comment_ip", _commentIp)
            .ADDPARAM_CMD_String("comment_date", DateTime.Now.Date)
            .ADDPARAM_CMD_String("comment_datetime", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"))
            .executeUsingCommandFromSQL(True)
        End With
    End Sub
    Public Sub saveReply()
        If _transId <> "" Then
            With _clsDB.dbUtility
                .fieldItems = "reply,reply_count"
                .sqlString = .getSQLStatement("tbl_comments", "UPDATE", "trans_id")
                .ADDPARAM_CMD_String("reply", _reply)
                .ADDPARAM_CMD_String("reply_count", _replyCount)
                .ADDPARAM_CMD_String("trans_id", _transId)
                .executeUsingCommandFromSQL(True)
            End With
        End If
       
    End Sub


    Public Sub getcomments(ByVal _id As String)
        Dim dt As New DataTable
        dt = _clsDB.Fill_DataTable("SELECT * FROM tbl_comments WHERE trans_id='" & _id & "'")
        If dt.Rows.Count > 0 Then
            _transId = dt.Rows(0)("trans_id") & ""
            _commentName = dt.Rows(0)("comment_name") & ""
            _commentContactno = dt.Rows(0)("comment_contactno") & ""
            _comment = dt.Rows(0)("comment") & ""
            _reply = dt.Rows(0)("reply") & ""
            _replyCount = dt.Rows(0)("reply_count") & ""
            _commentIp = dt.Rows(0)("comment_ip") & ""
            ' _commentDate = dt.Rows(0)("comment_date")
            '_commentDatetime = dt.Rows(0)("comment_datetime") & ""
        Else
            initialize()
        End If
    End Sub

End Class
