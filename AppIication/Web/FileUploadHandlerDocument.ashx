<%@ WebHandler Language="VB" Class="FileUploadHandlerDocument" %>

Imports System
Imports System.Web
Imports System.IO
Imports System.Drawing
Public Class FileUploadHandlerDocument : Implements IHttpHandler, System.Web.SessionState.IRequiresSessionState

    Dim _clsReqDocs As New clsRequiredDocuments
      
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        If (context.Request.Files.Count > 0) Then
            Dim files As HttpFileCollection = context.Request.Files
                 
            Dim file As HttpPostedFile = files(0)
                     
            If file IsNot Nothing And file.ContentLength > 0 Then
                ' MsgBox("naa")
                Dim mstream As New MemoryStream()
                Dim thisImage As System.Drawing.Image = System.Drawing.Image.FromStream(file.InputStream)

                Dim imageWidth As Integer
                Dim imageHeight As Integer


                Dim _set As Integer = 1200

                If thisImage.Width > _set Then

                    If (thisImage.Height > thisImage.Width) Then
                        imageHeight = _set
                        imageWidth = ((thisImage.Width / thisImage.Height) * _set)
                    Else
                        imageWidth = _set
                        imageHeight = ((thisImage.Height / thisImage.Width) * _set)
                    End If

                Else
                    imageWidth = thisImage.Width
                    imageHeight = thisImage.Height
                End If

                Dim thisImageResize As System.Drawing.Image = ResizeImage(thisImage, imageWidth, imageHeight)
                thisImageResize.Save(mstream, Imaging.ImageFormat.Png)

                Dim file_bytes() As Byte

                file_bytes = mstream.GetBuffer()

                With _clsReqDocs
                    .initialize()
                    .seniorId = context.Session("SENIOR_ID").ToString
                    .documentCode = context.Session("DOCTYPE").ToString
                    ' .documentDesc = hfDocType.Value
                    .fileName = file.FileName
                    .fileSize = file_bytes.Length.ToString & "|" & thisImageResize.Width & "|" & thisImageResize.Height
                    .fileType = file.ContentType
                    .documentData = file_bytes
                    '.uploadUser = Session("APP_ID")
                    .deleteDocument()
                    .saveRequiredDocuments()
                End With
            Else
             '   MsgBox("wala")
            End If
            '  context.Session("IS_UPLOAD") = "Y"

            context.Response.ContentType = "application/json"
            context.Response.Write("{}")

        End If
    End Sub
    
    Public Shared Function ResizeImage(ByVal InputImage As Image, ByVal inputWidth As Integer, ByVal inputHeight As Integer) As Image

        Return New Bitmap(InputImage, New Size(inputWidth, inputHeight))

    End Function
 
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class