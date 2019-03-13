<%@ Page Language="VB" AutoEventWireup="false" Inherits="WebItopz.DealerPrintReportAgentSales" Codebehind="PrintReportAgentSales.aspx.vb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>PrintReportAgentSales</title>
	<link href="~/Theme/css/bootstrap.min.css" rel="stylesheet" />

	<link href="~/Theme/fonts/css/font-awesome.min.css" rel="stylesheet" />
	<link href="~/Theme/css/animate.min.css" rel="stylesheet" />
	<link href="~/build/css/custom.min.css" rel="stylesheet" />
	<!--[if lt IE 9]>
		<script src="../assets/js/ie8-responsive-file-warning.js"></script>
	<![endif]-->

	<!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
	<!--[if lt IE 9]>
		<script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
		<script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
	<![endif]-->

	<!-- jQuery -->
    <script src="/Theme/jquery/dist/jquery.min.js"></script>
    <!-- <script src="../Scripts/jquery-1.10.2.js" type="text/javascript"></script> -->
	<!-- Bootstrap -->
	<script src="/Theme/bootstrap/dist/js/bootstrap.min.js"></script>
	<!-- FastClick -->
	<script src="/Theme/fastclick/lib/fastclick.js"></script>
	<!-- NProgress -->
	<script src="/Theme/nprogress/nprogress.js"></script>
	<!-- Dropzone.js -->
	<script src="/Theme/dropzone/dist/min/dropzone.min.js"></script>

	<style>
		.panel_toolbox{
			display:none;
		}
		.input-group{
			display:none;
		}
	</style>
        <!-- NProgress -->
    <link href="/Theme/nprogress/nprogress.css" rel="stylesheet" />

    <!-- Datatables -->
    <link href="/Theme/datatables.net-bs/css/dataTables.bootstrap.min.css" rel="stylesheet" />
    <link href="/Theme/datatables.net-buttons-bs/css/buttons.bootstrap.min.css" rel="stylesheet" />
    <link href="/Theme/datatables.net-fixedheader-bs/css/fixedHeader.bootstrap.min.css" rel="stylesheet" />
    <link href="/Theme/datatables.net-responsive-bs/css/responsive.bootstrap.min.css" rel="stylesheet" />
    <link href="/Theme/datatables.net-scroller-bs/css/scroller.bootstrap.min.css" rel="stylesheet" />
