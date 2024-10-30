<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_Film.ascx.cs" Inherits="MyWeb.Admin.Modules.uc_Film" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<script type="text/javascript">
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
                $('#<%=txtPicture.ClientID %>').val(fileUrl);
            };
            finder.popup();
        });
        
        $("#btnSelectImgBig").click(function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $('#<%=txtPictureBig.ClientID %>').val(fileUrl);
            };
            finder.popup();
        });
    });
</script>
<div class="PageName">
    Film
</div>

<asp:Panel ID="pnView" runat="server">
    <div id="search_block">
        Type Film:
            <asp:DropDownList ID="ddlFilterypeFilm" runat="server">
            </asp:DropDownList>
        Country:
            <asp:DropDownList ID="ddlFilterCountry" runat="server">
            </asp:DropDownList>
        Name Film:
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
    <asp:DataGrid ID="grdFilm" runat="server" Width="100%" CssClass="TableView" AutoGenerateColumns="False" AllowPaging="True" PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Center" BorderStyle="Solid" OnItemCommand="grdFilm_ItemCommand" OnItemDataBound="grdFilm_ItemDataBound" OnPageIndexChanged="grdFilm_PageIndexChanged">
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
            <asp:BoundColumn DataField="FilId" HeaderText="Id" Visible="False" />
            <asp:BoundColumn DataField="Status" HeaderText="Active" Visible="False" />
            <asp:TemplateColumn ItemStyle-CssClass="Text">
                <HeaderTemplate>
                    Film
                    <asp:LinkButton CssClass="sortasc" ID="lbtascFilm" CommandName="ascFilm" runat="server" ToolTip="Sort ascending">s</asp:LinkButton>
                    <asp:LinkButton CssClass="sortdesc" ID="lbtdescFilm" CommandName="descFilm" runat="server" ToolTip="Sort descending">s</asp:LinkButton>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="grdLblName" runat="server" Text='<%#(Eval("NameF").ToString())%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px" />
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Director">
                <ItemTemplate>
                    <asp:Label ID="grdLblDirector" runat="server" Text='<%#(Eval("Director").ToString())%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px" />
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Actor">
                <ItemTemplate>
                    <asp:Label ID="grdLblActor" runat="server" Text='<%#(Eval("Actor").ToString())%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px" />
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Duration">
                <ItemTemplate>
                    <asp:Label ID="grdLblDuration" runat="server" Text='<%#(Eval("Duration").ToString())%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="100px" />
            </asp:TemplateColumn>
            <asp:TemplateColumn ItemStyle-CssClass="Image">
                <HeaderTemplate>
                    Images
                </HeaderTemplate>
                <ItemTemplate>
                    <script type="text/javascript">playfile('<%#DataBinder.Eval(Container.DataItem, "Picture").ToString() %>', "75", "100", "false", "", "", "")</script>
                </ItemTemplate>
                <ItemStyle CssClass="Image" />
            </asp:TemplateColumn>
            <asp:TemplateColumn ItemStyle-CssClass="Image">
                <HeaderTemplate>
                    Images Big
                </HeaderTemplate>
                <ItemTemplate>
                    <script type="text/javascript">playfile('<%#DataBinder.Eval(Container.DataItem, "PictureBig").ToString() %>', "135", "80", "false", "", "", "")</script>
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
                    <asp:ImageButton ID="cmdEdit" runat="server" AlternateText="Edit" CommandName="Edit" ToolTip="Edit" ImageUrl="/App_Themes/Admin/images/edit.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"FilId")%>' />
                    <asp:ImageButton ID="cmdDelete" runat="server" AlternateText="Delete" CommandName="Delete" ToolTip="Delete" ImageUrl="/App_Themes/Admin/images/delete.png" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"FilId")%>' OnClientClick="javascript:return confirm('Do you want to delete?');" /><asp:ImageButton
                        ID="cmdActive" runat="server" AlternateText='<%#MyWeb.Common.PageHelper.ShowActiveToolTip(DataBinder.Eval(Container.DataItem, "Status").ToString())%>'
                        CommandName="Status" ToolTip='<%# MyWeb.Common.PageHelper.ShowActiveToolTip(DataBinder.Eval(Container.DataItem, "Status").ToString())%>'
                        ImageUrl='<%#MyWeb.Common.PageHelper.ShowActiveImage(DataBinder.Eval(Container.DataItem, "Status").ToString())%>'
                        CommandArgument='<%#DataBinder.Eval(Container.DataItem,"FilId")%>' />
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
        var strName = '<%=ListFilm%>'.split("|");
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
            <td class="name_fild_row">&nbsp;<asp:Label ID="lblTypId" runat="server">Type Film</asp:Label></td>
            <td>
                <asp:DropDownList ID="ddlTypId_Update" runat="server" Width="200px"> </asp:DropDownList>
                <asp:HiddenField ID="txtId" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="name_fild_row">&nbsp;<asp:Label ID="lblCouId" runat="server">Country</asp:Label></td>
            <td>
                <asp:DropDownList ID="ddlCouId_Update" runat="server"  Width="200px"></asp:DropDownList></td>
        </tr>
        <tr>
            <td class="name_fild_row">&nbsp;<asp:Label ID="lblName" runat="server">Name</asp:Label></td>
            <td>
                <asp:TextBox ID="txtName" runat="server" CssClass="text"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="name_fild_row">&nbsp;<asp:Label ID="lblDirector" runat="server">Director</asp:Label></td>
            <td>
                <asp:TextBox ID="txtDirector" runat="server" CssClass="text"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="name_fild_row">&nbsp;<asp:Label ID="lblActor" runat="server">Actor</asp:Label></td>
            <td>
                <asp:TextBox ID="txtActor" runat="server" CssClass="text"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="name_fild_row">&nbsp;<asp:Label ID="lblDuration" runat="server">Duration</asp:Label></td>
            <td>
                <asp:TextBox ID="txtDuration" runat="server" CssClass="text"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="name_fild_row">&nbsp;<asp:Label ID="lblDescription" runat="server">Description</asp:Label></td>
            <td>
                <FCKeditorV2:FCKeditor ID="FCKeditorDescription" runat="server" Height="270px"></FCKeditorV2:FCKeditor>
            </td>
        </tr>
        <tr>
            <td class="name_fild_row">&nbsp;<asp:Label ID="lblDetail" runat="server">Detail</asp:Label></td>
            <td>
                <FCKeditorV2:FCKeditor ID="FCKeditorDetail" runat="server" Height="320px"></FCKeditorV2:FCKeditor>
            </td>
        </tr>
        <tr>
            <td class="name_fild_row">&nbsp;<asp:Label ID="lblPicture" runat="server">Picture</asp:Label></td>
            <td>
                <asp:TextBox ID="txtPicture" runat="server" CssClass="text"></asp:TextBox>
                <input type="button" id="btnSelectImg" value="Choose..." />
                <asp:Image ID="imgImage" runat="server" ImageAlign="Middle" Width="100px"/>
            </td>
        </tr>
        <tr>
            <td class="name_fild_row">&nbsp;<asp:Label ID="Label1" runat="server">Picture Big</asp:Label></td>
            <td>
                <asp:TextBox ID="txtPictureBig" runat="server" CssClass="text"></asp:TextBox>
                <input type="button" id="btnSelectImgBig" value="Choose..." />
                <asp:Image ID="imgImageBig" runat="server" ImageAlign="Middle" Width="100px"/>
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
