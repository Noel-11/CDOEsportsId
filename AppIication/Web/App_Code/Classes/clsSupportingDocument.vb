Imports Microsoft.VisualBasic
Imports System.Data
Public Class clsSupportingDocument

    Dim _clsDB As New clsDBDocs

    Public Sub New()
        initialize()
    End Sub

#Region "Properties"
    Public Property transId As String

    Public Property applicationId As String

    Public Property documentType As String


    Public Property documentDesc As String

    Public Property fileName As String

    Public Property fileSize As String

    Public Property downloadCount As String

    Public Property fileType As String

    Public Property documentData As Byte()

    Public Property uploadUser As String

    Public Property uploadDate As String

    Public Property uploadDatetime As String

    Public Property isActive As String
    Public Property deleteUser As String

    Public Property deleteDate As String

#End Region

    Public Sub initialize()
        _transId = ""
        _applicationId = ""
        _documentType = ""
        _documentDesc = ""
        _fileName = ""
        _fileSize = ""
        _downloadCount = "0"
        _fileType = ""
        _uploadUser = ""
        _uploadDate = ""
        _uploadDatetime = ""
        _isActive = "Y"
        _deleteUser = ""
        _deleteDate = ""
    End Sub

    Public Function browseDocumentData(ByVal _thisDocument As String) As DataTable
        Dim sql As String = ""
        sql = "SELECT trans_id, application_id, document_desc, document_type, document_type AS document_type_id, file_name, file_size, download_count, upload_user, upload_date, upload_datetime FROM tbl_document " &
              " WHERE is_active='Y' AND application_id='" & _thisDocument & "' ORDER BY upload_datetime"
        Return _clsDB.Fill_DataTable(sql, "tbl_document")
    End Function


    Public Sub saveDocumentData()

        With _clsDB.dbUtility
            .fieldItems = "trans_id,application_id,document_type,document_desc,file_name,file_size,download_count,file_type,document_data,upload_user,upload_date,upload_datetime,is_active"
            .sqlString = .getSQLStatement("tbl_document", "INSERT")
            _transId = DateTime.Now.ToString("MMddyyyymmhhss") & Left(Guid.NewGuid().ToString.Replace("-", ""), 25).ToUpper
            .ADDPARAM_CMD_String("trans_id", _transId)
            .ADDPARAM_CMD_String("application_id", _applicationId)
            .ADDPARAM_CMD_String("document_type", documentType)
            .ADDPARAM_CMD_String("document_desc", _documentDesc)
            .ADDPARAM_CMD_String("file_name", _fileName)
            .ADDPARAM_CMD_String("file_size", _fileSize)
            .ADDPARAM_CMD_String("download_count", _downloadCount)
            .ADDPARAM_CMD_String("file_type", _fileType)
            .ADDPARAM_CMD_String("document_data", _documentData)
            .ADDPARAM_CMD_String("upload_user", _uploadUser)
            .ADDPARAM_CMD_String("upload_date", DateTime.Now.Date)
            .ADDPARAM_CMD_String("upload_datetime", DateTime.Now.ToString)
            .ADDPARAM_CMD_String("is_active", _isActive)
            .executeUsingCommandFromSQL(True)
        End With


    End Sub

    Public Sub getDocumentData(ByVal _id As String)
        Dim dt As New DataTable
        dt = _clsDB.Fill_DataTable("SELECT * FROM tbl_document WHERE is_active='Y' AND trans_id='" & _id & "'")
        If dt.Rows.Count > 0 Then
            _transId = dt.Rows(0)("trans_id") & ""
            _applicationId = dt.Rows(0)("application_id") & ""
            _documentDesc = dt.Rows(0)("document_desc") & ""
            _fileName = dt.Rows(0)("file_name") & ""
            _fileSize = dt.Rows(0)("file_size") & ""
            _fileType = dt.Rows(0)("file_type") & ""
            _downloadCount = dt.Rows(0)("download_count") & ""
            _documentData = dt.Rows(0)("document_data")
            _uploadUser = dt.Rows(0)("upload_user") & ""
            _uploadDate = dt.Rows(0)("upload_date").ToString
            _uploadDatetime = dt.Rows(0)("upload_datetime") & ""
        Else
            initialize()
        End If
    End Sub

    Public Sub getDocumentAppData(ByVal _id As String)
        Dim dt As New DataTable
        dt = _clsDB.Fill_DataTable("SELECT * FROM tbl_document WHERE is_active='Y' AND application_id='" & _id & "' LIMIT 1")
        If dt.Rows.Count > 0 Then
            _transId = dt.Rows(0)("trans_id") & ""
            _applicationId = dt.Rows(0)("application_id") & ""
            _documentDesc = dt.Rows(0)("document_desc") & ""
            _fileName = dt.Rows(0)("file_name") & ""
            _fileSize = dt.Rows(0)("file_size") & ""
            _fileType = dt.Rows(0)("file_type") & ""
            _downloadCount = dt.Rows(0)("download_count") & ""
            _documentData = dt.Rows(0)("document_data")
            _uploadUser = dt.Rows(0)("upload_user") & ""
            _uploadDate = dt.Rows(0)("upload_date").ToString
            _uploadDatetime = dt.Rows(0)("upload_datetime") & ""
        Else
            initialize()
        End If
    End Sub

    Public Sub getDocumentAppDataDocType(ByVal _id As String, ByVal _thisDocType As String)
        Dim dt As New DataTable
        dt = _clsDB.Fill_DataTable("SELECT * FROM tbl_document WHERE is_active='Y' AND application_id='" & _id & "' AND document_type = '" & _thisDocType & "' LIMIT 1")
        If dt.Rows.Count > 0 Then
            _transId = dt.Rows(0)("trans_id") & ""
            _applicationId = dt.Rows(0)("application_id") & ""
            _documentDesc = dt.Rows(0)("document_desc") & ""
            _fileName = dt.Rows(0)("file_name") & ""
            _fileSize = dt.Rows(0)("file_size") & ""
            _fileType = dt.Rows(0)("file_type") & ""
            _downloadCount = dt.Rows(0)("download_count") & ""
            _documentData = dt.Rows(0)("document_data")
            _uploadUser = dt.Rows(0)("upload_user") & ""
            _uploadDate = dt.Rows(0)("upload_date").ToString
            _uploadDatetime = dt.Rows(0)("upload_datetime") & ""
        Else
            initialize()
        End If
    End Sub

    Public Sub deleteDocument()
        With _clsDB.dbUtility
            .fieldItems = "is_active,delete_user,delete_date"
            .sqlString = .getSQLStatement("tbl_document", "UPDATE", "application_id,is_active", "AND")
            .ADDPARAM_CMD_String("is_active", "N")
            .ADDPARAM_CMD_String("delete_user", _deleteUser)
            .ADDPARAM_CMD_String("delete_date", DateTime.Now.Date)
            .ADDPARAM_CMD_String("application_id", _applicationId)
            .ADDPARAM_CMD_String("is_active2", "Y")
            .executeUsingCommandFromSQL(True)
        End With
    End Sub

    Public Sub removeImage()
        With _clsDB.dbUtility
            .sqlString = "DELETE FROM tbl_document WHERE trans_id = '" & _transId & "'"
            .executeUsingCommandFromSQL(True)
        End With
    End Sub

    Public Sub removeAppImage()
        With _clsDB.dbUtility
            .sqlString = "DELETE FROM tbl_document WHERE application_id = '" & _applicationId & "'"
            .executeUsingCommandFromSQL(True)
        End With
    End Sub

    Public Sub removeAppImageDocType()
        With _clsDB.dbUtility
            .sqlString = "DELETE FROM tbl_document WHERE application_id = '" & _applicationId & "' AND document_type = '" & _documentType & "'"
            .executeUsingCommandFromSQL(True)
        End With
    End Sub

    Public Sub removeExistImage()
        With _clsDB.dbUtility
            .sqlString = "DELETE FROM tbl_document WHERE application_id = '" & _applicationId & "' AND document_type = '" & _documentType & "'"
            .executeUsingCommandFromSQL(True)
        End With
    End Sub

    Public Sub removeRelImage()
        With _clsDB.dbUtility
            .sqlString = "DELETE FROM tbl_document WHERE application_id = '" & _applicationId & "'"
            .executeUsingCommandFromSQL(True)
        End With
    End Sub

    Public Function formatDoc() As String


        Dim embed As String = ""

        If _fileType.ToLower = "application/pdf" Then
            embed = "<object data=""{0}{1}"" type=""application/pdf"" width=""100%"" height=""850px"">"
        Else
            Dim size() As String = fileSize.Split("|")
            Dim thisWidth As String = "100%"
            Dim thisHeight As String = "100%"

            '  If Integer.Parse(size(1)) < 1001 Then thisWidth = size(1)
            '  If Integer.Parse(size(2)) < 551 Then thisHeight = size(2)

            embed = "<object data=""{0}{1}"" type=""" & _fileType & """ width=""" & thisWidth & """ height=""" & thisHeight & """>"
            'embed = "<object data=""{0}{1}"" type=""" & _fileType & """ width=""100%"" height=""100%"">"
        End If


        'embed += "If you are unable to view file, you can download from <a href = ""{0}{1}&download=1"">here</a>"
        'embed += " or download <a target = ""_blank"" href = ""http://get.adobe.com/reader/"">Adobe PDF Reader</a> to view the file."
        embed += "</object>"

        Return embed

    End Function

    Public Sub updateDocumentRegStatus(thiRefCode As String, thisStatus As String)
        _clsDB.dbUtility.sqlString = "UPDATE  tbl_document set registration_status='" & thisStatus & "' WHERE application_id='" & thiRefCode & "' AND registration_status='APPLICATION'"
        _clsDB.dbUtility.executeUsingCommandFromSQL()
    End Sub
End Class
