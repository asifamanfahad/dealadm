<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MonthlyTransactionSummaryReport.aspx.cs" Inherits="admin_MonthlyTransactionSummaryReport" %>

<!DOCTYPE html>

<html ng-app="app">
<head runat="server">
    <title>Summary Report</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css">
    <link href="../AdminNew/assets/css/ace.min.css"" rel="stylesheet" />
</head>
<body>
    <form id="Summaryform" runat="server">

        <div class="col-xs-12">
            <div class="table-header" style="margin-top: 10px;">
                <span class="CustomHeader">Summary Report</span>
            </div>
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="True"></asp:ScriptManager>

        <div class="col-xs-12">

            <!--Modal for Coupon Details -->
            <div class="modal fade bs-example-modal-lg" id="DataModel2" tabindex="-1" role="dialog"
                    aria-labelledby="myModalLabel">
                    <div class="modal-dialog modal-lg" role="document" style="width: 1250px;">
                        <div class="modal-content" style="text-align: center;">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span></button>

                                <div id="loadBusy2" style="text-align: center; display: none;">
                                    <img src="http://www.ajkerdeal.com/Images/search/Loading_image.gif" alt="Loading..."/>
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


            <div class="table-responsive" ng-controller="summaryCtrl">
                <div class="row">
                    <div class="col-sm-4">
                        <label class="block clearfix PaddingCustom">
                            <span class="block input-icon input-icon-right">
                                <input ng-model="query" class="form-control" placeholder="Search for Summary Report" type="text" autofocus="autofocus">
                            </span>
                        </label>
                    </div>
                    <div class="col-sm-4">
                    </div>
                    <div class="col-sm-4">
                    </div>
                </div>

               
                <table class="table table-bordered">
                    <thead>
                        <tr>
                            <th>SN.</th>
                            <th>Booking Code</th>
                            <th>Deal Title</th>
                            <th>Price</th>
                            <th>POD</th>
                            <th>Order From</th>
                            <th>Courier</th>
                            <th>Company Name</th>
                            <th>Confirmation Date</th>
                            <th>Image</th>
                            <th>Comments</th>
                            <th>Commented By</th>
                        </tr>
                    </thead>

                    <tr class="animationCustom"  ng-repeat="item in summary | filter: query">
                        <td>{{$index + 1}}</td>
                        <td  style="cursor: pointer;" ><span data-toggle='modal' data-target='#DataModel2' id="{{item.couponId}}" onclick='GetDealDetailsPopup(this.id);'>{{item.couponId}}</span></td>
                        <td>{{item.dealTitle}} <a href='http://www.ajkerdeal.com/dealdetails.aspx?DI={{item.dealId}}'target=_blank>{{item.dealId}}</a></td>
                        <td>{{item.couponPrice}}</td>
                        <td>{{item.podNumber}}</td>
                        <td>{{item.orderFrom}}</td>
                        <td>{{item.courier}}</td>
                        <td>{{item.companyName}}</td>
                        <td>{{item.crmConfirmationDate}}</td>
                        <td>
                            <img  width='50' ng-src="http://www.ajkerdeal.com/images/Deals/{{item.folderName}}/dealdetails1.jpg" alt="Photo of {{item.companyName}}"></td>
                        <td>{{item.comments}}</td>
                        <td>{{item.commentedBy}}</td>
                    </tr>
                </table>
            </div>
        </div>


        <%--<div class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <h1>Test Modal</h1>
                </div>
            </div>
        </div>--%>


    </form>


    <style type="text/css">
        .CustomHeader {
            font-family: "Bree Serif",serif;
            font-size: 2.2rem;
            text-shadow: 1px 1px;
            line-height: 100%;
        }

        .PaddingCustom {
            padding: 10px 0px 10px 0px;
        }

        .animationCustom td {
            opacity: .9;
            -webkit-transition: all 0.3s ease-out;
            -moz-transition: all 0.3s ease-out;
            -o-transition: all 0.3s ease-out;
            transition: all 0.3s ease-out;
        }

            .animationCustom td:hover {
                background: #FFFFFF;
                opacity: 1;
                -webkit-transform: scale(1.2);
                -moz-transform: scale(1.2);
                -ms-transform: scale(1.2);
                transform: scale(1.2);
            }

        .table > tbody > tr > td, .table > tbody > tr > th, .table > tfoot > tr > td, .table > tfoot > tr > th, .table > thead > tr > td, .table > thead > tr > th {
            padding: 1px;
            vertical-align: middle;
        }

    </style>


    <%--  <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>--%>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.4.5/angular.min.js"></script>
    <script src="App/angular-animate.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/angular.js/1.5.0-beta.1/angular-resource.min.js"></script>
    <script src="../../css/AdminNew/assets/js/ace.min.js"></script>

    <script src="Angularjs/SummaryReport/App/app.js"></script>
    <script src="Angularjs/SummaryReport/App/data.js"></script>
    <script src="Angularjs/SummaryReport/App/summaryCtrl.js"></script>


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

</body>
</html>
