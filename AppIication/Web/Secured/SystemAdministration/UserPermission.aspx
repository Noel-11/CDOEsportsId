<%@ Page Title="User Permission" Language="VB" AutoEventWireup="false" CodeFile="UserPermission.aspx.vb" Inherits="Secured_SystemAdministration_UserPermission" Theme="Skins" MasterPageFile="~/MasterPage/Admin.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpConTent" runat="Server">
    <div class="container-fluid">
        <div class="card">

            <div class="card-header">
                <h2>USER PERMISSION</h2>
            </div>

            <div class="card-body">
                <div class="row mt-1">
                    <div class="col-lg-8 mb-1">
                        <div class="form-group">
                            <div class="input-group">
                                <span class="input-group-text border-secondary">Search </span>
                                <asp:TextBox runat="server" CssClass="form-control border-secondary" Style="z-index: 0; text-transform: uppercase;" ID="txtSearch"></asp:TextBox>
                                <button runat="server" class="btn btn-success border-secondary" onserverclick="btnSearch_Click"><i class="bi bi-funnel"></i>&nbsp;Filter</button>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-4 mb-1">
                        <span class="input-group-text" style="background-color: white; color: black">
                            <asp:Label runat="server" ID="lblPaging" CssClass="pull-right "></asp:Label></span>
                    </div>
                </div>

                <asp:GridView runat="server" ID="_gv" HeaderStyle-Font-Size="14px" CssClass="gridviewGreen table-bordered table-success table-striped table-hover" PageSize="15" EmptyDataText="NO RECORD FOUND"
                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="false"
                    GridLines="None" Font-Names="Arial" Font-Size="12px" ForeColor="#000000" AllowPaging="true">
                    <Columns>
                        <asp:TemplateField HeaderText="" HeaderStyle-Width="1%">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="lnkEdit" ImageUrl="~/images/useredit.png" OnCommand="cmdGVUpdate"
                                    CommandArgument='<%# Bind("user_id")%>' ToolTip="Click to Validate Registration" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="user_id" HeaderText="User ID" ItemStyle-Width="10%" />
                        <asp:BoundField DataField="user_name" HeaderText="User Name" ItemStyle-Width="30%" />
                    </Columns>
                </asp:GridView>

            </div>
        </div>

    </div>
</asp:Content>





