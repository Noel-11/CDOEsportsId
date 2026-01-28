<%@ Control Language="VB" AutoEventWireup="false" CodeFile="sSearchPaging.ascx.vb" Inherits="Include_sSearchPaging" %>
<asp:Table runat="server" ID="tblFormContent"  SkinID="tblNoBorder">
    <asp:TableRow>
        <asp:TableCell Width="70%">
            <asp:Label runat="server" ID="lblSearch" Text="Search : " ForeColor="#361155"></asp:Label>
            <asp:TextBox runat="server" ID="txtSearch" SkinID="txtInputForm_long"></asp:TextBox>
            <asp:ImageButton runat="server" ID="btnSearch" SkinID="btnSearch" ImageUrl="~/Images/btnSearch.png"  ImageAlign="AbsMiddle" Text="" CausesValidation ="false"/>
        </asp:TableCell>
        <asp:TableCell SkinID="celPaging" Width="30%">
            <asp:Label ID="lblPaging" runat="server" SkinID="lblPaging" Text="Page 1 of 1, Total Records: 0" Width="100%" ForeColor="#361155"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>