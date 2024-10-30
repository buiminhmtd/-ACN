<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MyWeb.Admin.Default" %>

<%@ Register Src="~/Admin/Modules/uc_MenuLeft.ascx" TagPrefix="uc1" TagName="uc_MenuLeft" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" border="0" cellspacing="0">
        <tr>
            <td id="col_left">
                <uc1:uc_MenuLeft runat="server" id="uc_MenuLeft" />
            </td>
            <td id="col_right">
                <div style="padding: 0 10px;">
                    <div>
                        <asp:PlaceHolder ID="controls" runat="server"></asp:PlaceHolder>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
