Imports System.Drawing.Imaging
Partial Class Secured_SystemAdministration_Ahctpac
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Declare The CaptchaObject
        Dim xcaptcha As PC.CaptchaImage
        'Create The Captcha Object		
        xcaptcha = New PC.CaptchaImage("", 100, 60)
        'Set the Captcha Text to a session variable
        Session("CaptchaText") = xcaptcha.Text
        'Set the response of this page to an image
        Context.Response.ContentType = "image/jpeg"
        'output the image to the response
        xcaptcha.Image.Save(Context.Response.OutputStream, ImageFormat.Jpeg)
        'Close and Dispose the Captcha Object
        xcaptcha.Dispose()
    End Sub
End Class
