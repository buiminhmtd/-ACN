<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_ChangePassword.ascx.cs" Inherits="MyWeb.Modules.uc_ChangePassword" %>
<style type="text/css">
    .auto-style1
    {
        width: 100%;
    }
</style>
<div class="group">
    <div class="group-title">
        <span class="title">CHANGE PASSWORD</span>
    </div>
    <div class="cinema-list" id="cinema-index-list">
        <br />
        <div>
            <div style="width: 100%; float: left; margin-left: 50px">
                <table class="auto-style1">
                    <tr>
                        <td>
                            <asp:Label ID="lblCurrentPassword" runat="server">Current Password</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCurrentPassword" runat="server" TextMode="Password" CssClass="input-all"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblNewPassword" runat="server">New Password</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" CssClass="input-all"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblReenterPassword" runat="server">Reenter Password</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtReenterPassword" runat="server" TextMode="Password" CssClass="input-all"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Button ID="btnChange" runat="server" Text="Change" CssClass="btnSearch1" OnClick="btnChange_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <span style="color: rgb(153, 153, 153); font-family: arial; font-size: 12px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); display: inline !important; float: none;">_ You must complete the information</span></td>
                    </tr>
                </table>
                <br />

            </div>
        </div>
    </div>
</div>
