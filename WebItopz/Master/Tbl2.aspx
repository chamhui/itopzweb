<%@ Page Title="Upkeep Transaction" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Tbl2.aspx.vb" Inherits="WebItopz.WebForm2" %>
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
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span style="text-decoration: underline"></span>
    <div class="page-title">
        <div class="title_left">
            <h3>Upkeep Transaction</h3>
        </div>
    </div>
    <div class="x_panel">
        <div class="x_title">
        <h2></h2>
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
                  <div class="row">
                    <div class="col-md-12 col-sm-4 col-xs-12">
                      <div class="x_panel">
                        <div class="x_title">
                          <h2>Starhub</h2>
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
                        <div class="x_content">
                          <div class="form-group">
                            <label class="control-label col-md-2 col-sm-3 col-xs-12" for="last-name">Date</label>
                            <div class="col-md-5 col-sm-6 col-xs-12">
                                <input id="date" class="form-control col-md-5 col-xs-12" type="date">
                            </div>
                          </div>
                          <br></br>
                          <br></br>
                            <div class="table-responsive">
                          <table class="table table-hover">
                            <thead>
                              <tr>
                                <th>Telco</th>
                                <th>Processor</th>
                                <th>Simcard No</th>
                                <th>Amount</th>

                              </tr>
                            </thead>
                            <tbody>
                              <tr>
                                <th scope="row">M1</th>
                                <td>M1P1</td>
                                <td>82108532</td>
                                <td><input class="form-control col-md-2 col-xs-12" type="text"></td>

                              </tr>
                              <tr>
                                <th scope="row">M2</th>
                                <td>M1P2</td>
                                <td>85411514</td>
                                <td><input class="form-control col-md-2 col-xs-12" type="text"></td>

                              </tr>
                              <tr>
                                <th scope="row">Starhub</th>
                                <td>STARHUBP1</td>
                                <td>81458244</td>
                                <td><input class="form-control col-md-2 col-xs-12" type="text"></td>

                              </tr>
                            </tbody>
                          </table>
                        </div>
                        </div>
                      </div>
                    </div>
                    <div class="col-md-12 col-sm-4 col-xs-12">
                      <div class="x_panel">
                        <div class="x_title">
                          <h2>Singtel</h2>
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
                        <div class="x_content">
                            <div class="table-responsive">
                          <table class="table table-hover">
                            <thead>
                              <tr>
                                <th>Processor</th>
                                <th>Simcard No</th>
                                <th>5</th>
                                <th>10</th>
                                <th>15</th>
                              </tr>
                            </thead>
                            <tbody>
                              <tr>
                                <th scope="row">SINGTELP1</th>
                                <td>94469454</td>
                                <td><input class="form-control col-md-2 col-xs-12" type="text"></td>
                                <td><input class="form-control col-md-2 col-xs-12" type="text"></td>
                                <td><input class="form-control col-md-2 col-xs-12" type="text"></td>

                              </tr>
                              <tr>
                                <th scope="row">SINGTELP2</th>
                                <td>93955507</td>
                                <td><input class="form-control col-md-2 col-xs-12" type="text"></td>
                                <td><input class="form-control col-md-2 col-xs-12" type="text"></td>
                                <td><input class="form-control col-md-2 col-xs-12" type="text"></td>
                              </tr>
                              <tr>
                                <th scope="row">SINGTELP3</th>
                                <td>97166343</td>
                                <td><input class="form-control col-md-2 col-xs-12" type="text"></td>
                                <td><input class="form-control col-md-2 col-xs-12" type="text"></td>
                                <td><input class="form-control col-md-2 col-xs-12" type="text"></td>
                              </tr>
                            </tbody>
                            <tfoot>
                                <tr>
                                  <th scope="row" colspan="2">Total Quantity</th>
                                  <td><input class="form-control col-md-2 col-xs-12" type="text"></td>
                                  <td><input class="form-control col-md-2 col-xs-12" type="text"></td>
                                  <td><input class="form-control col-md-2 col-xs-12" type="text"></td>
                                </tr>
                                <tr>
                                  <th scope="row" colspan="2">Total Amount</th>
                                  <td><input class="form-control col-md-2 col-xs-12" type="text"></td>
                                  <td><input class="form-control col-md-2 col-xs-12" type="text"></td>
                                  <td><input class="form-control col-md-2 col-xs-12" type="text"></td>
                                </tr>
                                <tr>
                                  <th scope="row" colspan="2">Total Discount Amount</th>
                                  <td><input class="form-control col-md-2 col-xs-12" type="text"></td>
                                  <td><input class="form-control col-md-2 col-xs-12" type="text"></td>
                                  <td><input class="form-control col-md-2 col-xs-12" type="text"></td>
                                </tr>

                              </tfoot>
                          </table>
                        </div>
                        </div>
                      </div>
                    </div>
                    <div class="col-md-12 col-sm-4 col-xs-12">
                      <div class="x_panel">
                        <div class="x_title">
                          <h2>GrandTotal</h2>
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
                        <div class="x_content">

                          <table class="table table-hover">
                            <thead>
                              <tr>
                                <th scope="row" colspan="2">Grandtotal Amount</th>
                              </tr>
                            </thead>
                            <tbody>
                              <tr>

                                <td colspan="3"><input class="form-control col-md-2 col-xs-12" type="text"></td>
                              </tr>
                            </tbody>

                          </table>
                          <button class="btn btn-success">Submit</button>
                          <button class="btn btn-primary">Cancel</button>

                        </div>
                      </div>
                    </div>
                  </div>

                </div>
              </div>
</asp:Content>
