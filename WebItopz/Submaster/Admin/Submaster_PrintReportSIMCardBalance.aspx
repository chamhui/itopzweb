<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="Submaster_PrintReportSIMCardBalance.aspx.vb" Inherits="WebItopz.Submaster_PrintReportProfit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>PrintReportProfit</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;
        <asp:Label ID="lblDate" runat="server"></asp:Label><br />
        <table style="margin: 10px">
               <tr>
                        <td style="width: 0px" valign="top">
                <asp:GridView ID="GridView2" runat="server" DataSourceID="SqlDataSource2" AutoGenerateColumns="False" AllowSorting="True" DataKeyNames="ProcessorID,SIMCardID" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
            <Columns>
                <asp:BoundField DataField="ProcessorID" HeaderText="ProcessorID" ReadOnly="True"
                    SortExpression="ProcessorID" />
                <asp:BoundField DataField="SIMCardID" HeaderText="SIMCardID" ReadOnly="True" SortExpression="SIMCardID" />
                <asp:BoundField DataField="Balance" HeaderText="Balance" ReadOnly="True" SortExpression="Balance" />
            </Columns>
            <HeaderStyle Font-Size="Small" ForeColor="White" BackColor="#6B696B" Font-Bold="True" />
            <EditRowStyle Font-Size="Medium" />
            <RowStyle BackColor="#F7F7DE" />
            <FooterStyle BackColor="#CCCC99" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        </TD>
                    <td style="width: 0px" valign="top">
                <asp:GridView ID="GridView3" runat="server" DataSourceID="SqlDataSource3" AutoGenerateColumns="False" AllowSorting="True" DataKeyNames="ProcessorID,SIMCardID" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
            <Columns>
                <asp:BoundField DataField="Balance" HeaderText="Balance" ReadOnly="True" SortExpression="Balance" />
            </Columns>
            <HeaderStyle Font-Size="Small" ForeColor="White" BackColor="#6B696B" Font-Bold="True" />
            <EditRowStyle Font-Size="Medium" />
            <RowStyle BackColor="#F7F7DE" />
            <FooterStyle BackColor="#CCCC99" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        </TD>
                            <td style="width: 0px" valign="top">
                <asp:GridView ID="GridView4" runat="server" DataSourceID="SqlDataSource4" AutoGenerateColumns="False" AllowSorting="True" DataKeyNames="ProcessorID,SIMCardID" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
            <Columns>
                <asp:BoundField DataField="Balance" HeaderText="Balance" ReadOnly="True" SortExpression="Balance" />
            </Columns>
            <HeaderStyle Font-Size="Small" ForeColor="White" BackColor="#6B696B" Font-Bold="True" />
            <EditRowStyle Font-Size="Medium" />
            <RowStyle BackColor="#F7F7DE" />
            <FooterStyle BackColor="#CCCC99" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        </TD>
                            <td style="width: 0px" valign="top">
                <asp:GridView ID="GridView5" runat="server" DataSourceID="SqlDataSource5" AutoGenerateColumns="False" AllowSorting="True" DataKeyNames="ProcessorID,SIMCardID" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
            <Columns>
                <asp:BoundField DataField="Balance" HeaderText="Balance" ReadOnly="True" SortExpression="Balance" />
            </Columns>
            <HeaderStyle Font-Size="Small" ForeColor="White" BackColor="#6B696B" Font-Bold="True" />
            <EditRowStyle Font-Size="Medium" />
            <RowStyle BackColor="#F7F7DE" />
            <FooterStyle BackColor="#CCCC99" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        </TD>
                            <td style="width: 0px" valign="top">
                <asp:GridView ID="GridView6" runat="server" DataSourceID="SqlDataSource6" AutoGenerateColumns="False" AllowSorting="True" DataKeyNames="ProcessorID,SIMCardID" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
            <Columns>
                <asp:BoundField DataField="Balance" HeaderText="Balance" ReadOnly="True" SortExpression="Balance" />
            </Columns>
            <HeaderStyle Font-Size="Small" ForeColor="White" BackColor="#6B696B" Font-Bold="True" />
            <EditRowStyle Font-Size="Medium" />
            <RowStyle BackColor="#F7F7DE" />
            <FooterStyle BackColor="#CCCC99" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        </TD>
                                    <td style="width: 0px" valign="top">
                <asp:GridView ID="GridView7" runat="server" DataSourceID="SqlDataSource7" AutoGenerateColumns="False" AllowSorting="True" DataKeyNames="ProcessorID,SIMCardID" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
            <Columns>
                <asp:BoundField DataField="Balance" HeaderText="Balance" ReadOnly="True" SortExpression="Balance" />
            </Columns>
            <HeaderStyle Font-Size="Small" ForeColor="White" BackColor="#6B696B" Font-Bold="True" />
            <EditRowStyle Font-Size="Medium" />
            <RowStyle BackColor="#F7F7DE" />
            <FooterStyle BackColor="#CCCC99" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        </TD>
                                    <td style="width: 0px" valign="top">
                <asp:GridView ID="GridView8" runat="server" DataSourceID="SqlDataSource8" AutoGenerateColumns="False" AllowSorting="True" DataKeyNames="ProcessorID,SIMCardID" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
            <Columns>
                <asp:BoundField DataField="Balance" HeaderText="Balance" ReadOnly="True" SortExpression="Balance" />
            </Columns>
            <HeaderStyle Font-Size="Small" ForeColor="White" BackColor="#6B696B" Font-Bold="True" />
            <EditRowStyle Font-Size="Medium" />
            <RowStyle BackColor="#F7F7DE" />
            <FooterStyle BackColor="#CCCC99" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        </TD>
                                            <td style="width: 0px" valign="top">
                <asp:GridView ID="GridView9" runat="server" DataSourceID="SqlDataSource9" AutoGenerateColumns="False" AllowSorting="True" DataKeyNames="ProcessorID,SIMCardID" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
            <Columns>
                <asp:BoundField DataField="Balance" HeaderText="Balance" ReadOnly="True" SortExpression="Balance" />
            </Columns>
            <HeaderStyle Font-Size="Small" ForeColor="White" BackColor="#6B696B" Font-Bold="True" />
            <EditRowStyle Font-Size="Medium" />
            <RowStyle BackColor="#F7F7DE" />
            <FooterStyle BackColor="#CCCC99" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        </TD>
        </tr>
        </table>

        <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" AllowSorting="True" DataKeyNames="ProcessorID,SIMCardID" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
            <Columns>
                <asp:BoundField DataField="ProcessorID" HeaderText="ProcessorID" ReadOnly="True"
                    SortExpression="ProcessorID" />
                <asp:BoundField DataField="SIMCardID" HeaderText="SIMCardID" ReadOnly="True" SortExpression="SIMCardID" />
                <asp:BoundField DataField="Balance" HeaderText="Balance" ReadOnly="True" SortExpression="Balance" />
            </Columns>
            <HeaderStyle Font-Size="Small" ForeColor="White" BackColor="#6B696B" Font-Bold="True" />
            <EditRowStyle Font-Size="Medium" />
            <RowStyle BackColor="#F7F7DE" />
            <FooterStyle BackColor="#CCCC99" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
        
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>" SelectCommand="SELECT ProcessorID, SIMCardID, (SELECT TOP (1) DNBalance FROM DNReceived WHERE (SIMCardID = Processor.SIMCardID) ORDER BY CreatedTS DESC) AS Balance FROM Processor Where ((ProcessorID LIKE 'M1%') or (ProcessorID LIKE 'STARHUB%') or (ProcessorID LIKE 'PINOY%') or (ProcessorID LIKE 'INDO%'))">
        </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>" SelectCommand="SELECT ProcessorID, SIMCardID, (SELECT TOP (1) DNBalance FROM DNReceived WHERE (SIMCardID = Processor.SIMCardID) and ReloadAmount = '5' and DNBalance != '' ORDER BY CreatedTS DESC) AS Balance FROM Processor Where ProcessorID LIKE 'SINGTELP%' ">
        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>" SelectCommand="SELECT ProcessorID, SIMCardID, (SELECT TOP (1) DNBalance FROM DNReceived WHERE (SIMCardID = Processor.SIMCardID) and ReloadAmount = '10' and DNBalance != '' ORDER BY CreatedTS DESC) AS Balance FROM Processor Where ProcessorID LIKE 'SINGTELP%'">
        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>" SelectCommand="SELECT ProcessorID, SIMCardID, (SELECT TOP (1) DNBalance FROM DNReceived WHERE (SIMCardID = Processor.SIMCardID) and ReloadAmount = '15' and DNBalance != '' ORDER BY CreatedTS DESC) AS Balance FROM Processor Where ProcessorID LIKE 'SINGTELP%'">
        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>" SelectCommand="SELECT ProcessorID, SIMCardID, (SELECT TOP (1) DNBalance FROM DNReceived WHERE (SIMCardID = Processor.SIMCardID) and ReloadAmount = '20' and DNBalance != '' ORDER BY CreatedTS DESC) AS Balance FROM Processor Where ProcessorID LIKE 'SINGTELP%'">
        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>" SelectCommand="SELECT ProcessorID, SIMCardID, (SELECT TOP (1) DNBalance FROM DNReceived WHERE (SIMCardID = Processor.SIMCardID) and ReloadAmount = '28' and DNBalance != '' ORDER  BY CreatedTS DESC) AS Balance FROM Processor Where ProcessorID LIKE 'SINGTELP%'">
        </asp:SqlDataSource>
                                <asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>" SelectCommand="SELECT ProcessorID, SIMCardID, (SELECT TOP (1) DNBalance FROM DNReceived WHERE (SIMCardID = Processor.SIMCardID) and ReloadAmount = '18' and DNBalance != '' ORDER BY CreatedTS DESC) AS Balance FROM Processor Where ProcessorID LIKE 'SINGTELP%'">
        </asp:SqlDataSource>
                                <asp:SqlDataSource ID="SqlDataSource8" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>" SelectCommand="SELECT ProcessorID, SIMCardID, (SELECT TOP (1) DNBalance FROM DNReceived WHERE (SIMCardID = Processor.SIMCardID) and ReloadAmount = '50' and DNBalance != '' ORDER BY CreatedTS DESC) AS Balance FROM Processor Where ProcessorID LIKE 'SINGTELP%'">
                                </asp:SqlDataSource>
                                <asp:SqlDataSource ID="SqlDataSource9" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>" SelectCommand="SELECT ProcessorID, SIMCardID, (SELECT TOP (1) DNBalance FROM DNReceived WHERE (SIMCardID = Processor.SIMCardID) and ReloadAmount = '22' and DNBalance != '' ORDER BY CreatedTS DESC) AS Balance FROM Processor Where ProcessorID LIKE 'SINGTELP%'">
        </asp:SqlDataSource>
        &nbsp; &nbsp;
    
    </div>
        &nbsp;
    </form>
</body>
</html>
