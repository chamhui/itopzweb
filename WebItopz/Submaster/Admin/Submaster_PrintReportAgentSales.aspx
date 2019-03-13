<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="Submaster_PrintReportAgentSales.aspx.vb" Inherits="WebItopz.Submaster_PrintReportAgentSales" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>PrintReportAgentSales</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="txtDateFrom" runat="server" Width="82px"></asp:TextBox>
        <asp:TextBox ID="txtDateTo" runat="server" Width="84px"></asp:TextBox>
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource2"
            DataTextField="Name" DataValueField="AgentID">
        </asp:DropDownList>
        <asp:Button ID="btnGenerate" runat="server" Text="Generate" />&nbsp;<br />
        <table>
            <tr>
                <td style="width: 65px">
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource3">
                        <Columns>
                            <asp:BoundField DataField="ToTal" HeaderText="Success$" SortExpression="ToTal" />
                        </Columns>
                    </asp:GridView>
                </td>
                <td style="width: 75px">
                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource4">
                        <Columns>
                            <asp:BoundField DataField="ToTal" HeaderText="Refunded$" ReadOnly="True" SortExpression="ToTal" />
                        </Columns>
                    </asp:GridView>
                </td>
                <td style="width: 61px">
                    <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource5">
                        <Columns>
                            <asp:BoundField DataField="ToTal" HeaderText="Cancelled$" ReadOnly="True" SortExpression="ToTal" />
                        </Columns>
                    </asp:GridView>
                </td>
                <td style="width: 55px">
                    <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource6">
                        <Columns>
                            <asp:BoundField DataField="ToTal" HeaderText="Pending$" ReadOnly="True" SortExpression="ToTal" />
                        </Columns>
                    </asp:GridView>
                </td>
                <td style="width: 100px">
                </td>
            </tr>
        </table>
        <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" AllowSorting="True">
            <Columns>
                <asp:TemplateField HeaderText="No."><ItemTemplate ><%#Container.DataItemIndex+1%></ItemTemplate></asp:TemplateField>
                <asp:BoundField DataField="ReloadTelco" HeaderText="ReloadTelco" SortExpression="ReloadTelco" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                <asp:BoundField DataField="ReloadAmount" HeaderText="ReloadAmount" SortExpression="ReloadAmount" />
                <asp:BoundField DataField="ReloadMSISDN" HeaderText="ReloadMSISDN" SortExpression="ReloadMSISDN" />
                <asp:BoundField DataField="CreatedTS" HeaderText="CreatedTS" SortExpression="CreatedTS" />
            </Columns>
            <HeaderStyle Font-Size="Small" ForeColor="#000040" />
            <EditRowStyle Font-Size="Medium" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>" SelectCommand="SELECT MSISDN, AgentID, ReloadTelco, DNReceivedID, Status, ReloadAmount, ReloadMSISDN, CreatedTS FROM TxIn WHERE (AgentID = @AgentID) AND (REPLACE(CONVERT (char(10), CreatedTS, 111), '/', '') >= @CreatedTS) AND (REPLACE(CONVERT (char(10), CreatedTS, 111), '/', '') <= @CreatedTS2)">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="AgentID" PropertyName="SelectedValue"
                    Type="String" />
                <asp:ControlParameter ControlID="txtDateFrom" Name="CreatedTS" PropertyName="Text" />
                <asp:ControlParameter ControlID="txtDateTo" Name="CreatedTS2" PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
            SelectCommand="SELECT AgentID, CONVERT (varchar(10), AgentID) + ' ' + Name AS Name FROM AgentInfo WHERE Agentlvl like @Agentlvl+@agentid+'|%' ">
					 <SelectParameters>
            <asp:SessionParameter Name="agentid" SessionField="AGENT_ID" />
						 <asp:SessionParameter Name="Agentlvl" SessionField="AGENT_AGENTLVL" />
        </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
            SelectCommand="SELECT Sum(ReloadAmount) as ToTal  FROM [TxIn] WHERE (AgentID = @AgentID) AND (REPLACE(CONVERT (char(10), CreatedTS, 111), '/', '') >= @CreatedTS) AND (REPLACE(CONVERT (char(10), CreatedTS, 111), '/', '') <= @CreatedTS2) and Status='SUCCESS'">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="AgentID" PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="txtDateFrom" Name="CreatedTS" PropertyName="Text" />
                <asp:ControlParameter ControlID="txtDateTo" Name="CreatedTS2" PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
            SelectCommand="SELECT Sum(ReloadAmount) as ToTal  FROM [TxIn] WHERE (AgentID = @AgentID) AND (REPLACE(CONVERT (char(10), CreatedTS, 111), '/', '') >= @CreatedTS) AND (REPLACE(CONVERT (char(10), CreatedTS, 111), '/', '') <= @CreatedTS2) and Status='REFUNDED'">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="AgentID" PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="txtDateFrom" Name="CreatedTS" PropertyName="Text" />
                <asp:ControlParameter ControlID="txtDateTo" Name="CreatedTS2" PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
        <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
            SelectCommand="SELECT Sum(ReloadAmount) as ToTal  FROM [TxIn] WHERE (AgentID = @AgentID) AND (REPLACE(CONVERT (char(10), CreatedTS, 111), '/', '') >= @CreatedTS) AND (REPLACE(CONVERT (char(10), CreatedTS, 111), '/', '') <= @CreatedTS2) and Status='CANCELLED'">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="AgentID" PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="txtDateFrom" Name="CreatedTS" PropertyName="Text" />
                <asp:ControlParameter ControlID="txtDateTo" Name="CreatedTS2" PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
            SelectCommand="SELECT Sum(ReloadAmount) as ToTal  FROM [TxIn] WHERE (AgentID = @AgentID) AND (REPLACE(CONVERT (char(10), CreatedTS, 111), '/', '') >= @CreatedTS) AND (REPLACE(CONVERT (char(10), CreatedTS, 111), '/', '') <= @CreatedTS2) and Status='PENDING'">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="AgentID" PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="txtDateFrom" Name="CreatedTS" PropertyName="Text" />
                <asp:ControlParameter ControlID="txtDateTo" Name="CreatedTS2" PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
