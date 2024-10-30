<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Booking.aspx.cs" Inherits="MyWeb.Booking" %>

<%@ Register Src="~/Modules/uc_Booking.ascx" TagPrefix="uc1" TagName="uc_Booking" %>
<%@ Register Src="~/Modules/uc_MovieBooking.ascx" TagPrefix="uc1" TagName="uc_MovieBooking" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <uc1:uc_Booking runat="server" ID="uc_Booking" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:uc_MovieBooking runat="server" id="uc_MovieBooking" />
</asp:Content>
