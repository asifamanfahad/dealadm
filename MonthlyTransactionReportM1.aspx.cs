using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Text;

public partial class admin_MonthlyTransactionReportM1 : System.Web.UI.Page
{
    public string transReport = string.Empty, first = string.Empty, second = string.Empty, CurrentUser = string.Empty, uniqueMerchant = string.Empty;
    //public string adminType = string.Empty;
    public int TotalGmv = 0;
    public double TotalCouponSold = 0, PercentOfDelivery = 0, PercentAjkerdealRefuse = 0, PercentPreshipment = 0, PercentCommission = 0,
        PercentNotVerifyYetM1, PercentMerchantGivenToCourierM1 = 0, PercentUnderVerificationM1 = 0,
        PercentNotYetConfirmByMerchantM2 = 0, PercentMerchantConfirmButNotYetDeliverdToAD = 0, PercentPostShipmentRTOM1 = 0,
        PercentRefundProcessToCustomerM1 = 0, PercentPreshipmentM1 = 0, PercentMerchantRefuse = 0, PercentPaymentRefundM1 = 0,
        PercentDidNotGetProductYet = 0, PercentPaymentRefundDoneM1 = 0, PercentReadyToPickFromCourierM1 = 0,
        PercentPreShipmentCustomerNotReachableM1 = 0;
   

    protected void Page_Load(object sender, EventArgs e)
    {

        using (GenarateSessionThroughtCoockie checkSession = new GenarateSessionThroughtCoockie())
        {
            bool hasSession = checkSession.SessionCheck(3);
            if (hasSession == false)
            {
                Response.Redirect("Default.aspx");
                Response.End();
            }
        }

        //Response.AppendHeader("Refresh", "10");

        if ((Session["AD_ADMIN_TYPE"] != null) && (Session["AD_ADMIN_TYPE"] != ""))
        {
            //adminType = Session["AD_ADMIN_TYPE"].ToString();
            CurrentUser = this.Session["AD_ADMIN_NAME"].ToString() + "(" + this.Session["AD_ADMIN_USERNAME"] + ")";

        }
        else
        {
            Response.Redirect("Default.aspx");
            Response.End();
        }

        if (!Page.IsPostBack)
        {
            DropDownMonth.SelectedValue = DateTime.Now.Month.ToString();
            DropDownYear.SelectedValue = DateTime.Now.Year.ToString();
            string Month = string.Empty, Year = string.Empty;
            string OrderBy = string.Empty;
            OrderBy = "CouponSold";
            Month = DropDownMonth.SelectedValue;
            Year = DropDownYear.SelectedValue;

            ReportM1Method(Month, Year, OrderBy);
        }        

    }

