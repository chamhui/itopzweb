<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="EditRebate.aspx.vb" Inherits="WebItopz.EditRebate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Product Rebate</title>
	<link href="~/Theme/css/bootstrap.min.css" rel="stylesheet" />

	<link href="~/Theme/fonts/css/font-awesome.min.css" rel="stylesheet" />
	<link href="~/Theme/css/animate.min.css" rel="stylesheet" />
	<link href="~/build/css/custom.min.css" rel="stylesheet" />
	<!--[if lt IE 9]>
		<script src="../assets/js/ie8-responsive-file-warning.js"></script>
	<![endif]-->

	<!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
	<!--[if lt IE 9]>
		<script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
		<script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
	<![endif]-->

	<!-- jQuery -->
    <script src="/Theme/jquery/dist/jquery.min.js"></script>
    <!-- <script src="../Scripts/jquery-1.10.2.js" type="text/javascript"></script> -->
	<!-- Bootstrap -->
	<script src="/Theme/bootstrap/dist/js/bootstrap.min.js"></script>
	<!-- FastClick -->
	<script src="/Theme/fastclick/lib/fastclick.js"></script>
	<!-- NProgress -->
	<script src="/Theme/nprogress/nprogress.js"></script>
	<!-- Dropzone.js -->
	<script src="/Theme/dropzone/dist/min/dropzone.min.js"></script>

	<style>
		.panel_toolbox{
			display:none;
		}
		.input-group{
			display:none;
		}
        .dataTables_wrapper .col-sm-12 {
            width: 100%;
        }
	</style>
        <!-- NProgress -->
    <link href="/Theme/nprogress/nprogress.css" rel="stylesheet" />

    <!-- Datatables -->
    <link href="/Theme/datatables.net-bs/css/dataTables.bootstrap.min.css" rel="stylesheet" />
    <link href="/Theme/datatables.net-buttons-bs/css/buttons.bootstrap.min.css" rel="stylesheet" />
    <link href="/Theme/datatables.net-fixedheader-bs/css/fixedHeader.bootstrap.min.css" rel="stylesheet" />
    <link href="/Theme/datatables.net-responsive-bs/css/responsive.bootstrap.min.css" rel="stylesheet" />
    <link href="/Theme/datatables.net-scroller-bs/css/scroller.bootstrap.min.css" rel="stylesheet" />
