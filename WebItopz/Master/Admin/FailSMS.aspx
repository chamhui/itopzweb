<%@ Page Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="FailSMS.aspx.vb" Inherits="WebItopz.Admin_FailSMS" title="FailSMS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="margin: 10px">
        <tr>
            <td style="width: 100px">
            </td>
            <td colspan="4" style="width: 82px">
                <strong><span style="text-decoration: underline">FailSMS</span></strong></td>
            <td colspan="1" style="width: 305px">
                <asp:Label ID="lblErrorMsg" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label></td>
        </tr>
    </table>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Vertical"
        Style="margin: 10px" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px">
        <FooterStyle BackColor="#CCCC99" />
        <RowStyle BackColor="#F7F7DE" Font-Names="Arial" Font-Size="Medium" />
        <Columns>
            <asp:BoundField DataField="MSISDN" HeaderText="MSISDN" SortExpression="MSISDN" />
            <asp:BoundField DataField="MessageOut" HeaderText="MessageOut" SortExpression="MessageOut" />
            <asp:BoundField DataField="AgentID" HeaderText="AgentID" SortExpression="AgentID" />
            <asp:BoundField DataField="Robin" HeaderText="P" SortExpression="Robin" />
            <asp:BoundField DataField="AgentID" HeaderText="AgentID" SortExpression="AgentID" />
            <asp:BoundField DataField="CreatedTS" HeaderText="CreatedTS" SortExpression="CreatedTS" />
            <asp:BoundField DataField="Retry" HeaderText="Retry" SortExpression="Retry" />
            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
            <asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="FailSMS.aspx?ID={0}&amp;action=ResentMT"
                HeaderText="ResentMT" Text="ResentMT" />
<%--            <asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="NoDN.aspx?ID={0}&amp;action=Refund"
                HeaderText="Refund" Text="Refund" />
            <asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="NoDN.aspx?ID={0}&amp;action=Cancel"
                HeaderText="Cancel" Text="Cancel" />
            <asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="NoDN.aspx?ID={0}&amp;action=Success"
                HeaderText="Success" Text="Success" />--%>
        </Columns>
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Left" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#404040" Font-Bold="True" ForeColor="White" Font-Names="Arial" Font-Size="Small" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
        SelectCommand="SELECT ID, Robin, MessageOut, AgentID, MSISDN, CreatedTS, Retry, Status FROM TxOut WHERE (Status = @Status) AND (Retry = '5') ORDER BY ID DESC">
        <SelectParameters>
            <asp:Parameter DefaultValue="PENDING" Name="Status" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>

