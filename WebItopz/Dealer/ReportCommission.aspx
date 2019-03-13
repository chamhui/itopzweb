<%@ Page Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" Inherits="WebItopz.Dealer_ReportCommission" title="Dealer - ReportAgentSales" Codebehind="ReportCommission.aspx.vb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblErrorMsg" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
    <div class="page-title">
        <div class="title_left">
            <h3>Report Commission</h3>
        </div>
    </div>
    <div class="x_panel">
        <div class="x_title">
        <h2>Report Commission</h2>
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
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Month 
                </label>
                <div class="col-md-8 col-sm-8 col-xs-12">
                    <asp:DropDownList ID="DDLMonth" runat="server" class="form-control col-md-12 col-xs-12" >
                        <asp:ListItem>01</asp:ListItem>
                        <asp:ListItem>02</asp:ListItem>
                        <asp:ListItem>03</asp:ListItem>
                        <asp:ListItem>04</asp:ListItem>
                        <asp:ListItem>05</asp:ListItem>
                        <asp:ListItem>06</asp:ListItem>
                        <asp:ListItem>07</asp:ListItem>
                        <asp:ListItem>08</asp:ListItem>
                        <asp:ListItem>09</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                    </asp:DropDownList>       
                </div>
            </div>
           <div class="item form-group col-md-7 col-sm-7 col-xs-12">
                <label class="control-label col-md-3 col-sm-3 col-xs-12" for="name">Year 
                </label>
                <div class="col-md-8 col-sm-8 col-xs-12">
                    <asp:DropDownList ID="DDLYear" runat="server" class="form-control col-md-12 col-xs-12" >
                    </asp:DropDownList>     
                </div>
            </div>
            <div class="item form-group col-md-7 col-sm-7 col-xs-12" style="text-align:center;">
                <asp:Button ID="Button1" runat="server" class="btn btn-success" Text="Generate" />
                <asp:Label ID="lblError" runat="server" Font-Bold="True" ForeColor="#FF6600"></asp:Label>
            </div>
        </div>

      <br />
    <table border="1" cellpadding="5" cellspacing="2" width="100%" class="dataTable table-bordered table-counter">
        <tr style="color: White; background-color: #404040;">
            <td>
                <strong>Total</strong></td>
            <td>
                <b>Week 1</b></td>
            <td>
                <b>Week 2</b></td>
            <td>
                <b>Week 3</b></td>
            <td>
                <b>Week 4 </b>
            </td>
            <td>
                <b>Week 5</b></td>
        </tr>
        <tr style="background-color: #F7F7DE; color: black;">
            <td>
                $<asp:Label ID="lblTotal" runat="server" Text="0.00"></asp:Label>
            </td>
            <td>
                $<asp:Label ID="lblWeek1" runat="server" Text="0.00"></asp:Label>
            </td>
            <td>
                $<asp:Label ID="lblWeek2" runat="server" Text="0.00"></asp:Label>
            </td>
            <td>
                $<asp:Label ID="lblWeek3" runat="server" Text="0.00"></asp:Label>
            </td>
            <td>
                $<asp:Label ID="lblWeek4" runat="server" Text="0.00"></asp:Label>
            </td>
            <td>
                $<asp:Label ID="lblWeek5" runat="server" Text="0.00"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    </div>
</asp:Content>

