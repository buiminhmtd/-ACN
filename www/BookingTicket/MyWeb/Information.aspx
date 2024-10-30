<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Information.aspx.cs" Inherits="MyWeb.Information" %>

<%@ Register Src="~/Modules/uc_Information.ascx" TagPrefix="uc1" TagName="uc_Information" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:uc_Information runat="server" id="uc_Information" />
</asp:Content>
