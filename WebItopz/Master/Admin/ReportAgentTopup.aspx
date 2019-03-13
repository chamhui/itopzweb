<%@ Page Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="ReportAgentTopup.aspx.vb" Inherits="WebItopz.Admin_ReportAgentTopup" title="ReportAgentTopup" %>
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
            <h3>Agent TopUp History</h3>
        </div>
    </div>
    <div class="x_panel">
        <div class="x_title">
        <h2>Agent TopUp History</h2>
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
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Day 
                </label>
                <div class="col-md-8 col-sm-8 col-xs-12">
                    <asp:DropDownList ID="DDLDay" runat="server" class="form-control col-md-12 col-xs-12" >
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
                        <asp:ListItem>13</asp:ListItem>
                        <asp:ListItem>14</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>16</asp:ListItem>
                        <asp:ListItem>17</asp:ListItem>
                        <asp:ListItem>18</asp:ListItem>
                        <asp:ListItem>19</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>21</asp:ListItem>
                        <asp:ListItem>22</asp:ListItem>
                        <asp:ListItem>23</asp:ListItem>
                        <asp:ListItem>24</asp:ListItem>
                        <asp:ListItem>25</asp:ListItem>
                        <asp:ListItem>26</asp:ListItem>
                        <asp:ListItem>27</asp:ListItem>
                        <asp:ListItem>28</asp:ListItem>
                        <asp:ListItem>29</asp:ListItem>
                        <asp:ListItem>30</asp:ListItem>
                        <asp:ListItem>31</asp:ListItem>
                    </asp:DropDownList>          
                </div>
            </div>
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
                <asp:Button ID="Button1" runat="server" class="btn btn-success" Text="Generate" />
            </div>
        </div>
    </div>
    <div class="col-md-12 col-sm-12 col-xs-12" style="padding-left: 0;">
        <div class="x_panel">
            <div class="x_title">
            <h2>Topup Summary (Selected Date)</h2>
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

	<asp:Button ID="btnExport" runat="server" Text="Export" />

            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" OnPreRender="GridView1_PreRender"
                BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px"
                CellPadding="4" DataSourceID="SqlDataSource1" GridLines="Vertical" style="margin: 10px" PageSize="30" ForeColor="Black" CssClass="datatable-responsive table table-striped table-bordered dt-responsive nowrap">
                <FooterStyle BackColor="#CCCC99" />
                <Columns>
                    <asp:BoundField DataField="Date" HeaderText="Date" ReadOnly="True" SortExpression="Date" />
                    <asp:BoundField DataField="Amount" HeaderText="Amount" ReadOnly="True" SortExpression="Amount" />
                    <asp:BoundField DataField="AgentID" HeaderText="AgentID" SortExpression="AgentID" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
									 <asp:BoundField DataField="M5Q" HeaderText="M5 Quantity" ReadOnly="True" SortExpression="M5Q" />
									 <asp:BoundField DataField="M5RA" HeaderText="M5 Purchase Value" ReadOnly="True" SortExpression="M5RA" />
									 <asp:BoundField DataField="M18Q" HeaderText="M18 Quantity" ReadOnly="True" SortExpression="M18Q" />
									 <asp:BoundField DataField="M18RA" HeaderText="M18 Purchase Value" ReadOnly="True" SortExpression="M18RA" />
									 <asp:BoundField DataField="M28Q" HeaderText="M28 Quantity" ReadOnly="True" SortExpression="M28Q" />
									 <asp:BoundField DataField="M28RA" HeaderText="M28 Purchase Value" ReadOnly="True" SortExpression="M28RA" />					
                </Columns>
                <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <PagerStyle ForeColor="#333333" HorizontalAlign="Left" CssClass="GridPager" />
                <HeaderStyle BackColor="#404040" Font-Bold="True" ForeColor="White" Font-Names="Arial" Font-Size="Small" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
                SelectCommand="SELECT CONVERT (varchar(10), t.CreatedTS, 111) AS Date, SUM(t.Amount) AS Amount, t.AgentID, i.Name,Sum(M5Q) as M5Q, Sum(M18Q) as M18Q, Sum(M28Q) as M28Q,Sum(M5RA) as M5RA, Sum(M18RA) as M18RA, Sum(M28RA) as M28RA FROM AgentTopupTx AS t INNER JOIN AgentInfo AS i ON t.AgentID = i.AgentID LEFT JOIN (select Quantity AS M5Q , ReloadAmount AS M5RA, AgentID from AgentTopupTx where (DATEPART(mm, CreatedTS) = @month) AND (DATEPART(yyyy, CreatedTS) = @year) AND (DAY(CreatedTS) = @Day) and ReloadType='M5' ) AS ATT1 on ATT1.AgentID =  i.AgentID LEFT JOIN (select Quantity AS M18Q , ReloadAmount AS M18RA, AgentID from AgentTopupTx where (DATEPART(mm, CreatedTS) = @month) AND (DATEPART(yyyy, CreatedTS) = @year) AND (DAY(CreatedTS) = @Day) and ReloadType='M18' ) AS ATT2 on ATT2.AgentID =  i.AgentID LEFT JOIN (select Quantity AS M28Q , ReloadAmount AS M28RA, AgentID from AgentTopupTx where (DATEPART(mm, CreatedTS) = @month) AND (DATEPART(yyyy, CreatedTS) = @year) AND (DAY(CreatedTS) = @Day) and ReloadType='M28' ) AS ATT3 on ATT3.AgentID =  i.AgentID WHERE (DATEPART(mm, t.CreatedTS) = @month) AND (DATEPART(yyyy, t.CreatedTS) = @year) AND (DAY(t.CreatedTS) = @Day) AND (t.Type = 'TOPUP' OR T.TYPE='RECEIVED') GROUP BY CONVERT (varchar(10), t.CreatedTS, 111), t.AgentID, i.Name ORDER BY CONVERT (INT, t.AgentID)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DDLMonth" Name="month" PropertyName="SelectedValue" />
                    <asp:ControlParameter ControlID="DDLYear" Name="year" PropertyName="SelectedValue" />
                    <asp:ControlParameter ControlID="DDLDay" Name="Day" PropertyName="SelectedValue" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
    </div>
    <div class="col-md-12 col-sm-12 col-xs-12" style="padding-right: 0;">
        <div class="x_panel">
            <div class="x_title">
            <h2>Monthly Topup Summary</h2>
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
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4" CssClass="dataTable table-bordered table-counter"
                DataSourceID="SqlDataSource2" ForeColor="Black" GridLines="Vertical" Style="margin: 10px; width: 100%;" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px">
                <FooterStyle BackColor="#CCCC99" />
                <Columns>
                    <asp:BoundField DataField="Month" HeaderText="Month" ReadOnly="True" SortExpression="Month" />
                    <asp:BoundField DataField="Amount" HeaderText="Amount" ReadOnly="True" SortExpression="Amount" />
									 <asp:BoundField DataField="M5Q" HeaderText="M5 Quantity" ReadOnly="True" SortExpression="M5Q" />
									 <asp:BoundField DataField="M5RA" HeaderText="M5 Purchase Value" ReadOnly="True" SortExpression="M5RA" />
									 <asp:BoundField DataField="M18Q" HeaderText="M18 Quantity" ReadOnly="True" SortExpression="M18Q" />
									 <asp:BoundField DataField="M18RA" HeaderText="M18 Purchase Value" ReadOnly="True" SortExpression="M18RA" />
									 <asp:BoundField DataField="M28Q" HeaderText="M28 Quantity" ReadOnly="True" SortExpression="M28Q" />
									 <asp:BoundField DataField="M28RA" HeaderText="M28 Purchase Value" ReadOnly="True" SortExpression="M28RA" />					
                </Columns>
                <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <HeaderStyle BackColor="#404040" Font-Bold="True" ForeColor="White" Font-Names="Arial" Font-Size="Small" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
          <%--  <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
                SelectCommand="SELECT Month(CreatedTS) as Month, Sum(Amount) as Amount,Sum(M5Q) as M5Q, Sum(M18Q) as M18Q, Sum(M28Q) as M28Q,Sum(M5PV) as M5PV, Sum(M18PV) as M18PV, Sum(M28PV) as M28PV, FROM [AgentTopupTx]&#13;&#10;where year(CreatedTS) = @year&#13;&#10;group by month(CreatedTS) order by month">--%>
					  <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
                SelectCommand="SELECT Month(CreatedTS) as Month, Sum(Amount) as Amount,Sum(M5Q) as M5Q, Sum(M18Q) as M18Q, Sum(M28Q) as M28Q,Sum(M5RA) as M5RA, Sum(M18RA) as M18RA, Sum(M28RA) as M28RA FROM [AgentTopupTx] left join (select Quantity AS M5Q , ReloadAmount AS M5RA, Month(CreatedTS) as Month from AgentTopupTx where year(CreatedTS) = @year and ReloadType='M5') AS ATT1 on ATT1.Month =  Month(AgentTopupTx.CreatedTS)  left join (select Quantity AS M18Q , ReloadAmount AS M18RA, Month(CreatedTS) as Month from AgentTopupTx where year(CreatedTS) = @year and ReloadType='M18') AS ATT2 on ATT2.Month =  Month(AgentTopupTx.CreatedTS)   left join (select Quantity AS M28Q , ReloadAmount AS M28RA, Month(CreatedTS) as Month from AgentTopupTx where year(CreatedTS) = @year and ReloadType='M28') AS ATT3 on ATT3.Month =  Month(AgentTopupTx.CreatedTS)   where year(CreatedTS) = @year  group by month(CreatedTS) order by month">
                <SelectParameters>
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
