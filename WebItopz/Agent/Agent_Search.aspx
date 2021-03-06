﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Agent_Search.aspx.vb" Inherits="WebItopz.Agent_Search1" EnableEventValidation="false" %>
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
    <span style="text-decoration: underline"></span>
    <div class="page-title">
        <div class="title_left">
            <h3>Search</h3>
        </div>
    </div>
    <div class="x_panel">
        <div class="x_title">
        <h2>Search</h2>
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
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Reload MSISDN 
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox  runat="server" id="txtReloadMSISDN" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" type="text"></asp:TextBox>                      
                </div>
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">(9xxxxxxx)
                </label>
            </div>
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Agent MSISDN 
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox  runat="server" id="txtAgentMSISDN" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" type="text"></asp:TextBox>                      
                </div>
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">(9xxxxxxx)
                </label>
                <asp:Label ID="Label1" runat="server" Font-Names="Arial" Font-Size="Small"></asp:Label>
            </div>
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Date
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox  runat="server" id="txtDate" class="form-control col-md-7 col-xs-12" data-validate-length-range="6" type="text"></asp:TextBox>                      
                </div>
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">(yyyymmdd)
                </label>
            </div>
            <div class="ln_solid"></div>
            <div class="item form-group col-md-12 col-sm-12 col-xs-12" style="text-align: center;">
								<asp:Button ID="btnExport" runat="server" Text="Export" class="btn btn-success" />
                <asp:Button ID="btnRefreshDN" runat="server" Text="Refresh DN" class="btn btn-success" />
                <asp:Button ID="Button1" runat="server" Text="Search" class="btn btn-success" />
            </div>
        </div>
    </div>
    <br />
	<div style="overflow-x: scroll;">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" OnPreRender="GridView1_PreRender"
        CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="Vertical"
        PageSize="20" Style="margin: 10px" BorderWidth="3px"  CssClass="datatable-responsive table table-striped table-bordered dt-responsive">
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
        <%--<RowStyle BackColor="#FFFBD6" ForeColor="#333333" Font-Names="Arial" Font-Size="Medium" Wrap="False" />--%>
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="ReloadMSISDN,ReloadAmount,DNReceivedId"
                DataNavigateUrlFormatString="DNDetails.aspx?ReloadMSISDN={0}&amp;ReloadAmount={1}&amp;DN={2}"
                DataTextField="ReloadMSISDN" HeaderText="ReloadNo" Target="_blank" />
					  <asp:BoundField DataField="ReloadTelco" HeaderText="Telco" SortExpression="ReloadTelco" />
            <asp:BoundField DataField="ReloadAmount" HeaderText="$$" SortExpression="ReloadAmount" />
            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
            <asp:BoundField DataField="DNReceivedID" HeaderText="DN" SortExpression="DNReceivedID" >
                <ItemStyle Font-Size="Small" />
            </asp:BoundField>
            <asp:BoundField DataField="LastUpdatedTS" HeaderText="LastUpdatedTS" SortExpression="LastUpdatedTS" >
                <ItemStyle Wrap="False" Font-Size="Small" />
            </asp:BoundField>
            <asp:BoundField DataField="MSISDN" HeaderText="AgentHP" SortExpression="MSISDN" >
                <ItemStyle Font-Size="Small" />
            </asp:BoundField>
            <asp:BoundField DataField="AgentID" HeaderText="AgentID" SortExpression="AgentID" >
                <ItemStyle Font-Size="Small" />
            </asp:BoundField>
                                   <%-- <asp:BoundField DataField="Commission" HeaderText="Comm$" SortExpression="Commission" >
                <ItemStyle Font-Size="Small" />
            </asp:BoundField>--%>
            <asp:BoundField DataField="MessageIn" HeaderText="MessageIn" SortExpression="MessageIn" >
                <ItemStyle Font-Size="Small" />
            </asp:BoundField>
            <asp:BoundField DataField="MessageTS" HeaderText="MessageTS" SortExpression="MessageTS" >
                <ItemStyle Font-Size="XX-Small" />
            </asp:BoundField>
            <asp:BoundField DataField="ErrorCode" HeaderText="ErrorCode" SortExpression="ErrorCode" >
                <ItemStyle Font-Size="Small" Wrap="False" />
            </asp:BoundField>
        </Columns>
        <PagerStyle ForeColor="#333333" HorizontalAlign="Left" CssClass="GridPager" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" Font-Names="Arial" Font-Size="Small"
            ForeColor="White" />
        <%--<AlternatingRowStyle BackColor="White" Wrap="False" />--%>
        <%--<PagerSettings Position="TopAndBottom" />--%>
    </asp:GridView>
		</div>
     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues"
        ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>" OldValuesParameterFormatString="original_{0}"
        SelectCommand="SELECT DNReceivedID, LocalMOID, MSISDN, AgentID, MessageIn, Status, ReloadTelco, ReloadAmount, ReloadMSISDN, MessageTS, ErrorCode, CreatedTS, LastUpdatedTS FROM TxIn WHERE (AgentID IN (SELECT AgentID FROM AgentInfo WHERE (ParentAgentID = @AgentID)))"
         >
        <SelectParameters>
            <asp:SessionParameter Name="AgentID" SessionField="AGENT_ID" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />

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

</asp:Content>

