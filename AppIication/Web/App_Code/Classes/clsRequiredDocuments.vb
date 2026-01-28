Imports Microsoft.VisualBasic
Imports System.Data

Public Class clsRequiredDocuments

    Dim _clsDB As New clsDBDocs
    'Dim _clsDB As New clsDatabase

    Public Sub New()
        initialize()
    End Sub

    Private _transId As String
    Private _seniorId As String
    Private _documentCode As String
    Private _documentData() As Byte
    Private _approveStatus As String
    Private _fileName As String
    Private _fileType As String
    Private _fileSize As String

#Region "Properties"
    Public Property transId As String
        Get
            Return Me._transId
        End Get
        Set(ByVal Value As String)
            Me._transId = Value
        End Set
    End Property

    Public Property seniorId As String
        Get
            Return Me._seniorId
        End Get
        Set(ByVal Value As String)
            Me._seniorId = Value
        End Set
    End Property

    Public Property documentCode As String
        Get
            Return Me._documentCode
        End Get
        Set(ByVal Value As String)
            Me._documentCode = Value
        End Set
    End Property

    Public Property documentData As Byte()
        Get
            Return Me._documentData
        End Get
        Set(ByVal Value As Byte())
            Me._documentData = Value
        End Set
    End Property

    Public Property approveStatus As String
        Get
            Return Me._approveStatus
        End Get
        Set(ByVal Value As String)
            Me._approveStatus = Value
        End Set
    End Property

    Public Property fileName As String
        Get
            Return Me._fileName
        End Get
        Set(ByVal Value As String)
            Me._fileName = Value
        End Set
    End Property

    Public Property fileType As String
        Get
            Return Me._fileType
        End Get
        Set(ByVal Value As String)
            Me._fileType = Value
        End Set
    End Property

    Public Property fileSize As String
        Get
            Return Me._fileSize
        End Get
        Set(ByVal Value As String)
            Me._fileSize = Value
        End Set
    End Property

