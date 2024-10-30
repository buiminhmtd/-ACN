<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="MyWeb.Detail" %>

<%@ Register Src="~/Modules/uc_Detail.ascx" TagPrefix="uc1" TagName="uc_Detail" %>
<%@ Register Src="~/Modules/uc_MovieByCinema.ascx" TagPrefix="uc1" TagName="uc_MovieByCinema" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <uc1:uc_Detail runat="server" ID="uc_Detail" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:uc_MovieByCinema runat="server" ID="uc_MovieByCinema" />
</asp:Content>
