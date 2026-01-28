<%@ Control Language="VB" AutoEventWireup="false" CodeFile="sFooterAdmin.ascx.vb" Inherits="Include_sFooterAdmin" %>

<link href="<%=ResolveClientUrl("~/Scripts/mycss/footerStyleAdmin.css")%>" rel="stylesheet" />

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


<div class="col-md-12 site-footer footer" runat="server" id="siteFooter">
    <div class="col-md-6" style="padding: 0px 25px 0px 25px;">
        <div class="img-container">
        </div>
        <br style="clear: both;" />
        <div class="client-info">

            <%--SYSTEM ABOUT--%>
            <%--<img src="<%=ResolveClientUrl("~/Images/clenro.png")%>" alt="CLENRO Logo" width="50" />--%>

            <h3>TAX RELIEF APPLICATION</h3>
            <br />
            <p>
                <%--First Description --%>  <span id="dots">...</span>

                <span id="more">
                    <%-- Additional Description
                          <br />--%>
                    <br />
                    <strong>Developed by:</strong> CMISID Team - Zelfred Anthony T. Cocon / Noel S. Moreno
                </span>
            </p>



            <button type="button" onclick="myFunction()" id="myBtn">Read more</button>
            <hr />
            <%--CMISID VISSION MISSION--%>
            <h3 style="color: #565656; font-size: 14px">CITY MANAGEMENT INFORMATION SYSTEMS AND INNOVATION DEPARTMENT</h3>
            <br />
            <p>
                <strong>Vision:</strong> A highly competitive information and Communications Technology driven City Government.
                <br />
                <br />
                <strong>Mission:</strong> To serve the city Government of Cagayan de Oro by providing a reliable, accurate and efficient ICT solutions and services while continuously innovates technology to meet the needs of our clients and stakeholders.
            </p>

        </div>
        <div class="socmed-info">
        </div>
    </div>

    <div class="col-xs-6 col-md-3 other-systems" runat="server" id="divRS" style="padding: 0px 10px 0 10px">
        <h6>other Related System(s)</h6>
        <ul class="footer-links">

        <%--    <li><a href="https://clenro.cagayandeoro.gov.ph/" target="_blank">CLENRO Website</a></li>
            <li><a href="https://services.cagayandeoro.gov.ph/cemeteryregistry/" target="_blank">Cemetery Registry</a></li>--%>

            <br />

            <li runat="server" id="liHelpdesk">If you have issues encountered and inquiries:<a href="https://services.cagayandeoro.gov.ph/helpdesk/" target="_blank">
                <br />
                CMISID Helpdesk</a></li>
        </ul>
    </div>

    <div class="col-xs-6 col-md-3 other-systems" id="divSealLogo" style="padding: 0px 10px 0 10px">

        <div class="col-xs-12 col-md-12">
            <div class="brand-container">
                <asp:Image runat="server" ImageUrl="~/Images/seallogo.png" Style="float: left" />
            </div>
            <a runat="server" href="https://cagayandeoro.gov.ph/" target="_blank">
                <div class='link' name='link' style="float: right;">Visit Official Website</div>
            </a>
        </div>
        <div class="col-xs-12 col-md-12">
            <div class="brand-container">
                <asp:Image runat="server" ImageUrl="~/Images/rise.png" />
            </div>
            <a runat="server" href="https://cagayandeoro.gov.ph/index.php/news/the-city-mayor/rise1.html" target="_blank">
                <div class='link2' name='link2' style="float: right;">Learn RISE Platform</div>
            </a>
        </div>

    </div>


    <div class="col-md-12 container-fluid">
        <hr />

        <div class="col-md-12 col-sm-12 col-xs-12" style="text-align: center">
            <div class="">

                <asp:Image runat="server" ImageUrl="~/Images/ICTLogo.png" Style="height: 40px" />
            </div>
            <div>
                <span style="padding-left: 10px;">Powered by: City Management Information Systems and Innovation Department</span><br>

                <div class="fb-like" data-href="https://www.facebook.com/City-Management-Information-Systems-Office-LGU-CdeO-568493593557935/" data-width="" data-layout="button_count" data-action="like" data-size="small" data-show-faces="false" data-share="true"></div>
            </div>
        </div>
        <%-- <div class="col-md-1 col-sm-6 col-xs-12 version" style="padding-left: 25px; padding-right: 25px">
           
        </div>--%>
    </div>




</div>
