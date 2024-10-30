<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logon.aspx.cs" Inherits="MyWeb.Admin.Logon" %>

<%@ Import Namespace="MyWeb.Common" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Logon</title>
    <style>
        /*Login*/ 
        .left_top					{ background-image: url(<%=GlobalClass.GetUrlAdminImage()%>xpwindowleft.jpg); width: 13px; background-repeat: no-repeat; height: 30px; }
        .right_top 					{ background-position: right 50%; background-image: url(<%=GlobalClass.GetUrlAdminImage()%>xpwindowright.jpg); width: 13px; background-repeat: no-repeat; height: 30px; }
        .top_bg 					{ text-align:left; font-weight: bold; font-size: 13px; background-image: url(<%=GlobalClass.GetUrlAdminImage()%>xpwindowbg.jpg); height:30px; color: #ffffff; background-repeat: repeat-x; font-family: verdana; }
        .top_bg2 					{ font-weight: bold; padding-left:150px; font-size: 13px; background-image: url(<%=GlobalClass.GetUrlAdminImage()%>top.jpg); background-repeat:no-repeat; border-left: #001eed 1px solid; border-right: #001eed 1px solid; width: auto; height: 70px; color: #ff3300; font-family: verdana; }
        .bottom_login				{ border-left: #001eed 1px solid; border-right: #001eed 1px solid; border-bottom: #001eed 1px solid; height: 1px; }
        .logname					{ font-size: 11px; font-weight:bold; color: #0b1985; font-family: verdana; }
        .txtbox 					{ border-right: #0b1985 1px solid; border-top: #0b1985 1px solid; text-align:left; border-left: #0b1985 1px solid; width: 250px; color: #1c2874; border-bottom: #0b1985 1px solid; height: 19px; }
        .selectbox 					{ border-right: #3854a1 1px solid; border-top: #3854a1 1px solid; border-left: #3854a1 1px solid; border-bottom: #3854a1 1px solid; font-family: verdana; font-size:12px; padding-left:10px; height: 19px; text-align:left; }
        .bg_main 					{ border-right: #001eed 1px solid; background: url(<%=GlobalClass.GetUrlAdminImage()%>bg_login.jpg) repeat-x center bottom; padding-bottom: 10px; border-left: #001eed 1px solid; padding-top: 10px;}
        .txt3 						{ font-size: 10px; color: #0b1985; font-family: verdana; text-align:justify; }
        .error                      { color:Red; font-size:12px; text-align:center; } 
        .buttom_image				{ font-size:12px; font-weight:bold; width:100px;}
        input[type="submit"],
        input[type="button"],
        input[type="reset"], button { background: url(<%=GlobalClass.GetUrlAdminImage()%>button-background-gray.gif) repeat-x scroll 0 0 #E3E3E3; border: 1px solid #CCCCCC; border-radius: 3px 3px 3px 3px; color: #0b1985; font-size: 12px; line-height: 16px; padding: 3px 5px; font-family: helvetica; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center">
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <table width="410" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="13" class="left_top">&nbsp;</td>
                                <td valign="middle" class="top_bg">Log On Admin Panel</td>
                                <td width="13" class="right_top">&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="top_bg2">Control Panel Login</td>
                </tr>
                <tr>
                    <td class="bg_main" align="center">
                        <table width="94%" border="0" cellspacing="0" cellpadding="3">
                            <tr>
                                <td width="29%" class="logname">Username : </td>
                                <td width="71%">
                                    <asp:TextBox ID="txtUsername" runat="server" Width="200px"></asp:TextBox><asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername" Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ForeColor="red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="logname">Password : </td>
                                <td>
                                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="200px"></asp:TextBox><asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ForeColor="red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <tr>
                                <td class="error" colspan="2">
                                    <asp:Literal ID="ltrError" runat="server"></asp:Literal></td>
                            </tr>

                            <tr>
                                <td height="47" colspan="2" align="center">
                                    <asp:Button ID="btnLogon" runat="server" Text="Logon" OnClick="btnLogon_Click" />&nbsp;&nbsp;<input name="reset" type="reset" id="reset" value="Reset" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="bottom_login" style="background: #3d90f6; color: #FFFFFF;" height="25px">Powered by PhamNgocTuan</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
