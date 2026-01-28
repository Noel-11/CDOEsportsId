<%@ Page Language="VB" AutoEventWireup="false" CodeFile="adminUserPermissionAdd.aspx.vb" Inherits="Secured_UserAdmin_adminUserPermissionAdd"
    MasterPageFile="~/MasterPage/Admin.master" Theme="Skins" %>

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
                        <h2>USER PERMISSION DETAILS</h2>
                    </div>

                    <div class="col-md-4">
                    </div>
                </div>

            </div>

            <div class="card-body">

                <div class="row mt-1 mb-1">
                    <div class="col-md-12">
                        <div class="input-group">
                            <span class="input-group-text border-secondary">User</span>
                            <asp:TextBox runat="server" ID="txtUserID" ReadOnly="true" CssClass="form-control border-secondary" data-toggle="tooltip" data-placement="top" title="User Details" trigger="hover"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <asp:GridView runat="server" ID="_gv" HeaderStyle-Font-Size="11px" CssClass="gridviewGray" PageSize="15"
                    PagerStyle-CssClass="pgr" AutoGenerateColumns="false" AllowSorting="true"
                    GridLines="None" Font-Names="Arial" Font-Size="14px" ForeColor="#000000" AllowPaging="false">
                    <Columns>

                        <asp:BoundField DataField="menu_type" HeaderText="" />
                        <asp:BoundField DataField="menu_id" HeaderText="" />
                        <asp:BoundField DataField="page_url" HeaderText="" />
                        <asp:BoundField DataField="menu_name" HeaderText="Module/Forms" />
                        <asp:TemplateField HeaderText="Access" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="8%">
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="chkAccess" Checked='<%# Bind("can_access") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Create" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="8%">
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="chkCreate" Checked='<%# Bind("can_create") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Update" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="8%">
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="chkUpdate" Checked='<%# Bind("can_update") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Discount" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="8%" Visible="false">
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="chkReport" Checked='<%# Bind("can_report")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                    
                    </Columns>
                </asp:GridView>
            </div>
            <div class="card-footer">

                <asp:Button runat="server" ID="btnSave" class="btn btn-primary btn-lg" Text="Save" ValidationGroup="DOC" />
                <asp:Button runat="server" ID="btnCancel" class="btn btn-danger btn-lg" Text="Cancel" CausesValidation="false" />

            </div>
            </ContentTemplate></asp:UpdatePanel>
        </div>
        <%--DOCUMENT ENTRY END --%>
    </div>

    <asp:UpdatePanel ID="updatePanel1" runat="server">
        <ContentTemplate>
            <asp:HiddenField runat="server" ID="hfTransid"></asp:HiddenField>
            <asp:HiddenField runat="server" ID="hfRoleId"></asp:HiddenField>
            <wucConfirmBox:wucConfirmBox runat="server" ID="thisMsgBox" />
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

