<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MonthlyTransactionReportM2.aspx.cs"
    Inherits="admin_MonthlyTransactionReportM2" %>

<!DOCTYPE html">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Monthly Transaction Report M2</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">


    <%-- <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css">--%>
    <link href="https://cdn.datatables.net/1.10.9/css/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="https://cdn.datatables.net/fixedcolumns/3.1.0/css/fixedColumns.dataTables.min.css"
        rel="stylesheet" />
    <link href="http://www.ajkerdeal.com/css/admin/admin_bootstrap.css" rel="stylesheet" type="text/css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.9/js/jquery.dataTables.min.js" type="text/javascript"></script>
    <script src="https://cdn.datatables.net/fixedcolumns/3.1.0/js/dataTables.fixedColumns.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>


    <style type="text/css">
        body 
        {
            font-size:12px;
            }
        table.dataTable tbody th, table.dataTable tbody td, table.dataTable tbody tr {
	        /*text-align:center;*/
	        font-weight:normal;
            font-size:12px;
            padding:5px 5px;
        }

        table.dataTable thead th, table.dataTable tfoot th {
            font-weight: normal;
            font-size: 12px;
            padding:1px 1px;
            text-align:center;
        }

        .col-lg-6 table {
            font-weight: normal;
            font-size: 12px;
        }
        </style>

