<%@ Page Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="Submaster_TelcoSettings.aspx.vb" Inherits="WebItopz.Submaster_Admin_TelcoSettings" title="TelcoSettings" %>
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
            <h3>Telco Settings</h3>
        </div>
    </div>
    <div class="x_panel">
        <div class="x_title">
        <h2>Telco Settings</h2>
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
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" OnPreRender="GridView1_PreRender"
            BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px"
            CellPadding="4" DataKeyNames="Telco" DataSourceID="SqlDataSource1" Style="margin: 10px" ForeColor="Black" GridLines="Vertical" CssClass="datatable-responsive table table-striped table-bordered dt-responsive nowrap">
            <FooterStyle BackColor="#CCCC99" />
            <Columns>
                <asp:CommandField ShowEditButton="True" />
                <asp:BoundField DataField="Telco" HeaderText="Telco" ReadOnly="True" SortExpression="Telco" />
                <asp:BoundField DataField="EndHour" HeaderText="EndHour" SortExpression="EndHour" />
                <asp:BoundField DataField="StartHour" HeaderText="StartHour" SortExpression="StartHour" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
            </Columns>
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#333333" HorizontalAlign="Left" CssClass="GridPager" />
            <HeaderStyle BackColor="#404040" Font-Bold="True" ForeColor="White" Font-Names="Arial" Font-Size="Small" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues"
            ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>" DeleteCommand="DELETE FROM [TelcoSettings] WHERE [Telco] = @original_Telco AND [EndHour] = @original_EndHour AND [StartHour] = @original_StartHour AND [Status] = @original_Status"
            InsertCommand="INSERT INTO [TelcoSettings] ([Telco], [EndHour], [StartHour], [Status]) VALUES (@Telco, @EndHour, @StartHour, @Status)"
            OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT [Telco], [EndHour], [StartHour], [Status] FROM [TelcoSettings]"
            UpdateCommand="UPDATE [TelcoSettings] SET [EndHour] = @EndHour, [StartHour] = @StartHour, [Status] = @Status WHERE [Telco] = @original_Telco AND [EndHour] = @original_EndHour AND [StartHour] = @original_StartHour AND [Status] = @original_Status">
            <DeleteParameters>
                <asp:Parameter Name="original_Telco" Type="String" />
                <asp:Parameter Name="original_EndHour" Type="Byte" />
                <asp:Parameter Name="original_StartHour" Type="Byte" />
                <asp:Parameter Name="original_Status" Type="Byte" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="EndHour" Type="Byte" />
                <asp:Parameter Name="StartHour" Type="Byte" />
                <asp:Parameter Name="Status" Type="Byte" />
                <asp:Parameter Name="original_Telco" Type="String" />
                <asp:Parameter Name="original_EndHour" Type="Byte" />
                <asp:Parameter Name="original_StartHour" Type="Byte" />
                <asp:Parameter Name="original_Status" Type="Byte" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="Telco" Type="String" />
                <asp:Parameter Name="EndHour" Type="Byte" />
                <asp:Parameter Name="StartHour" Type="Byte" />
                <asp:Parameter Name="Status" Type="Byte" />
            </InsertParameters>
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



