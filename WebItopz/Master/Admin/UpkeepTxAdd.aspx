<%@ Page Title="Upkeep" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="UpkeepTxAdd.aspx.vb" Inherits="WebItopz.UpkeepTxAdd" %>
<asp:Content ID="header" ContentPlaceHolderID="MainHeader" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
        <div class="form-horizontal form-label-left" >
             <div class="item form-group col-md-7 col-sm-7 col-xs-12">
               
                
                
            </div>
             <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Opening Date 
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtOpeningDate" runat="server" class="form-control col-md-7 col-xs-12 myDatepicker2" ></asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name"> 
                </label>
            </div>
              <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Starhub Phone
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtStarhub_No" runat="server" class="form-control col-md-7 col-xs-12" ></asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name"> 
                </label>
            </div>
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Starhub 
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtStarhubO" runat="server" class="form-control col-md-7 col-xs-12" >0</asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name">SGD 
                </label>
            </div>
              <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">M1 Phone
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtM1_No" runat="server" class="form-control col-md-7 col-xs-12" ></asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name"> 
                </label>
            </div>
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">M1
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtM1O" runat="server" class="form-control col-md-7 col-xs-12" >0</asp:TextBox>
                </div>
                <label class="control-label col-md-1 col-sm-3 col-xs-12" for="name">SGD 
                </label>
                </div> 
                <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">M5 
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtM5O" runat="server" class="form-control col-md-7 col-xs-12" >0</asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name"> 
                </label>
            </div> 
               <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">M18 
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtM18O" runat="server" class="form-control col-md-7 col-xs-12" >0</asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name"> 
                </label>
            </div> 
               <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">M28 
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtM28O" runat="server" class="form-control col-md-7 col-xs-12" >0</asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name"> 
                </label>
            </div> 
             <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Singtel Phone
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtSingtel_No" runat="server" class="form-control col-md-7 col-xs-12" ></asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name"> 
                </label>
            </div>
                   <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Singtel 5
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtSingtel5" runat="server" class="form-control col-md-7 col-xs-12" >0</asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name"> 
                </label>
            </div>  
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Singtel 10
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtSingtel10" runat="server" class="form-control col-md-7 col-xs-12" >0</asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name"> 
                </label>
            </div>  
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Singtel 20
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtSingtel20" runat="server" class="form-control col-md-7 col-xs-12" >0</asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name"> 
                </label>
            </div>  
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Singtel 50
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtSingtel50" runat="server" class="form-control col-md-7 col-xs-12" >0</asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name"> 
                </label>
            </div>  
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Singtel Bonus $30
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtSingtel16" runat="server" class="form-control col-md-7 col-xs-12" >0</asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name"> 
                </label>
            </div>  
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Singtel Hot $55
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtSingtel15" runat="server" class="form-control col-md-7 col-xs-12" >0</asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name"> 
                </label>
            </div>  
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Singtel Hot $128
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtSingtel28" runat="server" class="form-control col-md-7 col-xs-12" >0</asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name"> 
                </label>
            </div>  
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Singtel REDHot $30
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtSingtel300" runat="server" class="form-control col-md-7 col-xs-12" >0</asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name"> 
                </label>
            </div>  
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Singtel Local Saver $18
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtSingtel180" runat="server" class="form-control col-md-7 col-xs-12" >0</asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name"> 
                </label>
            </div>  
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Singtel China $8
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtSingtel888" runat="server" class="form-control col-md-7 col-xs-12" >0</asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name"> 
                </label>
            </div> 

            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Singtel 1GB 7D
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtSingtel102" runat="server" class="form-control col-md-7 col-xs-12" >0</asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name"> 
                </label>
            </div> 
            
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Singtel 1.5GB 7D
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtSingtel1015" runat="server" class="form-control col-md-7 col-xs-12" >0</asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name"> 
                </label>
            </div>

            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Singtel 1GB 30D
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtSingtel118" runat="server" class="form-control col-md-7 col-xs-12" >0</asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name"> 
                </label>
            </div>
              
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Singtel 1.5GB 30D
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtSingtel1315" runat="server" class="form-control col-md-7 col-xs-12" >0</asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name"> 
                </label>
            </div>

            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Singtel 3GB 30D
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtSingtel119" runat="server" class="form-control col-md-7 col-xs-12" >0</asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name"> 
                </label>
            </div>

            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Singtel 4GB 30D
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtSingtel2504" runat="server" class="form-control col-md-7 col-xs-12" >0</asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name"> 
                </label>
            </div>

            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Singtel 5GB 30D
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtSingtel120" runat="server" class="form-control col-md-7 col-xs-12" >0</asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name"> 
                </label>
            </div>
              
               
            </div>
          

            <div class="item form-group col-md-7 col-sm-7 col-xs-12" style="text-align:center;">
                <asp:Button ID="btnSubmit" runat="server" cssClass="btn btn-success" Text="Add" OnClick="btnSubmit_Click" />
                 
                <asp:Label ID="lblErrorMsg" runat="server" Font-Names="Arial" Font-Size="Small" ForeColor="Red"></asp:Label>
            </div>
        </div>
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphFooter" runat="server">
    <script>
        

        $(document).ready(function () {
            $('.myDatepicker2').daterangepicker({
                singleDatePicker: true,
                calender_style: "picker_4"
            }, function (start, end, label) {
                console.log(start.toISOString(), end.toISOString(), label);
            });
        });
        </script>
</asp:Content>