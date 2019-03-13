<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="Submaster_ICDetails.aspx.vb" Inherits="WebItopz.Submaster_DNDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>IC Details</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow"
            BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataSourceID="SqlDataSource1"
            ForeColor="Black" GridLines="None">
            <FooterStyle BackColor="Tan" />
            <Columns>
                <asp:BoundField DataField="NRIC" HeaderText="NRIC" SortExpression="NRIC" />
                <asp:BoundField DataField="NAME" HeaderText="NAME" SortExpression="NAME" />
                <asp:BoundField DataField="LOANSTATUS" HeaderText="STATUS" SortExpression="LOANSTATUS" />
                <asp:BoundField DataField="LOANAMOUNT" HeaderText="LOANAMOUNT" SortExpression="LOANAMOUNT" />
                <asp:BoundField DataField="LOANTYPE" HeaderText="LOANTYPE" SortExpression="LOANTYPE" />
                <asp:BoundField DataField="COMPANY" HeaderText="COMPANY" SortExpression="COMPANY" />
                <asp:BoundField DataField="LastUpdatedTS" HeaderText="LastUpdatedTS" SortExpression="LastUpdatedTS" />
            </Columns>
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" Font-Names="Arial" Font-Size="Small" />
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <RowStyle Font-Names="Arial" Font-Size="Small" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
            SelectCommand="SELECT NRIC, NAME, LOANSTATUS, LOANAMOUNT, LOANTYPE, COMPANY, LastUpdatedTS FROM TxIn WHERE (NRIC = @NRIC)">
            <SelectParameters>
                <asp:QueryStringParameter Name="NRIC" QueryStringField="NRIC" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