    private void ReportM1Method(string Month, string Year, string OrderBy)
    {
        double TotalConfirmed = 0, TotalAmount = 0, TotalPreshipmentM1 = 0, TotalPreShipmentCustomerNotReachableM1 = 0,
            TotalCommission = 0, TotalPostShipmentRTOM1 = 0, TotalPaymentRefundM1 = 0, TotalRefundProcessToCustomerM1 = 0,TotalPaymentRefundDoneM1 = 0,
            TotalMerchantRefuse = 0, TotalMerchantGivenToCourierM1 = 0, TotalNotVerifyYetM1 = 0, TotalUnderVerificationM1 = 0,
            TotalDidNotGetProductYet = 0, TotalReadyToPickFromCourierM1 = 0, TotalDeliverdGMV = 0;
        double Sumation = 0;
        string UniqueDealM1 = string.Empty;


        using (MonthlyTransactionReportM1Gateway objMonthlyTransactionReportM1Gateway = new MonthlyTransactionReportM1Gateway())
        {
            DataTable dt = objMonthlyTransactionReportM1Gateway.MonthlyTransactionReportM1(Month, Year, OrderBy);

            //DataTable dt = objMonthlyTransactionReportM1Gateway.MonthlyTransactionReportM1_1(Month, Year, OrderBy);

            //DataTable dt = objMonthlyTransactionReportM1Gateway.MonthlyTransactionReportM1_2(Month, Year, OrderBy);

            if (dt.Rows.Count > 0)
            {
                int Count = 1;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    // Total Calculation Start

                    TotalGmv += Convert.ToInt32(dt.Rows[i]["TotalTransaction"]);
                    TotalCouponSold += Convert.ToInt32(dt.Rows[i]["CouponSold"]); //Grand Total Confirmed Orders
                    TotalConfirmed += Convert.ToInt32(dt.Rows[i]["TotalConfirmed"]); // Delivered
                    TotalCommission += Convert.ToInt32(dt.Rows[i]["Commission"]); //Total Commission
                    TotalPreshipmentM1 += Convert.ToInt32(dt.Rows[i]["Preshipmentm1"]); //Pre-Shipment Reject By Customer
                    TotalAmount += Convert.ToInt32(dt.Rows[i]["TotalTransaction"]);
                    TotalMerchantGivenToCourierM1 += Convert.ToInt32(dt.Rows[i]["Courier"]);
                    TotalNotVerifyYetM1 += Convert.ToInt32(dt.Rows[i]["NotVerifyYetM1"]);
                    TotalUnderVerificationM1 += Convert.ToInt32(dt.Rows[i]["VerificationM1"]);
                    TotalDidNotGetProductYet += Convert.ToInt32(dt.Rows[i]["DidNotGetProductYet"]);
                    TotalMerchantRefuse += Convert.ToInt32(dt.Rows[i]["MerchantCancle"]);
                    TotalPostShipmentRTOM1 += Convert.ToInt32(dt.Rows[i]["NoReach"]);
                    TotalPaymentRefundM1 += Convert.ToInt32(dt.Rows[i]["RefundM1"]);
                    TotalRefundProcessToCustomerM1 += Convert.ToInt32(dt.Rows[i]["RefundProcessToCustomer"]);
                    TotalPaymentRefundDoneM1 += Convert.ToInt32(dt.Rows[i]["PaymentRefundDone"]);
                    TotalReadyToPickFromCourierM1 += Convert.ToInt32(dt.Rows[i]["ReadyToPickFromCourier"]);
                    TotalDeliverdGMV += Convert.ToInt32(dt.Rows[i]["TotalTransactionDeliverd"]);
                    TotalPreShipmentCustomerNotReachableM1 += Convert.ToInt32(dt.Rows[i]["PreShipmentCustomerNotReachable"]);

                    // Total Calculation End

                    string DateRange = Convert.ToString(dt.Rows[i]["InsertedOn"]);

                    // Deliverd Speed Start

                    //string DiffDate = Convert.ToString(dt.Rows[i]["DiffDate"]);
                    //if (DiffDate == "1")
                    //{
                    //    DiffDate = DiffDate + " Day";
                    //}
                    //else if (DiffDate == "<b>No Record</b>")
                    //{
                    //    DiffDate = Convert.ToString(dt.Rows[i]["DiffDate"]);
                    //}
                    //else
                    //{
                    //    DiffDate = DiffDate + " Days";
                    //}

                    //string DhakaDiffDate = Convert.ToString(dt.Rows[i]["DhakaDiffDate"]);
                    //if (DhakaDiffDate == "1")
                    //{
                    //    DhakaDiffDate = DhakaDiffDate + " Day";
                    //}
                    //else if (DhakaDiffDate == "<b>No Record</b>")
                    //{
                    //    DhakaDiffDate = Convert.ToString(dt.Rows[i]["DhakaDiffDate"]);
                    //}
                    //else
                    //{
                    //    DhakaDiffDate = DhakaDiffDate + " Days";
                    //}

                    // Deliverd Speed End

                    // Delivery Start
                    double Delivery = ((Convert.ToDouble(dt.Rows[i]["TotalConfirmed"]) / Convert.ToDouble(dt.Rows[i]["CouponSold"])) * 100);
                    string CalDeliverd = String.Format("{0:0.##}", Delivery);

                    if (CalDeliverd == "0")
                    {
                        CalDeliverd = "0 %";
                    }
                    else
                    {
                        CalDeliverd = CalDeliverd + "%";
                    }

                    // Delivery End


                    // Deliverd GMV Start

                    double DeliverdGMV = (Convert.ToDouble(dt.Rows[i]["TotalTransactionDeliverd"]) / Convert.ToDouble(dt.Rows[i]["CouponSold"])) * 100;
                    string CalDeliverdGMV = String.Format("{0:0.##}", DeliverdGMV);
                    if (CalDeliverdGMV == "0")
                    {
                        CalDeliverdGMV = "0 %";
                    }
                    else
                    {
                        CalDeliverdGMV = CalDeliverdGMV + "%";
                    }

                    // Deleverd GMV End


                    // Merchant Given To Courier M1 Start
                    double MerchantGivenToCourierM1 = ((Convert.ToDouble(dt.Rows[i]["Courier"]) / Convert.ToDouble(dt.Rows[i]["CouponSold"])) * 100);
                    string CalMerchantGivenToCourierM1 = String.Format("{0:0.##}", MerchantGivenToCourierM1);
                    if (CalMerchantGivenToCourierM1 == "0")
                    {
                        CalMerchantGivenToCourierM1 = "0 %";
                    }
                    else
                    {
                        CalMerchantGivenToCourierM1 = CalMerchantGivenToCourierM1 + "%";
                    }
                    // Merchant Given To Courier M1 End


                    // Not Verify Yet M1 Start
                    double NotVerifyYetM1 = ((Convert.ToDouble(dt.Rows[i]["NotVerifyYetM1"]) / Convert.ToDouble(dt.Rows[i]["CouponSold"])) * 100);
                    string CalNotVerifyYetM1 = String.Format("{0:0.##}", NotVerifyYetM1);
                    if (CalNotVerifyYetM1 == "0")
                    {
                        CalNotVerifyYetM1 = "0 %";
                    }
                    else
                    {
                        CalNotVerifyYetM1 = CalNotVerifyYetM1 + "%";
                    }
                    // Not Verify Yet M1 End


                    // Ready To Pick From Courier M1 Start
                    double ReadyToPickFromCourierM1 = ((Convert.ToDouble(dt.Rows[i]["ReadyToPickFromCourier"]) / Convert.ToDouble(dt.Rows[i]["CouponSold"])) * 100);
                    string CalReadyToPickFromCourierM1 = String.Format("{0:0.##}", ReadyToPickFromCourierM1);
                    if (CalReadyToPickFromCourierM1 == "0")
                    {
                        CalReadyToPickFromCourierM1 = "0 %";
                    }
                    else
                    {
                        CalReadyToPickFromCourierM1 = CalReadyToPickFromCourierM1 + "%";
                    }
                    // Ready To Pick From Courier M1 End



                    // Refund Process To Customer / Payment Refund Done Start 
                    double RefundM1 = ((Convert.ToDouble(dt.Rows[i]["RefundM1"]) / Convert.ToDouble(dt.Rows[i]["CouponSold"])) * 100);
                    string CalRefundM1 = String.Format("{0:0.##}", RefundM1);
                    if (CalRefundM1 == "0")
                    {
                        CalRefundM1 = "0 %";
                    }
                    else
                    {
                        CalRefundM1 = CalRefundM1 + "%";
                    }
                    // Refund Process To Customer / Payment Refund Done END 


                    // 	Customer did not get the product yet M1 Start

                    double CustomerDidNotGetProduct = ((Convert.ToDouble(dt.Rows[i]["DidNotGetProductYet"]) / Convert.ToDouble(dt.Rows[i]["CouponSold"])) * 100);
                    string CalCustomerDidNotGetProductM1 = String.Format("{0:0.##}", CustomerDidNotGetProduct);
                    if (CalCustomerDidNotGetProductM1 == "0")
                    {
                        CalCustomerDidNotGetProductM1 = "0 %";
                    }
                    else
                    {
                        CalCustomerDidNotGetProductM1 = CalCustomerDidNotGetProductM1 + "%";
                    }
                    // Customer did not get the product yet M1 End


                    // Under Verification M1 Start
                    double UnderVerificationM1 = ((Convert.ToDouble(dt.Rows[i]["VerificationM1"]) / Convert.ToDouble(dt.Rows[i]["CouponSold"])) * 100);
                    string CalUnderVerificationM1 = String.Format("{0:0.##}", UnderVerificationM1);
                    if (CalUnderVerificationM1 == "0")
                    {
                        CalUnderVerificationM1 = "0 %";
                    }
                    else
                    {
                        CalUnderVerificationM1 = CalUnderVerificationM1 + "%";
                    }
                    // Under Verification M1 End


                    // Merchant Not Interested To Delivery Start
                    double MNotInterestedToDeliveryM1 = ((Convert.ToDouble(dt.Rows[i]["MNotInterestedToDelivery"]) / Convert.ToDouble(dt.Rows[i]["CouponSold"])) * 100);
                    double NotInterestedM1 = 5.0;
                    string NotInterestedRedM1 = "#ff0000";

                    string NotInterestedRedColourM1 = "";
                    if (MNotInterestedToDeliveryM1 > NotInterestedM1)
                    {
                        NotInterestedRedColourM1 = NotInterestedRedM1;
                    }

                    string CalMNotInterestedToDeliveryM1 = String.Format("{0:0.##}", MNotInterestedToDeliveryM1);
                    if (CalMNotInterestedToDeliveryM1 == "0")
                    {
                        CalMNotInterestedToDeliveryM1 = "0 %";
                    }
                    else
                    {
                        CalMNotInterestedToDeliveryM1 = CalMNotInterestedToDeliveryM1 + "%";
                    }
                    // Merchant Not Interested To Delivery End



                    // Merchant Refuse M1 Start
                    double MerchantRefuseM1 = ((Convert.ToDouble(dt.Rows[i]["MerchantCancle"]) / Convert.ToDouble(dt.Rows[i]["CouponSold"])) * 100);
                    double RefuseNumberM1 = 5.0;
                    string RefuseRedM1 = "#ff0000";

                    string RefuseRedColourM1 = "";
                    if (MerchantRefuseM1 > RefuseNumberM1)
                    {
                        RefuseRedColourM1 = RefuseRedM1;
                    }

                    string CalMerchantRefuseM1 = String.Format("{0:0.##}", MerchantRefuseM1);
                    if (CalMerchantRefuseM1 == "0")
                    {
                        CalMerchantRefuseM1 = "0 %";
                    }
                    else
                    {
                        CalMerchantRefuseM1 = CalMerchantRefuseM1 + "%";
                    }
                    // Merchant Refuse M1 End

                    //Pre-Shipment Reject By Customer M1 Start
                    double PreShipmentRejectByCustomerM1 = ((Convert.ToDouble(dt.Rows[i]["Preshipmentm1"]) / Convert.ToDouble(dt.Rows[i]["CouponSold"])) * 100);
                    string CalPreShipmentRejectByCustomerM1 = String.Format("{0:0.##}", PreShipmentRejectByCustomerM1);
                    if (CalPreShipmentRejectByCustomerM1 == "0")
                    {
                        CalPreShipmentRejectByCustomerM1 = "0 %";
                    }
                    else
                    {
                        CalPreShipmentRejectByCustomerM1 = CalPreShipmentRejectByCustomerM1 + "%";
                    }
                    //Pre-Shipment Reject By Customer M1 End

                    // Post-Shipment RTO Start M1
                    double PostShipmentRTOM1 = ((Convert.ToDouble(dt.Rows[i]["NoReach"]) / Convert.ToDouble(dt.Rows[i]["CouponSold"])) * 100);
                    double NumberM1 = 10.0;
                    string RedM1 = "#ff0000";

                    string RedColourM1 = "";
                    if (PostShipmentRTOM1 > NumberM1)
                    {
                        RedColourM1 = RedM1;
                    }
                    string CalPostShipmentRTOM1 = String.Format("{0:0.##}", PostShipmentRTOM1);
                    if (CalPostShipmentRTOM1 == "0")
                    {
                        CalPostShipmentRTOM1 = "0 %";
                    }
                    else
                    {
                        CalPostShipmentRTOM1 = CalPostShipmentRTOM1 + "%";
                    }
                    // Post-Shipment RTO End M1


                    // Pre-Shipment Customer Not Reachable M1

                    double PreShipmentCustomerNotReachableM1 = ((Convert.ToDouble(dt.Rows[i]["PreShipmentCustomerNotReachable"]) / Convert.ToDouble(dt.Rows[i]["CouponSold"])) * 100);
                    string CalPreShipmentCustomerNotReachableM1 = String.Format("{0:0.##}", PreShipmentCustomerNotReachableM1);
                    if (CalPreShipmentCustomerNotReachableM1 == "0")
                    {
                        CalPreShipmentCustomerNotReachableM1 = "0 %";
                    }
                    else
                    {
                        CalPreShipmentCustomerNotReachableM1 = CalPreShipmentCustomerNotReachableM1 + "%";
                    }

                    // Pre-Shipment Customer Not Reachable M1 End



                    Sumation = Delivery + MerchantGivenToCourierM1 + NotVerifyYetM1 + UnderVerificationM1 + MNotInterestedToDeliveryM1 +
                       MerchantRefuseM1 + PreShipmentRejectByCustomerM1 + PostShipmentRTOM1 +
                       CustomerDidNotGetProduct + RefundM1 + ReadyToPickFromCourierM1 + PreShipmentCustomerNotReachableM1;

                    string CalSumation = String.Format("{0:0.##}", Sumation);
                    if (CalSumation == "0")
                    {
                        CalSumation = "0 %";
                    }
                    else
                    {
                        CalSumation = CalSumation + "%";
                    }



                    // Avg Percent Commission Coupon Start
                    string AvgPercentCommissionCoupon = String.Format("{0:0.00}", dt.Rows[i]["AvgPercentCommissionCoupon"]);
                    if (AvgPercentCommissionCoupon == "0")
                    {
                        AvgPercentCommissionCoupon = "0 %";
                    }
                    else
                    {
                        AvgPercentCommissionCoupon = AvgPercentCommissionCoupon + "%";
                    }
                    // Avg Percent Commission Coupon End


                    // Successfully Processed
                    double SuccessfullyProcessed = Delivery + MerchantGivenToCourierM1 + ReadyToPickFromCourierM1;
                    string NoColor = "#333";
                    string GreenColor = "#019440";
                    string YellowColor = "#F4A535";
                    string RedColor = "#ff0000";
                    string color = NoColor;
                    int Day = DateTime.Now.Day;

                    if (Day >= 1 && Day <= 10 && Convert.ToInt32(Month) == DateTime.Now.Month && Convert.ToInt32(Year) == DateTime.Now.Year)
                    {
                        if (SuccessfullyProcessed >= 50)
                        {
                            color = GreenColor;
                        }
                        else if (SuccessfullyProcessed >= 40 && SuccessfullyProcessed < 50) // (intProcessOrder >= 40)
                        {
                            color = YellowColor;
                        }
                        else if (SuccessfullyProcessed < 40)
                        {
                            color = RedColor;
                        }
                    }

                    else if (Day >= 11 && Day <= 20 && Convert.ToInt32(Month) == DateTime.Now.Month && Convert.ToInt32(Year) == DateTime.Now.Year)
                    {
                        if (SuccessfullyProcessed >= 75)
                        {
                            color = GreenColor;
                        }
                        else if (SuccessfullyProcessed >= 60 && SuccessfullyProcessed < 75) //(intProcessOrder >= 60)
                        {
                            color = YellowColor;
                        }
                        else if (SuccessfullyProcessed < 60)
                        {
                            color = RedColor;
                        }
                    }

                    else if (Day >= 21 && Day <= 31 && Convert.ToInt32(Month) == DateTime.Now.Month && Convert.ToInt32(Year) == DateTime.Now.Year)
                    {
                        if (SuccessfullyProcessed >= 85)
                        {
                            color = GreenColor;
                        }
                        else if (SuccessfullyProcessed >= 70 && SuccessfullyProcessed < 85) // (intProcessOrder >= 70)
                        {
                            color = YellowColor;
                        }
                        else if (SuccessfullyProcessed < 70)
                        {
                            color = RedColor;
                        }
                    }

                    else
                    {
                        if (SuccessfullyProcessed >= 85)
                        {
                            color = GreenColor;
                        }
                        else if (SuccessfullyProcessed >= 70 && SuccessfullyProcessed < 85) // (intProcessOrder >= 70)
                        {
                            color = YellowColor;
                        }
                        else if (SuccessfullyProcessed < 70)
                        {
                            color = RedColor;
                        }
                    }

                    // Cal Successfully Processed Calculation
                    string CalSuccessfullyProcessed = String.Format("{0:0.##}", SuccessfullyProcessed);

                    if (CalSuccessfullyProcessed == "0")
                    {
                        CalSuccessfullyProcessed = "0 %";
                    }
                    else
                    {
                        CalSuccessfullyProcessed = CalSuccessfullyProcessed + "%";
                    }

                    // Cal Successfully Processed End


                    //String GoodProductQuality = "<a><span data-toggle='modal' data-target='#DataModel2' id='" + dt.Rows[i]["ProfileId"] + "-1" + "' style= 'color:green; cursor:pointer;' onclick='ServiceExperincePopUp(this.id);'>" + dt.Rows[i]["GoodProductQuality"] + "</a></span>";
                    //String BadProductQuality = "<a><span data-toggle='modal' data-target='#DataModel2' id='" + dt.Rows[i]["ProfileId"] + "-2" + "' style= 'color:red; cursor:pointer;' onclick='ServiceExperincePopUp(this.id);'>" + dt.Rows[i]["BadProductQuality"] + "</a></span>";


                    transReport = transReport + "<tr><td>" + Count++ + "</td><td>" + dt.Rows[i]["CompanyName"] + "</td><td>-</td><td>-</td><td data-toggle='modal' data-target='#myModal'> <span style='cursor: pointer;' id ='" + dt.Rows[i]["ProfileId"] + "-14-D-" + dt.Rows[i]["CompanyName"] + "' onclick = 'GetDeliverySpeed(this.id);'>-</span></td><td data-toggle='modal' data-target='#myModal'> <span style='cursor: pointer;' id ='" + dt.Rows[i]["ProfileId"] + "-14-O-" + dt.Rows[i]["CompanyName"] + "' onclick = 'GetDeliverySpeed(this.id);'>-</span></td><td>" + DateRange + "</td><td data-toggle='modal' data-target='#myModal'><span style='cursor: pointer;' id ='" + dt.Rows[i]["ProfileId"] + "-" + dt.Rows[i]["CompanyName"] + "-" + dt.Rows[i]["CouponSold"] + "' onclick = 'GetReportsDetails(this.id);'>" + dt.Rows[i]["CouponSold"] + "</span></td><td data-toggle='modal' data-target='#myModal'><span style='cursor: pointer;' id ='" + dt.Rows[i]["ProfileId"] + "-10,23,110-" + dt.Rows[i]["CompanyName"] + "' onclick = 'GetReports(this.id);'>" + CalDeliverd + "</span></td><td data-toggle='modal' data-target='#myModal'><span style='cursor: pointer;' id ='" + dt.Rows[i]["ProfileId"] + "-111-" + dt.Rows[i]["CompanyName"] + "' onclick = 'GetReports(this.id);'>" + CalMerchantGivenToCourierM1 + "</span></td><td data-toggle='modal' data-target='#myModal'><span style='cursor: pointer;' id ='" + dt.Rows[i]["ProfileId"] + "-102-" + dt.Rows[i]["CompanyName"] + "' onclick = 'GetReports(this.id);'>" + CalReadyToPickFromCourierM1 + "</span></td><td data-toggle='modal' data-target='#myModal' ><span style='cursor: pointer; color:" + color + "' id ='" + dt.Rows[i]["ProfileId"] + "-10,23,111,110,102-" + dt.Rows[i]["CompanyName"] + "' onclick = 'GetReports(this.id);'>" + CalSuccessfullyProcessed + "</span></td><td data-toggle='modal' data-target='#myModal'> <span style='cursor: pointer;' id ='" + dt.Rows[i]["ProfileId"] + "-105-" + dt.Rows[i]["CompanyName"] + "' onclick = 'GetReports(this.id);'>" + CalCustomerDidNotGetProductM1 + "</span></td><td data-toggle='modal' data-target='#myModal'><span style='cursor: pointer;' id ='" + dt.Rows[i]["ProfileId"] + "-7,16,19-" + dt.Rows[i]["CompanyName"] + "' onclick = 'GetReports(this.id);'>" + CalNotVerifyYetM1 + "</span></td><td data-toggle='modal' data-target='#myModal'> <span style='cursor: pointer;' id ='" + dt.Rows[i]["ProfileId"] + "-101-" + dt.Rows[i]["CompanyName"] + "' onclick = 'GetReports(this.id);'>" + CalUnderVerificationM1 + "</span></td><td data-toggle='modal' data-target='#myModal'> <span style='cursor: pointer; color:" + NotInterestedRedColourM1 + "' id ='" + dt.Rows[i]["ProfileId"] + "-35-" + dt.Rows[i]["CompanyName"] + "' onclick = 'GetReports(this.id);'>" + CalMNotInterestedToDeliveryM1 + "<span></td><td data-toggle='modal' data-target='#myModal'> <span style='cursor: pointer; color:" + RefuseRedColourM1 + "' id ='" + dt.Rows[i]["ProfileId"] + "-18-" + dt.Rows[i]["CompanyName"] + "' onclick = 'GetReports(this.id);'>" + CalMerchantRefuseM1 + "<span></td><td data-toggle='modal' data-target='#myModal'> <span style='cursor: pointer;' id ='" + dt.Rows[i]["ProfileId"] + "-130,134-" + dt.Rows[i]["CompanyName"] + "' onclick = 'GetReports(this.id);'>" + CalRefundM1 + "</span></td><td data-toggle='modal' data-target='#myModal' ><span style='cursor: pointer;' id ='" + dt.Rows[i]["ProfileId"] + "-155,104-" + dt.Rows[i]["CompanyName"] + "' onclick = 'GetReports(this.id);'>" + CalPreShipmentRejectByCustomerM1 + "</span></td><td data-toggle='modal' data-target='#myModal'><span style='cursor: pointer;' id ='" + dt.Rows[i]["ProfileId"] + "-324-" + dt.Rows[i]["CompanyName"] + "' onclick = 'GetReports(this.id);'>" + CalPreShipmentCustomerNotReachableM1 + "</span></td><td data-toggle='modal' data-target='#myModal'> <span style='cursor: pointer; color:" + RedColourM1 + "' id ='" + dt.Rows[i]["ProfileId"] + "-24,17-" + dt.Rows[i]["CompanyName"] + "' onclick = 'GetReports(this.id);'>" + CalPostShipmentRTOM1 + "</span></td><td>" + CalSumation + "</td><td>" + dt.Rows[i]["EValuePerTransaction"] + "</td><td>" + AvgPercentCommissionCoupon + "</td><td>" + dt.Rows[i]["TotalTransaction"] + "</td><td>" + dt.Rows[i]["TotalTransactionDeliverd"] + "</td></tr>";


                }


                if (TotalCouponSold != 0)
                {
                    PercentOfDelivery = (TotalConfirmed / TotalCouponSold) * 100;
                    PercentCommission = (TotalCommission / TotalAmount) * 100;
                    PercentMerchantGivenToCourierM1 = (TotalMerchantGivenToCourierM1 / TotalCouponSold) * 100;
                    PercentNotVerifyYetM1 = (TotalNotVerifyYetM1 / TotalCouponSold) * 100;
                    PercentMerchantRefuse = (TotalMerchantRefuse / TotalCouponSold) * 100;
                    PercentPreshipmentM1 = (TotalPreshipmentM1 / TotalCouponSold) * 100;
                    PercentUnderVerificationM1 = (TotalUnderVerificationM1 / TotalCouponSold) * 100;
                    PercentDidNotGetProductYet = (TotalDidNotGetProductYet / TotalCouponSold) * 100;
                    PercentPostShipmentRTOM1 = (TotalPostShipmentRTOM1 / TotalCouponSold) * 100;
                    PercentPaymentRefundM1 = (TotalPaymentRefundM1 / TotalCouponSold) * 100;
                    PercentRefundProcessToCustomerM1 = (TotalRefundProcessToCustomerM1 / TotalCouponSold) * 100;
                    PercentPaymentRefundDoneM1 = (TotalPaymentRefundDoneM1 / TotalCouponSold) * 100;
                    PercentReadyToPickFromCourierM1 = (TotalReadyToPickFromCourierM1 / TotalCouponSold) * 100;
                    PercentPreShipmentCustomerNotReachableM1 = (TotalPreShipmentCustomerNotReachableM1 / TotalCouponSold) * 100;
                }
            }
                   
           
            DataTable UnqueDealDataTable = objMonthlyTransactionReportM1Gateway.MonthlyOrderUniqueDealM1(Month, Year);
            if (UnqueDealDataTable != null && UnqueDealDataTable.Rows.Count > 0)
            {
                foreach (DataRow rowUnique in UnqueDealDataTable.Rows)
                {
                    UniqueDealM1 = Convert.ToString(UnqueDealDataTable.Rows[0]["Deal_SKU"]);
                }
            }
        }


