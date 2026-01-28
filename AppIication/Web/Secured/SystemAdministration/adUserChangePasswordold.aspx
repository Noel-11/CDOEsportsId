<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage/Secured.master" AutoEventWireup="false" CodeFile="adUserChangePasswordold.aspx.vb" Inherits="Secured_adUserChangePassword" Theme="Skins" %>

<%@ Register src="~/Include/wucErrorMessageBox.ascx" tagname="wucErrorMessageBox" tagprefix="wucErrorMsgBox" %>
<%@ Register src="~/Include/wucValidateMessageBox.ascx" tagname="wucMessageBox" tagprefix="wucMsgBox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphSContent" Runat="Server">
    <asp:Table runat="server" ID="tblForm" SkinID="tblForm">
        <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#b9b9b9"
            Height="30px">
            <asp:TableCell>
                <asp:Label runat="server" ID="lblPageTitle" Text="Change Password" SkinID="lblPageTitle" ></asp:Label></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Table runat="server" ID="tblFormContent" SkinID="tblFormContent">
                    
                    <asp:TableRow>
                        <asp:TableCell SkinID="celFormLabel3" Text="Current Password : "></asp:TableCell>
                        <asp:TableCell SkinID="celFormLabel2"><asp:TextBox runat="server" ID="txtCurrentPassword" TextMode="Password" SkinID="txtInputForm"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell SkinID="celFormLabel3" Text="New Password : "></asp:TableCell>
                        <asp:TableCell SkinID="celFormLabel2"><asp:TextBox runat="server" ID="txtNewPassword" TextMode="Password" SkinID="txtInputForm"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell SkinID="celFormLabel3" Text="Re-type Password : "></asp:TableCell>
                        <asp:TableCell SkinID="celFormLabel2"><asp:TextBox runat="server" ID="txtRetypePassword"  TextMode="Password" SkinID="txtInputForm" ></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell></asp:TableCell>
                        <asp:TableCell HorizontalAlign="Left">
                            <wucMsgBox:wucMessageBox runat ="server" ID="thisMsgBox" />
                            <wucErrorMsgBox:wucErrorMessageBox runat ="server" ID="thisErrorMsgBox" />
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>       
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    
</asp:Content>