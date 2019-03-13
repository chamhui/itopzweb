<%@ Page Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="MTSuccess.aspx.vb" Inherits="WebItopz.Admin_MTSuccess" title="MTSuccess" %>
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
            <h3>Last 100 Successful MT</h3>
        </div>
    </div>
    <div class="x_panel">
        <div class="x_title">
        <h2>Last 100 Successful MT</h2>
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
    <table>
        <tr>
            <td style="width: 100px">
            </td>
            <td colspan="4" style="width: 200px">
                <strong><span style="text-decoration: underline"></span></strong></td>
            <td colspan="1" style="width: 305px">
                <asp:Label ID="lblErrorMsg" runat="server" Font-Size="Small" ForeColor="Red" Wrap="False"></asp:Label></td>
        </tr>
    </table>
    <div class="col-md-1 col-sm-1 col-xs-12">
        <asp:GridView ID="GridView3" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None"
            BorderWidth="1px" CellPadding="4" DataSourceID="SqlDataSource2" CssClass="dataTable table-bordered table-counter"
            GridLines="Vertical" style="margin: 10px; width: 100%;" ForeColor="Black" PageSize="1"><RowStyle BackColor="#F7F7DE" />
            <Columns>
                <asp:BoundField DataField="Total" HeaderText="MTP1" ReadOnly="True" SortExpression="Total" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Left" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#404040" Font-Bold="True" ForeColor="White" Font-Names="Arial" Font-Size="Small" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
     </div>
    <div class="col-md-1 col-sm-1 col-xs-12">
        <asp:GridView ID="GridView4" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None"
            BorderWidth="1px" CellPadding="4" DataSourceID="SqlDataSource3" CssClass="dataTable table-bordered table-counter"
            GridLines="Vertical" style="margin: 10px; width: 100%;" ForeColor="Black" PageSize="1"><RowStyle BackColor="#F7F7DE" />
            <Columns>
                <asp:BoundField DataField="Total" HeaderText="MTP2" ReadOnly="True" SortExpression="Total" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Left" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#404040" Font-Bold="True" ForeColor="White" Font-Names="Arial" Font-Size="Small" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
     </div>
    <div class="col-md-1 col-sm-1 col-xs-12">
        <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None"
            BorderWidth="1px" CellPadding="4" DataSourceID="SqlDataSource4" CssClass="dataTable table-bordered table-counter"
            GridLines="Vertical" style="margin: 10px; width: 100%;" ForeColor="Black" PageSize="1"><RowStyle BackColor="#F7F7DE" />
            <Columns>
                <asp:BoundField DataField="Total" HeaderText="MTP3" ReadOnly="True" SortExpression="Total" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Left" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#404040" Font-Bold="True" ForeColor="White" Font-Names="Arial" Font-Size="Small" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
    </div>
    <div class="col-md-1 col-sm-1 col-xs-12">
        <asp:GridView ID="GridView5" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None"
            BorderWidth="1px" CellPadding="4" DataSourceID="SqlDataSource5" CssClass="dataTable table-bordered table-counter"
            GridLines="Vertical" style="margin: 10px; width: 100%;" ForeColor="Black" PageSize="1"><RowStyle BackColor="#F7F7DE" />
            <Columns>
                <asp:BoundField DataField="Total" HeaderText="MTP4" ReadOnly="True" SortExpression="Total" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Left" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#404040" Font-Bold="True" ForeColor="White" Font-Names="Arial" Font-Size="Small" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
    </div>
    <div class="col-md-1 col-sm-1 col-xs-12">
        <asp:GridView ID="GridView6" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None"
            BorderWidth="1px" CellPadding="4" DataSourceID="SqlDataSource6" CssClass="dataTable table-bordered table-counter"
            GridLines="Vertical" style="margin: 10px; width: 100%;" ForeColor="Black" PageSize="1"><RowStyle BackColor="#F7F7DE" />
            <Columns>
                <asp:BoundField DataField="Total" HeaderText="MTP5" ReadOnly="True" SortExpression="Total" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Left" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#404040" Font-Bold="True" ForeColor="White" Font-Names="Arial" Font-Size="Small" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
     </div>
     <div class="col-md-1 col-sm-1 col-xs-12">      
        <asp:GridView ID="GridView7" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None"
            BorderWidth="1px" CellPadding="4" DataSourceID="SqlDataSource7" CssClass="dataTable table-bordered table-counter"
            GridLines="Vertical" style="margin: 10px; width: 100%;" ForeColor="Black" PageSize="1"><RowStyle BackColor="#F7F7DE" />
            <Columns>
                <asp:BoundField DataField="Total" HeaderText="MTP6" ReadOnly="True" SortExpression="Total" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Left" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#404040" Font-Bold="True" ForeColor="White" Font-Names="Arial" Font-Size="Small" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
    </div>
     <div class="col-md-1 col-sm-1 col-xs-12">      
        <asp:GridView ID="GridView8" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None"
            BorderWidth="1px" CellPadding="4" DataSourceID="SqlDataSource8" CssClass="dataTable table-bordered table-counter"
            GridLines="Vertical" style="margin: 10px; width: 100%;" ForeColor="Black" PageSize="1"><RowStyle BackColor="#F7F7DE" />
            <Columns>
                <asp:BoundField DataField="Total" HeaderText="MTP7" ReadOnly="True" SortExpression="Total" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Left" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#404040" Font-Bold="True" ForeColor="White" Font-Names="Arial" Font-Size="Small" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
    </div>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" OnPreRender="GridView1_PreRender"
        CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Vertical"
        Style="margin: 10px" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CssClass="datatable-responsive table table-striped table-bordered dt-responsive">
        <FooterStyle BackColor="#CCCC99" />
        <RowStyle BackColor="#F7F7DE" Font-Names="Arial" Font-Size="Medium" />
        <Columns>
            <asp:BoundField DataField="MSISDN" HeaderText="MSISDN" SortExpression="MSISDN" />
            <asp:BoundField DataField="CreatedTS" HeaderText="CreatedTS" SortExpression="CreatedTS" >
                            <ItemStyle Font-Size="Small" Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="MessageOut" HeaderText="MessageOut" SortExpression="MessageOut" >
                <ItemStyle Font-Size="Small" Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
            <asp:BoundField DataField="Robin" HeaderText="MT" SortExpression="Robin" />
            <asp:BoundField DataField="Retry" HeaderText="Retry" SortExpression="Retry" />
            <asp:HyperLinkField DataNavigateUrlFields="ID" DataNavigateUrlFormatString="MTPending.aspx?ID={0}&amp;action=ResentMT"
                HeaderText="Retry" Text="Retry" />            
        </Columns>
        <PagerStyle ForeColor="#333333" HorizontalAlign="Left" CssClass="GridPager" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#404040" Font-Bold="True" ForeColor="White" Font-Names="Arial" Font-Size="Small" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
        SelectCommand="SELECT Top 100 ID, MessageOut, MSISDN, CreatedTS, Retry, Status, Robin FROM TxOut WHERE (Status = @Status) order by ID Desc">
        <SelectParameters>
            <asp:Parameter DefaultValue="SUCCESS" Name="Status" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
        SelectCommand="SELECT COUNT(*) AS Total FROM TxOut WHERE (MONTH(LastUpdatedTS) = DatePart(MM, GetDate())) AND (YEAR(LastUpdatedTS) = DatePart(YY, GetDate())) AND ((Robin = '1') OR (Robin= '11'))">
        <SelectParameters>
            <asp:SessionParameter Name="agentid" SessionField="AGENT_ID" />
        </SelectParameters>
    </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
        SelectCommand="SELECT COUNT(*) AS Total FROM TxOut WHERE (MONTH(LastUpdatedTS) = DatePart(MM, GetDate())) AND (YEAR(LastUpdatedTS) = DatePart(YY, GetDate())) AND ((Robin = '2') OR (Robin= '12'))">
        <SelectParameters>
            <asp:SessionParameter Name="agentid" SessionField="AGENT_ID" />
        </SelectParameters>
    </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
        SelectCommand="SELECT COUNT(*) AS Total FROM TxOut WHERE (MONTH(LastUpdatedTS) = DatePart(MM, GetDate())) AND (YEAR(LastUpdatedTS) = DatePart(YY, GetDate())) AND ((Robin = '3') OR (Robin= '13'))">
        <SelectParameters>
           <asp:SessionParameter Name="agentid" SessionField="AGENT_ID" />
        </SelectParameters>
    </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
        SelectCommand="SELECT COUNT(*) AS Total FROM TxOut WHERE (MONTH(LastUpdatedTS) = DatePart(MM, GetDate())) AND (YEAR(LastUpdatedTS) = DatePart(YY, GetDate())) AND ((Robin = '4') OR (Robin= '14'))">
        <SelectParameters>
            <asp:SessionParameter Name="agentid" SessionField="AGENT_ID" />
        </SelectParameters>
    </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
        SelectCommand="SELECT COUNT(*) AS Total FROM TxOut WHERE (MONTH(LastUpdatedTS) = DatePart(MM, GetDate())) AND (YEAR(LastUpdatedTS) = DatePart(YY, GetDate())) AND ((Robin = '5') OR (Robin= '15'))">
        <SelectParameters>
            <asp:SessionParameter Name="agentid" SessionField="AGENT_ID" />
        </SelectParameters>
    </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
        SelectCommand="SELECT COUNT(*) AS Total FROM TxOut WHERE (MONTH(LastUpdatedTS) = DatePart(MM, GetDate())) AND (YEAR(LastUpdatedTS) = DatePart(YY, GetDate())) AND ((Robin = '6') OR (Robin= '16'))">
        <SelectParameters>
            <asp:SessionParameter Name="agentid" SessionField="AGENT_ID" />
        </SelectParameters>
    </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource8" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
        SelectCommand="SELECT COUNT(*) AS Total FROM TxOut WHERE (MONTH(LastUpdatedTS) = DatePart(MM, GetDate())) AND (YEAR(LastUpdatedTS) = DatePart(YY, GetDate())) AND ((Robin = '7') OR (Robin= '17'))">
        <SelectParameters>
            <asp:SessionParameter Name="agentid" SessionField="AGENT_ID" />
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

