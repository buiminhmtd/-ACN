<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_ChangePassword.ascx.cs" Inherits="MyWeb.Admin.Modules.uc_ChangePassword" %>
<div class="PageName">
    Change Password
</div>
<table class="TableUpdate" border="1">
    <tr>
        <td class="Control" colspan="2">
            <ul>
                <li>
                    <asp:LinkButton CssClass="uupdate" ID="lbtUpdateT" runat="server" OnClick="lbtUpdateT_Click">Save</asp:LinkButton></li>
                <li><a class="vback" href="javascript:void(0);" onclick="window.history.go(-1);">Back</a> </li>
            </ul>
        </td>
    </tr>
    <tr>
        <td class="name_fild_row">
            <asp:Label ID="lblCurrentPassword" runat="server">Current Password</asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtCurrentPassword" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="name_fild_row">
            <asp:Label ID="lblNewPassword" runat="server">New Password</asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtNewPassword" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="name_fild_row">
            <asp:Label ID="lblReenterPassword" runat="server">Reenter Password</asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtReenterPassword" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="Control" colspan="2">
            <ul>
                <li>
                    <asp:LinkButton CssClass="uupdate" ID="lbtUpdateB" runat="server" OnClick="lbtUpdateB_Click">Save</asp:LinkButton></li>
                <li><a class="vback" href="javascript:void(0);" onclick="window.history.go(-1);">Back</a> </li>
            </ul>
        </td>
    </tr>
</table>
