<%@ Page Language="VB" AutoEventWireup="false" EnableEventValidation="false" CodeFile="admin.aspx.vb" Inherits="_admin" Theme="Skins" %>

<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">--%>
<!DOCTYPE html>
<%@ Register Src="~/Include/wucErrorMessageBox.ascx" TagName="wucError" TagPrefix="wucError" %>
<%@ Register Src="~/Include/sFooter.ascx" TagName="sFooter" TagPrefix="uc3" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <meta name="robots" content="noindex, nofollow" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="Shortcut Icon" href="~/favicon.ico" type="image/x-icon" />
    <title>SENIOR CITIZEN'S ID ONLINE REGISTRATION</title>

    <link href="Scripts/Bootstrap5/css/bootstrap.css" rel="stylesheet" />
    <link href="Scripts/Bootstrap5/css/bootstrap.min.css" rel="stylesheet" />

    <script src="Scripts/Bootstrap5/js/bootstrap.min.js"></script>

    <script src="Scripts/Bootstrap5/js/bootstrap.bundle.js"></script>

    <link href="Scripts/NiceAdmin/vendor/bootstrap-icons/bootstrap-icons.css" rel="stylesheet" />

    <!-- Font Awesome icons (free version)-->
    <%--<script src="https://use.fontawesome.com/releases/v6.1.0/js/all.js" crossorigin="anonymous"></script>--%>

    <style type="text/css">
        .auto-style1 {
            width: 202px;
        }

        .auto-style4 {
            width: 533px;
        }

        #imgWaterMark {
            opacity: 0.4;
            z-index: -1;
            /* For IE8 and earlier */
        }

            #imgWaterMark:hover {
                opacity: 1;
                filter: alpha(opacity=100);
                position: absolute;
                z-index: -1;
                /*For IE8 and earlier*/
            }

        .divider:after,
        .divider:before {
            content: "";
            flex: 1;
            height: 1px;
            background: #eee;
        }

        .h-custom {
            height: calc(100% - 73px);
        }

        @media (max-width: 450px) {
            .h-custom {
                height: 100%;
            }
        }

        .footer {
            /*position: fixed;*/
            left: 0;
            bottom: 0;
            width: 100%;
            background-color: #333;
            color: white;
            /*text-align: center;*/
        }
    </style>

    <!-- Google tag (gtag.js) -->
    <script async src="https://www.googletagmanager.com/gtag/js?id=G-BTES5DW7T1"></script>
    <script>
        window.dataLayer = window.dataLayer || [];
        function gtag() { dataLayer.push(arguments); }
        gtag('js', new Date());

        gtag('config', 'G-BTES5DW7T1');
    </script>

</head>

<body style="background: linear-gradient(to bottom, #306a6aab, #e7e7e7);">

    <form id="form1" runat="server" autocomplete="off">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <div class="container" style="margin-bottom: 5%;">
            <div class="row justify-content-center mt-5">
                <div class="col-md-6">
                    <div class="card">
                        <div class="card-header" style="background-color: #5eb1b1ab;">
                            <h3 class="text-center">LOG IN ACCOUNT <i class="fa-solid fa-user-lock"></i></h3>
                        </div>
                        <div class="card-body">
                            <form>
                                <div class="form-outline mb-4">
                                    <div class="form-group text-center">
                                        <img src="<%=ResolveClientUrl("~/Images/login_1.png")%>" class="img-fluid img-thumbnail" alt="LOGIN IMAGE" />
                                    </div>
                                </div>

                                <!-- UserID input -->
                                <div class="form-outline mb-4">
                                    <asp:TextBox runat="server" ID="txtUserId" class="form-control form-control-lg" placeholder="Enter User ID"></asp:TextBox>
                                    <%-- <label class="form-label" for="form3Example3">User ID</label>--%>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtUserId" SetFocusOnError="true" Font-Bold="true" Font-Italic="true" Font-Size="10pt" Display="Dynamic" Text=" is required" ValidationGroup="DOC" />
                                </div>

                                <!-- Password input -->
                                <div class="form-outline mb-3">
                                    <input runat="server" type="password" id="txtPassword" class="form-control form-control-lg"
                                        placeholder="Enter password" />

                                    <%--  <label class="form-label" for="form3Example4">Password</label>--%>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPassword" SetFocusOnError="true" Font-Bold="true" Font-Italic="true" Font-Size="10pt" Display="Dynamic" Text=" is required" ValidationGroup="DOC" />
                                </div>

                                <div class="text-center text-lg-start mt-4 pt-2">
                                    <button runat="server" id="btnLogin" class="btn btn-success text-light" causesvalidation="false"><i class="bi bi-box-arrow-in-right h4"></i>&nbsp;Login</button>
                                    <%--<asp:Button runat="server" ID="btnLogin" class="btn btn-primary btn-lg" Style="padding-left: 2.5rem; padding-right: 2.5rem;" Text="Login" ValidationGroup="DOC" />--%>
                                    <p class="small fw-bold mt-2 pt-1 mb-0" runat="server" visible="false">
                                        Don't have an account? <a href="#!"
                                            class="link-danger">Register</a>
                                    </p>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>

            <hr />

            <div class="row" id="visitorCount">
                <div class="col-sm-6" align="center">
                    <asp:Label runat="server" Style="font-size: 14px; font-weight: bold;" Text="Today's Visitor Count : "></asp:Label>
                    <asp:Label runat="server" ID="lblTodayVisitor" CssClass="badge text-bg-danger" Style="font-size: 16px; font-weight: bold;"></asp:Label>
                </div>

                <div class="col-sm-6" align="center">
                    <asp:Label runat="server" Style="font-size: 14px; font-weight: bold;" Text="Total Visitor Count : "></asp:Label>
                    <asp:Label runat="server" ID="lblTotalVisitor" CssClass="badge text-bg-primary" Style="font-size: 16px; font-weight: bold;"></asp:Label>
                </div>
            </div>

        </div>

        <!-- Footer -->
        <div class="footer">
            <uc3:sFooter ID="sFooter1" runat="server" />
        </div>

    </form>
</body>
</html>