        first = "<tr class='active'><td>Grand Total GMV :</td><td>Tk. " + TotalGmv + "</td></tr>";      
        first += "<tr class='active'><td>Grand Total Confirmed Orders :</td><td>" + TotalCouponSold + "</td></tr>";
        first += "<tr><td>Total Commission :</td><td>" + PercentCommission.ToString("#.##") + "%</td></tr>";
        first += "<tr class='active'><td>Total Unique Deal :</td><td>" + UniqueDealM1 + "</td></tr>";
        first += "<tr class='success'><td>Deliverd :</td><td><a href='Reports/MonthlyTransactionSummaryReport.aspx?IsDone=10,23,110&Month=" + Month + "&Year=" + Year + "' target='_blank'>" + PercentOfDelivery.ToString("#.##") + "%</a></td></tr>";

        double OnDeliverySum = PercentMerchantGivenToCourierM1 + PercentReadyToPickFromCourierM1;
        first += "<tr class='success'><td>On Delivery :</td><td><a href='Reports/MonthlyTransactionSummaryReport.aspx?IsDone=111,102&Month=" + Month + "&Year=" + Year + "' target='_blank'>" + OnDeliverySum.ToString("#.##") + "%</a><br> Merchant given to courier = <a href='Reports/MonthlyTransactionSummaryReport.aspx?IsDone=111&Month=" + Month + "&Year=" + Year + "' target='_blank'>" + PercentMerchantGivenToCourierM1.ToString("#.##") + "%</a><br />";
        first += "Ready To Pick From Courier = <a href='Reports/MonthlyTransactionSummaryReport.aspx?IsDone=102&Month=" + Month + "&Year=" + Year + "' target='_blank'>" + PercentReadyToPickFromCourierM1.ToString("#.##") + "%</a><br></td></tr>";
        first += "<tr class=''><td>Not Verify Yet :</td><td><a href='Reports/MonthlyTransactionSummaryReport.aspx?IsDone=7,16,19&Month=" + Month + "&Year=" + Year + "' target='_blank'>" + PercentNotVerifyYetM1.ToString("#.##") + " %</a></td></tr>";
        first += "<tr class='warning'><td>Under Verification :</td><td><a href='Reports/MonthlyTransactionSummaryReport.aspx?IsDone=101&Month=" + Month + "&Year=" + Year + "' target='_blank'>" + PercentUnderVerificationM1.ToString("#.##") + " %</a></td></tr>";

