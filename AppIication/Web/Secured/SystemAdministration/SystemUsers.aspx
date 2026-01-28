<%@ Page Title="System Users" Language="VB" AutoEventWireup="false" CodeFile="SystemUsers.aspx.vb" Inherits="Secured_SystemAdministration_SystemUsers" Theme="Skins" %>

<!DOCTYPE html>

<%@ Register Src="~/Include/wucConfirmBoxBS.ascx" TagName="wucConfirmBox" TagPrefix="wucConfirmBox" %>
<%@ Register Src="~/Include/wucMainMenuBS.ascx" TagName="wucMainMenu" TagPrefix="uc4" %>

<%@ Register Src="~/Include/sHeader.ascx" TagName="sHeader" TagPrefix="uc1" %>
<%@ Register Src="~/Include/sFooterAdmin.ascx" TagName="sFooter" TagPrefix="uc3" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Shortcut Icon" href="~/favicon.ico" type="image/x-icon" />
    <script src="../../Scripts/jquery-1.12.4.min.js"></script>
    <link href="../../Scripts/bootstrap/css/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../../Scripts/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <script src="../../Scripts/bootstrap/js/bootstrap.min.js"></script>

    <script src="../../Scripts/bootstrap_datepicker/js/bootstrap-datepicker.min.js"></script>
    <link href="../../Scripts/bootstrap_datepicker/css/bootstrap-datepicker.standalone.min.css" rel="stylesheet" />

    <style>
        /*#btnInformation {
            background-color: white;
            color: seagreen;
        }*/
    </style>
</head>
<body>
    <form id="form1" role="form" method="post" runat="server" autocomplete="off">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <div class="container" style="width: 100%">
            <uc4:wucMainMenu ID="wucMainMenu" runat="server" />
        </div>

        <div class="container" style="width: 100%">
            <div class="panel panel-primary">
                <div class="panel-heading" style="text-align: center;">
                    <asp:Label runat="server" ID="Label1" Text="ACTIVE USERS" SkinID="lblPageTitle"></asp:Label>
                </div>

                <div class="panel-body">
                    <ul runat="server" class="nav nav-tabs">
                        <li runat="server" class="active tab"><a data-toggle="tab" href="#divAdmin" class="btn-lg">ADMIN</a></li>
                        <li runat="server" class="tab"><a data-toggle="tab" href="#divClient" class="btn-lg">CLIENT</a></li>
                    </ul>

                    <div class="tab-content">
                        <div class="tab-pane fade in active" runat="server" id="divAdmin">
                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <div class="input-group">
                                            <span class="input-group-addon" style="background-color: white; color: black">Active Count: </span>
                                            <asp:Label runat="server" ID="lblAdminCount" CssClass="form-control"></asp:Label>
                                        </div>
                                    </div>

                                </div>
                            </div>

                            <asp:GridView runat="server" ID="_gvAdmin" HeaderStyle-Font-Size="11px" CssClass="gridviewGreen" PageSize="15"
                                AllowPaging="false" EmptyDataText="No Active" AlternatingRowStyle-CssClass="alt">
                            </asp:GridView>

                        </div>

                        <div class="tab-pane fade" runat="server" id="divClient">

                            <br />
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <div class="input-group">
                                            <span class="input-group-addon" style="background-color: white; color: black">Active Count: </span>
                                            <asp:Label runat="server" ID="lblClientCount" CssClass="form-control"></asp:Label>
                                        </div>
                                    </div>

                                </div>
                            </div>

                            <asp:GridView runat="server" ID="_gvClient" HeaderStyle-Font-Size="11px" CssClass="table table-success table-striped" PageSize="15"
                                AllowPaging="false" EmptyDataText="No Active" AlternatingRowStyle-CssClass="alt">
                            </asp:GridView>

                        </div>

                    </div>

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
