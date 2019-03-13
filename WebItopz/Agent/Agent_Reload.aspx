<%@ Page Language="VB"  MasterPageFile="~/Site.Master"  AutoEventWireup="false" Inherits="WebItopz.Agent_Reload" title="Agent - Reload" Codebehind="Agent_Reload.aspx.vb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	  <asp:ScriptManager id="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
	<span style="text-decoration: underline"></span>
    <div class="page-title">
        <div class="title_left">
            <h3>Reload</h3>
        </div>
    </div>
    <div class="x_panel">
        <div class="x_title">
        <h2>Reload</h2>
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
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Type
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                   <asp:DropDownList id="DDLTelco" runat="server" DataSourceID="SqlDataSource1" DataValueField="Telco" DataTextField="Telco" AutoPostBack="True" OnSelectedIndexChanged="DDLTelco_SelectedIndexChanged">
										 </asp:DropDownList>
                </div>
            </div>
            <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Amount
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:DropDownList id="DDLReloadAmount" runat="server"></asp:DropDownList>
                </div>
               
            </div>
					 <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Mobile
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:TextBox ID="txtReloadMSISDN" runat="server" class="form-control col-md-7 col-xs-12" ></asp:TextBox>
                </div>
               
            </div>
					<div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:label ID="lblReloadTelco" runat="server" class="col-md-7 col-xs-12" ></asp:label>
                </div>
               
            </div>
					<div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:label ID="lblReloadAmount" runat="server" class="col-md-7 col-xs-12" ></asp:label>
                </div>
               
            </div>
					<div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                    <asp:label ID="lblReloadMSISDN" runat="server" class=" col-md-7 col-xs-12" ></asp:label>
                </div>
               
            </div>

							<div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">
                </label>
                <div class="col-md-6 col-sm-6 col-xs-12">
                     <asp:label ID="lblErrorMsg" runat="server" class=" col-md-7 col-xs-12" ></asp:label>
                </div>
               
            </div>

            <div class="item form-group col-md-7 col-sm-7 col-xs-12" style="text-align:center;">
							 
							<asp:Button id="btnSubmit" runat="server" Text="Submit" cssClass="btn btn-success" ></asp:Button> 
							<asp:Button id="btnConfirm" runat="server" Text="Confirm" Visible="False" cssClass="btn btn-success" ></asp:Button> 
							<asp:Button id="btnEdit" runat="server" Text="Edit" Visible="False" cssClass="btn" ></asp:Button>
             <%--   <asp:Button ID="BtnSave" runat="server" cssClass="btn btn-success" Text="Save" />
                <asp:Label ID="lblError" runat="server" Font-Names="Arial" Font-Size="Small" ForeColor="Red"></asp:Label>--%>
            </div>
					            <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="White" NavigateUrl="http://www.m1.com.sg/M1/site/M1Corp/menuitem.bbba2e1e0cd45957f15a947b3f2000a0/?vgnextoid=ec700a6b02c8e210VgnVCM100000695a230aRCRD&vgnextfmt=pdate:1106051758:"
                            Target="_blank"><img src="images/m17.jpg" style="width: 83px; height: 52px"/></asp:HyperLink><img src="images/m2.jpg" style="width: 83px; height: 52px"/><img src="images/m18.jpg" style="width: 83px; height: 52px"/> <img src="images/m30.jpg" style="width: 83px; height: 52px"/> <img src="images/sh8.jpg" style="width: 83px; height: 52px"/> <img src="images/sh18.gif" style="width: 83px; height: 52px"/><img src="images/sh28.gif" style="width: 83px; height: 52px"/><img src="images/sh17.jpg" style="width: 83px; height: 52px"/>
            <br/>
        <img src="images/Pinoylogo.jpg" style="width: 81px; height: 50px"/> <img src="images/stez5.gif" style="width: 81px; height: 50px"/> <img src="images/ste10.gif" style="width: 81px; height: 50px"/> <img src="images/ste15.gif" style="width: 81px; height: 50px"/> <img src="images/ste20.gif" style="width: 81px; height: 50px"/> <img src="images/ste28.gif" style="width: 81px; height: 50px"/> <img src="images/ste50.gif" style="width: 81px; height: 50px"/> <img src="images/yo18.gif" style="width: 81px; height: 50px"/>
        </div>
    </div>
			<asp:UpdateProgress id="UpdateProgress2" runat="server" __designer:dtid="281474976710662" AssociatedUpdatePanelID="UpdatePanel1" __designer:wfdid="w15"><ProgressTemplate __designer:dtid="281474976710663">
&nbsp;<img src="images/loading.gif" /> 
</ProgressTemplate>
</asp:UpdateProgress><asp:Label id="Label1" runat="server" ForeColor="Red" Font-Size="Small"></asp:Label><asp:Label style="MARGIN: 25px" id="Label2" runat="server" Font-Size="XX-Large"></asp:Label><BR /><asp:Label style="MARGIN: 25px" id="Label3" runat="server" Font-Size="XX-Large"></asp:Label><BR /><asp:Label style="MARGIN: 25px" id="Label4" runat="server" Font-Size="XX-Large"></asp:Label> 
</contenttemplate>
    </asp:UpdatePanel>
	 <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
        SelectCommand="SELECT [Telco] FROM [ProductInfo] WHERE ([Telco] Not Like '%.PIN%') and ([Telco] Not Like '%Flexi%') and ([Status] = @Status)">
        <SelectParameters>
            <asp:Parameter DefaultValue="ACTIVE" Name="Status" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
