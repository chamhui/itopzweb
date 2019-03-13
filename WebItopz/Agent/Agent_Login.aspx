<%@ Page Language="VB" AutoEventWireup="false" Inherits="WebItopz.Agent_Login" title="Agent - Login" Codebehind="Agent_Login.aspx.vb" %>
<html lang="en">
  <head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>Agent - Login</title>

    <!-- Bootstrap -->
    <link href="../Theme/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet">
    <!-- Font Awesome -->
    <link href="../Theme/font-awesome/css/font-awesome.min.css" rel="stylesheet">
    <!-- NProgress -->
    <link href="../Theme/nprogress/nprogress.css" rel="stylesheet">
    <!-- Animate.css -->
    <link href="../Theme/animate.css/animate.min.css" rel="stylesheet">

    <!-- Custom Theme Style -->
    <link href="../build/css/custom.min.css" rel="stylesheet">
  </head>

  <body class="login">
    <div>
      <a class="hiddenanchor" id="signup"></a>
      <a class="hiddenanchor" id="signin"></a>

      <div class="login_wrapper">
        <div class="animate form login_form">
          <section class="login_content">
            <form runat="server">
              <h1>Agent - Login</h1>
              <div>
<asp:TextBox ID="txtMISISN" class="form-control" placeholder="MSISDN" runat="server"></asp:TextBox>
              </div>
              <div>
<asp:TextBox ID="txtPassword" class="form-control" placeholder="Password" runat="server" TextMode="Password"></asp:TextBox>
            
              </div>
							<!--<div>
								<asp:DropDownList ID="ddlserver" runat="server"  class="form-control" >
									<asp:ListItem>Production</asp:ListItem>
									<asp:ListItem>Test</asp:ListItem>
								</asp:DropDownList>
							</div>-->
							<br />
              <div>
								<asp:Button ID="LoginButton" class="btn btn-default" runat="server" Text="Log in" style="float:none;margin-left:0px;" OnClick="LoginButton_Click" />
             <%--   <a class="btn btn-default submit" href="index.html">Log in</a>
                <a class="reset_pass" href="#">Lost your password?</a>--%>
              </div>
							<div>
	<asp:Label ID="lblError" runat="server" Text=""></asp:Label>

							</div>
              <div class="clearfix"></div>

           
            </form>
          </section>
        </div>

      </div>
    </div>
  </body>
</html>

