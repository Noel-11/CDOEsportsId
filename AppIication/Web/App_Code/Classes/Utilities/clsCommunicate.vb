Imports Microsoft.VisualBasic
Imports System.Net.Mail
Imports System.Net
Imports System.IO

Public Class clsCommunicate
    Public Sub sendGmail(thisRecipient As String, thisSubject As String, thisMessage As String)
        Try
            Dim client As New SmtpClient("smtp.gmail.com", 587)
            client.EnableSsl = True
            client.UseDefaultCredentials = False
            Dim [from] As New MailAddress("obbServiceEmail@gmail.com", "[BOLONSIRI ONLINE BURIAL BOOKING]")
            Dim [to] As New MailAddress(thisRecipient, thisRecipient)
            Dim message As New MailMessage([from], [to])
            message.Body = thisMessage & "<br/><br/>" & " This is a system generated email, please do not reply."
            message.IsBodyHtml = True
            message.Subject = thisSubject
            Dim myCreds As New NetworkCredential("obbServiceEmail@gmail.com", "ryejqkkrqkfulasy")
            client.Credentials = myCreds

            client.Send(message)
        Catch ex As Exception

        End Try

    End Sub

    Public Sub sendGmailWithAttachment(thisRecipient As String, thisSubject As String, thisMessage As String, fileName As String, fileByte As MemoryStream)
        Try
            'Dim attachPDF As New Attachment(fileByte, "application/pdf")
            'attachPDF.ContentDisposition.FileName = fileName

            'Dim client As New SmtpClient("smtp.gmail.com", 587)
            'client.EnableSsl = True
            'client.UseDefaultCredentials = False
            'Dim from As New MailAddress("lgucdoonlineservices@gmail.com", "[Pre-Arrival]")
            'Dim [to] As New MailAddress(thisRecipient, thisRecipient)
            'Dim message As New MailMessage(from, [to])
            'message.Body = thisMessage & "<br/><br/>" & " This is a system generated email, please do not reply."
            'message.Attachments.Add(attachPDF)
            'message.IsBodyHtml = True
            'message.Subject = thisSubject
            'Dim myCreds As New NetworkCredential("lgucdoonlineservices@gmail.com", "derflez79")
            'client.Credentials = myCreds
            'client.Send(message)

            Dim attachPDF As New Attachment(fileByte, "application/pdf")
            attachPDF.ContentDisposition.FileName = fileName

            Dim client As New SmtpClient("smtp.gmail.com", 587)
            client.EnableSsl = True
            client.UseDefaultCredentials = False
            Dim from As New MailAddress("travel.verifier@gmail.com", "[Pre-Arrival]")
            Dim [to] As New MailAddress(thisRecipient, thisRecipient)
            Dim message As New MailMessage(from, [to])
            message.Body = thisMessage & "<br/><br/>" & " This is a system generated email, please do not reply."
            message.Attachments.Add(attachPDF)
            message.IsBodyHtml = True
            message.Subject = thisSubject
            Dim myCreds As New NetworkCredential("travel.verifier@gmail.com", "aiypwzqp")
            client.Credentials = myCreds
            client.Send(message)

        Catch ex As Exception

        End Try

    End Sub

    Public Sub notifySMS(thisMOD As String, thisNumber As String, thisMessage As String)
        'Dim sms As New wrSMS.smsWS

        'Dim nums() As String = thisNumber.Split(",")
        'Try
        '    For Each n As String In nums
        '        If n.Trim <> "" Then
        '            sms.saveSMS("AlexandraMikaelaDaniellaAntoinetteOliviaGabrielle", thisMOD, "SCHED", n.Trim, thisMessage, 1, "", "")
        '        End If

        '    Next
        'Catch ex As Exception

        'End Try

        'sms.saveSMS("AlexandraMikaelaDaniellaAntoinetteOliviaGabrielle", "SCIDVAL", "", "09261277653", "For Validation - Senior Citizen ID Online Application of ", 0, "", "")
    End Sub
End Class
