<%@ Page Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="Submaster_ReportSalesByTelcoSIM.aspx.vb" Inherits="WebItopz.Submaster_Admin_ReportTotalAgentSales" title="ReportSalesByTelcoSIM" %>
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
            <h3>Report Sales by Telco SIM</h3>
        </div>
    </div>
    <div class="x_panel">
        <div class="x_title">
        <h2>Report Sales by Telco SIM</h2>
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
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Month 
                </label>
                <div class="col-md-8 col-sm-8 col-xs-12">
                    <asp:DropDownList ID="DDLMonth" runat="server" class="form-control col-md-12 col-xs-12" >
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
                    </asp:DropDownList>       
                </div>
            </div>
           <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Year 
                </label>
                <div class="col-md-8 col-sm-8 col-xs-12">
                    <asp:DropDownList ID="DDLYear" runat="server" class="form-control col-md-12 col-xs-12" >
                    </asp:DropDownList>     
                </div>
            </div>
            <div class="item form-group col-md-7 col-sm-7 col-xs-12" style="text-align:center;">
                <asp:Button ID="btnGenerate" runat="server" class="btn btn-success" Text="Generate" />
                <asp:Label ID="lblError" runat="server" Font-Bold="True" ForeColor="#FF6600"></asp:Label>
            </div>
        </div>
    </div>
    <div class="col-md-6 col-sm-6 col-xs-12" style="padding-left: 0;">
        <div class="x_panel">
            <div class="x_title">
            <h2>Total Agent Sales</h2>
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
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnPreRender="GridView1_PreRender"
                BackColor="White" BorderColor="#DEDFDE" BorderWidth="1px" CellPadding="4" ForeColor="Black" 
                GridLines="Vertical" BorderStyle="None" CssClass="datatable-responsive table table-striped table-bordered dt-responsive">
                <Columns>
                    <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
                    <asp:BoundField DataField="ReloadTelco" HeaderText="ReloadTelco" SortExpression="ReloadTelco" />
                    <asp:BoundField DataField="TotalSales" HeaderText="TotalSales" SortExpression="TotalSales" />
                </Columns>
                <FooterStyle BackColor="#CCCC99" />
                <SelectedRowStyle BackColor="#CE5D5A" ForeColor="White" Font-Bold="True" />
                <PagerStyle ForeColor="#333333" HorizontalAlign="Left" CssClass="GridPager" />
                <HeaderStyle BackColor="#404040" Font-Bold="True" Font-Names="Arial" Font-Size="Small" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
                <RowStyle BackColor="#F7F7DE" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
                SelectCommand="SELECT  convert(char(10),createdts,111) Date, [ReloadTelco], sum(ReloadAmount) as TotalSales FROM [TxIn]WHERE (Status = 'SUCCESS')  and datepart(mm,createdts)=@month and datepart(yyyy,createdts)=@year&#13;&#10;group by convert(char(10),createdts,111), [ReloadTelco]&#13;&#10;order by convert(char(10),createdts,111) , ReloadTelco">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DDLMonth" Name="month" PropertyName="SelectedValue" />
                    <asp:ControlParameter ControlID="DDLYear" Name="year" PropertyName="SelectedValue" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
    </div>
    <div class="col-md-6 col-sm-6 col-xs-12" style="padding-right: 0;">
        <div class="x_panel">
            <div class="x_title">
            <h2>Total SimCard Sales</h2>
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
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White" OnPreRender="GridView2_PreRender"
                BorderColor="#DEDFDE" BorderWidth="1px" CellPadding="4" DataSourceID="SqlDataSource2"
                ForeColor="Black" GridLines="Vertical" BorderStyle="None" DataKeyNames="SIMCardID" CssClass="datatable-responsive table table-striped table-bordered dt-responsive">
                <FooterStyle BackColor="#CCCC99" />
                <Columns>
                    <asp:BoundField DataField="Date" HeaderText="Date" ReadOnly="True" SortExpression="Date" />
                    <asp:BoundField DataField="Telco" HeaderText="Telco" SortExpression="Telco" />
                    <asp:BoundField DataField="SIMCardID" HeaderText="SIMCardID" ReadOnly="True" SortExpression="SIMCardID" />
                    <asp:BoundField DataField="TotalSales" HeaderText="TotalSales" ReadOnly="True" SortExpression="TotalSales" />
                </Columns>
                <SelectedRowStyle BackColor="#CE5D5A" ForeColor="White" Font-Bold="True" />
                <PagerStyle ForeColor="#333333" HorizontalAlign="Left" CssClass="GridPager" />
                <HeaderStyle BackColor="#404040" Font-Bold="True" Font-Names="Arial" Font-Size="Small" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
                <RowStyle BackColor="#F7F7DE" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
                SelectCommand="SELECT CONVERT (char(10), d.CreatedTS, 111) AS Date, s.Telco, SUM(d.ReloadAmount) AS TotalSales, s.SIMCardID FROM DNReceived AS d INNER JOIN SIMCard AS s ON d.SIMCardID = s.SIMCardID WHERE (d.DNStatus = 'SUCCESS') OR (d.DNStatus = 'succeedfully') AND (DATEPART(mm, d.CreatedTS) = @month) AND (DATEPART(yyyy, d.CreatedTS) = @year) GROUP BY CONVERT (char(10), d.CreatedTS, 111), s.Telco, s.SIMCardID ORDER BY Date, s.Telco, s.SIMCardID">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DDLMonth" Name="month" PropertyName="SelectedValue" />
                    <asp:ControlParameter ControlID="DDLYear" Name="year" PropertyName="SelectedValue" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
    </div>
    <div style="clear: both;"></div>

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
        //var totalRecords = $(".datatable-responsive").DataTable().page.info().recordsTotal;
        //alert(totalRecords);
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




