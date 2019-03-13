<%@ Page Title="Upkeep List" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Upkeep3.aspx.vb" Inherits="WebItopz.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <link href="../../theme/datatables.net-bs/css/dataTables.bootstrap.min.css" rel="stylesheet"/>
    <link href="../../theme/datatables.net-buttons-bs/css/buttons.bootstrap.min.css" rel="stylesheet"/>
    <link href="../../theme/datatables.net-fixedheader-bs/css/fixedHeader.bootstrap.min.css" rel="stylesheet"/>
    <link href="../../theme/datatables.net-responsive-bs/css/responsive.bootstrap.min.css" rel="stylesheet"/>
    <link href="../../theme/datatables.net-scroller-bs/css/scroller.bootstrap.min.css" rel="stylesheet"/>
    <span style="text-decoration: underline"></span>
    <div class="page-title">
        <div class="title_left">
            <h3>Upkeep List</h3>
        </div>
    </div>
    <div class="x_panel">
        <div class="x_title">
        <h2>Upkeep List</h2>
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
    <%--    <form id="form1" >--%>
            <asp:HiddenField ID="hfUpkeepID" runat="server" />
                           <asp:Label ID="lblErrorMsg" runat="server" Font-Names="Arial" Font-Size="Small" ForeColor="Red"></asp:Label>

    <br />
          <table id="datatable-buttons" class="table table-striped table-bordered">
                      <thead>
                        <tr>
                          <th>Upkeep Status</th>
                            <th>Date</th>
                          <th>Starhub</th>
                          <th>M1</th>
                          <th>M5</th>
                          <th>M18</th>
                          <th>M28</th>
                            <th>S5</th>
                            <th>S8</th>
                            <th>S10</th>
                            <th>S15</th>
                            <th>S18</th>
                            <th>S20</th>
                            <th>S22</th>
                            <th>S28</th>
                            <th>S30</th>
                            <th>S50</th>
                            <th>Edit</th>
                        </tr>
                      </thead>


                      <tbody>
              <asp:Repeater ID="rptrUpkeep" runat="server">
                  <ItemTemplate>
                  <tr><td>Opening</td>
                            <td><%# Eval("OpeningDate") %></td>
                          <td><%# Eval("StarhubOpening") %></td>
                          <td><%# Eval("M1Opening") %></td>
                          <td><%# Eval("M5Opening") %></td>
                          <td><%# Eval("M18Opening") %></td>
                          <td><%# Eval("M28Opening") %></td>
                            <td><%# Eval("Singtel5Opening") %></td>
                            <td><%# Eval("Singtel8Opening") %></td>
                            <td><%# Eval("Singtel10Opening") %></td>
                            <td><%# Eval("Singtel15Opening") %></td>
                            <td><%# Eval("Singtel18Opening") %></td>
                            <td><%# Eval("Singtel20Opening") %></td>
                            <td><%# Eval("Singtel22Opening") %></td>
                            <td><%# Eval("Singtel28Opening") %></td>
                            <td><%# Eval("Singtel30Opening") %></td>
                            <td><%# Eval("Singtel50Opening") %></td>
                      <td><a href="Upkeep.aspx?upkeepid=<%# Eval("UpkeepID") %>">Edit</a></td>
                        </tr>
                  <tr><td>Current/Closing</td>
                            <td><%# Eval("ClosingDate") %></td>
                          <td><%# Eval("StarhubCurrent") %></td>
                          <td><%# Eval("M1Current") %></td>
                          <td><%# Eval("M5Current") %></td>
                          <td><%# Eval("M18Current") %></td>
                          <td><%# Eval("M28Current") %></td>
                            <td><%# Eval("Singtel5Current") %></td>
                            <td><%# Eval("Singtel8Current") %></td>
                            <td><%# Eval("Singtel10Current") %></td>
                            <td><%# Eval("Singtel15Current") %></td>
                            <td><%# Eval("Singtel18Current") %></td>
                            <td><%# Eval("Singtel20Current") %></td>
                            <td><%# Eval("Singtel22Current") %></td>
                            <td><%# Eval("Singtel28Current") %></td>
                            <td><%# Eval("Singtel30Current") %></td>
                            <td><%# Eval("Singtel50Current") %></td>
                           <td><a href="Upkeep.aspx?upkeepid=<%# Eval("UpkeepID") %>">Edit</a></td>
                        </tr>
                      </ItemTemplate>
              </asp:Repeater>        
                             </tbody>
                    </table>
    <%--<asp:GridView ID="gvUpkeep" runat="server" AutoGenerateColumns ="False" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>

            <asp:BoundField DataField="UpkeepID" HeaderText="UpkeepID" />

            <asp:BoundField DataField="StarhubOpening" HeaderText="Starhub Opening" />
            <asp:BoundField DataField="M1Opening" HeaderText="M1 Opening" />
            <asp:BoundField DataField="M5Opening" HeaderText="M5 Opening" />
            <asp:BoundField DataField="M18Opening" HeaderText="M18 Opening" />
             <asp:BoundField DataField="M28Opening" HeaderText="M28 Opening" />
            <asp:BoundField DataField="SingtelOpening" HeaderText="Singtel Opening" />

             <asp:BoundField DataField="OpeningDate" HeaderText="Opening Date" />

            <asp:BoundField DataField="StarhubCurrent" HeaderText="Starhub Current" />
            <asp:BoundField DataField="M1Current" HeaderText="M1 Current" />
             <asp:BoundField DataField="M5Current" HeaderText="M5 Current" />
            <asp:BoundField DataField="M18Current" HeaderText="M18 Current" />
            <asp:BoundField DataField="M28Current" HeaderText="M28 Current" />
             <asp:BoundField DataField="SingtelCurrent" HeaderText="Singtel Current" />
            <asp:BoundField DataField="ClosingDate" HeaderText="Closing Date" />
            <asp:TemplateField>
                <ItemTemplate>
                <asp:LinkButton ID="linkView" runat="server" CommandArgument='<%# Eval("UpkeepID") %>' OnClick ="lnk_onClick">View</asp:LinkButton>
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
    </asp:GridView>--%>
      <%--  </form>--%>
        
       
    </div>
    
    <!-- Datatables -->
   
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
              'order': [[2, 'desc']],
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