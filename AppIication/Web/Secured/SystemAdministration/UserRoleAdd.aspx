<%@ Page Title="User Role" Language="VB" AutoEventWireup="false" CodeFile="UserRoleAdd.aspx.vb" Inherits="Secured_UserRoleAdd" Theme="Skins" %>

<!DOCTYPE html>

<%@ Register Src="~/Include/wucConfirmBoxBS.ascx" TagName="wucConfirmBox" TagPrefix="wucConfirmBox" %>
<%@ Register Src="~/Include/sHeader.ascx" TagName="sHeader" TagPrefix="uc1" %>
<%@ Register Src="~/Include/sFooterAdmin.ascx" TagName="sFooter" TagPrefix="uc3" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="Shortcut Icon" href="~/favicon.ico" type="image/x-icon" />
    <script src="../../Scripts/jquery-1.12.4.min.js"></script>
    <link href="../../Scripts/bootstrap/css/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../../Scripts/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <script src="../../Scripts/bootstrap/js/bootstrap.min.js"></script>

    <script type="text/javascript">
        $(function () {
            $('[data-toggle="tooltip"]').tooltip();
        });
    </script>
    
</head>

<body>
    <br />
    <form id="form1" role="form" method="post" runat="server" autocomplete="off">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <div class="container-fluid">
            <div class="panel panel-success">
                <div class="panel-heading" style="text-align: center">
                    <button runat="server" onserverclick="btnHome_Click" type="button" id="btnHome" class="btn btn-info btn-default pull-left" causesvalidation="false"><span class="glyphicon glyphicon-backward">&nbsp;BACK</span> </button>
                    <asp:Label runat="server" ID="lblPageTitle" Text="User Role" Font-Size="18px" ForeColor="#000000"></asp:Label>
                </div>
                <div class="panel-body">

                    <div class="form-group">
                        <div class="input-group">
                            <span class="input-group-addon" style="font-weight: bold">User Role : </span>
                            <asp:TextBox runat="server" ID="txtuserrole" CssClass="form-control" ToolTip="Text"></asp:TextBox>
                        </div>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtuserrole" SetFocusOnError="true" Font-Bold="true" Font-Size="13pt" Display="Dynamic" Text="User Role is required" ValidationGroup="DOC" />
                    </div>

                    <div class="form-group">
                        <div class="input-group">
                            <span class="input-group-addon" style="font-weight: bold">Description : </span>
                            <asp:TextBox runat="server" ID="txtdescription" CssClass="form-control" ToolTip="Text"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="input-group">
                            <span class="input-group-addon" style="font-weight: bold">Status : </span>
                            <asp:RadioButtonList runat="server" ID="rblIsActive" CssClass="form-control " RepeatDirection="Horizontal">
                                <asp:ListItem Text="&nbsp;Yes&nbsp;&nbsp;" Value="Y" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="&nbsp;&nbsp;No" Value="N"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>

                </div>

                <div class="modal-footer">
                    <asp:Button runat="server" ID="btnSave" class="btn btn-primary btn-lg" Text="Save" ValidationGroup="DOC" />
                    <asp:Button runat="server" ID="btnCancel" class="btn btn-danger btn-lg" Text="Cancel" CausesValidation="false" />
                </div>

            </div>
        </div>

        <asp:UpdatePanel ID="updatePanel1" runat="server">
            <ContentTemplate>
                <asp:HiddenField runat="server" ID="hfUserRoleId"></asp:HiddenField>
                <wucConfirmBox:wucConfirmBox runat="server" ID="thisMsgBox" />
            </ContentTemplate>
        </asp:UpdatePanel>

        <div>
            <uc1:sHeader ID="sHeader1" runat="server" />
        </div>
        <div>
            <uc3:sFooter ID="sFooter1" runat="server" />
        </div>
    </form>

</body>

</html>
