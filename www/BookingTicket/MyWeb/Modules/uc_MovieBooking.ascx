<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_MovieBooking.ascx.cs" Inherits="MyWeb.Modules.uc_MovieBooking" %>
<div class="group inline">
    <div id="search-tabs">
        <ul class="tab">
            <li class="activeTab"><a href="#">Detail Movie</a></li>
            <li><a href="#">Comment</a></li>
        </ul>
        <div class="tab-content">
            <asp:Label ID="lblDetail" runat="server"></asp:Label>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1Comment" runat="server">
            <ContentTemplate>
                <div class="tab-content">
                    <div style="float: left; width: 50%; padding-right: 5px;">
                        <div class="group">
                            <div class="group-title">
                                <span class="title">Comment</span>
                            </div>
                            <div id="comment123f">
                                <div>
                                    <ul class="comment-list">
                                        <asp:Repeater runat="server" ID="RptComment">
                                            <ItemTemplate>
                                                <li>
                                                    <asp:Image ID="imgImageA" runat="server" ImageAlign="Middle" CssClass="avatar" Width="50" Height="50" ImageUrl='<%#Eval("Avata") %>'/>
                                                    <div class="date">
                                                        <asp:Label ID="lblCreated" runat="server" Text='<%# Eval("Created") %>'></asp:Label>
                                                    </div>
                                                    <div class="name">
                                                        <asp:Label ID="lblName" runat="server" Text='<%# Eval("FullName") %>'></asp:Label>
                                                    </div>
                                                    <div class="text">
                                                        <asp:Label ID="lblContent" runat="server" Text='<%# Eval("Comment") %>'></asp:Label>
                                                    </div>
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                    <asp:Image ID="imgImage" runat="server" ImageAlign="Middle" CssClass="image_avata" />
                                    <div class="box clearfix">
                                        <asp:TextBox ID="txtConten" runat="server" TextMode="MultiLine" placeholder="Your opinion ..." CssClass="textarea"></asp:TextBox>
                                        <asp:Button ID="btnSend" runat="server" Text="Comment" CssClass="btnSearch" OnClick="btnSend_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div style="float: right; width: 50%; padding-right: 5px;">
                        <div class="group">
                            <div class="group-title">
                                <span class="title">List Comment</span>
                            </div>
                            <div>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</div>
