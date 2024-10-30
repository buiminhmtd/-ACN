<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_Information.ascx.cs" Inherits="MyWeb.Modules.uc_Information" %>
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
        <span class="title">INFORMATION</span>
    </div>
    <div class="cinema-list" id="cinema-index-list">
        <br />
        <div>
            <div style="width: 100%; float: left; margin-left: 50px">
                <br />
                <table style="width: 100%">
                    <tr>
                        <td>Username</td>
                        <td>
                            <asp:TextBox ID="txtUsername" runat="server" CssClass="input-all" ReadOnly="True"></asp:TextBox>
                            <asp:HiddenField ID="txtId" runat="server" />
                        </td>
                        <td>Birth</td>
                        <td>
                            <asp:TextBox ID="txtBirth" runat="server" CssClass="input-all"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Password</td>
                        <td>
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="input-all" TextMode="Password" Visible="False"></asp:TextBox>
                        </td>
                        <td>Address</td>
                        <td>
                            <asp:TextBox ID="txtAddress" runat="server" CssClass="input-all"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Credit Card</td>
                        <td>
                            <asp:TextBox ID="txtCard" runat="server" CssClass="input-all" onkeypress="return ValidateKeypress(/\d/,event);"></asp:TextBox>
                        </td>
                        <td>Phone</td>
                        <td>
                            <asp:TextBox ID="txtPhone" runat="server" CssClass="input-all" onkeypress="return ValidateKeypress(/\d/,event);"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Full Name</td>
                        <td>
                            <asp:TextBox ID="txtName" runat="server" CssClass="input-all"></asp:TextBox>
                        </td>
                        <td>Email</td>
                        <td>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="input-all"></asp:TextBox>
                            <asp:CheckBox ID="chkActive" runat="server" Checked="True" Visible="False" />
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btnSearch1" OnClick="btnUpdate_Click" />
                        </td>
                        <td>Avata</td>
                        <td>
                            <asp:Image ID="imgImage" runat="server" ImageAlign="Middle" Width="40px" Height="40px"/>
                            <asp:TextBox ID="txtAvata" runat="server" CssClass="text" Visible="True"></asp:TextBox>
                            <input type="button" id="btnSelectImg" value="Choose..." />
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <br />
                            <span style="color: rgb(153, 153, 153); font-family: arial; font-size: 12px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); display: inline !important; float: none;">_ You must complete the information</span><br />
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>

            </div>
        </div>
    </div>
</div>