</head>
<body style="background: none;">
    <form id="form1" runat="server">
    <div style="margin: 10px;">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="RebateID" OnPreRender="GridView1_PreRender" 
            DataSourceID="SqlDataSource1" style="width: 100%;" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" ForeColor="Black" GridLines="Vertical" Height="1px" CssClass="table table-striped table-bordered dt-responsive">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="Telco" HeaderText="Telco" ReadOnly="True" SortExpression="Telco" />                
                <asp:TemplateField HeaderText="RebateID" SortExpression="RebateID" Visible="False" >
                    <EditItemTemplate>
                        <asp:Label ID="lblRebateID" runat="server" Text='<%# Eval("RebateID") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblRebateID" runat="server" Text='<%# Bind("RebateID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Denomination"  SortExpression="Denomination"   >
                    <EditItemTemplate>
                        <asp:Textbox ID="txtDenomination" runat="server" Text='<%# Eval("Denomination") %>'></asp:Textbox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblDenomination" runat="server" Text='<%# Bind("Denomination") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Rebate%"  SortExpression="Rebate"   >
                    <EditItemTemplate>
                        <asp:Textbox ID="txtRebate" runat="server" Text='<%# Eval("Rebate") %>'></asp:Textbox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblRebate" runat="server" Text='<%# Bind("Rebate") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>     
							 <asp:TemplateField HeaderText="Face Value"  SortExpression="P_FaceValue"   >
                    <EditItemTemplate>
                        <asp:Textbox ID="txtP_FaceValue" runat="server" Text='<%# Eval("P_FaceValue") %>'></asp:Textbox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblP_FaceValue" runat="server" Text='<%# Bind("P_FaceValue") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>     
                <asp:BoundField DataField="CreatedTS" HeaderText="CreatedTS" ReadOnly="True" visible="false" SortExpression="CreatedTS">
                    <ItemStyle Wrap="False" />
                </asp:BoundField>
            </Columns>
            <RowStyle BackColor="#F7F7DE" />
            <FooterStyle BackColor="#CCCC99" />
            <PagerStyle ForeColor="#333333" HorizontalAlign="Left" CssClass="GridPager" />
            <EmptyDataTemplate>
                No record found.
            </EmptyDataTemplate>
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <br />
        <br />
        <div class="x_panel">
            <div class="x_title">
            <h2>Add New Rebate</h2>
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
            <div class="item form-group form-horizontal col-md-4 col-sm-4 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Denomination
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox  runat="server" id="txtDenomination" class="form-control col-md-7 col-xs-12" style="margin-bottom: 10px;" type="text"></asp:TextBox>                      
                </div>
                <div class="col-md-3 col-sm-3 col-xs-12">
                    <span>ie: 3-5</span>
                </div>
                <asp:Label ID="lblErrorAgentid" runat="server" Font-Names="Arial" Font-Size="Small"></asp:Label>
            </div>
            <div class="item form-group form-horizontal col-md-4 col-sm-4 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Rebate %
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox  runat="server" id="txtRebate" class="form-control col-md-7 col-xs-12" style="margin-bottom: 10px;" type="text"></asp:TextBox>                      
                </div>
                <div class="col-md-3 col-sm-3 col-xs-12">
                    <span>ie: 0.25</span>
                </div>
                <asp:Label ID="Label1" runat="server" Font-Names="Arial" Font-Size="Small"></asp:Label>
            </div>

					 <div class="item form-group form-horizontal col-md-4 col-sm-4 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Face Value
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox  runat="server" id="txtP_FaceValue" class="form-control col-md-7 col-xs-12" style="margin-bottom: 10px;" type="text"></asp:TextBox>                      
                </div>
                <div class="col-md-3 col-sm-3 col-xs-12">
                    <span>ie: 30</span>
                </div>
                <asp:Label ID="Label6" runat="server" Font-Names="Arial" Font-Size="Small"></asp:Label>
            </div>

            <div class="item form-group form-horizontal col-md-4 col-sm-4 col-xs-12">
                <div class="col-md-9 col-sm-9 col-xs-12">
                    <asp:Button ID="btnAddRebate" runat="server" class="btn btn-success" Text="Add" />
                    <asp:Label ID="lblErrorMsg" runat="server" Font-Names="Arial" Font-Size="Small" ForeColor="Red"></asp:Label>
                </div>
            </div>
        </div>

       <div class="x_panel">
            <div class="x_title">
            <h2>Edit Dealer Downline Rebate</h2>
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
            <div class="item form-group form-horizontal col-md-4 col-sm-4 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Dealer ID
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:DropDownList ID="DDLParentAgentID" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource2"
                        DataTextField="Name" DataValueField="AgentID" class="form-control col-md-7 col-xs-12" >
                    </asp:DropDownList>
                </div>
                <div class="col-md-3 col-sm-3 col-xs-12">
                    <span>ie: 3-5</span>
                </div>
                <asp:Label ID="Label5" runat="server" Font-Names="Arial" Font-Size="Small"></asp:Label>
            </div>
            <div class="item form-group form-horizontal col-md-4 col-sm-4 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Denomination
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:DropDownList ID="DDLDenomination" runat="server" DataSourceID="SqlDataSource3"
                        DataTextField="Denomination" DataValueField="Denomination" class="form-control col-md-7 col-xs-12">
                    </asp:DropDownList>                
                </div>
                <asp:Label ID="Label2" runat="server" Font-Names="Arial" Font-Size="Small"></asp:Label>
            </div>
            <div class="item form-group form-horizontal col-md-4 col-sm-4 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Rebate %
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox  runat="server" id="DDLRebate" class="form-control col-md-7 col-xs-12" style="margin-bottom: 10px;" type="text"></asp:TextBox>                      
                </div>
                <div class="col-md-3 col-sm-3 col-xs-12">
                    <span>ie: 0.25</span>
                </div>
                <asp:Label ID="Label3" runat="server" Font-Names="Arial" Font-Size="Small"></asp:Label>
            </div>

            <div class="item form-group form-horizontal col-md-4 col-sm-4 col-xs-12">
                <div class="col-md-9 col-sm-9 col-xs-12">
                    <asp:Button ID="btnEditRebate" runat="server" class="btn btn-success" Text="Apply" />
                    <asp:Label ID="lblErrorMsg2" runat="server" Font-Names="Arial" Font-Size="Small" ForeColor="Red"></asp:Label>
                </div>
            </div>
        </div>
 
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues"
            ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>" DeleteCommand="DELETE FROM [ProductRebate] WHERE [RebateID] = @original_RebateID "
            OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT ProductInfo.Telco, ProductRebate.ProductID, ProductRebate.Denomination, ProductRebate.Rebate, ProductRebate.CreatedTS, ProductRebate.RebateID, ProductRebate.P_FaceValue FROM ProductInfo INNER JOIN ProductRebate ON ProductInfo.ProductID = ProductRebate.ProductID WHERE (ProductInfo.ProductID = @ProductID)"
            UpdateCommand="UPDATE ProductRebate SET CreatedTS = GETDATE() WHERE (RebateID = @original_RebateID)">
            <DeleteParameters>
                <asp:Parameter Name="original_RebateID" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="original_RebateID" />
            </UpdateParameters>
            <SelectParameters>
                <asp:QueryStringParameter Name="ProductID" QueryStringField="ProductID" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
        SelectCommand="SELECT CONVERT (varchar(10), AgentID) + ' ' + Name AS Name, AgentID FROM AgentInfo WHERE (ParentAgentID = '0')">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
        SelectCommand="SELECT Denomination FROM ProductRebate where productid = @ProductID">
                    <SelectParameters>
                <asp:QueryStringParameter Name="ProductID" QueryStringField="ProductID" />
            </SelectParameters>
    </asp:SqlDataSource>
    </div>
    </form>
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
</body>
</html>
