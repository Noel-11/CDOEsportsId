<%@ Page Title="User Entry" Language="VB" AutoEventWireup="false" CodeFile="adminUserEntryAdd.aspx.vb"
    Inherits="Secured_UserAdmin_adminUserEntryAdd" MasterPageFile="~/MasterPage/Admin.master" Theme="Skins" %>


<%@ Register Src="~/Include/wucConfirmBoxBS5.ascx" TagName="wucConfirmBox" TagPrefix="wucConfirmBox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpConTent" runat="Server">

    <div class="container-fluid">
        <div class="card">
            <asp:UpdatePanel ID="updatePanel2" runat="server">
                <ContentTemplate>
                    <div class="card-header">
                        <div class="row">
                            <div class="col-md-4">
                                <button runat="server" id="btnHome" class="btn btn-primary" style="margin-bottom: 7px;"><i class="bi bi-chevron-double-left "></i>&nbsp;Back</button>
                            </div>
                            <div class="col-md-4" align="center">
                                <h2>USER ENTRY DETAILS</h2>
                            </div>

                            <div class="col-md-4">
                            </div>
                        </div>
                    </div>
                    <div class="card-body">

                        <div class="row mt-1 mb-1">
                            <div class="col-md-4">

                                <div class="input-group">
                                    <span class="input-group-text border-secondary">User ID </span>
                                    <asp:TextBox runat="server" ID="txtUserId" CssClass="form-control border-secondary"></asp:TextBox>

                                </div>
                                <asp:RequiredFieldValidator ID="rfvUserId" runat="server" ControlToValidate="txtUserId" SetFocusOnError="true" Font-Bold="true" Font-Italic="true" Font-Size="10pt" Display="Dynamic" InitialValue-="" Text="UserID is Required!" ValidationGroup="DOC" />
                            </div>

                            <div class="col-md-8">
                                <div class="input-group">
                                    <span class="input-group-text border-secondary">User Name</span>
                                    <asp:TextBox runat="server" ID="txtUserName" CssClass="form-control border-secondary"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="txtUserName" SetFocusOnError="true" Font-Bold="true" Font-Italic="true" Font-Size="10pt" Display="Dynamic" Text="UserName is Required!" ValidationGroup="DOC" />
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-md-6">
                                <div class="input-group">
                                    <span class="input-group-text border-secondary">User Role</span>
                                    <asp:DropDownList runat="server" ID="ddlUserRoleid" CssClass="form-select border-secondary"></asp:DropDownList>
                                </div>
                                <asp:RequiredFieldValidator InitialValue="0" ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddluserroleid" SetFocusOnError="true" Font-Bold="true" Font-Italic="true" Font-Size="10pt" Display="Dynamic" Text="User Role is Required!" ValidationGroup="DOC" />
                            </div>

                            <div class="col-md-6">
                                <div class="input-group">
                                    <span class="input-group-text border-secondary">Is Active?</span>
                                    <asp:RadioButtonList runat="server" ID="rblIsActive" CssClass="form-control border-secondary" RepeatDirection="Horizontal">
                                        <asp:ListItem Text="&nbsp;Yes&nbsp;&nbsp;&nbsp;" Value="Y" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="&nbsp;No" Value="N"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>

                        </div>

                        <div class="card-footer">
                            <asp:Button runat="server" ID="btnSave" CssClass="btn btn-primary" Text="Save" ValidationGroup="DOC" />
                            <asp:Button runat="server" ID="btnCancel" CssClass="btn btn-danger" Text="Cancel" CausesValidation="false" />
                            <asp:Button runat="server" ID="btnresetpassword" CssClass="btn btn-success" Text="Reset Password" CausesValidation="false" />
                        </div>


                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>


    </div>

    <asp:UpdatePanel ID="updatePanel1" runat="server">
        <ContentTemplate>
            <asp:HiddenField runat="server" ID="hfUserID"></asp:HiddenField>
            <asp:HiddenField runat="server" ID="hfTransId"></asp:HiddenField>
            <asp:HiddenField runat="server" ID="hfOldUserID"></asp:HiddenField>
            <wucConfirmBox:wucConfirmBox runat="server" ID="thisMsgBox" />

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

