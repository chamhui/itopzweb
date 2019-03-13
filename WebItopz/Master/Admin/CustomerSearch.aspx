<%@ Page Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="CustomerSearch.aspx.vb" Inherits="WebItopz.Admin_CustomerSearch" title="CustomerSearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp;&nbsp;&nbsp;<br />
    &nbsp; &nbsp; &nbsp;<asp:TextBox ID="txtNRIC" runat="server"></asp:TextBox>
    <span style="font-size: 10pt">(S12345678X)</span><asp:Label ID="lblErrorMsg" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label><br />
    &nbsp; &nbsp; &nbsp; 
    <asp:Button ID="btnSearch" runat="server" Text="Search" />
    &nbsp; &nbsp; &nbsp;&nbsp;
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
        BorderColor="#DEDFDE" BorderWidth="1px" CellPadding="4" DataSourceID="SqlDataSource1"
        ForeColor="Black" GridLines="Vertical" style="margin: 10px" AllowPaging="True" BorderStyle="None">
        <RowStyle Wrap="False" />
        <FooterStyle BackColor="#CCCC99" />
        <Columns>
            <asp:BoundField DataField="NRIC" HeaderText="NRIC" SortExpression="NRIC" />
            <asp:BoundField DataField="NAME" HeaderText="NAME" SortExpression="NAME" />
            <asp:BoundField DataField="LOANSTATUS" HeaderText="LOANSTATUS" SortExpression="LOANSTATUS" />
            <asp:BoundField DataField="LOANAMOUNT" HeaderText="AMOUNT" SortExpression="LOANAMOUNT" />
            <asp:BoundField DataField="LOANTYPE" HeaderText="LOANTYPE" SortExpression="LOANTYPE" />
            <asp:BoundField DataField="COMPANY" HeaderText="COMPANY" SortExpression="COMPANY" />
            <asp:BoundField DataField="CreatedTS" HeaderText="CreatedTS" SortExpression="CreatedTS" >
                <ItemStyle Wrap="False" />
            </asp:BoundField>
<%--            <asp:HyperLinkField DataNavigateUrlFields="LocalMOId,ReloadMSISDN" DataNavigateUrlFormatString="Refund.aspx?Id={0}&amp;Action=Redo&amp;&amp;Reloadmsisdn={1}"
                HeaderText="Redo" Text="Redo" />
            <asp:HyperLinkField DataNavigateUrlFields="LocalMOId,ReloadMSISDN" DataNavigateUrlFormatString="Refund.aspx?Id={0}&amp;Action=Refund&amp;&amp;Reloadmsisdn={1}"
                HeaderText="Refund" Text="Refund" />
            <asp:HyperLinkField DataNavigateUrlFields="LocalMOId,ReloadMSISDN" DataNavigateUrlFormatString="Refund.aspx?id={0}&amp;action=cancel&amp;&amp;Reloadmsisdn={1}"
                HeaderText="Cancel" Text="Cancel" />
            <asp:HyperLinkField DataNavigateUrlFields="LocalMOID,reloadmsisdn" DataNavigateUrlFormatString="Refund.aspx?Id={0}&amp;Action=Success&amp;Reloadmsisdn={1}"
                HeaderText="Success" Text="Success" />
--%>        </Columns>
        <SelectedRowStyle BackColor="#CE5D5A" ForeColor="White" Font-Bold="True" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Left" />
        <HeaderStyle BackColor="#404040" Font-Bold="True" Font-Names="Arial" Font-Size="Small" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
        <RowStyle BackColor="#F7F7DE" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
        SelectCommand="SELECT [NRIC], [NAME], [LOANSTATUS], [LOANAMOUNT], [LOANTYPE], [CreatedTS], [COMPANY] FROM [TxIn] WHERE ([NRIC] = @NRIC)ORDER BY CreatedTS DESC">
        <SelectParameters>
            <asp:ControlParameter ControlID="txtNRIC" Name="NRIC" PropertyName="Text"
                Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>

