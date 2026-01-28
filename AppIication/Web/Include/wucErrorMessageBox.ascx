<%@ Control Language="VB" AutoEventWireup="false" CodeFile="wucErrorMessageBox.ascx.vb" Inherits="Include_wucErrorMessageBox" %>

 <asp:HiddenField runat="server" ID="hdDummy" />
    <asp:HiddenField runat="server" ID="hfModalType" />
    <ajaxToolkit:ModalPopupExtender ID="mpeMessageBox" runat="server" PopupControlID="pnlMessageBox"
        TargetControlID="hdDummy" BackgroundCssClass="modalBackground">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="pnlMessageBox" runat="server" CssClass="modalPopupError" Style="display: none">
        <div class="header">
            <asp:Label runat="server" ID="lblMsgBoxHeader" SkinID="lbl12BW"  Text="ERROR"></asp:Label>
        </div>
        <div class="body">
            <asp:Label runat="server" ID="lblMsgBoxMessage" SkinID="lbl12B" Text="Are you sure you want to save this record?"></asp:Label>
        </div>
        <div class="footer" align="center">
            <asp:Button ID="btnMsgBoxYes" runat="server" Text="OK" CssClass="yes" CausesValidation="false"/>
        </div>
    </asp:Panel>