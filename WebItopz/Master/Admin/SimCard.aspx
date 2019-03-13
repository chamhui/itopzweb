<%@ Page Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="SimCard.aspx.vb" Inherits="WebItopz.SimCard" title="SimCard" %>
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
    <asp:Label ID="Label1" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
    <div class="page-title">
        <div class="title_left">
            <h3>Sim Card</h3>
        </div>
    </div>
    <div class="x_panel">
        <div class="x_title">
        <h2>Sim Card</h2>
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
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" OnPreRender="GridView1_PreRender"
        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="SIMCardID"
        DataSourceID="SqlDataSource1" Style="margin: 10px" ForeColor="Black" GridLines="Vertical" CssClass="datatable-responsive table table-striped table-bordered dt-responsive">
        <FooterStyle BackColor="#CCCC99" />
        <RowStyle BackColor="#F7F7DE" />
        <Columns>
            <asp:CommandField ShowEditButton="True" />
            <asp:BoundField DataField="SIMCardID" HeaderText="SIMCardID" SortExpression="SIMCardID" />
            <asp:BoundField DataField="Telco" HeaderText="Telco" SortExpression="Telco" />
            <asp:BoundField DataField="Balance" HeaderText="Balance" SortExpression="Balance" />
            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
        </Columns>
        <PagerStyle ForeColor="#333333" HorizontalAlign="Left" CssClass="GridPager" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#404040" Font-Bold="True" ForeColor="White" Font-Names="Arial" Font-Size="Small" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
        SelectCommand="SELECT [SIMCardID], [Telco], [Balance], [Status] FROM [SIMCard] order by Telco Asc" ConflictDetection="CompareAllValues" DeleteCommand="DELETE FROM [SIMCard] WHERE [SIMCardID] = @original_SIMCardID AND [Telco] = @original_Telco AND [Balance] = @original_Balance AND [Status] = @original_Status" InsertCommand="INSERT INTO [SIMCard] ([SIMCardID], [Telco], [Balance], [Status]) VALUES (@SIMCardID, @Telco, @Balance, @Status)" OldValuesParameterFormatString="original_{0}" UpdateCommand="UPDATE [SIMCard] SET [SIMCardID] = @SIMCardID, [Telco] = @Telco, [Balance] = @Balance, [Status] = @Status WHERE [SIMCardID] = @original_SIMCardID AND [Telco] = @original_Telco AND [Balance] = @original_Balance AND [Status] = @original_Status">
        <DeleteParameters>
            <asp:Parameter Name="original_SIMCardID" Type="String" />
            <asp:Parameter Name="original_Telco" Type="String" />
            <asp:Parameter Name="original_Balance" Type="Decimal" />
            <asp:Parameter Name="original_Status" Type="String" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="SIMCardID" />
            <asp:Parameter Name="Telco" Type="String" />
            <asp:Parameter Name="Balance" Type="Decimal" />
            <asp:Parameter Name="Status" Type="String" />
            <asp:Parameter Name="original_SIMCardID" Type="String" />
            <asp:Parameter Name="original_Telco" Type="String" />
            <asp:Parameter Name="original_Balance" Type="Decimal" />
            <asp:Parameter Name="original_Status" Type="String" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="SIMCardID" Type="String" />
            <asp:Parameter Name="Telco" Type="String" />
            <asp:Parameter Name="Balance" Type="Decimal" />
            <asp:Parameter Name="Status" Type="String" />
        </InsertParameters>
    </asp:SqlDataSource>
    <br />
    </div>
    <div class="x_panel">
        <div class="x_title">
        <h2>Top Up SIM Credit</h2>
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
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">SIM MSISDN 
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtSIMCardId" runat="server" CssClass="form-control col-md-7 col-xs-12" ></asp:TextBox>         
                </div>
            </div>
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Amount 
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control col-md-7 col-xs-12" ></asp:TextBox>         
                </div>
            </div>
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Balance 
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:Label ID="lblBalance" runat="server" CssClass="form-control col-md-7 col-xs-12" Style="border: 0; box-shadow: none;" ></asp:Label>         
                </div>
            </div>
            <div class="item form-group col-md-7 col-sm-7 col-xs-12" style="text-align:center;">
                <asp:Button ID="btnSubmit" runat="server" class="btn btn-success" Text="TopUp" />
                <asp:Button ID="btnConfirm" runat="server" class="btn btn-success" Text="Confirm" Visible="False" />
                <asp:Button ID="btnCancel" runat="server" class="btn btn-primary" Text="Cancel" Visible="False" />
                <asp:Label ID="lblErrorMsg" runat="server" Font-Names="Arial" Font-Size="Small" ForeColor="Red"></asp:Label>
            </div>
        </div>
    </div>

    <div class="x_panel">
        <div class="x_title">
        <h2>Add New SIM Card ID</h2>
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
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">SIM MSISDN 
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtSIMMSISDN" runat="server" class="form-control col-md-7 col-xs-12" ></asp:TextBox>         
                </div>
            </div>
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">SIM Telco 
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:DropDownList ID="DDLTelco" class="form-control col-md-12 col-xs-12" runat="server">
                        <asp:ListItem>SINGTEL</asp:ListItem>
                        <asp:ListItem>M1</asp:ListItem>
                        <asp:ListItem>STARHUB</asp:ListItem>                    
                    </asp:DropDownList>         
                </div>
            </div>

            <div class="item form-group col-md-7 col-sm-7 col-xs-12" style="text-align:center;">
                <asp:Button ID="btnAddTelco" runat="server" class="btn btn-success" Text="AddTelco" />
                <asp:Label ID="lblErrorSIM" runat="server" Font-Names="Arial" Font-Size="Small" ForeColor="Red"></asp:Label>
            </div>
        </div>
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

