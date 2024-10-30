<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Movie.aspx.cs" Inherits="MyWeb.Movie" %>

<%@ Register Src="~/Modules/uc_Movie.ascx" TagPrefix="uc1" TagName="uc_Movie" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:uc_Movie runat="server" id="uc_Movie" />
</asp:Content>
