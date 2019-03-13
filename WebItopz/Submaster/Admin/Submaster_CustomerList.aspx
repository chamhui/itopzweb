<%@ Page Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="Submaster_CustomerList.aspx.vb" Inherits="WebItopz.Submaster_Admin_CustomerList" title="CustomerList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript">
    function openPopup(strOpen)
    {
        open(strOpen, "Info", "status=1, width=650, height=450, top=100, left=150");
    }
</script>
    <table style="margin: 10px">
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 159px">
                <strong><span style="text-decoration: underline">Agent Information</span></strong></td>
            <td style="width: 100px">
            </td>
        </tr>
    </table>
    <asp:Label ID="lblErrorGrid" runat="server" Font-Names="Arial" Font-Size="Small" ForeColor="Red"></asp:Label>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None"
        BorderWidth="1px" CellPadding="4" DataSourceID="SqlDataSource1"
        ForeColor="Black" GridLines="Vertical" Style="margin: 10px" DataKeyNames="NRIC" PageSize="20" Width="530px">
        <FooterStyle BackColor="#CCCC99" />
        <RowStyle BackColor="#F7F7DE" Font-Names="Arial" Font-Size="Small" />
        <Columns>
            <asp:CommandField ShowEditButton="True" />
                        <asp:TemplateField HeaderText="AgentID" SortExpression="AgentID" >
                <EditItemTemplate>
                    <asp:Label ID="lblAgentID" runat="server" Text='<%# Eval("NRIC") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblAgentID" runat="server" Text='<%# Bind("NRIC") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" >
                <ItemStyle Font-Size="Small" Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="Tel1" HeaderText="Tel1" SortExpression="Tel1" />
            <asp:BoundField DataField="Tel2" HeaderText="Tel2" SortExpression="Tel2" />
            <asp:BoundField DataField="Mobile1" HeaderText="Mobile1" SortExpression="Mobile1" />
            <asp:BoundField DataField="Mobile2" HeaderText="Mobile2" SortExpression="Mobile2" />
            <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
            <asp:BoundField DataField="BusinessAddress" HeaderText="BusinessAddress" SortExpression="BusinessAddress" />
            <asp:BoundField DataField="Remarks" HeaderText="Remarks" SortExpression="Remarks" />
        </Columns>
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Left" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#404040" Font-Bold="True" ForeColor="White" Font-Names="Arial" Font-Size="Small" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues"
        ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>" DeleteCommand="DELETE FROM [AgentInfo] WHERE [AgentID] = @original_AgentID AND [Name] = @original_Name AND [Gender] = @original_Gender AND [Race] = @original_Race AND [Status] = @original_Status AND [Email] = @original_Email AND [Address] = @original_Address AND [HPNo] = @original_HPNo AND [ICNo] = @original_ICNo AND [Bank] = @original_Bank AND [BankNo] = @original_BankNo AND [ParentAgentID] = @original_ParentAgentID AND [DiscountMaxis] = @original_DiscountMaxis AND [DiscountDiGi] = @original_DiscountDiGi AND [DiscountCelcom] = @original_DiscountCelcom AND [CreatedDate] = @original_CreatedDate"
        InsertCommand="INSERT INTO [AgentInfo] ([AgentID], [Name], [Gender], [Race], [Status], [Email], [Address], [HPNo], [ICNo], [Bank], [BankNo], [ParentAgentID], [DiscountMaxis], [DiscountDiGi], [DiscountCelcom], [CreatedDate]) VALUES (@AgentID, @Name, @Gender, @Race, @Status, @Email, @Address, @HPNo, @ICNo, @Bank, @BankNo, @ParentAgentID, @DiscountMaxis, @DiscountDiGi, @DiscountCelcom, @CreatedDate)"
        OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT NRIC, Name, Tel1, Tel2, Mobile1, Mobile2, Mobile3, Address, BusinessAddress, Remarks, Parent FROM CustomerList"
        UpdateCommand="UPDATE AgentInfo SET Name = @Name, Status = @Status, ParentAgentID = @ParentAgentID WHERE ([AgentID] = @original_AgentID)">
        <DeleteParameters>
            <asp:Parameter Name="original_AgentID" Type="Int32" />
            <asp:Parameter Name="original_Name" Type="String" />
            <asp:Parameter Name="original_Gender" Type="String" />
            <asp:Parameter Name="original_Race" Type="String" />
            <asp:Parameter Name="original_Status" Type="String" />
            <asp:Parameter Name="original_Email" Type="String" />
            <asp:Parameter Name="original_Address" Type="String" />
            <asp:Parameter Name="original_HPNo" Type="String" />
            <asp:Parameter Name="original_ICNo" Type="String" />
            <asp:Parameter Name="original_Bank" Type="String" />
            <asp:Parameter Name="original_BankNo" Type="String" />
            <asp:Parameter Name="original_ParentAgentID" Type="String" />
            <asp:Parameter Name="original_DiscountMaxis" Type="Decimal" />
            <asp:Parameter Name="original_DiscountDiGi" Type="Decimal" />
            <asp:Parameter Name="original_DiscountCelcom" Type="Decimal" />
            <asp:Parameter Name="original_CreatedDate" Type="DateTime" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="Status" Type="String" />
            <asp:Parameter Name="HPNo" Type="String" />
            <asp:Parameter Name="ParentAgentID" Type="String" />
            <asp:Parameter Name="original_AgentID" Type="Int32" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="AgentID" Type="Int32" />
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="Gender" Type="String" />
            <asp:Parameter Name="Race" Type="String" />
            <asp:Parameter Name="Status" Type="String" />
            <asp:Parameter Name="Email" Type="String" />
            <asp:Parameter Name="Address" Type="String" />
            <asp:Parameter Name="HPNo" Type="String" />
            <asp:Parameter Name="ICNo" Type="String" />
            <asp:Parameter Name="Bank" Type="String" />
            <asp:Parameter Name="BankNo" Type="String" />
            <asp:Parameter Name="ParentAgentID" Type="String" />
            <asp:Parameter Name="DiscountMaxis" Type="Decimal" />
            <asp:Parameter Name="DiscountDiGi" Type="Decimal" />
            <asp:Parameter Name="DiscountCelcom" Type="Decimal" />
            <asp:Parameter Name="CreatedDate" Type="DateTime" />
        </InsertParameters>
    </asp:SqlDataSource>
</asp:Content>

