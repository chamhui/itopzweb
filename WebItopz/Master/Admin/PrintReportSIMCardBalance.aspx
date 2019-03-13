<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="PrintReportSIMCardBalance.aspx.vb" Inherits="WebItopz.PrintReportProfit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>PrintReportProfit</title>
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
    <div style="margin: 10px;">
        <div class="item form-group form-horizontal col-md-12 col-sm-12 col-xs-12">
            <asp:Label ID="lblDate" runat="server"></asp:Label><br />
        </div>
        <div class="item form-group form-horizontal col-md-12 col-sm-12 col-xs-12">
            <div class="col-md-5 col-sm-5 col-xs-12">
                <asp:GridView ID="GridView2" runat="server" DataSourceID="SqlDataSource2" AutoGenerateColumns="False" 
                    AllowSorting="True" DataKeyNames="ProcessorID,SIMCardID" BackColor="White" BorderColor="#DEDFDE" 
                    BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" CssClass="dataTable table-bordered table-counter" style="width: 100%;">
                    <Columns>
                        <asp:BoundField DataField="ProcessorID" HeaderText="ProcessorID" ReadOnly="True"
                            SortExpression="ProcessorID" />
                        <asp:BoundField DataField="SIMCardID" HeaderText="SIMCardID" ReadOnly="True" SortExpression="SIMCardID" />
                        <asp:BoundField DataField="Balance" HeaderText="Balance" ReadOnly="True" SortExpression="Balance" />
                    </Columns>
                    <HeaderStyle Font-Size="Small" ForeColor="White" BackColor="#6B696B" Font-Bold="True" />
                    <EditRowStyle Font-Size="Medium" />
                    <RowStyle BackColor="#F7F7DE" />
                    <FooterStyle BackColor="#CCCC99" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </div>
            <div class="col-md-1 col-sm-1 col-xs-12">
                <asp:GridView ID="GridView3" runat="server" DataSourceID="SqlDataSource3" AutoGenerateColumns="False" 
                    AllowSorting="True" DataKeyNames="ProcessorID,SIMCardID" BackColor="White" BorderColor="#DEDFDE" 
                    BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" CssClass="dataTable table-bordered table-counter" style="width: 100%;">
                    <Columns>
                        <asp:BoundField DataField="Balance" HeaderText="Balance" ReadOnly="True" SortExpression="Balance" />
                    </Columns>
                    <HeaderStyle Font-Size="Small" ForeColor="White" BackColor="#6B696B" Font-Bold="True" />
                    <EditRowStyle Font-Size="Medium" />
                    <RowStyle BackColor="#F7F7DE" />
                    <FooterStyle BackColor="#CCCC99" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </div>
            <div class="col-md-1 col-sm-1 col-xs-12">
                <asp:GridView ID="GridView4" runat="server" DataSourceID="SqlDataSource4" AutoGenerateColumns="False" 
                    AllowSorting="True" DataKeyNames="ProcessorID,SIMCardID" BackColor="White" BorderColor="#DEDFDE" 
                    BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" CssClass="dataTable table-bordered table-counter" style="width: 100%;">
                    <Columns>
                        <asp:BoundField DataField="Balance" HeaderText="Balance" ReadOnly="True" SortExpression="Balance" />
                    </Columns>
                    <HeaderStyle Font-Size="Small" ForeColor="White" BackColor="#6B696B" Font-Bold="True" />
                    <EditRowStyle Font-Size="Medium" />
                    <RowStyle BackColor="#F7F7DE" />
                    <FooterStyle BackColor="#CCCC99" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </div>
            <div class="col-md-1 col-sm-1 col-xs-12">
                <asp:GridView ID="GridView5" runat="server" DataSourceID="SqlDataSource5" AutoGenerateColumns="False" 
                    AllowSorting="True" DataKeyNames="ProcessorID,SIMCardID" BackColor="White" BorderColor="#DEDFDE" 
                    BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" CssClass="dataTable table-bordered table-counter" style="width: 100%;">
                    <Columns>
                        <asp:BoundField DataField="Balance" HeaderText="Balance" ReadOnly="True" SortExpression="Balance" />
                    </Columns>
                    <HeaderStyle Font-Size="Small" ForeColor="White" BackColor="#6B696B" Font-Bold="True" />
                    <EditRowStyle Font-Size="Medium" />
                    <RowStyle BackColor="#F7F7DE" />
                    <FooterStyle BackColor="#CCCC99" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </div>
            <div class="col-md-1 col-sm-1 col-xs-12">
                <asp:GridView ID="GridView6" runat="server" DataSourceID="SqlDataSource6" AutoGenerateColumns="False" 
                    AllowSorting="True" DataKeyNames="ProcessorID,SIMCardID" BackColor="White" BorderColor="#DEDFDE" 
                    BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" CssClass="dataTable table-bordered table-counter" style="width: 100%;">
                    <Columns>
                        <asp:BoundField DataField="Balance" HeaderText="Balance" ReadOnly="True" SortExpression="Balance" />
                    </Columns>
                    <HeaderStyle Font-Size="Small" ForeColor="White" BackColor="#6B696B" Font-Bold="True" />
                    <EditRowStyle Font-Size="Medium" />
                    <RowStyle BackColor="#F7F7DE" />
                    <FooterStyle BackColor="#CCCC99" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </div>
            <div class="col-md-1 col-sm-1 col-xs-12">
                <asp:GridView ID="GridView7" runat="server" DataSourceID="SqlDataSource7" AutoGenerateColumns="False" 
                    AllowSorting="True" DataKeyNames="ProcessorID,SIMCardID" BackColor="White" BorderColor="#DEDFDE" 
                    BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" CssClass="dataTable table-bordered table-counter" style="width: 100%;">
                    <Columns>
                        <asp:BoundField DataField="Balance" HeaderText="Balance" ReadOnly="True" SortExpression="Balance" />
                    </Columns>
                    <HeaderStyle Font-Size="Small" ForeColor="White" BackColor="#6B696B" Font-Bold="True" />
                    <EditRowStyle Font-Size="Medium" />
                    <RowStyle BackColor="#F7F7DE" />
                    <FooterStyle BackColor="#CCCC99" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </div>
            <div class="col-md-1 col-sm-1 col-xs-12">
                <asp:GridView ID="GridView8" runat="server" DataSourceID="SqlDataSource8" AutoGenerateColumns="False" 
                    AllowSorting="True" DataKeyNames="ProcessorID,SIMCardID" BackColor="White" BorderColor="#DEDFDE" 
                    BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" CssClass="dataTable table-bordered table-counter" style="width: 100%;">
                    <Columns>
                        <asp:BoundField DataField="Balance" HeaderText="Balance" ReadOnly="True" SortExpression="Balance" />
                    </Columns>
                    <HeaderStyle Font-Size="Small" ForeColor="White" BackColor="#6B696B" Font-Bold="True" />
                    <EditRowStyle Font-Size="Medium" />
                    <RowStyle BackColor="#F7F7DE" />
                    <FooterStyle BackColor="#CCCC99" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </div>
            <div class="col-md-1 col-sm-1 col-xs-12">
                <asp:GridView ID="GridView9" runat="server" DataSourceID="SqlDataSource9" AutoGenerateColumns="False" 
                    AllowSorting="True" DataKeyNames="ProcessorID,SIMCardID" BackColor="White" BorderColor="#DEDFDE" 
                    BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" CssClass="dataTable table-bordered table-counter" style="width: 100%;">
                    <Columns>
                        <asp:BoundField DataField="Balance" HeaderText="Balance" ReadOnly="True" SortExpression="Balance" />
                    </Columns>
                    <HeaderStyle Font-Size="Small" ForeColor="White" BackColor="#6B696B" Font-Bold="True" />
                    <EditRowStyle Font-Size="Medium" />
                    <RowStyle BackColor="#F7F7DE" />
                    <FooterStyle BackColor="#CCCC99" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </div>
        </div>

        <div class="item form-group form-horizontal col-md-12 col-sm-12 col-xs-12">
            <div class="col-md-12 col-sm-12 col-xs-12">
                <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" 
                    AllowSorting="True" DataKeyNames="ProcessorID,SIMCardID" BackColor="White" BorderColor="#DEDFDE" 
                    BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" CssClass="dataTable table-bordered table-counter" style="width: 100%;">
                    <Columns>
                        <asp:BoundField DataField="ProcessorID" HeaderText="ProcessorID" ReadOnly="True"
                            SortExpression="ProcessorID" />
                        <asp:BoundField DataField="SIMCardID" HeaderText="SIMCardID" ReadOnly="True" SortExpression="SIMCardID" />
                        <asp:BoundField DataField="Balance" HeaderText="Balance" ReadOnly="True" SortExpression="Balance" />
                    </Columns>
                    <HeaderStyle Font-Size="Small" ForeColor="White" BackColor="#6B696B" Font-Bold="True" />
                    <EditRowStyle Font-Size="Medium" />
                    <RowStyle BackColor="#F7F7DE" />
                    <FooterStyle BackColor="#CCCC99" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
        
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>" SelectCommand="SELECT ProcessorID, SIMCardID, (SELECT TOP (1) DNBalance FROM DNReceived WHERE (SIMCardID = Processor.SIMCardID) ORDER BY CreatedTS DESC) AS Balance FROM Processor Where ((ProcessorID LIKE 'M1%') or (ProcessorID LIKE 'STARHUB%') or (ProcessorID LIKE 'PINOY%') or (ProcessorID LIKE 'INDO%'))">
                </asp:SqlDataSource>
            </div>
        </div>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>" SelectCommand="SELECT ProcessorID, SIMCardID, (SELECT TOP (1) DNBalance FROM DNReceived WHERE (SIMCardID = Processor.SIMCardID) and ReloadAmount = '5' and DNBalance != '' ORDER BY CreatedTS DESC) AS Balance FROM Processor Where ProcessorID LIKE 'SINGTELP%' ">
        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>" SelectCommand="SELECT ProcessorID, SIMCardID, (SELECT TOP (1) DNBalance FROM DNReceived WHERE (SIMCardID = Processor.SIMCardID) and ReloadAmount = '10' and DNBalance != '' ORDER BY CreatedTS DESC) AS Balance FROM Processor Where ProcessorID LIKE 'SINGTELP%'">
        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>" SelectCommand="SELECT ProcessorID, SIMCardID, (SELECT TOP (1) DNBalance FROM DNReceived WHERE (SIMCardID = Processor.SIMCardID) and ReloadAmount = '15' and DNBalance != '' ORDER BY CreatedTS DESC) AS Balance FROM Processor Where ProcessorID LIKE 'SINGTELP%'">
        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>" SelectCommand="SELECT ProcessorID, SIMCardID, (SELECT TOP (1) DNBalance FROM DNReceived WHERE (SIMCardID = Processor.SIMCardID) and ReloadAmount = '20' and DNBalance != '' ORDER BY CreatedTS DESC) AS Balance FROM Processor Where ProcessorID LIKE 'SINGTELP%'">
        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>" SelectCommand="SELECT ProcessorID, SIMCardID, (SELECT TOP (1) DNBalance FROM DNReceived WHERE (SIMCardID = Processor.SIMCardID) and ReloadAmount = '28' and DNBalance != '' ORDER  BY CreatedTS DESC) AS Balance FROM Processor Where ProcessorID LIKE 'SINGTELP%'">
        </asp:SqlDataSource>
                                <asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>" SelectCommand="SELECT ProcessorID, SIMCardID, (SELECT TOP (1) DNBalance FROM DNReceived WHERE (SIMCardID = Processor.SIMCardID) and ReloadAmount = '18' and DNBalance != '' ORDER BY CreatedTS DESC) AS Balance FROM Processor Where ProcessorID LIKE 'SINGTELP%'">
        </asp:SqlDataSource>
                                <asp:SqlDataSource ID="SqlDataSource8" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>" SelectCommand="SELECT ProcessorID, SIMCardID, (SELECT TOP (1) DNBalance FROM DNReceived WHERE (SIMCardID = Processor.SIMCardID) and ReloadAmount = '50' and DNBalance != '' ORDER BY CreatedTS DESC) AS Balance FROM Processor Where ProcessorID LIKE 'SINGTELP%'">
                                </asp:SqlDataSource>
                                <asp:SqlDataSource ID="SqlDataSource9" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>" SelectCommand="SELECT ProcessorID, SIMCardID, (SELECT TOP (1) DNBalance FROM DNReceived WHERE (SIMCardID = Processor.SIMCardID) and ReloadAmount = '22' and DNBalance != '' ORDER BY CreatedTS DESC) AS Balance FROM Processor Where ProcessorID LIKE 'SINGTELP%'">
        </asp:SqlDataSource>
        &nbsp; &nbsp;
    
    </div>
        &nbsp;
    </form>
</body>
</html>
