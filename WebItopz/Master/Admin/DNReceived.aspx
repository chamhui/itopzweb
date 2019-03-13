<%@ Page Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="DNReceived.aspx.vb" Inherits="WebItopz.Admin_DNReceived" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2"
        DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="None" Style="margin: 10px">
        <FooterStyle BackColor="Tan" />
        <Columns>
            <asp:BoundField DataField="DNReceivedID" HeaderText="DNReceivedID" SortExpression="DNReceivedID" />
            <asp:BoundField DataField="SIMCardID" HeaderText="SIMCardID" SortExpression="SIMCardID" />
            <asp:BoundField DataField="ReloadMSISDN" HeaderText="ReloadMSISDN" SortExpression="ReloadMSISDN" />
            <asp:BoundField DataField="ReloadAmount" HeaderText="ReloadAmount" SortExpression="ReloadAmount" />
            <asp:BoundField DataField="DNTS" HeaderText="DNTS" SortExpression="DNTS" />
            <asp:BoundField DataField="DNRefNo" HeaderText="DNRefNo" SortExpression="DNRefNo" />
            <asp:BoundField DataField="DNBalance" HeaderText="DNBalance" SortExpression="DNBalance" />
            <asp:BoundField DataField="DNStatus" HeaderText="DNStatus" SortExpression="DNStatus" />
            <asp:BoundField DataField="CreatedTS" HeaderText="CreatedTS" SortExpression="CreatedTS" />
        </Columns>
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
        SelectCommand="SELECT [DNReceivedID], [SIMCardID], [ReloadMSISDN], [ReloadAmount], [DNTS], [DNRefNo], [DNBalance], [DNStatus], [CreatedTS] FROM [DNReceived] ORDER BY [CreatedTS] DESC">
    </asp:SqlDataSource>
</asp:Content>

