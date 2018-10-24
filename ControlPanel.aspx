<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ControlPanel.aspx.cs" Inherits="admin_ControlPanelAdmin" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ajker Deal - Admin Panel</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="http://www.ajkerdeal.com/css/AdminNew/assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="http://www.ajkerdeal.com/css/AdminNew/assets/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="http://www.ajkerdeal.com/css/AdminNew/assets/css/jquery-ui-1.10.3.full.min.css" rel="stylesheet"
        type="text/css" />
    <link href="http://www.ajkerdeal.com/css/AdminNew/assets/css/ace-fonts.css" rel="stylesheet" type="text/css" />
    <link href="http://www.ajkerdeal.com/css/AdminNew/assets/css/ace.min.css" rel="stylesheet" type="text/css" />
    <link href="http://www.ajkerdeal.com/css/AdminNew/assets/css/ace-rtl.min.css" rel="stylesheet" type="text/css" />
    <link href="http://www.ajkerdeal.com/css/AdminNew/assets/css/ace-skins.min.css" rel="stylesheet" type="text/css" />
    <script src="http://www.ajkerdeal.com/css/AdminNew/assets/js/ace-extra.min.js" type="text/javascript"></script>
    <%--online--%>
    <link rel="stylesheet" href="//maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css" />
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <%--online--%>
    <link href="http://www.ajkerdeal.com/css/admin/Report/hover.css" rel="stylesheet" />

