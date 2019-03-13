<%@ Page Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="UpkeepTx.aspx.vb" Inherits="WebItopz.Admin_UpkeepTx" title="UpkeepTx"%>
<%--<%@ Page Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="NoDN.aspx.vb" Inherits="WebItopz.Admin_NoDN" title="NoDN" %>--%>

<asp:Content ID="Header" ContentPlaceHolderID="MainHeader" runat="server">
     <header>
         <link rel="stylesheet" href="http://code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css" />

              <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
        <script>
            $(function () {

                $(".purup").datepicker();


            })</script>
    </header>
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
    x`<asp:Label ID="lblErrorMsg" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
    <div class="page-title">
        <div class="title_left">
            <h3>UpkeepTx</h3>
        </div>
    </div>
    <div class="x_panel">
        <div class="x_title">
        <h2>UpkeepTx</h2>
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
        <div class="form-horizontal form-label-left" > <asp:HiddenField ID="hiddenid" runat="server" />                  
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Starhub 
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="Starhub" runat="server" class="form-control col-md-7 col-xs-12" >0</asp:TextBox>         
                </div>
            </div>
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">M1 
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="M1" runat="server" class="form-control col-md-7 col-xs-12" >0</asp:TextBox>
                </div>
  
            </div>
                        <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">M5
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="M5" runat="server" class="form-control col-md-7 col-xs-12" >0</asp:TextBox>
                </div>
  
            </div>
                        <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">M18 
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="M18" runat="server" class="form-control col-md-7 col-xs-12" >0</asp:TextBox>
                </div>
  
            </div>
                        <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">M28
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="M28" runat="server" class="form-control col-md-7 col-xs-12" >0</asp:TextBox>
                </div>
  
            </div>
                        <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Singtel 
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="Singtel" runat="server" class="form-control col-md-7 col-xs-12" >0</asp:TextBox>
                </div>
  
            </div>

                              <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Transaction Date 
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtpu" runat="server" class="form-control col-md-7 col-xs-12 purup" ></asp:TextBox>
                </div>
  
            </div>

            <div class="item form-group col-md-7 col-sm-7 col-xs-12" style="text-align:center;">
                <asp:Button ID="btnSubmit" runat="server" cssClass="btn btn-success" Text="Submit" />
                <asp:Label ID="Label1" runat="server" Font-Names="Arial" Font-Size="Small" ForeColor="Red"></asp:Label>
            </div>
        </div>
        <updatepanel>
   <asp:GridView ID="GridView1" runat="server" AllowPaging="True" DataKeyNames="UpkeepTX_ID"  AutoGenerateColumns="False" OnPreRender="GridView1_PreRender"
        CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Vertical" 
        Style="margin: 10px" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CssClass="datatable-responsive table table-striped table-bordered dt-responsive nowrap">
        <FooterStyle BackColor="#CCCC99" />
        <RowStyle BackColor="#F7F7DE" Font-Names="Arial" Font-Size="Medium" />
        <Columns>
            <asp:CommandField ShowEditButton="True" />
            <asp:BoundField DataField="UpkeepTX_ID" HeaderText="UpkeepTX_ID" InsertVisible="false" ReadOnly="true" SortExpression="UpkeepTX_ID" />
            <asp:BoundField DataField="Starhub" HeaderText="Starhub" SortExpression="Starhub" />
            <asp:BoundField DataField="M1" HeaderText="M1" SortExpression="M1" />
            <asp:BoundField DataField="M5" HeaderText="M5" SortExpression="M5" />
            <asp:BoundField DataField="M18" HeaderText="M18" SortExpression="M18" /> 
            <asp:BoundField DataField="M28" HeaderText="M28" SortExpression="M28" />
            <asp:BoundField DataField="Singtel" HeaderText="Singtel" SortExpression="Singtel" />
            <asp:BoundField DataField="TotalAmount" HeaderText="TotalAmount" SortExpression="TotalAmount" />
            <asp:BoundField DataField="UpkeepTX_Date" HeaderText="UpkeepTX_Date" SortExpression="UpkeepTX_Date">
                  <ItemStyle Wrap="False" />
            </asp:BoundField>
                    

        </Columns>
        <PagerStyle ForeColor="#333333" HorizontalAlign="Left" CssClass="GridPager" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#404040" Font-Bold="True" ForeColor="White" Font-Names="Arial" Font-Size="Small" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
            </updatepanel>


    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
        SelectCommand="SELECT * FROM UpkeepTx"
        OldValuesParameterFormatString="original_{0}"
        UpdateCommand="UPDATE [UpkeepTx] SET [Starhub] = @Starhub, [M1] = @M1, [M5] = @M5, [M18] = @M18, [M28] = @M28, [Singtel] = @Singtel, [TotalAmount] = @Starhub + @M1 + @M5 + @M18 + @M28 + @Singtel WHERE [UpkeepTX_ID] = @UpkeepTX_ID">
       
<%--        <DeleteParameters>
                <asp:Parameter Name="Starhub" Type="Int32" />
                <asp:Parameter Name="M1" Type="Int32" />
                <asp:Parameter Name="M5" Type="Int32" />
                <asp:Parameter Name="M18" Type="Int32" />
                <asp:Parameter Name="M24" Type="Int32" />
                <asp:Parameter Name="Singtel" Type="Int32" />  
                <asp:Parameter Name="UpkeepTX_ID" Type="Int32" />
                <asp:Parameter Name="original_UpkeepTX_ID" Type="Int32" />
                <asp:Parameter Name="original_Starhub" Type="Int32" />
                <asp:Parameter Name="original_M1" Type="Int32" />
                <asp:Parameter Name="original_M5" Type="Int32" />
                <asp:Parameter Name="original_M18" Type="Int32" />
                <asp:Parameter Name="original_M24" Type="Int32" />
                <asp:Parameter Name="original_Singtel" Type="Int32" />
         </DeleteParameters>--%>

         <UpdateParameters>
                <asp:Parameter Name="Starhub" Type="Int32" />
                <asp:Parameter Name="M1" Type="Int32" />
                <asp:Parameter Name="M5" Type="Int32" />
                <asp:Parameter Name="M18" Type="Int32" />
                <asp:Parameter Name="M24" Type="Int32" />
                <asp:Parameter Name="Singtel" Type="Int32" />
                <asp:Parameter Name="TotalAmount" Type="Int32" />
             

             
              <asp:Parameter Name="UpkeepTX_ID" Type="Int32" />
                <asp:Parameter Name="original_UpkeepTX_ID" Type="Int32" />

                <asp:Parameter Name="original_Starhub" Type="Int32" />
                <asp:Parameter Name="original_M1" Type="Int32" />
                <asp:Parameter Name="original_M5" Type="Int32" />
                <asp:Parameter Name="original_M18" Type="Int32" />
                <asp:Parameter Name="original_M24" Type="Int32" />
                <asp:Parameter Name="original_Singtel" Type="Int32" />
                <asp:Parameter Name="original_TotalAmount" Type="Int32" />

                

                

            </UpdateParameters>
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
         $(document).ready(function () {
             var handleDataTableButtons = function () {
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

             TableManageButtons = function () {
                 "use strict";
                 return {
                     init: function () {
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
                 'order': [[1, 'asc']],
                 'columnDefs': [
                     { orderable: false, targets: [0] }
                 ]
             });
             $datatable.on('draw.dt', function () {
                 $('input').iCheck({
                     checkboxClass: 'icheckbox_flat-green'
                 });
             });

             TableManageButtons.init();
         });
    </script> 
</asp:Content>

