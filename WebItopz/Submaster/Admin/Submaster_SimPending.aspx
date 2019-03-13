<%@ Page Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="Submaster_SimPending.aspx.vb" Inherits="WebItopz.Submaster_Admin_SimPending" title="Pending" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="margin: 10px">
        <tr>
            <td style="width: 100px">
            </td>
            <td colspan="4" style="width: 82px">
                <strong><span style="text-decoration: underline">Sim Pending</span></strong></td>
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
            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
            <asp:BoundField DataField="Telco" HeaderText="Telco" SortExpression="Telco" />
            <asp:BoundField DataField="Robin" HeaderText="Robin" SortExpression="Robin" />
            <asp:BoundField DataField="IMSI" HeaderText="IMSI" SortExpression="IMSI" />
            <asp:BoundField DataField="UpdatedTS" HeaderText="UpdatedTS" SortExpression="Updated" />
            <asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="SimPending.aspx?ID={0}&amp;action=RETRY"
                HeaderText="Retry" Text="Retry" />
            <asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="SimPending.aspx?ID={0}&amp;action=Refund"
                HeaderText="Refund" Text="Refund" />
            <asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="SimPending.aspx?ID={0}&amp;action=Cancel"
                HeaderText="Cancel" Text="Cancel" />
            <asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="SimPending.aspx?ID={0}&amp;action=Success"
                HeaderText="Success" Text="Success" />              
        </Columns>
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Left" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#404040" Font-Bold="True" ForeColor="White" Font-Names="Arial" Font-Size="Small" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White"
        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="SqlDataSource2"
        ForeColor="Black" GridLines="Vertical" Style="margin: 10px" AllowPaging="True" Width="932px">
        <FooterStyle BackColor="#CCCC99" />
        <RowStyle BackColor="#F7F7DE" Font-Size="Small" />
        <Columns>
            <asp:BoundField DataField="MOTS" HeaderText="MOTS" SortExpression="MOTS" />
            <asp:BoundField DataField="MessageTS" HeaderText="MessageTS" SortExpression="MessageTS" />
            <asp:BoundField DataField="MOMsg" HeaderText="MOMsg" SortExpression="MOMsg" />
            <asp:BoundField DataField="SenderMSISDN" HeaderText="SenderMSISDN" SortExpression="SenderMSISDN" />
        </Columns>
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#404040" Font-Bold="True" ForeColor="White" Font-Names="Arial" Font-Size="Small" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
        SelectCommand="SELECT TOP 5 [MOTS], [CreatedTS], [MOMsg], [SenderMSISDN] FROM [DNMsgs] WHERE ([MOMsg] LIKE @MOMsg + '%') OR ([MOMsg] LIKE @MOMsg1 + '%') OR ([MOMsg] LIKE @MOMsg2 + '%') ORDER BY [CreatedTS] DESC &#13;&#10;">
        <SelectParameters>
            <asp:Parameter DefaultValue="Customer Number not found" Name="MOMsg" Type="String" />
            <asp:Parameter DefaultValue="System error. Please try again later. Your bal is" Name="MOMsg1" />
            <asp:Parameter DefaultValue="Transaction Failed. You are not authorized to perform postpaid payment"
                Name="MOMsg2" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
        SelectCommand="SELECT [Status], [IMSI], [Robin], [ID], [UpdatedTS], [Telco] FROM [TxActivation] WHERE ([Status] = 'DONE' or ([Status] = 'SUCCESS' and [MSISDN] = '')) order by ID Desc">
        <SelectParameters>
            <asp:Parameter DefaultValue="INACTIVE" Name="Status" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>

