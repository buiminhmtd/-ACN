<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_Banner.ascx.cs" Inherits="MyWeb.Modules.uc_Banner" %>
<div id="banner">
    <div class="neoslideshow">
        <asp:Repeater runat="server" ID="RepeaterSlide">
            <ItemTemplate>
                <%--<asp:HyperLink ID="hlPicture" runat="server" NavigateUrl='<%# String.Format("~/Detail.aspx?&id={0}", Eval("FilId")) %>'>--%>
                    <asp:Image ID="Image" runat="server" ImageUrl='<%# Eval("Image") %>' />
               <%--</asp:HyperLink>--%>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
<div id="banner-box" class="block-review">
    <div class="group-title">
        <span class="title">
            <a>LIST MOVIE</a>
        </span>
        <span class="action">
            <a href="../Movie.aspx">View All</a>
        </span>
    </div>
    <div class="block-secondary">
        <asp:Repeater runat="server" ID="rptMovie">
            <ItemTemplate>
                <div class="list-small">
                    <a class="thumb" href="#">
                        <asp:Image ID="Imagethumb" runat="server" Width="40" Height="50" ImageUrl='<%# Eval("Picture") %>' />
                        <span class="stag review"></span>
                    </a>
                    <asp:HyperLink ID="hlNameFilm" runat="server" Text='<%# Eval("NameF") %>' CssClass="name" NavigateUrl='<%# String.Format("~/Detail.aspx?&id={0}", Eval("FilId")) %>'></asp:HyperLink>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
