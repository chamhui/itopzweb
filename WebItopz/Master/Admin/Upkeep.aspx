<%@ Page Title="Upkeep" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Upkeep.aspx.vb" Inherits="WebItopz.Upkeep" %>
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
               
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <h2><asp:label ID="TextBox1" runat="server" class="control-label col-md-7 col-xs-12" >Opening</asp:label></h2>      
                </div>
                
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
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Starhub 
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtStarhubO" runat="server" class="form-control col-md-7 col-xs-12" ></asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name">SGD 
                </label>
            </div>
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">M1
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtM1O" runat="server" class="form-control col-md-7 col-xs-12" ></asp:TextBox>
                </div>
                <label class="control-label col-md-1 col-sm-3 col-xs-12" for="name">SGD 
                </label>
                </div> 
                <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">M5 
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtM5O" runat="server" class="form-control col-md-7 col-xs-12" ></asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name"> 
                </label>
            </div> 
               <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">M18 
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtM18O" runat="server" class="form-control col-md-7 col-xs-12" ></asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name"> 
                </label>
            </div> 
               <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">M28 
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtM28O" runat="server" class="form-control col-md-7 col-xs-12" ></asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name"> 
                </label>
            </div> 
                <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Singtel5
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtSingtel5o" runat="server" class="form-control col-md-7 col-xs-12" ></asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name"> 
                </label>
            </div>  
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Singtel8
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtSingtel8o" runat="server" class="form-control col-md-7 col-xs-12" ></asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name"> 
                </label>
            </div>  
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Singtel10
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtSingtel10o" runat="server" class="form-control col-md-7 col-xs-12" ></asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name"> 
                </label>
            </div>  
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Singtel15
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtSingtel15o" runat="server" class="form-control col-md-7 col-xs-12" ></asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name"> 
                </label>
            </div>  
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Singtel18
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtSingtel18o" runat="server" class="form-control col-md-7 col-xs-12" ></asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name"> 
                </label>
            </div>  
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Singtel20
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtSingtel20o" runat="server" class="form-control col-md-7 col-xs-12" ></asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name"> 
                </label>
            </div>  
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Singtel22
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtSingtel22o" runat="server" class="form-control col-md-7 col-xs-12" ></asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name"> 
                </label>
            </div>  
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Singtel28
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtSingtel28o" runat="server" class="form-control col-md-7 col-xs-12" ></asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name"> 
                </label>
            </div>  
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Singtel30
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtSingtel30o" runat="server" class="form-control col-md-7 col-xs-12" ></asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name"> 
                </label>
            </div>  
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Singtel50
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtSingtel50o" runat="server" class="form-control col-md-7 col-xs-12" ></asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name"> 
                </label>
            </div>  
              
               
            </div>
          
           <div class="form-horizontal form-label-left" >
             <div class="item form-group col-md-7 col-sm-7 col-xs-12">
               
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <h2><asp:label ID="Label1" runat="server" class="control-label col-md-7 col-xs-12" >Current/Closing</asp:label></h2>      
                </div>
                
            </div>
             <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Current/Closing Date 
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtCurrentDate" runat="server" class="form-control col-md-7 col-xs-12 myDatepicker2" ></asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name"> 
                </label>
            </div>
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Starhub 
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtStarhubc" runat="server" class="form-control col-md-7 col-xs-12" ></asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name">SGD 
                </label>
            </div>
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">M1
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtM1c" runat="server" class="form-control col-md-7 col-xs-12" ></asp:TextBox>
                </div>
                <label class="control-label col-md-1 col-sm-3 col-xs-12" for="name">SGD 
                </label>
                </div> 
                <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">M5 
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtM5c" runat="server" class="form-control col-md-7 col-xs-12" ></asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name"> 
                </label>
            </div> 
               <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">M18 
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtM18c" runat="server" class="form-control col-md-7 col-xs-12" ></asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name"> 
                </label>
            </div> 
               <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">M28 
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtM28c" runat="server" class="form-control col-md-7 col-xs-12" ></asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name"> 
                </label>
            </div> 
                <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Singtel5
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtSingtel5c" runat="server" class="form-control col-md-7 col-xs-12" ></asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name"> 
                </label>
            </div>  
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Singtel8
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtSingtel8c" runat="server" class="form-control col-md-7 col-xs-12" ></asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name"> 
                </label>
            </div>  
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Singtel10
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtSingtel10c" runat="server" class="form-control col-md-7 col-xs-12" ></asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name"> 
                </label>
            </div>  
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Singtel15
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtSingtel15c" runat="server" class="form-control col-md-7 col-xs-12" ></asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name"> 
                </label>
            </div>  
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Singtel18
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtSingtel18c" runat="server" class="form-control col-md-7 col-xs-12" ></asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name"> 
                </label>
            </div>  
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Singtel20
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtSingtel20c" runat="server" class="form-control col-md-7 col-xs-12" ></asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name"> 
                </label>
            </div>  
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Singtel22
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtSingtel22c" runat="server" class="form-control col-md-7 col-xs-12" ></asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name"> 
                </label>
            </div>  
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Singtel28
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtSingtel28c" runat="server" class="form-control col-md-7 col-xs-12" ></asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name"> 
                </label>
            </div>  
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Singtel30
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtSingtel30c" runat="server" class="form-control col-md-7 col-xs-12" ></asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name"> 
                </label>
            </div>  
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Singtel50
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtSingtel50c" runat="server" class="form-control col-md-7 col-xs-12" ></asp:TextBox>      
                </div><label class="control-label col-md-1 col-sm-3 col-xs-12" for="name"> 
                </label>
            </div>  
               <asp:Label ID="lblstatus" runat="server" Text="" Visible="False"></asp:Label>
               
            </div>
      

            <div class="item form-group col-md-7 col-sm-7 col-xs-12" style="text-align:center;">
                <asp:Button ID="btnSubmit" runat="server" cssClass="btn btn-success" Text="Update" OnClick="btnSubmit_Click" />
                 <asp:Button ID="btnClose" runat="server" cssClass="btn btn-success" Text="Close" OnClick="btnClose_Click" />
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