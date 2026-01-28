<%@ Page Title="Menu" Language="VB" AutoEventWireup="false" CodeFile="cmsMenuAdd.aspx.vb" Inherits="Secured_cmsMenuAdd" Theme="Skins" MasterPageFile="~/MasterPage/Admin.master" %>


<%@ Register Src="~/Include/wucConfirmBoxBS5.ascx" TagName="wucConfirmBox" TagPrefix="wucConfirmBox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpConTent" runat="Server">
    <div class="card">
        <asp:UpdatePanel ID="updatePanel2" runat="server">
            <ContentTemplate>
                <div class="card-header" style="text-align: center">
                    <button runat="server" onserverclick="btnHome_Click" type="button" id="btnHome" class="btn btn-primary" causesvalidation="false">BACK</button>
                    <asp:Label runat="server" ID="Label2" Text="Menu" class="form-label" Style="font-size: 20px;"></asp:Label>
                </div>

                <div class="card-body">
                    <div class="row">
                        <div class="col-md-12 mb-3">
                            <span class="input-group-addon">Menu : </span>
                            <asp:TextBox runat="server" ID="txtmenu" CssClass="form-control" ToolTip="Text"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtmenu" SetFocusOnError="true" Font-Bold="true" Font-Size="13pt" Display="Dynamic" Text="Menu is Required!" ValidationGroup="DOC" />
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12 mb-3">
                            <span class="input-group-addon">Page URL : </span>
                            <asp:TextBox runat="server" ID="txtpageurl" CssClass="form-control" ToolTip="Text"></asp:TextBox>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12 mb-3">
                            <span class="input-group-addon">Sort Order : </span>
                            <asp:TextBox runat="server" ID="txtSortOrder" TextMode="Number" CssClass="form-control" ToolTip="Text"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" InitialValue="" ControlToValidate="txtmenu" SetFocusOnError="true" Font-Bold="true" Font-Size="13pt" Display="Dynamic" Text="Sort Order is Required!" ValidationGroup="DOC" />
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12 mb-3">
                            <span class="input-group-addon">Is Public? </span>
                            <asp:RadioButtonList runat="server" ID="rdolispublic" CssClass="form-control " RepeatDirection="Horizontal">
                                <asp:ListItem Text="&nbsp;Yes&nbsp;&nbsp;&nbsp;" Value="Y" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="&nbsp;No" Value="N"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-12 mb-3">
                            <span class="input-group-addon">Is Active? </span>
                            <asp:RadioButtonList runat="server" ID="rdolisactive" CssClass="form-control " RepeatDirection="Horizontal">
                                <asp:ListItem Text="&nbsp;Yes&nbsp;&nbsp;&nbsp;" Value="Y" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="&nbsp;No" Value="N"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>


                </div>

                <div class="modal-footer">
                    <asp:Button runat="server" ID="btnSave" CssClass="btn btn-primary" Text="Save" ValidationGroup="DOC" />
                    <asp:Button runat="server" ID="btnCancel" CssClass="btn btn-danger" Text="Cancel" CausesValidation="false" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>


    <asp:UpdatePanel ID="updatePanel1" runat="server">
        <ContentTemplate>
            <wucConfirmBox:wucConfirmBox runat="server" ID="thisMsgBox" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>




