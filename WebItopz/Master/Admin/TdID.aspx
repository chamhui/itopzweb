<%@ Page Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="TdID.aspx.vb" Inherits="WebItopz.TdID" title="SimCard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="SIMCardID"
        DataSourceID="SqlDataSource1" Style="margin: 10px" ForeColor="Black" GridLines="Vertical">
        <FooterStyle BackColor="#CCCC99" />
        <RowStyle BackColor="#F7F7DE" />
        <Columns>
            <asp:CommandField ShowEditButton="True" />
            <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" />
            <asp:BoundField DataField="Distrubutor" HeaderText="Distrubutor" SortExpression="Distrubutor" />
            <asp:BoundField DataField="RegFig" HeaderText="RegFig" SortExpression="RegFig" />
            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
        </Columns>
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#404040" Font-Bold="True" ForeColor="White" Font-Names="Arial" Font-Size="Small" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
        SelectCommand="SELECT [SIMCardID], [Telco], [Balance], [Status] FROM [SIMCard] order by Telco Asc" ConflictDetection="CompareAllValues" DeleteCommand="DELETE FROM [SIMCard] WHERE [SIMCardID] = @original_SIMCardID AND [Telco] = @original_Telco AND [Balance] = @original_Balance AND [Status] = @original_Status" InsertCommand="INSERT INTO [SIMCard] ([SIMCardID], [Telco], [Balance], [Status]) VALUES (@SIMCardID, @Telco, @Balance, @Status)" OldValuesParameterFormatString="original_{0}" UpdateCommand="UPDATE [SIMCard] SET [SIMCardID] = @SIMCardID, [Telco] = @Telco, [Balance] = @Balance, [Status] = @Status WHERE [SIMCardID] = @original_SIMCardID AND [Telco] = @original_Telco AND [Balance] = @original_Balance AND [Status] = @original_Status">
        <DeleteParameters>
            <asp:Parameter Name="original_SIMCardID" Type="String" />
            <asp:Parameter Name="original_Telco" Type="String" />
            <asp:Parameter Name="original_Balance" Type="Decimal" />
            <asp:Parameter Name="original_Status" Type="String" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="SIMCardID" />
            <asp:Parameter Name="Telco" Type="String" />
            <asp:Parameter Name="Balance" Type="Decimal" />
            <asp:Parameter Name="Status" Type="String" />
            <asp:Parameter Name="original_SIMCardID" Type="String" />
            <asp:Parameter Name="original_Telco" Type="String" />
            <asp:Parameter Name="original_Balance" Type="Decimal" />
            <asp:Parameter Name="original_Status" Type="String" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="SIMCardID" Type="String" />
            <asp:Parameter Name="Telco" Type="String" />
            <asp:Parameter Name="Balance" Type="Decimal" />
            <asp:Parameter Name="Status" Type="String" />
        </InsertParameters>
    </asp:SqlDataSource>
    <br />
    <table style="margin: 10px">
        <tr>
            <td style="width: 93px; height: 20px;">
            </td>
            <td colspan="2" style="height: 20px">
                <span style="font-size: 10pt; text-decoration: underline"><strong>Top Up SIM Credit</strong></span></td>
            <td style="width: 100px; height: 20px;">
            </td>
        </tr>
        <tr>
            <td style="width: 93px; height: 26px; text-align: right;">
                <span style="font-size: 10pt;">
                SIM MSISDN</span></td>
            <td style="width: 20px; height: 26px; text-align: center;">
                <strong>:</strong></td>
            <td style="width: 63px; height: 26px;">
                <asp:TextBox ID="txtSIMCardId" runat="server"></asp:TextBox></td>
            <td style="width: 100px; height: 26px;">
            </td>
        </tr>
        <tr>
            <td style="width: 93px; height: 21px; text-align: right;">
                <span style="font-size: 10pt;">
                Amount</span></td>
            <td style="width: 20px; height: 21px; text-align: center;">
                <strong>:</strong></td>
            <td style="width: 63px; height: 21px">
                <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox></td>
            <td style="width: 100px; height: 21px">
            </td>
        </tr>
        <tr>
            <td style="width: 93px; text-align: right;">
                <span style="font-size: 10pt;">Balance</span></td>
            <td style="width: 20px; text-align: center;">
                <strong>:</strong></td>
            <td style="width: 63px">
                <asp:Label ID="lblBalance" runat="server"></asp:Label></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 93px">
            </td>
            <td style="width: 20px">
            </td>
            <td colspan="2">
                <asp:Button ID="btnSubmit" runat="server" Text="TopUp" />
                <asp:Button ID="btnConfirm" runat="server" Text="Confirm" Visible="False" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" Visible="False" /></td>
        </tr>
        <tr>
            <td style="width: 93px">
            </td>
            <td colspan="4">
                <asp:Label ID="lblErrorMsg" runat="server" Font-Names="Arial" Font-Size="Small" ForeColor="Red"></asp:Label></td>
        </tr>
    </table>
    <table style="margin: 10px">
        <tr>
            <td style="width: 93px; height: 20px;">
            </td>
            <td colspan="2" style="height: 20px">
                <span style="font-size: 10pt; text-decoration: underline"><strong>Add New SIM Card ID</strong></span></td>
            <td style="width: 100px; height: 20px;">
            </td>
        </tr>
        <tr>
            <td style="width: 93px; height: 26px; text-align: right;">
                <span style="font-size: 10pt;">SIM MSISDN</span></td>
            <td style="width: 20px; height: 26px; text-align: center; font-size: 12pt;">
                <strong>:</strong></td>
            <td style="width: 63px; height: 26px; font-size: 12pt;">
                <asp:TextBox ID="txtSIMMSISDN" runat="server"></asp:TextBox></td>
            <td style="width: 100px; height: 26px; font-size: 12pt;">
            </td>
        </tr>
        <tr style="font-size: 12pt">
            <td style="width: 93px; height: 21px; text-align: right;">
                <span style="font-size: 10pt;">SIM Telco</span></td>
            <td style="width: 20px; height: 21px; text-align: center; font-size: 12pt;">
                <strong>:</strong></td>
            <td style="width: 63px; height: 21px; font-size: 12pt;">
                <asp:DropDownList ID="DDLTelco" runat="server">
                    <asp:ListItem>SINGTEL</asp:ListItem>
                    <asp:ListItem>M1</asp:ListItem>
                    <asp:ListItem>STARHUB</asp:ListItem>                    
                </asp:DropDownList></td>
            <td style="width: 100px; height: 21px; font-size: 12pt;">
            </td>
        </tr>
        <tr style="font-size: 12pt">
            <td style="width: 93px">
            </td>
            <td style="width: 20px">
            </td>
            <td colspan="2">
                <asp:Button ID="btnAddTelco" runat="server" Text="AddTelco" /></td>
        </tr>
        <tr style="font-size: 12pt">
            <td style="width: 93px">
            </td>
            <td colspan="4">
                <asp:Label ID="lblErrorSIM" runat="server" Font-Names="Arial" Font-Size="Small" ForeColor="Red"></asp:Label></td>
        </tr>
    </table>
</asp:Content>

