<%@ Page Title="User Entry" Language="VB" AutoEventWireup="false" CodeFile="GenerateId.aspx.vb" Inherits="GenerateId" MasterPageFile="~/MasterPage/Admin.master" Theme="Skins" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpConTent" runat="Server">
    <div class="container-fluid">

        <div class="card">

            <div class="card-header">
                <div class="row">
                    <div class="col-md-6">
                        <h2>USER ENTRY</h2>
                    </div>

                    <div class="col-md-6">
                    </div>
                </div>

            </div>

            <div class="card-body">

                <div class="row mt-1">
                    <div class="col-lg-8">
                        <div class="form-group">
                            <div class="input-group">
                                <span class="input-group-text border-secondary">Search </span>
                                <asp:TextBox runat="server" CssClass="form-control border-secondary" Style="z-index: 0; text-transform: uppercase;" ID="txtSearch"></asp:TextBox>
                                <button runat="server" class="btn btn-success border-secondary" onserverclick="btnSearch_Click"><i class="bi bi-funnel"></i>&nbsp;Filter</button>
                            </div>

                        </div>
                    </div>

                    <div class="col-md-4 mb-1">
                        <div class="input-group mb-1">
                            <span class="input-group-text" style="background-color: white; color: black">
                                <asp:Label runat="server" ID="lblPaging" CssClass="pull-right "></asp:Label></span>
                        </div>
                    </div>

                </div>
                <asp:UpdatePanel ID="updatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:GridView runat="server" ID="_gv" HeaderStyle-Font-Size="14px" CssClass="gridviewGreen table-bordered table-success table-striped table-hover" PageSize="15" EmptyDataText="NO RECORD FOUND"
                            PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="false"
                            GridLines="None" Font-Names="Arial" Font-Size="12px" ForeColor="#000000" AllowPaging="true">
                            <Columns>
                                <asp:TemplateField HeaderText="" HeaderStyle-Width="1%" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:ImageButton runat="server" ID="lnkEdit" ImageUrl="~/images/view24.png" OnCommand="cmdGVGenerate"
                                            CommandArgument='<%# Bind("id")%>' ToolTip="Click to Validate Registration" />

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="full_name" HeaderText="Name" ItemStyle-Width="30%" />
                                <asp:BoundField DataField="sex" HeaderText="Sex" ItemStyle-Width="5%" />
                                <asp:BoundField DataField="age" HeaderText="Age" ItemStyle-Width="5%" />
                                <asp:BoundField DataField="contact_number" HeaderText="Contact No." ItemStyle-Width="10%" />
                                <asp:BoundField DataField="mode_of_validation" HeaderText="Validation Mode" ItemStyle-Width="10%" />
                                <asp:BoundField DataField="referral_channel" HeaderText="Referral" ItemStyle-Width="10%" />
                                <asp:BoundField DataField="is_licensed_player" HeaderText="Licensed" ItemStyle-Width="5%" />

                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>
        </div>
    </div>

     <div id="mdlGenIDReport" role="dialog" class="modal fade" data-bs-backdrop="false" data-bs-keyboard="false">
                <div class="modal-dialog modal-lg">

                    <!-- Modal content-->
                    <div class="modal-content">

                        <div class="modal-header">
                            <span class="glyphicon glyphicon-alt-list"></span>
                            <asp:Label runat="server" ID="Label73" Style="font-size: 20px" Text="Generate ID"></asp:Label>
                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>

                        <div class="modal-body">
                             <asp:UpdatePanel ID="updatePanel20" runat="server">
                                    <ContentTemplate>
                                        <button type="button" id="btnIDFront" runat="server" class="btn btn-primary" onserverclick="btnIDFront_ServerClick"><span class="glyphicon glyphicon-chevron-left"></span>&nbsp;FRONT</button>
                                        <button type="button" id="btnIDBack" runat="server" class="btn btn-primary" onserverclick="btnIDBack_ServerClick">&nbsp;BACK&nbsp;&nbsp;<span class="glyphicon glyphicon-chevron-right"></span></button>
                                    
                            <asp:Literal ID="ltEmbedID" runat="server" />
                                        </ContentTemplate>
                                </asp:UpdatePanel>
                        </div>
                        <div class="modal-footer">
                          <button type="button" id="btnExport" runat="server" class="btn btn-success pull-left" onserverclick="btnExport_ServerClick"><span class="glyphicon glyphicon-download"></span>&nbsp;Export</button>
                    <button type="button" id="Button1" runat="server" class="btn btn-danger " data-dismiss="modal"><span class="glyphicon glyphicon-remove"></span>&nbsp;Close</button>
                        </div>
                    </div>

                </div>

            </div>

    <asp:UpdatePanel ID="updatePanel1" runat="server">
        <ContentTemplate>
            <asp:HiddenField runat="server" ID="hfTransId"></asp:HiddenField>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>




