<%@ Page Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" Inherits="WebItopz.Reload" title="Agent - Reload" Codebehind="Reload.aspx.vb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
<TABLE style="MARGIN: 10px"><TBODY><TR><TD style="WIDTH: 108px"></TD><TD colSpan=2><STRONG><SPAN style="TEXT-DECORATION: underline"></SPAN></STRONG></TD><TD style="WIDTH: 73px"></TD><TD style="WIDTH: 171px"></TD></TR><TR><TD style="WIDTH: 108px; TEXT-ALIGN: right"><SPAN style="FONT-FAMILY: Arial"><SPAN style="TEXT-DECORATION: underline"><STRONG>Reload #</STRONG></SPAN></SPAN></TD><TD style="WIDTH: 162px; TEXT-ALIGN: center"><STRONG><SPAN style="TEXT-DECORATION: underline">Type</SPAN></STRONG></TD><TD style="WIDTH: 42px; TEXT-ALIGN: center">&nbsp;<SPAN style="TEXT-DECORATION: underline"><STRONG>Amount</STRONG></SPAN></TD><TD style="WIDTH: 73px; TEXT-ALIGN: center"><SPAN style="TEXT-DECORATION: underline"><STRONG>Mobile</STRONG></SPAN></TD><TD style="WIDTH: 171px"></TD></TR>
<TR><TD style="WIDTH: 108px; TEXT-ALIGN: right"><SPAN style="FONT-FAMILY: Arial">1.</SPAN></TD><TD style="WIDTH: 162px; TEXT-ALIGN: center"><STRONG><asp:DropDownList id="DDLTelco" runat="server" DataSourceID="SqlDataSource1" DataValueField="Telco" DataTextField="Telco" AutoPostBack="True" OnSelectedIndexChanged="DDLTelco_SelectedIndexChanged"><asp:ListItem Value="MAXIS">MAXIS</asp:ListItem>
</asp:DropDownList> </STRONG></TD><TD style="WIDTH: 42px"><asp:DropDownList id="DDLReloadAmount" runat="server"></asp:DropDownList></TD><TD style="WIDTH: 73px"><asp:TextBox id="txtReloadMSISDN" runat="server" Width="109px"></asp:TextBox></TD><TD style="WIDTH: 171px"><SPAN style="FONT-SIZE: 8pt">9xxxxxxx<BR />8xxxxxxx</SPAN></TD></TR>
<TR><TD style="WIDTH: 108px; TEXT-ALIGN: right"><SPAN style="FONT-FAMILY: Arial">2.</SPAN></TD><TD style="WIDTH: 162px; TEXT-ALIGN: center"><STRONG><asp:DropDownList id="DDLTelco2" runat="server" DataSourceID="SqlDataSource2" DataValueField="Telco" DataTextField="Telco" AutoPostBack="True" OnSelectedIndexChanged="DDLTelco2_SelectedIndexChanged"><asp:ListItem Value="MAXIS">MAXIS</asp:ListItem>
</asp:DropDownList> </STRONG></TD><TD style="WIDTH: 42px"><asp:DropDownList id="DDLReloadAmount2" runat="server"></asp:DropDownList></TD><TD style="WIDTH: 73px"><asp:TextBox id="txtReloadMSISDN2" runat="server" Width="109px"></asp:TextBox></TD><TD style="WIDTH: 171px"><SPAN style="FONT-SIZE: 8pt">9xxxxxxx<BR />8xxxxxxx</SPAN></TD></TR>

<TR><TD style="WIDTH: 108px; TEXT-ALIGN: right"></TD><TD style="WIDTH: 162px"></TD><TD style="WIDTH: 42px"></TD><TD style="WIDTH: 73px"></TD><TD style="WIDTH: 171px"></TD></TR><TR><TD style="WIDTH: 108px; HEIGHT: 21px"></TD><TD style="HEIGHT: 21px" colSpan=3><asp:Button id="btnSubmit" runat="server" Text="Submit"></asp:Button> <asp:Button id="btnConfirm" runat="server" Text="Confirm" Visible="False"></asp:Button> <asp:Button id="btnEdit" runat="server" Text="Edit" Visible="False"></asp:Button>&nbsp; <asp:UpdateProgress id="UpdateProgress1" runat="server" __designer:dtid="281474976710662" AssociatedUpdatePanelID="UpdatePanel1" __designer:wfdid="w15"><ProgressTemplate __designer:dtid="281474976710663">
<IMG src="images/loading.gif" /> 
</ProgressTemplate>
</asp:UpdateProgress></TD><TD style="WIDTH: 171px; HEIGHT: 21px"></TD></TR><TR><TD style="WIDTH: 108px"></TD><TD colSpan=3><asp:Label id="lblErrorMsg" runat="server" ForeColor="Red" Font-Size="Small"></asp:Label></TD><TD colSpan=1></TD></TR></TBODY></TABLE><asp:Label style="MARGIN: 25px" id="lblReloadMSISDN" runat="server" Font-Size="XX-Large"></asp:Label><BR /><asp:Label style="MARGIN: 25px" id="lblReloadAmount" runat="server" Font-Size="XX-Large"></asp:Label><BR /><asp:Label style="MARGIN: 25px" id="lblReloadTelco" runat="server" Font-Size="XX-Large"></asp:Label> 
</contenttemplate>
    </asp:UpdatePanel>
    &nbsp;&nbsp;<br />
     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
        SelectCommand="SELECT [Telco] FROM [ProductInfo] WHERE ([Status] = @Status)">
        <SelectParameters>
            <asp:Parameter DefaultValue="ACTIVE" Name="Status" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
         <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
        SelectCommand="SELECT [Telco] FROM [ProductInfo] WHERE ([Status] = @Status)">
        <SelectParameters>
            <asp:Parameter DefaultValue="ACTIVE" Name="Status" Type="String" />
            </SelectParameters>
    </asp:SqlDataSource>
    <br />
    <br />
</asp:Content>

