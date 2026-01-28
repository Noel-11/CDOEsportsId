<%@ Page Title="Change Password" Language="VB" AutoEventWireup="false" CodeFile="adUserChangePassword.aspx.vb" Inherits="Secured_SystemAdministration_adUserChangePassword" Theme="Skins" MasterPageFile="~/MasterPage/Admin.master" %>


<%@ Register Src="~/Include/wucConfirmBoxBS5.ascx" TagName="wucConfirmBox" TagPrefix="wucConfirmBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cpConTent" runat="Server">
    <div class="card">
        <asp:UpdatePanel ID="updatePanel2" runat="server">
            <ContentTemplate>
                <div class="card-header" style="text-align: center">
                    <asp:Label runat="server" ID="lblPageTitle" Text="Change Password" class="form-label" Style="font-size: 20px;"></asp:Label>
                </div>
                <div class="card-body" style="background-color: #f8f9fa;">

                    <div class="row">
                        <div class="col-md-12 mb-3">
                            <span class="input-group-addon">Current Password </span>
                            <asp:TextBox runat="server" ID="txtCurrentPassword" CssClass="form-control" Width="30%" data-toggle="tooltip" data-placement="top" title="Current Password" trigger="hover" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12 mb-3">
                            <span class="input-group-addon">New Password </span>
                            <asp:TextBox runat="server" ID="txtNewPassword" CssClass="form-control" Width="30%" data-toggle="tooltip" data-placement="top" title="New Password" trigger="hover" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12 mb-3">
                            <span class="input-group-addon">Re-type Password </span>
                            <asp:TextBox runat="server" ID="txtRetypePassword" CssClass="form-control" Width="30%" data-toggle="tooltip" data-placement="top" title="Re-type Password" trigger="hover" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>


                </div>
                <div class="panel-footer">
                    <asp:Button runat="server" ID="btnSave" class="btn btn-primary btn-lg" Text="Save" ValidationGroup="DOC" />
                    <asp:Button runat="server" ID="btnCancel" class="btn btn-danger btn-lg" Text="Cancel" CausesValidation="false" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    
    <asp:UpdatePanel ID="updatePanel1" runat="server">
        <ContentTemplate>
            <asp:HiddenField runat="server" ID="hfTransid"></asp:HiddenField>
            <wucConfirmBox:wucConfirmBox runat="server" ID="thisMsgBox" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


