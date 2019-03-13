<%@ Page Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="Submaster_Refund.aspx.vb" Inherits="WebItopz.Submaster_Admin_Refund" title="Refund" %>
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
            <h3>Refund</h3>
        </div>
    </div>
    <div class="x_panel">
        <div class="x_title">
        <h2>Refund</h2>
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
    <div class="col-md-3 col-sm-3 col-xs-12">
        <asp:TextBox ID="txtReloadMSISDN" class="form-control col-md-7 col-xs-12" runat="server"></asp:TextBox>
        <span class="col-md-5 col-xs-12" style="font-size: 10pt">(65XXXXXXXX)</span>
        <asp:Label ID="lblErrorMsg" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label><br />
    </div>
    <div class="col-md-3 col-sm-3 col-xs-12">
        <asp:Button ID="btnSearch" runat="server" Text="Search" class="btn btn-success" />
    </div>
    &nbsp; &nbsp; &nbsp;&nbsp;
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" OnPreRender="GridView1_PreRender"
        CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Vertical"
        Style="margin: 10px" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CssClass="datatable-responsive table table-striped table-bordered dt-responsive nowrap">

        <FooterStyle BackColor="#CCCC99" />
        <Columns>
            <asp:BoundField DataField="ReloadMSISDN" HeaderText="ReloadMSISDN" SortExpression="ReloadMSISDN" />
            <asp:BoundField DataField="ReloadAmount" HeaderText="Amount" SortExpression="ReloadAmount" />
            <asp:BoundField DataField="AgentId" HeaderText="AgentId" SortExpression="AgentId" />
            <asp:BoundField DataField="MSISDN" HeaderText="MSISDN" SortExpression="MSISDN" />
            <asp:BoundField DataField="ReloadTelco" HeaderText="ReloadTelco" SortExpression="ReloadTelco" />
            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
            <asp:BoundField DataField="CreatedTS" HeaderText="CreatedTS" SortExpression="CreatedTS" >
                <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:HyperLinkField DataNavigateUrlFields="LocalMOId,ReloadMSISDN" DataNavigateUrlFormatString="Refund.aspx?Id={0}&amp;Action=Redo&amp;&amp;Reloadmsisdn={1}"
                HeaderText="Redo" Text="Redo" />
            <asp:HyperLinkField DataNavigateUrlFields="LocalMOId,ReloadMSISDN" DataNavigateUrlFormatString="Refund.aspx?Id={0}&amp;Action=Refund&amp;&amp;Reloadmsisdn={1}"
                HeaderText="Refund" Text="Refund" />
            <asp:HyperLinkField DataNavigateUrlFields="LocalMOId,ReloadMSISDN" DataNavigateUrlFormatString="Refund.aspx?id={0}&amp;action=cancel&amp;&amp;Reloadmsisdn={1}"
                HeaderText="Cancel" Text="Cancel" />
            <asp:HyperLinkField DataNavigateUrlFields="LocalMOID,reloadmsisdn" DataNavigateUrlFormatString="Refund.aspx?Id={0}&amp;Action=Success&amp;Reloadmsisdn={1}"
                HeaderText="Success" Text="Success" />
        </Columns>
        <SelectedRowStyle BackColor="#CE5D5A" ForeColor="White" Font-Bold="True" />
        <PagerStyle ForeColor="#333333" HorizontalAlign="Left" CssClass="GridPager" />
        <HeaderStyle BackColor="#404040" Font-Bold="True" Font-Names="Arial" Font-Size="Small" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
        <RowStyle BackColor="#F7F7DE" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
        SelectCommand="SELECT [ReloadAmount], [ReloadMSISDN], [ReloadTelco], [AgentID], [MSISDN], [CreatedTS], [DNReceivedID], [LocalMOID], [Status] FROM [TxIn] WHERE ([ReloadMSISDN] = @ReloadMSISDN)ORDER BY CreatedTS DESC">
        <SelectParameters>
            <asp:ControlParameter ControlID="txtReloadMSISDN" Name="ReloadMSISDN" PropertyName="Text"
                Type="String" />
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

