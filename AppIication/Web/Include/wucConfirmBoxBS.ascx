<%@ Control Language="VB" AutoEventWireup="false" CodeFile="wucConfirmBoxBS.ascx.vb" Inherits="Include_wucConfirmBoxBS" %>
&nbsp;&nbsp;
 
 <asp:HiddenField runat="server" ID="hfModalType" />

<!-- PENDING BOX -->
<div id="pnlPending2" class="modal fade" data-backdrop="static" data-keyboard="false">
    <div class="modal-dialog">

        <!-- Modal content-->
        <div class="modal-content">
           <%-- <asp:UpdatePanel ID="updatePanel6" runat="server">
                <ContentTemplate>--%>
                    <div class="modal-header" style="text-align: center; font-weight: bold; font-size: large; color: black" runat="server" id="divHeader">
                        <asp:Label runat="server" ID="lblMsgBoxHeader" Style="font-size: x-large; font-weight: bold" Text="CONFIRMATION"></asp:Label>
                      <button type="button" class="close" data-dismiss="modal">&times;</button>
                    </div>
                    <div class="modal-body" style="padding: 10px 10px;">

                        <div class="form-group">
                            <div class="form-group">
                                <div class="input-group">
                                    <asp:Label runat="server" ID="lblMsgBoxMessage" Style="font-size: x-large" Text="Are you sure you want to save this record?"></asp:Label>
                                    <br />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">

                        <button type="button" id="btnMsgBoxYes" runat="server" class="btn btn-primary" data-dismiss="modal"><span class="glyphicon glyphicon-ok"></span>&nbsp;Yes</button>&nbsp;&nbsp;&nbsp;
                <button type="button" id="btnMsgBoxNo" runat="server" class="btn btn-danger " data-dismiss="modal"><span class="glyphicon glyphicon-remove"></span>&nbsp;No</button>
                    </div>
               <%-- </ContentTemplate>
            </asp:UpdatePanel>--%>
        </div>

    </div>

</div>
<!-- PENDING BOX -->
