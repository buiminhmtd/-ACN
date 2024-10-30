<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="MyWeb.Register" %>

<%@ Register Src="~/Modules/uc_Register.ascx" TagPrefix="uc1" TagName="uc_Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:uc_Register runat="server" id="uc_Register" />
</asp:Content>
