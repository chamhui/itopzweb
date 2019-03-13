<%@ Page Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="ProcessorSetting.aspx.vb" Inherits="WebItopz.Admin_SIMSetting" title="ProcessorSetting" %>
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
            <h3>Processor Settings</h3>
        </div>
    </div>
    <div class="x_panel">
        <div class="x_title">
        <h2>Processor Settings</h2>
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
        DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="Black" GridLines="Vertical" style="margin: 10px; width: 100%;" 
        BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" PageSize="30" CssClass="datatable-responsive table table-striped table-bordered dt-responsive">
        <Columns>
            <asp:CommandField ShowEditButton="True" />
            <asp:BoundField DataField="ProcessorID" HeaderText="ProcessorID" ReadOnly="True"
                SortExpression="ProcessorID" />
            <asp:BoundField DataField="SIMCardID" HeaderText="SIMCardID" SortExpression="SIMCardID" >
                
            </asp:BoundField>
            <asp:BoundField DataField="Pin" HeaderText="Pin" SortExpression="Pin" />
            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" >
                
            </asp:BoundField>
            <asp:BoundField DataField="ModemPort" HeaderText="ModemPort" SortExpression="ModemPort" >
                
            </asp:BoundField>
            <asp:BoundField DataField="LastUpdatedTS" HeaderText="LastUpdatedTS" ReadOnly="True" SortExpression="LastUpdatedTS" >
            <ItemStyle Wrap=false />
            </asp:BoundField>
        </Columns>
        <FooterStyle BackColor="#CCCC99" />
        <RowStyle BackColor="#F7F7DE" Font-Names="Arial" Font-Size="Medium" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <PagerStyle ForeColor="#333333" HorizontalAlign="Left" CssClass="GridPager" />
        <HeaderStyle BackColor="#404040" Font-Bold="True" ForeColor="White" Font-Names="Arial" Font-Size="Small" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues"
        ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>" DeleteCommand="DELETE FROM [Processor] WHERE [ProcessorID] = @original_ProcessorID AND [SIMCardID] = @original_SIMCardID AND [Status] = @original_Status AND [ModemPort] = @original_ModemPort AND [CreatedTS] = @original_CreatedTS"
        InsertCommand="INSERT INTO [Processor] ([ProcessorID], [SIMCardID], [Status], [ModemPort], [CreatedTS]) VALUES (@ProcessorID, @SIMCardID, @Status, @ModemPort, @CreatedTS)"
        OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT ProcessorID, SIMCardID, Pin, Status, ModemPort, LastUpdatedTS FROM Processor"
        UpdateCommand="UPDATE [Processor] SET [Status] = @Status, [ModemPort] = @ModemPort, [LastUpdatedTS] = getdate(), [SIMCardID]=@SIMCardID, [PIN]=@PIN WHERE [ProcessorID] = @original_ProcessorID AND [SIMCardID] = @original_SIMCardID">
        <DeleteParameters>
            <asp:Parameter Name="original_ProcessorID" Type="String" />
            <asp:Parameter Name="original_SIMCardID" Type="String" />
            <asp:Parameter Name="original_Status" Type="String" />
            <asp:Parameter Name="original_ModemPort" Type="String" />
            <asp:Parameter Name="original_CreatedTS" Type="DateTime" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="Status" Type="String" />
            <asp:Parameter Name="ModemPort" Type="String" />
            <asp:Parameter Name="SIMCardID" Type="String" />
            <asp:Parameter Name="PIN" />
            <asp:Parameter Name="original_ProcessorID" Type="String" />
            <asp:Parameter Name="original_SIMCardID" Type="String" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="ProcessorID" Type="String" />
            <asp:Parameter Name="SIMCardID" Type="String" />
            <asp:Parameter Name="Status" Type="String" />
            <asp:Parameter Name="ModemPort" Type="String" />
            <asp:Parameter Name="CreatedTS" Type="DateTime" />
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