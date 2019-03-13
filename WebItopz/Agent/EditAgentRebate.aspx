<%@ Page Language="VB" AutoEventWireup="false" Inherits="WebItopz.Agent_EditAgentDiscount" Codebehind="Agent_EditAgentDiscount.aspx.vb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Agent Product Rebate</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
            DataSourceID="SqlDataSource1" Width="198px" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" Height="1px">
            <Columns>
                <asp:TemplateField HeaderText="AgentID" SortExpression="AgentID">
                    <EditItemTemplate>
                        <asp:Label ID="lblAgentID" runat="server" Text='<%# Eval("AgentID") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblAgentID" runat="server" Text='<%# Bind("AgentID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField> 
                <asp:TemplateField HeaderText="RebateID" SortExpression="RebateID" Visible="False">
                    <EditItemTemplate>
                        <asp:Label ID="lblRebateID" runat="server" Text='<%# Eval("RebateID") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblRebateID" runat="server" Text='<%# Bind("RebateID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>                               
                <asp:BoundField DataField="Telco" HeaderText="Telco" SortExpression="Telco" ReadOnly="True" />
                <asp:BoundField DataField="Denomination" HeaderText="Denomination" SortExpression="Denomination" ReadOnly="True" />
                <asp:BoundField DataField="Rebate" HeaderText="Rebate%" SortExpression="Rebate" />
                <asp:BoundField DataField="UpdatedTS" HeaderText="UpdatedTS" SortExpression="UpdatedTS" ReadOnly="True">
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                    SortExpression="ID" Visible="False" />
     
            </Columns>
            <RowStyle BackColor="#F7F7DE" />
            <FooterStyle BackColor="#CCCC99" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <EmptyDataTemplate>
                No record found.
            </EmptyDataTemplate>
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues"
            ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>" DeleteCommand="DELETE FROM [ProductRebate] WHERE [RebateID] = @original_RebateID "
            OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT ProductInfo.Telco, AgentProductRebate.Denomination, AgentProductRebate.Rebate, AgentProductRebate.UpdatedTS, AgentProductRebate.ID, AgentProductRebate.AgentID, AgentProductRebate.RebateID FROM ProductInfo INNER JOIN AgentProductRebate ON ProductInfo.ProductID = AgentProductRebate.ProductID WHERE (ProductInfo.ProductID = @ProductID) AND (AgentProductRebate.AgentID = @AgentID) AND (AgentProductRebate.ProductID = @ProductID)"
            UpdateCommand="UPDATE AgentProductRebate SET Rebate = @Rebate WHERE (ID = @original_ID)">
            <DeleteParameters>
                <asp:Parameter Name="original_RebateID" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="Rebate" />
                <asp:Parameter Name="original_ID" />
            </UpdateParameters>
            <SelectParameters>
                <asp:QueryStringParameter Name="ProductID" QueryStringField="ProductID" />
                <asp:SessionParameter Name="AgentID" SessionField="AGENT_ID" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
