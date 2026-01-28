Imports System.Data
Imports System.Net
Imports System.Net.Sockets

Partial Class _admin
    Inherits System.Web.UI.Page

    Dim _dt As New DataTable

    Dim clsLibrary As New clsLibrary
    Dim _clsUser As New clsUser
    Dim _clsDB As New clsDatabase
    Dim _dtCV As New DataTable

    Dim _clsLoginLog As New clsLoginLog

    Dim _clsVisitor As New clsVisitor

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        'lblIPAddress.Text = LocalIPAddress()
        If Not Page.IsPostBack Then
            Session.RemoveAll()

            Session("NOTIFYME") = ConfigurationManager.AppSettings("NotifyMe").ToString
            Session("SENDSMS") = _clsDB.Get_DB_Item("SELECT default_value FROM tbl_system_default WHERE default_desc = 'notify_sms'")

            lblTodayVisitor.Text = _clsVisitor.getVisitorCount
            lblTotalVisitor.Text = _clsVisitor.getVisitorCount("ALL")

        End If

    End Sub
    Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.ServerClick
        logIn()
    End Sub

    Private Sub saveLoginLog(ByVal _status As String)
        With _clsLoginLog
            .initialize()
            .userId = Session("UserId")
            .loginIp = GetIPAddress()
            .loginDatetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            .loginStatus = _status
            .saveLoginLog()
        End With
    End Sub

    Public Sub logIn()
        If _clsUser.validateUserLogon(txtUserId.Text, txtPassword.Value) = True Then

            With _clsUser
                .getUserInformation(txtUserId.Text)
                Session("UserId") = .userID
                Session("UserRoleId") = .userRoleID
                Session("UserName") = .userName
                'Session("UserFieldDistrict") = .fieldDistrict
            End With

            Session("UserCode") = DateTime.Now.ToString("MMddyyyymmhhss") & Left(Guid.NewGuid().ToString.Replace("-", ""), 7).ToUpper

            Try
                CType(Application("userList"), Dictionary(Of String, String())).Add(Session("UserCode"), {Session("UserId"), Session("UserName"), DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt"), GetIPAddress()})
            Catch ex As Exception
            End Try

            Session("MODULE") = "SENIOR CITIZEN"

            'If _clsUser.verifyDefaultPassword(txtPassword.Value) = True Then

            '    Response.Redirect("~/Secured/SystemAdministration/adUserChangePassword.aspx")
            'Else

            'End If

            Dim _clsCMS As New clsCMS
            Dim dtMenuHeader As New DataTable
            dtMenuHeader.Clear()
            dtMenuHeader = _clsCMS.browseSecureCMSMenuHeaderPermissionByModule(Session("UserId"), Session("UserRoleId"), Session("MODULE"))

            If dtMenuHeader.Rows.Count > 0 Then
                'If Session("SENDSMS") = "Y" Then
                '    smsForLoginVerification()
                'End If
                'MsgBox("Login Success")
                Dim dtHomePermission As DataTable
                dtHomePermission = _clsCMS.browseSecureCMSMenuHeaderPermissionHome(Session("UserId"), Session("UserRoleId"), Session("MODULE"))
                If dtHomePermission.Rows.Count > 0 Then
                    Response.Redirect("~/Secured/DashBoard.aspx")
                Else
                    Response.Redirect("~/Secured/Default.aspx")
                End If
            End If

        Else
            Session("UserId") = txtUserId.Text.Trim
            saveLoginLog("FAIL")
            'Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "popupscript", clsLibrary.fnShowMessage("Sorry, Invalid username or password."))

        End If
    End Sub

    Public Shared Function GetIPAddress() As String
        Dim context As System.Web.HttpContext = System.Web.HttpContext.Current
        Dim sIPAddress As String = context.Request.ServerVariables("HTTP_X_FORWARDED_FOR")
        If String.IsNullOrEmpty(sIPAddress) Then
            Return context.Request.ServerVariables("REMOTE_ADDR")
        Else
            Dim ipArray As String() = sIPAddress.Split(New [Char]() {","c})
            Return ipArray(0)
        End If
    End Function
End Class
