<%@ Page Title="Role Permission" Language="VB" AutoEventWireup="false" CodeFile="RolePermission.aspx.vb" 
    Inherits="Secured_SystemAdministration_RolePermission" Theme="Skins" %>

<!DOCTYPE html>

<%@ Register Src="~/Include/wucConfirmBoxBS.ascx" TagName="wucConfirmBox" TagPrefix="wucConfirmBox" %>
<%@ Register Src="~/Include/wucMainMenuBS.ascx" TagName="wucMainMenu" TagPrefix="uc4" %>

<%@ Register Src="~/Include/sHeader.ascx" TagName="sHeader" TagPrefix="uc1" %>
<%@ Register Src="~/Include/sFooterAdmin.ascx" TagName="sFooter" TagPrefix="uc3" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>User Permission</title>
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
    <form id="form1" role="form" method="post" runat="server" autocomplete="off">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <div class="container" style="width: 100%">
            <uc4:wucMainMenu ID="wucMainMenu2" runat="server" />
        </div>

        <div class="container-fluid">
            <div class="panel-warning">
                <div class="panel-heading" style="text-align: center">
                    <asp:Label runat="server" ID="lblPageTitle" Text="Role Permission" Font-Size="18px"
                        ForeColor="#000000"></asp:Label>
                </div>
                <div class="panel-body">

                    <div class="row">
                        <div class="col-lg-10">
                            <div class="form-group">
                                <div class="input-group">
                                    <span class="input-group-addon">Search </span>
                                    <asp:TextBox runat="server" Width="100%" CssClass="form-control" Style="z-index: 0; text-transform: uppercase;" ID="txtSearch"></asp:TextBox>
                                    <div class="input-group-btn">
                                        <button runat="server" class="btn btn-success" onserverclick="btnSearch_Click"><span class="glyphicon glyphicon-filter"></span>&nbsp;Filter</button>
                                    </div>
                                    <span class="input-group-addon" style="background-color: white">
                                        <asp:Label runat="server" ID="lblPaging" CssClass="pull-right "></asp:Label>
                                    </span>
                                </div>
                            </div>
                        </div>
                    </div>

                    <asp:GridView runat="server" ID="_gv" SkinID="gvDefault" CssClass="table table-success table-striped">
                        <Columns>
                            <asp:TemplateField HeaderText="User Role" HeaderStyle-Width="10%">
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="lnkGV" SkinID="lnkButton" OnCommand="cmdGVUpdate" CommandArgument='<%# bind("user_role_id")%>' Text='<%# bind("user_role_name") %>' ToolTip="Click to View/Edit" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="user_role_description" HeaderText="Description" ItemStyle-Width="30%" />
                        </Columns>
                    </asp:GridView>
                    
                </div>

            </div>
        </div>

        <div>
            <uc1:sHeader ID="sHeader1" runat="server" />
        </div>
        <div>
            <uc3:sFooter ID="sFooter1" runat="server" />
        </div>
    </form>
</body>

</html>





