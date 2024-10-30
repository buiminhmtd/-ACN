<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_Booking.ascx.cs" Inherits="MyWeb.Admin.Modules.uc_Booking" %>
<div class="PageName">
    Booking</div>
<asp:Panel ID="pnView" runat="server">
    <div class="Control">
        <ul>
            <li>
                <asp:LinkButton CssClass="vdelete" ID="lbtDeleteT" runat="server" OnClick="lbtDeleteT_Click">Delete</asp:LinkButton></li>
            <li>
                <asp:LinkButton CssClass="vrefresh" ID="lbtRefreshT" runat="server">Refresh</asp:LinkButton></li>
            <li><a class="vback" href="javascript:void(0);" onclick="window.history.go(-1);">Back</a> </li>
        </ul>
    </div>
    <asp:DataGrid ID="grdBooking" runat="server" Width="100%" CssClass="TableView" AutoGenerateColumns="False" AllowPaging="True" PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Center" BorderStyle="Solid" OnItemCommand="grdBooking_ItemCommand" OnItemDataBound="grdBooking_ItemDataBound" OnPageIndexChanged="grdBooking_PageIndexChanged">
        <HeaderStyle CssClass="trHeader"></HeaderStyle>
        <ItemStyle CssClass="trOdd"></ItemStyle>
        <AlternatingItemStyle CssClass="trEven"></AlternatingItemStyle>
        <Columns>
            <asp:TemplateColumn ItemStyle-CssClass="tdCenter">
                <HeaderTemplate>
                    <asp:CheckBox ID="chkSelectAll" runat="server" AutoPostBack="False"></asp:CheckBox>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="chkSelect" runat="server"></asp:CheckBox>
                </ItemTemplate>
                <ItemStyle CssClass="tdCenter"></ItemStyle>
            </asp:TemplateColumn>
            <asp:BoundColumn DataField="BooId" HeaderText="Id" Visible="False" />
            <asp:BoundColumn DataField="Status" HeaderText="Status" Visible="False" />
            <asp:TemplateColumn HeaderText="Customer">
                <ItemTemplate>
                    <asp:Label ID="grdLblCusId" runat="server" Text='<%#(Eval("FullName").ToString())%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px" />
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Address">
                <ItemTemplate>
                    <asp:Label ID="grdLblQuantity" runat="server" Text='<%#(Eval("Address").ToString())%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px" />
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Date Booking">
                <ItemTemplate>
                    <asp:Label ID="grdLblShoId" runat="server" Text='<%#MyWeb.Common.DateTimeClass.ConvertDateTime(Eval("DateBooking").ToString(),"dd/MM/yyyy")%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px" />
            </asp:TemplateColumn>
            <asp:TemplateColumn ItemStyle-CssClass="Activehead">
                <HeaderTemplate>
                    Status
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblStatus" runat="server" Text='<%# (Eval("Status").ToString()) %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px" />
            </asp:TemplateColumn>
            <asp:TemplateColumn ItemStyle-CssClass="Function">
                <HeaderTemplate>
                    Action
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:ImageButton ID="cmdEdit" runat="server" AlternateText="Edit" CommandName="Edit" ToolTip="Edit" ImageUrl="/App_Themes/Admin/images/edit.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"BooId")%>' />
                    <asp:ImageButton ID="cmdDelete" runat="server" AlternateText="Delete" CommandName="Delete" ToolTip="Delete" ImageUrl="/App_Themes/Admin/images/delete.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"BooId")%>' OnClientClick="javascript:return confirm('Do you want to delete?');" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px" />
            </asp:TemplateColumn>
        </Columns>
    </asp:DataGrid>
    <div class="Control">
        <ul>
            <li>
                <asp:LinkButton CssClass="vdelete" ID="lbtDeleteB" runat="server" OnClick="lbtDeleteB_Click">Delete</asp:LinkButton></li>
            <li>
                <asp:LinkButton CssClass="vrefresh" ID="lbtRefreshB" runat="server">Refresh</asp:LinkButton></li>
            <li><a class="vback" href="javascript:void(0);" onclick="window.history.go(-1);">Back</a> </li>
        </ul>
    </div>
