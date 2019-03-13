<%@ Page Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="Submaster_UploadReloadPin.aspx.vb" Inherits="WebItopz.Submaster_Admin_UploadReloadPin" title="UploadReloadPin" %>
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
    <asp:Label ID="Label2" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
    <div class="page-title">
        <div class="title_left">
            <h3>Upload Reload PIN</h3>
        </div>
    </div>
    <div class="x_panel">
        <div class="x_title">
        <h2>Upload Reload PIN</h2>
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
        <br />
        <div class="form-horizontal form-label-left" >                   
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:FileUpload ID="MyFile" class="form-control col-md-7 col-xs-12" Style="padding-left: 0; border: 0; box-shadow: none;"  runat="server" />
                </div>
                <div class="col-md-3 col-sm-3 col-xs-12">
                    <asp:Button ID="btnUpload" runat="server" cssClass="btn btn-success" Text="Upload ReloadPIN.txt" />
                    <asp:label id="lblMsg" Runat="server" CssClass="ErrorMessage"></asp:label>
                    <asp:label id="lblMsgError" Runat="server" CssClass="ErrorMessage"></asp:label>
                </div>
            </div>
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <span style="font-size: 10pt">Right click & save the sample file<strong><span style="font-size: 11pt">
                        <a href="ReloadPIN.txt">ReloadPIN.txt</a></span></strong></span>
                </div>
            </div>
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <asp:Button ID="btnActive" runat="server" class="btn btn-success" Text="Active" />
                <asp:Button ID="btnDelete" runat="server" class="btn btn-danger" Text="Delete" />
            </div>
        </div>
        <span class="small_darblue_text" id="span1" runat="server"></span>
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" OnPreRender="GridView1_PreRender"
            BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px"
            CellPadding="3" DataSourceID="SqlDataSource1" GridLines="Vertical" Style="margin: 10px" CssClass="datatable-responsive table table-striped table-bordered dt-responsive">
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" Font-Size="Smaller" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="BatchID" HeaderText="BatchID" SortExpression="BatchID" />
                <asp:BoundField DataField="ReloadTelco" HeaderText="ReloadTelco" SortExpression="ReloadTelco" />
                <asp:BoundField DataField="ProcessorID" HeaderText="ProcessorID" SortExpression="ProcessorID" />
                <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount" />
                <asp:BoundField DataField="TotalRecords" HeaderText="TotalRecords" ReadOnly="True"
                    SortExpression="TotalRecords" />
                <asp:BoundField DataField="TotalAmount" HeaderText="TotalAmount" ReadOnly="True"
                    SortExpression="TotalAmount" />
                <asp:BoundField DataField="BatchStatus" HeaderText="BatchStatus" SortExpression="BatchStatus" />
                <asp:BoundField DataField="CreatedTS" HeaderText="CreatedTS" SortExpression="CreatedTS">
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
            </Columns>
            <PagerStyle ForeColor="#333333" HorizontalAlign="Left" CssClass="GridPager" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" Font-Size="Smaller" />
            <AlternatingRowStyle BackColor="Gainsboro" />
        </asp:GridView> 
    </div>
    <div class="x_panel">
        <div class="x_title">
        <h2 style="overflow: initial;">Reload Pin Balance : <asp:HyperLink ID="hlManageReloadPin" runat="server" Font-Bold="True" Font-Size="Medium"
            NavigateUrl="~/Master/Admin/ReloadPinManage.aspx" Target="_blank">Manage Reload Pin</asp:HyperLink></h2>
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
        <asp:GridView ID="GridView2"
                runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" OnPreRender="GridView2_PreRender"
                BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px"
                CellPadding="4" DataSourceID="SqlDataSource2" ForeColor="Black" GridLines="Vertical"
                Style="margin: 10px" PageSize="30" CssClass="datatable-responsive table table-striped table-bordered dt-responsive">
                <FooterStyle BackColor="#CCCC99" />
                <RowStyle BackColor="#F7F7DE" />
                <Columns>
                    <asp:BoundField DataField="ReloadTelco" HeaderText="ReloadTelco" SortExpression="ReloadTelco" />
                    <asp:BoundField DataField="ProcessorID" HeaderText="ProcessorID" SortExpression="ProcessorID" />
                    <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount" />
                    <asp:BoundField DataField="Records" HeaderText="Records" SortExpression="Records" />
                    <asp:BoundField DataField="Total (SGD)" HeaderText="Total ($$)" SortExpression="Total (SGD)">
                        <HeaderStyle Wrap="False" />
                    </asp:BoundField>
                </Columns>
                <PagerStyle ForeColor="#333333" HorizontalAlign="Left" CssClass="GridPager" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
            SelectCommand="SELECT ReloadTelco, ProcessorID, Amount, COUNT(*) AS Records, COUNT(*) * Amount AS [Total (SGD)] FROM ReloadPin WHERE (BatchStatus = 'ACTIVE') AND (Status = 'NEW') GROUP BY ReloadTelco, ProcessorID, Amount ORDER BY ReloadTelco DESC">
        </asp:SqlDataSource>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
            SelectCommand="SELECT BatchID, ReloadTelco, ProcessorID, Amount, COUNT(*) AS TotalRecords, COUNT(*) * Amount AS TotalAmount, BatchStatus, CreatedTS FROM ReloadPin &#13;&#10;WHERE BatchStatus<>'DELETE'&#13;&#10;GROUP BY BatchID, ReloadTelco, ProcessorID, Amount, BatchStatus, CreatedTS &#13;&#10;ORDER BY CreatedTS DESC">
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

