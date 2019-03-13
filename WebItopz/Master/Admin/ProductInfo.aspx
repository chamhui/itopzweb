<%@ Page Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="ProductInfo.aspx.vb" Inherits="WebItopz.ProductInfo" title="ProductInfo" %>
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
<script language="javascript">
    function openPopup(strOpen)
    {
        open(strOpen, "ProductInfo", "status=1, width=650, height=650, top=100, left=150, scrollbars=yes");
    }
</script>
    <asp:Label ID="Label1" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
    <div class="page-title">
        <div class="title_left">
            <h3>Product Info</h3>
        </div>
    </div>
    <div class="x_panel">
        <div class="x_title">
        <h2>Product Info</h2>
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
        &nbsp;&nbsp;
        <asp:Label ID="lblErrorGrid" runat="server" Font-Names="Arial" Font-Size="Small" ForeColor="Red"></asp:Label>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" OnPreRender="GridView1_PreRender"
            BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="ProductID"
            DataSourceID="SqlDataSource1" Style="margin: 10px" ForeColor="Black" GridLines="Vertical" CssClass="datatable-responsive table table-striped table-bordered dt-responsive">
            <FooterStyle BackColor="#CCCC99" />
            <RowStyle BackColor="#F7F7DE" />
            <Columns>
                <asp:CommandField ShowEditButton="True" />            
                <asp:TemplateField HeaderText="ID" SortExpression="ProductID" >
                    <EditItemTemplate>
                        <asp:Label ID="lblProductID" runat="server" Text='<%# Eval("ProductID") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblProductID" runat="server" Text='<%# Bind("ProductID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Telco" HeaderText="Telco" SortExpression="Telco" />
                <asp:TemplateField HeaderText="Keyword"  SortExpression="Keyword"   >
                    <EditItemTemplate>
                        <asp:Textbox ID="tKeyword" runat="server" Text='<%# Eval("Keyword") %>'></asp:Textbox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblKeyword" runat="server" Text='<%# Bind("Keyword") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>             
                <asp:TemplateField HeaderText="Discount"  SortExpression="Discount"   >
                    <EditItemTemplate>
                        <asp:Textbox ID="tDiscount" runat="server" Text='<%# Eval("Discount") %>'></asp:Textbox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblDiscount" runat="server" Text='<%# Bind("Discount") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>             
                <asp:BoundField DataField="Cost" HeaderText="Cost" SortExpression="Cost" />
                <asp:TemplateField HeaderText="Rebate">
                    <ItemTemplate>
                    <a href="javascript:openPopup('<%# Eval("ProductID", "EditRebate.aspx?ProductID={0}") %>')">View/Edit</a>
                    </ItemTemplate>
                </asp:TemplateField>            
                <asp:BoundField DataField="Note" HeaderText="Note" SortExpression="Note">
                    <ItemStyle Font-Size="XX-Small" />
                </asp:BoundField>
                <asp:BoundField DataField="Instruction" HeaderText="Instruction" SortExpression="Instruction" >
                    <ItemStyle Font-Size="XX-Small" />
                </asp:BoundField>
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description">
                    <ItemStyle Font-Size="XX-Small" Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" >
                    <ItemStyle Font-Size="XX-Small" />
                </asp:BoundField>
            </Columns>
            <PagerStyle ForeColor="#333333" HorizontalAlign="Left" CssClass="GridPager" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#404040" Font-Bold="True" ForeColor="White" Font-Names="Arial" Font-Size="Small" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
            SelectCommand="SELECT ProductID, Telco, Description, Keyword, Instruction, Discount, Cost, Note, Status FROM ProductInfo" ConflictDetection="CompareAllValues" DeleteCommand="DELETE FROM [ProductInfo] WHERE [ProductID] = @original_ProductID AND [Telco] = @original_Telco AND [Description] = @original_Description AND [Keyword] = @original_Keyword AND [Instruction] = @original_Instruction AND [Discount] = @original_Discount AND [Cost] = @original_Cost AND [Status] = @original_Status" InsertCommand="INSERT INTO [ProductInfo] ([Telco], [Description], [Keyword], [Instruction], [Discount], [Cost], [Status]) VALUES (@Telco, @Description, @Keyword, @Instruction, @Discount, @Cost, @Status)" OldValuesParameterFormatString="original_{0}" UpdateCommand="UPDATE [ProductInfo] SET [Telco] = @Telco, [Description] = @Description, [Instruction] = @Instruction, [Cost] = @Cost, [Note]=@note, [Status] = @Status WHERE [ProductID] = @original_ProductID ">
            <DeleteParameters>
                <asp:Parameter Name="original_ProductID" Type="Int32" />
                <asp:Parameter Name="original_Telco" Type="String" />
                <asp:Parameter Name="original_Description" Type="String" />
                <asp:Parameter Name="original_Keyword" Type="String" />
                <asp:Parameter Name="original_Instruction" Type="String" />
                <asp:Parameter Name="original_Discount" Type="Decimal" />
                <asp:Parameter Name="original_Cost" Type="Decimal" />
                <asp:Parameter Name="original_Status" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="Telco" Type="String" />
                <asp:Parameter Name="Description" Type="String" />
                <asp:Parameter Name="Instruction" Type="String" />
                <asp:Parameter Name="Cost" Type="Decimal" />
                <asp:Parameter Name="note" />
                <asp:Parameter Name="Status" Type="String" />
                <asp:Parameter Name="original_ProductID" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="Telco" Type="String" />
                <asp:Parameter Name="Description" Type="String" />
                <asp:Parameter Name="Keyword" Type="String" />
                <asp:Parameter Name="Instruction" Type="String" />
                <asp:Parameter Name="Discount" Type="Decimal" />
                <asp:Parameter Name="Cost" Type="Decimal" />
                <asp:Parameter Name="Status" Type="String" />
            </InsertParameters>
        </asp:SqlDataSource>
        <br />
    </div>
    <div class="x_panel">
        <div class="x_title">
        <h2>Add New Product</h2>
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
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Telco 
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtTelco" runat="server" class="form-control col-md-7 col-xs-12" ></asp:TextBox>         
                </div>
            </div>
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Keyword 
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtKeyword" runat="server" class="form-control col-md-7 col-xs-12" ></asp:TextBox>         
                </div>
            </div>
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Discount 
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtDiscount" runat="server" class="form-control col-md-7 col-xs-12" >0.00</asp:TextBox>         
                </div>
            </div>
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Cost 
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtCost" runat="server" class="form-control col-md-7 col-xs-12" >0.00</asp:TextBox>         
                </div>
            </div>
            <div class="item form-group col-md-7 col-sm-7 col-xs-12" style="text-align:center;">
                <asp:Button ID="btnAddTelco" runat="server" cssClass="btn btn-success" Text="Add" />
                <asp:Label ID="lblErrorMsg" runat="server" Font-Names="Arial" Font-Size="Small" ForeColor="Red"></asp:Label>
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