        second = "<tr><td>Total Deliverd GMV :</td><td>" + TotalDeliverdGMV + "</td></tr>";
        second += "<tr><td>Total Unique Merchant :</td><td>" + uniqueMerchant + "</td></tr>";
        second += "<tr class='danger'><td>Post-Shipment RTO :</td><td><a href='Reports/MonthlyTransactionSummaryReport.aspx?IsDone=24,17&Month=" + Month + "&Year=" + Year + "' target='_blank'>" + PercentPostShipmentRTOM1.ToString("#.##") + " %</a></td></tr>";

        string RefundM1SumString = "", PercentRefundProcessToCustomerM1String = "", PercentPaymentRefundDoneM1String = "";

        double RefundM1Sum = PercentRefundProcessToCustomerM1 + PercentPaymentRefundDoneM1;
        if (RefundM1Sum == 0)
        {
            RefundM1SumString = "0";
        }

        if (PercentRefundProcessToCustomerM1 == 0)
        {
            PercentRefundProcessToCustomerM1String = "0";
        }

        if (PercentPaymentRefundDoneM1 == 0)
        {
            PercentPaymentRefundDoneM1String = "0";
        }


        second += "<tr class=''><td>Refund Process / Payment Refund :</td><td><a href='Reports/MonthlyTransactionSummaryReport.aspx?IsDone=130,134&Month=" + Month + "&Year=" + Year + "' target='_blank'>" + RefundM1Sum.ToString("#.##") + RefundM1SumString + " %</a><br> Refund Process To Customer = <a href='Reports/MonthlyTransactionSummaryReport.aspx?IsDone=130&Month=" + Month + "&Year=" + Year + "' target='_blank'>" + PercentRefundProcessToCustomerM1.ToString("#.##") + PercentRefundProcessToCustomerM1String + " %</a><br />";
        second += "Payment Refund Done = <a href='Reports/MonthlyTransactionSummaryReport.aspx?IsDone=134&Month=" + Month + "&Year=" + Year + "' target='_blank'>" + PercentPaymentRefundDoneM1.ToString("#.##") + PercentPaymentRefundDoneM1String + " %</a></td></tr>";
        second += "<tr class='warning'><td>Merchant Refuse (Stock issue) :</td><td><a href='Reports/MonthlyTransactionSummaryReport.aspx?IsDone=18&Month=" + Month + "&Year=" + Year + "' target='_blank'>" + PercentMerchantRefuse.ToString("#.##") + " %</a></td></tr>";
        second += "<tr class='active'><td>Customer Did Not Get Product Yet :</td><td><a href='Reports/MonthlyTransactionSummaryReport.aspx?IsDone=105&Month=" + Month + "&Year=" + Year + "' target='_blank'>" + PercentDidNotGetProductYet.ToString("#.##") + " %</a></td></tr>";
        second += "<tr class='danger'><td>Pre-Shipment Rejected By Customer :</td><td><a href='Reports/MonthlyTransactionSummaryReport.aspx?IsDone=155,104&Month=" + Month + "&Year=" + Year + "' target='_blank'>" + PercentPreshipmentM1.ToString("#.##") + " %</a></td></tr>";

