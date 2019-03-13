<%@ Page Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="UploadTopUp.aspx.vb" Inherits="WebItopz.Admin_UploadTopUp" title="UploadTopUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <table>
        <tr>
            <td colspan="3" style="height: 20px">
                <span style="font-size: 10pt; text-decoration: underline"><strong>Upload TopUp</strong></span></td>
        </tr>
        <tr>
            <td style="width: 145px">
            </td>
            <td style="width: 100px">
                <asp:FileUpload ID="MyFile" runat="server" /></td>
            <td style="width: 100px">
    <asp:Button ID="btnUpload" runat="server" Text="Upload TopUp.txt" /></td>
            <td style="width: 190px">
            </td>
        </tr>
        <tr>
            <td style="width: 145px">
            </td>
            <td colspan="3">
                &nbsp;<asp:label id="lblMsgError" Runat="server" CssClass="ErrorMessage"></asp:label>
    <asp:label id="lblMsg" Runat="server" CssClass="ErrorMessage"></asp:label></td>
        </tr>
        <tr>
            <td style="width: 145px">
            </td>
            <td colspan="3">
                <span style="font-size: 10pt">Right click & save the sample file<strong><span style="font-size: 11pt">
                    <a href="ReloadPIN.txt">ReloadPIN.txt</a></span></strong></span></td>
        </tr>
        <tr>
            <td style="width: 145px">
            </td>
            <td colspan="3">
                <asp:Button ID="btnActive" runat="server" Text="Active" />
                <asp:Button ID="btnDelete" runat="server" Text="Delete" /></td>
        </tr>
    </table> <span class="small_darblue_text" id="span1" runat="server"></span>
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px"
        CellPadding="3" DataSourceID="SqlDataSource1" GridLines="Vertical" Style="margin: 10px">
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" Font-Size="Smaller" />
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="BatchID" HeaderText="BatchID" SortExpression="BatchID" />
            <asp:BoundField DataField="ReloadTelco" HeaderText="ReloadTelco" SortExpression="ReloadTelco" />
            <asp:BoundField DataField="ProcessorID" HeaderText="ProcessorID" SortExpression="ProcessorID" />
            <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount" />
            <asp:BoundField DataField="TotalRecords" HeaderText="TotalRecords" ReadOnly="True"
                SortExpression="TotalRecords" />
            <asp:BoundField DataField="TotalAmount" HeaderText="TotalAmount" ReadOnly="True"
                SortExpression="TotalAmount" />
            <asp:BoundField DataField="BatchStatus" HeaderText="BatchStatus" SortExpression="BatchStatus" />
            <asp:BoundField DataField="CreatedTS" HeaderText="CreatedTS" SortExpression="CreatedTS">
                <ItemStyle Wrap="False" />
            </asp:BoundField>
        </Columns>
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" Font-Size="Smaller" />
        <AlternatingRowStyle BackColor="Gainsboro" />
    </asp:GridView> 
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Small"
        Style="margin: 10px" Text="Reload Pin Balance:"></asp:Label>
    <asp:HyperLink ID="hlManageReloadPin" runat="server" Font-Bold="True" Font-Size="Small"
        NavigateUrl="~/Admin/ReloadPinManage.aspx" Target="_blank">Manage Reload Pin</asp:HyperLink>
    <asp:GridView ID="GridView2"
            runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
            BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px"
            CellPadding="4" DataSourceID="SqlDataSource2" ForeColor="Black" GridLines="Vertical"
            Style="margin: 10px" PageSize="30">
            <FooterStyle BackColor="#CCCC99" />
            <RowStyle BackColor="#F7F7DE" />
            <Columns>
                <asp:BoundField DataField="ReloadTelco" HeaderText="ReloadTelco" SortExpression="ReloadTelco" />
                <asp:BoundField DataField="ProcessorID" HeaderText="ProcessorID" SortExpression="ProcessorID" />
                <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount" />
                <asp:BoundField DataField="Records" HeaderText="Records" SortExpression="Records" />
                <asp:BoundField DataField="Total (SGD)" HeaderText="Total ($$)" SortExpression="Total (SGD)">
                    <HeaderStyle Wrap="False" />
                </asp:BoundField>
            </Columns>
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
        SelectCommand="SELECT ReloadTelco, ProcessorID, Amount, COUNT(*) AS Records, COUNT(*) * Amount AS [Total (SGD)] FROM ReloadPin WHERE (BatchStatus = 'ACTIVE') AND (Status = 'NEW') GROUP BY ReloadTelco, ProcessorID, Amount ORDER BY ReloadTelco DESC">
    </asp:SqlDataSource>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
        SelectCommand="SELECT BatchID, ReloadTelco, ProcessorID, Amount, COUNT(*) AS TotalRecords, COUNT(*) * Amount AS TotalAmount, BatchStatus, CreatedTS FROM ReloadPin &#13;&#10;WHERE BatchStatus<>'DELETE'&#13;&#10;GROUP BY BatchID, ReloadTelco, ProcessorID, Amount, BatchStatus, CreatedTS &#13;&#10;ORDER BY CreatedTS DESC">
    </asp:SqlDataSource>
</asp:Content>

