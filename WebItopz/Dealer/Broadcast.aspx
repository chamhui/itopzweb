<%@ Page Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" Inherits="WebItopz.Broadcast" title="Broadcast" Codebehind="Broadcast.aspx.vb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="margin: 20px">
        <tr>
            <td style="width: 25px">
            </td>
            <td colspan="2">
                <strong><span style="text-decoration: underline">Broadcast Message</span></strong></td>
        </tr>
        <tr>
            <td style="width: 25px">
                To</td>
            <td style="text-align: center">
                <strong>:</strong></td>
            <td style="width: 295px">
                <asp:DropDownList ID="DDLGroup" runat="server" Font-Names="Arial" Font-Size="Small">          
                    <asp:ListItem Value="DEALER">All Agent</asp:ListItem>   
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 25px; height: 23px">
                To</td>
            <td style="height: 23px; text-align: center;">
                <strong>:</strong></td>
            <td style="width: 295px; height: 23px">
                <asp:TextBox ID="txtMSISDN" runat="server"></asp:TextBox>
                8<span style="font-size: 10pt">XXXXXXX</span></td>
        </tr>
        <tr>
            <td style="width: 25px; height: 54px">
            </td>
            <td style="height: 54px">
            </td>
            <td style="width: 295px; height: 54px">
                <asp:TextBox ID="txtMsg" runat="server" Height="160px" TextMode="MultiLine" Width="301px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 25px">
            </td>
            <td>
            </td>
            <td style="width: 295px">
                <asp:Button ID="btnSend" runat="server" Text="Send" /></td>
        </tr>
        <tr>
            <td style="width: 25px">
            </td>
            <td>
            </td>
            <td style="width: 295px">
                <asp:Label ID="lblErrorMsg" runat="server" Font-Names="Arial" Font-Size="Small"></asp:Label></td>
        </tr>
    </table>
</asp:Content>

