<%@ Page Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="Broadcast.aspx.vb" Inherits="WebItopz.Admin_Broadcast" title="Broadcast" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <span style="text-decoration: underline"></span>
    <div class="page-title">
        <div class="title_left">
            <h3>Broadcast Message</h3>
        </div>
    </div>
    <div class="x_panel">
        <div class="x_title">
        <h2>Broadcast Message</h2>
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
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">To 
                </label>
                <div class="col-md-8 col-sm-8 col-xs-12">
                <asp:DropDownList ID="DDLGroup" class="form-control col-md-12 col-xs-12"  runat="server" Font-Names="Arial" Font-Size="Small">
                    <asp:ListItem Value="ALL">ALL Dealer &amp; Agent</asp:ListItem>
                    <asp:ListItem Value="DEALER">Dealer Only</asp:ListItem>
                    <asp:ListItem Value="AGENT">Agent Only</asp:ListItem>
                </asp:DropDownList>        
                </div>
            </div>
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">To
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox  runat="server" id="txtMSISDN" class="form-control col-md-7 col-xs-12" type="text"></asp:TextBox>              
                </div>
                <div class="col-md-3 col-sm-3 col-xs-12">
                    <span style="font-size: 10pt; border: 0; box-shadow: none;" class="form-control col-md-7 col-xs-12" >8XXXXXXX</span>
                </div>
            </div>
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name"> 
                </label>
                <div class="col-md-8 col-sm-8 col-xs-12">
                    <asp:TextBox  runat="server" Height="160px" id="txtMsg" class="form-control col-md-7 col-xs-12" type="text" TextMode="MultiLine">ITOPZ.SG :
											
                    </asp:TextBox>                                                    
                </div>
            </div>
            <div class="item form-group col-md-7 col-sm-7 col-xs-12" style="text-align:center;">
                <asp:Button ID="btnSend" runat="server" cssClass="btn btn-success" Text="Send" />
                <asp:Label ID="lblErrorMsg" runat="server" Font-Names="Arial" Font-Size="Small" ForeColor="Red"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>

