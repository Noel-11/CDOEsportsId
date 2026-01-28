<%@ Control Language="VB" AutoEventWireup="false" CodeFile="sFooter.ascx.vb" Inherits="Include_sFooter" %>

<link href="<%=ResolveClientUrl("~/Scripts/mycss/footerStyle.css")%>" rel="stylesheet" />

<div id="fb-root"></div>
<script async defer crossorigin="anonymous" src="https://connect.facebook.net/en_LA/sdk.js#xfbml=1&version=v3.3"></script>


<style>
    .site-footer {
        background-color: #e7e7e7;
    }



    #more {
        display: none;
    }

    /*body {
        background-color: #e7e7e7 !important;
    }*/
</style>

<script>
    function myFunction() {
        var dots = document.getElementById("dots");
        var moreText = document.getElementById("more");
        var btnText = document.getElementById("myBtn");
        if (dots.style.display === "none") {
            dots.style.display = "inline";
            btnText.innerHTML = "Read more";
            moreText.style.display = "none";
        } else {
            dots.style.display = "none";
            btnText.innerHTML = "Read less";
            moreText.style.display = "inline";
        }
    }
</script>


<div class="container-fluid" style="padding: 0 11px;">
    <div class="row">
        <div class="col-md-12 position-relative footerC">
            <footer class="site-footer">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-sm-12 col-md-6 mt-2">
                            <div class="client-info">
                               <%-- <img src="<%=ResolveClientUrl("~/Images/clenro.png")%>" alt="CLENRO Logo" width="50" />--%>

                                <h3>SENIOR CITIZEN'S ID ONLINE REGISTRATION</h3>
                                <p>The Online Senior Citizen ID Application System offers a convenient, quick, and accessible way for Senior Citizens
                                    <span id="dots" style="display: block">...</span>
                                    <span id="more"> to apply for their identification card without visiting the City Social Welfare and Development Office in person. Through this platform, applicants can easily enter their details, upload the necessary documents, and monitor the progress of their application.
                                        <br />
                                        <br />
                                        
                                    </span>
                                </p>
                                <button type="button" id="myBtn" onclick="myFunction()">Read more</button>
                                <h5 class="pb-3 fs-5">CITY SOCIAL WELFARE DEVELOPMENT</h5>
                                <p>
                                    <%--<strong>Vision:</strong> Shall be the most highly competitive ICT organization in the City Government of Cagayan de Oro.
                                    <br />
                                    <br />
                                    <strong>Mission:</strong> To serve the City Government of Cagayan de Oro by providing a reliable, accurate and efficient ICT solutions and services while continuously innovates technology to meet the needs of our clients and stakeholders.
                                     --%>
                                    <strong>Office of the Senior Citizens Affair</strong>
                                    <br />
                                    <br />
                                    <strong>Developed by:</strong> CMISID Team | QA - TIN | DEVELOPER - NOEL
                                </p>
                            </div>
                        </div>
                        <div class="col-xs-6 col-md-3 other-systems">
                            <h6>other Related Systems</h6>
                            <ul class="footer-links">
                               <%-- <li><a class="text-primary" href="https://clenro.cagayandeoro.gov.ph/" target="_blank">CLENRO Website</a></li>
                                <li><a class="text-primary" href="https://services.cagayandeoro.gov.ph/cemeteryregistry/clientmain.aspx" target="_blank">Cemetery Registry</a></li>--%>
                                <li><span>If you have issues encountered and inquiries</span></li>
                                <li><a class="text-primary" href="https://services.cagayandeoro.gov.ph/helpdesk" target="_blank">CMISID Helpdesk</a></li>
                            </ul>
                        </div>
                        <div class="col-xs-6 col-md-3 other-systems image-block">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="brand-container">
                                        <asp:Image runat="server" ImageUrl="~/Images/seallogo.png" class="w-70" Style="float: left" />

                                    </div>
                                    <a href="https://cagayandeoro.gov.ph/" target="_blank" class='link' name='link' style="float: right;color: black;font-weight: 400;">Visit Official Website</a>
                                </div>
                                <div class="col-md-12">
                                    <div class="brand-container">
                                        <asp:Image runat="server" ImageUrl="~/Images/rise.png" />
                                    </div>
                                    <a href="https://cagayandeoro.gov.ph/index.php/news/the-city-mayor/rise1.html" target="_blank" class='link2' name='link2' style="float: right;color: white;font-weight: 400;">Learn RISE Platform</a>
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-12 footer-separator"></div>
                    </div>
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-md-11 col-sm-6 col-xs-12">

                                <div class="d-flex justify-content-center">
                                    <div>
                                        <asp:Image runat="server" ImageUrl="~/Images/ICTLogo.png" Style="height: 40px" />
                                    </div>
                                    <div>
                                        <span style="padding-left: 10px;">Powered by: City Management Information Systems and Innovation Department</span><br>
                                        <span>&nbsp;&nbsp;
                                            <div class="fb-like fb_iframe_widget" data-href="https://www.facebook.com/City-Management-Information-Systems-Office-LGU-CdeO-568493593557935/" data-width="" data-layout="button_count" data-action="like" data-size="small" data-share="true" data-show-faces="false"></div>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-1 col-sm-6 col-xs-12 version">
                                Version 2.0
                            </div>
                        </div>
                    </div>
                </div>
            </footer>
        </div>
    </div>
</div>
