<%@ Page Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" Inherits="WebItopz.Admin_AgentMSISDN" title="Agent MSISDN" Codebehind="AgentMSISDN.aspx.vb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <table style="margin: 10px">
        <tr>
            <td style="width: 48px">
            </td>
            <td style="width: 210px">
                <strong><span style="text-decoration: underline">Agent Mobile Number</span></strong></td>
            <td style="width: 100px">
            </td>
        </tr>
    </table>
    <table style="margin: 10px">
        <tr>
            <td style="width: 61px; text-align: right;">
                Agent ID
            </td>
            <td style="width: 7px">
                <strong>:</strong></td>
            <td style="width: 99px">
                <asp:DropDownList ID="txtAgentId" runat="server" DataSourceID="SqlDataSource2" DataTextField="Name"
                    DataValueField="AgentID" AutoPostBack="True">
                </asp:DropDownList></td>
        </tr>
    </table>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" AllowPaging="True" style="margin: 10px">
        <Columns>
            <asp:CommandField ShowEditButton="True" />
            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                SortExpression="ID" />
            <asp:BoundField DataField="AgentID" HeaderText="AgentID" SortExpression="AgentID" />
            <asp:BoundField DataField="MSISDN" HeaderText="MSISDN" SortExpression="MSISDN" />
            <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
            <asp:BoundField DataField="ReplyFlag" HeaderText="ReplyMT" SortExpression="ReplyFlag" />
        </Columns>
        <FooterStyle BackColor="#CCCC99" />
        <RowStyle BackColor="#F7F7DE" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Left" />
        <HeaderStyle BackColor="#404040" Font-Bold="True" ForeColor="White" Font-Names="Arial" Font-Size="Small" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues"
        ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>" DeleteCommand="DELETE FROM [AgentMSISDN] WHERE [ID] = @original_ID AND [AgentID] = @original_AgentID AND [MSISDN] = @original_MSISDN AND [Password] = @original_Password"
        InsertCommand="INSERT INTO [AgentMSISDN] ([AgentID], [MSISDN], [Password]) VALUES (@AgentID, @MSISDN, @Password)"
        OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT [ID], [AgentID], [MSISDN], [Password], [ReplyFlag] FROM [AgentMSISDN] WHERE ([AgentID] = @AgentID)"
        UpdateCommand="UPDATE [AgentMSISDN] SET [MSISDN] = @MSISDN, [Password] = @Password, [ReplyFlag]=@ReplyFlag WHERE [ID] = @original_ID AND [AgentID] = @original_AgentID AND [MSISDN] = @original_MSISDN ">
        <DeleteParameters>
            <asp:Parameter Name="original_ID" Type="Int32" />
            <asp:Parameter Name="original_AgentID" Type="String" />
            <asp:Parameter Name="original_MSISDN" Type="String" />
            <asp:Parameter Name="original_Password" Type="String" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="MSISDN" Type="String" />
            <asp:Parameter Name="Password" Type="String" />
            <asp:Parameter Name="ReplyFlag" />
            <asp:Parameter Name="original_ID" Type="Int32" />
            <asp:Parameter Name="original_AgentID" Type="String" />
            <asp:Parameter Name="original_MSISDN" Type="String" />
        </UpdateParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="txtAgentId" Name="AgentID" PropertyName="Text" Type="String" />
        </SelectParameters>
        <InsertParameters>
            <asp:Parameter Name="AgentID" Type="String" />
            <asp:Parameter Name="MSISDN" Type="String" />
            <asp:Parameter Name="Password" Type="String" />
        </InsertParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
        SelectCommand="SELECT CONVERT (varchar(10), AgentID) + ' ' + Name AS Name, AgentID FROM AgentInfo WHERE (AgentID IN (SELECT AgentID FROM AgentInfo AS AgentInfo_1 WHERE (ParentAgentID = @AgentID)))">
        <SelectParameters>
            <asp:SessionParameter Name="AgentID" SessionField="DEALER_ID" />
        </SelectParameters>
    </asp:SqlDataSource>
    <table style="margin: 10px">
        <tr>
            <td style="width: 61px; text-align: right;">
                Agent ID</td>
            <td style="width: 7px">
                <strong>:</strong></td>
            <td style="width: 100px">
                <asp:TextBox ID="txtAgentId1" runat="server"></asp:TextBox></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 61px; text-align: right;">
                MSISDN</td>
            <td style="width: 7px">
                <strong>:</strong></td>
            <td style="width: 100px">
                <asp:TextBox ID="txtMSISDN" runat="server"></asp:TextBox></td>
            <td style="width: 100px">
                <span style="font-size: 10pt">(8XXXXXXX)</span></td>
        </tr>
        <tr>
            <td style="width: 61px">
            </td>
            <td style="width: 7px">
            </td>
            <td style="width: 100px">
                <asp:Button ID="btnAdd" runat="server" Text="Add New MSISDN" /></td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 61px; height: 10px;">
            </td>
            <td colspan="4" style="height: 10px">
                <asp:Label ID="lblErrorMsg" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label></td>
        </tr>
    </table>
</asp:Content>

