<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="admin_DefaultAdmin" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Login Page : Admin Panel</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="http://www.ajkerdeal.com/css/AdminNew/assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="http://www.ajkerdeal.com/css/AdminNew/assets/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="http://www.ajkerdeal.com/css/AdminNew/assets/css/ace-fonts.css" rel="stylesheet" type="text/css" />
    <link href="http://www.ajkerdeal.com/css/AdminNew/assets/css/ace.min.css" rel="stylesheet" type="text/css" />
    <link href="http://www.ajkerdeal.com/css/AdminNew/assets/css/ace-rtl.min.css" rel="stylesheet" type="text/css" />
    <link href="http://www.ajkerdeal.com/css/admin/Report/hover.css" rel="stylesheet" type="text/css" />
    <%--Online--%>
    <link rel="stylesheet" href="//maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>
</head>

<body class="login-layout">
    <form id="form1" runat="server">
    <div class="main-container" id="main-container">
        <div class="main-content">
            <div class="row">
                <div class="col-sm-10 col-sm-offset-1">
                    <div class="login-container">
                        <div class="center">
                            <h1>
                                <img src="http://m.ajkerdeal.com/images/site-images/Mdealdetails/Logo.png" class="pulse" />
                            </h1>
                            <h5 class="white">
                                Largest Online Shopping Mall In Bangladesh
                            </h5>
                        </div>
                        <div class="space-6">
                        </div>
                        <div class="position-relative">
                            <div id="login-box" class="login-box widget-box no-border visible">
                                <div class="widget-body">
                                    <div class="widget-main">
                                        <div class="center">
                                            <h5 class="red">
                                                <asp:Label ID="lblSystemMessage" runat="server" Text=""></asp:Label></h5>
                                        </div>
                                        <h4 class="header blue lighter bigger">
                                            <i class="icon-hand-right blue"></i>Please Enter Your Information
                                        </h4>
                                        <div class="space-6">
                                        </div>
                                        <fieldset>
                                            <label class="block clearfix">
                                                <span class="block input-icon input-icon-right">
                                                    <asp:TextBox ID="UserNameTextBox" runat="server" CssClass="form-control" placeholder="Username"></asp:TextBox>
                                                    <i class="icon-user"></i></span>
                                            </label>
                                            <label class="block clearfix">
                                                <span class="block input-icon input-icon-right">
                                                    <asp:TextBox ID="PasswordTextBox" runat="server" CssClass="form-control" placeholder="Password"
                                                        TextMode="Password"></asp:TextBox>
                                                    <i class="icon-lock"></i></span>
                                            </label>
                                            <div class="space">
                                            </div>
                                            <div class="clearfix">
                                                <label class="inline">
                                                    <input class="ace" type="checkbox">
                                                    <span class="lbl">Remember Me</span>
                                                </label>
                                                <asp:Button ID="SigninButton" runat="server" OnClick="SigninButton_Click" class="width-35 pull-right btn btn-sm btn-primary"
                                                    OnClientClick="return ValidateForm(1);" Text="Login" />
                                            </div>
                                            <div class="space-4">
                                            </div>
                                        </fieldset>
                                    </div>
                                    <!-- /widget-main -->
                                    <div class="toolbar clearfix">
                                        <div>
                                            <a href="#" onclick="show_box('forgot-box'); return false;" class="forgot-password-link">
                                                <i class="icon-arrow-left"></i>I forgot my password </a>
                                        </div>
                                        <div>
                                            <a href="#" onclick="show_box('signup-box'); return false;" class="user-signup-link">
                                                I want to register <i class="icon-arrow-right"></i></a>
                                        </div>
                                    </div>
                                </div>
                                <!-- /widget-body -->
                            </div>
                            <!-- /login-box -->
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