</head>
<body>
    <form id="formControlPanel" runat="server">
        <div class="navbar navbar-default" id="navbar">
            <div class="navbar-container" id="navbar-container">
                <div class="navbar-header pull-left">
                    <a href="#" class="navbar-brand"><small>
                        <img src="http://www.ajkerdeal.com/images/Logo.png" alt="Logo Image" width="30" />
                        Ajkerdeal Admin Panel </small></a>
                </div>
                <!-- /.navbar-header -->
                <div class="navbar-header pull-right" role="navigation">
                    <ul class="nav ace-nav">
                        <li class="light-blue"><a data-toggle="dropdown" href="#" class="dropdown-toggle">
                            <img class="nav-user-photo" src="http://ajkerdeal.com/images/admin_users/<%Response.Write(intUserId);%>.jpg"
                                alt="<%Response.Write(UserFullName);%>" onerror="if (this.src != 'http://ajkerdeal.com/css/AdminNew/assets/avatars/avatar5.png') this.src = 'http://ajkerdeal.com/css/AdminNew/assets/avatars/avatar5.png';">
                            <span class="user-info"><small>Welcome,</small>
                                <%Response.Write(CurrentUser); %>
                            </span><i class="icon-caret-down"></i></a>

                            <ul class="user-menu pull-right dropdown-menu dropdown-yellow dropdown-caret dropdown-close">
                                <%Response.Write(EditUser); %>
                                <li class="divider"></li>
                                <li><a href="SignOut.aspx"><i class="icon-off"></i>Logout</a></li>
                            </ul>

                        </li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="main-container" id="main-container">
            <div class="main-container-inner">
                <a class="menu-toggler" id="menu-toggler" href="#"><span class="menu-text"></span>
                </a>
                
                <div class="main-content">
                    <div class="breadcrumbs" id="breadcrumbs">
                        <script type="text/javascript">
                            try { ace.settings.check('breadcrumbs', 'fixed') } catch (e) { }
                        </script>
                        <ul class="breadcrumb">
                            <li><i class="icon-home home-icon"></i><a href="#">Home</a> </li>
                            <li class="active">Control Panel</li>
                        </ul>
                        <!-- .breadcrumb -->
                    </div>
                    <div class="page-content">
                        <div class="row">
                            <div class="col-xs-12">
                                
                               <div class="row">
                           <%--        <%

                         using (UserLoginGateway objUserLoginGateway = new UserLoginGateway())
                         {
                             int checkAccess = 0;
                             DataTable dataTable = objUserLoginGateway.CheckLogin(CurrentUser);
                             checkAccess = Convert.ToInt32(dataTable.Rows[0]["AllowOutsideAccess"].ToString());
                             string pathLink = ResolveUrl("~/Default.aspx");
                             string VisitorsIP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();

                             if (!((VisitorsIP == "163.53.150.123") || (VisitorsIP == "103.36.100.154") || (VisitorsIP == "163.53.150.122") || ((intUserId == 64) || (intUserId == 1) || (intUserId == 3) || (intUserId == 21) || (intUserId == 95))))
                             {
                                 Response.Redirect(pathLink, false);
                             }

                         } 
                         
                         %>--%>
                                    <p class='center'> 
                                    <a href='MonthlyTransactionReport.aspx' class='btn btn-info' data-rel='tooltip' data-original-title='Monthly Transaction Report Based On Confirm Order New' title='' style='margin-top:4px'>Transaction RPT New</a>
                                    <a href='MonthlyTransactionReportM1.aspx' class='btn btn-info' data-rel='tooltip' data-original-title='Monthly Transaction Report M1 New' title='' style='margin-top:4px'>New M1</a>
                                    <a href='MonthlyTransactionReportM2.aspx' class='btn btn-info' data-rel='tooltip' data-original-title='Monthly Transaction Report M2 New' title='' style='margin-top:4px'>New M2</a>
                                  <% 
                                      
                                      if ((intUserId == 1) || (intUserId == 21) || (intUserId == 3) || (intUserId == 64) || (intUserId == 95) || (intUserId == 57) || (intUserId == 68))
                                          {%>
                                              
                                          <a href='Generator.aspx' class='btn btn-info' data-rel='tooltip' data-original-title='Generator' title='' style='margin-top:4px'>Manage Desktop Home</a>
                                          <a href='http://www.ajkerdeal.com/admin/HotDealsEntry/DealPriority.aspx' class='btn btn-info' data-rel='tooltip' data-original-title='Manage Mobile Feed' title='' style='margin-top:4px'>Manage Mobile Feed</a>
                               
                                      <%  }

                                      
                                       %>  
                                    </p>
                                </div> 

                                <div class="row">
                               
                                    <h4 class="header smaller lighter pink">CRM Order Reports</h4>
                                    <div class="col-xs-12 col-sm-6 widget-container-span">

                                        <%--Crm Order Main Start--%>
                                        <div class="widget-box">
                                            <div class="widget-header header-color-blue">
                                                <h5 class="bigger lighter">
                                                    <i class="icon-cloud"></i>
                                                    CRM Order
                                                </h5>
                                                <div class="widget-toolbar">
                                                    <a href="#" data-action="settings">
                                                        <i class="icon-cog"></i>
                                                    </a>

                                                    <a href="#" data-action="reload">
                                                        <i class="icon-refresh"></i>
                                                    </a>

                                                    <a href="#" data-action="collapse">
                                                        <i class="icon-chevron-up"></i>
                                                    </a>

                                                    <a href="#" data-action="close">
                                                        <i class="icon-remove"></i>
                                                    </a>
                                                </div>
                                                <div class="widget-toolbar widget-toolbar-light no-border">
                                                    <select id="simple-colorpicker-12" class="hide">
                                                        <option selected="" data-class="blue" value="#307ECC">#307ECC</option>
                                                        <option data-class="blue2" value="#5090C1">#5090C1</option>
                                                        <option data-class="blue3" value="#6379AA">#6379AA</option>
                                                        <option data-class="green" value="#82AF6F">#82AF6F</option>
                                                        <option data-class="green2" value="#2E8965">#2E8965</option>
                                                        <option data-class="green3" value="#5FBC47">#5FBC47</option>
                                                        <option data-class="red" value="#E2755F">#E2755F</option>
                                                        <option data-class="red2" value="#E04141">#E04141</option>
                                                        <option data-class="red3" value="#D15B47">#D15B47</option>
                                                        <option data-class="orange" value="#FFC657">#FFC657</option>
                                                        <option data-class="purple" value="#7E6EB0">#7E6EB0</option>
                                                        <option data-class="pink" value="#CE6F9E">#CE6F9E</option>
                                                        <option data-class="dark" value="#404040">#404040</option>
                                                        <option data-class="grey" value="#848484">#848484</option>
                                                        <option data-class="default" value="#EEE">#EEE</option>
                                                    </select>
                                                </div>
                                            </div>

                                            <div class="widget-body">
                                                <div class="widget-main no-padding">
                                                    <table class="table table-striped table-bordered table-hover">
                                                        <thead class="thin-border-bottom">
                                                            <tr>
                                                                <th>
                                                                    <i class="icon-caret-right blue"></i>Name
                                                                </th>
                                                                <th>
                                                                    <i class="icon-caret-right blue"></i>Last 5th
                                                                </th>
                                                                <th>
                                                                    <i class="icon-caret-right blue"></i>Last 4th
                                                                </th>
                                                                <th>
                                                                    <i class="icon-caret-right blue"></i>Last 3rd
                                                                </th>
                                                                <th>
                                                                    <i class="icon-caret-right blue"></i>Yesterday
                                                                </th>
                                                                <th>
                                                                    <i class="icon-caret-right blue"></i>Today
                                                                </th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <tr>
                                                                <td>Placed Order
                                                                </td>
                                                                <td>
                                                                    <b>
                                                                        <%Response.Write(totalOrderLast5th); %> </b>
                                                                </td>
                                                                <td>
                                                                    <b>
                                                                        <%Response.Write(totalOrderLast4th); %> </b>
                                                                </td>
                                                                <td>
                                                                    <b>
                                                                        <%Response.Write(totalOrderLast3rd); %> </b>
                                                                </td>
                                                                <td>
                                                                    <b>
                                                                        <%Response.Write(totalOrderYesterday); %></b>
                                                                </td>
                                                                <td>
                                                                    <b>
                                                                        <%Response.Write(totalOrderToday); %> </b>
                                                                </td>
                                                            </tr>


                                                            <tr>
                                                                <td>Placed Unique Customer
                                                                </td>
                                                                <td>

                                                                    <%Response.Write(Last5thCustomer); %>
                                                                </td>
                                                                <td>

                                                                    <%Response.Write(Last4thCustomer); %>
                                                                </td>
                                                                <td>

                                                                    <%Response.Write(Last3rdCustomer); %>
                                                                </td>
                                                                <td>

                                                                    <%Response.Write(YesterdayCustomer); %>
                                                                </td>
                                                                <td>

                                                                    <%Response.Write(TodayCustomer); %>
                                                                </td>
                                                            </tr>


                                                            <tr>
                                                                <td>Processed Order
                                                                </td>
                                                                <td data-toggle="modal" data-target="#Model1">
                                                                    <span onclick="GetOrderModel(9);"><b style="color: #008000; cursor: pointer;">
                                                                        <%Response.Write(successOrderLast5th); %></b></span>
                                                                </td>
                                                                <td data-toggle="modal" data-target="#Model1">
                                                                    <span onclick="GetOrderModel(8);"><b style="color: #008000; cursor: pointer;">
                                                                        <%Response.Write(successOrderLast4th); %></b></span>
                                                                </td>
                                                                <td data-toggle="modal" data-target="#Model1">
                                                                    <span onclick="GetOrderModel(7);"><b style="color: #008000; cursor: pointer;">
                                                                        <%Response.Write(successOrderLast3rd); %></b></span>
                                                                </td>
                                                                <td data-toggle="modal" data-target="#Model1">
                                                                    <span onclick="GetOrderModel(6);"><b style="color: #008000; cursor: pointer;">
                                                                        <%Response.Write(successOrderYesterday); %></b></span>
                                                                </td>
                                                                <td data-toggle="modal" data-target="#Model1">
                                                                    <span onclick="GetOrderModel(5);"><b style="color: #008000; cursor: pointer;">
                                                                        <%Response.Write(successOrderToday); %></b></span>
                                                                </td>
                                                            </tr>


                                                            <tr>
                                                                <td>Processed Uni. Customer
                                                                </td>
                                                                <td>

                                                                    <%Response.Write(SuccessCustomerLast5th); %>
                                                                </td>
                                                                <td>

                                                                    <%Response.Write(SuccessCustomerLast4th); %>
                                                                </td>
                                                                <td>

                                                                    <%Response.Write(SuccessCustomerLast3rd); %>
                                                                </td>
                                                                <td>

                                                                    <%Response.Write(SuccessCustomerYesterday); %>
                                                                </td>
                                                                <td>

                                                                    <%Response.Write(SuccessCustomerToday); %>
                                                                </td>
                                                            </tr>

                                                             <tr>
                                                                <td>Placed Conversion
                                                                </td>
                                                                <td>
                                                                    <b>
                                                                        <%Response.Write(Last5thConversion); %>%</b>
                                                                </td>
                                                                <td>
                                                                    <b>
                                                                        <%Response.Write(Last4thConversion); %>%</b>
                                                                </td>
                                                                <td>
                                                                    <b>
                                                                        <%Response.Write(Last3rdConversion); %>%</b>
                                                                </td>
                                                                <td>

                                                                    <b>
                                                                        <%Response.Write(YesterdayConversion); %>%</b>
                                                                </td>
                                                                <td>
                                                                    <b>
                                                                        <%Response.Write(TodayConversion); %>%</b>

                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td>Processed M1
                                                                </td>
                                                                <td data-toggle="modal" data-target="#Model1">
                                                                    <span onclick="GetOrderModel(14);"><b style="color: #DEB887; cursor: pointer;">
                                                                        <%Response.Write(successOrderM1Last5th); %></b></span>
                                                                </td>
                                                                <td data-toggle="modal" data-target="#Model1">
                                                                    <span onclick="GetOrderModel(12);"><b style="color: #DEB887; cursor: pointer;">
                                                                        <%Response.Write(successOrderM1Last4th); %></b></span>
                                                                </td>
                                                                <td data-toggle="modal" data-target="#Model1">
                                                                    <span onclick="GetOrderModel(10);"><b style="color: #DEB887; cursor: pointer;">
                                                                        <%Response.Write(successOrderM1Last3rd); %></b></span>
                                                                </td>
                                                                <td data-toggle="modal" data-target="#Model1">
                                                                    <span onclick="GetOrderModel(3);"><b style="color: #DEB887; cursor: pointer;">
                                                                        <%Response.Write(successOrderM1Yesterday); %></b></span>
                                                                </td>
                                                                <td data-toggle="modal" data-target="#Model1">
                                                                    <span onclick="GetOrderModel(1);"><b style="color: #DEB887; cursor: pointer;">
                                                                        <%Response.Write(successOrderM1Today); %></b></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>Processed M2
                                                                </td>
                                                                <td data-toggle="modal" data-target="#Model1">
                                                                    <span onclick="GetOrderModel(15);"><b style="color: #DEB887; cursor: pointer;">
                                                                        <%Response.Write(successOrderM2Last5th); %></b></span>
                                                                </td>
                                                                <td data-toggle="modal" data-target="#Model1">
                                                                    <span onclick="GetOrderModel(13);"><b style="color: #DEB887; cursor: pointer;">
                                                                        <%Response.Write(successOrderM2Last4th); %></b></span>
                                                                </td>
                                                                <td data-toggle="modal" data-target="#Model1">
                                                                    <span onclick="GetOrderModel(11);"><b style="color: #DEB887; cursor: pointer;">
                                                                        <%Response.Write(successOrderM2Last3rd); %></b></span>
                                                                </td>
                                                                <td data-toggle="modal" data-target="#Model1">
                                                                    <span onclick="GetOrderModel(4);"><b style="color: #DEB887; cursor: pointer;">
                                                                        <%Response.Write(successOrderM2Yesterday); %></b></span>
                                                                </td>
                                                                <td data-toggle="modal" data-target="#Model1">
                                                                    <span onclick="GetOrderModel(2);"><b style="color: #DEB887; cursor: pointer;">
                                                                        <%Response.Write(successOrderM2Today); %></b></span>
                                                                </td>
                                                            </tr>
                                                        </tbody>

                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                        <%--Crm Order Main End--%>
                                    </div>


                                    <div class="col-xs-12 col-sm-6 ">
                                        <div class='widget-box'>

                                            <div class="widget-header header-color-blue">
                                                <h5 class="bigger lighter">
                                                    <i class='ace-icon fa fa-paw'></i>
                                                    Performing Category
                                                </h5>
                                                <div class="widget-toolbar">
                                                    <a href="#" data-action="settings">
                                                        <i class="icon-cog"></i>
                                                    </a>

                                                    <a href="#" data-action="reload">
                                                        <i class="icon-refresh"></i>
                                                    </a>

                                                    <a href="#" data-action="collapse">
                                                        <i class="icon-chevron-up"></i>
                                                    </a>

                                                    <a href="#" data-action="close">
                                                        <i class="icon-remove"></i>
                                                    </a>
                                                </div>
                                                <div class="widget-toolbar widget-toolbar-light no-border">
                                                    <select id="simple-colorpicker-19" class="hide">
                                                        <option selected="" data-class="blue" value="#307ECC">#307ECC</option>
                                                        <option data-class="blue2" value="#5090C1">#5090C1</option>
                                                        <option data-class="blue3" value="#6379AA">#6379AA</option>
                                                        <option data-class="green" value="#82AF6F">#82AF6F</option>
                                                        <option data-class="green2" value="#2E8965">#2E8965</option>
                                                        <option data-class="green3" value="#5FBC47">#5FBC47</option>
                                                        <option data-class="red" value="#E2755F">#E2755F</option>
                                                        <option data-class="red2" value="#E04141">#E04141</option>
                                                        <option data-class="red3" value="#D15B47">#D15B47</option>
                                                        <option data-class="orange" value="#FFC657">#FFC657</option>
                                                        <option data-class="purple" value="#7E6EB0">#7E6EB0</option>
                                                        <option data-class="pink" value="#CE6F9E">#CE6F9E</option>
                                                        <option data-class="dark" value="#404040">#404040</option>
                                                        <option data-class="grey" value="#848484">#848484</option>
                                                        <option data-class="default" value="#EEE">#EEE</option>
                                                    </select>
                                                </div>
                                            </div>

                                            <div class='tabbable'>
                                                <ul class='nav nav-tabs' id='myTabCaCategory' data-action="reload">
                                                    <li class='active'><a data-toggle='tab' href='#TodayCaCategory' id="dayToCa" onclick="getPerformingCategory(this.id)">
                                                        <i class='blue icon-home bigger-110'></i>Today</a></li>
                                                    <li><a data-toggle='tab' href='#YesterdayCaCategory' id="dayYesterCa" onclick="getPerformingCategory(this.id)">
                                                        <i class='green icon-comment bigger-110'></i>Yesterday</a></li>
                                                    <li><a data-toggle='tab' href='#Last3daysCaCategory' id="daysLast3Ca" onclick="getPerformingCategory(this.id)">
                                                        <i class='green icon-comment-alt bigger-110'></i>Last 3 days</a></li>
                                                    <li><a data-toggle='tab' href='#LastweekCaCategory' id="weekLastCa" onclick="getPerformingCategory(this.id)">
                                                        <i class='pink icon-comments bigger-110'></i>Last 7 Days</a></li>

                                                </ul>
                                                <div class='tab-content'>
                                                    <div id='TodayCaCategory' class='tab-pane in active'>
                                                        <p>
                                                            <div class='widget-body'>
                                                                <div style='display: block;' class='widget-body-inner'>
                                                                    <div class='widget-main no-padding' style='height: 200px; overflow: auto;'>
                                                                        <table class='table table-bordered table-striped'>
                                                                            <thead class='thin-border-bottom'>
                                                                                <tr>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Name
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Confirmed
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Delivered
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Merchant
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Avg.Trans
                                                                                    </th>
                                                                                </tr>
                                                                            </thead>
                                                                            <tbody id="PerformingMainCategory_Today">
                                                                                <%=PerformingCaCategory_Today%>
                                                                            </tbody>
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </p>
                                                    </div>
                                                    <div id='YesterdayCaCategory' class='tab-pane'>
                                                        <p>
                                                            <div class='widget-body'>
                                                                <div style='display: block;' class='widget-body-inner'>
                                                                    <div class='widget-main no-padding' style='height: 200px; overflow: auto;'>
                                                                        <table class='table table-bordered table-striped'>
                                                                            <thead class='thin-border-bottom'>
                                                                                <tr>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Name
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Confirmed Order
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Delivered
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Merchant
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Avg.<br />
                                                                                        Value<br />
                                                                                        Of<br />
                                                                                        Trans
                                                                                    </th>
                                                                                </tr>
                                                                            </thead>
                                                                            <tbody id="PerformingMainCategory_YesterDay">
                                                                            </tbody>
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </p>
                                                    </div>
                                                    <div id='Last3daysCaCategory' class='tab-pane'>
                                                        <p>
                                                            <div class='widget-body'>
                                                                <div style='display: block;' class='widget-body-inner'>
                                                                    <div class='widget-main no-padding' style='height: 200px; overflow: auto;'>
                                                                        <table class='table table-bordered table-striped'>
                                                                            <thead class='thin-border-bottom'>
                                                                                <tr>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Name
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Confirmed Order
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Delivered
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Merchant
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Avg.<br />
                                                                                        Value<br />
                                                                                        Of<br />
                                                                                        Trans
                                                                                    </th>
                                                                                </tr>
                                                                            </thead>
                                                                            <tbody id="PerformingMainCategory_Last3days">
                                                                            </tbody>
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </p>
                                                    </div>
                                                    <div id='LastweekCaCategory' class='tab-pane'>
                                                        <p>
                                                            <div class='widget-body'>
                                                                <div style='display: block;' class='widget-body-inner'>
                                                                    <div class='widget-main no-padding' style='height: 200px; overflow: auto;'>
                                                                        <table class='table table-bordered table-striped'>
                                                                            <thead class='thin-border-bottom'>
                                                                                <tr>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Name
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Confirmed Order
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Delivered
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Merchant
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Avg.<br />
                                                                                        Value<br />
                                                                                        Of<br />
                                                                                        Trans
                                                                                    </th>
                                                                                </tr>
                                                                            </thead>
                                                                            <tbody id="PerformingMainCategory_Lastweek">
                                                                            </tbody>
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </p>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <%--Crm Order M2 End--%>
                                </div>

                                <div class="hr hr32 hr-dotted">
                                </div>

                                <div class="row">
                                    <div class='col-sm-6'>
                                        <div class='widget-box transparent'>
                                            <div class='widget-header widget-header-flat'>
                                                <h4 class='lighter'>
                                                    <i class='icon-star orange'></i>Performing Merchant</h4>
                                                <div class='widget-toolbar'>
                                                    <a href='#' data-action='collapse'><i class='icon-chevron-up'></i></a>
                                                </div>
                                            </div>
                                            <div class='tabbable'>
                                                <ul class='nav nav-tabs' id='Ul2' data-action="reload">
                                                    <li class='active'><a data-toggle='tab' href='#Today' id="dayTo" onclick="getPerformingMerchant(this.id,'1')">
                                                        <i class='blue icon-home bigger-110'></i>Today</a></li>
                                                    <li><a data-toggle='tab' href='#Yesterday' id="dayYester" onclick="getPerformingMerchant(this.id,'1')">
                                                        <i class='green icon-comment bigger-110'></i>Yesterday</a></li>
                                                    <li><a data-toggle='tab' href='#Last3days' id="daysLast3" onclick="getPerformingMerchant(this.id,'1')">
                                                        <i class='green icon-comment-alt bigger-110'></i>Last 3 days</a></li>
                                                    <li><a data-toggle='tab' href='#Lastweek' id="weekLast" onclick="getPerformingMerchant(this.id,'1')">
                                                        <i class='pink icon-comments bigger-110'></i>Last 7 Days</a></li>

                                                    <%-- <li><a data-toggle='tab' href='#Month' id="Month1" onclick="getPerformingMerchant(this.id,'1')">
                                                        <i class='pink icon-comments-alt bigger-110'></i>Last 30 Days</a></li>
                                                    <li><a data-toggle='tab' href='#Day100' id="100Day" onclick="getPerformingMerchant(this.id,'1')">
                                                        <i class='pink icon-comments-alt bigger-110'></i>Last 100 Days</a></li>--%>
                                                </ul>
                                                <div class='tab-content'>
                                                    <div id='Today' class='tab-pane in active'>
                                                        <p>
                                                            <div class='widget-body'>
                                                                <div style='display: block;' class='widget-body-inner'>
                                                                    <div class='widget-main no-padding' style='height: 300px; overflow: auto;'>
                                                                        <table class='table table-bordered table-striped'>
                                                                            <thead class='thin-border-bottom'>
                                                                                <tr>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Name
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Confirmed Order
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Delivered
                                                                                    </th>
                                                                                </tr>
                                                                            </thead>
                                                                            <tbody id="PerformingMerchant_Today">
                                                                                <%=PerformingMerchant_Today %>
                                                                            </tbody>
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </p>
                                                    </div>
                                                    <div id='Yesterday' class='tab-pane'>
                                                        <p>
                                                            <div class='widget-body'>
                                                                <div style='display: block;' class='widget-body-inner'>
                                                                    <div class='widget-main no-padding' style='height: 300px; overflow: auto;'>
                                                                        <table class='table table-bordered table-striped'>
                                                                            <thead class='thin-border-bottom'>
                                                                                <tr>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Name
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Confirmed Order
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Delivered
                                                                                    </th>
                                                                                </tr>
                                                                            </thead>
                                                                            <tbody id="PerformingMerchant_YesterDay">
                                                                            </tbody>
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </p>
                                                    </div>
                                                    <div id='Last3days' class='tab-pane'>
                                                        <p>
                                                            <div class='widget-body'>
                                                                <div style='display: block;' class='widget-body-inner'>
                                                                    <div class='widget-main no-padding' style='height: 300px; overflow: auto;'>
                                                                        <table class='table table-bordered table-striped'>
                                                                            <thead class='thin-border-bottom'>
                                                                                <tr>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Name
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Confirmed Order
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Delivered
                                                                                    </th>
                                                                                </tr>
                                                                            </thead>
                                                                            <tbody id="PerformingMerchant_Last3days">
                                                                            </tbody>
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </p>
                                                    </div>
                                                    <div id='Lastweek' class='tab-pane'>
                                                        <p>
                                                            <div class='widget-body'>
                                                                <div style='display: block;' class='widget-body-inner'>
                                                                    <div class='widget-main no-padding' style='height: 300px; overflow: auto;'>
                                                                        <table class='table table-bordered table-striped'>
                                                                            <thead class='thin-border-bottom'>
                                                                                <tr>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Name
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Confirmed Order
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Delivered
                                                                                    </th>
                                                                                </tr>
                                                                            </thead>
                                                                            <tbody id="PerformingMerchant_Lastweek">
                                                                                <%--<tr>
                                                                                <td>
                                                                                    <b class='black'>lastweek</b>
                                                                                </td>
                                                                                <td>
                                                                                    <b class='green'>12</b>
                                                                                </td>
                                                                                <td>
                                                                                    <b class='pink'>123</b>
                                                                                </td>
                                                                            </tr>--%>
                                                                            </tbody>
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </p>
                                                    </div>
                                                    <div id='Month' class='tab-pane'>
                                                        <p>
                                                            <div class='widget-body'>
                                                                <div style='display: block;' class='widget-body-inner'>
                                                                    <div class='widget-main no-padding' style='height: 300px; overflow: auto;'>
                                                                        <table class='table table-bordered table-striped'>
                                                                            <thead class='thin-border-bottom'>
                                                                                <tr>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Name
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Confirmed Order
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Delivered
                                                                                    </th>
                                                                                </tr>
                                                                            </thead>
                                                                            <tbody id="PerformingMerchant_Month">
                                                                                <%--<tr>
                                                                                <td>
                                                                                    <b class='black'>month</b>
                                                                                </td>
                                                                                <td>
                                                                                    <b class='green'>12</b>
                                                                                </td>
                                                                                <td>
                                                                                    <b class='pink'>123</b>
                                                                                </td>
                                                                            </tr>--%>
                                                                            </tbody>
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </p>
                                                    </div>
                                                    <div id='Day100' class='tab-pane'>
                                                        <p>
                                                            <div class='widget-body'>
                                                                <div style='display: block;' class='widget-body-inner'>
                                                                    <div class='widget-main no-padding' style='height: 300px; overflow: auto;'>
                                                                        <table class='table table-bordered table-striped'>
                                                                            <thead class='thin-border-bottom'>
                                                                                <tr>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Name
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Confirmed Order
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Delivered
                                                                                    </th>
                                                                                </tr>
                                                                            </thead>
                                                                            <tbody id="PerformingMerchant_100">
                                                                                <%--<tr>
                                                                                <td>
                                                                                    <b class='black'>100 Day</b>
                                                                                </td>
                                                                                <td>
                                                                                    <b class='green'>12</b>
                                                                                </td>
                                                                                <td>
                                                                                    <b class='pink'>123</b>
                                                                                </td>
                                                                            </tr>--%>
                                                                            </tbody>
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </p>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class='col-sm-6'>
                                        <div class='widget-box transparent'>
                                            <div class='widget-header widget-header-flat'>
                                                <h4 class='orange'>
                                                    <i class='ace-icon fa fa-th-large blue'></i> Performing Sub Category</h4>
                                                <div class='widget-toolbar'>
                                                    <a href='#' data-action='collapse'><i class='icon-chevron-up'></i></a>
                                                </div>
                                            </div>
                                            <div class='tabbable'>
                                                <ul class='nav nav-tabs' id='myTabCategory' data-action="reload">
                                                    <li class='active'><a data-toggle='tab' href='#TodayCategory' id="dayTo2" onclick="getPerformingMerchant(this.id,'2')">
                                                        <i class='blue icon-home bigger-110'></i>Today</a></li>
                                                    <li><a data-toggle='tab' href='#YesterdayCategory' id="dayYester2" onclick="getPerformingMerchant(this.id,'2')">
                                                        <i class='green icon-comment bigger-110'></i>Yesterday</a></li>
                                                    <li><a data-toggle='tab' href='#Last3daysCategory' id="daysLast32" onclick="getPerformingMerchant(this.id,'2')">
                                                        <i class='green icon-comment-alt bigger-110'></i>Last 3 days</a></li>
                                                    <li><a data-toggle='tab' href='#LastweekCategory' id="weekLast2" onclick="getPerformingMerchant(this.id,'2')">
                                                        <i class='pink icon-comments bigger-110'></i>Last 7 Days</a></li>


                                                    <%--<li><a data-toggle='tab' href='#MonthCategory' id="Month2" onclick="getPerformingMerchant(this.id,'2')">
                                                        <i class='pink icon-comments-alt bigger-110'></i>Last 30 Days</a></li>
                                                    <li><a data-toggle='tab' href='#Day100Category' id="100Day2" onclick="getPerformingMerchant(this.id,'2')">
                                                        <i class='pink icon-comments-alt bigger-110'></i>Last 100 Days</a></li>--%>
                                                </ul>
                                                <div class='tab-content'>
                                                    <div id='TodayCategory' class='tab-pane in active'>
                                                        <p>
                                                            <div class='widget-body'>
                                                                <div style='display: block;' class='widget-body-inner'>
                                                                    <div class='widget-main no-padding' style='height: 300px; overflow: auto;'>
                                                                        <table class='table table-bordered table-striped'>
                                                                            <thead class='thin-border-bottom'>
                                                                                <tr>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Name
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Confirmed
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Delivered
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Merchant
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Avg.Trans
                                                                                    </th>
                                                                                </tr>
                                                                            </thead>
                                                                            <tbody id="PerformingCategory_Today">
                                                                                <%=PerformingCategory_Today%>
                                                                                <%--<tr>
                                                                                <td>
                                                                                    <b class='black'>Test11 </b>
                                                                                </td>
                                                                                <td>
                                                                                    <b class='green'>589</b>
                                                                                </td>
                                                                                <td>
                                                                                    <b class='pink'>58</b>
                                                                                </td>
                                                                            </tr>--%>
                                                                            </tbody>
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </p>
                                                    </div>
                                                    <div id='YesterdayCategory' class='tab-pane'>
                                                        <p>
                                                            <div class='widget-body'>
                                                                <div style='display: block;' class='widget-body-inner'>
                                                                    <div class='widget-main no-padding' style='height: 300px; overflow: auto;'>
                                                                        <table class='table table-bordered table-striped'>
                                                                            <thead class='thin-border-bottom'>
                                                                                <tr>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Name
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Confirmed Order
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Delivered
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Merchant
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Avg.<br />
                                                                                        Value<br />
                                                                                        Of<br />
                                                                                        Trans
                                                                                    </th>
                                                                                </tr>
                                                                            </thead>
                                                                            <tbody id="PerformingCategory_YesterDay">
                                                                                <%--<tr>
                                                                                <td>
                                                                                    <b class='black'>Test11 </b>
                                                                                </td>
                                                                                <td>
                                                                                    <b class='green'>589</b>
                                                                                </td>
                                                                                <td>
                                                                                    <b class='pink'>58</b>
                                                                                </td>
                                                                            </tr>--%>
                                                                            </tbody>
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </p>
                                                    </div>
                                                    <div id='Last3daysCategory' class='tab-pane'>
                                                        <p>
                                                            <div class='widget-body'>
                                                                <div style='display: block;' class='widget-body-inner'>
                                                                    <div class='widget-main no-padding' style='height: 300px; overflow: auto;'>
                                                                        <table class='table table-bordered table-striped'>
                                                                            <thead class='thin-border-bottom'>
                                                                                <tr>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Name
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Confirmed Order
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Delivered
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Merchant
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Avg.<br />
                                                                                        Value<br />
                                                                                        Of<br />
                                                                                        Trans
                                                                                    </th>
                                                                                </tr>
                                                                            </thead>
                                                                            <tbody id="PerformingCategory_Last3days">
                                                                                <%--<tr>
                                                                                <td>
                                                                                    <b class='black'>Test11 </b>
                                                                                </td>
                                                                                <td>
                                                                                    <b class='green'>589</b>
                                                                                </td>
                                                                                <td>
                                                                                    <b class='pink'>58</b>
                                                                                </td>
                                                                            </tr>--%>
                                                                            </tbody>
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </p>
                                                    </div>
                                                    <div id='LastweekCategory' class='tab-pane'>
                                                        <p>
                                                            <div class='widget-body'>
                                                                <div style='display: block;' class='widget-body-inner'>
                                                                    <div class='widget-main no-padding' style='height: 300px; overflow: auto;'>
                                                                        <table class='table table-bordered table-striped'>
                                                                            <thead class='thin-border-bottom'>
                                                                                <tr>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Name
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Confirmed Order
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Delivered
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Merchant
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Avg.<br />
                                                                                        Value<br />
                                                                                        Of<br />
                                                                                        Trans
                                                                                    </th>
                                                                                </tr>
                                                                            </thead>
                                                                            <tbody id="PerformingCategory_Lastweek">
                                                                                <%--<tr>
                                                                                <td>
                                                                                    <b class='black'>Test11 </b>
                                                                                </td>
                                                                                <td>
                                                                                    <b class='green'>589</b>
                                                                                </td>
                                                                                <td>
                                                                                    <b class='pink'>58</b>
                                                                                </td>
                                                                            </tr>--%>
                                                                            </tbody>
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </p>
                                                    </div>
                                                    <div id='MonthCategory' class='tab-pane'>
                                                        <p>
                                                            <div class='widget-body'>
                                                                <div style='display: block;' class='widget-body-inner'>
                                                                    <div class='widget-main no-padding' style='height: 300px; overflow: auto;'>
                                                                        <table class='table table-bordered table-striped'>
                                                                            <thead class='thin-border-bottom'>
                                                                                <tr>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Name
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Confirmed Order
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Delivered
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Merchant
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Avg.<br />
                                                                                        Value<br />
                                                                                        Of<br />
                                                                                        Trans
                                                                                    </th>
                                                                                </tr>
                                                                            </thead>
                                                                            <tbody id="PerformingCategory_Month">
                                                                                <%-- <tr>
                                                                                <td>
                                                                                    <b class='black'>Test11 </b>
                                                                                </td>
                                                                                <td>
                                                                                    <b class='green'>589</b>
                                                                                </td>
                                                                                <td>
                                                                                    <b class='pink'>58</b>
                                                                                </td>
                                                                            </tr>--%>
                                                                            </tbody>
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </p>
                                                    </div>
                                                    <div id='Day100Category' class='tab-pane'>
                                                        <p>
                                                            <div class='widget-body'>
                                                                <div style='display: block;' class='widget-body-inner'>
                                                                    <div class='widget-main no-padding' style='height: 300px; overflow: auto;'>
                                                                        <table class='table table-bordered table-striped'>
                                                                            <thead class='thin-border-bottom'>
                                                                                <tr>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Name
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Confirmed Order
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Delivered
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Merchant
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Avg.<br />
                                                                                        Value<br />
                                                                                        Of<br />
                                                                                        Trans
                                                                                    </th>
                                                                                </tr>
                                                                            </thead>
                                                                            <tbody id="PerformingCategory_100">
                                                                                <%--<tr>
                                                                                <td>
                                                                                    <b class='black'>Test11 </b>
                                                                                </td>
                                                                                <td>
                                                                                    <b class='green'>589</b>
                                                                                </td>
                                                                                <td>
                                                                                    <b class='pink'>58</b>
                                                                                </td>
                                                                            </tr>--%>
                                                                            </tbody>
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </p>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="hr hr32 hr-dotted"></div>

                                

                                <div class="hr hr32 hr-dotted"></div>


                                <%--Unique Deal-Merchant--%>
                                <div class="row">
                                    <div class="col-sm-6" id="UniqueDealMerchant">

                                        <a href="#UniqueDealMerchant" 
                                            class="btn btn-success pull-right pop" id="todayDeal_First" onclick="getDealMerchant(this.id);">
                                            <i class="icon-cog bigger-130"></i>
                                            Unique Deal-Merchant
                                        </a>

                                        <div class='widget-box transparent' style="display: none" id="DealMerchantId">
                                            <div class='widget-header widget-header-flat'>
                                                <h4 class='lighter'>
                                                    <i class='icon-cog orange'></i>Unique Deal-Merchant</h4>
                                                <div class='widget-toolbar'>
                                                    <a href='#' data-action='collapse'><i class='icon-chevron-up'></i></a>
                                                </div>
                                            </div>
                                            <div class='tabbable'>
                                                <ul class='nav nav-tabs' id='Ul3' data-action="reload">
                                                    <li class='active'><a data-toggle='tab' href='#Dealtoday' id="todayDeal" onclick="getDealMerchant(this.id)">
                                                        <i class='blue icon-home bigger-110'></i>Today</a></li>
                                                    <li><a data-toggle='tab' href='#Dealyesterday' id="yesterdayDeal" onclick="getDealMerchant(this.id)">
                                                        <i class='green icon-comment bigger-110'></i>Yesterday</a></li>
                                                    <li><a data-toggle='tab' href='#Deallast3day' id="last3dayDeal" onclick="getDealMerchant(this.id)">
                                                        <i class='green icon-comment-alt bigger-110'></i>Last 3 days</a></li>
                                                    <li><a data-toggle='tab' href='#Deallast7day' id="last7dayDeal" onclick="getDealMerchant(this.id)">
                                                        <i class='pink icon-comments bigger-110'></i>Last 7 Days</a></li>

                                                    <%--<li><a data-toggle='tab' href='#Deallast30day' id="last30dayDeal" onclick="getDealMerchant(this.id)">
                                                        <i class='pink icon-comments-alt bigger-110'></i>Last 30 Days</a></li>
                                                    <li><a data-toggle='tab' href='#Deallast100day' id="last100dayDeal" onclick="getDealMerchant(this.id)">
                                                        <i class='pink icon-comments-alt bigger-110'></i>Last 100 Days</a></li>--%>
                                                </ul>
                                                <div class='tab-content'>
                                                    <div id='Dealtoday' class='tab-pane in active'>
                                                        <p>
                                                            <div class='widget-body'>
                                                                <div style='display: block;' class='widget-body-inner'>
                                                                    <div class='widget-main no-padding' style='height: 60px; overflow: auto;'>
                                                                        <table class='table table-bordered table-striped'>
                                                                            <thead class='thin-border-bottom'>
                                                                                <tr>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Total Placed Deal
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Confirmed Deal
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Confirmed Merchant
                                                                                    </th>
                                                                                </tr>
                                                                            </thead>
                                                                            <tbody id="Deal1">
                                                                                <%=Deal1%>
                                                                                <%-- <tr>
                                                                                <td>
                                                                                    <b class='black'>Today</b>
                                                                                </td>
                                                                                <td>
                                                                                    <b class='green'>12</b>
                                                                                </td>
                                                                                <td>
                                                                                    <b class='pink'>123</b>
                                                                                </td>
                                                                            </tr>--%>
                                                                            </tbody>
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </p>
                                                    </div>
                                                    <div id='Dealyesterday' class='tab-pane'>
                                                        <p>
                                                            <div class='widget-body'>
                                                                <div style='display: block;' class='widget-body-inner'>
                                                                    <div class='widget-main no-padding' style='height: 60px; overflow: auto;'>
                                                                        <table class='table table-bordered table-striped'>
                                                                            <thead class='thin-border-bottom'>
                                                                                <tr>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Total Placed Deal
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Confirmed Deal
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Confirmed Merchant
                                                                                    </th>
                                                                                </tr>
                                                                            </thead>
                                                                            <tbody id="Deal2">
                                                                                <%--<tr>
                                                                                <td>
                                                                                    <b class='black'>Yesterday</b>
                                                                                </td>
                                                                                <td>
                                                                                    <b class='green'>12</b>
                                                                                </td>
                                                                                <td>
                                                                                    <b class='pink'>123</b>
                                                                                </td>
                                                                            </tr>--%>
                                                                            </tbody>
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </p>
                                                    </div>
                                                    <div id='Deallast3day' class='tab-pane'>
                                                        <p>
                                                            <div class='widget-body'>
                                                                <div style='display: block;' class='widget-body-inner'>
                                                                    <div class='widget-main no-padding' style='height: 60px; overflow: auto;'>
                                                                        <table class='table table-bordered table-striped'>
                                                                            <thead class='thin-border-bottom'>
                                                                                <tr>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Total Placed Deal
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Confirmed Deal
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Confirmed Merchant
                                                                                    </th>
                                                                                </tr>
                                                                            </thead>
                                                                            <tbody id="Deal3">
                                                                                <%--<tr>
                                                                                <td>
                                                                                    <b class='black'>3day</b>
                                                                                </td>
                                                                                <td>
                                                                                    <b class='green'>12</b>
                                                                                </td>
                                                                                <td>
                                                                                    <b class='pink'>123</b>
                                                                                </td>
                                                                            </tr>--%>
                                                                            </tbody>
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </p>
                                                    </div>
                                                    <div id='Deallast7day' class='tab-pane'>
                                                        <p>
                                                            <div class='widget-body'>
                                                                <div style='display: block;' class='widget-body-inner'>
                                                                    <div class='widget-main no-padding' style='height: 60px; overflow: auto;'>
                                                                        <table class='table table-bordered table-striped'>
                                                                            <thead class='thin-border-bottom'>
                                                                                <tr>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Total Placed Deal
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Confirmed Deal
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Confirmed Merchant
                                                                                    </th>
                                                                                </tr>
                                                                            </thead>
                                                                            <tbody id="Deal7">
                                                                                <%--<tr>
                                                                                <td>
                                                                                    <b class='black'>lastweek</b>
                                                                                </td>
                                                                                <td>
                                                                                    <b class='green'>12</b>
                                                                                </td>
                                                                                <td>
                                                                                    <b class='pink'>123</b>
                                                                                </td>
                                                                            </tr>--%>
                                                                            </tbody>
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </p>
                                                    </div>
                                                    <div id='Deallast30day' class='tab-pane'>
                                                        <p>
                                                            <div class='widget-body'>
                                                                <div style='display: block;' class='widget-body-inner'>
                                                                    <div class='widget-main no-padding' style='height: 60px; overflow: auto;'>
                                                                        <table class='table table-bordered table-striped'>
                                                                            <thead class='thin-border-bottom'>
                                                                                <tr>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Total Placed Deal
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Confirmed Deal
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Confirmed Merchant
                                                                                    </th>
                                                                                </tr>
                                                                            </thead>
                                                                            <tbody id="Deal30">
                                                                                <%--<tr>
                                                                                <td>
                                                                                    <b class='black'>month</b>
                                                                                </td>
                                                                                <td>
                                                                                    <b class='green'>12</b>
                                                                                </td>
                                                                                <td>
                                                                                    <b class='pink'>123</b>
                                                                                </td>
                                                                            </tr>--%>
                                                                            </tbody>
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </p>
                                                    </div>
                                                    <div id='Deallast100day' class='tab-pane'>
                                                        <p>
                                                            <div class='widget-body'>
                                                                <div style='display: block;' class='widget-body-inner'>
                                                                    <div class='widget-main no-padding' style='height: 60px; overflow: auto;'>
                                                                        <table class='table table-bordered table-striped'>
                                                                            <thead class='thin-border-bottom'>
                                                                                <tr>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Total Placed Deal
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Confirmed Deal
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Confirmed Merchant
                                                                                    </th>
                                                                                </tr>
                                                                            </thead>
                                                                            <tbody id="Deal100">
                                                                                <%--<tr>
                                                                                <td>
                                                                                    <b class='black'>100 Day</b>
                                                                                </td>
                                                                                <td>
                                                                                    <b class='green'>12</b>
                                                                                </td>
                                                                                <td>
                                                                                    <b class='pink'>123</b>
                                                                                </td>
                                                                            </tr>--%>
                                                                            </tbody>
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </p>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-sm-6" id="InfoCrazyDeal">

                                        <a href="#InfoCrazyDeal" 
                                            class="btn btn-success pop" id="todayCrazy_First" onclick="getCrazyDeal(this.id);">
                                            <i class="icon-group bigger-130"></i>
                                            Info Crazy-Deal
                                        </a>

                                        <div class='widget-box transparent' style="display: none" id="InfoCrazyDealId">
                                            <div class='widget-header widget-header-flat'>
                                                <h4 class='lighter'>
                                                    <i class='icon-group orange'></i>Info Crazy-Deal</h4>
                                                <div class='widget-toolbar'>
                                                    <a href='#' data-action='collapse'><i class='icon-chevron-up'></i></a>
                                                </div>
                                            </div>
                                            <div class='tabbable'>
                                                <ul class='nav nav-tabs' id='Ul13' data-action="reload">
                                                    <li class='active'><a data-toggle='tab' href='#Crazytoday' id="todayCrazy" onclick="getCrazyDeal(this.id)">
                                                        <i class='blue icon-home bigger-110'></i>Today</a></li>
                                                    <li><a data-toggle='tab' href='#Crazyyesterday' id="yesterdayCrazy" onclick="getCrazyDeal(this.id)">
                                                        <i class='green icon-comment bigger-110'></i>Yesterday</a></li>
                                                    <li><a data-toggle='tab' href='#Crazylast3day' id="last3dayCrazy" onclick="getCrazyDeal(this.id)">
                                                        <i class='green icon-comment-alt bigger-110'></i>Last 3 days</a></li>
                                                    <li><a data-toggle='tab' href='#Crazylast7day' id="last7dayCrazy" onclick="getCrazyDeal(this.id)">
                                                        <i class='pink icon-comments bigger-110'></i>Last 7 Days</a></li>

                                                    <%--<li><a data-toggle='tab' href='#Crazylast30day' id="last30dayCrazy" onclick="getCrazyDeal(this.id)">
                                                        <i class='pink icon-comments-alt bigger-110'></i>Last 30 Days</a></li>
                                                    <li><a data-toggle='tab' href='#Crazylast100day' id="last100dayCrazy" onclick="getCrazyDeal(this.id)">
                                                        <i class='pink icon-comments-alt bigger-110'></i>Last 100 Days</a></li>--%>
                                                </ul>
                                                <div class='tab-content'>
                                                    <div id='Crazytoday' class='tab-pane in active'>
                                                        <p>
                                                            <div class='widget-body'>
                                                                <div style='display: block;' class='widget-body-inner'>
                                                                    <div class='widget-main no-padding' style='height: 60px; overflow: auto;'>
                                                                        <table class='table table-bordered table-striped'>
                                                                            <thead class='thin-border-bottom'>
                                                                                <tr>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Total Active Deal
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Total Crazy Deal
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Total
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Avg Crazy Deal
                                                                                    </th>
                                                                                </tr>
                                                                            </thead>
                                                                            <tbody id="Crazy1">
                                                                                <%=Crazy1%>
                                                                            </tbody>
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </p>
                                                    </div>
                                                    <div id='Crazyyesterday' class='tab-pane'>
                                                        <p>
                                                            <div class='widget-body'>
                                                                <div style='display: block;' class='widget-body-inner'>
                                                                    <div class='widget-main no-padding' style='height: 60px; overflow: auto;'>
                                                                        <table class='table table-bordered table-striped'>
                                                                            <thead class='thin-border-bottom'>
                                                                                <tr>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Total Active Deal
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Total Crazy Deal
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Total
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Avg Crazy Deal
                                                                                    </th>
                                                                                </tr>
                                                                            </thead>
                                                                            <tbody id="Crazy2">
                                                                            </tbody>
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </p>
                                                    </div>
                                                    <div id='Crazylast3day' class='tab-pane'>
                                                        <p>
                                                            <div class='widget-body'>
                                                                <div style='display: block;' class='widget-body-inner'>
                                                                    <div class='widget-main no-padding' style='height: 60px; overflow: auto;'>
                                                                        <table class='table table-bordered table-striped'>
                                                                            <thead class='thin-border-bottom'>
                                                                                <tr>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Total Active Deal
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Total Crazy Deal
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Total
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Avg Crazy Deal
                                                                                    </th>
                                                                                </tr>
                                                                            </thead>
                                                                            <tbody id="Crazy3">
                                                                            </tbody>
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </p>
                                                    </div>
                                                    <div id='Crazylast7day' class='tab-pane'>
                                                        <p>
                                                            <div class='widget-body'>
                                                                <div style='display: block;' class='widget-body-inner'>
                                                                    <div class='widget-main no-padding' style='height: 60px; overflow: auto;'>
                                                                        <table class='table table-bordered table-striped'>
                                                                            <thead class='thin-border-bottom'>
                                                                                <tr>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Total Active Deal
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Total Crazy Deal
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Total
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Avg Crazy Deal
                                                                                    </th>
                                                                                </tr>
                                                                            </thead>
                                                                            <tbody id="Crazy7">
                                                                            </tbody>
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </p>
                                                    </div>
                                                    <div id='Crazylast30day' class='tab-pane'>
                                                        <p>
                                                            <div class='widget-body'>
                                                                <div style='display: block;' class='widget-body-inner'>
                                                                    <div class='widget-main no-padding' style='height: 60px; overflow: auto;'>
                                                                        <table class='table table-bordered table-striped'>
                                                                            <thead class='thin-border-bottom'>
                                                                                <tr>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Total Active Deal
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Total Crazy Deal
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Total
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Avg Crazy Deal
                                                                                    </th>
                                                                                </tr>
                                                                            </thead>
                                                                            <tbody id="Crazy30">
                                                                            </tbody>
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </p>
                                                    </div>
                                                    <div id='Crazylast100day' class='tab-pane'>
                                                        <p>
                                                            <div class='widget-body'>
                                                                <div style='display: block;' class='widget-body-inner'>
                                                                    <div class='widget-main no-padding' style='height: 60px; overflow: auto;'>
                                                                        <table class='table table-bordered table-striped'>
                                                                            <thead class='thin-border-bottom'>
                                                                                <tr>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Total Active Deal
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Total Crazy Deal
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Total
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Avg Crazy Deal
                                                                                    </th>
                                                                                </tr>
                                                                            </thead>
                                                                            <tbody id="Crazy100">
                                                                            </tbody>
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </p>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div id="PielineChart" class="hr hr32 hr-dotted"></div>
                                <div class="row">
                                    <div class='col-sm-6' id='Sales-Star'>
                                        <a href="#Sales-Star" class="btn btn-info pull-right pop" onclick="GetRecords();">
                                            <i class="fa fa-line-chart bigger-130"></i>
                                            Order Stats line chart
                                        </a>
                                    </div>
                                    <div class='col-sm-6' id='pieChart'>
                                        <a href="#pieChart" class="btn btn-info pop" onclick="loadData();">
                                            <i class="fa fa-pie-chart bigger-130"></i>
                                            Crm Order Processing
                                        </a>
                                    </div>
                                    <%--<%Response.Write(SaleStats); %>--%>
                                    <%--  <%Response.Write(StrOrderProcessing); %>--%>
                                </div>
                                <div class="hr hr32 hr-dotted">
                                </div>
                                <div class="row">
                                    <div class="col-sm-6">
                                        <a href="#WishlistId" class="btn btn-inverse pull-right pop" id="btnWishList" onclick="getWishList();">
                                            <i class="red icon-heart bigger-130"></i>
                                            WishList & Transaction
                                        </a>

                                        <div class="tabbable" style="display: none" id="WishlistId">
                                            <ul class="nav nav-tabs" id="myTab">
                                                <li class="active"><a data-toggle="tab" href="#home"><i class="green icon-desktop bigger-110"></i>Transaction</a></li>
                                                <li><a data-toggle="tab" href="#Wishlist"><i class="red icon-heart bigger-110"></i>Added
                                                to Wishlist</a></li>
                                            </ul>
                                            <div class="tab-content">
                                                <div id="home" class="tab-pane in active">
                                                    <p>
                                                        <div class="center">
                                                            <div class="infobox infobox-green  ">
                                                                <div class="infobox-icon">
                                                                    <i class="icon-desktop"></i>
                                                                </div>
                                                                <div class="infobox-data">
                                                                    <span class="infobox-data-number" id="CountOrderMainSite">
                                                                        <%Response.Write(CountOrderMainSite); %></span>
                                                                    <div class="infobox-content green">
                                                                        Total Main
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="infobox infobox-pink ">
                                                                <div class="infobox-icon">
                                                                    <i class="icon-hdd"></i>
                                                                </div>
                                                                <div class="infobox-data">
                                                                    <span class="infobox-data-number" id="CountOrderMobileSite">
                                                                        <%Response.Write(CountOrderMobileSite); %></span>
                                                                    <div class="infobox-content pink">
                                                                        Total Mobile
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="infobox infobox-green  ">
                                                                <div class="infobox-icon">
                                                                    <i class="icon-desktop"></i>
                                                                </div>
                                                                <div class="infobox-data">
                                                                    <span class="infobox-data-number" id="CountOrderMainSiteUnique">
                                                                        <%Response.Write(CountOrderMainSiteUnique); %></span>
                                                                    <div class="infobox-content green">
                                                                        Unique Main
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="infobox infobox-pink  ">
                                                                <div class="infobox-icon">
                                                                    <i class="icon-hdd"></i>
                                                                </div>
                                                                <div class="infobox-data">
                                                                    <span class="infobox-data-number" id="CountOrderMobileSiteUnique">
                                                                        <%Response.Write(CountOrderMobileSiteUnique); %></span>
                                                                    <div class="infobox-content pink">
                                                                        Unique Mobile
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="infobox infobox-orange2">
                                                                <div class="infobox-icon">
                                                                    <i class="icon-user"></i>
                                                                </div>
                                                                <div class="infobox-data">
                                                                    <span class="infobox-data-number" id="NewMerchant">
                                                                        <%Response.Write(NewMerchant); %></span>
                                                                    <div class="infobox-content orange2">
                                                                        New Merchant
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="infobox infobox-blue2  ">
                                                                <div class="infobox-progress">
                                                                    <div style="width: 46px; height: 46px; line-height: 46px;" class="easy-pie-chart percentage easyPieChart"
                                                                        data-percent="<%Response.Write(avgReturnShopper); %>" data-size="46">
                                                                        <span class="percent" id="avgReturnShopper">
                                                                            <%Response.Write(avgReturnShopper); %></span>%
                                                                    <canvas width="46" height="46"></canvas>
                                                                    </div>
                                                                </div>
                                                                <div class="infobox-data">
                                                                    <span class="infobox-text">Return Shopper</span>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </p>
                                                </div>
                                                <div id="Wishlist" class="tab-pane">
                                                    <p>
                                                        <div class="center">
                                                            <div class="infobox infobox-red">
                                                                <div class="infobox-icon">
                                                                    <i class="icon-heart"></i>
                                                                </div>
                                                                <div class="infobox-data">
                                                                    <span class="infobox-data-number" id="CountFavMainSite">
                                                                        <%Response.Write(CountFavMainSite); %></span>
                                                                    <div class="infobox-content red">
                                                                        Total Main
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="infobox infobox-blue">
                                                                <div class="infobox-icon">
                                                                    <i class="icon-heart"></i>
                                                                </div>
                                                                <div class="infobox-data">
                                                                    <span class="infobox-data-number" id="CountFavMobileSite">
                                                                        <%Response.Write(CountFavMobileSite); %></span>
                                                                    <div class="infobox-content blue">
                                                                        Total Mobile
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="infobox infobox-red">
                                                                <div class="infobox-icon">
                                                                    <i class="icon-heart"></i>
                                                                </div>
                                                                <div class="infobox-data">
                                                                    <span class="infobox-data-number" id="CountFavMainSiteUnique">
                                                                        <%Response.Write(CountFavMainSiteUnique); %></span>
                                                                    <div class="infobox-content red">
                                                                        Unique Main
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="infobox infobox-blue">
                                                                <div class="infobox-icon">
                                                                    <i class="icon-heart"></i>
                                                                </div>
                                                                <div class="infobox-data">
                                                                    <span class="infobox-data-number" id="CountFavMobileSiteUnique">
                                                                        <%Response.Write(CountFavMobileSiteUnique); %></span>
                                                                    <div class="infobox-content blue">
                                                                        Unique Mobile
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>


                                    <div class='col-sm-6' id="BKashCODOPS">
                                        <a href="#BKashCODOPS" class="btn btn-inverse pop" id="BkashToday_First" onclick="getBKashCODOPS(this.id);">
                                            <i class="ace-icon fa fa-rss bigger-130"></i>
                                            BKash, COD, OPS
                                        </a>
                                        <div class='widget-box transparent' style="display: none" id="bKashId">
                                            <div class='widget-header widget-header-flat'>
                                                <h4 class='lighter'>
                                                    <i class='ace-icon fa fa-rss blue'></i>BKash, COD, OPS</h4>
                                                <div class='widget-toolbar'>
                                                    <a href='#' data-action='collapse'><i class='icon-chevron-up'></i></a>
                                                </div>
                                            </div>
                                            <div class='tabbable'>
                                                <ul class='nav nav-tabs' id='myTab2' data-action="reload">
                                                    <li class='active'><a data-toggle='tab' href='#TodayBkash' id="BkashToday" onclick="getBKashCODOPS(this.id)">
                                                        <i class='blue icon-home bigger-110'></i>Today</a></li>
                                                    <li><a data-toggle='tab' href='#YesterdayBkash' id="BkashYesterday" onclick="getBKashCODOPS(this.id)">
                                                        <i class='green icon-comment bigger-110'></i>Yesterday</a></li>
                                                    <li><a data-toggle='tab' href='#Last3daysBkash' id="BkashLast3days" onclick="getBKashCODOPS(this.id)">
                                                        <i class='green icon-comment-alt bigger-110'></i>Last 3 days</a></li>
                                                    <li><a data-toggle='tab' href='#LastweekBkash' id="BkashLastweek" onclick="getBKashCODOPS(this.id)">
                                                        <i class='pink icon-comments bigger-110'></i>Last 7 Days</a></li>

                                                    <%--<li><a data-toggle='tab' href='#MonthBkash' id="BkashMonth" onclick="getBKashCODOPS(this.id)">
                                                        <i class='pink icon-comments-alt bigger-110'></i>Last 30 Days</a></li>
                                                    <li><a data-toggle='tab' href='#100Bkash' id="Bkash100" onclick="getBKashCODOPS(this.id)">
                                                        <i class='pink icon-comments-alt bigger-110'></i>Last 100 Days</a></li>--%>
                                                </ul>
                                                <div class='tab-content'>
                                                    <div id='TodayBkash' class='tab-pane in active'>
                                                        <p>
                                                            <div class='widget-body'>
                                                                <div style='display: block;' class='widget-body-inner'>
                                                                    <div class='widget-main no-padding' style='height: 135px; overflow: auto;'>
                                                                        <table class='table table-bordered table-striped' id="tableToday">
                                                                            <%=Bkash_Today%>
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </p>
                                                    </div>
                                                    <div id='YesterdayBkash' class='tab-pane'>
                                                        <p>
                                                            <div class='widget-body'>
                                                                <div style='display: block;' class='widget-body-inner'>
                                                                    <div class='widget-main no-padding' style='height: 135px; overflow: auto;'>
                                                                        <table class='table table-bordered table-striped' id="tableYesterday">
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </p>
                                                    </div>
                                                    <div id='Last3daysBkash' class='tab-pane'>
                                                        <p>
                                                            <div class='widget-body'>
                                                                <div style='display: block;' class='widget-body-inner'>
                                                                    <div class='widget-main no-padding' style='height: 135px; overflow: auto;'>
                                                                        <table class='table table-bordered table-striped' id="tableLast3days">
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </p>
                                                    </div>
                                                    <div id='LastweekBkash' class='tab-pane'>
                                                        <p>
                                                            <div class='widget-body'>
                                                                <div style='display: block;' class='widget-body-inner'>
                                                                    <div class='widget-main no-padding' style='height: 135px; overflow: auto;'>
                                                                        <table class='table table-bordered table-striped' id="tableLastweek">
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </p>
                                                    </div>
                                                    <div id='MonthBkash' class='tab-pane'>
                                                        <p>
                                                            <div class='widget-body'>
                                                                <div style='display: block;' class='widget-body-inner'>
                                                                    <div class='widget-main no-padding' style='height: 135px; overflow: auto;'>
                                                                        <table class='table table-bordered table-striped' id="tableMonth">
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </p>
                                                    </div>
                                                    <div id='100Bkash' class='tab-pane'>
                                                        <p>
                                                            <div class='widget-body'>
                                                                <div style='display: block;' class='widget-body-inner'>
                                                                    <div class='widget-main no-padding' style='height: 135px; overflow: auto;'>
                                                                        <table class='table table-bordered table-striped' id="table100">
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </p>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <%--BKash, COD, OPS End--%>
                                </div>

                                <div class="hr hr32 hr-dotted">
                                </div>

                                <%--CRM Order (1,2)--%>

                                <div class="row">
                                    <div class="col-sm-6">

                                        <a href="#todayDelivery_First" class="btn btn-pink pull-right pop" id="todayDelivery_First" onclick="getDeliverySummary(this.id);">
                                            <i class="icon-cloud bigger-130"></i>
                                             CRM Order M1
                                        </a>

                                        <div class='widget-box transparent' style="display: none" id="DeliverySummaryId">
                                            <div class='widget-header widget-header-flat'>
                                                <h4 class='lighter'>
                                                    <i class='fa fa-futbol-o orange'></i> Info Delivery Summary</h4>
                                                <div class='widget-toolbar'>
                                                    <a href='#' data-action='collapse'><i class='icon-chevron-up'></i></a>
                                                </div>
                                            </div>
                                            <div class='tabbable'>
                                                <ul class='nav nav-tabs' id='Ul14' data-action="reload">
                                                    <li class='active'><a data-toggle='tab' href='#Deliverytoday' id="todayDelivery" onclick="getDeliverySummary(this.id)">
                                                        <i class='blue icon-home bigger-110'></i>Today</a></li>
                                                    <li><a data-toggle='tab' href='#Deliveryyesterday' id="yesterdayDelivery" onclick="getDeliverySummary(this.id)">
                                                        <i class='green icon-comment bigger-110'></i>Yesterday</a></li>
                                                    <li><a data-toggle='tab' href='#Deliverylast3day' id="last3dayDelivery" onclick="getDeliverySummary(this.id)">
                                                        <i class='green icon-comment-alt bigger-110'></i>Last 3 days</a></li>
                                                    <li><a data-toggle='tab' href='#Deliverylast7day' id="last7dayDelivery" onclick="getDeliverySummary(this.id)">
                                                        <i class='pink icon-comments bigger-110'></i>Last 7 Days</a></li>

                                                    <%--<li><a data-toggle='tab' href='#Deliverylast30day' id="last30dayDelivery" onclick="getDeliverySummary(this.id)">
                                                        <i class='pink icon-comments-alt bigger-110'></i>Last 30 Days</a></li>
                                                    <li><a data-toggle='tab' href='#Deliverylast100day' id="last100dayDelivery" onclick="getDeliverySummary(this.id)">
                                                        <i class='pink icon-comments-alt bigger-110'></i>Last 100 Days</a></li>--%>
                                                </ul>
                                                <div class='tab-content'>
                                                    <div id='Deliverytoday' class='tab-pane in active'>
                                                        <p>
                                                            <div class='widget-body'>
                                                                <div style='display: block;' class='widget-body-inner'>
                                                                    <div class='widget-main no-padding' style='height: 80px; overflow: auto;'>
                                                                        <table class='table table-bordered table-striped'>
                                                                            <thead class='thin-border-bottom'>
                                                                                <tr>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Total Delivery
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Late Delivery
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Avg LateDelivery
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Fast Delivery
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Avg FastDelivery
                                                                                    </th>
                                                                                </tr>
                                                                            </thead>
                                                                            <tbody id="Delivery1">
                                                                                <%=Delivery1%>
                                                                            </tbody>
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </p>
                                                    </div>
                                                    <div id='Deliveryyesterday' class='tab-pane'>
                                                        <p>
                                                            <div class='widget-body'>
                                                                <div style='display: block;' class='widget-body-inner'>
                                                                    <div class='widget-main no-padding' style='height: 80px; overflow: auto;'>
                                                                        <table class='table table-bordered table-striped'>
                                                                            <thead class='thin-border-bottom'>
                                                                                <tr>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Total Delivery
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Late Delivery
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Avg LateDelivery
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Fast Delivery
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Avg FastDelivery
                                                                                    </th>
                                                                                </tr>
                                                                            </thead>
                                                                            <tbody id="Delivery2">
                                                                            </tbody>
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </p>
                                                    </div>
                                                    <div id='Deliverylast3day' class='tab-pane'>
                                                        <p>
                                                            <div class='widget-body'>
                                                                <div style='display: block;' class='widget-body-inner'>
                                                                    <div class='widget-main no-padding' style='height: 80px; overflow: auto;'>
                                                                        <table class='table table-bordered table-striped'>
                                                                            <thead class='thin-border-bottom'>
                                                                                <tr>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Total Delivery
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Late Delivery
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Avg LateDelivery
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Fast Delivery
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Avg FastDelivery
                                                                                    </th>
                                                                                </tr>
                                                                            </thead>
                                                                            <tbody id="Delivery3">
                                                                            </tbody>
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </p>
                                                    </div>
                                                    <div id='Deliverylast7day' class='tab-pane'>
                                                        <p>
                                                            <div class='widget-body'>
                                                                <div style='display: block;' class='widget-body-inner'>
                                                                    <div class='widget-main no-padding' style='height: 80px; overflow: auto;'>
                                                                        <table class='table table-bordered table-striped'>
                                                                            <thead class='thin-border-bottom'>
                                                                                <tr>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Total Delivery
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Late Delivery
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Avg LateDelivery
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Fast Delivery
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Avg FastDelivery
                                                                                    </th>
                                                                                </tr>
                                                                            </thead>
                                                                            <tbody id="Delivery7">
                                                                            </tbody>
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </p>
                                                    </div>
                                                    <div id='Deliverylast30day' class='tab-pane'>
                                                        <p>
                                                            <div class='widget-body'>
                                                                <div style='display: block;' class='widget-body-inner'>
                                                                    <div class='widget-main no-padding' style='height: 80px; overflow: auto;'>
                                                                        <table class='table table-bordered table-striped'>
                                                                            <thead class='thin-border-bottom'>
                                                                                <tr>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Total Delivery
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Late Delivery
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Avg LateDelivery
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Fast Delivery
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Avg FastDelivery
                                                                                    </th>
                                                                                </tr>
                                                                            </thead>
                                                                            <tbody id="Delivery30">
                                                                            </tbody>
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </p>
                                                    </div>
                                                    <div id='Deliverylast100day' class='tab-pane'>
                                                        <p>
                                                            <div class='widget-body'>
                                                                <div style='display: block;' class='widget-body-inner'>
                                                                    <div class='widget-main no-padding' style='height: 80px; overflow: auto;'>
                                                                        <table class='table table-bordered table-striped'>
                                                                            <thead class='thin-border-bottom'>
                                                                                <tr>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Total Delivery
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Late Delivery
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Avg LateDelivery
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Fast Delivery
                                                                                    </th>
                                                                                    <th>
                                                                                        <i class='icon-caret-right blue'></i>Avg FastDelivery
                                                                                    </th>
                                                                                </tr>
                                                                            </thead>
                                                                            <tbody id="Delivery100">
                                                                            </tbody>
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </p>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="widget-box"  style="display: none" id="crmOrder1">
                                            <div class="widget-header header-color-green2">
                                                <h5 class="bigger lighter">
                                                    <i class="icon-cloud"></i>
                                                    CRM Order M1
                                                </h5>
                                                <div class="widget-toolbar">
                                                    <a href="#" data-action="settings">
                                                        <i class="icon-cog"></i>
                                                    </a>

                                                    <a href="#" data-action="reload">
                                                        <i class="icon-refresh"></i>
                                                    </a>

                                                    <a href="#" data-action="collapse">
                                                        <i class="icon-chevron-up"></i>
                                                    </a>

                                                    <a href="#" data-action="close">
                                                        <i class="icon-remove"></i>
                                                    </a>
                                                </div>
                                                <div class="widget-toolbar widget-toolbar-light no-border">
                                                    <select id="simple-colorpicker-1" class="hide">
                                                        <option selected="" data-class="green2" value="#2E8965">#2E8965</option>
                                                        <option data-class="blue2" value="#5090C1">#5090C1</option>
                                                        <option data-class="blue3" value="#6379AA">#6379AA</option>
                                                        <option data-class="green" value="#82AF6F">#82AF6F</option>
                                                        <option data-class="blue" value="#307ECC">#307ECC</option>
                                                        <option data-class="green3" value="#5FBC47">#5FBC47</option>
                                                        <option data-class="red" value="#E2755F">#E2755F</option>
                                                        <option data-class="red2" value="#E04141">#E04141</option>
                                                        <option data-class="red3" value="#D15B47">#D15B47</option>
                                                        <option data-class="orange" value="#FFC657">#FFC657</option>
                                                        <option data-class="purple" value="#7E6EB0">#7E6EB0</option>
                                                        <option data-class="pink" value="#CE6F9E">#CE6F9E</option>
                                                        <option data-class="dark" value="#404040">#404040</option>
                                                        <option data-class="grey" value="#848484">#848484</option>
                                                        <option data-class="default" value="#EEE">#EEE</option>
                                                    </select>
                                                </div>
                                            </div>

                                            <div class="widget-body">
                                                <div class="widget-main no-padding">
                                                    <table class="table table-striped table-bordered table-hover">
                                                        <thead class="thin-border-bottom">
                                                            <tr>
                                                                <th>
                                                                    <i class="icon-caret-right blue"></i>Name (M1)
                                                                </th>
                                                                <th>
                                                                    <i class="icon-caret-right blue"></i>Last 5th
                                                                </th>
                                                                <th>
                                                                    <i class="icon-caret-right blue"></i>Last 4th
                                                                </th>
                                                                <th>
                                                                    <i class="icon-caret-right blue"></i>Last 3rd
                                                                </th>
                                                                <th>
                                                                    <i class="icon-caret-right blue"></i>Yesterday
                                                                </th>
                                                                <th>
                                                                    <i class="icon-caret-right blue"></i>Today
                                                                </th>
                                                            </tr>
                                                        </thead>

                                                        <tbody>
                                                            <tr>
                                                                <td>Total Order
                                                                </td>
                                                                <td>
                                                                    <b>
                                                                        <%Response.Write(successOrderM1Last5th); %></b>
                                                                </td>
                                                                <td>
                                                                    <b>
                                                                        <%Response.Write(successOrderM1Last4th); %></b>
                                                                </td>
                                                                <td>
                                                                    <b>
                                                                        <%Response.Write(successOrderM1Last3rd); %></b>
                                                                </td>
                                                                <td>
                                                                    <b>
                                                                        <%Response.Write(successOrderM1Yesterday); %></b>
                                                                </td>
                                                                <td>
                                                                    <b>
                                                                        <%Response.Write(successOrderM1Today); %></b>
                                                                </td>
                                                            </tr>
                                                            <%Response.Write(tableShowM1); %>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-sm-6">

                                        <a href="#crmOrder2_First" class="btn btn-pink pop" id="crmOrder2_First"  onclick="getCrmOrderM2(this.id);">
                                            <i class="icon-cloud bigger-130"></i>
                                             CRM Order M2
                                        </a>

                                        <div class="widget-box" style="display: none" id="crmOrder2">
                                            <div class="widget-header header-color-red">
                                                <h5 class="bigger lighter">
                                                    <i class="icon-cloud"></i>
                                                    CRM Order M2
                                                </h5>
                                                <div class="widget-toolbar">
                                                    <a href="#" data-action="settings">
                                                        <i class="icon-cog"></i>
                                                    </a>

                                                    <a href="#" data-action="reload">
                                                        <i class="icon-refresh"></i>
                                                    </a>

                                                    <a href="#" data-action="collapse">
                                                        <i class="icon-chevron-up"></i>
                                                    </a>

                                                    <a href="#" data-action="close">
                                                        <i class="icon-remove"></i>
                                                    </a>
                                                </div>
                                                <div class="widget-toolbar widget-toolbar-light no-border">
                                                    <select id="simple-colorpicker-2" class="hide">
                                                        <option selected="" data-class="red" value="#E2755F">#E2755F</option>
                                                        <option data-class="blue2" value="#5090C1">#5090C1</option>
                                                        <option data-class="blue3" value="#6379AA">#6379AA</option>
                                                        <option data-class="green" value="#82AF6F">#82AF6F</option>
                                                        <option data-class="green2" value="#2E8965">#2E8965</option>
                                                        <option data-class="green3" value="#5FBC47">#5FBC47</option>
                                                        <option data-class="blue" value="#307ECC">#307ECC</option>
                                                        <option data-class="red2" value="#E04141">#E04141</option>
                                                        <option data-class="red3" value="#D15B47">#D15B47</option>
                                                        <option data-class="orange" value="#FFC657">#FFC657</option>
                                                        <option data-class="purple" value="#7E6EB0">#7E6EB0</option>
                                                        <option data-class="pink" value="#CE6F9E">#CE6F9E</option>
                                                        <option data-class="dark" value="#404040">#404040</option>
                                                        <option data-class="grey" value="#848484">#848484</option>
                                                        <option data-class="default" value="#EEE">#EEE</option>
                                                    </select>
                                                </div>
                                            </div>

                                            <div class="widget-body">
                                                <div class="widget-main no-padding">
                                                    <table class="table table-striped table-bordered table-hover">
                                                        <thead class="thin-border-bottom">
                                                            <tr>
                                                                <th>
                                                                    <i class="icon-caret-right blue"></i>Name (M2)
                                                                </th>
                                                                <th>
                                                                    <i class="icon-caret-right blue"></i>Last 5th
                                                                </th>
                                                                <th>
                                                                    <i class="icon-caret-right blue"></i>Last 4th
                                                                </th>
                                                                <th>
                                                                    <i class="icon-caret-right blue"></i>Last 3rd
                                                                </th>
                                                                <th>
                                                                    <i class="icon-caret-right blue"></i>Yesterday
                                                                </th>
                                                                <th>
                                                                    <i class="icon-caret-right blue"></i>Today
                                                                </th>
                                                            </tr>
                                                        </thead>

                                                        <tbody>
                                                            <tr>
                                                                <td>Total Order
                                                                </td>
                                                                <td>
                                                                    <b>
                                                                        <%Response.Write(successOrderM2Last5th); %></b>
                                                                </td>
                                                                <td>
                                                                    <b>
                                                                        <%Response.Write(successOrderM2Last4th); %></b>
                                                                </td>
                                                                <td>
                                                                    <b>
                                                                        <%Response.Write(successOrderM2Last3rd); %></b>
                                                                </td>
                                                                <td>
                                                                    <b>
                                                                        <%Response.Write(successOrderM2Yesterday); %></b>
                                                                </td>
                                                                <td>
                                                                    <b>
                                                                        <%Response.Write(successOrderM2Today); %></b>
                                                                </td>
                                                            </tr>
                                                            <%Response.Write(tableShowM2); %>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>

                <%--<div class="row">
                    <div class="col-lg-12">
                        <asp:Label ID="NeedToVerifyLabel" runat="server" Text=""></asp:Label>
                        <asp:Label ID="DealsEntryLabel" runat="server" Text=""></asp:Label>
                        <div class="table-header">
                            <asp:Label ID="UploadedDealsLabel" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="table-responsive" style="overflow: auto; height: 500px">
                            <asp:GridView ID="DealsGridView" runat="server" CssClass="table table-striped table-bordered table-hover"
                                AutoGenerateColumns="False">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.NO">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Inserted On">
                                        <ItemTemplate>
                                            <%#Eval("InsertedOn")%>
                                        </ItemTemplate>
                                        <ItemStyle Font-Bold="False" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Deal Title">
                                        <ItemTemplate>
                                            <%#Eval("DealTitle")%>(<%#Eval("DealId")%>)
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>--%>
            </div>
        </div>
        
    <!--Modal -->
        <div class="modal fade" id="Model1" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
            <div class="modal-dialog" role="document" style="width: 1300px;">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="myModalLabel">Details !!
                        </h4>
                        <div id="loadBusy" style="text-align: center; display: none;">
                            <img src="http://www.ajkerdeal.com/Images/search/Loading_image.gif" alt="Loading...">
                        </div>
                    </div>
                    <div class="modal-body">
                        <div id="BackLogsGrid">
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            Close</button>
                    </div>
                </div>
            </div>
        </div>
        <!---END-->
        <!--Modal -->
        <div class="modal fade bs-example-modal-lg" id="GetDeal" tabindex="-1" role="dialog"
            aria-labelledby="myModalLabel">
            <div class="modal-dialog modal-lg" role="document" style="width: 1250px;">
                <div class="modal-content" style="text-align: center;">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="H1">Coupon Details
                        </h4>
                        <div id="loadBusy2" style="text-align: center; display: none;">
                            <img src="http://www.ajkerdeal.com/Images/search/Loading_image.gif" alt="Loading..." />
                        </div>
                    </div>
                    <div class="modal-body">
                        <div id="DataModelPopUp">
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            Close</button>
                    </div>
                </div>
            </div>
        </div>
        <!---END-->
        <%-- </div>--%>
    </form>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>
    <script src="http://www.ajkerdeal.com/css/AdminNew/assets/js/jquery-ui-1.10.3.full.min.js" type="text/javascript"></script>
    <script src="http://www.ajkerdeal.com/css/AdminNew/assets/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="http://www.ajkerdeal.com/css/AdminNew/assets/js/typeahead-bs2.min.js" type="text/javascript"></script>
    <script src="http://www.ajkerdeal.com/css/AdminNew/assets/js/jquery.easy-pie-chart.min.js" type="text/javascript"></script>
    <script src="http://www.ajkerdeal.com/css/AdminNew/assets/js/jquery.sparkline.min.js" type="text/javascript"></script>
    <script src="http://www.ajkerdeal.com/css/AdminNew/assets/js/flot/jquery.flot.min.js" type="text/javascript"></script>
    <script src="http://www.ajkerdeal.com/css/AdminNew/assets/js/flot/jquery.flot.pie.min.js" type="text/javascript"></script>
    <script src="http://www.ajkerdeal.com/css/AdminNew/assets/js/flot/jquery.flot.resize.min.js" type="text/javascript"></script>

    <script src="http://www.ajkerdeal.com/css/AdminNew/assets/js/jquery.slimscroll.min.js"></script>

    <!-- Pie Chart -->
    <%--<script src="http://code.highcharts.com/highcharts.js"></script>
    <script src="http://code.highcharts.com/highcharts-3d.js"></script>
    <script src="http://code.highcharts.com/modules/exporting.js"></script>--%>

    <script src="http://www.ajkerdeal.com/css/AdminNew/assets/js/highcharts/highcharts.js"></script>
    <script src="http://www.ajkerdeal.com/css/AdminNew/assets/js/highcharts/exporting.js"></script>

    <!-- ace scripts -->
    <script src="http://www.ajkerdeal.com/css/AdminNew/assets/js/ace-elements.min.js" type="text/javascript"></script>
    <script src="http://www.ajkerdeal.com/css/AdminNew/assets/js/ace.min.js" type="text/javascript"></script>

    <script type="text/javascript">

        var chartData;
        google.load('visualization', '1', { packages: ['corechart'] });

        //$(window).scroll(function () {
        //    if ($(window).scrollTop() == $(document).height() - $(window).height()) {

        //        GetRecords();
        //        document.getElementById('PielineChart').style.display = "block";
        //    }
        //});
        //GetRecords();
        // $(document).ready(function () {
        function GetRecords() {
            //alert("Line Chart");
            $.ajax({

                url: window.location.origin + window.location.pathname + "/GetChartData",
                data: "",
                dataType: "json",
                type: "POST",
                //async: true,
                //cache: false,
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    chartData = data.d;
                    //alert(data['d']);
                },
                error: function () {
                    alert("Error in loading Line Chart");
                }
            }).done(function () {
                drawChart();

            });
        };
        //});
        //    }
        //});

        function drawChart() {

            var data = google.visualization.arrayToDataTable(chartData);

            var options = {
                title: "Order Stats line chart",
                pointSize: 4,
                width: '100%',
                height: 300,
                lineWidth: 2

            };

            //var lineChart = new google.visualization.PieChart(document.getElementById('Sales-Star'));
            var lineChart = new google.visualization.LineChart(document.getElementById('Sales-Star'));
            lineChart.draw(data, options);
        }

    </script>

    <%--<script type="text/javascript">
        google.load('visualization', '1.1', { packages: ['line'] });
        google.setOnLoadCallback(drawChart);

        function drawChart() {

            var data = new google.visualization.DataTable();
            data.addColumn('number', 'Day');
            data.addColumn('number', 'Total Order');
            data.addColumn('number', 'Courier');
            data.addColumn('number', 'By Confirmation Date');
            data.addColumn('number', 'By Ordering Date');

            data.addRows([
            
            <%=SaleStatsString %>
            ]);

            var options = {
                //                chart: {
                //                    title: 'Box Office Earnings in First Two Weeks of Opening',
                //                    subtitle: 'in millions of dollars (USD)'
                //                },
                width: '100%',
                height: 250,
                axes: {
                    x: {
                        0: { side: 'top' }
                    }
                }
            };

            var chart = new google.charts.Line(document.getElementById('Sales-Star'));

            chart.draw(data, options);
        }
    </script>--%>
    <script type="text/javascript">
        jQuery(function ($) {
            $('[data-rel=tooltip]').tooltip();

            $('.easy-pie-chart.percentage').each(function () {
                var $box = $(this).closest('.infobox');
                var barColor = $(this).data('color') || (!$box.hasClass('infobox-dark') ? $box.css('color') : 'rgba(255,255,255,0.95)');
                var trackColor = barColor == 'rgba(255,255,255,0.95)' ? 'rgba(255,255,255,0.25)' : '#E2E2E2';
                var size = parseInt($(this).data('size')) || 50;
                $(this).easyPieChart({
                    barColor: barColor,
                    trackColor: trackColor,
                    scaleColor: false,
                    lineCap: 'butt',
                    lineWidth: parseInt(size / 10),
                    animate: /msie\s*(8|7|6)/.test(navigator.userAgent.toLowerCase()) ? false : 1000,
                    size: size
                });
            })

            $('.sparkline').each(function () {
                var $box = $(this).closest('.infobox');
                var barColor = !$box.hasClass('infobox-dark') ? $box.css('color') : '#FFF';
                $(this).sparkline('html', { tagValuesAttribute: 'data-values', type: 'bar', barColor: barColor, chartRangeMin: $(this).data('min') || 0 });
            });

        });
    </script>

    <%--<script type="text/javascript">
        $(function () {
            $('#piechart-status').highcharts({
                chart: {
                    type: 'pie',
                    options3d: {
                        enabled: true,
                        alpha: 45
                    }
                },
                title: {
                    text: 'CRM Order Processing (Today)'
                },
                subtitle: {
                    text: 'Total Order Processing ' +<%=Total_CRM_Order_Processing %>
                    },

                plotOptions: {
                    pie: {
                        innerSize: 100,
                        depth: 45,
                        cursor: 'pointer'
                    }
                },

                series: [{
                    name:'Order',
                    data: [{
                        name: 'Merchant Cancel',
                        color: '#E9967A',
                        y: <%=CancelMerchantReports %>
                        }, {
                            name: 'New Order',
                            color: 'yellow',
                            y: <%=NewOrderReports %>
                            }, {
                                name:'COD OutSide Dhaka',
                                color: '#00BFFF',
                                y: <%=COD_OutSideDhaka %>
                                },{
                                    name: 'Follow Up',
                                    color: 'cyan',
                                    y: <%=FollowUpReports %>
                                    }, {
                                        name: 'AjkerDeal Cancel',
                                        color: 'red',
                                        y: <%=CancelAjkerDealReports %>
                                        },{
                                            name: 'Repeated Order',
                                            color: '#F16E52',
                                            y: <%=CancelRepertedOrder %>
                                            },{
                                                name:'CRM Processed Model1',
                                                color:'#CCFFFF',
                                                y: <%=CRM_ProcessedModel1 %>
                                                },{
                                                    name:'CRM Processed Model2',
                                                    color:'#DEB887',
                                                    y:<%=CRM_ProcessedModel2 %>
                                                    },{
                                                        name:'After CRM Processed',
                                                        color:'#CCCCCC',
                                                        y:<%=After_CRM_Processed %>
                                                        }]
                }]

            });
        });
    </script>--%>



    <script type="text/javascript">
        //$(document).ready(function () {
        //loadData();

        //$(window).scroll(function () {
        //    if ($(window).scrollTop() == $(document).height() - $(window).height()) {
        //        loadData();
        //    }
        //});

        function loadData() {
            //alert("load Pie");
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                //url: "ControlPanel.aspx/PieChartAnalysis",
                url: window.location.origin + window.location.pathname + "/PieChartAnalysis",
                data: "{}",
                dataType: "json",
                //async: true,
                //cache: false,
                success: function (Result) {
                    Result = Result.d;
                    var data = [];
                    for (var i in Result) {
                        var serie = new Array(Result[i].Name, Result[i].Value);
                        data.push(serie);
                    }

                    DreawChart(data);
                },
                error: function (Result) {
                    alert("Error in pie chart");
                }
            });

        };


        //});

        function DreawChart(series) {

            $('#pieChart').highcharts({
                chart: {

                    plotBackgroundColor: null,
                    plotBorderWidth: 1,
                    plotShadow: false,
                    backgroundColor: {
                        linearGradient: [0, 0, 500, 500],
                        stops: [
                    [0, 'rgb(255, 255, 255)'],
                    [1, 'rgb(200, 200, 255)']
                        ]
                    }
                },
                title: {
                    text: 'CRM Order Processing (Today)'
                },
                tooltip: {
                    //pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                    pointFormat: '{series.name}: <b>{point.y:1f}</b>'
                },
                plotOptions: {
                    pie: {
                        allowPointSelect: true,
                        cursor: 'pointer',
                        dataLabels: {
                            enabled: true,
                            //format: '<b>{point.name}</b>: {point.percentage:.1f} %',
                            format: '<b>{point.name}</b>: {point.y:1f}',
                            style: {
                                color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black'

                            }
                        }
                    }
                },
                series: [{
                    type: 'pie',
                    name: 'CRM Order',
                    data: series
                }]

            });
        }
    </script>

    <script type="text/javascript">
        function GetOrderModel(CaseData) {
            $.ajax({
                beforeSend: function () {
                    $('#loadBusy').show();
                },
                complete: function () {
                    $('#loadBusy').hide();
                },
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: window.location.origin + window.location.pathname + "/GetOrderModel",
                data: "{ \'whichTypeOfModel\': \'" + CaseData + "\' }",
                dataType: "json",
                async: true,
                cache: false,
                success: function (data) {
                    document.getElementById('BackLogsGrid').innerHTML = data.d;
                },
                error: function (result) {
                    alert("Error In Control Panel");
                }
            });
        }
    </script>
    <script type="text/javascript">
        function GetOrderModelStatus(CaseData) {
            var Status = CaseData.split("-");

            var CaseData2 = Status[0];
            var Day = Status[1];

            $.ajax({
                beforeSend: function () {
                    $('#loadBusy').show();
                },
                complete: function () {
                    $('#loadBusy').hide();
                },
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: window.location.origin + window.location.pathname + "/GetOrderModelStatus",
                data: "{ \'whichTypeOfStatus\': \'" + CaseData2 + "\', \'Day\': \'" + Day + "\' }",
                dataType: "json",
                async: true,
                cache: false,
                success: function (data) {
                    document.getElementById('BackLogsGrid').innerHTML = data.d;
                },
                error: function (result) {
                    alert("Error");
                }
            });
        }
    </script>

    <script type="text/javascript">
        function GetDetailsPopup(CouponId) {

            $.ajax({
                beforeSend: function () {
                    $('#loadBusy3').show();
                },
                complete: function () {
                    $('#loadBusy3').hide();
                },
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: window.location.origin + window.location.pathname + "/LoadComments",
                data: "{ \'CouponId\': \'" + CouponId + "\' }",
                dataType: "json",
                async: true,
                cache: false,
                success: function (data) {
                    document.getElementById('DataModelPopUp').innerHTML = data.d;
                },
                error: function (result) {
                    alert("Error");
                }
            });
        }
    </script>

    <script type="text/javascript">
        function GetPerformingMerchantgCategoryDetails(CouponId) {

            $.ajax({
                beforeSend: function () {
                    $('#loadBusy2').show();
                },
                complete: function () {
                    $('#loadBusy2').hide();
                },
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: window.location.origin + window.location.pathname + "/GetDetailsPopupMethod",
                data: "{ \'CouponId\': \'" + CouponId + "\' }",
                dataType: "json",
                async: true,
                cache: false,
                success: function (data) {
                    document.getElementById('DataModelPopUp').innerHTML = data.d;
                },
                error: function (result) {
                    alert("Coupon Details Error");
                }
            });
        }
    </script>


    <script type="text/javascript">

        function getPerformingMerchant(strId, Check) {

            $.ajax({
                beforeSend: function () {
                    //$('#loadBusy3').show();
                },
                complete: function () {
                    //$('#loadBusy3').hide();
                },
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: window.location.origin + window.location.pathname + "/LoadPerformingMerchant",
                data: "{ \'strId\': \'" + strId + "\', \'Check\': \'" + Check + "\' }",
                dataType: "json",
                async: true,
                cache: false,
                success: function (data) {

                    if (strId == "100Day") {
                        document.getElementById('PerformingMerchant_100').innerHTML = data['d'];
                    }
                    else if (strId == "Month1") {
                        document.getElementById('PerformingMerchant_Month').innerHTML = data['d'];
                    }

                    else if (strId == "weekLast") {
                        document.getElementById('PerformingMerchant_Lastweek').innerHTML = data['d'];
                    }

                    else if (strId == "daysLast3") {
                        document.getElementById('PerformingMerchant_Last3days').innerHTML = data['d'];
                    }

                    else if (strId == "dayYester") {
                        document.getElementById('PerformingMerchant_YesterDay').innerHTML = data['d'];
                    }

                    else if (strId == "dayTo") {
                        document.getElementById('PerformingMerchant_Today').innerHTML = data['d'];
                    }

                    else if (strId == "100Day2") {
                        document.getElementById('PerformingCategory_100').innerHTML = data['d'];
                    }
                    else if (strId == "Month2") {
                        document.getElementById('PerformingCategory_Month').innerHTML = data['d'];
                    }

                    else if (strId == "weekLast2") {
                        document.getElementById('PerformingCategory_Lastweek').innerHTML = data['d'];
                    }

                    else if (strId == "daysLast32") {
                        document.getElementById('PerformingCategory_Last3days').innerHTML = data['d'];
                    }

                    else if (strId == "dayYester2") {
                        document.getElementById('PerformingCategory_YesterDay').innerHTML = data['d'];
                    }

                    else if (strId == "dayTo2") {
                        document.getElementById('PerformingCategory_Today').innerHTML = data['d'];
                    }

                },
                error: function (result) {
                    alert("Error in loading");
                }
            });
        }
    </script>

    <script type="text/javascript">

        function getPerformingCategory(strId) {

            $.ajax({
                beforeSend: function () {
                    //$('#loadBusy3').show();
                },
                complete: function () {
                    //$('#loadBusy3').hide();
                },
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: window.location.origin + window.location.pathname + "/LoadPerformingCategory",
                data: "{ \'strId\': \'" + strId + "\'}",
                dataType: "json",
                async: true,
                cache: false,
                success: function (data) {

                    if (strId == "dayToCa") {
                        document.getElementById('PerformingMainCategory_Today').innerHTML = data['d'];
                    }

                    else if (strId == "dayYesterCa") {
                        document.getElementById('PerformingMainCategory_YesterDay').innerHTML = data['d'];
                    }

                    else if (strId == "daysLast3Ca") {
                        document.getElementById('PerformingMainCategory_Last3days').innerHTML = data['d'];
                    }

                    else if (strId == "weekLastCa") {
                        document.getElementById('PerformingMainCategory_Lastweek').innerHTML = data['d'];
                    }
                },
                error: function (result) {
                    alert("Error in loading Performing Category");
                }
            });
        }
    </script>


    <script type="text/javascript">

        //$(window).scroll(function () {
        //    if ($(window).scrollTop() == $(document).height() - $(window).height()) {
        //        var strId = "BkashToday";
        //        getBKashCODOPS(strId);
        //        document.getElementById('bKashId').style.display = "block";
        //        //document.getElementById('WishlistId').style.display = "block";
        //        //document.getElementById('WishbKash').style.display = "block";

        //    }
        //});

        function getBKashCODOPS(strId) {

            document.getElementById('bKashId').style.display = "block";
            document.getElementById('BkashToday_First').style.display = "none";

            $.ajax({
                beforeSend: function () {
                    //$('#loadBusy3').show();
                },
                complete: function () {
                    //$('#loadBusy3').hide();
                },
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: window.location.origin + window.location.pathname + "/LoadBKashCODOPS",
                data: "{ \'strId\': \'" + strId + "\'}",
                dataType: "json",
                async: true,
                cache: false,
                success: function (data) {

                    if (strId == "BkashToday_First") {
                        document.getElementById('tableToday').innerHTML = data['d'];
                    }

                    else if (strId == "Bkash100") {
                        document.getElementById('table100').innerHTML = data['d'];
                    }

                    else if (strId === "BkashMonth") {
                        document.getElementById('tableMonth').innerHTML = data['d'];
                    }

                    else if (strId == "BkashLastweek") {
                        document.getElementById('tableLastweek').innerHTML = data['d'];
                    }

                    else if (strId == "BkashLast3days") {
                        document.getElementById('tableLast3days').innerHTML = data['d'];
                    }

                    else if (strId == "BkashYesterday") {
                        document.getElementById('tableYesterday').innerHTML = data['d'];
                    }

                    else if (strId == "BkashToday") {
                        document.getElementById('tableToday').innerHTML = data['d'];
                    }

                },
                error: function (result) {
                    alert("Error in loading Bkash");
                }
            });
        }

    </script>


    <script type="text/javascript">
        function GetPerformingMerchantPopUp2(Data) {

            var Status = Data.split("-");
            var CompanyId = Status[0];
            var startDate = Status[1];
            var endDate = Status[2];
            var Check = Status[3];

            $.ajax({
                beforeSend: function () {
                    $('#loadBusy').show();
                },
                complete: function () {
                    $('#loadBusy').hide();
                },
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: window.location.origin + window.location.pathname + "/GetPerformingMerchantPopUp",

                data: "{ \'CompanyId\': \'" + CompanyId + "\', \'startDate\': \'" + startDate + "\', \'endDate\': \'" + endDate + "\', \'Check\': \'" + Check + "\' }",
                dataType: "json",
                async: true,
                cache: false,
                success: function (data) {
                    // alert(data['d']);
                    document.getElementById('BackLogsGrid').innerHTML = data['d'];
                },
                error: function (result) {
                    alert("Error in loading Performing");
                }
            });
        }
    </script>


    <script type="text/javascript">
        function GetPerformingMerchantPopUp(Data) {

            var Status = Data.split("-");
            var CompanyId = Status[0];
            var startDate = Status[1];
            var endDate = Status[2];
            var Check = Status[3];

            $.ajax({
                beforeSend: function () {
                    $('#loadBusy').show();
                },
                complete: function () {
                    $('#loadBusy').hide();
                },
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: window.location.origin + window.location.pathname + "/GetPerformingMerchantPopUp",

                data: "{ \'CompanyId\': \'" + CompanyId + "\', \'startDate\': \'" + startDate + "\', \'endDate\': \'" + endDate + "\', \'Check\': \'" + Check + "\' }",
                dataType: "json",
                async: true,
                cache: false,
                success: function (data) {
                    // alert(data['d']);
                    document.getElementById('BackLogsGrid').innerHTML = data['d'];
                },
                error: function (result) {
                    alert("Error in loading Performing");
                }
            });
        }
    </script>



    <script type="text/javascript">

        function getWishList() {

            document.getElementById('WishlistId').style.display = "block";
            document.getElementById('btnWishList').style.display = "none";

            $.ajax({
                beforeSend: function () {
                    //$('#loadBusy3').show();
                },
                complete: function () {
                    //$('#loadBusy3').hide();
                },
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: window.location.origin + window.location.pathname + "/WishList",
                data: "{}",
                dataType: "json",
                async: true,
                cache: false,
                success: function (data) {

                    var valueSplit = data['d'].split("-");
                    var CountOrderMainSite = valueSplit[0];
                    var CountOrderMobileSite = valueSplit[1]

                    var CountOrderMainSiteUnique = valueSplit[2];
                    var CountOrderMobileSiteUnique = valueSplit[3]

                    var NewMerchant = valueSplit[4];
                    var avgReturnShopper = valueSplit[5]

                    var CountFavMainSite = valueSplit[6];
                    var CountFavMobileSite = valueSplit[7]

                    var CountFavMainSiteUnique = valueSplit[8];
                    var CountFavMobileSiteUnique = valueSplit[9]

                    document.getElementById('CountOrderMainSite').innerHTML = CountOrderMainSite;
                    document.getElementById('CountOrderMobileSite').innerHTML = CountOrderMobileSite;

                    document.getElementById('CountOrderMainSiteUnique').innerHTML = CountOrderMainSiteUnique;
                    document.getElementById('CountOrderMobileSiteUnique').innerHTML = CountOrderMobileSiteUnique;

                    document.getElementById('NewMerchant').innerHTML = NewMerchant;
                    document.getElementById('avgReturnShopper').innerHTML = avgReturnShopper;

                    document.getElementById('CountFavMainSite').innerHTML = CountFavMainSite;
                    document.getElementById('CountFavMobileSite').innerHTML = CountFavMobileSite;

                    document.getElementById('CountFavMainSiteUnique').innerHTML = CountFavMainSiteUnique;
                    document.getElementById('CountFavMobileSiteUnique').innerHTML = CountFavMobileSiteUnique;


                },
                error: function (result) {
                    alert("Error in loading WishList");
                }
            });
        }
    </script>


    <script type="text/javascript">

        //$(window).scroll(function () {
        //    if ($(window).scrollTop() == $(document).height() - $(window).height()) {
        //        var strId = "todayDeal";
        //        getDealMerchant(strId);
        //        document.getElementById('DealMerchantId').style.display = "block";
        //        document.getElementById('UniqueDealMerchant').style.display = "block";
        //    }
        //});

        function getDealMerchant(strId) {
            document.getElementById('DealMerchantId').style.display = "block";
            document.getElementById('todayDeal_First').style.display = "none";
            $.ajax({
                beforeSend: function () {
                    //$('#loadBusy3').show();
                },
                complete: function () {
                    //$('#loadBusy3').hide();
                },
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: window.location.origin + window.location.pathname + "/LoadDealMerchant",
                data: "{ \'strId\': \'" + strId + "\' }",
                dataType: "json",
                async: true,
                cache: false,
                success: function (data) {

                    if (strId == "todayDeal_First") {
                        document.getElementById('Deal1').innerHTML = data['d'];
                    }

                    else if (strId == "todayDeal") {
                        document.getElementById('Deal1').innerHTML = data['d'];
                    }
                    else if (strId == "yesterdayDeal") {
                        document.getElementById('Deal2').innerHTML = data['d'];
                    }

                    else if (strId == "last3dayDeal") {
                        document.getElementById('Deal3').innerHTML = data['d'];
                    }

                    else if (strId == "last7dayDeal") {
                        document.getElementById('Deal7').innerHTML = data['d'];
                    }

                    else if (strId == "last30dayDeal") {
                        document.getElementById('Deal30').innerHTML = data['d'];
                    }

                    else if (strId == "last100dayDeal") {
                        document.getElementById('Deal100').innerHTML = data['d'];
                    }

                },
                error: function (result) {
                    alert("Error in loading Unique Deal-Merchant");
                }
            });
        }
    </script>


    <script type="text/javascript">

        //$(window).scroll(function () {
        //    if ($(window).scrollTop() == $(document).height() - $(window).height()) {
        //        var strId = "todayCrazy";
        //        getCrazyDeal(strId);
        //        document.getElementById('InfoCrazyDealId').style.display = "block";
        //    }
        //});


        function getCrazyDeal(strId) {

            document.getElementById('InfoCrazyDealId').style.display = "block";
            document.getElementById('todayCrazy_First').style.display = "none";
            $.ajax({
                beforeSend: function () {
                    //$('#loadBusy3').show();
                },
                complete: function () {
                    //$('#loadBusy3').hide();
                },
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: window.location.origin + window.location.pathname + "/LoadDealCrazy",
                data: "{ \'strId\': \'" + strId + "\' }",
                dataType: "json",
                async: true,
                cache: false,
                success: function (data) {


                    if (strId == "todayCrazy_First") {
                        document.getElementById('Crazy1').innerHTML = data['d'];
                    }

                    else if (strId == "todayCrazy") {
                        document.getElementById('Crazy1').innerHTML = data['d'];
                    }
                    else if (strId == "yesterdayCrazy") {
                        document.getElementById('Crazy2').innerHTML = data['d'];
                    }

                    else if (strId == "last3dayCrazy") {
                        document.getElementById('Crazy3').innerHTML = data['d'];
                    }

                    else if (strId == "last7dayCrazy") {
                        document.getElementById('Crazy7').innerHTML = data['d'];
                    }

                    else if (strId == "last30dayCrazy") {
                        document.getElementById('Crazy30').innerHTML = data['d'];
                    }

                    else if (strId == "last100dayCrazy") {
                        document.getElementById('Crazy100').innerHTML = data['d'];
                    }

                },
                error: function (result) {
                    alert("Error in loading Unique Crazy Deal");
                }
            });
        }
    </script>

    

    <script type="text/javascript">

        function getCrmOrderM2() {

            document.getElementById('crmOrder2_First').style.display = "none";
            document.getElementById('crmOrder2').style.display = "block";

            $.ajax({
                beforeSend: function () {
                    //$('#loadBusy3').show();
                },
                complete: function () {
                    //$('#loadBusy3').hide();
                },
                type: "POST",
                contentType: "application/json; charset=utf-8",
                //url: window.location.origin + window.location.pathname + "/LoadDeliverySummary",
                data: "{ }",
                dataType: "json",
                async: true,
                cache: false,
                success: function (data) {
                    

                },
                error: function (result) {
                    //alert("Error in loading Crm Order M2");
                }
            });
        }
    </script>



    <script type="text/javascript">

        //$(window).scroll(function () {
        //    if ($(window).scrollTop() == $(document).height() - $(window).height()) {
        //        var strId = "todayDelivery";

        //        getDeliverySummary(strId);
        //        document.getElementById('crmOrderDelivery').style.display = "block";
        //        document.getElementById('DeliverySummaryId').style.display = "block";
        //        document.getElementById('crmOrder2').style.display = "block";

        //    }
        //});

        function getDeliverySummary(strId) {
            document.getElementById('DeliverySummaryId').style.display = "block";
            document.getElementById('crmOrder1').style.display = "block";
            document.getElementById('todayDelivery_First').style.display = "none";

            $.ajax({
                beforeSend: function () {
                    //$('#loadBusy3').show();
                },
                complete: function () {
                    //$('#loadBusy3').hide();
                },
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: window.location.origin + window.location.pathname + "/LoadDeliverySummary",
                data: "{ \'strId\': \'" + strId + "\' }",
                dataType: "json",
                async: true,
                cache: false,
                success: function (data) {


                    if (strId == "todayDelivery_First") {
                        document.getElementById('Delivery1').innerHTML = data['d'];
                    }

                    else if (strId == "todayDelivery") {
                        document.getElementById('Delivery1').innerHTML = data['d'];
                    }
                    else if (strId == "yesterdayDelivery") {
                        document.getElementById('Delivery2').innerHTML = data['d'];
                    }

                    else if (strId == "last3dayDelivery") {
                        document.getElementById('Delivery3').innerHTML = data['d'];
                    }

                    else if (strId == "last7dayDelivery") {
                        document.getElementById('Delivery7').innerHTML = data['d'];
                    }

                    else if (strId == "last30dayDelivery") {
                        document.getElementById('Delivery30').innerHTML = data['d'];
                    }

                    else if (strId == "last100dayDelivery") {
                        document.getElementById('Delivery100').innerHTML = data['d'];
                    }

                },
                error: function (result) {
                    alert("Error in loading Delivery Summary Report");
                }
            });
        }
    </script>


    


    <script type="text/javascript">
        jQuery(function ($) {

            $('#simple-colorpicker-1').ace_colorpicker({ pull_right: true }).on('change', function () {
                var color_class = $(this).find('option:selected').data('class');
                var new_class = 'widget-header';
                if (color_class != 'default') new_class += ' header-color-' + color_class;
                $(this).closest('.widget-header').attr('class', new_class);
            });

            $('#simple-colorpicker-12').ace_colorpicker({ pull_right: true }).on('change', function () {
                var color_class = $(this).find('option:selected').data('class');
                var new_class = 'widget-header';
                if (color_class != 'default') new_class += ' header-color-' + color_class;
                $(this).closest('.widget-header').attr('class', new_class);
            });

            $('#simple-colorpicker-2').ace_colorpicker({ pull_right: true }).on('change', function () {
                var color_class = $(this).find('option:selected').data('class');
                var new_class = 'widget-header';
                if (color_class != 'default') new_class += ' header-color-' + color_class;
                $(this).closest('.widget-header').attr('class', new_class);
            });



            // scrollables
            $('.slim-scroll').each(function () {
                var $this = $(this);
                $this.slimScroll({
                    height: $this.data('height') || 100,
                    railVisible: true
                });
            });

            /**$('.widget-box').on('ace.widget.settings' , function(e) {
                e.preventDefault();
            });*/



            // Portlets (boxes)
            $('.widget-container-span').sortable({
                connectWith: '.widget-container-span',
                items: '> .widget-box',
                opacity: 0.8,
                revert: true,
                forceHelperSize: true,
                placeholder: 'widget-placeholder',
                forcePlaceholderSize: true,
                tolerance: 'pointer'
            });


        });
    </script>


    <script type="text/javascript">
        function SoldOutProduct(DealId,userId) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "Service/AdminService/ControlPanelService.asmx/SoldOutProduct",
                data: "{ \'DealId\': \'" + DealId + "\',\'userId\': \'" + userId + "\' }",
                dataType: "json",
                async: true,
                cache: false,
                success: function (data) {
                    var Result = data['d'];
                    if (DealId = Result) {
                        document.getElementById(DealId).innerHTML = "<b style='color:red;cursor:pointer;'>Yes</b>";
                    }
                },
                error: function (result) {
                    alert("Error in Sold-Out");
                }
            });
        }
    </script>

</body>
</html>