</head>
<body style="background: none;">
    <form id="form1" runat="server">
    <div style="margin:10px;">
        <div class="item form-group form-horizontal col-md-12 col-sm-12 col-xs-12">
            <div class="col-md-2 col-sm-2 col-xs-12">
                <asp:TextBox ID="txtDateFrom" runat="server" class="form-control col-md-7 col-xs-12"></asp:TextBox>
            </div>
            <div class="col-md-2 col-sm-2 col-xs-12">
                <asp:TextBox ID="txtDateTo" runat="server" class="form-control col-md-7 col-xs-12"></asp:TextBox>
            </div>
            <div class="col-md-6 col-sm-6 col-xs-12">
                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource2"
                DataTextField="Name" DataValueField="AgentID" class="form-control col-md-7 col-xs-12">
                </asp:DropDownList>
            </div>
            <div class="col-md-2 col-sm-2 col-xs-12">
                <asp:Button ID="btnGenerate" runat="server" Text="Generate" class="btn btn-success"/>&nbsp;<br />
            </div>
        </div>
        <div class="item form-group form-horizontal col-md-12 col-sm-12 col-xs-12">
            <div class="col-md-2 col-sm-2 col-xs-12">
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" style="width: 100%;" DataSourceID="SqlDataSource3" CssClass="dataTable table-bordered table-counter">
                    <Columns>
                        <asp:BoundField DataField="ToTal" HeaderText="Success$" SortExpression="ToTal" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-md-2 col-sm-2 col-xs-12">
                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" style="width: 100%;" DataSourceID="SqlDataSource4" CssClass="dataTable table-bordered table-counter">
                    <Columns>
                        <asp:BoundField DataField="ToTal" HeaderText="Refunded$" ReadOnly="True" SortExpression="ToTal" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-md-2 col-sm-2 col-xs-12">
                <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" style="width: 100%;" DataSourceID="SqlDataSource5" CssClass="dataTable table-bordered table-counter">
                    <Columns>
                        <asp:BoundField DataField="ToTal" HeaderText="Cancelled$" ReadOnly="True" SortExpression="ToTal" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-md-2 col-sm-2 col-xs-12">
                <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" style="width: 100%;" DataSourceID="SqlDataSource6" CssClass="dataTable table-bordered table-counter">
                    <Columns>
                        <asp:BoundField DataField="ToTal" HeaderText="Pending$" ReadOnly="True" SortExpression="ToTal" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div class="item form-group form-horizontal col-md-12 col-sm-12 col-xs-12">
            <div class="col-md-12 col-sm-12 col-xs-12">
                <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" 
                    AllowSorting="True" CssClass="dataTable table-bordered table-counter" style="width: 100%;">
                    <Columns>
                        <asp:TemplateField HeaderText="No."><ItemTemplate ><%#Container.DataItemIndex+1%></ItemTemplate></asp:TemplateField>
                        <asp:BoundField DataField="ReloadTelco" HeaderText="ReloadTelco" SortExpression="ReloadTelco" />
                        <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                        <asp:BoundField DataField="ReloadAmount" HeaderText="ReloadAmount" SortExpression="ReloadAmount" />
                        <asp:BoundField DataField="ReloadMSISDN" HeaderText="ReloadMSISDN" SortExpression="ReloadMSISDN" />
                        <asp:BoundField DataField="CreatedTS" HeaderText="CreatedTS" SortExpression="CreatedTS" />
                    </Columns>
                    <HeaderStyle Font-Size="Small" ForeColor="#000040" />
                    <EditRowStyle Font-Size="Medium" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>" SelectCommand="SELECT MSISDN, AgentID, ReloadTelco, DNReceivedID, Status, ReloadAmount, ReloadMSISDN, CreatedTS FROM TxIn WHERE (AgentID = @AgentID) AND (REPLACE(CONVERT (char(10), CreatedTS, 111), '/', '') >= @CreatedTS) AND (REPLACE(CONVERT (char(10), CreatedTS, 111), '/', '') <= @CreatedTS2)">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="DropDownList1" Name="AgentID" PropertyName="SelectedValue"
                            Type="String" />
                        <asp:ControlParameter ControlID="txtDateFrom" Name="CreatedTS" PropertyName="Text" />
                        <asp:ControlParameter ControlID="txtDateTo" Name="CreatedTS2" PropertyName="Text" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
        </div>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
            SelectCommand="SELECT AgentID, CONVERT (varchar(10), AgentID) + ' ' + Name AS Name FROM AgentInfo WHERE (AgentID IN (SELECT AgentID FROM AgentInfo AS AgentInfo_1 WHERE (ParentAgentID = @agentid))) or AgentID= @agentid">
                    <SelectParameters>
	                <asp:SessionParameter Name="agentid" SessionField="DEALER_ID" />
        </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
            SelectCommand="SELECT Sum(ReloadAmount) as ToTal  FROM [TxIn] WHERE (AgentID = @AgentID) AND (REPLACE(CONVERT (char(10), CreatedTS, 111), '/', '') >= @CreatedTS) AND (REPLACE(CONVERT (char(10), CreatedTS, 111), '/', '') <= @CreatedTS2) and Status='SUCCESS'">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="AgentID" PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="txtDateFrom" Name="CreatedTS" PropertyName="Text" />
                <asp:ControlParameter ControlID="txtDateTo" Name="CreatedTS2" PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
            SelectCommand="SELECT Sum(ReloadAmount) as ToTal  FROM [TxIn] WHERE (AgentID = @AgentID) AND (REPLACE(CONVERT (char(10), CreatedTS, 111), '/', '') >= @CreatedTS) AND (REPLACE(CONVERT (char(10), CreatedTS, 111), '/', '') <= @CreatedTS2) and Status='REFUNDED'">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="AgentID" PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="txtDateFrom" Name="CreatedTS" PropertyName="Text" />
                <asp:ControlParameter ControlID="txtDateTo" Name="CreatedTS2" PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
        <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
            SelectCommand="SELECT Sum(ReloadAmount) as ToTal  FROM [TxIn] WHERE (AgentID = @AgentID) AND (REPLACE(CONVERT (char(10), CreatedTS, 111), '/', '') >= @CreatedTS) AND (REPLACE(CONVERT (char(10), CreatedTS, 111), '/', '') <= @CreatedTS2) and Status='CANCELLED'">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="AgentID" PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="txtDateFrom" Name="CreatedTS" PropertyName="Text" />
                <asp:ControlParameter ControlID="txtDateTo" Name="CreatedTS2" PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
            SelectCommand="SELECT Sum(ReloadAmount) as ToTal  FROM [TxIn] WHERE (AgentID = @AgentID) AND (REPLACE(CONVERT (char(10), CreatedTS, 111), '/', '') >= @CreatedTS) AND (REPLACE(CONVERT (char(10), CreatedTS, 111), '/', '') <= @CreatedTS2) and Status='PENDING'">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="AgentID" PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="txtDateFrom" Name="CreatedTS" PropertyName="Text" />
                <asp:ControlParameter ControlID="txtDateTo" Name="CreatedTS2" PropertyName="Text" />
            </SelectParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
