<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Upkeep2.aspx.vb" Inherits="WebItopz.Upkeep2" %>
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

                $(".OD").datepicker();

                $(".CD").datepicker();

            })</script>
    </header>
    <span style="text-decoration: underline"></span>
    <div class="page-title">
        <div class="title_left">
            <h3>Upkeep Form</h3>
        </div>
    </div>
    <div class="x_panel">
        <div class="x_title">
        <h2>Upkeep Form</h2>
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
        <div id="gridupkeep" runat="server">
         <asp:GridView ID="gvUpkeep" runat="server" AutoGenerateColumns ="False" CellPadding="4" ForeColor="#333333" GridLines="None">
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
    </asp:GridView>
            </div>
    <%--    <form id="form1" >--%>
        <div id="formupkeep" runat="server">
            <table>
                                <!-- Open -->
                            <asp:HiddenField ID="hfUpkeepID" runat="server" />

               <div class="form-horizontal form-label-left" >  
                         <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">ID 
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtID" runat="server" class="form-control col-md-7 col-xs-12" ></asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name"> 
                </label>
            </div>
                                    
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Starhub Opening 
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtSO" runat="server" class="form-control col-md-7 col-xs-12" ></asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name">SGD 
                </label>
            </div>
                  
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">M1 Opening
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtM1O" runat="server" class="form-control col-md-7 col-xs-12" ></asp:TextBox>
                </div>
                <label class="control-label col-md-1 col-sm-3 col-xs-12" for="name">SGD 
                </label>
                </div> 
                <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">M5 Opening 
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtM5O" runat="server" class="form-control col-md-7 col-xs-12" ></asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name">SGD 
                </label>
            </div> 
                <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">M18 Opening 
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtM18O" runat="server" class="form-control col-md-7 col-xs-12" ></asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name">SGD 
                </label>
            </div>  
                <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">M28 Opening 
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtM28O" runat="server" class="form-control col-md-7 col-xs-12" ></asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name">SGD 
                </label>
            </div>  
                <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Singtel Opening 
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtSingO" runat="server" class="form-control col-md-7 col-xs-12" ></asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name">SGD 
                </label>
            </div> 
                    <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Opening Date
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtOD" runat="server" class="form-control col-md-7 col-xs-12 OD" ></asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name">Date 
                </label>
            </div>
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Starhub Current
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtSC" runat="server" class="form-control col-md-7 col-xs-12" ></asp:TextBox>
                </div>
                <label class="control-label col-md-1 col-sm-3 col-xs-12" for="name">SGD 
                </label>
                </div> 
                <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">M1 Current
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtM1C" runat="server" class="form-control col-md-7 col-xs-12" ></asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name">SGD 
                </label>
            </div>  
                <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">M5 Current 
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtM5C" runat="server" class="form-control col-md-7 col-xs-12" ></asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name">SGD 
                </label>
            </div>  
                <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">M18 Current
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtM18C" runat="server" class="form-control col-md-7 col-xs-12" ></asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name">SGD 
                </label>
            </div> 
                       <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">M28 Current
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtM28C" runat="server" class="form-control col-md-7 col-xs-12" ></asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name">SGD 
                </label>
            </div> 
                       <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Singtel Current
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtSingC" runat="server" class="form-control col-md-7 col-xs-12" ></asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name">SGD 
                </label>
            </div> 
                       <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Closing Date
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtCD" runat="server" class="form-control col-md-7 col-xs-12 CD" ></asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name">Date 
                </label>
            </div>       
            </div>
            <div class="item form-group col-md-7 col-sm-7 col-xs-12" style="text-align:center;">
<%--                <asp:Button ID="btnSave" runat="server" cssClass="btn btn-success" Text="Add" />--%>
                <asp:Button ID="btnClear" runat="server" cssClass="btn btn-success" Text="Clear" />
                <asp:Button ID="btnCloseDate" runat="server" cssClass="btn btn-success" Text="CloseDate" />
                <asp:Button ID="btnUpdate" runat="server" cssClass="btn btn-success" Text="Update" />



                <asp:Label ID="lblErrorMsg" runat="server" Font-Names="Arial" Font-Size="Small" ForeColor="Red"></asp:Label>
            </div>
        </div>
            </table>
        </div>
    <br />

   
      <%--  </form>--%>
        
       
    </div>

</asp:Content>