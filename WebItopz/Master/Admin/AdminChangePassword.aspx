<%@ Page Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="AdminChangePassword.aspx.vb" Inherits="WebItopz.AdminChangePassword" title="AdminChangePassword" %>
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
        <script runat="server">


        </script>
    <h1>Change Password 
    </h1>
    
    <hr />
    <div class="row">
        <div class="col-sm-3">
            

           
        </div>
        <div class="col-sm-6">
            <div class="form-group">
                <label>Current Password</label>
                <asp:TextBox runat="server" ID="password" type="password" CssClass="form-control"></asp:TextBox>
                <label>New Password</label>
                <asp:TextBox runat="server" ID="new_password" type="password" CssClass="form-control"></asp:TextBox>
                <label>Confirm Password</label>
                <asp:TextBox runat="server" ID="confirm_password" type="password" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="col-sm-3">
           
        </div>
    </div>
    <div class="row">
        <div class="col-sm-3"></div>
        <div class="col-sm-6">
            <asp:Button ID="btnSubmit" CssClass="btn btn-primary" runat="server" Text="Change Password"></asp:Button>
            <a href="#" class="btn btn-secondary">Cancel</a>
            <br />
            
        <asp:Label ID="lblErrorMsg" runat="server" Font-Names="Arial" Font-Size="Small" ForeColor="Red"></asp:Label>
            <asp:Label ID="lblSuccessMsg" runat="server" Font-Names="Arial" Font-Size="Small" ForeColor="Green"></asp:Label>
        </div>
        <div class="col-sm-3">
            
        </div>
    </div>
    
</asp:Content> 


