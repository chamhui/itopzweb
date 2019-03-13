<%@ Page Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="Submaster_Reload.aspx.vb" Inherits="WebItopz.Submaster_Reload" title="Reload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="margin: 10px">
        <tr>
            <td style="width: 178px">
            </td>
            <td colspan="2">
                <strong><span style="text-decoration: underline">
                Online Reload</span></strong></td>
            <td style="width: 171px">
            </td>
        </tr>
        <tr>
            <td style="width: 178px; height: 22px; text-align: right;">
                <span style="font-family: Arial">
                Agent HPNo</span></td>
            <td style="width: 17px; height: 22px; text-align: center;">
                <strong>:</strong></td>
            <td style="width: 160px; height: 22px">
                <asp:TextBox ID="txtAgentMSISDN" runat="server" Text="65"></asp:TextBox></td>
            <td style="width: 171px; height: 22px">
                <span style="font-size: 10pt">8XXXXXXX OR 9XXXXXXX</span></td>
        </tr>
        <tr>
            <td style="width: 178px; text-align: right;">
                <span style="font-family: Arial">Password</span></td>
            <td style="width: 17px; text-align: center;">
                <strong>:</strong></td>
            <td style="width: 160px">
                <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox></td>
            <td style="width: 171px">
            </td>
        </tr>
        <tr>
            <td style="width: 178px; text-align: right;">
                <span style="font-family: Arial">Reload HPNo</span></td>
            <td style="width: 17px; text-align: center;">
                <strong>:</strong></td>
            <td style="width: 160px">
                <asp:TextBox ID="txtReloadMSISDN" runat="server"></asp:TextBox></td>
            <td style="width: 171px">
                <span style="font-size: 10pt">8XXXXXXX OR 9XXXXXXX</span></td>
        </tr>
        <tr>
            <td style="width: 178px; text-align: right;">
                <span style="font-family: Arial">
                Reload Amount</span></td>
            <td style="width: 17px; text-align: center;">
                <strong>:</strong></td>
            <td style="width: 160px">
                <asp:TextBox ID="txtReloadAmount" runat="server"></asp:TextBox></td>
            <td style="width: 171px">
            </td>
        </tr>
        <tr>
            <td style="width: 178px; text-align: right;">
                Reload Telco</td>
            <td style="width: 17px">
                <strong><em>&nbsp;</em>:</strong></td>
            <td style="width: 160px">
                <asp:DropDownList ID="DDLTelco" runat="server">
                    <asp:ListItem>SINGTEL</asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 171px">
            </td>
        </tr>
        <tr>
            <td style="width: 178px; height: 21px">
            </td>
            <td style="width: 17px; height: 21px">
            </td>
            <td style="width: 160px; height: 21px">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
                <asp:Button ID="btnConfirm" runat="server" Text="Confirm" Visible="False" />
                <asp:Button ID="btnEdit" runat="server" Text="Edit" Visible="False" /></td>
            <td style="width: 171px; height: 21px">
            </td>
        </tr>
        <tr>
            <td style="width: 178px">
            </td>
            <td colspan="3">
                <asp:Label ID="lblErrorMsg" runat="server"></asp:Label></td>
        </tr>
    </table>
    <asp:Label ID="lblReloadMSISDN" runat="server" Style="font-size: 48pt; margin: 25px"></asp:Label><br />
    <asp:Label ID="lblReloadAmount" runat="server" Style="font-size: 48pt; margin: 25px"></asp:Label><br />
    <asp:Label ID="lblReloadTelco" runat="server" Style="font-size: 48pt; margin: 25px"></asp:Label><br />
</asp:Content>