#End Region


    Public Sub initialize()
        _transId = ""
        _seniorId = ""
        _documentCode = ""
        _approveStatus = ""
        _fileName = ""
        _fileType = ""
        _fileSize = ""
    End Sub


    Public Function browseRequiredDocuments(ByVal _thisSeniorID As String) As DataTable
        Dim sql As String = ""
        sql = "SELECT req_desc, trans_id, req_display, senior_id, document_code, approve_status, file_name, file_type, file_size FROM tbl_required_documents " & _
              "INNER JOIN tbl_ref_required_document ON tbl_required_documents.document_code=tbl_ref_required_document.req_code " & _
              "WHERE senior_id = '" & _thisSeniorID & "'"
        Return _clsDB.Fill_DataTable(sql, "tbl_required_documents")
    End Function

    Public Function browseAttachments(ByVal _thisSeniorID As String) As DataTable
        Dim sql As String = ""
        'sql = "SELECT tbl_required_documents.trans_id,req_code, req_desc, req_display, trans_id, senior_id,document_code, approve_status, file_name, file_type, file_size, " & _
        '      "CONCAT('data:image/png;base64,',TO_BASE64(document_data)) AS document_data, " & _
        '      "(CASE WHEN tbl_required_documents.trans_id IS NULL THEN 'FALSE' ELSE 'TRUE' END) AS hasFile FROM tbl_ref_required_document  " & _
        '      "LEFT JOIN tbl_required_documents ON tbl_required_documents.document_code = tbl_ref_required_document.req_code AND " & _
        '      "tbl_required_documents.senior_id = '" & _thisSeniorID & "' "

        sql = "SELECT tbl_required_documents.trans_id,req_code, req_desc, req_display, trans_id, senior_id,document_code, approve_status, file_name, file_type, file_size, " & _
              "(CASE WHEN tbl_required_documents.trans_id IS NULL THEN 'FALSE' ELSE 'TRUE' END) AS hasFile, req_optional FROM tbl_ref_required_document  " & _
             "LEFT JOIN tbl_required_documents ON tbl_required_documents.document_code = tbl_ref_required_document.req_code AND " & _
             "tbl_required_documents.senior_id = '" & _thisSeniorID & "' " & _
             "WHERE tbl_ref_required_document.status = 'Y' "

        Return _clsDB.Fill_DataTable(sql, "tbl_required_documents")
    End Function


    Public Sub saveRequiredDocuments()
        With _clsDB.dbUtility
            .fieldItems = "trans_id,senior_id,document_code,document_data,approve_status,file_name,file_type,file_size"
            .sqlString = .getSQLStatement("tbl_required_documents", "INSERT")
            _transId = DateTime.Now.ToString("MMddyyyymmhhss") & Left(Guid.NewGuid().ToString.Replace("-", ""), 25).ToUpper
            .ADDPARAM_CMD_String("trans_id", _transId)
            .ADDPARAM_CMD_String("senior_id", _seniorId)
            .ADDPARAM_CMD_String("document_code", _documentCode)
            .ADDPARAM_CMD_String("document_data", _documentData)
            .ADDPARAM_CMD_String("approve_status", _approveStatus)
            .ADDPARAM_CMD_String("file_name", _fileName)
            .ADDPARAM_CMD_String("file_type", _fileType)
            .ADDPARAM_CMD_String("file_size", _fileSize)
            .executeUsingCommandFromSQL(True)
        End With
    End Sub

    Public Sub getRequiredDocuments(ByVal _id As String)
        Dim dt As New DataTable
        dt = _clsDB.Fill_DataTable("SELECT * FROM tbl_required_documents WHERE trans_id='" & _id & "' LIMIT 1")
        If dt.Rows.Count > 0 Then
            _transId = dt.Rows(0)("trans_id") & ""
            _seniorId = dt.Rows(0)("senior_id") & ""
            _documentCode = dt.Rows(0)("document_code") & ""
            If Not IsDBNull(dt.Rows(0)("document_data")) Then
                _documentData = dt.Rows(0)("document_data")
            End If
            _approveStatus = dt.Rows(0)("approve_status") & ""
            _fileName = dt.Rows(0)("file_name") & ""
            _fileType = dt.Rows(0)("file_type") & ""
            _fileSize = dt.Rows(0)("file_size") & ""

            If _fileType = "application/pdf" Then
                _fileSize = dt.Rows(0)("file_size") & "|1200"
            End If

        Else
            initialize()
        End If
    End Sub

    Public Function isApproved() As Boolean
        'Return 0 = _clsDB.Get_DB_Item("SELECT count(trans_id) as count FROM tbl_required_documents WHERE senior_id=" & _seniorId  & " AND trans_type='" & transType & "' AND approve_status='N'")
    End Function

    'Public Function formatDoc() As String

    '    Dim embed As String = ""

    '    If _fileType.ToLower = "application/pdf" Then
    '        embed = "<object data=""{0}{1}"" type=""application/pdf"" width=""1000px"" height=""550px"">"
    '    Else
    '        Dim size() As String = fileSize.Split("|")
    '        Dim thisWidth As String = "1000"
    '        Dim thisHeight As String = "550"

    '        If Integer.Parse(size(1)) < 1001 Then thisWidth = size(1)
    '        If Integer.Parse(size(2)) < 551 Then thisHeight = size(2)

    '        embed = "<object data=""{0}{1}"" type=""" & _fileType & """ width=""" & thisWidth & "px"" height=""" & thisHeight & "px"">"
    '    End If

    '    'embed += "If you are unable to view file, you can download from <a href = ""{0}{1}&download=1"">here</a>"
    '    'embed += " or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/"">Adobe PDF Reader</a> to view the file."
    '    embed += "</object>"

    '    Return embed

    'End Function

    Public Function formatDoc() As String


        Dim embed As String = ""

        If _fileType.ToLower = "application/pdf" Then
            embed = "<object data=""{0}{1}"" type=""application/pdf"" width=""100%"" height=""850px"">"
        Else
            Dim size() As String = fileSize.Split("|")
            Dim thisWidth As String = size(1)
            Dim thisHeight As String = size(2)

            '  If Integer.Parse(size(1)) < 1001 Then thisWidth = size(1)
            '  If Integer.Parse(size(2)) < 551 Then thisHeight = size(2)

            'embed = "<object data=""{0}{1}"" type=""" & _fileType & """ width=""" & thisWidth & """ height=""" & thisHeight & """>"

            embed = "<img src=""{0}{1}""  width='" & thisWidth & "' height='" & thisHeight & "' style='display:block;' />"

            'embed = "<object data=""{0}{1}"" type=""" & _fileType & """ width=""100%"" height=""100%"">"
        End If


        'embed += "If you are unable to view file, you can download from <a href = ""{0}{1}&download=1"">here</a>"
        'embed += " or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/"">Adobe PDF Reader</a> to view the file."
        embed += "</object>"

        Return embed

    End Function

    Public Sub deleteDocument(ByVal _thisTransId As String)
        _clsDB.Delete_Record("DELETE FROM tbl_required_documents WHERE trans_id='" & _thisTransId & "'")
    End Sub
    Public Sub deleteDocument()
        _clsDB.Delete_Record("DELETE FROM tbl_required_documents WHERE senior_id='" & _seniorId & "' AND document_code='" & _documentCode & "'")
    End Sub

    Public Function getSCPicture(_thisID As String) As DataTable
        Dim dt As New DataTable

        dt = _clsDB.Fill_DataTable("SELECT document_data as senior_pic FROM tbl_required_documents WHERE document_code='PIC' AND senior_id='" & _thisID & "'", "tbl_senior_citizen_picture")

        Return dt

    End Function

    Public Sub getSCIDPicture(ByVal _thisID As String)
        Dim dt As New DataTable

        dt = _clsDB.Fill_DataTable("SELECT document_data FROM tbl_required_documents WHERE document_code='PIC' AND senior_id='" & _thisID & "'", "tbl_senior_citizen_picture")

        If dt.Rows.Count > 0 Then
            _documentData = dt.Rows(0)("document_data")
        Else
            _documentData = Nothing
        End If

    End Sub

End Class
