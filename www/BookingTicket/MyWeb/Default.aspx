<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MyWeb.Default" %>

<%@ Register Src="~/Modules/uc_Banner.ascx" TagPrefix="uc1" TagName="uc_Banner" %>
<%@ Register Src="~/Modules/uc_MovieHome.ascx" TagPrefix="uc1" TagName="uc_MovieHome" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <uc1:uc_Banner runat="server" ID="uc_Banner" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:uc_MovieHome runat="server" ID="uc_MovieHome" />
</asp:Content>
