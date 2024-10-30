<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_MovieHome.ascx.cs" Inherits="MyWeb.Modules.uc_MovieHome" %>
<div class="group inline">
    <div class="group-title">
        <span class="title">
            <a href="#">MOVIES PLAYING</a>
        </span>
        <span class="action">
            <a href="../Movie.aspx" class="viewmore">View all</a>
        </span>
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
