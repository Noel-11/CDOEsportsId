<%@ Control Language="VB" AutoEventWireup="false" CodeFile="wucMainMenu.ascx.vb"
    Inherits="Include_wucMainMenu" %>


<asp:Menu ID="mnuMainMenu" runat="server" Orientation="Horizontal" 
    Font-Names="Verdana"  Height="30px"  StaticEnableDefaultPopOutImage="false">
    <%--  <StaticMenuItemStyle BackColor="Maroon" Width="100%" Height="30px" BorderColor="Blue" BorderWidth="1px" Font-Size="11px" Font-Bold ="true" />    
    <DynamicMenuItemStyle BackColor="Green"  Height="30px" Width="100%" HorizontalPadding="5px" VerticalPadding="5px"  BorderColor="Red" BorderWidth="1px"  />
    <DynamicHoverStyle BackColor="Yellow" Height="30px"   />
    <StaticHoverStyle BackColor="Pink" Height="30px" />
    <LevelMenuItemStyles>
        <asp:MenuItemStyle Font-Underline="False" />
    </LevelMenuItemStyles>
    <LevelSubMenuStyles>
        <asp:SubMenuStyle CssClass="webMenuNavigationSubS" Font-Underline="False" />
    </LevelSubMenuStyles>--%>
    <StaticMenuItemStyle Height="30px" CssClass="menuYellow"/>
    <DynamicMenuItemStyle Height="30px" CssClass="menuItemYellow"/>
   
</asp:Menu>
