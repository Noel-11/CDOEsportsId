<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" Theme="Skins" %>

<!DOCTYPE html>

<%@ Register Src="~/Include/MyCaptchaWithIncrease.ascx" TagName="Captcha" TagPrefix="site" %>
<%@ Register Src="~/Include/wucConfirmBoxBS5.ascx" TagName="wucConfirmBox" TagPrefix="wucConfirmBox" %>

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta charset="utf-8" />
    <meta name="robots" content="noindex, nofollow" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Senior Citizen's ID Online Registration</title>
    <link rel="icon" type="image/x-icon" href="Scripts/landing/assets/favicon.ico" />
    <!-- Font Awesome icons (free version)-->
    <%--<script src="https://use.fontawesome.com/releases/v6.1.0/js/all.js" crossorigin="anonymous"></script>--%>
    <!-- Google fonts-->
    <link rel="preconnect" href="https://fonts.gstatic.com" />
    <link href="https://fonts.googleapis.com/css2?family=Tinos:ital,wght@0,400;0,700;1,400;1,700&amp;display=swap" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css2?family=DM+Sans:ital,wght@0,400;0,500;0,700;1,400;1,500;1,700&amp;display=swap" rel="stylesheet" />

    <!-- Core theme CSS (includes Bootstrap)-->
    <link href="Scripts/landing/css/styles.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous" />

    <link href="Scripts/Bootstrap5/css/bootstrap.css" rel="stylesheet" />
    <link href="Scripts/Bootstrap5/css/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/Bootstrap5/js/bootstrap.min.js"></script>

    <!-- Bootstrap core JS-->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js"></script>
    <!-- Core theme JS-->
    <script src="Scripts/landing/js/scripts.js"></script>
    <!-- * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *-->
    <!-- * *                               SB Forms JS                               * *-->
    <!-- * * Activate your form at https://startbootstrap.com/solution/contact-forms * *-->
    <!-- * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *-->

    <script src="https://cdn.startbootstrap.com/sb-forms-latest.js"></script>
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <%--<script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>--%>

    <script type="text/javascript">

        function CheckTextLength(text, long) {
            var maxlength = new Number(long); // Change number to your max length.

            var lblCharCount;

            lblCharCount = document.getElementById("lblCharCount");

            lblCharCount.innerHTML = 500 - text.value.length;


            if (text.value.length > maxlength) {
                text.value = text.value.substring(0, maxlength);
                lblCharCount.innerHTML = 0;
                alert(" Only " + long + " characters allowed");
            }
        }

    </script>

    <!-- Google tag (gtag.js) -->
    <script async src="https://www.googletagmanager.com/gtag/js?id=G-BTES5DW7T1"></script>
    <script>
        window.dataLayer = window.dataLayer || [];
        function gtag() { dataLayer.push(arguments); }
        gtag('js', new Date());

        gtag('config', 'G-BTES5DW7T1');
   </script>

