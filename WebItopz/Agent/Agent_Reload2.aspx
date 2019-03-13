<%@ Page Language="VB"  MasterPageFile="~/Site.Master"  AutoEventWireup="false" Inherits="WebItopz.Agent_Reload2" title="Agent - Reload" Codebehind="Agent_Reload2.aspx.vb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	
    <link href="../Theme/css/bootstrap.min.css" rel="stylesheet"/>
    <link href="../Theme/fonts/css/font-awesome.min.css" rel="stylesheet"/>
    <link href="../Theme/css/animate.min.css" rel="stylesheet"/>
    <link href="../build/css/custom.min.css" rel="stylesheet"/>
    <link rel="stylesheet" type="text/css" href="/index.css"/>
    <link href="/fontawesome-all.css" rel="stylesheet"/>
    <style>
     a{
    color:black !important;
}
a:hover{
    color:black !important;
    text-decoration: none !important;
}
.card{
    height: 100% !important;    
    box-shadow: 6px 6px 20px -9px !important;
}
.nav-tabs{
    width: 100% !important;
}

.far{
    float: right !important;
}

	    .nav.side-menu > li > a, .nav.child_menu > li > a {
	        color: #E7E7E7 !important;
	    }

        .row{
            margin-right: -15px;
            margin-left: -15px;
            margin: auto;
        }

        .col{
            position: relative;
    min-height: 1px;
    padding-right: 15px;
    padding-left: 15px;
    width: 25%;
    float: left;
        }
      .card {
    position: relative;
    display: -webkit-box;
    display: -ms-flexbox;
    display: flex;
    -webkit-box-orient: vertical;
    -webkit-box-direction: normal;
    -ms-flex-direction: column;
    flex-direction: column;
    min-width: 0;
    word-wrap: break-word;
    background-color: #fff;
    background-clip: border-box;
    border: 1px solid rgba(0,0,0,.125);
    border-radius: .25rem;
    color:white;
    min-height:200px;
}


      .card-header {
    padding: .75rem 1.25rem;
    margin-bottom: 0;
    background-color: rgba(0,0,0,.03);
    border-bottom: 1px solid rgba(0,0,0,.125);
}

      .card-body {
    -webkit-box-flex: 1;
    -ms-flex: 1 1 auto;
    flex: 1 1 auto;
    padding: 1.25rem;
}
			h3{
				font-size: 40px;
				font-weight: bolder;
			}
	</style> 
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
     <div class="container">
            <div class="row">
                <ul class="nav nav-tabs">
                    <li class="nav-item active">
                        <a class="nav-link" href="Agent_Reload2.aspx">M1</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link active" href="Agent_Reload3.aspx">STARHUB</a>
                    </li>
									<li class="nav-item">
                        <a class="nav-link" href="Agent_Reload3Data.aspx">STARHUB DATA</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="Agent_Reload4.aspx">SINGTEL</a>
                    </li>
									<li class="nav-item">
                        <a class="nav-link" href="Agent_Reload4Data.aspx">SINGTEL DATA</a>
                    </li>
                    
                </ul>
            </div>
            <br>

           <br />
            <div class="row">
                <div class="col">
                    <a href="Agent_Reload_Receive.aspx?telco=m1&deno=2&value=2">
                        <div class="card text-white" style="background-color: #FF7F50">
                            
                            <div class="card-body text-center">
                                        <h3 class="card-title">$2</h3>
                            </div>
                            <h5 class="card-header" style="background-color: #2F4F4F">
                           <%--     <asp:RadioButton ID="rb2" AssociatedControlID="rb2" runat="server" value="2" GroupName="M1"  Text="&nbsp;&nbsp; M1 $2" Checked="True" /> 
                          --%>
                                <i class="far fa-arrow-alt-circle-right bg-black"></i>
                            </h5>
                        </div>
                    </a>
                </div>
                <div class="col">
                    <a href="Agent_Reload_Receive.aspx?telco=m1&deno=5&value=5">
                        <div class="card text-white" style="background-color: #FF7F50">
                
                            <div class="card-body text-center">
                
                               <h3 class="card-title">$5</h3>
                
                
                            </div>
                            <h5 class="card-header" style="background-color: #2F4F4F">
                                 <%-- <asp:RadioButton ID="rb5" AssociatedControlID="rb5" runat="server" value="5" GroupName="M1"  Text="&nbsp;&nbsp;M1 $5" /> 
                        --%>
                                <i class="far fa-arrow-alt-circle-right bg-black"></i>
                            </h5>
                        </div>
                    </a>
                </div>
                <div class="col">
                    <a href="Agent_Reload_Receive.aspx?telco=m1&deno=10&value=10">
                        <div class="card text-white" style="background-color: #FF7F50">
                
                            <div class="card-body text-center">
                
                                <h3 class="card-title">$10</h3>
                
                
                            </div>
                            <h5 class="card-header" style="background-color: #2F4F4F">
                        <%--     <asp:RadioButton ID="rb10" AssociatedControlID="rb10" runat="server" value="10" GroupName="M1"  Text="&nbsp;&nbsp;M1 $10" /> 
                         --%> 
                                <i class="far fa-arrow-alt-circle-right bg-black"></i>
                            </h5>
                        </div>
                    </a>
                </div>
                <div class="col">
                    <a href="Agent_Reload_Receive.aspx?telco=m1&deno=15&value=15">
                        <div class="card text-white" style="background-color: #FF7F50">
                
                            <div class="card-body text-center">
                
                                <h3 class="card-title"> $15 (Super $55)</h3>
                
                
                            </div>
                            <h5 class="card-header" style="background-color: #2F4F4F">
                                <%--  <asp:RadioButton ID="rb15" AssociatedControlID="rb15" runat="server" value="15" GroupName="M1"  Text="&nbsp;&nbsp;M1 $15 (Super $55)" /> 
                          --%>
                                
                                <i class="far fa-arrow-alt-circle-right bg-black"></i>
                            </h5>
                        </div>
                    </a>
                </div>
                
            </div><br>
            <div class="row">
                <div class="col">
                    <a href="Agent_Reload_Receive.aspx?telco=m1&deno=18&value=18">
                        <div class="card text-white" style="background-color: #FF7F50">
                
                            <div class="card-body text-center">
                
                                <h3 class="card-title">$18</h3>
                
                
                            </div>
                            <h5 class="card-header" style="background-color: #2F4F4F">
                             <%--    <asp:RadioButton ID="rb18" AssociatedControlID="rb18" runat="server" value="18" GroupName="M1"  Text="&nbsp;&nbsp;M1 $18" /> 
                          --%>
                                <i class="far fa-arrow-alt-circle-right bg-black"></i>
                            </h5>
                        </div>
                    </a>
                </div>
                <div class="col">
                    <a href="Agent_Reload_Receive.aspx?telco=m1&deno=19&value=19">
                        <div class="card text-white" style="background-color: #FF7F50">
                
                            <div class="card-body text-center">
                
                                <h3 class="card-title"> $19 (Power talk $19) </h3>
                
                
                            </div>
                            <h5 class="card-header" style="background-color: #2F4F4F">
                               <%-- <asp:RadioButton ID="rb19" AssociatedControlID="rb19" runat="server"  value="19" GroupName="M1"  Text="&nbsp;&nbsp;M1 $19 (Powertalk $19)" /> 
                          --%>
                                <i class="far fa-arrow-alt-circle-right bg-black"></i>
                            </h5>
                        </div>
                    </a>
                </div>
                <div class="col">
                    <a href="Agent_Reload_Receive.aspx?telco=m1&deno=20&value=20">
                        <div class="card text-white" style="background-color: #FF7F50">
                
                            <div class="card-body text-center">
                
                                <h3 class="card-title">$20</h3>
                
                
                            </div>
                            <h5 class="card-header" style="background-color: #2F4F4F">
                         <%--       <asp:RadioButton ID="rb20" AssociatedControlID="rb20" runat="server" value="20" GroupName="M1"  Text="&nbsp;&nbsp;M1 $20" /> 
                         --%> 
                                <i class="far fa-arrow-alt-circle-right bg-black"></i>
                            </h5>
                        </div>
                    </a>
                </div>
                <div class="col">
                    <a href="Agent_Reload_Receive.aspx?telco=m1&deno=28&value=28">
                        <div class="card text-white" style="background-color: #FF7F50">
                
                            <div class="card-body text-center">
                
                                <h3 class="card-title">$28 (Super $130)</h3>
                
                
                            </div>
                            <h5 class="card-header" style="background-color: #2F4F4F">
                               <%-- <asp:RadioButton ID="rb28" AssociatedControlID="rb28" runat="server"  GroupName="M1" value="28" Text="&nbsp;&nbsp;M1 $28 (Super $130)" /> 
                          --%>
                                <i class="far fa-arrow-alt-circle-right bg-black"></i>
                            </h5>
                        </div>
                    </a>
                </div>
            </div><br>
            <div class="row">
                <div class="col">
                    <a href="Agent_Reload_Receive.aspx?telco=m1&deno=30&value=30">
                        <div class="card text-white" style="background-color: #FF7F50">
                
                            <div class="card-body text-center">
                
                                <h3 class="card-title">$30 (Powertalk $30) </h3>
                
                
                            </div>
                            <h5 class="card-header" style="background-color: #2F4F4F">
                                 <%--  <asp:RadioButton ID="rb30" AssociatedControlID="rb30" runat="server"  GroupName="M1"   value="30" Text="&nbsp;&nbsp;M1 $30 ( Powertalk $30 )" /> 
                          --%>
                                <i class="far fa-arrow-alt-circle-right bg-black"></i>
                            </h5>
                        </div>
                    </a>
                </div>

							<div class="col">
                    <a href="Agent_Reload_Receive.aspx?telco=m1&deno=0&value=0">
                        <div class="card text-white" style="background-color: #FF7F50">
                
                            <div class="card-body text-center">
                
                                <h3 class="card-title">Other Amount </h3>
                
                
                            </div>
                            <h5 class="card-header" style="background-color: #2F4F4F">
                                 <%--  <asp:RadioButton ID="rb30" AssociatedControlID="rb30" runat="server"  GroupName="M1"   value="30" Text="&nbsp;&nbsp;M1 $30 ( Powertalk $30 )" /> 
                          --%>
                                <i class="far fa-arrow-alt-circle-right bg-black"></i>
                            </h5>
                        </div>
                    </a>
                </div>
           
            </div>
        </div>
      <br />
            <div class="row">


        <div class="x_title">
       
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
      <%--        <div class="row">
                <div class="form-horizontal form-label-left" >  
                     <div class="item form-group col-md-12 col-sm12 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Mobile
                </label>
                <div class="col-md-3 col-sm-3 col-xs-12">
                    <asp:TextBox ID="txtReloadMSISDN" runat="server" class="form-control col-md-7 col-xs-12" ></asp:TextBox>
                </div>
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">
                      <asp:RadioButton ID="rbOther" AssociatedControlID="rbOther" runat="server"  GroupName="M1"  Text="&nbsp;&nbsp; Other Amount" /> 
                          
                </label>
                <div class="col-md-3 col-sm-3 col-xs-12">
                    <asp:TextBox ID="txtAmount" runat="server" class="form-control col-md-7 col-xs-12" ></asp:TextBox>
                </div>
            </div>


					
					<div class="item form-group col-md-12 col-sm-12 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">
                </label>
                <div class="col-md-12 col-sm-12 col-xs-12">
                    
                </div>
               
            </div>
					<div class="item form-group col-md-12 col-sm-12 col-xs-12">
               <div class="col-md-4 col-sm-4 col-xs-12">
                    <asp:label ID="lblReloadTelco" runat="server" class="col-md-7 col-xs-12" ></asp:label>
               </div>
                <div class="col-md-4 col-sm-4 col-xs-12">
                  <asp:label ID="lblReloadMSISDN" runat="server" class=" col-md-7 col-xs-12" ></asp:label>
                </div>
                <div class="col-md-4 col-sm-4 col-xs-12">
                   
                       <asp:label ID="lblReloadAmount" runat="server" class="col-md-7 col-xs-12" ></asp:label>
                </div>
            </div>
							<div class="item form-group col-md-12 col-sm-12 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">
                </label>
                <div class="col-md-12 col-sm-12 col-xs-12">
                     <asp:label ID="lblErrorMsg" runat="server" class=" col-md-7 col-xs-12" ></asp:label>
                </div>
               
            </div>

            <div class="item form-group col-md-12 col-sm-12 col-xs-12" style="text-align:center;">
							 
							<asp:Button id="btnSubmit" runat="server" Text="Submit" cssClass="btn btn-success" ></asp:Button> 
							<asp:Button id="btnConfirm" runat="server" Text="Confirm" Visible="False" cssClass="btn btn-success" ></asp:Button> 
							<asp:Button id="btnEdit" runat="server" Text="Edit" Visible="False" cssClass="btn" ></asp:Button>
          
            </div>
					        
        </div>
 
         </div>--%>
         <div>
             			<asp:UpdateProgress id="UpdateProgress2" runat="server" __designer:dtid="281474976710662" AssociatedUpdatePanelID="UpdatePanel1" __designer:wfdid="w15"><ProgressTemplate __designer:dtid="281474976710663">
&nbsp;<img src="images/loading.gif" /> 
</ProgressTemplate>
</asp:UpdateProgress><asp:Label id="Label1" runat="server" ForeColor="Red" Font-Size="Small"></asp:Label><asp:Label style="MARGIN: 25px" id="Label2" runat="server" Font-Size="XX-Large"></asp:Label><BR /><asp:Label style="MARGIN: 25px" id="Label3" runat="server" Font-Size="XX-Large"></asp:Label><BR /><asp:Label style="MARGIN: 25px" id="Label4" runat="server" Font-Size="XX-Large"></asp:Label> 
         </div>
                </div>

</contenttemplate>
    </asp:UpdatePanel>
	 <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RichTechConnectionString %>"
        SelectCommand="SELECT [Telco] FROM [ProductInfo] WHERE ([Telco] Not Like '%.PIN%') and ([Telco] Not Like '%Flexi%') and ([Status] = @Status)">
        <SelectParameters>
            <asp:Parameter DefaultValue="ACTIVE" Name="Status" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>

    <script src="/bootstrap-4.1.1-dist/js/bootstrap.js"></script>
</asp:Content>
