<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_Register.ascx.cs" Inherits="MyWeb.Modules.uc_Register" %>
<script type="text/javascript">
    $(function () {
        $("[id$=txtBirth]").datepicker({ dateFormat: 'mm/dd/yy' });
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
<div class="group">
    <div class="group-title">
        <span class="title">REGISTER</span>
    </div>
    <div class="cinema-list" id="cinema-index-list">
        <div style="width: 100%; float: left; margin-left: 50px">

            <table style="width: 100%">
                <tr>
                    <td>Username</td>
                    <td>
                        <asp:TextBox ID="txtUsername" runat="server" CssClass="input-all"></asp:TextBox>
                    </td>
                    <td>Birth</td>
                    <td>
                        <asp:TextBox ID="txtBirth" runat="server" CssClass="input-all"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Password</td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="input-all" TextMode="Password"></asp:TextBox>
                    </td>
                    <td>Address</td>
                    <td>
                        <asp:TextBox ID="txtAddress" runat="server" CssClass="input-all"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Reenter Password</td>
                    <td>
                        <asp:TextBox ID="txtReenterPassword" runat="server" CssClass="input-all" TextMode="Password"></asp:TextBox>
                    </td>
                    <td>Phone</td>
                    <td>
                        <asp:TextBox ID="txtPhone" runat="server" CssClass="input-all" onkeypress="return ValidateKeypress(/\d/,event);"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Credit Card</td>
                    <td>
                        <asp:TextBox ID="txtCard" runat="server" CssClass="input-all"></asp:TextBox>
                    </td>
                    <td>Email</td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="input-all"></asp:TextBox>
                        <asp:CheckBox ID="chkActive" runat="server" Checked="True" Visible="False" />
                    </td>
                </tr>
                <tr>
                    <td>Full Name</td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" CssClass="input-all"></asp:TextBox>
                    </td>
                    <td>Avata
                    </td>
                    <td>
                        <%--<asp:Image ID="Image1" runat="server" ImageAlign="Middle" Width="50px" />--%>
                        <asp:TextBox ID="txtAvata" runat="server" CssClass="text"></asp:TextBox>
                        <input type="button" id="btnSelectImg" value="Choose..." />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btnSearch1" OnClick="btnRegister_Click" />
                    </td>
                    <td></td>
                    <td></td>
                </tr>
            </table>
        </div>
    </div>
</div>
