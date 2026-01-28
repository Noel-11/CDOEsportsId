<%@ Page Language="VB" AutoEventWireup="false" CodeFile="DPN.aspx.vb" Inherits="Secured_DPN_DPN" %>

<%@ Register Src="~/Include/sHeader.ascx" TagName="sHeader" TagPrefix="uc1" %>
<%@ Register Src="~/Include/sMainMenu.ascx" TagName="sMainMenu" TagPrefix="uc2" %>
<%@ Register Src="~/Include/sFooter.ascx" TagName="sFooter" TagPrefix="uc3" %>
<%@ Register Src="~/Include/wucMainMenu.ascx" TagName="wucMainMenu" TagPrefix="uc4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DATA PRIVACY NOTICE</title>
    <link rel="Shortcut Icon" href="~/favicon.ico" type="image/x-icon" />
    <script src="../../Scripts/jquery-1.12.4.min.js"></script>
    <link href="../../Scripts/bootstrap/css/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../../Scripts/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <script src="../../Scripts/bootstrap/js/bootstrap.min.js"></script>
    <link href="../../Scripts/kratik/fileinput/css/fileinput.min.css" rel="stylesheet" />
    <script src="../../Scripts/kratik/fileinput/js/fileinput.min.js"></script>

    <style>
        .sticky {
            position: fixed;
            top: 0;
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="panel panel-default">
            <div class="panel-heading panel-title sticky" style="text-align: center;">
                <%--<div class="row">
                    <div class="col-md-4" align="center">
                       <img src="../../Images/CDOSea1l.png" width="100px" class="img img-responsive"/>
                    </div>
                    <div class="col-md-4">--%>
                          <asp:Label runat="server" ID="lblPageTitlePDS" Text="DATA PRIVACY NOTICE" Style="font-size: x-large; font-weight: bold"></asp:Label>
                           <%--<p>PUBLIC INFORMATION SYSTEMS</p>--%>
                   <%-- </div>
                    <div class="col-md-4" align="center">
                        <img src="../../Images/ICTLogo.png" width="100px" class="img img-responsive" />
                    </div>
                </div>--%>
              
            </div>
            <div class="panel-body" style="padding-bottom: 10%; padding-top:10%;">
                <asp:Label runat="server" ID="lblDetails"></asp:Label>

            </div>
            <div class="panel-footer navbar-fixed-bottom">
                <div class="row">
                    <div class="col-md-12">
                        <p class="text-center text-muted mt-md mb-md ">
                           <b>Senior Citizen Registration</b><br />
                            © Copyright 2019. All Rights Reserved.<br />
                        </p>
                    </div>
                </div>
            </div>
        </div>

    </form>
</body>
</html>
