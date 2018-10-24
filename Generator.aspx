<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Generator.aspx.cs" Inherits="admin_ControlPanelAdmin" %>
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
                            <li><i class="icon-home home-icon"></i><a href="ControlPanel.aspx">Home</a> </li>
                            <li class="active">Control Panel</li>
                        </ul>
                        <!-- .breadcrumb -->
                    </div>
                   <div class="row">
                       <%

                         using (UserLoginGateway objUserLoginGateway = new UserLoginGateway())
                         {
                             int checkAccess = 0;
                             DataTable dataTable = objUserLoginGateway.CheckLogin(CurrentUser);
                             checkAccess = Convert.ToInt32(dataTable.Rows[0]["AllowOutsideAccess"].ToString());
                             string pathLink = ResolveUrl("~/");
                             string VisitorsIP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();

                             if (!((VisitorsIP == "163.53.150.123") || (VisitorsIP == "103.36.100.154") || (VisitorsIP == "163.53.150.122") || ((checkAccess == 1) && (intUserId == 64) || (intUserId == 1) || (intUserId == 3) || (intUserId == 21) || (intUserId == 95) || (intUserId == 57) || (intUserId == 68))))
                             {
                                 Response.Redirect(pathLink, false);
                             }

                         } 
                         
                         %>
                          <p class='center'>
                            ALL HOME PRODUCT ENTRY
                         </p>
                         <p class="center">
                               
                                    <a href='http://www.ajkerdeal.com/admin/HomeProductBlock/HomeProductBlockEntry.aspx' class='btn btn-info' data-rel='tooltip' data-original-title='Home Product Block Entry' title='' style='margin-top:4px'>Home Product Block Entry</a>
                                    <a href='http://www.ajkerdeal.com/admin/HomeProductBlock/HomeProductDealIdEntry.aspx' class='btn btn-info' data-rel='tooltip' data-original-title='Home Product DealId Entry' title='' style='margin-top:4px'>Home Product DealId Entry</a>
                                    <a href='http://www.ajkerdeal.com/admin/HomeProductBlock/HomeProductEntry.aspx' class='btn btn-info' data-rel='tooltip' data-original-title='Home Product Entry' title='' style='margin-top:4px'>Home Product Entry</a>
                                   
                         </p>
                         <p class='center'>
                            ALL DESKTOP HTML GENERATOR
                         </p>
                                    <p class='center'>
                                         
                                    
                                    <a href='http://www.ajkerdeal.com/admin/HTMLGenerator/FistLoadCrazyDealsHtmlGenerator.aspx' class='btn btn-info' data-rel='tooltip' data-original-title='Fist Load Crazy Deals Html Generator' title='' style='margin-top:4px' target="_blank">Fist Load Crazy Deals Generator</a>
                                    <a href='http://www.ajkerdeal.com/admin/HTMLGenerator/CrazyDealsHtmlGenerator.aspx' class='btn btn-info' data-rel='tooltip' data-original-title='All Crazy Deal Load' title='' style='margin-top:4px' target="_blank">All Crazy Deal Load</a>
                                    <a href='http://www.ajkerdeal.com/admin/HTMLGenerator/HomePageProduct.aspx' class='btn btn-info' data-rel='tooltip' data-original-title='Home Page Product' title='' style='margin-top:4px' target="_blank">Home Page Product</a>
                                    <a href='http://www.ajkerdeal.com/admin/HTMLGenerator/HomePageTopBanner.aspx' class='btn btn-info' data-rel='tooltip' data-original-title='Home Page Top Banner' title='' style='margin-top:4px' target="_blank">Home Page Top Banner</a>
                                    <a href='http://www.ajkerdeal.com/admin/HTMLGenerator/HomePopularSearch.aspx' class='btn btn-info' data-rel='tooltip' data-original-title='Home Popular Search' title='' style='margin-top:4px' target="_blank">Home Popular Search</a>
                                    <a href='http://www.ajkerdeal.com/admin/HTMLGenerator/MegaLeftMenu.aspx' class='btn btn-info' data-rel='tooltip' data-original-title='Mega Menu Generator' title='' style='margin-top:4px' target="_blank">Mega Menu Generator</a>
                                  
                                    </p>

                                </div> 
                </div>

        
   
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

</body>
</html>