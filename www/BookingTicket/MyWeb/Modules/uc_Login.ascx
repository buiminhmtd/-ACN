<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_Login.ascx.cs" Inherits="MyWeb.Modules.uc_Login" %>

<div class="group">
    <div class="group-title">
        <span class="title">LOGIN</span>
    </div>
    <div class="cinema-list" id="cinema-index-list">
        <div style="width: 100%">
            <div style="width: 100%; float: left; margin-left: 50px">
                <br />
                <table style="width: 100%">
                    <tr>
                        <td>Username&nbsp;</td>
                        <td>
                <asp:TextBox ID="txtUsernameL" runat="server" CssClass="input-all"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Password</td>
                        <td>
                <asp:TextBox ID="txtPasswordL" runat="server" CssClass="input-all" TextMode="Password"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td><br/>
                            <asp:CheckBox ID="ckRemember" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btnSearch1" OnClick="btnLogin_Click" />
                            <br /></td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>_ If you do not have an account <a href="../Register.aspx"> Register here</a></td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>_ If you forgot your password <a href="#"> Forgot password</a></tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>_ Login to be able to put the ticket
                    </tr>
                </table>
                <br /><br/>
            </div>
        </div>

    </div>
</div>
