<%@ Page Language="VB" AutoEventWireup="false" Inherits="WebItopz.Agent_DNDetails" Codebehind="Agent_DNDetails.aspx.vb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>DN Details</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow"
            BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataSourceID="SqlDataSource1"
            ForeColor="Black" GridLines="None">
            <FooterStyle BackColor="Tan" />
            <Columns>
                <asp:BoundField DataField="ReloadMSISDN" HeaderText="ReloadMSISDN" SortExpression="ReloadMSISDN" />
                <asp:BoundField DataField="ReloadAmount" HeaderText="ReloadAmount" SortExpression="ReloadAmount" />
                <asp:BoundField DataField="DNStatus" HeaderText="DNStatus" SortExpression="DNStatus" />
                <asp:BoundField DataField="DNTS" HeaderText="DNTS" SortExpression="DNTS" />
                <asp:BoundField DataField="DNRefNo" HeaderText="DNRefNo" SortExpression="DNRefNo" />
                <asp:BoundField DataField="CreatedTS" HeaderText="CreatedTS" SortExpression="CreatedTS" />
            </Columns>
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" Font-Names="Arial" Font-Size="Small" />
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <RowStyle Font-Names="Arial" Font-Size="Small" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
            SelectCommand="SELECT TOP (10) DNTS, DNRefNo, CreatedTS, ReloadMSISDN, ReloadAmount, DNStatus FROM DNReceived WHERE (DNReceivedID = @DNReceivedID)">
            <SelectParameters>
                <asp:QueryStringParameter Name="DNReceivedID" QueryStringField="DN" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
