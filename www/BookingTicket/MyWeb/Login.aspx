<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MyWeb.Login" %>

<%@ Register Src="~/Modules/uc_Login.ascx" TagPrefix="uc1" TagName="uc_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:uc_Login runat="server" id="uc_Login" />
</asp:Content>
