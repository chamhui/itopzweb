<%@ Page Language="VB" AutoEventWireup="false" Inherits="WebItopz.Agent_EditDiscount" Codebehind="Agent_EditDiscount.aspx.vb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Agent Product Discount</title>
</head>
<body>
<script language="javascript">
    function openPopup(strOpen)
    {
        open(strOpen, "AgentProductRebate", "status=1, width=650, height=650, top=100, left=150, scrollbars=yes");
    }
</script>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
            DataSourceID="SqlDataSource1" Width="344px">
            <Columns>
                <asp:TemplateField HeaderText="AgentID" SortExpression="AgentID">
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("AgentID") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("AgentID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Telco" ReadOnly="True" HeaderText="Telco" SortExpression="Telco" />
                <asp:TemplateField HeaderText="Discount %" SortExpression="Discount">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Discount") %>' Width="65px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                            ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1"
                            ErrorMessage="RegularExpressionValidator" Font-Size="XX-Small" ValidationExpression="^\d+(\.\d{2})?$">Must Be Number! ie: 2.00</asp:RegularExpressionValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Discount") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="100px" />
                    <HeaderStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Rebate">
                    <ItemTemplate>
                    <a href="javascript:openPopup('<%# Eval("ProductID", "EditAgentRebate.aspx?ProductID={0}&") %>AgentID=<%# Eval("AgentID") %>')">View</a>
                    </ItemTemplate>
                </asp:TemplateField>                   
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" >
                    <ItemStyle Width="10px" Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="ProductID" HeaderText="ProductID" InsertVisible="False"
                    ReadOnly="True" SortExpression="ProductID" Visible="False" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues"
            ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>" DeleteCommand="DELETE FROM [AgentProduct] WHERE [ID] = @original_ID AND (([AgentID] = @original_AgentID) OR ([AgentID] IS NULL AND @original_AgentID IS NULL)) AND (([ProductID] = @original_ProductID) OR ([ProductID] IS NULL AND @original_ProductID IS NULL)) AND (([Discount] = @original_Discount) OR ([Discount] IS NULL AND @original_Discount IS NULL)) AND (([Status] = @original_Status) OR ([Status] IS NULL AND @original_Status IS NULL))"
            InsertCommand="INSERT INTO [AgentProduct] ([AgentID], [ProductID], [Discount], [Status]) VALUES (@AgentID, @ProductID, @Discount, @Status)"
            OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT AgentProduct.ID, AgentProduct.AgentID, ProductInfo.Telco, AgentProduct.Discount, AgentProduct.Status, ProductInfo.ProductID FROM AgentProduct INNER JOIN ProductInfo ON AgentProduct.ProductID = ProductInfo.ProductID WHERE (AgentProduct.AgentID = @AgentID)"
            UpdateCommand="UPDATE [AgentProduct] SET  [Discount] = @Discount, [Status] = @Status WHERE [ID] = @original_ID  ">
            <SelectParameters>
                <asp:QueryStringParameter Name="AgentID" QueryStringField="AGENTID" Type="Int32" />
            </SelectParameters>
            <DeleteParameters>
                <asp:Parameter Name="original_ID" Type="Int32" />
                <asp:Parameter Name="original_AgentID" Type="Int32" />
                <asp:Parameter Name="original_ProductID" Type="String" />
                <asp:Parameter Name="original_Discount" Type="Decimal" />
                <asp:Parameter Name="original_Status" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="Discount" Type="Decimal" />
                <asp:Parameter Name="Status" Type="String" />
                <asp:Parameter Name="original_ID" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="AgentID" Type="Int32" />
                <asp:Parameter Name="ProductID" Type="String" />
                <asp:Parameter Name="Discount" Type="Decimal" />
                <asp:Parameter Name="Status" Type="String" />
            </InsertParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
