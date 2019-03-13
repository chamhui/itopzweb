<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="Submaster_ReloadPinManage.aspx.vb" Inherits="WebItopz.Submaster_Admin_ReloadPinManage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ReloadPinManage</title>
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
        <div class="item form-group form-horizontal col-md-6 col-sm-6 col-xs-12">
            <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Status
            </label>
            <div class="col-md-7 col-sm-7 col-xs-12">
                <asp:DropDownList ID="DDLStatus" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource3"
                    DataTextField="Status" DataValueField="Status" class="form-control col-md-7 col-xs-12" style="margin-bottom: 10px;">
                </asp:DropDownList>         
            </div>
            <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Response Status
            </label>
            <div class="col-md-7 col-sm-7 col-xs-12">
                <asp:DropDownList ID="DDLResPStatus" runat="server" DataSourceID="SqlDataSource2"
                    DataTextField="ResponseStatus" DataValueField="ResponseStatus" class="form-control col-md-7 col-xs-12">
                </asp:DropDownList>                
            </div>
        </div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" OnPreRender="GridView1_PreRender"
            AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None"
            BorderWidth="1px" CellPadding="4" DataKeyNames="ID" DataSourceID="SqlDataSource1" CssClass="datatable-responsive table table-striped table-bordered dt-responsive"
            ForeColor="Black" GridLines="Vertical" Style="margin: 10px">
            <RowStyle BackColor="#F7F7DE" Font-Names="Arial" Font-Size="Small" />
            <Columns>
                <asp:CommandField ShowEditButton="True" />
                <asp:BoundField ReadOnly="True" DataField="ReloadTelco" HeaderText="ReloadTelco" SortExpression="ReloadTelco" />                
                <asp:BoundField DataField="SerialNumber" HeaderText="SerialNumber" SortExpression="SerialNumber" />
                <asp:BoundField DataField="ReloadPin" HeaderText="ReloadPin" SortExpression="ReloadPin" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                <asp:BoundField DataField="Amount" HeaderText="Amount" SortExpression="Amount" />
                <asp:BoundField ReadOnly="True" DataField="LocalMOID" HeaderText="LocalMOID" SortExpression="LocalMOID" />
                <asp:BoundField ReadOnly="True" DataField="UpdatedTS" HeaderText="UpdatedTS" SortExpression="UpdatedTS" />
                <asp:BoundField ReadOnly="True" DataField="ResponseStatus" HeaderText="ResponseStatus" SortExpression="ResponseStatus" />
                <asp:BoundField ReadOnly="True" DataField="ResponseMsg" HeaderText="ResponseMsg" SortExpression="ResponseMsg" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <PagerStyle ForeColor="#333333" HorizontalAlign="Left" CssClass="GridPager" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#404040" Font-Bold="True" Font-Names="Arial" Font-Size="Small"
                ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues"
            ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>" DeleteCommand="DELETE FROM [ReloadPin] WHERE [ID] = @original_ID AND (([ReloadTelco] = @original_ReloadTelco) OR ([ReloadTelco] IS NULL AND @original_ReloadTelco IS NULL)) AND (([ProcessorID] = @original_ProcessorID) OR ([ProcessorID] IS NULL AND @original_ProcessorID IS NULL)) AND (([SerialNumber] = @original_SerialNumber) OR ([SerialNumber] IS NULL AND @original_SerialNumber IS NULL)) AND (([ExpiryDate] = @original_ExpiryDate) OR ([ExpiryDate] IS NULL AND @original_ExpiryDate IS NULL)) AND (([LocalMOID] = @original_LocalMOID) OR ([LocalMOID] IS NULL AND @original_LocalMOID IS NULL)) AND (([Status] = @original_Status) OR ([Status] IS NULL AND @original_Status IS NULL)) AND (([Amount] = @original_Amount) OR ([Amount] IS NULL AND @original_Amount IS NULL)) AND (([ReloadPin] = @original_ReloadPin) OR ([ReloadPin] IS NULL AND @original_ReloadPin IS NULL)) AND (([UpdatedTS] = @original_UpdatedTS) OR ([UpdatedTS] IS NULL AND @original_UpdatedTS IS NULL)) AND (([ResponseMsg] = @original_ResponseMsg) OR ([ResponseMsg] IS NULL AND @original_ResponseMsg IS NULL)) AND (([ResponseStatus] = @original_ResponseStatus) OR ([ResponseStatus] IS NULL AND @original_ResponseStatus IS NULL))"
            InsertCommand="INSERT INTO [ReloadPin] ([ReloadTelco], [ProcessorID], [SerialNumber], [ExpiryDate], [LocalMOID], [Status], [Amount], [ReloadPin], [UpdatedTS], [ResponseMsg], [ResponseStatus]) VALUES (@ReloadTelco, @ProcessorID, @SerialNumber, @ExpiryDate, @LocalMOID, @Status, @Amount, @ReloadPin, @UpdatedTS, @ResponseMsg, @ResponseStatus)"
            OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT ReloadTelco, ProcessorID, SerialNumber, ExpiryDate, LocalMOID, Status, Amount, ID, ReloadPin, UpdatedTS, ResponseMsg, ResponseStatus FROM ReloadPin WHERE (ResponseStatus = @ResponseStatus) AND (Status = @Status) AND (BatchStatus = 'ACTIVE') ORDER BY UpdatedTS DESC"
            UpdateCommand="UPDATE [ReloadPin] SET [SerialNumber] = @SerialNumber, [Status] = @Status, [Amount] = @Amount, [ReloadPin] = @ReloadPin, [ResponseMsg] ='', [ResponseStatus] = 'NEW' WHERE [ID] = @original_ID  ">
            <SelectParameters>
                <asp:ControlParameter ControlID="DDLResPStatus" Name="ResponseStatus" PropertyName="SelectedValue"
                    Type="String" />
                <asp:ControlParameter ControlID="DDLStatus" Name="Status" PropertyName="SelectedValue"
                    Type="String" />
            </SelectParameters>
            <DeleteParameters>
                <asp:Parameter Name="original_ID" Type="Int64" />
                <asp:Parameter Name="original_ReloadTelco" Type="String" />
                <asp:Parameter Name="original_ProcessorID" Type="String" />
                <asp:Parameter Name="original_SerialNumber" Type="String" />
                <asp:Parameter Name="original_ExpiryDate" Type="String" />
                <asp:Parameter Name="original_LocalMOID" Type="String" />
                <asp:Parameter Name="original_Status" Type="String" />
                <asp:Parameter Name="original_Amount" Type="String" />
                <asp:Parameter Name="original_ReloadPin" Type="String" />               
                <asp:Parameter Name="original_UpdatedTS" />
                <asp:Parameter Name="original_ResponseMsg" Type="String" />
                <asp:Parameter Name="original_ResponseStatus" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="SerialNumber" Type="String" />
                <asp:Parameter Name="Status" Type="String" />
                <asp:Parameter Name="Amount" Type="String" />
                <asp:Parameter Name="ReloadPin" Type="String" />
                <asp:Parameter Name="original_ID" Type="Int64" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="ReloadTelco" Type="String" />
                <asp:Parameter Name="ProcessorID" Type="String" />
                <asp:Parameter Name="SerialNumber" Type="String" />
                <asp:Parameter Name="ExpiryDate" Type="String" />
                <asp:Parameter Name="LocalMOID" Type="String" />
                <asp:Parameter Name="Status" Type="String" />
                <asp:Parameter Name="Amount" Type="String" />
                <asp:Parameter Name="ReloadPin" Type="String" /> 
                <asp:Parameter Name="UpdatedTS" />
                <asp:Parameter Name="ResponseMsg" Type="String" />
                <asp:Parameter Name="ResponseStatus" Type="String" />
            </InsertParameters>
        </asp:SqlDataSource>
    
    </div>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
            SelectCommand="SELECT [ResponseStatus] FROM [ReloadPin] WHERE ResponseStatus <>'' AND STATUS=@STATUS&#13;&#10;group by [ResponseStatus] ">
            <SelectParameters>
                <asp:ControlParameter ControlID="DDLStatus" Name="STATUS" PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
            SelectCommand="SELECT [Status] FROM [ReloadPin] Group By Status"></asp:SqlDataSource>
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
