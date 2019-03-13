<%@ Page Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="Submaster_PurchaseTx.aspx.vb" Inherits="WebItopz.Submaster_Admin_PurchaseTx" title="PurchaseTx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="margin: 10px">
        <tr>
            <td style="width: 100px">
            </td>
            <td colspan="4" style="width: 200px">
                <strong><span style="text-decoration: underline">Last 100 Purchase Tx</span></strong></td>
            <td colspan="1" style="width: 305px">
                <asp:Label ID="lblErrorMsg" runat="server" Font-Size="Small" ForeColor="Red" Wrap="False"></asp:Label></td>
        </tr>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        CellPadding="4" DataSourceID="SqlDataSource2" ForeColor="Black" GridLines="Vertical"
        Style="margin: 10px" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px">
        <FooterStyle BackColor="#CCCC99" />
        <RowStyle BackColor="#F7F7DE" Font-Names="Arial" Font-Size="Medium" />
        <Columns>
            <asp:BoundField DataField="SimCardId" HeaderText="SimCardId" SortExpression="SimCardId" />
            <asp:BoundField DataField="SenderMSISDN" HeaderText="Sender" SortExpression="SenderMSISDN"/>
            <asp:BoundField DataField="MOMsg" HeaderText="MOMsg" SortExpression="MOMsg" >
             <ItemStyle Font-Size="Small" Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="CreatedTS" HeaderText="CreatedTS" SortExpression="CreatedTS" />         
        </Columns>
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Left" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#404040" Font-Bold="True" ForeColor="White" Font-Names="Arial" Font-Size="Small" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
        SelectCommand="SELECT TOP 100 SIMCardId, SenderMSISDN, MOMsg, CreatedTS From DNMsg WHERE (MOMsg = @Momsg) ORDER BY Id DESC"
        <SelectParameters>
            <asp:Parameter DefaultValue="MOMsg" Name="MOMsg" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>

