<%@ Control Language="VB" AutoEventWireup="false" CodeFile="wucMessageBox.ascx.vb" Inherits="Include_wucMessageBox" %>
 <asp:Button runat="server" ID="btnSave" CssClass="buttonOrange" Text="Save"/>&nbsp;&nbsp;
 <asp:Button runat="server" ID="btnCancel" CssClass="buttonOrange" Text="Cancel" CausesValidation="false" />

 <asp:HiddenField runat="server" ID="hdDummy" />
    <asp:HiddenField runat="server" ID="hfModalType" />
    <ajaxToolkit:ModalPopupExtender ID="mpeMessageBox" runat="server" PopupControlID="pnlMessageBox"
        TargetControlID="hdDummy" BackgroundCssClass="modalBackground">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="pnlMessageBox" runat="server" CssClass="modalPopup" Style="display: none">
        <div class="header">
            <asp:Label runat="server" ID="lblMsgBoxHeader" SkinID="lbl12BW"  Text="CONFIRMATION"></asp:Label>
        </div>
        <div class="body">
            <asp:Label runat="server" ID="lblMsgBoxMessage" SkinID="lbl12B" Text="Are you sure you want to save this record?"></asp:Label>
        </div>
        <div class="footer" align="center">
            <asp:Button ID="btnMsgBoxYes" runat="server" Text="Yes" CssClass="yes" CausesValidation="false" />
            <asp:Button ID="btnMsgBoxNo" runat="server" Text="No" CssClass="no" CausesValidation="false" />
        </div>
    </asp:Panel>