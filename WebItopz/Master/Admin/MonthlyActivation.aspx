<%@ Page Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="MonthlyActivation.aspx.vb" Inherits="WebItopz.Admin_MonthlyActivation" title="MonthlyActivation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="margin: 10px">
        <tr>
            <td style="width: 100px; text-align: right">
            </td>
            <td colspan="2">
                <span style="text-decoration: underline"><strong>Monthly Activation Comparesom</strong></span></td>
        </tr>
        <tr>
            <td style="width: 100px; text-align: right;">
                Month</td>
            <td style="width: 11px; text-align: center;">
                <strong>:</strong></td>
            <td style="width: 220px">
                <asp:DropDownList ID="DDLMonth" runat="server">
                    <asp:ListItem>01</asp:ListItem>
                    <asp:ListItem>02</asp:ListItem>
                    <asp:ListItem>03</asp:ListItem>
                    <asp:ListItem>04</asp:ListItem>
                    <asp:ListItem>05</asp:ListItem>
                    <asp:ListItem>06</asp:ListItem>
                    <asp:ListItem>07</asp:ListItem>
                    <asp:ListItem>08</asp:ListItem>
                    <asp:ListItem>09</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 100px; text-align: right;">
                Year</td>
            <td style="width: 11px; text-align: center;">
                <strong>:</strong></td>
            <td style="width: 220px">
                <asp:DropDownList ID="DDLYear" runat="server">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 11px">
            </td>
            <td style="width: 220px">
                <asp:Button ID="btnGenerate" runat="server" Text="Generate" /></td>
        </tr>
    </table>
    <table style="margin: 10px">
        <tr>
            <td style="width: 300px">
                <strong><span style="text-decoration: underline">
                Total Current Month Activation</span></strong></td>
            <td style="width: 300px">
                <strong><span style="text-decoration: underline">
                Total Previous Month Activation</span></strong></td>
                            <td style="width: 300px">
                <strong><span style="text-decoration: underline">
                Total Previous Month Activation</span></strong></td>
        </tr>
        <tr>
            <td style="width: 208px" valign="top">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" BackColor="White" BorderColor="#DEDFDE" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" BorderStyle="None">
        <Columns>
                        <asp:BoundField DataField="Month" HeaderText="Month" ReadOnly="True" SortExpression="Date" />
                        <asp:BoundField DataField="Telco" HeaderText="Telco" SortExpression="Telco" />
                        <asp:BoundField DataField="Total" HeaderText="Total" ReadOnly="True" SortExpression="Total" />
        </Columns>
        <FooterStyle BackColor="#CCCC99" />
        <SelectedRowStyle BackColor="#CE5D5A" ForeColor="White" Font-Bold="True" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <HeaderStyle BackColor="#404040" Font-Bold="True" Font-Names="Arial" Font-Size="Small" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
        <RowStyle BackColor="#F7F7DE" />
        <EmptyDataTemplate>
            No records found
        </EmptyDataTemplate>
    </asp:GridView>
            </td>
            <td style="width: 221px" valign="top">
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#DEDFDE" BorderWidth="1px" CellPadding="4" DataSourceID="SqlDataSource2"
                    ForeColor="Black" GridLines="Vertical" BorderStyle="None" Width="248px">
                    <FooterStyle BackColor="#CCCC99" />
                    <Columns>
                        <asp:BoundField DataField="Month" HeaderText="Month" ReadOnly="True" SortExpression="Date" />
                        <asp:BoundField DataField="Telco" HeaderText="Telco" SortExpression="Telco" />
                        <asp:BoundField DataField="Total" HeaderText="Total" ReadOnly="True" SortExpression="Total" />
                    </Columns>
                    <SelectedRowStyle BackColor="#CE5D5A" ForeColor="White" Font-Bold="True" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <HeaderStyle BackColor="#404040" Font-Bold="True" Font-Names="Arial" Font-Size="Small" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                    <RowStyle BackColor="#F7F7DE" />
                    <EmptyDataTemplate>
                        No records found
                    </EmptyDataTemplate>
                </asp:GridView>
            </td>
            <td style="width: 221px" valign="top">
                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" BackColor="White"
                    BorderColor="#DEDFDE" BorderWidth="1px" CellPadding="4" DataSourceID="SqlDataSource3"
                    ForeColor="Black" GridLines="Vertical" BorderStyle="None" Width="248px">
                    <FooterStyle BackColor="#CCCC99" />
                    <Columns>
                        <asp:BoundField DataField="Month" HeaderText="Month" ReadOnly="True" SortExpression="Date" />
                        <asp:BoundField DataField="Telco" HeaderText="Telco" SortExpression="Telco" />
                        <asp:BoundField DataField="Total" HeaderText="Total" ReadOnly="True" SortExpression="Total" />
                    </Columns>
                    <SelectedRowStyle BackColor="#CE5D5A" ForeColor="White" Font-Bold="True" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <HeaderStyle BackColor="#404040" Font-Bold="True" Font-Names="Arial" Font-Size="Small" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                    <RowStyle BackColor="#F7F7DE" />
                    <EmptyDataTemplate>
                        No records found
                    </EmptyDataTemplate>
                </asp:GridView>
            </td>  
        </tr>
    </table>

    &nbsp;<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
        SelectCommand="SELECT month(UpdatedTS) AS Month, Telco, COUNT(*) AS Total FROM [TxActivation] where month(createdts)=@month and year(CreatedTS) = @year Group By Telco, month(UpdatedTS) order by Telco ">
        <SelectParameters>
            <asp:ControlParameter ControlID="DDLMonth" Name="month" PropertyName="SelectedValue" />
            <asp:ControlParameter ControlID="DDLYear" Name="year" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
                    SelectCommand="SELECT month(UpdatedTS) AS Month, Telco, COUNT(*) AS Total FROM [TxActivation] where month(createdts)=(@month-1) and year(CreatedTS) = @year Group By Telco, month(UpdatedTS) order by Telco ">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DDLMonth" Name="month" PropertyName="SelectedValue" />
                        <asp:ControlParameter ControlID="DDLYear" Name="year" PropertyName="SelectedValue" />
                    </SelectParameters>
                </asp:SqlDataSource>
                
                                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
                    SelectCommand="SELECT month(UpdatedTS) AS Month, Telco, COUNT(*) AS Total FROM [TxActivation] where month(createdts)=(@month-2) and year(CreatedTS) = @year Group By Telco, month(UpdatedTS) order by Telco ">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DDLMonth" Name="month" PropertyName="SelectedValue" />
                        <asp:ControlParameter ControlID="DDLYear" Name="year" PropertyName="SelectedValue" />
                    </SelectParameters>
                </asp:SqlDataSource>
</asp:Content>

