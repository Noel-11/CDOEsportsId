Imports Microsoft.VisualBasic
Imports System.Data
Public Class clsUploadDiagnoses

    Dim _clsDB As New clsDatabase

    Public Sub New()
        initialize()
    End Sub

    Private _diagnoses As String
    Private _uploadType As String

    Public Property diagnoses As String
        Get
            Return Me._diagnoses
        End Get
        Set(ByVal Value As String)
            Me._diagnoses = Value
        End Set
    End Property

    Public Property uploadType As String
        Get
            Return Me._uploadType
        End Get
        Set(ByVal Value As String)
            Me._uploadType = Value
        End Set
    End Property

    Public Sub initialize()
        _diagnoses = ""
        _uploadType = ""
    End Sub

    Public Function browseUploadDiagnoses(ByVal _criteria As String, Optional ByVal browse_type As String = "BROWSE") As DataTable
        Dim sql As String = ""
        sql = "SELECT diagnoses, upload_type, FROM tbl_ref_upload_diagnoses"
        Select Case browse_type
            Case "BROWSE"
                sql = sql & " WHERE diagnoses LIKE '%" & _criteria & "%' OR upload_type LIKE '%" & _criteria & "%' OR  ORDER BY "
        End Select
        Return _clsDB.Fill_DataTable(sql, "tbl_ref_upload_diagnoses")
    End Function

    Public Function getUploadDiagnoses(ByVal _criteria As String, ByVal _thisUpload As String) As DataTable
        Dim sql As String = ""
        sql = "SELECT DISTINCT diagnoses, upload_type FROM tbl_ref_upload_diagnoses " & _
              "WHERE diagnoses LIKE '" & _criteria & "%' AND upload_type ='" & _thisUpload & "'"

        Return _clsDB.Fill_DataTable(sql, "getUploadDiagnoses")
    End Function

    Public Sub saveUploadDiagnoses()
        _clsDB.Delete_Record("DELETE FROM tbl_ref_upload_diagnoses WHERE diagnoses='" & _diagnoses & "' AND upload_type='" & _uploadType & "'")
        With _clsDB.dbUtility
            .fieldItems = "diagnoses,upload_type"
            .sqlString = .getSQLStatement("tbl_ref_upload_diagnoses", "INSERT")
            .ADDPARAM_CMD_String("diagnoses", _diagnoses)
            .ADDPARAM_CMD_String("upload_type", _uploadType)
            .executeUsingCommandFromSQL(True)
        End With

    End Sub



End Class
