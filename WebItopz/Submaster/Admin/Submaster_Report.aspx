<%@ Page Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="Submaster_Report.aspx.vb" Inherits="WebItopz.Submaster_Report" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
        AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1"
        ForeColor="#333333" GridLines="None">
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="TxID" HeaderText="TxID" InsertVisible="False" ReadOnly="True"
                SortExpression="TxID" />
            <asp:BoundField DataField="AgentID" HeaderText="AgentID" SortExpression="AgentID" />
            <asp:BoundField DataField="ReloadMSISDN" HeaderText="ReloadMSISDN" SortExpression="ReloadMSISDN" />
            <asp:BoundField DataField="ReloadTelco" HeaderText="ReloadTelco" SortExpression="ReloadTelco" />
            <asp:BoundField DataField="CreatedTS" HeaderText="CreatedTS" SortExpression="CreatedTS" />
            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
            <asp:BoundField DataField="BalanceAfterReload" HeaderText="BalanceAfterReload" SortExpression="BalanceAfterReload" />
            <asp:BoundField DataField="ReloadAmount" HeaderText="ReloadAmount" SortExpression="ReloadAmount" />
        </Columns>
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues"
        ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>" DeleteCommand="DELETE FROM [TxReload] WHERE [TxID] = @original_TxID AND [LocalMOID] = @original_LocalMOID AND [AgentID] = @original_AgentID AND [ReloadMSISDN] = @original_ReloadMSISDN AND [ReloadTelco] = @original_ReloadTelco AND [CreatedTS] = @original_CreatedTS AND [Status] = @original_Status AND [BalanceAfterReload] = @original_BalanceAfterReload AND [ReloadAmount] = @original_ReloadAmount"
        InsertCommand="INSERT INTO [TxReload] ([LocalMOID], [AgentID], [ReloadMSISDN], [ReloadTelco], [CreatedTS], [Status], [BalanceAfterReload], [ReloadAmount]) VALUES (@LocalMOID, @AgentID, @ReloadMSISDN, @ReloadTelco, @CreatedTS, @Status, @BalanceAfterReload, @ReloadAmount)"
        OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT [LocalMOID], [AgentID], [ReloadMSISDN], [ReloadTelco], [CreatedTS], [Status], [BalanceAfterReload], [ReloadAmount], [TxID] FROM [TxReload] order by txid desc"
        UpdateCommand="UPDATE [TxReload] SET [LocalMOID] = @LocalMOID, [AgentID] = @AgentID, [ReloadMSISDN] = @ReloadMSISDN, [ReloadTelco] = @ReloadTelco, [CreatedTS] = @CreatedTS, [Status] = @Status, [BalanceAfterReload] = @BalanceAfterReload, [ReloadAmount] = @ReloadAmount WHERE [TxID] = @original_TxID AND [LocalMOID] = @original_LocalMOID AND [AgentID] = @original_AgentID AND [ReloadMSISDN] = @original_ReloadMSISDN AND [ReloadTelco] = @original_ReloadTelco AND [CreatedTS] = @original_CreatedTS AND [Status] = @original_Status AND [BalanceAfterReload] = @original_BalanceAfterReload AND [ReloadAmount] = @original_ReloadAmount">
        <DeleteParameters>
            <asp:Parameter Name="original_TxID" Type="Int64" />
            <asp:Parameter Name="original_LocalMOID" Type="String" />
            <asp:Parameter Name="original_AgentID" Type="String" />
            <asp:Parameter Name="original_ReloadMSISDN" Type="String" />
            <asp:Parameter Name="original_ReloadTelco" Type="String" />
            <asp:Parameter Name="original_CreatedTS" Type="DateTime" />
            <asp:Parameter Name="original_Status" Type="String" />
            <asp:Parameter Name="original_BalanceAfterReload" Type="Int32" />
            <asp:Parameter Name="original_ReloadAmount" Type="String" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="LocalMOID" Type="String" />
            <asp:Parameter Name="AgentID" Type="String" />
            <asp:Parameter Name="ReloadMSISDN" Type="String" />
            <asp:Parameter Name="ReloadTelco" Type="String" />
            <asp:Parameter Name="CreatedTS" Type="DateTime" />
            <asp:Parameter Name="Status" Type="String" />
            <asp:Parameter Name="BalanceAfterReload" Type="Int32" />
            <asp:Parameter Name="ReloadAmount" Type="String" />
            <asp:Parameter Name="original_TxID" Type="Int64" />
            <asp:Parameter Name="original_LocalMOID" Type="String" />
            <asp:Parameter Name="original_AgentID" Type="String" />
            <asp:Parameter Name="original_ReloadMSISDN" Type="String" />
            <asp:Parameter Name="original_ReloadTelco" Type="String" />
            <asp:Parameter Name="original_CreatedTS" Type="DateTime" />
            <asp:Parameter Name="original_Status" Type="String" />
            <asp:Parameter Name="original_BalanceAfterReload" Type="Int32" />
            <asp:Parameter Name="original_ReloadAmount" Type="String" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="LocalMOID" Type="String" />
            <asp:Parameter Name="AgentID" Type="String" />
            <asp:Parameter Name="ReloadMSISDN" Type="String" />
            <asp:Parameter Name="ReloadTelco" Type="String" />
            <asp:Parameter Name="CreatedTS" Type="DateTime" />
            <asp:Parameter Name="Status" Type="String" />
            <asp:Parameter Name="BalanceAfterReload" Type="Int32" />
            <asp:Parameter Name="ReloadAmount" Type="String" />
        </InsertParameters>
    </asp:SqlDataSource>
</asp:Content>

