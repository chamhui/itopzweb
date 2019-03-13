<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="Submaster_PrintReportAgentTopUpAll.aspx.vb" Inherits="WebItopz.Submaster_PrintReportAgentTopUpAll" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>PrintReportAgentSalesAll</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="txtDateFrom" runat="server" Width="82px"></asp:TextBox>
        <asp:TextBox ID="txtDateTo" runat="server" Width="84px"></asp:TextBox>
        &nbsp;
        <asp:Button ID="btnGenerate" runat="server" Text="Generate" />&nbsp;<br />
        <table>
            <tr>
                <td style="width: 65px">
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource3">
                        <Columns>
                            <asp:BoundField DataField="Column1" HeaderText="Column1" ReadOnly="True" SortExpression="Column1" />
                        </Columns>
                    </asp:GridView>
                </td>
                <td style="width: 75px">
                    &nbsp;</td>
                <td style="width: 61px">
                    &nbsp;</td>
                <td style="width: 55px">
                    &nbsp;</td>
                <td style="width: 100px">
                </td>
            </tr>
        </table>
        <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" AllowSorting="True">
            <Columns>
            <asp:BoundField DataField="AgentID" HeaderText="AgentID" SortExpression="AgentID" />

                <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount" />
                <asp:BoundField DataField="Remarks" HeaderText="Remarks" SortExpression="Remarks" />
                <asp:BoundField DataField="CreatedTS" HeaderText="CreatedTS" SortExpression="CreatedTS" />
            </Columns>
            <HeaderStyle Font-Size="Small" ForeColor="#000040" />
            <EditRowStyle Font-Size="Medium" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>" SelectCommand="SELECT Amount , BankIn, Remarks, AgentID, CreatedTS FROM AgentTopupTx WHERE (REPLACE(CONVERT (char(10), CreatedTS, 111), '/', '') >= @CreatedTS) AND (REPLACE(CONVERT (char(10), CreatedTS, 111), '/', '') <= @CreatedTS2) AND AgentID in (SELECT [AgentID] FROM [AgentInfo] WHERE (Agentlvl like @Agentlvl & @Agentid & '|%'))">
            <SelectParameters>
													   <asp:SessionParameter Name="Agentid" SessionField="AGENT_ID" />
						   <asp:SessionParameter Name="Agentlvl" SessionField="AGENT_AGENTLVL" />
                <asp:ControlParameter ControlID="txtDateFrom" Name="CreatedTS" PropertyName="Text" />
                <asp:ControlParameter ControlID="txtDateTo" Name="CreatedTS2" PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
            SelectCommand="SELECT Sum(Amount)  FROM [AgentTopupTx] WHERE AgentID in (SELECT [AgentID] FROM [AgentInfo] WHERE (Agentlvl like @Agentlvl & @Agentid & '|%')) AND (REPLACE(CONVERT (char(10), CreatedTS, 111), '/', '') >= @CreatedTS) AND (REPLACE(CONVERT (char(10), CreatedTS, 111), '/', '') <= @CreatedTS2)&#13;&#10;">
            <SelectParameters>
													   <asp:SessionParameter Name="Agentid" SessionField="AGENT_ID" />
						   <asp:SessionParameter Name="Agentlvl" SessionField="AGENT_AGENTLVL" />
                <asp:ControlParameter ControlID="txtDateFrom" Name="CreatedTS" PropertyName="Text" />
                <asp:ControlParameter ControlID="txtDateTo" Name="CreatedTS2" PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
        &nbsp;
    </form>
</body>
</html>
