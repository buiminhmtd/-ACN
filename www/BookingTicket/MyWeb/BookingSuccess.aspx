<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="BookingSuccess.aspx.cs" Inherits="MyWeb.BookingSuccess" %>

<%@ Register Src="~/Modules/uc_BookingSuccess.ascx" TagPrefix="uc1" TagName="uc_BookingSuccess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:uc_BookingSuccess runat="server" id="uc_BookingSuccess" />
</asp:Content>
