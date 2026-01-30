<%@ Page Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Register-card.aspx.vb" Inherits="RegisterCard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <title>Register Card</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-10 col-lg-8">
                
                <!-- Registration Form Panel -->
                <asp:Panel ID="pnlForm" runat="server" CssClass="card shadow-sm">
                    <div class="card-body p-4">
                        <h4 class="card-title text-center mb-4">E-Sports Player Registration</h4>
                        
                        <!-- Full Name -->
                        <div class="mb-3">
                            <label class="form-label">Complete / Real Name <span class="text-danger">*</span></label>
                            <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control" placeholder="Enter your complete name" />
                            <asp:RequiredFieldValidator ID="rfvFullName" runat="server" ControlToValidate="txtFullName" 
                                ErrorMessage="Full name is required" CssClass="text-danger small" Display="Dynamic" />
                        </div>

                        <!-- Sex and Age Row -->
                        <div class="row mb-3">
                            <div class="col-md-6">
                                <label class="form-label">Sex <span class="text-danger">*</span></label>
                                <asp:DropDownList ID="ddlSex" runat="server" CssClass="form-select">
                                    <asp:ListItem Value="" Text="-- Select Sex --" />
                                    <asp:ListItem Value="Male" Text="Male" />
                                    <asp:ListItem Value="Female" Text="Female" />
                                    <asp:ListItem Value="Other" Text="Other" />
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvSex" runat="server" ControlToValidate="ddlSex" 
                                    InitialValue="" ErrorMessage="Sex is required" CssClass="text-danger small" Display="Dynamic" />
                            </div>
                            <div class="col-md-6">
                                <label class="form-label">Age <span class="text-danger">*</span></label>
                                <asp:TextBox ID="txtAge" runat="server" CssClass="form-control" TextMode="Number" placeholder="Enter age" />
                                <asp:RequiredFieldValidator ID="rfvAge" runat="server" ControlToValidate="txtAge" 
                                    ErrorMessage="Age is required" CssClass="text-danger small" Display="Dynamic" />
                                <asp:RangeValidator ID="rvAge" runat="server" ControlToValidate="txtAge" 
                                    MinimumValue="1" MaximumValue="150" Type="Integer"
                                    ErrorMessage="Age must be between 1 and 150" CssClass="text-danger small" Display="Dynamic" />
                            </div>
                        </div>

                        <!-- Birthday -->
                        <div class="mb-3">
                            <label class="form-label">Birthday <span class="text-danger">*</span></label>
                            <asp:TextBox ID="txtBirthday" runat="server" CssClass="form-control" TextMode="Date" />
                            <asp:RequiredFieldValidator ID="rfvBirthday" runat="server" ControlToValidate="txtBirthday" 
                                ErrorMessage="Birthday is required" CssClass="text-danger small" Display="Dynamic" />
                        </div>

                        <!-- Contact Number -->
                        <div class="mb-3">
                            <label class="form-label">Contact Number</label>
                            <asp:TextBox ID="txtContactNumber" runat="server" CssClass="form-control" placeholder="e.g., 09123456789" />
                        </div>

                        <!-- Barangay Residency -->
                        <div class="mb-3">
                            <label class="form-label">Barangay Residency <span class="text-danger">*</span></label>
                            <asp:DropDownList ID="ddlBarangay" runat="server" CssClass="form-select">
                                <asp:ListItem Value="" Text="-- Select Barangay --" />
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvBarangay" runat="server" ControlToValidate="ddlBarangay" 
                                InitialValue="" ErrorMessage="Barangay is required" CssClass="text-danger small" Display="Dynamic" />
                        </div>

                        <!-- Mode of Validation -->
                        <div class="mb-3">
                            <label class="form-label">Mode of Validation</label>
                            <asp:TextBox ID="txtModeOfValidation" runat="server" CssClass="form-control" placeholder="e.g., ID Verification, Document Submission" />
                        </div>

                        <!-- Licensed Player -->
                        <div class="mb-3">
                            <label class="form-label">I am a Licensed Esports Player/Athlete <span class="text-danger">*</span></label>
                            <asp:DropDownList ID="ddlLicensedPlayer" runat="server" CssClass="form-select">
                                <asp:ListItem Value="" Text="-- Select --" />
                                <asp:ListItem Value="True" Text="Yes" />
                                <asp:ListItem Value="False" Text="No" />
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvLicensed" runat="server" ControlToValidate="ddlLicensedPlayer" 
                                InitialValue="" ErrorMessage="Please select an option" CssClass="text-danger small" Display="Dynamic" />
                        </div>

                        <!-- Referral Channel -->
                        <div class="mb-3">
                            <label class="form-label">Referral / Channel</label>
                            <asp:TextBox ID="txtReferralChannel" runat="server" CssClass="form-control" placeholder="e.g., Facebook, Friend, Event" />
                        </div>

                        <div class="d-grid gap-2 mt-4">
                            <asp:Button ID="btnSubmit" runat="server" Text="Preview Registration" CssClass="btn btn-primary btn-lg" OnClick="btnSubmit_Click" />
                            <asp:Button ID="btnClearFormInput" runat="server" Text="Clear All Fields" CssClass="btn btn-outline-secondary" OnClick="btnClearForm_Click" CausesValidation="false" />
                        </div>
                    </div>
                </asp:Panel>

                <!-- Preview Panel (NEW) -->
                <asp:Panel ID="pnlPreview" runat="server" Visible="false" CssClass="card shadow-sm">
                    <div class="card-body p-4">
                        <div class="alert alert-info mb-4">
                            <i class="bi bi-info-circle"></i> <strong>Please review your information before saving.</strong><br/>
                            <small>Click "Edit" to make changes or "Confirm & Save" to save to database.</small>
                        </div>

                        <h4 class="card-title text-center mb-4">Preview Your Registration</h4>
                        
                        <div class="mb-2 row">
                            <label class="col-sm-5 fw-bold">Full Name:</label>
                            <div class="col-sm-7">
                                <asp:Label ID="lblPreviewFullName" runat="server" />
                            </div>
                        </div>

                        <div class="mb-2 row">
                            <label class="col-sm-5 fw-bold">Sex:</label>
                            <div class="col-sm-7">
                                <asp:Label ID="lblPreviewSex" runat="server" />
                            </div>
                        </div>

                        <div class="mb-2 row">
                            <label class="col-sm-5 fw-bold">Age:</label>
                            <div class="col-sm-7">
                                <asp:Label ID="lblPreviewAge" runat="server" />
                            </div>
                        </div>

                        <div class="mb-2 row">
                            <label class="col-sm-5 fw-bold">Birthday:</label>
                            <div class="col-sm-7">
                                <asp:Label ID="lblPreviewBirthday" runat="server" />
                            </div>
                        </div>

                        <div class="mb-2 row">
                            <label class="col-sm-5 fw-bold">Contact Number:</label>
                            <div class="col-sm-7">
                                <asp:Label ID="lblPreviewContactNumber" runat="server" />
                            </div>
                        </div>
                        
                        <div class="mb-2 row">
                            <label class="col-sm-5 fw-bold">Barangay:</label>
                            <div class="col-sm-7">
                                <asp:Label ID="lblPreviewBarangay" runat="server" />
                            </div>
                        </div>

                        <div class="mb-2 row">
                            <label class="col-sm-5 fw-bold">Mode of Validation:</label>
                            <div class="col-sm-7">
                                <asp:Label ID="lblPreviewModeOfValidation" runat="server" />
                            </div>
                        </div>

                        <div class="mb-2 row">
                            <label class="col-sm-5 fw-bold">Licensed Player:</label>
                            <div class="col-sm-7">
                                <asp:Label ID="lblPreviewLicensedPlayer" runat="server" />
                            </div>
                        </div>

                        <div class="mb-2 row">
                            <label class="col-sm-5 fw-bold">Referral Channel:</label>
                            <div class="col-sm-7">
                                <asp:Label ID="lblPreviewReferralChannel" runat="server" />
                            </div>
                        </div>

                        <div class="d-grid gap-2 mt-4">
                            <asp:Button ID="btnConfirmSave" runat="server" Text="✓ Confirm & Save to Database" CssClass="btn btn-success btn-lg" OnClick="btnConfirmSave_Click" CausesValidation="false" />
                            <asp:Button ID="btnEdit" runat="server" Text="✎ Edit Information" CssClass="btn btn-outline-primary" OnClick="btnEdit_Click" CausesValidation="false" />
                            <asp:Button ID="btnClearFromPreview" runat="server" Text="Clear Form" CssClass="btn btn-outline-danger" OnClick="btnClearForm_Click" CausesValidation="false" />
                        </div>
                    </div>
                </asp:Panel>

                <!-- Print Summary Panel -->
                <asp:Panel ID="pnlDetails" runat="server" Visible="false" CssClass="card shadow-sm">
                    <div class="card-body p-4">
                        <div class="alert alert-success mb-4">
                            <i class="bi bi-check-circle"></i> <strong>Registration saved successfully!</strong>
                        </div>

                        <h4 class="card-title text-center mb-4">Registration Summary</h4>
                        
                        <div class="mb-2 row">
                            <label class="col-sm-5 fw-bold">Full Name:</label>
                            <div class="col-sm-7">
                                <asp:Label ID="lblFullName" runat="server" />
                            </div>
                        </div>

                        <div class="mb-2 row">
                            <label class="col-sm-5 fw-bold">Sex:</label>
                            <div class="col-sm-7">
                                <asp:Label ID="lblSex" runat="server" />
                            </div>
                        </div>

                        <div class="mb-2 row">
                            <label class="col-sm-5 fw-bold">Age:</label>
                            <div class="col-sm-7">
                                <asp:Label ID="lblAge" runat="server" />
                            </div>
                        </div>

                        <div class="mb-2 row">
                            <label class="col-sm-5 fw-bold">Birthday:</label>
                            <div class="col-sm-7">
                                <asp:Label ID="lblBirthday" runat="server" />
                            </div>
                        </div>

                        <div class="mb-2 row">
                            <label class="col-sm-5 fw-bold">Contact Number:</label>
                            <div class="col-sm-7">
                                <asp:Label ID="lblContactNumber" runat="server" />
                            </div>
                        </div>
                        
                        <div class="mb-2 row">
                            <label class="col-sm-5 fw-bold">Barangay:</label>
                            <div class="col-sm-7">
                                <asp:Label ID="lblBarangay" runat="server" />
                            </div>
                        </div>

                        <div class="mb-2 row">
                            <label class="col-sm-5 fw-bold">Barangay Captain:</label>
                            <div class="col-sm-7">
                                <asp:Label ID="lblBarangayCaptain" runat="server" />
                            </div>
                        </div>

                        <div class="mb-2 row">
                            <label class="col-sm-5 fw-bold">Mode of Validation:</label>
                            <div class="col-sm-7">
                                <asp:Label ID="lblModeOfValidation" runat="server" />
                            </div>
                        </div>

                        <div class="mb-2 row">
                            <label class="col-sm-5 fw-bold">Licensed Player:</label>
                            <div class="col-sm-7">
                                <asp:Label ID="lblLicensedPlayer" runat="server" />
                            </div>
                        </div>

                        <div class="mb-2 row">
                            <label class="col-sm-5 fw-bold">Referral Channel:</label>
                            <div class="col-sm-7">
                                <asp:Label ID="lblReferralChannel" runat="server" />
                            </div>
                        </div>

                        <div class="d-grid gap-2 mt-4 d-print-none">
                            <button type="button" class="btn btn-success btn-lg" onclick="window.print()">
                                <i class="bi bi-printer"></i> Print Card
                            </button>
                            <asp:Button ID="btnNewRegistration" runat="server" Text="New Registration" CssClass="btn btn-primary" OnClick="btnClearForm_Click" OnClientClick="clearReloadWarning(); return true;" CausesValidation="false" />
                        </div>
                    </div>
                </asp:Panel>

            </div>
        </div>
    </div>

    <script type="text/javascript">
    // Track if print panel is visible (server-side value)
    var isPrintPanelVisible = <%= If(pnlDetails.Visible, "true", "false") %>;

    // Prevent navigation/reload with warning dialog
    window.addEventListener('beforeunload', function (e) {
        if (isPrintPanelVisible) {
            e.preventDefault();
            e.returnValue = 'Registration saved. Please use "New Registration" button to continue.';
            return 'Registration saved. Please use "New Registration" button to continue.';
        }
    });

    // Block F5 and Ctrl+R keyboard shortcuts
    document.addEventListener('keydown', function(e) {
        if (isPrintPanelVisible) {
            // F5 key
            if (e.keyCode === 116) {
                e.preventDefault();
                alert('⚠️ Reload is disabled.\n\nPlease use the "New Registration" button to start a new registration.');
                return false;
            }
            
            // Ctrl+R (Windows/Linux) or Cmd+R (Mac)
            if ((e.ctrlKey || e.metaKey) && e.keyCode === 82) {
                e.preventDefault();
                alert('⚠️ Reload is disabled.\n\nPlease use the "New Registration" button to start a new registration.');
                return false;
            }

            // Optional: Also block Ctrl+F5 (hard reload)
            if (e.ctrlKey && e.keyCode === 116) {
                e.preventDefault();
                alert('⚠️ Reload is disabled.\n\nPlease use the "New Registration" button to start a new registration.');
                return false;
            }
        }
    });

    // Disable reload warning when user clicks "New Registration"
    function clearReloadWarning() {
        isPrintPanelVisible = false;
    }

    // Optional: Show message when page loads with print panel visible
    window.addEventListener('load', function() {
        if (isPrintPanelVisible) {
            console.log('Print panel is active. Reload shortcuts are disabled.');
        }
    });
    </script>
</asp:Content>