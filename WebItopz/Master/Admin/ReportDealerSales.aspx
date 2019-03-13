<%@ Page Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="ReportDealerSales.aspx.vb" Inherits="WebItopz.Admin_ReportAgentSales" title=" ReportAgentSales" %>
<asp:Content ID="Header" ContentPlaceHolderID="MainHeader" runat="server">
        <!-- NProgress -->
    <link href="/Theme/nprogress/nprogress.css" rel="stylesheet" />

    <!-- Datatables -->
    <link href="/Theme/datatables.net-bs/css/dataTables.bootstrap.min.css" rel="stylesheet" />
    <link href="/Theme/datatables.net-buttons-bs/css/buttons.bootstrap.min.css" rel="stylesheet" />
    <link href="/Theme/datatables.net-fixedheader-bs/css/fixedHeader.bootstrap.min.css" rel="stylesheet" />
    <link href="/Theme/datatables.net-responsive-bs/css/responsive.bootstrap.min.css" rel="stylesheet" />
    <link href="/Theme/datatables.net-scroller-bs/css/scroller.bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblErrorMsg" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
    <div class="page-title">
        <div class="title_left">
            <h3>Report Dealer Sales</h3>
        </div>
    </div>
    <div class="x_panel">
        <div class="x_title">
        <h2>Report Dealer Sales</h2>
        <ul class="nav navbar-right panel_toolbox">
            <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
            </li>
            <li class="dropdown">
            <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false"><i class="fa fa-wrench"></i></a>
            <ul class="dropdown-menu" role="menu">
                <li><a href="#">Settings 1</a>
                </li>
                <li><a href="#">Settings 2</a>
                </li>
            </ul>
            </li>
            <li><a class="close-link"><i class="fa fa-close"></i></a>
            </li>
        </ul>
        <div class="clearfix"></div>
        </div>
        <div class="form-horizontal form-label-left" >                  
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Agent ID 
                </label>
                <div class="col-md-9 col-sm-9 col-xs-12">
                    <asp:DropDownList ID="txtAgentID" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource7"
                        DataTextField="Name" DataValueField="AgentID" class="form-control col-md-7 col-xs-12">
                    </asp:DropDownList>         
                </div>
            </div>
           <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Date From 
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtDateFrom" runat="server" class="form-control col-md-7 col-xs-12"></asp:TextBox>     
                </div>
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">(yyyymmdd)
                </label>
            </div>
           <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Date To 
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtDateTo" runat="server" class="form-control col-md-7 col-xs-12"></asp:TextBox>    
                </div>
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">(yyyymmdd)
                </label>
            </div>
            <div class="item form-group col-md-7 col-sm-7 col-xs-12" style="text-align:center;">
                <asp:Button ID="btnSearch" runat="server" class="btn btn-success" Text="Search" />
            </div>
        </div>
    </div>
    <div class="col-md-2 col-sm-2 col-xs-12">
			
	<asp:Button ID="btnExport" runat="server" Text="Export" />
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White" CssClass="dataTable table-bordered table-counter"
            BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="SqlDataSource2" Style="margin: 10px; width: 100%;">
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <Columns>
                <asp:BoundField DataField="Total" HeaderText="Total (SGD)" SortExpression="Total" >
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
            </Columns>
            <RowStyle BackColor="White" ForeColor="#330099" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
        </asp:GridView>
    </div>
    <div class="col-md-4 col-sm-4 col-xs-12">
        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" BackColor="White" CssClass="dataTable table-bordered table-counter"
            BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataSourceID="SqlDataSource3" Style="margin: 10px; width: 100%;" >
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <Columns>
                <asp:BoundField DataField="ReloadTelco" HeaderText="Telco" SortExpression="ReloadTelco" />
                <asp:BoundField DataField="Total" HeaderText="Total (SGD)" SortExpression="Total" >
                    <HeaderStyle Wrap="False" />
                </asp:BoundField>
            </Columns>
            <RowStyle BackColor="White" ForeColor="#330099" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
        </asp:GridView>
    </div>
    <div class="col-md-2 col-sm-2 col-xs-12">
        <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" CellPadding="4" CssClass="dataTable table-bordered table-counter"
            DataSourceID="SqlDataSource4" ForeColor="#333333" GridLines="None" Style="margin: 10px; width: 100%;" >
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Balance" HeaderText="Balance" SortExpression="Balance" />
								<asp:BoundField DataField="M5" HeaderText="M5" SortExpression="M5" />
							<asp:BoundField DataField="M18" HeaderText="M18" SortExpression="M18" />
							<asp:BoundField DataField="M28" HeaderText="M28" SortExpression="M28" />
            </Columns>
        </asp:GridView>
    </div>
    <div class="col-md-4 col-sm-4 col-xs-12">
        <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" CellPadding="4" CssClass="dataTable table-bordered table-counter"
            DataSourceID="SqlDataSource6" ForeColor="#333333" GridLines="None" Style="margin: 10px; width: 100%;" >
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <Columns>
                <asp:BoundField DataField="ReloadTelco" HeaderText="ReloadTelco" SortExpression="ReloadTelco" />
                <asp:BoundField DataField="Total" HeaderText="Total" ReadOnly="True" SortExpression="Total" />
            </Columns>
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
    </div>
    <div class="col-md-12 col-sm-12 col-xs-12">
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" OnPreRender="GridView1_PreRender"
            AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None"
            BorderWidth="1px" CellPadding="4" DataSourceID="SqlDataSource1" CssClass="datatable-responsive table table-striped table-bordered dt-responsive nowrap"
            GridLines="Vertical" style="margin: 10px" ForeColor="Black">
            <FooterStyle BackColor="#CCCC99" />
            <Columns>
                <asp:BoundField DataField="ReloadMSISDN" HeaderText="ReloadMSISDN" SortExpression="ReloadMSISDN" />
                <asp:BoundField DataField="ReloadAmount" HeaderText="$$" SortExpression="ReloadAmount" />
                <asp:BoundField DataField="ReloadTelco" HeaderText="Telco" SortExpression="ReladTelco" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                <asp:BoundField DataField="BalanceAfterReload" HeaderText="Balance" SortExpression="BalanceAfterReload" />
                <asp:BoundField DataField="AgentID" HeaderText="AgentID" SortExpression="AgentID" />
                <asp:BoundField DataField="MSISDN" HeaderText="AgentMSISDN" SortExpression="MSISDN" />
                <asp:BoundField DataField="MessageIn" HeaderText="MessageIn" SortExpression="MessageIn" />
                <asp:BoundField DataField="LastUpdatedTS" HeaderText="LastUpdatedTS" SortExpression="LastUpdatedTS" />
            </Columns>
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#333333" HorizontalAlign="Left" CssClass="GridPager" />
            <HeaderStyle BackColor="#404040" Font-Bold="True" ForeColor="White" Font-Names="Arial" Font-Size="Small" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
            SelectCommand="SELECT T.MSISDN, T.ReloadTelco, T.AgentID, T.ReloadAmount, T.ReloadMSISDN, T.LastUpdatedTS, T.MessageIn, T.Status, R.BalanceAfterReload FROM TxIn AS T INNER JOIN TxReload AS R ON T.LocalMOID = R.LocalMOID COLLATE Chinese_Taiwan_Stroke_CI_AS WHERE  (T.AgentID in (select agentid from agentinfo where parentagentid=@AgentId)) AND (LEFT (T.MessageTS, 8) >= @MessageTS) AND (LEFT (T.MessageTS, 8) <= @MessageTS2) ORDER BY T.MessageTS DESC">
            <SelectParameters>
                <asp:ControlParameter ControlID="txtAgentID" Name="AgentID" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="txtDateFrom" Name="MessageTS" PropertyName="Text"
                    Type="String" />
                <asp:ControlParameter ControlID="txtDateTo" Name="MessageTS2" PropertyName="Text"
                    Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
    <div style="clear: both;"></div>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
                    SelectCommand="SELECT SUM(ReloadAmount) AS Total FROM TxIn WHERE (LEFT (MessageTS, 8) >= @MessageTS) AND (LEFT (MessageTS, 8) <= @MessageTS1) AND (Status = @Status) AND (AgentID IN (SELECT AgentID FROM AgentInfo WHERE (ParentAgentID = @AgentId)))">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="txtDateFrom" Name="MessageTS" PropertyName="Text"
                            Type="String" />
                        <asp:ControlParameter ControlID="txtDateTo" DefaultValue="" Name="MessageTS1" PropertyName="Text" />
                        <asp:Parameter DefaultValue="SUCCESS" Name="Status" Type="String" />
                        <asp:ControlParameter ControlID="txtAgentID" DefaultValue="" Name="AgentId" PropertyName="Text" />
                    </SelectParameters>
                </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
                    SelectCommand="SELECT ReloadTelco, SUM(ReloadAmount) AS Total FROM TxIn WHERE (LEFT (MessageTS, 8) >= @MessageTS) AND (LEFT (MessageTS, 8) <= @MessageTS1) AND (Status = @Status) AND (AgentID IN (SELECT AgentID FROM AgentInfo WHERE (ParentAgentID = @AgentId))) GROUP BY ReloadTelco">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="txtDateFrom" Name="MessageTS" PropertyName="Text" />
                        <asp:ControlParameter ControlID="txtDateTo" Name="MessageTS1" PropertyName="Text" />
                        <asp:Parameter DefaultValue="SUCCESS" Name="Status" />
                        <asp:ControlParameter ControlID="txtAgentID" DefaultValue="" Name="AgentId" PropertyName="Text" />
                    </SelectParameters>
                </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
                    
        SelectCommand="SELECT SUM(Balance) as Balance,SUM(M5) as M5,SUM(M18) as M18,SUM(M28) as M28  FROM [AgentBalance] WHERE  (AgentID in (select agentid from agentinfo where parentagentid=@AgentId))">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="txtAgentID" Name="AgentID" PropertyName="Text" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
        SelectCommand="SELECT FROM TxReload INNER JOIN TxIn ON TxReload.LocalMOID COLLATE Chinese_Taiwan_Stroke_CI_AS = TxIn.LocalMOID">
    </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
                    SelectCommand="SELECT  ReloadTelco, sum([ReloadAmount]) as Total FROM [TxIn] WHERE ((left([MessageTS],8) >= @MessageTS) AND (left([MessageTS],8) <= @MessageTS1) AND ([Status] = @Status)) and  (AgentID in (select agentid from agentinfo where parentagentid=@AgentId)) GROUP BY ReloadTelco&#13;&#10;">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="txtDateFrom" Name="MessageTS" PropertyName="Text" />
                        <asp:ControlParameter ControlID="txtDateTo" Name="MessageTS1" PropertyName="Text" />
                        <asp:Parameter DefaultValue="SUCCESS" Name="Status" Type="String" />
                        <asp:ControlParameter ControlID="txtAgentID" Name="AgentID" PropertyName="Text" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
        SelectCommand="SELECT CONVERT (varchar(10), AgentID) + ' ' + Name AS Name, AgentID FROM AgentInfo WHERE (ParentAgentID = '0')">
    </asp:SqlDataSource>
    <script src="/Theme/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="/Theme/datatables.net-bs/js/dataTables.bootstrap.min.js"></script>
    <script src="/Theme/datatables.net-buttons/js/dataTables.buttons.min.js"></script>
    <script src="/Theme/datatables.net-buttons-bs/js/buttons.bootstrap.min.js"></script>
    <script src="/Theme/datatables.net-buttons/js/buttons.flash.min.js"></script>
    <script src="/Theme/datatables.net-buttons/js/buttons.html5.min.js"></script>
    <script src="/Theme/datatables.net-buttons/js/buttons.print.min.js"></script>
    <script src="/Theme/datatables.net-fixedheader/js/dataTables.fixedHeader.min.js"></script>
    <script src="/Theme/datatables.net-keytable/js/dataTables.keyTable.min.js"></script>
    <script src="/Theme/datatables.net-responsive/js/dataTables.responsive.min.js"></script>
    <script src="/Theme/datatables.net-responsive-bs/js/responsive.bootstrap.js"></script>
    <script src="/Theme/datatables.net-scroller/js/datatables.scroller.min.js"></script>
    <script src="/Theme/jszip/dist/jszip.min.js"></script>
    <script src="/Theme/pdfmake/build/pdfmake.min.js"></script>
    <script src="/Theme/pdfmake/build/vfs_fonts.js"></script>


    <!-- Datatables -->
    <script>
      $(document).ready(function() {
        var handleDataTableButtons = function() {
          if ($("#datatable-buttons").length) {
            $("#datatable-buttons").DataTable({
              dom: "Bfrtip",
              buttons: [
                {
                  extend: "copy",
                  className: "btn-sm"
                },
                {
                  extend: "csv",
                  className: "btn-sm"
                },
                {
                  extend: "excel",
                  className: "btn-sm"
                },
                {
                  extend: "pdfHtml5",
                  className: "btn-sm"
                },
                {
                  extend: "print",
                  className: "btn-sm"
                },
              ],
              responsive: true
            });
          }
        };

        TableManageButtons = function() {
          "use strict";
          return {
            init: function() {
              handleDataTableButtons();
            }
          };
        }();

        $('#datatable').dataTable();

        $('#datatable-keytable').DataTable({
          keys: true
        });

        //$('.datatable-responsive').DataTable();
        //$(".datatable-responsive").prepend($("<thead></thead>").append($(".datatable-responsive").find("tr:first"))).dataTable();
        $(".datatable-responsive").dataTable({ searching: false, info: false, paging: false, ordering: false });
        $(".datatable-responsive>tfoot>tr>td").css("display", "block");

        $('#datatable-scroller').DataTable({
          ajax: "js/datatables/json/scroller-demo.json",
          deferRender: true,
          scrollY: 380,
          scrollCollapse: true,
          scroller: true
        });

        $('#datatable-fixed-header').DataTable({
          fixedHeader: true
        });

        var $datatable = $('#datatable-checkbox');

        $datatable.dataTable({
          'order': [[ 1, 'asc' ]],
          'columnDefs': [
            { orderable: false, targets: [0] }
          ]
        });
        $datatable.on('draw.dt', function() {
          $('input').iCheck({
            checkboxClass: 'icheckbox_flat-green'
          });
        });

        TableManageButtons.init();
      });
    </script> 
</asp:Content>

