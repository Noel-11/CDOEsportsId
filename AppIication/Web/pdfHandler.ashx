<%@ WebHandler Language="VB" Class="pdfHandler" %>

Imports System
Imports System.Web
Imports System.Data
Imports System.Drawing.Imaging
Imports System.Data.SqlClient
Imports System.Configuration

Public Class pdfHandler : Implements IHttpHandler
    Dim _clsRequiredDocuments As New clsRequiredDocuments

    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

        _clsRequiredDocuments.getRequiredDocuments(context.Request.QueryString("Id"))

        context.Response.Buffer = True
        context.Response.Charset = ""
        'If context.Request.QueryString("download") = "1" Then
        '    context.Response.AppendHeader("Content-Disposition", Convert.ToString("attachment; filename=") & "x.pdf")
        'End If
        context.Response.Cache.SetCacheability(HttpCacheability.NoCache)
        ' context.Response.ContentType = "application/pdf"
        'If _clsAppDetail.fileType.ToLower = "pdf" Then
        'context.Response.ContentType = "application/pdf"
        'Else
        'context.Response.ContentType = "image/" & _clsAppDetail.fileType.ToLower
        'End If
        context.Response.ContentType = _clsRequiredDocuments.fileType.ToLower
        context.Response.BinaryWrite(_clsRequiredDocuments.documentData)
        context.Response.Flush()
        context.Response.[End]()
    End Sub

    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property
End Class