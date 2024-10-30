<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Cinema.aspx.cs" Inherits="MyWeb.Cinema" %>

<%@ Register Src="~/Modules/uc_Cinema.ascx" TagPrefix="uc1" TagName="uc_Cinema" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:uc_Cinema runat="server" ID="uc_Cinema" />
</asp:Content>
