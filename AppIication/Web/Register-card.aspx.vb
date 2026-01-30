Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Data


Partial Public Class RegisterCard
    Inherits System.Web.UI.Page

    Dim _clsDB As New clsDatabase

    Private registeredUsersDB As New clsRegisteredUsers()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            ' Load barangays into dropdown
            LoadBarangays()
        End If
    End Sub

    ''' <summary>
    ''' Load barangays from database into dropdown
    ''' </summary>
    Private Sub LoadBarangays()
        Try
            Dim dt As DataTable = registeredUsersDB.GetAllBarangays()

            ddlBarangay.DataSource = dt
            ddlBarangay.DataTextField = "barangay"
            ddlBarangay.DataValueField = "id"
            ddlBarangay.DataBind()
            ddlBarangay.Items.Insert(0, New ListItem("-- Select Barangay --", ""))

            ' Explicitly set selected index to 0 (the placeholder)
            ddlBarangay.SelectedIndex = 0

        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "error",
                "alert('Error loading barangays: " & ex.Message.Replace("'", "\'") & "');", True)
        End Try
    End Sub

    ''' <summary>
    ''' Show preview panel (NO database save yet)
    ''' </summary>
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As EventArgs)
        If Page.IsValid Then
            ' Store form data in ViewState (NO database insert yet)
            ViewState("fullName") = txtFullName.Text.Trim()
            ViewState("sex") = ddlSex.SelectedValue
            ViewState("age") = txtAge.Text
            ViewState("birthday") = txtBirthday.Text
            ViewState("contactNumber") = txtContactNumber.Text.Trim()
            ViewState("barangayId") = ddlBarangay.SelectedValue
            ViewState("barangayName") = ddlBarangay.SelectedItem.Text
            ViewState("modeOfValidation") = txtModeOfValidation.Text.Trim()
            ViewState("isLicensedPlayer") = ddlLicensedPlayer.SelectedValue
            ViewState("referralChannel") = txtReferralChannel.Text.Trim()

            ' Populate preview labels
            PopulatePreviewLabels()

            ' Show preview panel
            pnlForm.Visible = False
            pnlPreview.Visible = True
        End If
    End Sub

    ''' <summary>
    ''' Save to database and show print panel
    ''' </summary>
    Protected Sub btnConfirmSave_Click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            ' Get data from ViewState
            Dim fullName As String = ViewState("fullName").ToString()
            Dim sex As String = ViewState("sex").ToString()
            Dim age As Integer = Integer.Parse(ViewState("age").ToString())
            Dim birthday As DateTime = DateTime.Parse(ViewState("birthday").ToString())
            Dim contactNumber As String = ViewState("contactNumber").ToString()
            Dim barangayId As String = ViewState("barangayId").ToString()
            Dim modeOfValidation As String = ViewState("modeOfValidation").ToString()
            Dim isLicensedPlayer As Boolean = Boolean.Parse(ViewState("isLicensedPlayer").ToString())
            Dim referralChannel As String = ViewState("referralChannel").ToString()

            ' NOW save to database
            Dim userId As Integer = registeredUsersDB.InsertRegisteredUser(
                fullName, sex, age, birthday, contactNumber, barangayId,
                modeOfValidation, isLicensedPlayer, referralChannel)

            If userId > 0 Then
                ' Get full data with barangay details
                Dim userRow As DataRow = registeredUsersDB.GetUserWithBarangay(userId)

                If userRow IsNot Nothing Then
                    ' Store user ID for reference
                    ViewState("lastSavedUserId") = userId

                    ' Populate final print labels
                    PopulatePrintLabels(userRow)

                    ' Show print panel
                    pnlPreview.Visible = False
                    pnlDetails.Visible = True
                End If
            End If

        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "alert",
                "alert('Error saving data:\n" & ex.Message.Replace("'", "\'").Replace(vbCrLf, "\n") & "');", True)
        End Try
    End Sub

    ''' <summary>
    ''' Go back to form from preview (no DB save)
    ''' </summary>
    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Go back to form (data still in controls from ViewState postback)
        pnlPreview.Visible = False
        pnlForm.Visible = True
    End Sub

    ''' <summary>
    ''' Clear all form fields and reset
    ''' </summary>
    Protected Sub btnClearForm_Click(ByVal sender As Object, ByVal e As EventArgs)
        '' Clear all form fields
        'txtFullName.Text = ""
        'ddlSex.SelectedIndex = 0
        'txtAge.Text = ""
        'txtBirthday.Text = ""
        'txtContactNumber.Text = ""
        'ddlBarangay.SelectedIndex = 0
        'txtModeOfValidation.Text = ""
        'ddlLicensedPlayer.SelectedIndex = 0
        'txtReferralChannel.Text = ""

        '' Clear ViewState
        'ViewState.Clear()

        '' Reload barangays (since ViewState was cleared)
        'LoadBarangays()

        '' Show form panel
        'pnlPreview.Visible = False
        'pnlDetails.Visible = False
        'pnlForm.Visible = True

        Response.Redirect("Register-card.aspx")
    End Sub

    ''' <summary>
    ''' Populate preview panel labels
    ''' </summary>
    Private Sub PopulatePreviewLabels()
        lblPreviewFullName.Text = ViewState("fullName").ToString()
        lblPreviewSex.Text = ViewState("sex").ToString()
        lblPreviewAge.Text = ViewState("age").ToString()
        lblPreviewBirthday.Text = DateTime.Parse(ViewState("birthday").ToString()).ToString("MMMM dd, yyyy")
        lblPreviewContactNumber.Text = If(String.IsNullOrEmpty(ViewState("contactNumber").ToString()), "N/A", ViewState("contactNumber").ToString())
        lblPreviewBarangay.Text = ViewState("barangayName").ToString()
        lblPreviewModeOfValidation.Text = If(String.IsNullOrEmpty(ViewState("modeOfValidation").ToString()), "N/A", ViewState("modeOfValidation").ToString())
        lblPreviewLicensedPlayer.Text = If(ViewState("isLicensedPlayer").ToString() = "True", "Yes", "No")
        lblPreviewReferralChannel.Text = If(String.IsNullOrEmpty(ViewState("referralChannel").ToString()), "N/A", ViewState("referralChannel").ToString())
    End Sub

    ''' <summary>
    ''' Populate final print panel labels with database data
    ''' </summary>
    Private Sub PopulatePrintLabels(userRow As DataRow)
        lblFullName.Text = userRow("full_name").ToString()
        lblSex.Text = userRow("sex").ToString()
        lblAge.Text = userRow("age").ToString()
        lblBirthday.Text = DateTime.Parse(userRow("birthday").ToString()).ToString("MMMM dd, yyyy")
        lblContactNumber.Text = If(String.IsNullOrEmpty(userRow("contact_number").ToString()), "N/A", userRow("contact_number").ToString())
        lblBarangay.Text = userRow("barangay").ToString()
        lblBarangayCaptain.Text = userRow("barangay_captain").ToString()
        lblModeOfValidation.Text = If(String.IsNullOrEmpty(userRow("mode_of_validation").ToString()), "N/A", userRow("mode_of_validation").ToString())
        lblLicensedPlayer.Text = If(CBool(userRow("is_licensed_player")), "Yes", "No")
        lblReferralChannel.Text = If(String.IsNullOrEmpty(userRow("referral_channel").ToString()), "N/A", userRow("referral_channel").ToString())
    End Sub



End Class