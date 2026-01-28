<%@ Page Title="User Role" Language="VB" AutoEventWireup="false" CodeFile="UserRole.aspx.vb" Inherits="Secured_UserRole" Theme="Skins" MasterPageFile="~/MasterPage/Admin.master" %>


<%@ Register Src="~/Include/wucConfirmBoxBS5.ascx" TagName="wucConfirmBox" TagPrefix="wucConfirmBox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpConTent" runat="Server">
    <div class="container-fluid">
        <div class="card">
            <div class="card-header" style="text-align: center;">
                <asp:Label runat="server" CssClass="card-title" ID="lblPageTitle" Text="User Role" Font-Size="18px"
                    ForeColor="#000000"></asp:Label>
            </div>

            <div class="card-body">

                <div class="row">
                    <div class="col-lg-10">
                        <div class="form-group">
                            <div class="input-group">
                                <span class="input-group-text">Search </span>
                                <asp:TextBox runat="server" CssClass="form-control" Style="z-index: 0; text-transform: uppercase;" ID="txtSearch"></asp:TextBox>
                                <button runat="server" class="btn btn-success" onserverclick="btnSearch_Click"><span class="glyphicon glyphicon-filter"></span>&nbsp;Filter</button>
                            </div>
                            <span class="input-group-addon" style="background-color: white">
                                <asp:Label runat="server" ID="lblPaging" CssClass="pull-right "></asp:Label>
                            </span>
                        </div>
                    </div>

                </div>

                <%--<div class="row">
                    <div class="col-lg-10">
                        <div class="form-group">
                            <div class="input-group">
                                <span class="input-group-text">Search </span>
                                <asp:TextBox runat="server" Width="100%" CssClass="form-control" Style="z-index: 0; text-transform: uppercase;" ></asp:TextBox>
                                <button runat="server" class="btn btn-success" onserverclick="btnSearch_Click"><span class="glyphicon glyphicon-filter"></span>&nbsp;Filter</button>
                            </div>
                            <span class="input-group-addon" style="background-color: white">
                                <asp:Label runat="server" CssClass="pull-right "></asp:Label>
                            </span>
                        </div>
                    </div>
                </div>--%>
                
                <div class="row">
                    <div class="col-lg-12">
                        <asp:Button runat="server" ID="btnAdd" CssClass="btn btn-primary" Text="Add" />
                    </div>
                </div>

                <asp:GridView runat="server" ID="_gv" CssClass="table table-success table-striped" AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateField HeaderText="User Role">
                            <ItemTemplate>
                                <asp:LinkButton runat="server" ID="lnkGV" SkinID="lnkButton" OnCommand="cmdGVUpdate" CommandArgument='<%# bind("user_role_id")%>' Text='<%# bind("user_role_name") %>' ToolTip="" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="user_role_description" HeaderText="Description" HeaderStyle-Width="50%" />
                        <asp:BoundField DataField="is_active" HeaderText="Active" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%" HeaderStyle-HorizontalAlign="Center" />
                    </Columns>
                </asp:GridView>

            </div>

        </div>
    </div>


</asp:Content>








