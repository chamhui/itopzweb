<%@ Page Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" Inherits="WebItopz.Dealer_AgentBalance" title="AgentBalance" Codebehind="AgentBalance.aspx.vb" %>
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
    <div class="page-title">
        <div class="title_left">
            <h3>Agent Balance</h3>
        </div>
    </div>
    <div class="x_panel">
        <div class="x_title">
        <h2>Agent Balance</h2>
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
    <div class="col-md-2 col-sm-2 col-xs-12">
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4" CssClass="dataTable table-bordered table-counter"
            DataSourceID="SqlDataSource2" style="margin: 10px; width: 100%;" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px">
            <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
            <Columns>
                <asp:BoundField DataField="TotalBalance" HeaderText="TotalBalance" ReadOnly="True"
                    SortExpression="TotalBalance" />
            </Columns>
            <RowStyle BackColor="White" ForeColor="#330099" Font-Names="Arial" Font-Size="Medium" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
            <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" Font-Names="Arial" Font-Size="Small" />
        </asp:GridView>
    </div>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
        SelectCommand="SELECT SUM(Balance) AS TotalBalance FROM AgentBalance &#13;&#10;WHERE (AgentID IN (SELECT AgentID FROM AgentInfo AS AgentInfo_1 WHERE (ParentAgentID = @AgentID)))">
        <SelectParameters>
            <asp:SessionParameter Name="AgentID" SessionField="DEALER_ID" />
        </SelectParameters>
    </asp:SqlDataSource>
    &nbsp;
    <br />
    <div class="item form-group form-horizontal col-md-6 col-sm-6 col-xs-12">
        <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Agent HP 
        </label>
        <div class="col-md-6 col-sm-6 col-xs-12">
            <asp:TextBox  runat="server" id="txtMSISDN" class="form-control col-md-7 col-xs-12" style="margin-bottom: 10px;" type="text"></asp:TextBox>                      
        </div>
        <div class="col-md-3 col-sm-3 col-xs-12">
            <asp:Button ID="btnSearch" runat="server" class="btn btn-success" Text="Search" />
        </div>
        <asp:Label ID="lblErrorMSISDN" runat="server" Font-Names="Arial" Font-Size="Small"></asp:Label>
    </div>    
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" OnPreRender="GridView1_PreRender"
        AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None"
        BorderWidth="1px" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="Black"
        GridLines="Vertical" style="margin: 10px" DataKeyNames="AgentID" PageSize="20" CssClass="datatable-responsive table table-striped table-bordered dt-responsive">
        <FooterStyle BackColor="#CCCC99" />
        <Columns>
            <asp:BoundField DataField="AgentID" HeaderText="AgentID" ReadOnly="True" SortExpression="AgentID" />
            <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" SortExpression="Name" />
            <asp:BoundField DataField="HPNo" HeaderText="HPNo" ReadOnly="True" SortExpression="HPNo" />
            <asp:BoundField DataField="Balance" HeaderText="Balance" SortExpression="Balance" />
					       <asp:BoundField DataField="M5" HeaderText="M5" SortExpression="M5" />
					       <asp:BoundField DataField="M18" HeaderText="M18" SortExpression="M18" />
					       <asp:BoundField DataField="M28" HeaderText="M28" SortExpression="M28" />
        </Columns>
        <RowStyle BackColor="#F7F7DE" Font-Names="Arial" Font-Size="Medium" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <PagerStyle ForeColor="#333333" HorizontalAlign="Left" CssClass="GridPager" />
        <HeaderStyle BackColor="#404040" Font-Bold="True" ForeColor="White" Font-Names="Arial" Font-Size="Small" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
        SelectCommand="SELECT AgentID, (SELECT Name FROM AgentInfo AS i WHERE (AgentID = b.AgentID)) AS Name, (SELECT HPNo FROM AgentInfo AS i WHERE (AgentID = b.AgentID)) AS HPNo, Balance, M5,M18,M28 FROM AgentBalance AS b WHERE (AgentID IN (SELECT AgentID FROM AgentInfo AS AgentInfo_1 WHERE (ParentAgentID = @AgentID))) Order by CONVERT (INT, AgentID)">
        <SelectParameters>
            <asp:SessionParameter Name="AgentID" SessionField="DEALER_ID" />
        </SelectParameters>
    </asp:SqlDataSource>
    </div>
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

