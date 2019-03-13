<%@ Page Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="AgentInfo.aspx.vb" Inherits="WebItopz.Admin_AgentInfo" title="AgentInfo" %>
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
        open(strOpen, "Info", "status=1, width=650, height=450, top=100, left=150");
    }
</script>
    <asp:Label ID="lblErrorMsg" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
    <div class="page-title">
        <div class="title_left">
            <h3>Agent Information</h3>
        </div>
    </div>
    <div class="x_panel">
        <div class="x_title">
        <h2>Agent Information</h2>
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
        <label class="control-label col-md-4 col-sm-4 col-xs-12" for="name">Agent ID *
        </label>
        <div class="col-md-8 col-sm-8 col-xs-12">
            <asp:TextBox  runat="server" id="txtAgentid" class="form-control col-md-7 col-xs-12" style="margin-bottom: 10px;" type="text"></asp:TextBox>                      
        </div>
        <asp:Label ID="lblErrorAgentid" runat="server" Font-Names="Arial" Font-Size="Small"></asp:Label>
    </div>
    <div class="item form-group form-horizontal col-md-4 col-sm-4 col-xs-12">
        <label class="control-label col-md-4 col-sm-4 col-xs-12" for="name">Parent ID * 
        </label>
        <div class="col-md-8 col-sm-8 col-xs-12">
            <asp:TextBox  runat="server" id="TxtParentid" class="form-control col-md-7 col-xs-12" style="margin-bottom: 10px;" type="text"></asp:TextBox>                      
        </div>
        <asp:Label ID="lblErrorParentid" runat="server" Font-Names="Arial" Font-Size="Small"></asp:Label>
    </div>
    <div class="item form-group form-horizontal col-md-4 col-sm-4 col-xs-12">
        <div class="col-md-9 col-sm-9 col-xs-12">
            <asp:Button ID="btnSearch" runat="server" class="btn btn-success" Text="Search" />
        </div>
    </div>
			<asp:Button ID="btnExport" runat="server" Text="Export" />
    <asp:Label ID="lblErrorGrid" runat="server" Font-Names="Arial" Font-Size="Small" ForeColor="Red"></asp:Label>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" OnPreRender="GridView1_PreRender"
        AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None"
        BorderWidth="1px" CellPadding="4" DataSourceID="SqlDataSource1" CssClass="datatable-responsive table table-striped table-bordered dt-responsive nowrap"
        ForeColor="Black" GridLines="Vertical" Style="margin: 10px" DataKeyNames="AgentID" PageSize="20" >
        <FooterStyle BackColor="#CCCC99" />
        <RowStyle BackColor="#F7F7DE" Font-Names="Arial" Font-Size="Small" />
        <Columns>
            <asp:CommandField ShowEditButton="True" />
                        <asp:TemplateField HeaderText="AgentID" SortExpression="AgentID" >
                <EditItemTemplate>
                    <asp:Label ID="lblAgentID" runat="server" Text='<%# Eval("AgentID") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblAgentID" runat="server" Text='<%# Bind("AgentID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" >
                <ItemStyle Font-Size="Small" Wrap="False" />
            </asp:BoundField>
                <asp:TemplateField HeaderText="Balance" SortExpression="Balance" >
                <EditItemTemplate>
                    <asp:Label ID="Balance" runat="server" Text='<%# Eval("Balance") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Balance" runat="server" Text='<%# Bind("Balance") %>'></asp:Label>
                </ItemTemplate>   
                </asp:TemplateField>
            <asp:TemplateField HeaderText="Discount">
                <ItemTemplate>
                <a href="javascript:openPopup('<%# Eval("AgentID", "EditDiscount.aspx?AgentID={0}&") %>Name=<%# Eval("Name") %>')">View/Edit</a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
            <asp:TemplateField HeaderText="HPNo"  SortExpression="HPNo"   >
            <EditItemTemplate>
            <asp:Textbox ID="tHPNo" runat="server" Text='<%# Eval("HPNo") %>'></asp:Textbox>
            </EditItemTemplate>
            <ItemTemplate>
            <asp:Label ID="lblHPNo" runat="server" Text='<%# Bind("HPNo") %>'></asp:Label>
            </ItemTemplate>
            </asp:TemplateField>           
            <asp:BoundField DataField="ParentAgentID" HeaderText="ParentID" SortExpression="ParentAgentID" />
            <asp:BoundField DataField="CreatedDate" HeaderText="CreatedDate" SortExpression="CreatedDate">
            <ItemStyle Wrap="False" />
            </asp:BoundField>
            <asp:BoundField DataField="LastmodifiedDate" HeaderText="LastModifiedDate" SortExpression="LastmodifiedDate">
                <ItemStyle Wrap="False" />
            </asp:BoundField>
        </Columns>
        <PagerStyle ForeColor="#333333" HorizontalAlign="Left" CssClass="GridPager" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#404040" Font-Bold="True" ForeColor="White" Font-Names="Arial" Font-Size="Small" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues"
        ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>" DeleteCommand="DELETE FROM [AgentInfo] WHERE [AgentID] = @original_AgentID AND [Name] = @original_Name AND [Gender] = @original_Gender AND [Race] = @original_Race AND [Status] = @original_Status AND [Email] = @original_Email AND [Address] = @original_Address AND [HPNo] = @original_HPNo AND [ICNo] = @original_ICNo AND [Bank] = @original_Bank AND [BankNo] = @original_BankNo AND [ParentAgentID] = @original_ParentAgentID AND [DiscountMaxis] = @original_DiscountMaxis AND [DiscountDiGi] = @original_DiscountDiGi AND [DiscountCelcom] = @original_DiscountCelcom AND [CreatedDate] = @original_CreatedDate"
        InsertCommand="INSERT INTO [AgentInfo] ([AgentID], [Name], [Gender], [Race], [Status], [Email], [Address], [HPNo], [ICNo], [Bank], [BankNo], [ParentAgentID], [DiscountMaxis], [DiscountDiGi], [DiscountCelcom], [CreatedDate]) VALUES (@AgentID, @Name, @Gender, @Race, @Status, @Email, @Address, @HPNo, @ICNo, @Bank, @BankNo, @ParentAgentID, @DiscountMaxis, @DiscountDiGi, @DiscountCelcom, @CreatedDate)"
        OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT AgentID, Name, Status, HPNo, ParentAgentID, CreatedDate, LastmodifiedDate, (SELECT Balance FROM AgentBalance AS i WHERE (AgentID = b.AgentID)) AS Balance FROM AgentInfo As b ORDER BY CONVERT(INT, ParentAgentID)"
        UpdateCommand="UPDATE AgentInfo SET Name = @Name, Status = @Status, ParentAgentID = @ParentAgentID WHERE ([AgentID] = @original_AgentID)">
        <DeleteParameters>
            <asp:Parameter Name="original_AgentID" Type="Int32" />
            <asp:Parameter Name="original_Name" Type="String" />
            <asp:Parameter Name="original_Gender" Type="String" />
            <asp:Parameter Name="original_Race" Type="String" />
            <asp:Parameter Name="original_Status" Type="String" />
            <asp:Parameter Name="original_Email" Type="String" />
            <asp:Parameter Name="original_Address" Type="String" />
            <asp:Parameter Name="original_HPNo" Type="String" />
            <asp:Parameter Name="original_ICNo" Type="String" />
            <asp:Parameter Name="original_Bank" Type="String" />
            <asp:Parameter Name="original_BankNo" Type="String" />
            <asp:Parameter Name="original_ParentAgentID" Type="String" />
            <asp:Parameter Name="original_DiscountMaxis" Type="Decimal" />
            <asp:Parameter Name="original_DiscountDiGi" Type="Decimal" />
            <asp:Parameter Name="original_DiscountCelcom" Type="Decimal" />
            <asp:Parameter Name="original_CreatedDate" Type="DateTime" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="Status" Type="String" />
            <asp:Parameter Name="HPNo" Type="String" />
            <asp:Parameter Name="ParentAgentID" Type="String" />
            <asp:Parameter Name="original_AgentID" Type="Int32" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="AgentID" Type="Int32" />
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="Gender" Type="String" />
            <asp:Parameter Name="Race" Type="String" />
            <asp:Parameter Name="Status" Type="String" />
            <asp:Parameter Name="Email" Type="String" />
            <asp:Parameter Name="Address" Type="String" />
            <asp:Parameter Name="HPNo" Type="String" />
            <asp:Parameter Name="ICNo" Type="String" />
            <asp:Parameter Name="Bank" Type="String" />
            <asp:Parameter Name="BankNo" Type="String" />
            <asp:Parameter Name="ParentAgentID" Type="String" />
            <asp:Parameter Name="DiscountMaxis" Type="Decimal" />
            <asp:Parameter Name="DiscountDiGi" Type="Decimal" />
            <asp:Parameter Name="DiscountCelcom" Type="Decimal" />
            <asp:Parameter Name="CreatedDate" Type="DateTime" />
        </InsertParameters>
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

