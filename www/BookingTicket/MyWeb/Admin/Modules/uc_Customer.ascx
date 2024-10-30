<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_Customer.ascx.cs" Inherits="MyWeb.Admin.Modules.uc_Customer" %>
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
    
    $(document).ready(function () {
        $("#btnSelectImg").click(function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $('#<%=txtAvata.ClientID %>').val(fileUrl);
            };
            finder.popup();
        });
    });
</script>
<div class="PageName">
    Customer
</div>
<asp:Panel ID="pnView" runat="server">
    <div id="search_block">
        Name Customer:
            <asp:TextBox ID="txtFilterName" runat="server" CssClass="text" Width="145px"></asp:TextBox>
        Status:
            <asp:DropDownList ID="ddlFilterActive" runat="server" CssClass="active">
            </asp:DropDownList>
        <asp:Button ID="Filter" runat="server" Text="Filter" CssClass="filter" OnClick="Filter_Click" />
        <asp:Button ID="UnFilter" runat="server" Text="UnFilter" OnClick="UnFilter_Click" />
    </div>
    <div class="Control">
        <ul>
            <li>
                <asp:LinkButton CssClass="vadd" ID="lbtAddT" runat="server" OnClick="lbtAddT_Click">Add</asp:LinkButton></li>
            <li>
                <asp:LinkButton CssClass="vdelete" ID="lbtDeleteT" runat="server" OnClick="lbtDeleteT_Click">Delete</asp:LinkButton></li>
            <li>
                <asp:LinkButton CssClass="vrefresh" ID="lbtRefreshT" runat="server" OnClick="lbtRefreshT_Click">Refresh</asp:LinkButton></li>
            <li><a class="vback" href="javascript:void(0);" onclick="window.history.go(-1);">Back</a> </li>
        </ul>
    </div>
    <asp:DataGrid ID="grdCustomer" runat="server" Width="100%" CssClass="TableView" AutoGenerateColumns="False"
        AllowPaging="True" PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Center" BorderStyle="Solid" OnItemCommand="grdCustomer_ItemCommand" OnPageIndexChanged="grdCustomer_PageIndexChanged" OnItemDataBound="grdCustomer_ItemDataBound">
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
            <asp:BoundColumn DataField="CusId" HeaderText="Id" Visible="False" />
            <asp:BoundColumn DataField="Status" HeaderText="Active" Visible="False" />
            <asp:TemplateColumn ItemStyle-CssClass="Text">
                <HeaderTemplate>
                    Username
                    <asp:LinkButton CssClass="sortasc" ID="lbtascUsername" CommandName="ascUsername" runat="server" ToolTip="Sort ascending">s</asp:LinkButton>
                    <asp:LinkButton CssClass="sortdesc" ID="lbtdescUsername" CommandName="descUsername" runat="server" ToolTip="Sort descending">s</asp:LinkButton>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="grdLblUsername" runat="server" Text='<%#(Eval("Username").ToString())%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px" />
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Credit Card">
                <ItemTemplate>
                    <asp:Label ID="grdLblCreditCard" runat="server" Text='<%#(Eval("CreditCard").ToString())%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px" />
            </asp:TemplateColumn>
            <asp:TemplateColumn ItemStyle-CssClass="Text">
                <HeaderTemplate>
                    Full Name
                    <asp:LinkButton CssClass="sortasc" ID="lbtascFullName" CommandName="ascFullName" runat="server" ToolTip="Sort ascending">s</asp:LinkButton>
                    <asp:LinkButton CssClass="sortdesc" ID="lbtdescFullName" CommandName="descFullName" runat="server" ToolTip="Sort descending">s</asp:LinkButton>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="grdLblFullName" runat="server" Text='<%#(Eval("FullName").ToString())%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px" />
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Birth">
                <ItemTemplate>
                    <asp:Label ID="grdLblBod" runat="server" Text='<%# MyWeb.Common.DateTimeClass.ConvertDateTime(Eval("Bod").ToString(),"dd/MM/yyyy")%>'></asp:Label>
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
            <asp:TemplateColumn ItemStyle-CssClass="Image">
                <HeaderTemplate>
                    Images
                </HeaderTemplate>
                <ItemTemplate>
                    <script type="text/javascript">playfile('<%#DataBinder.Eval(Container.DataItem, "Avata").ToString() %>', "75", "75", "false", "", "", "")</script>
                </ItemTemplate>
                <ItemStyle CssClass="Image" />
            </asp:TemplateColumn>
            <asp:TemplateColumn ItemStyle-CssClass="Activehead">
                <HeaderTemplate>
                    Enable
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblStatus" runat="server" Text='<%# MyWeb.Common.PageHelper.ShowActiveStatus(Eval("Status").ToString()) %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px" />
            </asp:TemplateColumn>
            <asp:TemplateColumn ItemStyle-CssClass="Function">
                <HeaderTemplate>
                    Action
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:ImageButton ID="cmdEdit" runat="server" AlternateText="Edit" CommandName="Edit" ToolTip="Edit" ImageUrl="/App_Themes/Admin/images/edit.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"CusId")%>' />
                    <asp:ImageButton ID="cmdDelete" runat="server" AlternateText="Delete" CommandName="Delete" ToolTip="Delete" ImageUrl="/App_Themes/Admin/images/delete.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"CusId")%>' OnClientClick="javascript:return confirm('Do you want to delete?');" /><asp:ImageButton
                            ID="cmdActive" runat="server" AlternateText='<%#MyWeb.Common.PageHelper.ShowActiveToolTip(DataBinder.Eval(Container.DataItem, "Status").ToString())%>'
                            CommandName="Status" ToolTip='<%# MyWeb.Common.PageHelper.ShowActiveToolTip(DataBinder.Eval(Container.DataItem, "Status").ToString())%>'
                            ImageUrl='<%#MyWeb.Common.PageHelper.ShowActiveImage(DataBinder.Eval(Container.DataItem, "Status").ToString())%>'
                            CommandArgument='<%#DataBinder.Eval(Container.DataItem,"CusId")%>' />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px" />
            </asp:TemplateColumn>
        </Columns>
    </asp:DataGrid>
    <div class="Control">
        <ul>
            <li>
                <asp:LinkButton CssClass="vadd" ID="lbtAddB" runat="server" OnClick="lbtAddB_Click">Add</asp:LinkButton></li>
            <li>
                <asp:LinkButton CssClass="vdelete" ID="lbtDeleteB" runat="server" OnClick="lbtDeleteB_Click">Delete</asp:LinkButton></li>
            <li>
                <asp:LinkButton CssClass="vrefresh" ID="lbtRefreshB" runat="server" OnClick="lbtRefreshB_Click">Refresh</asp:LinkButton></li>
            <li><a class="vback" href="javascript:void(0);" onclick="window.history.go(-1);">Back</a> </li>
        </ul>
    </div>
