<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="Submaster_EditMenuID.aspx.vb" Inherits="WebItopz.Submaster_EditMenuID" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Product Rebate</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="MenuID"
            DataSourceID="SqlDataSource1" Width="100px" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" Height="1px">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="Telco" HeaderText="Telco" ReadOnly="True" SortExpression="Telco" />                
                <asp:TemplateField HeaderText="Denomination"  SortExpression="Denomination"   >
                    <EditItemTemplate>
                        <asp:Textbox ID="txtDenomination" runat="server" Text='<%# Eval("Denomination") %>'></asp:Textbox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblDenomination" runat="server" Text='<%# Bind("Denomination") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="MenuID"  SortExpression="MenuID"   >
                    <EditItemTemplate>
                        <asp:Textbox ID="txtMenuID" runat="server" Text='<%# Eval("MenuID") %>'></asp:Textbox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblMenuID" runat="server" Text='<%# Bind("MenuID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>                
                <asp:BoundField DataField="CreatedTS" HeaderText="CreatedTS" ReadOnly="True" SortExpression="CreatedTS">
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
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
        <br />
        <table id="TABLE1" style="margin: 10px">
            <tr>
                <td style="width: 93px; height: 20px">
                </td>
                <td colspan="2" style="height: 20px">
                    <span style="font-size: 10pt; text-decoration: underline"><strong>Add New Menu</strong></span></td>
                <td style="width: 100px; height: 20px">
                </td>
            </tr>
            <tr>
                <td style="width: 93px; height: 26px; text-align: right">
                    <span style="font-size: 10pt">Denomination</span></td>
                <td style="font-size: 12pt; width: 20px; height: 26px; text-align: center">
                    <strong>:</strong></td>
                <td style="font-size: 12pt; width: 63px; height: 26px">
                    <asp:TextBox ID="txtDenomination" runat="server"></asp:TextBox></td>
                <td style="font-size: 12pt; width: 100px; height: 26px">
                    ie: 3-5</td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 93px; height: 21px; text-align: right">
                    <span style="font-size: 10pt">Menu ID</span></td>
                <td style="font-size: 12pt; width: 20px; height: 21px; text-align: center">
                    <strong>:</strong></td>
                <td style="font-size: 12pt; width: 63px; height: 21px">
                    <asp:TextBox ID="txtMenuID" runat="server"></asp:TextBox></td>
                <td style="font-size: 12pt; width: 100px; height: 21px">
                    ie: 0.25</td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 93px">
                </td>
                <td style="width: 20px">
                </td>
                <td colspan="2">
                    <asp:Button ID="btnAddMenu" runat="server" Text="  Add  " /></td>
            </tr>
            <tr style="font-size: 12pt">
                <td style="width: 93px">
                </td>
                <td colspan="4">
                    <asp:Label ID="lblErrorMsg" runat="server" Font-Names="Arial" Font-Size="Small" ForeColor="Red"></asp:Label></td>
            </tr>
        </table>
        <br />

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues"
            ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>" DeleteCommand="DELETE FROM [NPNMenu] WHERE [MenuID] = @original_MenuID "
            OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT ProductInfo.Telco, NPNMenu.ProductID, NPNMenu.Denomination, NPNMenu.MenuID, NPNMenu.CreatedTS FROM ProductInfo INNER JOIN NPNMenu ON ProductInfo.ProductID = NPNMenu.ProductID WHERE (ProductInfo.ProductID = @ProductID)"
            UpdateCommand="UPDATE NPNMenu SET CreatedTS = GETDATE() WHERE (MenuID = @original_MenuID)">
            <DeleteParameters>
                <asp:Parameter Name="original_MenuID" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="original_MenuID" />
            </UpdateParameters>
            <SelectParameters>
                <asp:QueryStringParameter Name="ProductID" QueryStringField="ProductID" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
        SelectCommand="SELECT CONVERT (varchar(10), AgentID) + ' ' + Name AS Name, AgentID FROM AgentInfo WHERE (ParentAgentID = '0')">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
        SelectCommand="SELECT Denomination FROM NPNMenu where productid = @ProductID">
                    <SelectParameters>
                <asp:QueryStringParameter Name="ProductID" QueryStringField="ProductID" />
            </SelectParameters>
    </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