</head>
<body>
    <form id="MonthlyTransactionReportM2" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="nav navbar-fixed-top header-main">
                <div class="container-fluid">
                    <div class="row">
                        <nav class="navbar navbar-inverse rev-marg " role="navigation">
                            <!-- Brand and toggle get grouped for better mobile display -->
                            <div class="navbar-header">
                                <button type="button" class="navbar-toggle toggle-green" data-toggle="collapse" data-target=".navbar-ex1-collapse">
                                    <span class="sr-only">Toggle navigation</span> <span class="icon-bar"></span><span
                                        class="icon-bar"></span><span class="icon-bar"></span>
                                </button>
                                <img src="http://www.ajkerdeal.com/images/Logo.png" width="130" height="95">
                            </div>
                            <!-- Collect the nav links, forms, and other content for toggling -->
                            <div class="collapse navbar-collapse navbar-ex1-collapse">
                                <ul class="nav navbar-nav navbar-right navbar-user top-menu">
                                    <li class="dropdown user-dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown">
                                        <i class="fa fa-user"></i>
                                        <%Response.Write(CurrentUser); %></a>
                                        <ul class="dropdown-menu profile-drop">
                                            <li class="divider"></li>
                                            <li><a href="SignOut.aspx"><i class="fa fa-power-off"></i>Log Out</a></li>
                                        </ul>
                                    </li>
                                    <li><a href="ControlPanel.aspx" class="btn btn-sm btn-orange">Control Panel</a></li>
                                    <li><a href="BookingReports.aspx" class="btn btn-sm btn-orange">Total Order</a></li>
                                    <li><a href="MonthlyTransactionReport.aspx" class="btn btn-sm btn-orange">
                                        Monthly Trans. Report </a></li>
                                    <li><a href="MonthlyTransactionReportM1.aspx" class="btn btn-sm btn-orange">
                                        Monthly Trans. M1 </a></li>
                                </ul>
                            </div>
                            </nav>
                            <!-- /.navbar-collapse -->
                    </div>
                </div>
            </div>
        </div>
    <div class="col-md-12" style="margin-top: 100px;">
            <h3 style="text-align: center;">
            Monthly Transaction Report M2</h3>
        <div class="row">
            <div class="col-lg-12 text-center" style="margin-top: 10px;">
                <div class="row">
                    <div class="col-lg-6">
                        <table class="table">
                            <tbody id="first">
                                <%=first %>
                            </tbody>
                        </table>
                    </div>
                    <div class="col-lg-6">
                        <table class="table">
                            <tbody id="second">
                                <%=second %>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>

        <div id="loadBusyMain" style="text-align: center; display: none; padding-bottom:20px;">
              <img src="http://www.ajkerdeal.com/Images/search/Loading_image.gif" alt="Loading...">
        </div>

        <!-- Modal -->
        <div class="modal fade" id="myModal" role="dialog">
            <div class="modal-dialog modal-lg" style="width: 1000px;">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">
                            &times;</button>
                        <h4 class="modal-title">
                            Monthly Transaction Report M2 Details</h4>
                    </div>
                    <div class="modal-body" id="popup">
                        <div id="loadBusy" style="text-align: center; display: none;">
                            <img src="http://www.ajkerdeal.com/Images/search/Loading_image.gif" alt="Loading...">
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            Close</button>
                    </div>
                </div>
            </div>
        </div>
        <!-- Modal End-->


        <!--Modal -->
        <div class="modal fade bs-example-modal-lg" id="DataModel2" tabindex="-1" role="dialog"
            aria-labelledby="myModalLabel">
            <div class="modal-dialog modal-lg" role="document" style="width: 1250px;">
                <div class="modal-content" style="text-align: center;">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="H1">
                            Coupon Details
                        </h4>
                        <div id="loadBusy2" style="text-align: center; display: none;">
                            <img src="http://www.ajkerdeal.com/Images/search/Loading_image.gif" alt="Loading...">
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


    </div>
    <div class="col-md-12">
        <div style="text-align: center">
        <asp:Label ID="Label2" runat="server" Font-Size="Large" Text="Month :"></asp:Label>
            <asp:DropDownList ID="DropDownMonth" runat="server" CssClass="btn btn-info">
                <asp:ListItem Text="January" Value="1"></asp:ListItem>
                <asp:ListItem Text="February" Value="2"></asp:ListItem>
                <asp:ListItem Text="March" Value="3"></asp:ListItem>
                <asp:ListItem Text="April" Value="4"></asp:ListItem>
                <asp:ListItem Text="May" Value="5"></asp:ListItem>
                <asp:ListItem Text="June" Value="6"></asp:ListItem>
                <asp:ListItem Text="July" Value="7"></asp:ListItem>
                <asp:ListItem Text="August" Value="8"></asp:ListItem>
                <asp:ListItem Text="September" Value="9"></asp:ListItem>
                <asp:ListItem Text="October" Value="10"></asp:ListItem>
                <asp:ListItem Text="November" Value="11"></asp:ListItem>
                <asp:ListItem Text="December" Value="12"></asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="Label3" runat="server" Font-Size="Large" Text="Year :"></asp:Label>
            <asp:DropDownList ID="DropDownYear" runat="server" CssClass="btn btn-info">
                <asp:ListItem Text="2014" Value="2014"></asp:ListItem>
                <asp:ListItem Text="2015" Value="2015"></asp:ListItem>
                <asp:ListItem Text="2016" Value="2016"></asp:ListItem>
                <asp:ListItem Text="2017" Value="2017"></asp:ListItem>
                <asp:ListItem Text="2018" Value="2018"></asp:ListItem>
                <asp:ListItem Text="2019" Value="2019"></asp:ListItem>
                <asp:ListItem Text="2020" Value="2020"></asp:ListItem>
            </asp:DropDownList>

            <asp:Button ID="ShowButton" runat="server" Text="Show" class="btn btn-info" 
                onclick="ShowButton_Click"/>
            <%--<input id="SubmitMonth" type="button" value="Show" class="btn btn-info" onclick="getMonthlyReportM2();" />--%>
        </div>
        <div class="table-responsive">
            <table id="example" class="cell-border" cellpadding="0"  cellspacing="0" width="100%">
                <thead>
                    <tr>
                        <th>
                            S.No
                        </th>
                        <th>
                            Company
                        </th>

                        <th>Deliverd<br />
                                    Speed<br />
                                    Dhaka</th>
                                <th>Deliverd<br />
                                    Speed<br />
                                    OutSide<br />
                                    Dhaka</th>
                        <th>
                            Status<br />Days
                        </th>
                        <th>
                            Confirmed
                        </th>
                        <th>
                            Deliverd
                        </th>
                        <th>
                            Packaged<br />Wait For<br />Delivery
                        </th>
                        <th>
                            Paid<br />Delivery<br />Courier
                        </th>
                        <th>
                            UnPaid<br />Delivery<br />Courier
                        </th>
                        <th>
                            Under<br />Verification
                        </th>
                        <th>
                            Successfully<br />Processed
                        </th>
                        <th>
                            Not Yet<br />Confirm<br />By<br />Merchant<br />M2
                        </th>
                        <th>
                            Merchant<br />Confirm<br />But Not<br />Yet<br />Deliverd<br />To AD
                        </th>
                        <th>
                            Merchant<br />Refuse
                        </th>
                        <th>
                            Ajkerdeal<br />Refuse<br />(QC)
                        </th>
                        <th>
                            Pre-Shipment<br />Rejected<br />By<br />Customer
                        </th>
                        <th>
                            Post-Shipment<br />RTO
                        </th>
                        <th>
                            Sum
                        </th>
                        <th>
                            Avg.<br />Value/Trans
                        </th>
                        <th>
                            Avg.<br />Comm.
                        </th>
                        <th>
                            GMV
                        </th>
                    </tr>
                </thead>
                <tbody id="transAction">
                    <%=transReport%>
                </tbody>
            </table>
        </div>
        </div>
    </div>
    </form>
    <script type="text/javascript">

        $(document).ready(function () {
            $('#example').DataTable({

                //                fixedColumns: {
                //                    leftColumns: 2,
                //                    rightColumns: 0
                //                },
                "bSort": true,
                "scrollY": "450px",
                "scrollX": true,
                "paging": true,
                "order": [[0, 'asc']],
                "lengthMenu": [[100, 200, 300, -1], [100, 200, 300, "All"]],
                "pagingType": "full_numbers"
            });
        });
    </script>

    <script type="text/javascript">
        function SoldOutProduct(DealId) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "../Service/AdminService/ControlPanelService.asmx/SoldOutProduct",
                data: "{ \'DealId\': \'" + DealId + "\' }",
                dataType: "json",
                async: true,
                cache: false,
                success: function (data) {
                    var Result = data['d']
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

    <script type="text/javascript">
        function GetReports(Data) {

            var Status = Data.split("-");

            var CompanyId = Status[0];
            var IsDone = Status[1];

            var Month = document.getElementById('DropDownMonth').value;
            var Year = document.getElementById('DropDownYear').value;

            // var m = document.getElementById("DropDownMonth");
            // var Month = m.options[m.selectedIndex].value;

            // var y = document.getElementById("DropDownYear");
            // var Year = y.options[y.selectedIndex].value;


            $.ajax({
                beforeSend: function () {
                    $('#loadBusy').show();
                },
                complete: function () {
                    $('#loadBusy').hide();
                },
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: window.location.origin + window.location.pathname + "/GetReportMethod",

                data: "{ \'Month\': \'" + Month + "\', \'Year\': \'" + Year + "\', \'whichTypeOfCompany\': \'" + CompanyId + "\', \'IsDone\': \'" + IsDone + "\' }",
                dataType: "json",
                async: true,
                cache: false,
                success: function (data) {
                    //alert(data.d);
                    document.getElementById('popup').innerHTML = data.d;
                },
                error: function (result) {
                    alert("Error In Loding");
                }
            });
        }
    </script>

    <script type="text/javascript">
        function GetDealDetailsPopup(CouponId) {

            $.ajax({
                beforeSend: function () {
                    $('#loadBusy2').show();
                },
                complete: function () {
                    $('#loadBusy2').hide();
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
        function getMonthlyReportM2() {

            var m = document.getElementById("DropDownMonth");
            var month = m.options[m.selectedIndex].value;

            var y = document.getElementById("DropDownYear");
            var year = y.options[y.selectedIndex].value;

            $.ajax({
                beforeSend: function () {
                    $('#loadBusyMain').show();
                },
                complete: function () {
                    $('#loadBusyMain').hide();
                },
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: window.location.origin + window.location.pathname + "/GetM2Report",

                data: "{ \'month\': \'" + month + "\', \'year\': \'" + year + "\' }",
                dataType: "json",
                async: true,
                cache: false,
                success: function (data) {
                    //alert(data['d']);

                    resultData = data['d'];

                    document.getElementById('transAction').innerHTML = resultData[0];
                    document.getElementById('first').innerHTML = resultData[1];
                    document.getElementById('second').innerHTML = resultData[2];
                    //document.getElementById('transAction').innerHTML = data.d;

                },
                error: function (result) {
                    alert("Error in Active/Inactive");
                }
            });
        }
    </script>


    <script type="text/javascript">
        function GetReportsDetails(Data) {

            var Status = Data.split("-");

            var CompanyId = Status[0];
            var CompanyName = Status[1];
            var TotalQuantity = Status[2];

            var Month = document.getElementById('DropDownMonth').value;
            var Year = document.getElementById('DropDownYear').value;


            $.ajax({
                beforeSend: function () {
                    $('#loadBusy').show();
                },
                complete: function () {
                    $('#loadBusy').hide();
                },
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: window.location.origin + window.location.pathname + "/GetReportDetailsM2",

                data: "{ \'CompanyId\': \'" + CompanyId + "\', \'Month\': \'" + Month + "\', \'Year\': \'" + Year + "\', \'CompanyName\': \'" + CompanyName + "\', \'TotalQuantity\': \'" + TotalQuantity + "\' }",
                dataType: "json",
                async: true,
                cache: false,
                success: function (data) {
                    //alert(data.d);
                    document.getElementById('popup').innerHTML = data.d;
                },
                error: function (result) {
                    //alert("Error In Loding");
                    alert(

                            '▬▬▬▬▬▬▬▬▬ஜ۩۞۩ஜ▬▬▬▬▬▬▬▬▬\n\n'

                            + 'Error in Confirmed PopUp\n'
                            + '\t\t\t\t\t\t\t\t ধন্যবাদ\n'

                            );
                }
            });
        }
    </script>


    <script type="text/javascript">
        function GetDeliverySpeed(Data) {

            var Status = Data.split("-");

            var CompanyId = Status[0];
            var District = Status[1];
            var Check = Status[2];
            var CompanyName = Status[3];

            var Month = document.getElementById('DropDownMonth').value;
            var Year = document.getElementById('DropDownYear').value;

            $.ajax({
                beforeSend: function () {
                    $('#loadBusy').show();
                },
                complete: function () {
                    $('#loadBusy').hide();
                },
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: window.location.origin + window.location.pathname + "/GetDeliverySpeedDetails",

                data: "{ \'CompanyId\': \'" + CompanyId + "\', \'Month\': \'" + Month + "\', \'Year\': \'" + Year + "\', \'District\': \'" + District + "\', \'CompanyName\': \'" + CompanyName + "\' , \'Check\': \'" + Check + "\'}",
                dataType: "json",
                async: true,
                cache: false,
                success: function (data) {
                    //alert(data.d);
                    document.getElementById('popup').innerHTML = data.d;
                },
                error: function (result) {
                    //alert("Error In Loding");
                    alert(

                        '▬▬▬▬▬▬▬▬▬ஜ۩۞۩ஜ▬▬▬▬▬▬▬▬▬\n\n'

                        + 'Error in Delivery Speed PopUp\n'
                        + '\t\t\t\t\t\t\t\t ধন্যবাদ\n'

                        );

                }
            });
        }
    </script>



</body>
</html>
