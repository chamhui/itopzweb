<%@ Page Title="UpkeepTx2" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="UpkeepTx2.aspx.vb" Inherits="WebItopz.UpkeepTx2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <header>

         <link rel="stylesheet" href="http://code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css" />
               <!-- NProgress -->
    <link href="/Theme/nprogress/nprogress.css" rel="stylesheet" />

    <!-- Datatables -->
    <link href="/Theme/datatables.net-bs/css/dataTables.bootstrap.min.css" rel="stylesheet" />
    <link href="/Theme/datatables.net-buttons-bs/css/buttons.bootstrap.min.css" rel="stylesheet" />
    <link href="/Theme/datatables.net-fixedheader-bs/css/fixedHeader.bootstrap.min.css" rel="stylesheet" />
    <link href="/Theme/datatables.net-responsive-bs/css/responsive.bootstrap.min.css" rel="stylesheet" />
    <link href="/Theme/datatables.net-scroller-bs/css/scroller.bootstrap.min.css" rel="stylesheet" />

              <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
        <script>
            $(function () {

                $(".tradate").datepicker();

                $(".CD").datepicker();

            })</script>

    </header>
    <span style="text-decoration: underline"></span>
    <div class="page-title">
        <div class="title_left">
            <h3>Upkeep Transaction Form</h3>
        </div>
    </div>
    <div class="x_panel">
        <div class="x_title">
        <h2>Upkeep Transaction Form</h2>
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
       
         <asp:Label ID="lblErrorMsg" runat="server" Font-Names="Arial" Font-Size="Small" ForeColor="Red"></asp:Label>

    <br />
          <table id="datatable-buttons" class="table table-striped table-bordered">
                      <thead>
                        <tr>
                          <th>Record Date</th>
                            
                            <th>Starhub Phone</th>
                          <th>Starhub</th>
                          <th>M1 Phone</th>
                          <th>M1</th>
                          <th>M5</th>
                          <th>M18</th>
                          <th>M28</th>
                            <th>Singtel Phone</th>
                              <th>	5	</th>
<th>10</th>
<th>20</th>
<th>50</th>
<th>Bonue $30</th>
<th>Hot $55</th>
<th>Hot $128</th>
<th>REDHot $30</th>
<th>Local Saver $18</th>
<th>China 888</th>
<th>1GB</th>
<th>1.5GB</th>
<th>1GB</th>
<th>1.5GB</th>
<th>3GB</th>
<th>4GB</th>
<th>5GB</th>
                            <th>Edit</th>
                        </tr>
                      </thead>


                      <tbody>
              <asp:Repeater ID="rptrUpkeepTx" runat="server">
                  <ItemTemplate>
                  <tr>
                            <td><%# Eval("UpkeepTX_Date", "{0:d}") %></td>
                          <td><%# Eval("Starhub_No") %></td>
                          <td><%# Eval("Starhub") %></td>
                          <td><%# Eval("M1_No") %></td>
                          <td><%# Eval("M1") %></td>
                          <td><%# Eval("M5") %></td>
                       <td><%# Eval("M18") %></td>
                       <td><%# Eval("M28") %></td>
                       <td><%# Eval("Singtel_No") %></td>
                              <td><%# Eval("Singtel5") %></td>
                            <td><%# Eval("Singtel10") %></td>
                      <td><%# Eval("Singtel20") %></td>
                      <td><%# Eval("Singtel50") %></td>
                      <td><%# Eval("Singtel16") %></td>
                            <td><%# Eval("Singtel15") %></td>
                            <td><%# Eval("Singtel28") %></td>
                            <td><%# Eval("Singtel300") %></td>
                            <td><%# Eval("Singtel180") %></td>
                      <td><%# Eval("Singtel888") %></td>
                            <td><%# Eval("Singtel102") %></td>
                            <td><%# Eval("Singtel1015") %></td>
                            <td><%# Eval("Singtel118") %></td>
                      <td><%# Eval("Singtel1315") %></td>
                      <td><%# Eval("Singtel119") %></td>
                        <td><%# Eval("Singtel2504") %></td>
                      <td><%# Eval("Singtel120") %></td>
                      <td><a href="UpkeepTxEdit.aspx?UpkeepTx_ID=<%# Eval("UpkeepTx_ID") %>">Edit</a></td>
                        </tr>
            
                      </ItemTemplate>
              </asp:Repeater>        
                             </tbody>
                    </table>
  
   
   
      <%--     <div id="gridupkeep" runat="server">
         <asp:GridView ID="gvUpkeep" runat="server" AutoGenerateColumns ="False" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="UpkeepTx_ID" HeaderText="UpkeepTx_ID" />

            <asp:BoundField DataField="Starhub" HeaderText="Starhub" />
            <asp:BoundField DataField="M1" HeaderText="M1" />
            <asp:BoundField DataField="M5" HeaderText="M5" />
            <asp:BoundField DataField="M18" HeaderText="M18" />
            <asp:BoundField DataField="M28" HeaderText="M28" />
            <asp:BoundField DataField="Singtel" HeaderText="Singtel" />
            <asp:BoundField DataField="TotalAmount" HeaderText="TotalAmount" />
            <asp:BoundField DataField="UpkeepTX_Date" HeaderText="UpkeepTX_Date" />
            <asp:BoundField DataField="UpkeepTX_Update" HeaderText="UpkeepTX_Update" />


            <asp:TemplateField>
                <ItemTemplate>
                <asp:LinkButton ID="linkView" runat="server" CommandArgument='<%# Eval("UpkeepTx_ID") %>' OnClick ="lnk_onClick">View</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
 

        </Columns>
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />
    </asp:GridView>

            </div>--%>
        </div>
      </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphfooter" Runat="Server">
     <script src="../../theme/datatables.net/js/jquery.dataTables.min.js"></script>
    <script src="../../theme/datatables.net-bs/js/dataTables.bootstrap.min.js"></script>
    <script src="../../theme/datatables.net-buttons/js/dataTables.buttons.min.js"></script>
    <script src="../../theme/datatables.net-buttons-bs/js/buttons.bootstrap.min.js"></script>
    <script src="../../theme/datatables.net-buttons/js/buttons.flash.min.js"></script>
    <script src="../../theme/datatables.net-buttons/js/buttons.html5.min.js"></script>
    <script src="../../theme/datatables.net-buttons/js/buttons.print.min.js"></script>
    <script src="../../theme/datatables.net-fixedheader/js/dataTables.fixedHeader.min.js"></script>
    <script src="../../theme/datatables.net-keytable/js/dataTables.keyTable.min.js"></script>
    <script src="../../theme/datatables.net-responsive/js/dataTables.responsive.min.js"></script>
    <script src="../../theme/datatables.net-responsive-bs/js/responsive.bootstrap.js"></script>
    <script src="../../theme/datatables.net-scroller/js/dataTables.scroller.min.js"></script>
    <script src="../../theme/jszip/dist/jszip.min.js"></script>
    <script src="../../theme/pdfmake/build/pdfmake.min.js"></script>
    <script src="../../theme/pdfmake/build/vfs_fonts.js"></script>
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
                         'order': [[2, 'desc']],
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