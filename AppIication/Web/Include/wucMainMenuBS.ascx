<%@ Control Language="VB" AutoEventWireup="false" CodeFile="wucMainMenuBS.ascx.vb" Inherits="Include_wucMainMenuBS" %>

<link href="../Scripts/bootstrap/css/bootstrap.min.css" rel="stylesheet" />


<style type="text/css">
    .navbar {
        margin-top: 20px;
    }
</style>

<div class="row" runat="server" id="rwMenu">
                <nav class="navbar navbar-default">
                    <div class="container-fluid">
                        <div class="navbar-header">
                            <button runat="server" type="button" id="btnNavTogggle" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
                                <span class="icon-bar"></span>
                                <span class="icon-bar"></span>
                                <span class="icon-bar"></span>
                            </button>
                        </div>

                        <div class="collapse navbar-collapse" id="myNavbar">
                            <ul class="nav navbar-nav " runat="server" id="navMenu">

                            </ul>
                        </div>
                    </div>
                </nav>
            </div>


 <%--   <ul class="nav navbar-tabs " runat="server" id="navMenu">
        
    </ul>
--%>



