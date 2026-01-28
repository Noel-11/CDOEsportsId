<%@ Page Title="Menu" Language="VB" AutoEventWireup="false" CodeFile="cmsMenu.aspx.vb" Inherits="Secured_cmsMenu" MasterPageFile="~/MasterPage/Admin.master" Theme="Skins" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpConTent" runat="Server">

      <div class="container-fluid">
            <div class="card">
                <div class="card-header">
                    <asp:Label runat="server" ID="lblPageTitle" CssClass="card-title" Text="Menu" Font-Size="18px"
                        ForeColor="#000000"></asp:Label>
                </div>
                <div class="card-body">
                    <table style="width: 100%">
                        <tr>
                            <td style="text-align: left; width: 60%">
                                <div class="form-group">
                                    <div class="input-group">
                                        <span class="input-group-text">Search </span>

                                        <asp:TextBox runat="server" CssClass="form-control" Style="z-index: 0; text-transform: uppercase;" ID="txtSearch"></asp:TextBox>
                                    </div>
                                </div>

                            </td>
                            <td style="text-align: right; width: 40%">
                                <div class="form-group">

                                    <button runat="server" class="btn btn-primary" onserverclick="btnSearch_Click"><span class="glyphicon glyphicon-filter"></span>&nbsp;Filter</button>
                                    &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label runat="server" ID="lblPaging"></asp:Label>
                                </div>
                            </td>
                        </tr>
                    </table>
                   <button runat="server" onserverclick="btnBack_Click" type="button" id="btnReturn" class="btn btn-info btn-default" causesvalidation="false"><span class="glyphicon glyphicon-backward">&nbsp;BACK</span> </button>
                   <br />
                     <asp:GridView runat="server" ID="_gv" CssClass="gridviewGray table-success table-striped" SkinID="gvDefault">
                        <Columns>
                            <asp:TemplateField HeaderText="Menu Id">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="lnkGV" SkinID="lnkButton" OnCommand="cmdGVUpdate" CommandArgument='<%# bind("menu_id")%>' Text='<%# bind("menu_name") %>' ToolTip="" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sub Menu">
                                <ItemTemplate>
                                    &nbsp;<asp:LinkButton runat="server" ID="lnkGVSubMenu" SkinID="lnkButton" OnCommand="cmdGVSubMenu" CommandArgument='<%# bind("menu_id")%>' Text="Add/Edit" ToolTip="" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="parent_menu" HeaderText="Parent Menu" Visible="false" />
                            <asp:BoundField DataField="page_url" HeaderText="Page URL" Visible="false" />
                            <%--<asp:BoundField DataField="menu_level" HeaderText="Level"/>--%>
                            <asp:BoundField DataField="sort_order" HeaderText="Sort Order" />
                            <asp:BoundField DataField="is_public" HeaderText="Public" />
                            <asp:BoundField DataField="is_active" HeaderText="Active" />

                        </Columns>
                    </asp:GridView>
                    <br />
                    <asp:Button runat="server" ID="btnAdd" CssClass="btn btn-primary" Text="Add" />

                </div>

            </div>
        </div>
</asp:Content>