        second += "<tr class='active'><td>Pre-Shipment Customer Not Reachable :</td><td><a href='Reports/MonthlyTransactionSummaryReport.aspx?IsDone=324&Month=" + Month + "&Year=" + Year + "' target='_blank'>" + PercentPreShipmentCustomerNotReachableM1.ToString("#.##") + " %</a></td></tr>";
    }


    [WebMethod]
    public static string GetDeliverySpeedDetails(string CompanyId, string Month, string Year, string District, string CompanyName, string Check)
    {
        StringBuilder data = new StringBuilder();
        DataTable DeliverySpeedDataTable;

        data.Append("<div><h3 style='text-align:center;'>" + CompanyName + "</h3></div>");
        data.Append("<table class='table table-hover'>");
        data.Append("<thead>");
        data.Append("<tr>");
        data.Append("<th style='width: 83px;'>SNo.</th><th>Booking Code</th><th>Confirmation Date</th><th>Expected Delivery Date</th><th>Delivered Date</th><th>Difference Date</th><th>Image</th>");
        data.Append("</tr></thead>");

        data.Append("<tbody>");

        if ( Check == "D")
        {
            using (MonthlyTransactionReportM1Gateway ObjMonthlyTransactionReportM1Gateway = new MonthlyTransactionReportM1Gateway())
            {
                DeliverySpeedDataTable = ObjMonthlyTransactionReportM1Gateway.MonthlyDeliverySpeed(Month, Year, CompanyId, District);
            }

        }
        else
        {
            using (MonthlyTransactionReportM1Gateway ObjMonthlyTransactionReportM1Gateway = new MonthlyTransactionReportM1Gateway())
            {
                DeliverySpeedDataTable = ObjMonthlyTransactionReportM1Gateway.MonthlyDeliverySpeed_OutSideDhaka(Month, Year, CompanyId, District);
            }
        }

        if (DeliverySpeedDataTable != null && DeliverySpeedDataTable.Rows.Count > 0)
        {
            int count = 1;
            foreach (DataRow row in DeliverySpeedDataTable.Rows)
            {
                data.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td>{6}</td></tr>",
                count++, row["CouponId"], row["CrmConfirmationDate"], row["ExpectedDeliveryDate"], row["DeliveredDate"], row["DiffDate"],
                "<img src='http://www.ajkerdeal.com/images/Deals/" + row["FolderName"] + "/dealdetails1.jpg' width='60px'>");
            }
        }
        else
        {
            return null;
        }

        data.Append("</tbody></table>");
        return data.ToString();
    }


    [WebMethod]
    public static List<string> GetReportDetailsM1(string CompanyId, string Month, string Year, string CompanyName, string TotalQuantity)
    {
        List<string> ListArray = new List<string>();
        ListArray.Add(GetReportDetails1(CompanyId, Month, Year, CompanyName, TotalQuantity));
        ListArray.Add(GetReportDetails2(CompanyId, Month, Year));
        return ListArray.ToList();
    }

    [WebMethod]
    public static string GetReportDetails1(string CompanyId, string Month, string Year, string CompanyName, string TotalQuantity)
    {
        StringBuilder data = new StringBuilder();
        DataTable dataTable;
        data.Append("<h4 style='text-align:center;'> Company : " + CompanyName + " - " + TotalQuantity + "</h4>");
        data.Append("<div style='height: 200px; overflow: auto;'>");
        data.Append("<table class='table table-hover'>");
        data.Append("<thead>");
        data.Append("<tr>");
        data.Append("<th style='width: 83px;'>SNo.</th><th>Deal Id</th><th>Deal Title</th><th>Total</th>");
        data.Append("</tr></thead>");

        data.Append("<tbody>");

        using (MonthlyTransactionReportM1Gateway objMonthlyTransactionReportM1 = new MonthlyTransactionReportM1Gateway())
        {
            dataTable = objMonthlyTransactionReportM1.MonthlyTransactionReport_M1_DealWise(CompanyId, Month, Year);
        }

        if (dataTable != null && dataTable.Rows.Count > 0)
        {
            int count = 1;
            foreach (DataRow row in dataTable.Rows)
            {
                data.AppendFormat("<tr><td>{0}</td><td><a href='http://www.ajkerdeal.com/dealdetails.aspx?DI={1}'target=_blank>{1}</a></td><td>{2}</td><td>{3}</td></tr>",
                count++, row["DealId"], row["DealTitle"], row["total"]);

            }
        }
        else
        {
            return null;
        }

        data.Append("</tbody></table></div>");
        return data.ToString();
    }


    [WebMethod]
    public static string GetReportDetails2(string CompanyId, string Month, string Year)
    {
        StringBuilder data = new StringBuilder();
        DataTable dataTable;
        int Quantity = 0;
        data.Append("<div style='height: 300px; overflow: auto;'>");
        data.Append("<table class='table table-hover'>");
        data.Append("<thead>");
        data.Append("<tr>");
        data.Append("<th style='width: 83px;'>SNo.</th><th>Booking Code</th><th>Deal Title</th><th>Quantity</th><th>Price</th><th>Commission</th><th>Avg Commission</th><th>Confirmation Date</th><th>Delivered</th>");
        data.Append("</tr></thead>");

        data.Append("<tbody>");
        using (MonthlyTransactionReportM1Gateway objMonthlyTransactionReportM1 = new MonthlyTransactionReportM1Gateway())
        {
            dataTable = objMonthlyTransactionReportM1.MonthlyTransactionReportfirmOrderDetailsM1(Convert.ToInt32(CompanyId), Convert.ToInt32(Month), Convert.ToInt32(Year));
        }

        if (dataTable != null && dataTable.Rows.Count > 0)
        {
            int count = 1;
            foreach (DataRow row in dataTable.Rows)
            {

                Quantity += (int)row["CouponQtn"];
                //row["BookingCode"],
                data.AppendFormat("<tr><td>{0}</td><td>{2}</td><td>{3} (<a href='http://www.ajkerdeal.com/dealdetails.aspx?DI={1}'target=_blank>{1}</a>)</td><td>{4}</td><td>{5}</td><td>{6}</td><td>{7}</td><td>{8}</td><td>{9}</td></tr>",
                count++, row["DealId"], "<span data-toggle='modal' data-target='#DataModel2' onclick='GetDealDetailsPopup(this.id);' id='" + row["CouponId"] + "'><b style='color:#DEB887;cursor:pointer;'>" + row["BookingCode"] + "</b></span>",
                row["DealTitle"], row["CouponQtn"],
                row["CouponPrice"], row["CommissionPerCoupon"], row["AvgCommission"],
                row["CrmConfirmationDate"], row["IsDone"]);

            }
        }
        else
        {
            return null;
        }
        data.Append("<td></td><td></td><td></td><td>Total : " + Quantity + "</td><td></td><td></td><td></td><td></td><td></td>");
        data.Append("</tbody></table></div>");
        return data.ToString();
    }


    [WebMethod]
    public static string LoadServiceExperince(string ProfileId, string Flag, string Month)
    {
        StringBuilder data = new StringBuilder();
        DataTable dataTable;

        data.Append("<h4 style='text-align:center;'>Company Service Experince</h4>");
        data.Append("<table class='table table-hover'>");
        data.Append("<thead>");
        data.Append("<tr>");
        data.Append("<th>SNo.</th><th>Booking Code</th> <th>Product Title</th> <th>Confirmation Date</th> <th>Expected Receiving Date</th> <th>Receiving Date</th>");
        data.Append("<th>Product Quality</th> <th>Overall Experience</th> <th>Will Shop Further</th> <th>Feedback</th> <th>Customer's Query</th><th>Picture</th>");
        
        data.Append("</tr>");
        data.Append("</thead>");

        data.Append("<tbody>");
        using (MonthlyTransactionReportGateway objMonthlyTransactionReportGateway = new MonthlyTransactionReportGateway())
        {
            dataTable = objMonthlyTransactionReportGateway.GetMonthlyOrderReport_CompanyServiceExperince_PopUp(ProfileId, Flag, Month);
        }

        if (dataTable != null && dataTable.Rows.Count > 0)
        {
            int count = 1;

            foreach (DataRow row in dataTable.Rows)
            {
                data.AppendFormat("<tr> <td>{0}</td> <td>{1}</td> <td>{2}</td> <td>{3}</td> <td>{4}</td> <td>{5}</td> <td>{6}</td> <td>{7}</td> <td>{8}</td> <td>{9}</td> <td>{10}</td> <td>{11}</td></tr>",
                count++, row["CouponId"], row["DealTitle"], row["ConfirmationDate"], row["ExpectedDeliveryDate"], row["ReceivedDate"],
                row["ProductQuality"], row["OverAllExperience"], row["FurtherShopping"], row["FeedbackComment"], row["CustomerQuery"],
                "<img src='http://www.ajkerdeal.com/images/Deals/" + row["FolderName"] + "/dealdetails1.jpg' width='60px'>");
            }
        }
        else
        {
            return null;
        }

        data.Append("</tbody></table>");
        return data.ToString();
    }

    [WebMethod]
    public static List<string> GetReportMethod(string Month, string Year, string whichTypeOfCompany, string IsDone, string CompanyName)
    {
        List<string> ListArray = new List<string>();
        ListArray.Add(GetReportMethod_ServiceExperience(whichTypeOfCompany, Month, CompanyName));
        ListArray.Add(GetReportMethod_Info(Month, Year, whichTypeOfCompany, IsDone));
        
        return ListArray.ToList();
    }

    [WebMethod]
    public static string GetReportMethod_ServiceExperience(string whichTypeOfCompany, string Month, String CompanyName)
    {
        StringBuilder data = new StringBuilder();
        DataTable dataTable;

        data.Append("<h4 style='text-align:center;'>Company : " + CompanyName + "</h4>");
        data.Append("<table class='table table-hover'>");
        data.Append("<thead>");
        data.Append("<tr>");
        data.Append("<th>Total</th><th style= 'color:green;'>Good Product Quality</th><th style= 'color:red;'>Bad Product Quality</th><th style= 'color:green;'>Good Experience</th><th style= 'color:red;'>Bad Experience</th><th style= 'color:green;'>Will Shop Further</th><th style= 'color:green;'>Will Not Shop Further</th>");
        data.Append("</tr></thead>");

        data.Append("<tbody>");
        using (MonthlyTransactionReportGateway objMonthlyTransactionReportGateway = new MonthlyTransactionReportGateway())
        {
            dataTable = objMonthlyTransactionReportGateway.GetMonthlyOrderReport_CompanyServiceExperince(Month, whichTypeOfCompany);
        }

        if (dataTable != null && dataTable.Rows.Count > 0)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                data.AppendFormat("<tr><td>{0}</td><td>{1}</td> <td>{2}</td> <td>{3}</td> <td>{4}</td> <td>{5}</td> <td>{6}</td></tr>",
                row["Total"],
                "<a><span data-toggle='modal' data-target='#DataModel2' id='" + row["ProfileID"] + "-1" + "' style= 'color:green; cursor:pointer;' onclick='ServiceExperincePopUp(this.id);'>" + row["GoodProductQuality"] + "</a></span>",
                "<a><span data-toggle='modal' data-target='#DataModel2' id='" + row["ProfileID"] + "-2" + "' style= 'color:red; cursor:pointer;' onclick='ServiceExperincePopUp(this.id);'>" + row["BadProductQuality"] + "</a></span>",
                "<a><span data-toggle='modal' data-target='#DataModel2' id='" + row["ProfileID"] + "-3" + "' style= 'color:green; cursor:pointer;' onclick='ServiceExperincePopUp(this.id);'>" + row["GoodExperience"] + "</a></span>",
                "<a><span data-toggle='modal' data-target='#DataModel2' id='" + row["ProfileID"] + "-4" + "' style= 'color:red; cursor:pointer;' onclick='ServiceExperincePopUp(this.id);'>" + row["BadExperience"] + "</a></span>",
                "<a><span data-toggle='modal' data-target='#DataModel2' id='" + row["ProfileID"] + "-5" + "' style= 'color:green; cursor:pointer;' onclick='ServiceExperincePopUp(this.id);'>" + row["WillFurtherShop"] + "</a></span>",
                "<a><span data-toggle='modal' data-target='#DataModel2' id='" + row["ProfileID"] + "-6" + "' style= 'color:red; cursor:pointer;' onclick='ServiceExperincePopUp(this.id);'>" + row["WillNotFurtherShop"] + "</a></span>");
            }
        }
        else
        {
            return null;
        }

        data.Append("</tbody></table>");
        return data.ToString();
    }

    [WebMethod]
    public static string GetReportMethod_Info(string Month, string Year, string whichTypeOfCompany, string IsDone)
    {
        String ProductQuality = String.Empty;
        StringBuilder data = new StringBuilder();
        DataTable dataTable;

        data.Append("<table class='table table-hover'>");
        data.Append("<thead>");
        data.Append("<tr>");
        data.Append("<th style='width: 83px;'>SNo.</th><th>Booking Code</th><th>Product Quality</th><th>POD Number</th><th>Quantity</th><th>Price</th><th>Deal Title</th><th>Company Name</th><th>Order From</th><th>Courier</th><th>Confirmation Date</th><th>Comments</th><th>Commented By</th><th>Image</th><th>Sold Out</th>");
        data.Append("</tr></thead>");

        data.Append("<tbody>");
        using (MonthlyTransactionReportGateway objMonthlyTransactionReportGateway = new MonthlyTransactionReportGateway())
        {

            dataTable = objMonthlyTransactionReportGateway.GetMonthlyOrderReport(whichTypeOfCompany, Month, Year, IsDone);
        }

        if (dataTable != null && dataTable.Rows.Count > 0)
        {
            int count = 1;
            String IsSoldOut = string.Empty;
            foreach (DataRow row in dataTable.Rows)
            {

                if (row["IsSoldOut"].ToString() == "True")
                {
                    IsSoldOut = "Yes";
                }
                else if (row["IsSoldOut"].ToString() == "False")
                {
                    IsSoldOut = "No";
                }

                if (row["ProductQuality"].ToString() == "Good")
                {
                    ProductQuality = "<span style='color:green;'>" + row["ProductQuality"] + "</span>";
                }

                else 
                {
                    ProductQuality = "<span style='color:red;'>" + row["ProductQuality"] + "</span>"; ;
                }


                data.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{12}</td><td>{3}</td><td>{11}</td><td>{14}</td><td>{4}(<a href='http://www.ajkerdeal.com/dealdetails.aspx?DI={2}'target=_blank>{2}</a>)</td><td>{5}</td><td>{6}</td><td>{7}</td><td>{8}</td><td style='font-family: 'Segoe', 'Segoe UI', 'DejaVu Sans', 'Trebuchet MS', 'Verdana, sans-serif';'>{9}</td><td>{13}</td><td>{10}</td><td>{15}</td></tr>",
                count++, "<span data-toggle='modal' data-target='#DataModel2' onclick='GetDealDetailsPopup(this.id);' id='" + row["CouponId"] + "'><b style='color:#DEB887;cursor:pointer;'>" + row["CouponId"] + "</b></span>",
                row["DealId"], row["PODnumber"], row["DealTitle"], row["CompanyName"], row["OrderFrom"],
                row["Courier"], row["CrmConfirmationDate"], row["Comments"],
                "<img src='http://www.ajkerdeal.com/images/Deals/" + row["FolderName"] + "/dealdetails1.jpg' width='60px'>",
                row["CouponQtn"], ProductQuality, row["CommentedBy"], row["CouponPrice"],
                "<span onclick='SoldOutProduct(this.id);' id='" + row["DealId"] + "'><b style='color:#DEB887;cursor:pointer;'>" + IsSoldOut + "</b></span>");
            }
        }
        else
        {
            return null;
        }

        data.Append("</tbody></table>");
        return data.ToString();
    }

    [WebMethod]
    public static string GetDealDetailsPopupMethod(string CouponId)
    {
        StringBuilder data = new StringBuilder();
        DataTable dataTable;

        data.Append("<h4 style='text-align:center;'>Coupon Details</h4>");
        data.Append("<table class='table table-bordered'>");
        data.Append("<thead>");
        data.Append("<tr>");
        data.Append("<th>SNo.</th><th>User Statistics</th><th>Booking/Coupon Code</th><th>Coupon Qtn. / Payment Amount</th><th>Payment Status/Type</th><th>Recent Comments</th><th>Name/Mobile/Email/Address</th><th>Image</th>");
        data.Append("</tr></thead>");

        data.Append("<tbody>");

        string DealTitle = "-1";
        string FromDate = "";
        string ToDate = "";
        //string ToDate = DateTime.Now.AddDays(1).ToString("MM/dd/yyyy");
        string Mobile = "";
        string Email = "";
        string CustomerName = "";
        string PaymentType = "-1";
        string PaymentStatus = "-1";
        bool IsMotherDeal = false;
        string IsDone = "-1";
        string Top = "200";
        string Company = "";
        string BasedOn = "PostedOn";

        string CommentedBy = string.Empty, CommentedOn = string.Empty;

        using (MonthlyTransactionReportGateway objMonthlyTransactionReportGateway = new MonthlyTransactionReportGateway())
        {
            dataTable = objMonthlyTransactionReportGateway.GetMonthlyOrderReportPopup(DealTitle, FromDate, ToDate, Mobile, Email,
                CouponId, CustomerName, PaymentType, PaymentStatus, IsMotherDeal, IsDone, Top, Company, BasedOn);
        }

        if (dataTable != null && dataTable.Rows.Count > 0)
        {
            int count = 1;
            foreach (DataRow row in dataTable.Rows)
            {

                if (row["CommentedBy1"].ToString() == row["CustomerId"].ToString())
                {
                    CommentedBy = row["CName"].ToString();
                }
                else
                {
                    if (row["CommentedBy1"].ToString() == row["ProfileID"].ToString())
                    {
                        CommentedBy = row["CompanyName"].ToString();
                    }
                    else
                    {
                        CommentedBy = row["CommentedBy"].ToString();
                    }

                }


                object value = row["CommentedOn"];

                if (value == DBNull.Value)
                {
                    CommentedOn = "No Record";
                }
                else
                {
                    CommentedOn = String.Format("{0:f}", value);
                }

                data.AppendFormat("<tr><td>{0}</td><td>Coupon Entry : {1}</td><td>Company Name : {2}<br/>{3}<br/>{4}<br/>{5}<br/>Model : {6}</td><td>Original Price: {7}<br/>{8}<br/>({9})<br/>Inside Dhaka: {10}<br/>Outside Dhaka: {11}</td><td>{12}<br/>({13} / {14})</td><td>{15}<br/>Commented By:<b> {24}</b><br/>Commented On:<b> {25}</b></td><td>{16} - {17}<br/>{18}<br/>{19}<br/>Mobile : {20}<br/>{21}<br/>{22}</td><td>{23}</td></tr>",
                    count++, row["CPostedOn"],
                    row["CompanyName"], row["ContactPerson"], row["Mobile"], row["LoginEmail"], row["BusinessModel"],
                    row["CouponPrice"], row["CouponQtn"], row["PaymentAmount"], row["DeliveryChargeAmount"], row["DeliveryChargeAmountOutSideDhaka"],
                    row["PaymentStatus"], row["PaymentType"], row["CardType"],
                    row["Comments"],
                    row["CName"], row["CMobile"], row["CEmail"], row["CAddress"], row["CustomerMobile"], row["CustomerBillingAddress"], row["District"],
                    "<img src='http://www.ajkerdeal.com/images/Deals/" + row["FolderName"] + "/dealdetails1.jpg' width='60px'>", CommentedBy, CommentedOn);
            }
        }
        else
        {
            return null;
        }

        data.Append("</tbody></table>");
        return data.ToString();
    }

    [WebMethod]
    public static List<string> LoadComments(string CouponId)
    {
        List<string> ListArray = new List<string>();
        ListArray.Add(GetDealDetailsPopupMethod(CouponId));
        ListArray.Add(GetDealComments(CouponId));
        return ListArray.ToList();
    }


    [WebMethod]
    public static string GetDealComments(string CouponId)
    {
        try
        {
            string IsDone = string.Empty;
            StringBuilder StringComments = new StringBuilder();

            StringComments.Append("<table class='table table-bordered' style='margin-top: 10px;'>");
            StringComments.Append("<thead>");
            StringComments.Append("<tr>");
            StringComments.Append("<th>SNo.</th><th>CommentedOn</th><th>Commented By</th><th>Status</th><th>Comments</th>");
            StringComments.Append("</tr></thead>");
            StringComments.Append("<tbody>");

            using (AdminBookingReportGateway objAdminBookingReportGateway = new AdminBookingReportGateway())
            {
                DataTable CommentsDataTable = objAdminBookingReportGateway.LoadComments(int.Parse(CouponId));

                if (CommentsDataTable != null && CommentsDataTable.Rows.Count > 0)
                {
                    int count = 1;
                    foreach (DataRow row in CommentsDataTable.Rows)
                    {
                        if (row["IsDone"].ToString() == "0")
                        {
                            IsDone = "Not Done Yet";
                        }
                        else if (row["IsDone"].ToString() == "2")
                        {
                            IsDone = "FollowUp";
                        }
                        else if (row["IsDone"].ToString() == "16")
                        {
                            IsDone = "Delivery Accepted By Merchant To Customer-16";
                        }
                        else if (row["IsDone"].ToString() == "18")
                        {
                            IsDone = "Customer Order Cancel By Merchant-18";
                        }
                        else if (row["IsDone"].ToString() == "19")
                        {
                            IsDone = "Customer Order Delayed By Merchant-19";
                        }
                        else if (row["IsDone"].ToString() == "4")
                        {
                            IsDone = "Cancel Order";
                        }
                        else if (row["IsDone"].ToString() == "5")
                        {
                            IsDone = "Cancel for AjkerDeal Problem-5";
                        }
                        else if (row["IsDone"].ToString() == "6")
                        {
                            IsDone = "Repeated Order-6";
                        }
                        else if (row["IsDone"].ToString() == "8")
                        {
                            IsDone = "Cancel Order 4 COD outside Dhaka";
                        }
                        else if (row["IsDone"].ToString() == "10")
                        {
                            IsDone = "M1-Delivered To Customer By Merchant-10";
                        }
                        else if (row["IsDone"].ToString() == "11")
                        {
                            IsDone = "UnPaid-Delivered To Curier-11";
                        }
                        else if (row["IsDone"].ToString() == "12")
                        {
                            IsDone = "Office Sell-12";
                        }
                        else if (row["IsDone"].ToString() == "17")
                        {
                            IsDone = "Customer Reject Product-17";
                        }
                        else if (row["IsDone"].ToString() == "21")
                        {
                            IsDone = "Customer Confirmed Received Product From Merchant-21(M1)";
                        }
                        else if (row["IsDone"].ToString() == "22")
                        {
                            IsDone = "Customer Confirmed Received Product From Courier-22(M2/M3)";
                        }
                        else if (row["IsDone"].ToString() == "23")
                        {
                            IsDone = "Accounts Received Payment From Merchant";
                        }
                        else if (row["IsDone"].ToString() == "7")
                        {
                            IsDone = "To Be Delivered by Merchant-7(M1)";
                        }
                        else if (row["IsDone"].ToString() == "111")
                        {
                            IsDone = "Merchant Given Product To courier-111";
                        }
                        else if (row["IsDone"].ToString() == "24")
                        {
                            IsDone = "Customer not available confirm by merchant-24";
                        }
                        else if (row["IsDone"].ToString() == "35")
                        {
                            IsDone = "Merchant is unable to delivery for location-35";
                        }
                        else if (row["IsDone"].ToString() == "101")
                        {
                            IsDone = "M1-On Verification";
                        }
                        else if (row["IsDone"].ToString() == "155")
                        {
                            IsDone = "Preshipment Order Cancel By Customer(M1)-155";
                        }
                        else if (row["IsDone"].ToString() == "104")
                        {
                            IsDone = "Pre Shipment Cancel For Delivery Issue(M1) -104";
                        }
                        else if (row["IsDone"].ToString() == "130")
                        {
                            IsDone = "Refund Process To Customer(M1)-130";
                        }
                        else if (row["IsDone"].ToString() == "134")
                        {
                            IsDone = "Payment Refund Done (M1)-134";
                        }
                        else if (row["IsDone"].ToString() == "105")
                        {
                            IsDone = "Customer did not get the product yet - 105";
                        }
                        else if (row["IsDone"].ToString() == "102")
                        {
                            IsDone = "Ready To Pick From Courier-M1";
                        }
                        else
                        {
                            IsDone = "No data found";
                        }

                        StringComments.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td></tr>",
                            count++, row["CommentedOn"], row["UserName"], IsDone,
                            //row["IsDone"],
                            row["Comments"]);
                    }
                }
                else
                {
                    return null;
                }
            }

            StringComments.Append("</tbody></table>");
            return StringComments.ToString();
        }
        catch (Exception Exp)
        {
            throw new Exception("No data found ", Exp);
        }
    }

    protected void ShowButton_Click(object sender, EventArgs e)
    {
        string month = DropDownMonth.SelectedValue;
        string year = DropDownYear.SelectedValue;
        string OrderBy = "CouponSold";
        ReportM1Method(month, year, OrderBy);
    }
}