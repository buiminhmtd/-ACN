<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_Detail.ascx.cs" Inherits="MyWeb.Modules.uc_Detail" %>

<div id="banner">
    <asp:Image ID="Imagethumb" runat="server" Width="980" Height="380" />
    <%--<a href="#" class="action gray btn">BOOK TICKETS HERE</a>--%>
</div>
<div id="banner-box">
    <div class="title film-name">
        <div class="rating">
            8.1<br>
            <span>IMDb</span>
        </div>
        <asp:Label ID="lblName" runat="server" ForeColor="#f47c26"></asp:Label>
    </div>
    <div class="info scroll-pane jspScrollable" style="overflow: hidden; padding: 0px; width: 280px;" tabindex="0">
        <div class="jspContainer" style="width: 280px; height: 270px;">
            <div class="scroll-pane" style="padding: 0px; width: 266px; top: -23px;">
                <%--<div>
                    <strong>ShowTime</strong>
                    <span>
                        <asp:Label ID="lblShowTime" runat="server"></asp:Label>
                    </span>
                </div>--%>
                <div>
                    <strong>Director</strong>
                    <span>
                        <asp:Label ID="lblDirector" runat="server"></asp:Label>
                    </span>
                </div>
                <div>
                    <strong>Actor</strong>
                    <span>
                        <asp:Label ID="lblActor" runat="server"></asp:Label>
                    </span>
                </div>
                <div>
                    <strong>Duration</strong>
                    <span>
                        <asp:Label ID="lblDuration" runat="server"></asp:Label>
                    </span>
                </div>
                <div>
                    <strong>Genre</strong>
                    <span>
                        <a href="#">
                            <asp:Label ID="lblTypeFilm" runat="server"></asp:Label>
                        </a>
                    </span>
                </div>
                <div>
                    <strong>Country</strong>
                    <span>
                        <asp:Label ID="lblCountry" runat="server"></asp:Label>
                    </span>
                </div>
                <p>
                    <asp:Literal ID="ltDescription" runat="server"></asp:Literal>
                </p>
            </div>
        </div>
    </div>
</div>