</asp:Panel>
<asp:Panel ID="pnUpdate" runat="server" Visible="False">
    <table class="TableUpdate" style="border-collapse: collapse" cellpadding="0" width="100%" border="1">
        <tr>
            <td class="Control">
                <ul>
                    <li>
                        <asp:LinkButton CssClass="uupdate" ID="lbtUpdateT" runat="server" OnClick="lbtUpdateT_Click">Booking Success</asp:LinkButton></li>
                    <li>
                        <asp:LinkButton CssClass="uback" ID="lbtBackT" runat="server" CausesValidation="False" OnClick="lbtBackT_Click">Back</asp:LinkButton></li>
                </ul>
            </td>
        </tr>
        <tr>
            <td>
                <div class="PageName">
                    Information Customer
                    <asp:TextBox ID="txtId" runat="server" Visible="False"></asp:TextBox>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DataGrid ID="grdCustomer" runat="server" Width="100%"
                    AutoGenerateColumns="False" ShowHeader="False" CssClass="TableView">
                    <Columns>
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <table border="0">
                                    <tr>
                                        <th class="name_fild_row">FullName:</th>
                                        <td ><%# Eval("FullName").ToString()%></td>
                                    </tr>
                                    <tr>
                                        <th class="name_fild_row">Birth:</th>
                                        <td><%# MyWeb.Common.DateTimeClass.ConvertDateTime(Eval("Bod").ToString(),"dd/MM/yyyy")%></td>
                                    </tr>
                                    <tr>
                                        <th class="name_fild_row">Address:</th>
                                        <td><%# Eval("Address").ToString()%></td>
                                    </tr>
                                    <tr>
                                        <th class="name_fild_row">Phone:</th>
                                        <td><%# Eval("Phone").ToString()%></td>
                                    </tr>
                                    <tr>
                                        <th class="name_fild_row">Email:</th>
                                        <td><%# Eval("Email").ToString()%></td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                </asp:DataGrid>
            </td>
        </tr>
        <tr>
            <td>
                <div class="PageName">Information Booking</div>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DataGrid ID="grdShopcard" runat="server" AutoGenerateColumns="False" CellPadding="10" Width="100%">
                    <Columns>
                        <asp:TemplateColumn HeaderStyle-HorizontalAlign="Center">
                            <HeaderTemplate>Film</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="grdLblName" runat="server" Text='<%#(Eval("NameF").ToString())%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderStyle-HorizontalAlign="Center">
                            <HeaderTemplate>Picture</HeaderTemplate>
                            <ItemTemplate>
                                <script type="text/javascript">playfile('<%#DataBinder.Eval(Container.DataItem, "Picture").ToString() %>', "75", "100", "false", "", "", "")</script>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderStyle-HorizontalAlign="Center">
                            <HeaderTemplate>Quantity</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="grdLblQuantity" runat="server" Text='<%#(Eval("Quantity").ToString())%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderStyle-HorizontalAlign="Center">
                            <HeaderTemplate>Price</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="grdLblQuantity" runat="server" Text='<%#MyWeb.Common.StringClass.FormatNumber(Eval("Price").ToString())%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderStyle-HorizontalAlign="Center">
                            <HeaderTemplate>Bilmoney</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="grdLblQuantity" runat="server" Text='<%#MyWeb.Common.StringClass.FormatNumber(Eval("Bilmoney").ToString())%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderStyle-HorizontalAlign="Center">
                            <HeaderTemplate>Status</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="grdLblQuantity" runat="server" Text='<%#(Eval("St").ToString())%>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:TemplateColumn>
                    </Columns>
                    <HeaderStyle BackColor="#D0DEF0" BorderColor="#99BBE8" BorderStyle="Solid"
                        BorderWidth="1px" Font-Bold="True" Height="30px" />
                    <ItemStyle BorderColor="#B3B3B3" BorderStyle="Solid" BorderWidth="1px" />
                </asp:DataGrid>
            </td>
        </tr>
        <tr>
            <td class="Control">
                <ul>
                    <li>
                        <asp:LinkButton CssClass="uupdate" ID="lbtUpdateB" runat="server" OnClick="lbtUpdateB_Click">Booking Success</asp:LinkButton></li>
                    <li>
                        <asp:LinkButton CssClass="uback" ID="lbtBackB" runat="server" CausesValidation="False" OnClick="lbtBackB_Click">Back</asp:LinkButton></li>
                </ul>
            </td>
        </tr>
    </table>
</asp:Panel>
