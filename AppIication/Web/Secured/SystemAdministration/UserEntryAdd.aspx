<%@ Page Title="User Entry" Language="VB" AutoEventWireup="false" CodeFile="UserEntryAdd.aspx.vb" Inherits="Secured_SystemAdministration_UserEntryAdd"
    Theme="Skins" MasterPageFile="~/MasterPage/Admin.master" %>


<%@ Register Src="~/Include/wucConfirmBoxBS5.ascx" TagName="wucConfirmBox" TagPrefix="wucConfirmBox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpConTent" runat="Server">

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

                <div class="card-body" style="background-color: #f8f9fa;">

                    <div class="row">
                        <div class="col-md-12 mb-3">
                            <span class="input-group-addon" style="font-weight: bold">User ID </span>
                            <asp:TextBox runat="server" ID="txtUserId" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtUserId" SetFocusOnError="true" Font-Bold="true" Font-Size="13pt" Display="Dynamic" Text="User Id is required" ValidationGroup="DOC" />
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12 mb-3">
                            <span class="input-group-addon" style="font-weight: bold">User Name </span>
                            <asp:TextBox runat="server" ID="txtUserName" CssClass="form-control" Width="100%" data-toggle="tooltip" data-placement="top" title="User Name" trigger="hover"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName" SetFocusOnError="true" Font-Bold="true" Font-Size="13pt" Display="Dynamic" Text="User Name is required" ValidationGroup="DOC" />
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12 mb-3">
                            <span class="input-group-addon" style="font-weight: bold">User Role</span>
                            <asp:DropDownList runat="server" ID="ddlUserRole" CssClass="form-select"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12 mb-3">
                            <span class="input-group-addon" style="font-weight: bold">Active </span>
                            <asp:RadioButtonList runat="server" ID="rblIsActive" CssClass="form-control " RepeatDirection="Horizontal">
                                <asp:ListItem Text="&nbsp;Yes&nbsp;&nbsp;" Value="Y" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="&nbsp;&nbsp;No" Value="N"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>

                </div>

                <div class="card-footer">
                    <asp:Button runat="server" ID="btnSave" class="btn btn-primary btn-lg" Text="Save" ValidationGroup="DOC" />
                    <asp:Button runat="server" ID="btnCancel" class="btn btn-danger btn-lg" Text="Cancel" CausesValidation="false" />
                    <asp:Button runat="server" ID="btnResetPassword" class="btn btn-success btn-lg" Text="Reset Password" CausesValidation="false" />
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>



    <asp:UpdatePanel ID="updatePanel1" runat="server">
        <ContentTemplate>
            <asp:HiddenField runat="server" ID="hfUserID"></asp:HiddenField>
            <asp:HiddenField runat="server" ID="hfOldUserID"></asp:HiddenField>
            <wucConfirmBox:wucConfirmBox runat="server" ID="thisMsgBox" />

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
















