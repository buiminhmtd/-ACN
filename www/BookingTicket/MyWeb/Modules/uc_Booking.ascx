<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_Booking.ascx.cs" Inherits="MyWeb.Modules.uc_Booking" %>
<script type="text/javascript">
    function ValidateKeypress(numcheck, e) {
        var keynum, keychar, numcheck;
        if (window.event) {//IE
            keynum = e.keyCode;
        }
        else if (e.which) {// Netscape/Firefox/Opera
            keynum = e.which;
        }
        if (keynum == 8 || keynum == 127 || keynum == null || keynum == 9 || keynum == 0 || keynum == 13) return true;
        keychar = String.fromCharCode(keynum);
        var result = numcheck.test(keychar);
        return result;
    }
</script>
<div id="banner">
    <asp:Image ID="Imagethumb" runat="server" Width="980" Height="380" />
    <asp:LinkButton ID="lblOrder" runat="server" CssClass="action gray btn" OnClick="lblOrder_Click">BOOK TICKETS HERE</asp:LinkButton>
</div>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>

        <div id="banner-box">
            <div class="title film-name">
                <asp:Label ID="lblNameCinema" runat="server" ForeColor="#f47c26"></asp:Label><br/>
                <span style="font-size: 10px; text-transform: none;">(<asp:Label ID="lblAddress" runat="server"></asp:Label>)</span>
            </div>
            <div class="info scroll-pane jspScrollable" style="overflow: hidden; padding: 0px; width: 280px;" tabindex="0">

                <div class="jspContainer" style="width: 280px; height: 270px;">
                    <div class="scroll-pane" style="padding: 0px; width: 266px; top: -23px;">
                        <br />
                        <div>
                            <strong>Film</strong>
                            <span>
                                <asp:Label ID="lblFilm" runat="server"></asp:Label>
                            </span>
                        </div>
                        <div>
                            <strong>Duration</strong>
                            <span>
                                <asp:Label ID="lblDuration" runat="server"></asp:Label>
                            </span>
                        </div>
                        <div>
                            <strong>Show Time</strong>
                            <span>
                                <asp:Label ID="lblShowtime" runat="server"></asp:Label>
                            </span>
                        </div>
                        <div>
                            <strong>Time</strong>
                            <span>
                                <asp:Label ID="lblTime" runat="server"></asp:Label>
                            </span>
                        </div>
                        <div>
                            <strong>Price</strong>
                            <span>
                                <asp:Label ID="lblPrice" runat="server"></asp:Label>
                            </span>
                        </div>
                        <div style="padding-top: 10px; padding-left: 75px;">
                            <strong></strong>
                            <asp:TextBox ID="txtNumber" runat="server" CssClass="select-fi" placeholder="Number People" onkeypress="return ValidateKeypress(/\d/,event);" OnTextChanged="txtNumber_TextChanged">1</asp:TextBox>
                            <span style="font-size: 10px; text-transform: none;">(Enter update price)</span>
                        </div>
                        <div>
                            <strong>Tickets</strong>
                            <span style="float: none; text-align: center">
                                <asp:Label ID="lblNumbertickets" runat="server" Width="65px"></asp:Label>
                                <asp:Label ID="Label1" runat="server" Text="/" Width="20px"></asp:Label>
                                <asp:Label ID="lblSeats" runat="server" Width="65px"></asp:Label>
                            </span>
                        </div>
                    </div>
                </div>
            </div>
            <div class="social">
                Total : 
        <asp:Label ID="lblTotal" runat="server" ForeColor="#f47c26"></asp:Label>&nbsp; &nbsp; &nbsp; 
                <asp:Label ID="lblMessage" runat="server" ForeColor="red"></asp:Label>
            </div>
        </div>
    </ContentTemplate>


</asp:UpdatePanel>
