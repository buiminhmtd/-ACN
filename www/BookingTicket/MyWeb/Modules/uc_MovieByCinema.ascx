<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_MovieByCinema.ascx.cs" Inherits="MyWeb.Modules.uc_MovieByCinema" %>
<div class="section-title">
    <span class="title">SHOWTIME</span>
    <div class="action" id="filter-theater">
        Filter
        <asp:DropDownList ID="ddlCinama" runat="server"></asp:DropDownList>
    </div>
</div>
<div id="list-theater">
    <asp:Repeater runat="server" ID="rptShowTime" OnItemCommand="rptShowTime_ItemCommand">
        <ItemTemplate>
            <div class="block-half left">
                <div class="group">
                    <div class="group-title">
                        <asp:Label ID="lblAdd" runat="server" Text='<%# Eval("NameCi") %>' CssClass="title"></asp:Label>
                        <br>
                        <div class="support-text">
                            <asp:Label ID="lblAddress" runat="server" Text='<%# Eval("Address") %>'></asp:Label>
                        </div>
                    </div>
                    <div class="sessions">
                        <a class="showtime s1">
                            <asp:Label ID="lblShowTime" runat="server" Text='<%# MyWeb.Common.DateTimeClass.ConvertDate(Eval("ShowTime").ToString())%>'></asp:Label>
                        </a>
                        <a class="showtime s1">
                            <asp:Label ID="lblTime" runat="server" Text='<%# Eval("Time") %>'></asp:Label>
                        </a>
                        <a class="showtime s1">
                            <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Price","{0:0,0}") %>'></asp:Label>
                        </a>
                    </div>
                    <div class="sessions" style="float: right">
                        <asp:LinkButton ID="lbtTickets" runat="server" CssClass="showtime s1" CommandName="tickets" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ShoId")%>'>BOOK TICKETS HERE</asp:LinkButton>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
<div class="group inline">
    <div class="group-title">
        <span class="title">MAY INTEREST YOU</span>
    </div>
    <asp:Repeater runat="server" ID="rptMovie">
        <ItemTemplate>
            <div class="block-base movie">
                <asp:HyperLink ID="hlMoviePicture" runat="server" CssClass="poster" NavigateUrl='<%# String.Format("~/Detail.aspx?&id={0}", Eval("FilId")) %>'>
                    <asp:Image ID="Imagethumb" runat="server" Width="157" Height="224" ImageUrl='<%# Eval("Picture") %>' CssClass="thumb" />
                    <div class="tag new"></div>
                </asp:HyperLink>
                <div class="rating"><span class="rate">8.1</span><span class="desc">IMDb</span></div>
                <asp:HyperLink ID="hlNameFilm" runat="server" Text='<%# Eval("NameF") %>' CssClass="film-name" NavigateUrl='<%# String.Format("~/Detail.aspx?&id={0}", Eval("FilId")) %>'></asp:HyperLink>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>