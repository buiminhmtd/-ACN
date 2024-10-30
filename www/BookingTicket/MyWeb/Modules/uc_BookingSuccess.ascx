<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_BookingSuccess.ascx.cs" Inherits="MyWeb.Modules.uc_BookingSuccess" %>
<div class="group">
    <div class="group-title">
        <span class="title">BOOKING SUCCESS</span>
    </div><br/>
    <span>Your Information</span><br/><br/>
    <asp:DataGrid ID="grdCustomer" runat="server" Width="100%"
        AutoGenerateColumns="False" ShowHeader="False" BorderColor="white">
        <Columns>
            <asp:TemplateColumn>
                <ItemTemplate>
                    <table style="width: 100%; border: none">
                        <tr>
                            <th class="name_fild_row">FullName:</th>
                            <td><%# Eval("FullName").ToString()%></td>
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
    </asp:DataGrid><br/>

    <span>Information Booking</span>
    <br/><br/>
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
                    <script type="text/javascript">playfile('<%#DataBinder.Eval(Container.DataItem, "Pic").ToString() %>', "75", "100", "false", "", "", "")</script>
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
        </Columns>
        <HeaderStyle BackColor="#D0DEF0" BorderColor="#99BBE8" BorderStyle="Solid"
            BorderWidth="1px" Font-Bold="True" Height="30px" />
        <ItemStyle BorderColor="#B3B3B3" BorderStyle="Solid" BorderWidth="1px" />
    </asp:DataGrid>
</div>
