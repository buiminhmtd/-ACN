<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_Cinema.ascx.cs" Inherits="MyWeb.Modules.uc_Cinema" %>
<div class="group">
    <div class="group-title">
        <span class="title">CINEMA</span>
    </div>
    <div class="cinema-list" id="cinema-index-list">
        <asp:Repeater runat="server" ID="rptCinema">
            <ItemTemplate>
                <div class="block-secondary news">
                    <a class="thumbnail">
                        <asp:Image ID="Imagethumb" runat="server" ImageUrl='<%# Eval("Image") %>'/>
                    </a>
                    <a class="news-name">
                        <asp:Label ID="lblName" runat="server" Text='<%# Eval("NameCi") %>'></asp:Label>
                    </a>
                    <p>Address: </p>
                        <asp:Label ID="lblAddress" runat="server" Text='<%# Eval("Address") %>'></asp:Label><br/>
                    <p>Phone: </p>
                        <asp:Label ID="lblPhone" runat="server" Text='<%# Eval("Phone") %>'></asp:Label><br/>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
