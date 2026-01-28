<%@ Page Title="User Permission" Language="VB" AutoEventWireup="false" CodeFile="adminUserPermission.aspx.vb" Inherits="Secured_UserAdmin_adminUserPermission"
    MasterPageFile="~/MasterPage/Admin.master" Theme="Skins" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpConTent" runat="Server">

    <div class="container-fluid">

        <div class="card">
            <div class="card-header">
                <h2>USER PERMISSION</h2>
            </div>

            <div class="card-body">


                <div class="row mt-1">
                    <div class="col-lg-8">
                        <div class="input-group">
                            <span class="input-group-text border-secondary">Search </span>
                            <asp:TextBox runat="server" CssClass="form-control border-secondary" Style="z-index: 0; text-transform: uppercase;" ID="txtSearch"></asp:TextBox>
                            <button runat="server" class="btn btn-success border-secondary" onserverclick="btnSearch_Click"><i class="bi bi-funnel"></i>&nbsp;Filter</button>
                        </div>
                    </div>

                    <div class="col-md-4 mb-1">
                        <div class="input-group mb-1">
                            <span class="input-group-text" style="background-color: white; color: black">
                                <asp:Label runat="server" ID="lblPaging" CssClass="pull-right "></asp:Label></span>
                        </div>
                    </div>
                </div>



                <asp:GridView runat="server" ID="_gv" HeaderStyle-Font-Size="11px" CssClass="gridviewGreen" PageSize="10"
                    PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="false" AllowSorting="true"
                    GridLines="None" Font-Names="Arial" Font-Size="14px" ForeColor="#000000" AllowPaging="true">
                    <Columns>
                        <asp:TemplateField HeaderText="" HeaderStyle-Width="1%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:ImageButton runat="server" ID="lnkEdit" ImageUrl="~/images/edit.png" OnCommand="cmdGVSelect"
                                    CommandArgument='<%# Bind("user_id")%>' ToolTip="Click to View/Edit Record" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="user_id" HeaderText="User ID" ItemStyle-Width="25%" />
                        <asp:BoundField DataField="user_name" HeaderText="User Name" ItemStyle-Width="25%" />
                    </Columns>
                </asp:GridView>

            </div>

        </div>

    </div>

</asp:Content>


