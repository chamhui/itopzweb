<%@ Page Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="Submaster_PrintReports.aspx.vb" Inherits="WebItopz.Submaster_PrintReports" title="PrintReports" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblErrorMsg" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
    <div class="page-title">
        <div class="title_left">
            <h3>Print Reports</h3>
        </div>
    </div>
    <div class="x_panel">
        <div class="x_title">
        <h2>Print Reports</h2>
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
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
    <asp:Button ID="btnPrintReportAgentSales" runat="server" class="btn btn-success" Text="PrintReportAgentSales"/><br />
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
    <asp:Button ID="btnPrintReportAgentTopUp" runat="server" class="btn btn-success" Text="PrintReportAgentTopUp"/><br />
    <br />
    
    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
    <asp:Button ID="btnPrintReportAgentSalesAll" runat="server" class="btn btn-success" Text="PrintReportAgentSalesAll"/><br />
    <br />
    &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
    <asp:Button ID="btnPrintReportAgentTopUpAll" runat="server" class="btn btn-success" Text="PrintReportAgentTopUpAll"/><br />
     <br />
   &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
   <asp:Button ID="btnSimCardBalance" runat="server" class="btn btn-success" Text="ReportSImCardBalance" Visible="False" />

    </div>
</asp:Content>

