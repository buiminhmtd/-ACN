<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="MyWeb.ChangePassword" %>

<%@ Register Src="~/Modules/uc_ChangePassword.ascx" TagPrefix="uc1" TagName="uc_ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:uc_ChangePassword runat="server" ID="uc_ChangePassword" />
</asp:Content>
