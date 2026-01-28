<%@ Page Title="User PCB Access" Language="VB" MasterPageFile="~/MasterPage/Secured.master" AutoEventWireup="false" CodeFile="UserPCBAccess.aspx.vb" Inherits="Secured_SystemAdministration_UserEntry" Theme="Skins" %>

<%@ Register src="~/Include/sSearchPaging.ascx" tagname="sSearchPaging" tagprefix="uc6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphSContent" Runat="Server">
    <asp:Table runat="server" ID="tblForm"  SkinID="tblForm">
      <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#ffffcc"
            Height="30px">
            <asp:TableCell>
                <asp:Label runat="server" ID="lblPageTitle" Text="User Entry" Font-Size="18px"
                    ForeColor="#000000"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;</asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>
                <asp:Table runat="server" ID="tblFormContent"  SkinID="tblFormContent">    
                    <asp:TableRow>
                       <asp:TableCell SkinID="celPaging" HorizontalAlign ="Left" >
                     <uc6:sSearchPaging ID="sSearchPaging1" runat="server" />
                        </asp:TableCell>
                    </asp:TableRow>

                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:GridView runat="server" ID="_gv" SkinID="gvDefault">
                                <Columns>
                                    <asp:TemplateField HeaderText="User ID" HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center" >
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="lnkGV" SkinID="lnkButton" OnCommand="cmdGVUpdate" CommandArgument='<%# bind("user_id")%>' Text='<%# bind("user_id") %>' ToolTip="Click to View/Edit"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   
                                 <asp:BoundField DataField="user_name" HeaderText="User Name" ItemStyle-Width="40%" />
                                </Columns>
                            </asp:GridView>
                        </asp:TableCell>
                    </asp:TableRow>
                   
                 </asp:Table>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    
</asp:Content>