</asp:Panel>
<script type="text/javascript">
    $(document).ready(function () {
        var strName = '<%=ListUsername%>'.split("|");
        $("#<%= txtFilterName.ClientID %>").autocomplete({ source: strName });
    });
</script>
<asp:Panel ID="pnUpdate" runat="server" Visible="False">
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
                <asp:TextBox ID="txtUsername" runat="server" CssClass="text"></asp:TextBox>
                <asp:HiddenField ID="txtId" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="name_fild_row">&nbsp;<asp:Label ID="lblPassword" runat="server">Password</asp:Label></td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="text" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="name_fild_row">&nbsp;<asp:Label ID="lblCreditCard" runat="server">Credit Card</asp:Label></td>
            <td>
                <asp:TextBox ID="txtCreditCard" runat="server" CssClass="text"></asp:TextBox></td>
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
            <td class="name_fild_row">&nbsp;<asp:Label ID="lblImage" runat="server">Image</asp:Label></td>
            <td>
                <asp:TextBox ID="txtAvata" runat="server" CssClass="text"></asp:TextBox>
                <input type="button" id="btnSelectImg" value="Choose..." />
                <asp:Image ID="imgImage" runat="server" ImageAlign="Middle" Width="100px"/>
            </td>
        </tr>
        <tr>
            <td class="name_fild_row">
                <asp:Label ID="lblActive" runat="server" Text="Enable"></asp:Label></td>
            <td>
                <asp:CheckBox ID="chkActive" runat="server" /></td>
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
