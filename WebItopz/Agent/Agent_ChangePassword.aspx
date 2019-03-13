<%@ Page Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" Inherits="WebItopz.Agent_ChangePassword" title="Agent - ChangePassword" Codebehind="Agent_ChangePassword.aspx.vb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
	<span style="text-decoration: underline"></span>
    <div class="page-title">
        <div class="title_left">
            <h3>Change Password</h3>
        </div>
    </div>
    <div class="x_panel">
        <div class="x_title">
        <h2>Change Password</h2>
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
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Old Password 
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtPassword" runat="server" class="form-control col-md-7 col-xs-12" ></asp:TextBox>         
                </div>
            </div>
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">New Password 
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtPasswordNew" runat="server" class="form-control col-md-7 col-xs-12" ></asp:TextBox>
                </div>
               
            </div>
					 <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Retype Password 
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtPasswordNew2" runat="server" class="form-control col-md-7 col-xs-12" ></asp:TextBox>
                </div>
               
            </div>

            <div class="item form-group col-md-7 col-sm-7 col-xs-12" style="text-align:center;">
                <asp:Button ID="BtnSave" runat="server" cssClass="btn btn-success" Text="Save" />
                <asp:Label ID="lblError" runat="server" Font-Names="Arial" Font-Size="Small" ForeColor="Red"></asp:Label>
            </div>
        </div>
    </div>


</asp:Content>

