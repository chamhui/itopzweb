<%@ Page Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="AgentMSISDN.aspx.vb" Inherits="WebItopz.Admin_AgentMSISDN" title="Agent MSISDN" %>
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
            <h3>Agent Mobile Number</h3>
        </div>
    </div>
    <div class="x_panel">
        <div class="x_title">
        <h2>Agent Mobile Number</h2>
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
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Agent ID 
                </label>
                <div class="col-md-8 col-sm-8 col-xs-12">
                    <asp:DropDownList ID="txtAgentId" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource2"
                        DataTextField="Name" class="form-control col-md-12 col-xs-12" DataValueField="AgentID">
                    </asp:DropDownList>              
                </div>
            </div>
        </div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnPreRender="GridView1_PreRender"
        BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
        ForeColor="Black" GridLines="Vertical" AllowPaging="True" style="margin: 10px" CssClass="datatable-responsive table table-striped table-bordered dt-responsive nowrap">
        <Columns>
            <asp:CommandField ShowEditButton="True" />
            <asp:TemplateField HeaderText="Delete">
	            <ItemTemplate>
		            <asp:LinkButton ID="LinkDelete" runat="server" CommandName="Delete" 
            OnClientClick="return confirm('Are you sure you want to delete this MSISDN record?');" >Delete</asp:LinkButton>
	            </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                SortExpression="ID" />
            <asp:BoundField DataField="AgentID" HeaderText="AgentID" SortExpression="AgentID" />
            <asp:BoundField DataField="MSISDN" HeaderText="MSISDN" SortExpression="MSISDN" />
            <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
            <asp:BoundField DataField="ReplyFlag" HeaderText="ReplyMT" SortExpression="ReplyFlag" />
        </Columns>
        <FooterStyle BackColor="#CCCC99" />
        <RowStyle BackColor="#F7F7DE" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <PagerStyle ForeColor="#333333" HorizontalAlign="Left" CssClass="GridPager" />
        <HeaderStyle BackColor="#404040" Font-Bold="True" ForeColor="White" Font-Names="Arial" Font-Size="Small" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues"
        ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>" DeleteCommand="DELETE FROM [AgentMSISDN] WHERE [ID] = @original_ID AND [AgentID] = @original_AgentID AND [MSISDN] = @original_MSISDN AND [Password] = @original_Password"
        InsertCommand="INSERT INTO [AgentMSISDN] ([AgentID], [MSISDN], [Password]) VALUES (@AgentID, @MSISDN, @Password)"
        OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT [ID], [AgentID], [MSISDN], [Password], [ReplyFlag] FROM [AgentMSISDN] WHERE ([AgentID] = @AgentID)"
        UpdateCommand="UPDATE [AgentMSISDN] SET [MSISDN] = @MSISDN, [Password] = @Password, [ReplyFlag]=@ReplyFlag WHERE [ID] = @original_ID AND [AgentID] = @original_AgentID AND [MSISDN] = @original_MSISDN ">
        <DeleteParameters>
            <asp:Parameter Name="original_ID" Type="Int32" />
            <asp:Parameter Name="original_AgentID" Type="String" />
            <asp:Parameter Name="original_MSISDN" Type="String" />
            <asp:Parameter Name="original_Password" Type="String" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="MSISDN" Type="String" />
            <asp:Parameter Name="Password" Type="String" />
            <asp:Parameter Name="ReplyFlag" />
            <asp:Parameter Name="original_ID" Type="Int32" />
            <asp:Parameter Name="original_AgentID" Type="String" />
            <asp:Parameter Name="original_MSISDN" Type="String" />
        </UpdateParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="txtAgentId" Name="AgentID" PropertyName="Text" Type="String" />
        </SelectParameters>
        <InsertParameters>
            <asp:Parameter Name="AgentID" Type="String" />
            <asp:Parameter Name="MSISDN" Type="String" />
            <asp:Parameter Name="Password" Type="String" />
        </InsertParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
        SelectCommand="SELECT (convert(varchar(10),AgentID) +' '+Name) as Name,  [AgentID] FROM [AgentInfo]">
    </asp:SqlDataSource>
        <div class="form-horizontal form-label-left" >                   
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Agent ID 
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox  runat="server" id="txtAgentId1" class="form-control col-md-7 col-xs-12" style="margin-bottom: 10px;" type="text"></asp:TextBox>              
                </div>
            </div>
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">MSISDN
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox  runat="server" id="txtMSISDN" class="form-control col-md-7 col-xs-12" style="margin-bottom: 10px;" type="text"></asp:TextBox>              
                </div>
                <div class="col-md-3 col-sm-3 col-xs-12">
                    <span style="font-size: 10pt">(8XXXXXXX)</span>
                </div>
            </div>
            <div class="item form-group col-md-7 col-sm-7 col-xs-12" style="text-align:center;">
                <asp:Button ID="btnAdd" runat="server" cssClass="btn btn-success" Text="Add New MSISDN" />
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


