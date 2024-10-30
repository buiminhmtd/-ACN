<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_MyInformation.ascx.cs" Inherits="MyWeb.Admin.Modules.uc_MyInformation" %>
<script type="text/javascript">
    $(function () {
        $("[id$=txtBod]").datepicker({ dateFormat: 'mm/dd/yy' });
    });
    
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

<div class="PageName">
    My Information
</div>
<asp:Panel ID="pnView" runat="server">
    <div class="Control">
        <ul>
            <li>
                <asp:LinkButton CssClass="vrefresh" ID="lbtRefreshT" runat="server" OnClick="lbtRefreshT_Click">Refresh</asp:LinkButton></li>
            <li><a class="vback" href="javascript:void(0);" onclick="window.history.go(-1);">Back</a> </li>
        </ul>
    </div>
    <asp:DataGrid ID="grdAdmin" runat="server" Width="100%" CssClass="TableView" AutoGenerateColumns="False" OnItemCommand="grdAdmin_ItemCommand">
        <HeaderStyle CssClass="trHeader"></HeaderStyle>
        <ItemStyle CssClass="trOdd"></ItemStyle>
        <AlternatingItemStyle CssClass="trEven"></AlternatingItemStyle>
        <Columns>
            <asp:TemplateColumn HeaderText="Username">
                <ItemTemplate>
                    <asp:Label ID="grdLblUsername" runat="server" Text='<%#(Eval("Username").ToString())%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px" />
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="FullName">
                <ItemTemplate>
                    <asp:Label ID="grdLblFullName" runat="server" Text='<%#(Eval("FullName").ToString())%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px" />
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Birth">
                <ItemTemplate>
                    <asp:Label ID="grdLblBod" runat="server" Text='<%# MyWeb.Common.DateTimeClass.ConvertDateTime(Eval("Bod").ToString(), "dd/MM/yyyy")%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px" />
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Address">
                <ItemTemplate>
                    <asp:Label ID="grdLblAddress" runat="server" Text='<%#(Eval("Address").ToString())%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px" />
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Phone">
                <ItemTemplate>
                    <asp:Label ID="grdLblPhone" runat="server" Text='<%#(Eval("Phone").ToString())%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px" />
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Email">
                <ItemTemplate>
                    <asp:Label ID="grdLblEmail" runat="server" Text='<%#(Eval("Email").ToString())%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px" />
            </asp:TemplateColumn>
            <asp:TemplateColumn ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center">
                <HeaderTemplate>
                    Action
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="lbt1" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"AdmId")%>' CommandName="Edit" ToolTip="Edit" CssClass="edit"></asp:LinkButton>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px" />
            </asp:TemplateColumn>
        </Columns>
    </asp:DataGrid>
    <div class="Control">
        <ul>
            <li>
                <asp:LinkButton CssClass="vrefresh" ID="lbtRefreshB" runat="server" OnClick="lbtRefreshB_Click">Refresh</asp:LinkButton></li>
            <li><a class="vback" href="javascript:void(0);" onclick="window.history.go(-1);">Back</a> </li>
        </ul>
    </div>
</asp:Panel>
<asp:Panel ID="pnUpdate" runat="server" Visible="False" Width="100%">
    <table class="TableUpdate" style="border-collapse: collapse" cellpadding="0" width="100%" border="1">
        <tr>
            <td class="Control" colspan="2">
                <ul>
                    <li>
                        <asp:LinkButton CssClass="uupdate" ID="lbtUpdateT" runat="server" OnClick="lbtUpdateT_Click">Save</asp:LinkButton></li>
                    <li>
                        <asp:LinkButton CssClass="uback" ID="lbtBackT" runat="server" CausesValidation="False" OnClick="lbtBackT_Click">Back</asp:LinkButton></li>
                </ul>
            </td>
        </tr>
        <tr>
            <td class="name_fild_row">&nbsp;<asp:Label ID="lblUsername" runat="server">Username</asp:Label></td>
            <td>
                <asp:TextBox ID="txtUsername" runat="server" CssClass="text" ReadOnly="True"></asp:TextBox>
                <asp:HiddenField ID="txtId" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="name_fild_row">&nbsp;<asp:Label ID="lblFullName" runat="server">Full Name</asp:Label></td>
            <td>
                <asp:TextBox ID="txtFullName" runat="server" CssClass="text"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="name_fild_row">&nbsp;<asp:Label ID="lblBod" runat="server">Birth</asp:Label></td>
            <td>
                <asp:TextBox ID="txtBod" runat="server" CssClass="text"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="name_fild_row">&nbsp;<asp:Label ID="lblAddress" runat="server">Address</asp:Label></td>
            <td>
                <asp:TextBox ID="txtAddress" runat="server" CssClass="text"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="name_fild_row">&nbsp;<asp:Label ID="lblPhone" runat="server">Phone</asp:Label></td>
            <td>
                <asp:TextBox ID="txtPhone" runat="server" CssClass="text" onkeypress="return ValidateKeypress(/\d/,event);"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="name_fild_row">&nbsp;<asp:Label ID="lblEmail" runat="server">Email</asp:Label></td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="text"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="Control" colspan="2">
                <ul>
                    <li>
                        <asp:LinkButton CssClass="uupdate" ID="lbtUpdateB" runat="server" OnClick="lbtUpdateB_Click">Save</asp:LinkButton></li>
                    <li>
                        <asp:LinkButton CssClass="uback" ID="lbtBackB" runat="server" CausesValidation="False" OnClick="lbtBackB_Click">Back</asp:LinkButton></li>
                </ul>
            </td>
        </tr>
    </table>
</asp:Panel>