</head>
<body>
    <form id="form1" runat="server" autocomplete="off">

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <div class="bd-example">
            <div id="carouselExampleCaptions" class="carousel slide" data-bs-ride="carousel">
                <ol class="carousel-indicators">
                    <li data-bs-target="#carouselExampleCaptions" data-bs-slide-to="0" class=""></li>
                    <li data-bs-target="#carouselExampleCaptions" data-bs-slide-to="1" class=""></li>
                    <li data-bs-target="#carouselExampleCaptions" data-bs-slide-to="2" class="active"></li>
                </ol>
                <div class="carousel-inner">
                    <div class="carousel-item active">
                        <img class="d-block w-100" src="Scripts/landing/assets/img/SENIORS.jpg" data-holder-rendered="true" />
                    </div>
                    <div class="carousel-item">
                        <img class="d-block w-100" src="Scripts/landing/assets/img/67250800.jpg" data-holder-rendered="true" />
                    </div>
                    <div class="carousel-item active">
                        <img class="d-block w-100" src="Scripts/landing/assets/img/image4.jpg" data-holder-rendered="true" />
                    </div>
                </div>

            </div>
        </div>

        <div class="masthead">
            <div class="masthead-content text-white">
                <div class="container-fluid px-4 px-lg-0">

                    <div class="row" id="visitorCount">
                        <div class="col-sm-6">
                            <asp:Label runat="server" Style="font-size: 14px; font-weight: bold;" Text="Today's Visitor Count : "></asp:Label>
                            <asp:Label runat="server" ID="lblTodayVisitor" CssClass="badge text-bg-danger" Style="font-size: 16px; font-weight: bold;"></asp:Label>
                        </div>

                        <div class="col-sm-6">
                            <asp:Label runat="server" Style="font-size: 14px; font-weight: bold;" Text="Total Visitor Count : "></asp:Label>
                            <asp:Label runat="server" ID="lblTotalVisitor" CssClass="badge text-bg-primary" Style="font-size: 16px; font-weight: bold;"></asp:Label>
                        </div>
                    </div>

                    <img src="Scripts/landing/assets/img/cdo.png" width="90px" height="100px" data-holder-rendered="true" />
                    <img src="Scripts/landing/assets/img/logo.png" width="200px" height="90px" data-holder-rendered="true" />
                    <h1 class="fst-italic lh-1 mb-4"></br> Senior Citizen's ID Online Registration</h1>

                    <!--p class="mb-5">"The system is made up of two parts. The first is the Pre-Marriage Counseling Online Application, which is one of the first prerequisites before applying for a Marriage License.
                Second is the Online Pre-Application for Marriage License, which is an online profile system for bride and grooms who intend to marry in Cagayan de Oro City."</p>
                <!-- * * * * * * * * * * * * * * *-->
                    <!-- * * SB Forms Contact Form * *-->
                    <!-- * * * * * * * * * * * * * * *-->
                    <!-- This form is pre-integrated with SB Forms.-->
                    <!-- To make this form functional, sign up at-->
                    <!-- https://startbootstrap.com/solution/contact-forms-->
                    <!-- to get an API token!-->
                    <!-- Email address input-->

                    <div class="row input-group-newsletter">
                        <button runat="server" style="border-radius: 40px; font-size: 18px; font-style: italic;" href="#" class="btn btn-success btn-lg mb-2" id="btnShowNewRegistration"><b>REGISTER</b></button>
                        <button runat="server" style="border-radius: 40px; font-size: 18px; font-style: italic;" href="#" target="_blank" class="btn btn-primary btn-lg mb-2" id="btnShowUpdateRegistration"><b>CONTINUE REGISTRATION</b></button>
                        <button runat="server" style="border-radius: 40px; font-size: 18px; font-style: italic;" href="#" target="_blank" class="btn btn-danger btn-lg mb-2" id="btnShowRegistrationStatus"><b>REGISTRATION STATUS</b></button>
                        <a runat="server" style="z-index: 10; border-radius: 40px; font-size: 18px; font-style: italic;" href="#" class="btn btn-warning mb-2" id="btnShowComments"><b>COMMENTS/SUGGESTIONS</b></a>
                    </div>

                    <div class="row input-group-newsletter" style="border-radius: 16px; background-color: #bad6d7; display: none;">
                        <figure class="text-center mb-2">
                            <blockquote class="blockquote text-dark">
                                <p>For more inquiries , please call or text :</p>
                                <p><strong>COLEEN - 09069044808</strong></p>
                            </blockquote>
                            <figcaption class="text-dark" style="font-size: 21px;">Office of the Senior Citizens Affairs (OSCA)
                            </figcaption>
                            <figcaption class="text-dark" style="font-size: 16px;">City Social Welfare Department,City Hall, Cagayan de Oro City
                            </figcaption>

                        </figure>
                    </div>

                </div>

                <div class="footer">
                    <div class="container">

                        <div class="row">
                            <div class="col-md-6">
                                <div class="logo">
                                    <a href="/">
                                        <img height="70" src="Scripts/landing/assets/img/risev2.png" class="rise-logo" />
                                    </a>
                                    <a href="https://cagayandeoro.gov.ph/" target="_blank" class="btn btn-outline-warning links"><span class="lnks">Visit Official Page </span></a>
                                    <a href="https://cagayandeoro.gov.ph/index.php/news/the-city-mayor/rise1.html" target="_blank" class="btn btn-outline-primary links"><span class="lnks">Learn RISE Platform </span></a>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="logo">
                                    <span style="font-size: 12px; color: #fff">Powered by: City Management Information Systems and Innovation Department</span>
                                    <a href="/">
                                        <img height="60" src="Scripts/landing/assets/img/ICTLogo.png" class="ict-logo">
                                    </a>
                                </div>
                            </div>
                        </div>



                    </div>
                </div>
            </div>
        </div>

        <!-- Social Icons-->
        <!-- For more icon options, visit https://fontawesome.com/icons?d=gallery&p=2&s=brands-->

        <div class="social-icons">

            <div class="d-flex flex-wrap h-100 ">

                <div class="d-flex flex-lg-column justify-content-center align-items-center h-100 mt-3 mt-lg-0 ">
                    <img class="img-fluid shadow p-2 rounded img-responsive" style="filter: drop-shadow(0 0 1rem black);" src="Images/IDFront_sample.png" />
                    <img class="img-fluid shadow p-2 rounded img-responsive" style="filter: drop-shadow(0 0 1rem black);" src="Images/IDBack_sample.PNG" />
                </div>

                <div class="d-flex flex-lg-column justify-content-center align-items-center h-100 mt-3 mt-lg-0">
                </div>
            </div>

        </div>

        <%-- NEW APPLICATION --%>
        <div class="modal fade" id="mdlCaptcha" tabindex="-1" aria-hidden="true" data-bs-backdrop="static" data-bs-keyboard="false">
            <div class="modal-dialog">
                <div class="modal-content">

                    <div class="modal-header" style="background-color: lightgreen; color: black; text-align: center;">
                        <asp:Label runat="server" ID="Label18" Style="font-size: 20px;" Text="CAPTCHA"></asp:Label>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>

                    <div class="modal-body">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="container-fluid img-responsive" align="center">
                                    <site:Captcha runat="server" ID="Captcha3" EnableClientScript="true" ValidationGroup="SubmitInfo" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button runat="server" class="btn btn-success btn-lg mb-2" id="btnContinueCaptcha" validationgroup="SubmitInfo">Continue</button>
                    </div>
                </div>

            </div>

        </div>


        <%-- UPDATE APPLICATION --%>

        <div class="modal fade" id="mdlSeniorUpdate" tabindex="-1" aria-hidden="true" data-bs-backdrop="static" data-bs-keyboard="false">
            <div class="modal-dialog">
                <div class="modal-content">

                    <div class="modal-header" style="background-color: #0d6efd; color: white; text-align: center;">
                        <asp:Label runat="server" ID="Label1" Style="font-size: 20px;" Text="Continue Registration"></asp:Label>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>

                    <div class="modal-body">

                        <div class="row">
                            <div class="col-md-12 mb-2">
                                <asp:Label runat="server" ID="Label5">Reference Code</asp:Label>
                                <asp:TextBox runat="server" ID="txtUpdateRefCode" CssClass="input-field form-control" Style="text-transform: uppercase" MaxLength="10" placeholder="Enter Reference Code"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12 mb-2">
                                <div class="container-fluid img-responsive" align="center">
                                    <site:Captcha runat="server" ID="Captcha1" EnableClientScript="true" ValidationGroup="SubmitUpdate" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button runat="server" class="btn btn-success btn-lg mb-2" id="btnContinueUpdate" validationgroup="SubmitUpdate">Continue</button>
                    </div>
                </div>

            </div>

        </div>


        <%-- REGISTRATION STATUS --%>


        <%-- RETRIEVE --%>
        <div class="modal fade" id="mdlSeniorStatus" tabindex="-1" aria-hidden="true" data-bs-backdrop="static" data-bs-keyboard="false">
            <div class="modal-dialog">
                <div class="modal-content">

                    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                        <ContentTemplate>
                            <div class="modal-header bg-danger text-light" style="text-align: center;">
                                <asp:Label runat="server" ID="Label8" Style="font-size: 20px;" Text="Continue Registration"></asp:Label>
                                <button type="button" id="btnMdlStatusClose" class="btn-close text-light" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>

                            <div class="modal-body">

                                <div class="row">
                                    <div class="col-md-12 mb-2">
                                        <asp:Label runat="server" ID="Label9">Reference Code</asp:Label>
                                        <asp:TextBox runat="server" ID="txtStatusRefCode" CssClass="input-field form-control" Style="text-transform: uppercase" MaxLength="10" placeholder="Enter Reference Code"></asp:TextBox>
                                    </div>
                                </div>



                                <div class="row">
                                    <div class="col-md-12 mb-2">
                                        <div class="container-fluid img-responsive" align="center">
                                            <site:Captcha runat="server" ID="Captcha2" EnableClientScript="true" ValidationGroup="SubmitStatus" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" runat="server" class="btn btn-success btn-lg mb-2" id="btnContinueStatus" validationgroup="SubmitStatus">Retrieve</button>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

            </div>

        </div>


        <%-- STATUS DETAILS --%>

        <asp:UpdatePanel runat="server" ID="UpdatePanel2">
            <ContentTemplate>

                <div class="modal fade" id="mdlSeniorStatusDetails" data-bs-backdrop="static" data-bs-keyboard="false">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header" style="background-color: #0d6efd; color: white; text-align: center;">
                                <div class="col-lg-8">
                                    <span runat="server" style="font-size: 20px; text-align: center;" class="float-end" align="center">Registration Status</span>
                                </div>
                                <div class="col-lg-4">
                                    <button type="button" class="btn-close float-end" data-bs-dismiss="modal" aria-label="Close"></button>
                                </div>

                            </div>
                            <div class="modal-body">

                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="input-group mb-3">
                                            <span class="input-group-text bg-light text-dark">Reference #: </span>
                                            <asp:TextBox runat="server" ID="txtStatusDetailsRefCode" CssClass="input-field form-control" Style="text-transform: uppercase; background-color: white;" placeholder="" ReadOnly="true"></asp:TextBox>

                                        </div>

                                    </div>
                                </div>


                                <div class="row">
                                    <div class="col-lg-12   ">
                                        <div class="input-group mb-3">
                                            <span class="input-group-text bg-light text-dark">Name: </span>
                                            <asp:TextBox runat="server" ID="txtStatusDetailsName" CssClass="input-field form-control" Style="text-transform: uppercase; background-color: white;" placeholder="" ReadOnly="true"></asp:TextBox>

                                        </div>

                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-lg-12   ">
                                        <div class="input-group mb-3">
                                            <span class="input-group-text bg-light text-dark">BDate: </span>
                                            <asp:TextBox runat="server" ID="txtStatusDetailsBdate" CssClass="input-field form-control" Style="text-transform: uppercase; background-color: white;" placeholder="" ReadOnly="true"></asp:TextBox>

                                        </div>

                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-lg-12   ">
                                        <div class="input-group mb-3">
                                            <span class="input-group-text bg-light text-dark">Status: </span>
                                            <asp:TextBox runat="server" ID="txtStatusDetails" CssClass="input-field form-control" Style="text-transform: uppercase; background-color: white;" placeholder="" ReadOnly="true"></asp:TextBox>

                                        </div>

                                    </div>
                                </div>

                                 <div class="row">
                                    <div class="col-lg-12   ">
                                        <div class="input-group mb-3">
                                            <span class="input-group-text bg-light text-dark">Remarks: </span>
                                            <asp:TextBox runat="server" ID="txtStatusRemarks" CssClass="input-field form-control" TextMode="MultiLine" Rows="2" Style="text-transform: uppercase; background-color: white;" placeholder="" ReadOnly="true"></asp:TextBox>

                                        </div>

                                    </div>
                                </div>


                            </div>
                            <div class="modal-footer">
                                <button runat="server" class="btn btn-danger btn-lg mb-2" id="Button1" data-bs-dismiss="modal" causesvalidation="false">Close</button>
                            </div>
                        </div>
                    </div>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>


        <%-- MODAL COMMENTS DETAILS --%>

        <div class="modal fade" id="mdlComment" tabindex="-1" aria-hidden="true" data-bs-backdrop="static" data-bs-keyboard="false">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">

                    <asp:UpdatePanel runat="server" ID="UpdatePanel3">
                        <ContentTemplate>

                            <div class="modal-header bg-warning text-dark" style="text-align: center;">
                                <i class="fa-regular fa-comment-dots fa-2x" style="color: black;"></i>
                                <asp:Label runat="server" ID="Label2" Style="font-size: 20px;" Text="Comments/Suggestions"></asp:Label>
                                <button type="button" class="btn-close text-light" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>

                            <div class="modal-body">

                                <div class="row">
                                    <div class="col-md-12 mb-2">
                                        <div class="input-group">
                                            <span class="input-group-text" style="background-color: white; color: black; border-style: solid; border-color: black">Name :  </span>
                                            <asp:TextBox runat="server" ID="txtCommentName" CssClass="input-field form-control" Style="text-transform: uppercase" BorderColor="Black" BorderStyle="Solid" placeholder="Enter Name"></asp:TextBox>
                                        </div>

                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCommentName"
                                            SetFocusOnError="true" Font-Bold="true" Font-Size="16pt" Display="dynamic" Text="*" InitialValue="0" ValidationGroup="DOCCOM" />
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-12 mb-2">
                                        <div class="input-group">
                                            <span class="input-group-text" style="background-color: white; color: black; border-style: solid; border-color: black">Contact No. :  </span>
                                            <asp:TextBox runat="server" ID="txtCommentContact" MaxLength="11" CssClass="input-field form-control" Style="text-transform: uppercase" BorderColor="Black" BorderStyle="Solid" placeholder="Enter Contact Number"></asp:TextBox>
                                        </div>

                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCommentContact"
                                            SetFocusOnError="true" Font-Bold="true" Font-Size="16pt" Display="dynamic" Text="*" InitialValue="0" ValidationGroup="DOCCOM" />
                                        <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator1" ControlToValidate="txtCommentContact" Font-Bold="true" Font-Italic="true" Font-Size="10pt" SetFocusOnError="true" ErrorMessage="Only numbers allowed" Display="Dynamic" ValidationExpression="^\d+$" ValidationGroup="DOCCOM"></asp:RegularExpressionValidator>
                                        <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator4" ControlToValidate="txtCommentContact" Font-Bold="true" Font-Italic="true" Font-Size="10pt" SetFocusOnError="true" ErrorMessage="Invalid Contact no." Display="Dynamic" ValidationExpression="^(?:\d{2}-\d{3}-\d{3}-\d{3}|\d{11})$" ValidationGroup="DOCCOM"></asp:RegularExpressionValidator>
                                    </div>
                                </div>


                                <div class="row">
                                    <div class="col-md-12 mb-2">
                                        <div class="input-group">
                                            <span class="input-group-text" style="background-color: white; color: black; border-style: solid; border-color: black">Comments/Suggestions : 
                                               
                                            </span>
                                            <asp:TextBox runat="server" ID="txtComments" TextMode="MultiLine" Rows="7" CssClass="input-field form-control" Style="text-transform: none;" BorderColor="Black" BorderStyle="Solid" placeholder="Enter Comments" onKeyUp="CheckTextLength(this,500)" onChange="CheckTextLength(this,500)"></asp:TextBox>
                                        </div>

                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtComments"
                                            SetFocusOnError="true" Font-Bold="true" Font-Size="16pt" Display="dynamic" Text="*" InitialValue="0" ValidationGroup="DOCCOM" />
                                    </div>

                                    <div class="col-md-12">
                                        <p id="lblCharCount" class="float-end" style="font-size: 12px;">500</p>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-12 mb-2">
                                        <div class="container-fluid img-responsive" align="center">
                                            <site:Captcha runat="server" ID="Captcha4" EnableClientScript="true" ValidationGroup="DOCCOM" />
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <div class="modal-footer">
                                <button runat="server" class="btn btn-success btn-lg mb-2" id="btnContinueComments" validationgroup="DOCCOM"><i class="fa-regular fa-paper-plane fa-1x"></i>&nbsp;Submit</button>
                                <button type="button" id="Button4" runat="server" class="btn btn-danger " data-bs-dismiss="modal"><i class="fa-regular fa-circle-xmark fa-1x"></i>&nbsp;Cancel</button>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

            </div>

        </div>

        <asp:UpdatePanel runat="server" ID="upUpdate">
            <ContentTemplate>

                <wucConfirmBox:wucConfirmBox runat="server" ID="thisMsgBox" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>


</body>
</html>
