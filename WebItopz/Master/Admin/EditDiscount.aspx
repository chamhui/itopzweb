<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="EditDiscount.aspx.vb" Inherits="WebItopz.EditDiscount" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Agent Product Discount</title>
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
<script language="javascript">
    function openPopup(strOpen)
    {
        open(strOpen, "AgentProductRebate", "status=1, width=650, height=650, top=100, left=150, scrollbars=yes");
    }
</script>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
            DataSourceID="SqlDataSource1" OnPreRender="GridView1_PreRender" CssClass="datatable-responsive table table-striped table-bordered dt-responsive">
            <Columns>
                <asp:CommandField ShowEditButton="True" />
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                    SortExpression="ID" Visible="False" />
                <asp:BoundField DataField="AgentID" ReadOnly="True" HeaderText="AgentID" SortExpression="AgentID" />
                <asp:BoundField DataField="Telco" ReadOnly="True" HeaderText="Telco" SortExpression="Telco" />
                <asp:TemplateField HeaderText="Discount %" SortExpression="Discount">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Discount") %>' Width="65px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                            ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                        <br />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1"
                            ErrorMessage="RegularExpressionValidator" Font-Size="XX-Small" ValidationExpression="^-?\d+(\.\d{2})?$">Must Be Number! ie: 2.00</asp:RegularExpressionValidator>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Discount") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="100px" Wrap="False" />
                    <HeaderStyle Wrap="False" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Rebate">
                    <ItemTemplate>
                    <a href="javascript:openPopup('<%# Eval("ProductID", "EditAgentRebate.aspx?ProductID={0}&") %>AgentID=<%# Eval("AgentID") %>')">View/Edit</a>
                    </ItemTemplate>
                </asp:TemplateField>                  
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" >
                    <ItemStyle Width="10px" Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="ProductID" HeaderText="ProductID" SortExpression="ProductID"
                    Visible="False" />
            </Columns>
            <PagerStyle ForeColor="#333333" HorizontalAlign="Left" CssClass="GridPager" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues"
            ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>" DeleteCommand="DELETE FROM [AgentProduct] WHERE [ID] = @original_ID AND (([AgentID] = @original_AgentID) OR ([AgentID] IS NULL AND @original_AgentID IS NULL)) AND (([ProductID] = @original_ProductID) OR ([ProductID] IS NULL AND @original_ProductID IS NULL)) AND (([Discount] = @original_Discount) OR ([Discount] IS NULL AND @original_Discount IS NULL)) AND (([Status] = @original_Status) OR ([Status] IS NULL AND @original_Status IS NULL))"
            InsertCommand="INSERT INTO [AgentProduct] ([AgentID], [ProductID], [Discount], [Status]) VALUES (@AgentID, @ProductID, @Discount, @Status)"
            OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT AgentProduct.ID, AgentProduct.AgentID, ProductInfo.Telco, AgentProduct.Discount, AgentProduct.Status, AgentProduct.ProductID FROM AgentProduct INNER JOIN ProductInfo ON AgentProduct.ProductID = ProductInfo.ProductID WHERE (AgentProduct.AgentID = @AgentID)Order By Productinfo.ProductID "
            UpdateCommand="UPDATE [AgentProduct] SET  [Discount] = @Discount, [Status] = @Status WHERE [ID] = @original_ID  ">
            <SelectParameters>
                <asp:QueryStringParameter Name="AgentID" QueryStringField="AGENTID" Type="Int32" />
            </SelectParameters>
            <DeleteParameters>
                <asp:Parameter Name="original_ID" Type="Int32" />
                <asp:Parameter Name="original_AgentID" Type="Int32" />
                <asp:Parameter Name="original_ProductID" Type="String" />
                <asp:Parameter Name="original_Discount" Type="Decimal" />
                <asp:Parameter Name="original_Status" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="Discount" Type="Decimal" />
                <asp:Parameter Name="Status" Type="String" />
                <asp:Parameter Name="original_ID" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="AgentID" Type="Int32" />
                <asp:Parameter Name="ProductID" Type="String" />
                <asp:Parameter Name="Discount" Type="Decimal" />
                <asp:Parameter Name="Status" Type="String" />
            </InsertParameters>
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
