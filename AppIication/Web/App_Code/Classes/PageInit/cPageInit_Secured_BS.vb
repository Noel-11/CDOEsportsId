Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Web.UI.WebControls

Public Class cPageInit_Secured_BS
    Inherits System.Web.UI.Page
    Dim _clsCMSPermission As New clsCMSPermission

    Dim _strScript As String

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Init

        If Session("UserId") = Nothing Then
            savePage()
            'If _strScript = "VerifySoloParent.aspx" Then
            '    Response.Redirect("~/Error404.aspx")
            'Else
            Response.Redirect("~/admin.aspx")
            'End If

        End If

        If Not Page.IsPostBack Then
            savePage()
            Session("_strScript") = _strScript
            ' MsgBox(_strScript)
        End If

    End Sub

    Protected Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.LoadComplete

        If Not Page.IsPostBack Then
            GetUserPermission()
        End If

    End Sub

    Protected Sub GetUserPermission()

        Dim _btnSave As Button = FindControl("btnSave")
        Dim _btnCancel As Button = FindControl("btnCancel")
        Dim _btnAdd As Button = FindControl("btnAdd")
        Dim _btnAddHtml As HtmlButton = FindControl("btnAddHtml")
        Dim _btnDelete As Button = FindControl("btnDelete")
        Dim _btnBack As Button = FindControl("btnBack")
        Dim _btnUpload As Button = FindControl("btnUpload")
        Dim _gvDocuments As GridView = FindControl("_gvDocuments")
        Dim _gv As GridView = FindControl("_gv")
        Dim _rblIsDiscounted As RadioButtonList = FindControl("rblIsDiscounted")
        Dim _divIsDiscounted As Control = FindControl("divIsDiscounted")
        Dim _txtPaymentLessAmount As TextBox = FindControl("txtPaymentLessAmount")

        Dim _bolControl As Boolean()
        _bolControl = _clsCMSPermission.getMenuPermission(Session("UserId"), Session("UserRoleId"), _strScript)

        'Access 
        If _bolControl(0) = False Then
            Response.Redirect("~/Secured/Default.aspx")
        End If

        ' Create
        If Not IsNothing(_btnAdd) Then
            _btnAdd.Visible = _bolControl(1)
        End If

        If Not IsNothing(_btnAddHtml) Then
            _btnAddHtml.Visible = _bolControl(1)
        End If

        'Add/Edit
        If Session("AE_STATUS") = "ADD" Then

            If Not IsNothing(_btnSave) Then
                _btnSave.Visible = _bolControl(1)
                If Not IsNothing(_btnCancel) Then
                    _btnCancel.Visible = _bolControl(1)
                End If
            End If

        ElseIf Session("AE_STATUS") = "EDIT" Then
            If Not IsNothing(_btnSave) Then
                _btnSave.Visible = _bolControl(2)
                If Not IsNothing(_btnCancel) Then
                    _btnCancel.Visible = _bolControl(2)
                End If
            End If
        End If

        ' Delete
        If Not IsNothing(_btnDelete) Then
            _btnDelete.Visible = _bolControl(3)
        End If

        'Upload
        If Not IsNothing(_btnUpload) Then
            If Session("AE_STATUS") = "ADD" Then
                _btnUpload.Visible = _bolControl(1)
            ElseIf Session("AE_STATUS") = "EDIT" Then
                _btnUpload.Visible = _bolControl(2)
            End If

        End If

        'GVDelete
        'If Not IsNothing(_gvDocuments) Then
        '    _gvDocuments.Columns(3).Visible = _bolControl(3)
        'End If

        Dim _btnTakePhoto As Button = FindControl("btnTakePhoto")
        Dim _btnUploadPhoto As Button = FindControl("btnUploadPhoto")

        If Not IsNothing(_btnTakePhoto) Then
            If Session("AE_STATUS") = "ADD" Then
                _btnTakePhoto.Visible = _bolControl(1)
            ElseIf Session("AE_STATUS") = "EDIT" Then
                _btnTakePhoto.Visible = _bolControl(2)
            End If
        End If

        If Not IsNothing(_btnUploadPhoto) Then
            If Session("AE_STATUS") = "ADD" Then
                _btnUploadPhoto.Visible = _bolControl(1)
            ElseIf Session("AE_STATUS") = "EDIT" Then
                _btnUploadPhoto.Visible = _bolControl(2)
            End If

        End If


        'Discount

        If Not IsNothing(_rblIsDiscounted) Then
            If _rblIsDiscounted.Enabled = True Then
                If Not IsNothing(_divIsDiscounted) Then
                    _divIsDiscounted.Visible = _bolControl(4)
                    If _bolControl(4) = True Then
                        _txtPaymentLessAmount.ReadOnly = False
                    Else
                        _txtPaymentLessAmount.ReadOnly = True
                    End If
                End If
            End If
        End If

    End Sub

    Protected Sub savePage()
        ' save in apageguide
        Dim _dtPage As New DataTable
        Dim _strPageName As String, _strQuery As String, _strPage As String()
        _strQuery = Request.ServerVariables("QUERY_STRING").ToString()
        _strScript = Request.ServerVariables("SCRIPT_NAME").ToString()
        _strPage = _strScript.Split("/")
        _strScript = _strPage(_strPage.Length - 1)
        _strPageName = _strScript.Remove(_strScript.ToString().Length - 5, 5)

        '_dtPage = clsAdmin.fnapageguide_getpage(LCase(_strScript))
        'If _dtPage.Rows.Count <= 0 Then
        '    clsAdmin.fnapageguide_Save(0, Trim(_strPageName), "", LCase(Trim(_strScript)), 1, 1, Session("UserId"))
        'End If

    End Sub

    Public Function redirectAlert(ByVal url As String, ByVal msg As String) As String

        Dim strMsg As String = msg
        If msg = "" Then
            strMsg = "Transaction has been successfully saved."
        End If

        Dim strScript As String = "<script language=JavaScript>"
        strScript += "alert('" & strMsg & "');"
        strScript += "window.location='" & url & "'"
        strScript += "</script>"

        Return strScript

    End Function

    Public Function setCurrentPage(ByVal _intPageIndex As Integer, ByVal _dt As DataTable, Optional _isPage As Boolean = True) As String
        Dim _strReturn As String

        Dim _intTotalRec As Integer, _intTotalPage As Integer

        _intTotalRec = 0
        If _dt.Rows.Count > 0 Then
            _intTotalRec = _dt.Rows.Count
        End If

        If _intTotalRec < 11 Then
            _intTotalPage = 1
        Else
            _intTotalPage = Math.Truncate((_intTotalRec / 15))
            If (_intTotalRec Mod 15) <> 0 Then
                _intTotalPage += 1
            End If
        End If

        If _intPageIndex < 1 Then
            _intPageIndex = 1
        End If

        If _intTotalPage < 1 Then
            _intTotalPage = 1
        End If

        If _isPage = False Then
            _strReturn = "Total Records: " & _intTotalRec.ToString
        Else
            _strReturn = " Page " & _intPageIndex.ToString() & " of " & _intTotalPage.ToString() & ", Total Records: " & _intTotalRec.ToString
        End If


        Return _strReturn

    End Function
End Class
