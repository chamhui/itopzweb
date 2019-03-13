<%@ Page Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="AgentTopupCard.aspx.vb" Inherits="WebItopz.AgentTopupCard" title="Agent Topup Card" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <span style="text-decoration: underline"></span>
    <div class="page-title">
        <div class="title_left">
            <h3>Agent Topup</h3>
        </div>
    </div>
    <div class="x_panel">
        <div class="x_title">
        <h2>Agent Topup</h2>
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
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">AgentID 
                </label>
                <div class="col-md-8 col-sm-8 col-xs-12">
                    <asp:DropDownList ID="DDLAgentID" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource2"
                        DataTextField="Name" class="form-control col-md-12 col-xs-12" DataValueField="AgentID">
                    </asp:DropDownList>              
                </div>
            </div>

					 <div class="item form-group col-md-7 col-sm-7 col-xs-12">

                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name" style="float:left;">Card: <span style="color: #cc0000; font-size: 16px; margin-left: 1px; display: block; float: right;">*</span>
                </label>
                <div class="col-md-8 col-sm-8 col-xs-12">
                    <asp:DropDownList ID="ddlCard" runat="server" 
                         class="form-control col-md-12 col-xs-12">
											<asp:ListItem>M5</asp:ListItem>
											<asp:ListItem>M18</asp:ListItem>
											<asp:ListItem>M28</asp:ListItem>
										</asp:DropDownList>  
                </div>

            </div>

            <div class="item form-group col-md-7 col-sm-7 col-xs-12">

                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name" style="float:left;">Quantity <span style="color: #cc0000; font-size: 16px; margin-left: 1px; display: block; float: right;">*</span>
                </label>
                <div class="col-md-8 col-sm-8 col-xs-12">
                    <asp:TextBox  runat="server" id="txtMaxisAmount" class="form-control col-md-7 col-xs-12" type="text">0</asp:TextBox>                                
                    
                </div>

            </div>

					   <div class="item form-group col-md-7 col-sm-7 col-xs-12">

                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name" style="float:left;">Price <span style="color: #cc0000; font-size: 16px; margin-left: 1px; display: block; float: right;">*</span>
                </label>
                <div class="col-md-8 col-sm-8 col-xs-12">
                    <asp:TextBox  runat="server" id="txtPrice" class="form-control col-md-7 col-xs-12" type="text">0</asp:TextBox>                                
                    
                </div>

            </div>


            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Remarks 
                </label>
                <div class="col-md-8 col-sm-8 col-xs-12">
                    <asp:TextBox  runat="server" id="txtRemarks" class="form-control col-md-7 col-xs-12" type="text" TextMode="MultiLine"></asp:TextBox>                                
                    
                </div>

            </div>
            <div class="item form-group col-md-7 col-sm-7 col-xs-12" style="text-align:center;">
                <asp:Label ID="lblName" runat="server"></asp:Label>
            </div>
            <div class="item form-group col-md-7 col-sm-7 col-xs-12" style="text-align:center;">
                <asp:Button ID="btnSubmit" runat="server" class="btn btn-success" Text="TopUp" />
                <asp:Button ID="btnConfirm" runat="server" class="btn btn-success" Text="Confirm" Visible="False" />
                <asp:Button ID="btnCancel" runat="server" class="btn btn-primary" Text="Cancel" Visible="False" />
            </div>
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <asp:Label ID="lblErrorMsg" runat="server"></asp:Label>
            </div>
        </div>
    </div>

    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
        SelectCommand="SELECT (convert(varchar(10),AgentID) +' '+Name) as Name,  [AgentID] FROM [AgentInfo]">
    </asp:SqlDataSource>
</asp:Content>

