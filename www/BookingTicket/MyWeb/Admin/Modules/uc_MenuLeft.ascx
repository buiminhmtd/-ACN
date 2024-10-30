<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_MenuLeft.ascx.cs" Inherits="MyWeb.Admin.Modules.uc_MenuLeft" %>
<%@ Import Namespace="MyWeb.Common" %>
<table class="table" cellspacing="0" cellpadding="0">
    <tr>
        <td class="left">
            <img alt="" src="<%=GlobalClass.GetUrlAdminImage()%>blank.gif" />
        </td>
        <td>System
        </td>
        <td class="image">
            <img alt="" id="imgdiv1" src="<%=GlobalClass.GetUrlAdminImage()%>closed.gif" onclick="toggleXPMenu('div1');" />
        </td>
        <td class="right">
            <img alt="" src="<%=GlobalClass.GetUrlAdminImage()%>blank.gif" />
        </td>
    </tr>
</table>
<asp:Panel ID="div1" CssClass="content" ClientIDMode="Static" runat="server">
    <ul>
        <li>
            <img alt="" src="<%=GlobalClass.GetUrlAdminImage()%>icon_user.jpg" />
            <a href="Default.aspx?mod=uc_MyInformation">My Information</a>
        </li>
        <li>
            <img alt="" src="<%=GlobalClass.GetUrlAdminImage()%>icon_pro.jpg" />
            <a href="Default.aspx?mod=uc_ChangePassword">Change Password</a>
        </li>
        <li>
            <img alt="" src="<%=GlobalClass.GetUrlAdminImage()%>icon_pro.jpg" />
            <a href="Default.aspx?mod=uc_Slide">Slide</a>
        </li>
    </ul>
</asp:Panel>

<table class="table" cellspacing="0" cellpadding="0">
    <tr>
        <td class="left">
            <img alt="" src="<%=GlobalClass.GetUrlAdminImage()%>blank.gif" />
        </td>
        <td>Customer
        </td>
        <td class="image">
            <img alt="" id="imgdiv2" src="<%=GlobalClass.GetUrlAdminImage()%>closed.gif" onclick="toggleXPMenu('div2');" />
        </td>
        <td class="right">
            <img alt="" src="<%=GlobalClass.GetUrlAdminImage()%>blank.gif" />
        </td>
    </tr>
</table>
<asp:Panel ID="div2" CssClass="content" ClientIDMode="Static" runat="server">
    <ul>
        <li>
            <img alt="" src="<%=GlobalClass.GetUrlAdminImage()%>icon_pro.jpg" />
            <a href="Default.aspx?mod=uc_Customer">Customer</a>
        </li>
        <li>
            <img alt="" src="<%=GlobalClass.GetUrlAdminImage()%>icon_pro.jpg" />
            <a href="Default.aspx?mod=uc_Feedback">Feedback</a>
        </li>
        <li>
            <img alt="" src="<%=GlobalClass.GetUrlAdminImage()%>icon_pro.jpg" />
            <a href="Default.aspx?mod=uc_Booking">Booking</a>
        </li>
    </ul>
</asp:Panel>

<table class="table" cellspacing="0" cellpadding="0">
    <tr>
        <td class="left">
            <img alt="" src="<%=GlobalClass.GetUrlAdminImage()%>blank.gif" />
        </td>
        <td>Management Film
        </td>
        <td class="image">
            <img alt="" id="imgdiv3" src="<%=GlobalClass.GetUrlAdminImage()%>closed.gif" onclick="toggleXPMenu('div3');" />
        </td>
        <td class="right">
            <img alt="" src="<%=GlobalClass.GetUrlAdminImage()%>blank.gif" />
        </td>
    </tr>
</table>
<asp:Panel ID="div3" CssClass="content" ClientIDMode="Static" runat="server">
    <ul>
        <li>
            <img alt="" src="<%=GlobalClass.GetUrlAdminImage()%>icon_pro.jpg" />
            <a href="Default.aspx?mod=uc_Cinema">Cinema</a>
        </li>
        <li>
            <img alt="" src="<%=GlobalClass.GetUrlAdminImage()%>icon_pro.jpg" />
            <a href="Default.aspx?mod=uc_Country">Country</a>
        </li>
        <li>
            <img alt="" src="<%=GlobalClass.GetUrlAdminImage()%>icon_pro.jpg" />
            <a href="Default.aspx?mod=uc_TypeFilm">Type Film</a>
        </li>
        <li>
            <img alt="" src="<%=GlobalClass.GetUrlAdminImage()%>icon_pro.jpg" />
            <a href="Default.aspx?mod=uc_Film">Film</a>
        </li>
        <li>
            <img alt="" src="<%=GlobalClass.GetUrlAdminImage()%>icon_pro.jpg" />
            <a href="Default.aspx?mod=uc_ShowTimes">Show Time</a>
        </li>
    </ul>
</asp:Panel>