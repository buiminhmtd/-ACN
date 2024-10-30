<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_TypeFilm.ascx.cs" Inherits="MyWeb.Admin.Modules.uc_TypeFilm" %>
<div class="PageName">
    Type Film
</div>
<asp:Panel ID="pnView" runat="server">
    <div id="search_block">
        Type Film:
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
    <asp:DataGrid ID="grdTypeFilm" runat="server" Width="100%" CssClass="TableView" AutoGenerateColumns="False" AllowPaging="True" PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Center" BorderStyle="Solid" OnItemCommand="grdTypeFilm_ItemCommand" OnItemDataBound="grdTypeFilm_ItemDataBound" OnPageIndexChanged="grdTypeFilm_PageIndexChanged">
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
            <asp:BoundColumn DataField="TypId" HeaderText="Id" Visible="False" />
            <asp:BoundColumn DataField="Status" HeaderText="Active" Visible="False" />
            <asp:TemplateColumn ItemStyle-CssClass="Text">
                <HeaderTemplate>
                    Type Film
                    <asp:LinkButton CssClass="sortasc" ID="lbtascTypeFilm" CommandName="ascTypeFilm" runat="server" ToolTip="Sort ascending">s</asp:LinkButton>
                    <asp:LinkButton CssClass="sortdesc" ID="lbtdescTypeFilm" CommandName="descTypeFilm" runat="server" ToolTip="Sort descending">s</asp:LinkButton>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="grdLblName" runat="server" Text='<%#(Eval("NameT").ToString())%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px" />
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
                    <asp:ImageButton ID="cmdEdit" runat="server" AlternateText="Edit" CommandName="Edit" ToolTip="Edit" ImageUrl="/App_Themes/Admin/images/edit.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"TypId")%>' />
                    <asp:ImageButton ID="cmdDelete" runat="server" AlternateText="Delete" CommandName="Delete" ToolTip="Delete" ImageUrl="/App_Themes/Admin/images/delete.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"TypId")%>' OnClientClick="javascript:return confirm('Do you want to delete?');" /><asp:ImageButton
                        ID="cmdActive" runat="server" AlternateText='<%#MyWeb.Common.PageHelper.ShowActiveToolTip(DataBinder.Eval(Container.DataItem, "Status").ToString())%>'
                        CommandName="Status" ToolTip='<%# MyWeb.Common.PageHelper.ShowActiveToolTip(DataBinder.Eval(Container.DataItem, "Status").ToString())%>'
                        ImageUrl='<%#MyWeb.Common.PageHelper.ShowActiveImage(DataBinder.Eval(Container.DataItem, "Status").ToString())%>'
                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"TypId")%>' />
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
        var strName = '<%=ListTypeFilm%>'.split("|");
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
            <td class="name_fild_row">&nbsp;<asp:Label ID="lblName" runat="server" CssClass="text">Name</asp:Label></td>
            <td>
                <asp:TextBox ID="txtName" runat="server" Width="200px"></asp:TextBox>
                <asp:HiddenField ID="txtId" runat="server" />
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