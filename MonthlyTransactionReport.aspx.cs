using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Text;

public partial class admin_MonthlyTransactionReport : System.Web.UI.Page
{
    public string CurrentUser = string.Empty, uniqueMerchant = string.Empty;
    public string transReport = string.Empty, first = string.Empty, second = string.Empty, UniqueDealOfConfirmed = String.Empty;
    public int TotalGmv = 0;
    public double TotalCouponSold = 0, PercentOfDelivery = 0, PercentAjkerdealRefuse = 0, PercentPreshipment = 0, PercentPreshipmentM1 = 0, PercentCommission = 0,
        PercentTotalMerchantGivenToCourierM1 = 0, PercentPaidCourier = 0, PercentUnPaidCourier = 0, PercentPackagedWaitForDelivery = 0, PercentUnderVerification = 0, PercentUnderVerificationM1 = 0,
        PercentNotYetConfirmByMerchantM2 = 0, PercentMerchantConfirmButNotYetDeliverdToAD = 0, PercentPreShipmentCustomerNotReachable = 0,
        PercentReturnToMerchant = 0, PercentNotYetReturnToMerchant = 0, PercentPaymentRefund = 0, PercentPaymentRefundM1 = 0, PercentPostShipmentRTOM1 = 0,
        PercentMerchantRefuse = 0, PercentMerchantRefuseM1 = 0, PercentNotVerifyYetM1 = 0;

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

        if (Session["AD_ADMIN_TYPE"] != null && Session["AD_ADMIN_TYPE"] != "")
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
            //Month = "6";
            ReportMethod(Month, Year, OrderBy);
        }
    }

    private void ReportMethod(string Month, string Year, string OrderBy)
    {
        double TotalConfirmed = 0, TotalAjkerdealRefuse = 0, TotalPreshipment = 0, TotalPreshipmentM1 = 0, TotalAmount = 0,
            TotalCommission = 0, TotalPaidCourier = 0, TotalUnPaidCourier = 0, TotalPackagedWaitForDelivery = 0,
            TotalUnderVerification = 0, TotalUnderVerificationM1 = 0, ToatalNotYetConfirmByMerchantM2 = 0, TotalMerchantConfirmButNotYetDeliverdToAD = 0,
            TotalPreShipmentCustomerNotReachable = 0, TotalReturnToMerchant = 0, TotalNotYetReturnToMerchant = 0, TotalPaymentRefund = 0, TotalPaymentRefundM1 = 0,
            TotalMerchantRefuse = 0, TotalMerchantRefuseM1 = 0, TotalMerchantGivenToCourierM1 = 0, TotalPostShipmentRTOM1 = 0, TotalNotVerifyYetM1 = 0;
        double Sumation = 0;

        using (MonthlyTransactionReportGateway objMonthlyTransactionReportGateway = new MonthlyTransactionReportGateway())
        {
            DataTable dt = objMonthlyTransactionReportGateway.MonthlyTransactionReport(Month, Year, OrderBy);

            if (dt != null && dt.Rows.Count > 0)
            {
                uniqueMerchant = dt.Rows.Count.ToString();
                int Count = 1;
                foreach (DataRow row in dt.Rows)
                {
                    // Total Calculation Start
                    TotalGmv += Convert.ToInt32(row["TotalTransaction"]);
                    TotalCouponSold += Convert.ToInt32(row["CouponSold"]);
                    TotalConfirmed += Convert.ToInt32(row["TotalConfirmed"]);
                    TotalAjkerdealRefuse += Convert.ToInt32(row["AjkerdealRefuse"]);
                    TotalPreshipmentM1 += Convert.ToInt32(row["Preshipmentm1"]);
                    TotalPreshipment += Convert.ToInt32(row["Preshipment"]);
                    TotalAmount += Convert.ToInt32(row["TotalTransaction"]);
                    TotalCommission += Convert.ToInt32(row["Commission"]);
                    TotalPaidCourier += Convert.ToInt32(row["PaidCourier"]);
                    TotalUnPaidCourier += Convert.ToInt32(row["UnPaidCourier"]);
                    TotalPackagedWaitForDelivery += Convert.ToInt32(row["ProductWaitForDelivery"]);
                    TotalUnderVerification += Convert.ToInt32(row["VerificationM2"]);
                    TotalUnderVerificationM1 += Convert.ToInt32(row["VerificationM1"]);
                    ToatalNotYetConfirmByMerchantM2 += Convert.ToInt32(row["NotReceivedYetM2"]);
                    TotalMerchantConfirmButNotYetDeliverdToAD += Convert.ToInt32(row["MerchantWaitForDelivery"]);
                    TotalReturnToMerchant += Convert.ToInt32(row["ReturnToMerchant"]);
                    TotalNotYetReturnToMerchant += Convert.ToInt32(row["NotYetReturnToMerchant"]);
                    TotalMerchantGivenToCourierM1 += Convert.ToInt32(row["Courier"]);
                    TotalPostShipmentRTOM1 += Convert.ToInt32(row["NoReach"]);
                    TotalPaymentRefund += Convert.ToInt32(row["Refund"]);
                    TotalPaymentRefundM1 += Convert.ToInt32(row["RefundM1"]);
                    TotalMerchantRefuse += Convert.ToInt32(row["MerchantRefuse"]);
                    TotalMerchantRefuseM1 += Convert.ToInt32(row["MerchantRefuseM1"]);
                    TotalNotVerifyYetM1 += Convert.ToInt32(row["NotVerifyYetM1"]);
                    TotalPreShipmentCustomerNotReachable += Convert.ToInt32(row["PreShipmentCustomerNotReachable"]);
                    // Total Calculation End

                    //Model 1 & Model 2 start
                    string ModelName = string.Empty;
                    string ModelId = row["ModelName"].ToString();
                    string DeliveryId = row["DeliveryStatus"].ToString();

                    if (ModelId == "1" && DeliveryId == "1")
                    {
                        ModelName = "<b> M1</b>";
                    }
                    else if (ModelId == "2" && DeliveryId == "3")
                    {
                        ModelName = "<b> M2</b>";
                    }
                    else
                    {
                        ModelName = "<b> M1,M2</b>";
                    }


                    //Model 1 & Model 2 End

                    // Ready To Pick From Courier M1 Start
                    double ReadyToPickFromCourierM1 = ((Convert.ToDouble(row["ReadyToPickFromCourier"]) / Convert.ToDouble(row["CouponSold"])) * 100);
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


                    // Deliverd Start
                    double Delivery = ((Convert.ToDouble(row["TotalConfirmed"]) / Convert.ToDouble(row["CouponSold"])) * 100);
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

                    // PaidDeliveryCourier Start
                    double PaidDeliveryCourier = ((Convert.ToDouble(row["PaidCourier"]) / Convert.ToDouble(row["CouponSold"])) * 100);
                    string CalPaidDeliveryCourier = String.Format("{0:0.##}", PaidDeliveryCourier);

                    if (CalPaidDeliveryCourier == "0")
                    {
                        CalPaidDeliveryCourier = "0 %";
                    }
                    else
                    {
                        CalPaidDeliveryCourier = CalPaidDeliveryCourier + "%";
                    }
                    // PaidDeliveryCourier End

                    // UnPaidDeliveryCourier Start
                    double UnPaidDeliveryCourier = ((Convert.ToDouble(row["UnPaidCourier"]) / Convert.ToDouble(row["CouponSold"])) * 100);
                    string CalUnPaidDeliveryCourier = String.Format("{0:0.##}", UnPaidDeliveryCourier);

                    if (CalUnPaidDeliveryCourier == "0")
                    {
                        CalUnPaidDeliveryCourier = "0 %";
                    }
                    else
                    {
                        CalUnPaidDeliveryCourier = CalUnPaidDeliveryCourier + "%";
                    }
                    // UnPaidDeliveryCourier End

                    // Not Yet Confirm By Merchant M2 Start
                    double NotYetConfirmByMerchantM2 = ((Convert.ToDouble(row["NotReceivedYetM2"]) / Convert.ToDouble(row["CouponSold"])) * 100);
                    string CalNotYetConfirmByMerchantM2 = String.Format("{0:0.##}", NotYetConfirmByMerchantM2);

                    if (CalNotYetConfirmByMerchantM2 == "0")
                    {
                        CalNotYetConfirmByMerchantM2 = "0 %";
                    }
                    else
                    {
                        CalNotYetConfirmByMerchantM2 = CalNotYetConfirmByMerchantM2 + "%";
                    }
                    // Not Yet Confirm By Merchant M2 End

                    // Merchant Confirm But Not Yet Deliverd To AD Start
                    double MerchantConfirmButNotYetDeliverdToAD = ((Convert.ToDouble(row["MerchantWaitForDelivery"]) / Convert.ToDouble(row["CouponSold"])) * 100);
                    string CalMerchantConfirmButNotYetDeliverdToAD = String.Format("{0:0.##}", MerchantConfirmButNotYetDeliverdToAD);

                    if (CalMerchantConfirmButNotYetDeliverdToAD == "0")
                    {
                        CalMerchantConfirmButNotYetDeliverdToAD = "0 %";
                    }
                    else
                    {
                        CalMerchantConfirmButNotYetDeliverdToAD = CalMerchantConfirmButNotYetDeliverdToAD + "%";
                    }
                    // Merchant Confirm But Not Yet Deliverd To AD End

                    // Product Wait For Delivery Start
                    double ProductWaitForDelivery = ((Convert.ToDouble(row["ProductWaitForDelivery"]) / Convert.ToDouble(row["CouponSold"])) * 100);
                    string CalProductWaitForDelivery = String.Format("{0:0.##}", ProductWaitForDelivery);

                    if (CalProductWaitForDelivery == "0")
                    {
                        CalProductWaitForDelivery = "0 %";
                    }
                    else
                    {
                        CalProductWaitForDelivery = CalProductWaitForDelivery + "%";
                    }
                    // Product Wait For Delivery End


                    // Merchant Refuse M1 Start
                    double MerchantRefuseM1 = ((Convert.ToDouble(row["MerchantCancle"]) / Convert.ToDouble(row["CouponSold"])) * 100);
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


                    // Merchant Refuse M2 Start
                    double MerchantRefuseM2 = ((Convert.ToDouble(row["MerchantCancle2"]) / Convert.ToDouble(row["CouponSold"])) * 100);
                    double RefuseNumber = 5.0;
                    string RefuseRed = "#ff0000";

                    string RefuseRedColour = "";
                    if (MerchantRefuseM2 > RefuseNumber)
                    {
                        RefuseRedColour = RefuseRed;
                    }

                    string CalMerchantRefuseM2 = String.Format("{0:0.##}", MerchantRefuseM2);
                    if (CalMerchantRefuseM2 == "0")
                    {
                        CalMerchantRefuseM2 = "0 %";
                    }
                    else
                    {
                        CalMerchantRefuseM2 = CalMerchantRefuseM2 + "%";
                    }
                    // Merchant Refuse M2 End


                    // Not Verify Yet M1 Start
                    double NotVerifyYetM1 = ((Convert.ToDouble(row["NotVerifyYetM1"]) / Convert.ToDouble(row["CouponSold"])) * 100);
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


                    // Ajkerdeal Refuse QC Start
                    double AjkerdealRefuseQC = ((Convert.ToDouble(row["AjkerdealRefuse"]) / Convert.ToDouble(row["CouponSold"])) * 100);
                    string CalAjkerdealRefuseQC = String.Format("{0:0.##}", AjkerdealRefuseQC);
                    if (CalAjkerdealRefuseQC == "0")
                    {
                        CalAjkerdealRefuseQC = "0 %";
                    }
                    else
                    {
                        CalAjkerdealRefuseQC = CalAjkerdealRefuseQC + "%";
                    }
                    // Ajkerdeal Refuse QC End


                    //Pre-Shipment Reject By Customer M1 Start
                    double PreShipmentRejectByCustomerM1 = ((Convert.ToDouble(row["Preshipmentm1"]) / Convert.ToDouble(row["CouponSold"])) * 100);
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

                    //Pre-Shipment Reject By Customer M2 Start
                    double PreShipmentRejectByCustomer = ((Convert.ToDouble(row["Preshipment"]) / Convert.ToDouble(row["CouponSold"])) * 100);
                    string CalPreShipmentRejectByCustomer = String.Format("{0:0.##}", PreShipmentRejectByCustomer);
                    if (CalPreShipmentRejectByCustomer == "0")
                    {
                        CalPreShipmentRejectByCustomer = "0 %";
                    }
                    else
                    {
                        CalPreShipmentRejectByCustomer = CalPreShipmentRejectByCustomer + "%";
                    }
                    //Pre-Shipment Reject By Customer M2 End

                    // Post-Shipment RTO Start M1
                    double PostShipmentRTOM1 = ((Convert.ToDouble(row["NoReach"]) / Convert.ToDouble(row["CouponSold"])) * 100);
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


                    // Post-Shipment RTO Start M2
                    double PostShipmentRTO = ((Convert.ToDouble(row["Reject"]) / Convert.ToDouble(row["CouponSold"])) * 100);
                    double Number = 10.0;
                    string Red = "#ff0000";

                    string RedColour = "";
                    if (PostShipmentRTO > Number)
                    {
                        RedColour = Red;
                    }
                    string CalPostShipmentRTO = String.Format("{0:0.##}", PostShipmentRTO);
                    if (CalPostShipmentRTO == "0")
                    {
                        CalPostShipmentRTO = "0 %";
                    }
                    else
                    {
                        CalPostShipmentRTO = CalPostShipmentRTO + "%";
                    }
                    // Post-Shipment RTO End M2


                    // Under Verification M1 Start
                    double UnderVerificationM1 = ((Convert.ToDouble(row["VerificationM1"]) / Convert.ToDouble(row["CouponSold"])) * 100);
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


                    // Under Verification M2 Start
                    double UnderVerificationM2 = ((Convert.ToDouble(row["VerificationM2"]) / Convert.ToDouble(row["CouponSold"])) * 100);
                    string CalUnderVerificationM2 = String.Format("{0:0.##}", UnderVerificationM2);
                    if (CalUnderVerificationM2 == "0")
                    {
                        CalUnderVerificationM2 = "0 %";
                    }
                    else
                    {
                        CalUnderVerificationM2 = CalUnderVerificationM2 + "%";
                    }
                    // Under Verification M2 End

                    // Merchant Given To Courier M1 Start
                    double MerchantGivenToCourierM1 = ((Convert.ToDouble(row["Courier"]) / Convert.ToDouble(row["CouponSold"])) * 100);
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


                    // Pre-Shipment Customer Not Reachable Start
                    double PreShipmentCustomerNotReachable = ((Convert.ToDouble(row["PreShipmentCustomerNotReachable"]) / Convert.ToDouble(row["CouponSold"])) * 100);
                    string CalPreShipmentCustomerNotReachable = String.Format("{0:0.##}", PreShipmentCustomerNotReachable);
                    if (CalPreShipmentCustomerNotReachable == "0")
                    {
                        CalPreShipmentCustomerNotReachable = "0 %";
                    }
                    else
                    {
                        CalPreShipmentCustomerNotReachable = CalPreShipmentCustomerNotReachable + "%";
                    }
                    // Pre-Shipment Customer Not Reachable End





                    Sumation = Delivery + MerchantGivenToCourierM1 + PaidDeliveryCourier + UnPaidDeliveryCourier +
                        NotVerifyYetM1 + NotYetConfirmByMerchantM2 + MerchantConfirmButNotYetDeliverdToAD
                        + ProductWaitForDelivery + MerchantRefuseM1 + MerchantRefuseM2 + AjkerdealRefuseQC +
                        PreShipmentRejectByCustomerM1 + PreShipmentRejectByCustomer + PreShipmentCustomerNotReachable +
                        PostShipmentRTOM1 + PostShipmentRTO + UnderVerificationM1 + UnderVerificationM2 + ReadyToPickFromCourierM1;


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
                    string AvgPercentCommissionCoupon = String.Format("{0:0.00}", row["AvgPercentCommissionCoupon"]);
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
                    double SuccessfullyProcessed = Delivery + MerchantGivenToCourierM1 + UnPaidDeliveryCourier + PaidDeliveryCourier + ProductWaitForDelivery;
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


                    //CalPreShipmentCustomerNotReachable
                    string DateRange = Convert.ToString(row["InsertedOn"]);
                    string M1Status = "7,10,16,19,23,111,18,17,24,35,101,155,104,130,134,109,105,102,324,110";
                    string M2Status = "1,3,9,11,12,13,32,15,20,33,5,55,117,124,125,204,28,201,34,30,31,41,109,224";

                    transReport = transReport + "<tr><td>" + Count++ + "</td><td>" + row["CompanyName"] + ModelName + "</td><td>" + DateRange + "</td><td data-toggle='modal' data-target='#myModal'><span style='cursor: pointer;' id ='" + row["ProfileId"] + "-" + row["CompanyName"] + "-" + row["CouponSold"] + "' onclick = 'GetReportsDetails(this.id);'>" + row["CouponSold"] + "</span></td><td data-toggle='modal' data-target='#myModal'><span style='cursor: pointer;' id ='" + row["ProfileId"] + "-" + M1Status + "' onclick = 'GetReports(this.id);'>" + row["M1"] + "</span></td><td data-toggle='modal' data-target='#myModal'><span style='cursor: pointer;' id ='" + row["ProfileId"] + "-" + M2Status + "' onclick = 'GetReports(this.id);'>" + row["M2"] + "</span></td><td data-toggle='modal' data-target='#myModal'><span style='cursor: pointer;' id ='" + row["ProfileId"] + "-9,10,109,110,23' onclick = 'GetReports(this.id);'>" + CalDeliverd + "</span></td><td data-toggle='modal' data-target='#myModal'><span style='cursor: pointer;' id ='" + row["ProfileId"] + "-111' onclick = 'GetReports(this.id);'>" + CalMerchantGivenToCourierM1 + "</span></td><td data-toggle='modal' data-target='#myModal'><span style='cursor: pointer;' id ='" + row["ProfileId"] + "-13,32' onclick = 'GetReports(this.id);'>" + CalProductWaitForDelivery + "</span></td><td data-toggle='modal' data-target='#myModal'><span style='cursor: pointer;' id ='" + row["ProfileId"] + "-1' onclick = 'GetReports(this.id);'>" + CalPaidDeliveryCourier + "</span></td><td data-toggle='modal' data-target='#myModal'><span style='cursor: pointer;' id ='" + row["ProfileId"] + "-11' onclick = 'GetReports(this.id);'>" + CalUnPaidDeliveryCourier + "</span></td><td data-toggle='modal' data-target='#myModal'><span style='cursor: pointer; color:" + color + "' id ='" + row["ProfileId"] + "-9,10,109,23,111,13,32,1,11' onclick = 'GetReports(this.id);'>" + CalSuccessfullyProcessed + "</span></td><td data-toggle='modal' data-target='#myModal'><span style='cursor: pointer;' id ='" + row["ProfileId"] + "-7,16,19' onclick = 'GetReports(this.id);'>" + CalNotVerifyYetM1 + "</span></td><td data-toggle='modal' data-target='#myModal'><span style='cursor: pointer;' id ='" + row["ProfileId"] + "-101' onclick = 'GetReports(this.id);'>" + CalUnderVerificationM1 + "</span></td><td data-toggle='modal' data-target='#myModal'><span style='cursor: pointer;' id ='" + row["ProfileId"] + "-201' onclick = 'GetReports(this.id);'>" + CalUnderVerificationM2 + "</span></td><td data-toggle='modal' data-target='#myModal'><span style='cursor: pointer;' id ='" + row["ProfileId"] + "-33,20,3,12' onclick = 'GetReports(this.id);'>" + CalNotYetConfirmByMerchantM2 + "</span></td><td data-toggle='modal' data-target='#myModal'><span style='cursor: pointer;' id ='" + row["ProfileId"] + "-15' onclick = 'GetReports(this.id);'>" + CalMerchantConfirmButNotYetDeliverdToAD + "</span></td><td data-toggle='modal' data-target='#myModal'><span style='cursor: pointer; color:" + RefuseRedColourM1 + "' id ='" + row["ProfileId"] + "-18,130,134' onclick = 'GetReports(this.id);'>" + CalMerchantRefuseM1 + "<span></td><td data-toggle='modal' data-target='#myModal'><span style='cursor: pointer; color:" + RefuseRedColour + "' id ='" + row["ProfileId"] + "-28,30,34' onclick = 'GetReports(this.id);'>" + CalMerchantRefuseM2 + "<span></td><td data-toggle='modal' data-target='#myModal'><span style='cursor: pointer;' id ='" + row["ProfileId"] + "-125' onclick = 'GetReports(this.id);'>" + CalAjkerdealRefuseQC + "<span></td><td data-toggle='modal' data-target='#myModal'><span style='cursor: pointer;' id ='" + row["ProfileId"] + "-155,35,104' onclick = 'GetReports(this.id);'>" + CalPreShipmentRejectByCustomerM1 + "</span></td><td data-toggle='modal' data-target='#myModal'><span style='cursor: pointer;' id ='" + row["ProfileId"] + "-5,55,204,41,255' onclick = 'GetReports(this.id);'>" + CalPreShipmentRejectByCustomer + "</span></td><td data-toggle='modal' data-target='#myModal'><span style='cursor: pointer;' id ='" + row["ProfileId"] + "-102' onclick = 'GetReports(this.id);'>" + CalReadyToPickFromCourierM1 + "</span></td><td data-toggle='modal' data-target='#myModal'><span style='cursor: pointer;' id ='" + row["ProfileId"] + "-324,224' onclick = 'GetReports(this.id);'>" + CalPreShipmentCustomerNotReachable + "</span></td><td data-toggle='modal' data-target='#myModal'><span style='cursor: pointer; color:" + RedColourM1 + "' id ='" + row["ProfileId"] + "-24,17' onclick = 'GetReports(this.id);'>" + CalPostShipmentRTOM1 + "</span></td><td data-toggle='modal' data-target='#myModal'><span style='cursor: pointer; color:" + RedColour + "' id ='" + row["ProfileId"] + "-117,124,31' onclick = 'GetReports(this.id);'>" + CalPostShipmentRTO + "</span></td><td>" + CalSumation + "</td><td>" + row["EValuePerTransaction"] + "</td><td>" + AvgPercentCommissionCoupon + "</td><td>" + row["TotalTransaction"] + "</td></tr>";

                }

                if (TotalCouponSold != 0)
                {
                    PercentOfDelivery = (TotalConfirmed / TotalCouponSold) * 100;
                    PercentAjkerdealRefuse = (TotalAjkerdealRefuse / TotalCouponSold) * 100;
                    PercentPreshipmentM1 = (TotalPreshipmentM1 / TotalCouponSold) * 100;
                    PercentPreshipment = (TotalPreshipment / TotalCouponSold) * 100;
                    PercentCommission = (TotalCommission / TotalAmount) * 100;
                    PercentTotalMerchantGivenToCourierM1 = (TotalMerchantGivenToCourierM1 / TotalCouponSold) * 100;
                    PercentPaidCourier = (TotalPaidCourier / TotalCouponSold) * 100;
                    PercentUnPaidCourier = (TotalUnPaidCourier / TotalCouponSold) * 100;
                    PercentPackagedWaitForDelivery = (TotalPackagedWaitForDelivery / TotalCouponSold) * 100;
                    PercentUnderVerification = (TotalUnderVerification / TotalCouponSold) * 100;
                    PercentUnderVerificationM1 = (TotalUnderVerificationM1 / TotalCouponSold) * 100;
                    PercentNotYetConfirmByMerchantM2 = (ToatalNotYetConfirmByMerchantM2 / TotalCouponSold) * 100;
                    PercentMerchantConfirmButNotYetDeliverdToAD = (TotalMerchantConfirmButNotYetDeliverdToAD / TotalCouponSold) * 100;

                    PercentReturnToMerchant = (TotalReturnToMerchant / TotalCouponSold) * 100;
                    PercentNotYetReturnToMerchant = (TotalNotYetReturnToMerchant / TotalCouponSold) * 100;
                    PercentPaymentRefund = (TotalPaymentRefund / TotalCouponSold) * 100;
                    PercentPaymentRefundM1 = (TotalPaymentRefundM1 / TotalCouponSold) * 100;
                    PercentMerchantRefuseM1 = (TotalMerchantRefuseM1 / TotalCouponSold) * 100;
                    PercentMerchantRefuse = (TotalMerchantRefuse / TotalCouponSold) * 100;
                    PercentPostShipmentRTOM1 = (TotalPostShipmentRTOM1 / TotalCouponSold) * 100;
                    PercentNotVerifyYetM1 = (TotalNotVerifyYetM1 / TotalCouponSold) * 100;
                    PercentPreShipmentCustomerNotReachable = (TotalPreShipmentCustomerNotReachable / TotalCouponSold) * 100;
                }
            }
        }

        using (MonthlyTransactionReportGateway ObjMonthlyTransactionReportGateway = new MonthlyTransactionReportGateway())
        {
            Month = DropDownMonth.SelectedValue;
            Year = DropDownYear.SelectedValue;

            DataTable dataTable = ObjMonthlyTransactionReportGateway.MonthlyOrderUniqueDeal(Month, Year);
            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    UniqueDealOfConfirmed = Convert.ToString(dataTable.Rows[i]["Deal_SKU"]);
                }
            }
        }

        string PercentAjkerdealRefuseString = "", PercentMerchantRefuseString = "", PercentPaymentRefundString ="";

        if (PercentAjkerdealRefuse == 0)
        {
            PercentAjkerdealRefuseString = "0";
        }

         if (PercentMerchantRefuse == 0)
        {
            PercentMerchantRefuseString = "0";
        }
         if (PercentPaymentRefund == 0)
         {
             PercentPaymentRefundString = "0";
         }


        first = "<tr class='active'><td>Grand Total GMV :</td><td>Tk. " + TotalGmv + "</td></tr>";
        first += "<tr class='active'><td>Total Unique Merchant :</td><td>" + uniqueMerchant + "</td></tr>";
        first += "<tr class='active'><td>Grand Total Confirmed Orders :</td><td>" + TotalCouponSold + "</td></tr>";
        first += "<tr><td>Total Commission :</td><td>" + PercentCommission.ToString("#.##") + "%</td></tr>";
        first += "<tr class='active'><td>Total Unique Deal :</td><td>" + UniqueDealOfConfirmed + "</td></tr>";
        first += "<tr class='success'><td>Deliverd :</td><td><a href='Reports/MonthlyTransactionSummaryReport.aspx?IsDone=9,10,109,110,23&Month=" + Month + "&Year=" + Year + "' target='_blank'>" + PercentOfDelivery.ToString("#.##") + "%</a></td></tr>";

        double OnDeliverySum = PercentPackagedWaitForDelivery + PercentPaidCourier + PercentUnPaidCourier + PercentTotalMerchantGivenToCourierM1 + PercentUnderVerificationM1 + PercentUnderVerification;

        first += "<tr class='success'><td>On Delivery : </td><td><a href='Reports/MonthlyTransactionSummaryReport.aspx?IsDone=1,11,111,101,105,201,13,32&Month=" + Month + "&Year=" + Year + "' target='_blank'>" + OnDeliverySum.ToString("#.##") + "%</a><br /> Packaged Wait For Delivery =<a href='Reports/MonthlyTransactionSummaryReport.aspx?IsDone=13,32&Month=" + Month + "&Year=" + Year + "' target='_blank'>" + PercentPackagedWaitForDelivery.ToString("#.##") + " %</a><br />";
        first += "Paid to courier (Not Phone) =<a href='Reports/MonthlyTransactionSummaryReport.aspx?IsDone=1&Month=" + Month + "&Year=" + Year + "' target='_blank'>" + PercentPaidCourier.ToString("#.##") + "%</a><br>UnPaid to courier (Not Phone) =<a href='Reports/MonthlyTransactionSummaryReport.aspx?IsDone=11&Month=" + Month + "&Year=" + Year + "' target='_blank'>" + PercentUnPaidCourier.ToString("#.##") + " %</a><br>";
        first += "Merchant given to courier (Not Phone) =<a href='Reports/MonthlyTransactionSummaryReport.aspx?IsDone=111&Month=" + Month + "&Year=" + Year + "' target='_blank'>" + PercentTotalMerchantGivenToCourierM1.ToString("#.##") + " %</a><br>";
        first += "Under Verification M1 (Phone) =<a href='Reports/MonthlyTransactionSummaryReport.aspx?IsDone=101,105&Month=" + Month + "&Year=" + Year + "' target='_blank'>" + PercentUnderVerificationM1.ToString("#.##") + " %</a><br>";
        first += "Under Verification M2 (Phone) =<a href='Reports/MonthlyTransactionSummaryReport.aspx?IsDone=201&Month=" + Month + "&Year=" + Year + "' target='_blank'>" + PercentUnderVerification.ToString("#.##") + " %</a><br></td></tr>";

        first += "<tr class='active'><td>Not Verify Yet M1 :</td><td><a href='Reports/MonthlyTransactionSummaryReport.aspx?IsDone=7,16,19&Month=" + Month + "&Year=" + Year + "' target='_blank'>" + PercentNotVerifyYetM1.ToString("#.##") + " %</a></td></tr>";


        second = "<tr class='danger'><td>Post-Shipment RTO M1 :</td><td><a href='Reports/MonthlyTransactionSummaryReport.aspx?IsDone=24,17&Month=" + Month + "&Year=" + Year + "' target='_blank'>" + PercentPostShipmentRTOM1.ToString("#.##") + " %</a></td></tr>";

        double PostShipmentRTOM2Sum = PercentReturnToMerchant + PercentNotYetReturnToMerchant;

        second += "<tr class='danger'><td>Post-Shipment RTO M2 : </td><td><a href='Reports/MonthlyTransactionSummaryReport.aspx?IsDone=117,124,31&Month=" + Month + "&Year=" + Year + "' target='_blank'>" + PostShipmentRTOM2Sum.ToString("#.##") + "%</a><br />Not yet return to merchant =<a href='Reports/MonthlyTransactionSummaryReport.aspx?IsDone=117,124&Month=" + Month + "&Year=" + Year + "' target='_blank'>" + PercentNotYetReturnToMerchant.ToString("#.##") + " %</a><br />";
        second += "Return to merchant =<a href='Reports/MonthlyTransactionSummaryReport.aspx?IsDone=31&Month=" + Month + "&Year=" + Year + "' target='_blank'>" + PercentReturnToMerchant.ToString("#.##") + " %</a></td></tr>";

        double MerchantRefuseM2Sum = PercentMerchantRefuse + PercentPaymentRefund;
        second += "<tr class='warning'><td>Merchant Refuse M2: </td><td><a href='Reports/MonthlyTransactionSummaryReport.aspx?IsDone=30,34,28&Month=" + Month + "&Year=" + Year + "' target='_blank'>" + MerchantRefuseM2Sum.ToString("#.##") + "%</a><br />Merchant Refuse =<a href='Reports/MonthlyTransactionSummaryReport.aspx?IsDone=28&Month=" + Month + "&Year=" + Year + "' target='_blank'>" + PercentMerchantRefuse.ToString("#.##") + PercentMerchantRefuseString + " %</a><br />";
        second += "Payment Refund =<a href='Reports/MonthlyTransactionSummaryReport.aspx?IsDone=30,34&Month=" + Month + "&Year=" + Year + "' target='_blank'>" + PercentPaymentRefund.ToString("#.##") + PercentPaymentRefundString + " %</a></td></tr>";

        double MerchantRefuseM1Sum = PercentPaymentRefundM1 + PercentMerchantRefuseM1;
        second += "<tr class='warning'><td>Merchant Refuse M1: </td><td><a href='Reports/MonthlyTransactionSummaryReport.aspx?IsDone=130,134,18&Month=" + Month + "&Year=" + Year + "' target='_blank'>" + MerchantRefuseM1Sum.ToString("#.##") + "%</a><br />Merchant Refuse =<a href='Reports/MonthlyTransactionSummaryReport.aspx?IsDone=18&Month=" + Month + "&Year=" + Year + "' target='_blank'>" + PercentMerchantRefuseM1.ToString("#.##") + " %</a><br />";
        second += "Payment Refund =<a href='Reports/MonthlyTransactionSummaryReport.aspx?IsDone=130,134&Month=" + Month + "&Year=" + Year + "' target='_blank'>" + PercentPaymentRefundM1.ToString("#.##") + " %</a></td></tr>";

        second += "<tr class='warning'><td>Ajkerdeal Refuse (QC) :</td><td><a href='Reports/MonthlyTransactionSummaryReport.aspx?IsDone=125&Month=" + Month + "&Year=" + Year + "' target='_blank'> " + PercentAjkerdealRefuse.ToString("#.##") + PercentAjkerdealRefuseString + " %</a></td></tr>";
        second += "<tr><td>Pre-Shipment Rejected By Customer M1 :</td><td><a href='Reports/MonthlyTransactionSummaryReport.aspx?IsDone=155,35,104&Month=" + Month + "&Year=" + Year + "' target='_blank'>" + PercentPreshipmentM1.ToString("#.##") + " %</a></td></tr>";
        second += "<tr><td>Pre-Shipment Rejected By Customer M2 :</td><td><a href='Reports/MonthlyTransactionSummaryReport.aspx?IsDone=5,55,204,41,255&Month=" + Month + "&Year=" + Year + "' target='_blank'>" + PercentPreshipment.ToString("#.##") + " %</a></td></tr>";
        second += "<tr><td>Not Yet Confirm By Merchant M2 :</td><td><a href='Reports/MonthlyTransactionSummaryReport.aspx?IsDone=33,20,3,12&Month=" + Month + "&Year=" + Year + "' target='_blank'>" + PercentNotYetConfirmByMerchantM2.ToString("#.##") + " %</a></td></tr>";
        second += "<tr class='info'><td>Merchant Confirm But Not Yet Deliverd To AD :</td><td><a href='Reports/MonthlyTransactionSummaryReport.aspx?IsDone=15&Month=" + Month + "&Year=" + Year + "' target='_blank'>" + PercentMerchantConfirmButNotYetDeliverdToAD.ToString("#.##") + " %</a></td></tr>";
        second += "<tr class='info'><td>Pre-Shipment Customer Not Reachable :</td><td><a href='Reports/MonthlyTransactionSummaryReport.aspx?IsDone=324,224&Month=" + Month + "&Year=" + Year + "' target='_blank'>" + PercentPreShipmentCustomerNotReachable.ToString("#.##") + " %</a></td></tr>";

    }


    [WebMethod]
    public static List<string> GetM2Report(string month, string year)
    {
        List<string> ListArray = new List<string>();
        ListArray.Add(GetM2ReportTable(month, year));
        ListArray.Add(GetM2ReportFirst(month, year));
        ListArray.Add(GetM2ReportSecond(month, year));
        return ListArray.ToList();
    }

    [WebMethod]
    public static string GetM2ReportSecond(string month, string year)
    {
        string OrderBy = "CouponSold", second = string.Empty;
        int TotalGmv = 0;
        double TotalCouponSold = 0, PercentOfDelivery = 0, PercentAjkerdealRefuse = 0, PercentPreshipment = 0, PercentPreshipmentM1 = 0, PercentCommission = 0,
                PercentTotalMerchantGivenToCourierM1 = 0, PercentPaidCourier = 0, PercentUnPaidCourier = 0, PercentPackagedWaitForDelivery = 0, PercentUnderVerification = 0, PercentUnderVerificationM1 = 0,
                PercentNotYetConfirmByMerchantM2 = 0, PercentMerchantConfirmButNotYetDeliverdToAD = 0, PercentPostShipmentRTO = 0,
                PercentReturnToMerchant = 0, PercentNotYetReturnToMerchant = 0, PercentPaymentRefund = 0, PercentPaymentRefundM1 = 0, PercentPostShipmentRTOM1 = 0,
                PercentMerchantRefuse = 0, PercentMerchantRefuseM1 = 0, PercentNotVerifyYetM1 = 0;

        double TotalConfirmed = 0, TotalAjkerdealRefuse = 0, TotalPreshipment = 0, TotalPreshipmentM1 = 0, TotalAmount = 0,
            TotalCommission = 0, TotalPaidCourier = 0, TotalUnPaidCourier = 0, TotalPackagedWaitForDelivery = 0,
            TotalUnderVerification = 0, TotalUnderVerificationM1 = 0, ToatalNotYetConfirmByMerchantM2 = 0, TotalMerchantConfirmButNotYetDeliverdToAD = 0,
            TotalPostShipmentRTO = 0, TotalReturnToMerchant = 0, TotalNotYetReturnToMerchant = 0, TotalPaymentRefund = 0, TotalPaymentRefundM1 = 0,
            TotalMerchantRefuse = 0, TotalMerchantRefuseM1 = 0, TotalMerchantGivenToCourierM1 = 0, TotalPostShipmentRTOM1 = 0, TotalNotVerifyYetM1 = 0;


        using (MonthlyTransactionReportGateway objMonthlyTransactionReportGateway = new MonthlyTransactionReportGateway())
        {
            DataTable dt = objMonthlyTransactionReportGateway.MonthlyTransactionReport(month, year, OrderBy);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    // Total Calculation Start
                    //TotalGmv += Convert.ToInt32(row["TotalTransaction"]);
                    TotalCouponSold += Convert.ToInt32(row["CouponSold"]);
                    TotalConfirmed += Convert.ToInt32(row["TotalConfirmed"]);
                    TotalAjkerdealRefuse += Convert.ToInt32(row["AjkerdealRefuse"]);
                    TotalPreshipmentM1 += Convert.ToInt32(row["Preshipmentm1"]);
                    TotalPreshipment += Convert.ToInt32(row["Preshipment"]);
                    //TotalAmount += Convert.ToInt32(row["TotalTransaction"]);
                    //TotalCommission += Convert.ToInt32(row["Commission"]);
                    //TotalPaidCourier += Convert.ToInt32(row["PaidCourier"]);
                    //TotalUnPaidCourier += Convert.ToInt32(row["UnPaidCourier"]);
                    TotalPackagedWaitForDelivery += Convert.ToInt32(row["ProductWaitForDelivery"]);
                    TotalUnderVerification += Convert.ToInt32(row["VerificationM2"]);
                    TotalUnderVerificationM1 += Convert.ToInt32(row["VerificationM1"]);
                    ToatalNotYetConfirmByMerchantM2 += Convert.ToInt32(row["NotReceivedYetM2"]);
                    TotalMerchantConfirmButNotYetDeliverdToAD += Convert.ToInt32(row["MerchantWaitForDelivery"]);
                    //TotalPostShipmentRTO += Convert.ToInt32(row["Reject"]);
                    TotalReturnToMerchant += Convert.ToInt32(row["ReturnToMerchant"]);
                    TotalNotYetReturnToMerchant += Convert.ToInt32(row["NotYetReturnToMerchant"]);
                    //TotalMerchantGivenToCourierM1 += Convert.ToInt32(row["Courier"]);
                    TotalPostShipmentRTOM1 += Convert.ToInt32(row["NoReach"]);
                    TotalPaymentRefund += Convert.ToInt32(row["Refund"]);
                    TotalPaymentRefundM1 += Convert.ToInt32(row["RefundM1"]);
                    TotalMerchantRefuse += Convert.ToInt32(row["MerchantRefuse"]);
                    TotalMerchantRefuseM1 += Convert.ToInt32(row["MerchantRefuseM1"]);
                    //TotalNotVerifyYetM1 += Convert.ToInt32(row["NotVerifyYetM1"]);
                    // Total Calculation End

                    if (TotalCouponSold != 0)
                    {
                        //PercentOfDelivery = (TotalConfirmed / TotalCouponSold) * 100;
                        PercentAjkerdealRefuse = (TotalAjkerdealRefuse / TotalCouponSold) * 100;
                        PercentPreshipmentM1 = (TotalPreshipmentM1 / TotalCouponSold) * 100;
                        PercentPreshipment = (TotalPreshipment / TotalCouponSold) * 100;
                        //PercentCommission = (TotalCommission / TotalAmount) * 100;
                        //PercentTotalMerchantGivenToCourierM1 = (TotalMerchantGivenToCourierM1 / TotalCouponSold) * 100;
                        //PercentPaidCourier = (TotalPaidCourier / TotalCouponSold) * 100;
                        //PercentUnPaidCourier = (TotalUnPaidCourier / TotalCouponSold) * 100;
                        //PercentPackagedWaitForDelivery = (TotalPackagedWaitForDelivery / TotalCouponSold) * 100;
                        //PercentUnderVerification = (TotalUnderVerification / TotalCouponSold) * 100;
                        //PercentUnderVerificationM1 = (TotalUnderVerificationM1 / TotalCouponSold) * 100;
                        PercentNotYetConfirmByMerchantM2 = (ToatalNotYetConfirmByMerchantM2 / TotalCouponSold) * 100;
                        PercentMerchantConfirmButNotYetDeliverdToAD = (TotalMerchantConfirmButNotYetDeliverdToAD / TotalCouponSold) * 100;
                        //PercentPostShipmentRTO = (TotalPostShipmentRTO / TotalCouponSold) * 100;
                        PercentReturnToMerchant = (TotalReturnToMerchant / TotalCouponSold) * 100;
                        PercentNotYetReturnToMerchant = (TotalNotYetReturnToMerchant / TotalCouponSold) * 100;
                        PercentPaymentRefund = (TotalPaymentRefund / TotalCouponSold) * 100;
                        PercentPaymentRefundM1 = (TotalPaymentRefundM1 / TotalCouponSold) * 100;
                        PercentMerchantRefuseM1 = (TotalMerchantRefuseM1 / TotalCouponSold) * 100;
                        PercentMerchantRefuse = (TotalMerchantRefuse / TotalCouponSold) * 100;
                        PercentPostShipmentRTOM1 = (TotalPostShipmentRTOM1 / TotalCouponSold) * 100;
                        //PercentNotVerifyYetM1 = (TotalNotVerifyYetM1 / TotalCouponSold) * 100;
                    }
                }
            }
        }

        second = "<tr class='danger'><td>Post-Shipment RTO M1 :</td><td>" + PercentPostShipmentRTOM1.ToString("#.##") + " %</td></tr>";

        double PostShipmentRTOM2Sum = PercentReturnToMerchant + PercentNotYetReturnToMerchant;
        second += "<tr class='danger'><td>Post-Shipment RTO M2 : </td><td>" + PostShipmentRTOM2Sum.ToString("#.##") + "%<br />Not yet return to merchant =" + PercentNotYetReturnToMerchant.ToString("#.##") + " %<br />";
        second += "Return to merchant =" + PercentReturnToMerchant.ToString("#.##") + " %</td></tr>";

        double MerchantRefuseM2Sum = PercentMerchantRefuse + PercentPaymentRefund;
        second += "<tr class='warning'><td>Merchant Refuse M2: </td><td>" + MerchantRefuseM2Sum.ToString("#.##") + "%<br />Merchant Refuse =" + PercentMerchantRefuse.ToString("#.##") + " %<br />";
        second += "Payment Refund =" + PercentPaymentRefund.ToString("#.##") + " %</td></tr>";

        double MerchantRefuseM1Sum = PercentPaymentRefundM1 + PercentMerchantRefuseM1;
        second += "<tr class='warning'><td>Merchant Refuse M1: </td><td>" + MerchantRefuseM1Sum.ToString("#.##") + "%<br />Merchant Refuse =" + PercentMerchantRefuseM1.ToString("#.##") + " %<br />";
        second += "Payment Refund =" + PercentPaymentRefundM1.ToString("#.##") + " %</td></tr>";

        second += "<tr class='warning'><td>Ajkerdeal Refuse (QC) :</td><td>" + PercentAjkerdealRefuse.ToString("#.##") + " %</td></tr>";
        second += "<tr><td>Pre-Shipment Rejected By Customer M1 :</td><td>" + PercentPreshipmentM1.ToString("#.##") + " %</td></tr>";
        second += "<tr><td>Pre-Shipment Rejected By Customer M2 :</td><td>" + PercentPreshipment.ToString("#.##") + " %</td></tr>";
        second += "<tr><td>Not Yet Confirm By Merchant M2 :</td><td>" + PercentNotYetConfirmByMerchantM2.ToString("#.##") + " %</td></tr>";
        second += "<tr class='info'><td>Merchant Confirm But Not Yet Deliverd To AD :</td><td>" + PercentMerchantConfirmButNotYetDeliverdToAD.ToString("#.##") + " %</td></tr>";

        return second;
    }


    [WebMethod]
    public static string GetM2ReportFirst(string month, string year)
    {
        string OrderBy = "CouponSold", first = string.Empty;
        int TotalGmv = 0;
        double TotalCouponSold = 0, PercentOfDelivery = 0, PercentAjkerdealRefuse = 0, PercentPreshipment = 0, PercentPreshipmentM1 = 0, PercentCommission = 0,
        PercentTotalMerchantGivenToCourierM1 = 0, PercentPaidCourier = 0, PercentUnPaidCourier = 0, PercentPackagedWaitForDelivery = 0, PercentUnderVerification = 0, PercentUnderVerificationM1 = 0,
        PercentNotYetConfirmByMerchantM2 = 0, PercentMerchantConfirmButNotYetDeliverdToAD = 0, PercentPostShipmentRTO = 0,
        PercentReturnToMerchant = 0, PercentNotYetReturnToMerchant = 0, PercentPaymentRefund = 0, PercentPaymentRefundM1 = 0, PercentPostShipmentRTOM1,
        PercentMerchantRefuse = 0, PercentMerchantRefuseM1 = 0, PercentNotVerifyYetM1 = 0;

        double TotalConfirmed = 0, TotalAjkerdealRefuse = 0, TotalPreshipment = 0, TotalPreshipmentM1 = 0, TotalAmount = 0,
            TotalCommission = 0, TotalPaidCourier = 0, TotalUnPaidCourier = 0, TotalPackagedWaitForDelivery = 0,
            TotalUnderVerification = 0, TotalUnderVerificationM1 = 0, ToatalNotYetConfirmByMerchantM2 = 0, TotalMerchantConfirmButNotYetDeliverdToAD = 0,
            TotalPostShipmentRTO = 0, TotalReturnToMerchant = 0, TotalNotYetReturnToMerchant = 0, TotalPaymentRefund = 0, TotalPaymentRefundM1 = 0,
            TotalMerchantRefuse = 0, TotalMerchantRefuseM1 = 0, TotalMerchantGivenToCourierM1 = 0, TotalPostShipmentRTOM1 = 0, TotalNotVerifyYetM1 = 0;

        using (MonthlyTransactionReportGateway objMonthlyTransactionReportGateway = new MonthlyTransactionReportGateway())
        {
            DataTable dt = objMonthlyTransactionReportGateway.MonthlyTransactionReport(month, year, OrderBy);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    // Total Calculation Start
                    TotalGmv += Convert.ToInt32(row["TotalTransaction"]);
                    TotalCouponSold += Convert.ToInt32(row["CouponSold"]);
                    TotalConfirmed += Convert.ToInt32(row["TotalConfirmed"]);
                    //TotalAjkerdealRefuse += Convert.ToInt32(row["AjkerdealRefuse"]);
                    //TotalPreshipmentM1 += Convert.ToInt32(row["Preshipmentm1"]);
                    //TotalPreshipment += Convert.ToInt32(row["Preshipment"]);
                    TotalAmount += Convert.ToInt32(row["TotalTransaction"]);
                    TotalCommission += Convert.ToInt32(row["Commission"]);
                    TotalPaidCourier += Convert.ToInt32(row["PaidCourier"]);
                    TotalUnPaidCourier += Convert.ToInt32(row["UnPaidCourier"]);
                    TotalPackagedWaitForDelivery += Convert.ToInt32(row["ProductWaitForDelivery"]);
                    TotalUnderVerification += Convert.ToInt32(row["VerificationM2"]);
                    TotalUnderVerificationM1 += Convert.ToInt32(row["VerificationM1"]);
                    //ToatalNotYetConfirmByMerchantM2 += Convert.ToInt32(row["NotReceivedYetM2"]);
                    //TotalMerchantConfirmButNotYetDeliverdToAD += Convert.ToInt32(row["MerchantWaitForDelivery"]);
                    //TotalPostShipmentRTO += Convert.ToInt32(row["Reject"]);
                    //TotalReturnToMerchant += Convert.ToInt32(row["ReturnToMerchant"]);
                    //TotalNotYetReturnToMerchant += Convert.ToInt32(row["NotYetReturnToMerchant"]);
                    TotalMerchantGivenToCourierM1 += Convert.ToInt32(row["Courier"]);
                    //TotalPostShipmentRTOM1 += Convert.ToInt32(row["NoReach"]);
                    //TotalPaymentRefund += Convert.ToInt32(row["Refund"]);
                    //TotalPaymentRefundM1 += Convert.ToInt32(row["RefundM1"]);
                    //TotalMerchantRefuse += Convert.ToInt32(row["MerchantRefuse"]);
                    //TotalMerchantRefuseM1 += Convert.ToInt32(row["MerchantRefuseM1"]);
                    TotalNotVerifyYetM1 += Convert.ToInt32(row["NotVerifyYetM1"]);
                    // Total Calculation End

                    if (TotalCouponSold != 0)
                    {
                        PercentOfDelivery = (TotalConfirmed / TotalCouponSold) * 100;
                        //PercentAjkerdealRefuse = (TotalAjkerdealRefuse / TotalCouponSold) * 100;
                        PercentPreshipmentM1 = (TotalPreshipmentM1 / TotalCouponSold) * 100;
                        PercentPreshipment = (TotalPreshipment / TotalCouponSold) * 100;
                        PercentCommission = (TotalCommission / TotalAmount) * 100;
                        PercentTotalMerchantGivenToCourierM1 = (TotalMerchantGivenToCourierM1 / TotalCouponSold) * 100;
                        PercentPaidCourier = (TotalPaidCourier / TotalCouponSold) * 100;
                        PercentUnPaidCourier = (TotalUnPaidCourier / TotalCouponSold) * 100;
                        PercentPackagedWaitForDelivery = (TotalPackagedWaitForDelivery / TotalCouponSold) * 100;
                        PercentUnderVerification = (TotalUnderVerification / TotalCouponSold) * 100;
                        PercentUnderVerificationM1 = (TotalUnderVerificationM1 / TotalCouponSold) * 100;
                        //PercentNotYetConfirmByMerchantM2 = (ToatalNotYetConfirmByMerchantM2 / TotalCouponSold) * 100;
                        //PercentMerchantConfirmButNotYetDeliverdToAD = (TotalMerchantConfirmButNotYetDeliverdToAD / TotalCouponSold) * 100;
                        //PercentPostShipmentRTO = (TotalPostShipmentRTO / TotalCouponSold) * 100;
                        //PercentReturnToMerchant = (TotalReturnToMerchant / TotalCouponSold) * 100;
                        //PercentNotYetReturnToMerchant = (TotalNotYetReturnToMerchant / TotalCouponSold) * 100;
                        //PercentPaymentRefund = (TotalPaymentRefund / TotalCouponSold) * 100;
                        //PercentPaymentRefundM1 = (TotalPaymentRefundM1 / TotalCouponSold) * 100;
                        //PercentMerchantRefuseM1 = (TotalMerchantRefuseM1 / TotalCouponSold) * 100;
                        //PercentMerchantRefuse = (TotalMerchantRefuse / TotalCouponSold) * 100;
                        //PercentPostShipmentRTOM1 = (TotalPostShipmentRTOM1 / TotalCouponSold) * 100;
                        PercentNotVerifyYetM1 = (TotalNotVerifyYetM1 / TotalCouponSold) * 100;
                    }
                }
            }
        }

        string UniqueDealOfConfirmed = string.Empty;
        using (MonthlyTransactionReportGateway ObjMonthlyTransactionReportGateway = new MonthlyTransactionReportGateway())
        {
            DataTable dataTable = ObjMonthlyTransactionReportGateway.MonthlyOrderUniqueDeal(month, year);
            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    UniqueDealOfConfirmed = Convert.ToString(dataTable.Rows[i]["Deal_SKU"]);
                }
            }
        }

        first = "<tr class='active'><td>Grand Total GMV :</td><td>" + TotalGmv + "Tk.</td></tr>";
        first += "<tr class='active'><td>Grand Total Confirmed Orders :</td><td>" + TotalCouponSold + "</td></tr>";
        first += "<tr><td>Total Commission :</td><td>" + PercentCommission.ToString("#.##") + "%</td></tr>";
        first += "<tr class='active'><td>Total Unique Deal :</td><td>" + UniqueDealOfConfirmed + "</td></tr>";
        //first += "<tr class='active'><td>Total Unique Merchant :</td><td>" + 0 + "</td></tr>";
        first += "<tr class='success'><td>Deliverd :</td><td>" + PercentOfDelivery.ToString("#.##") + "%</td></tr>";

        double OnDeliverySum = PercentPackagedWaitForDelivery + PercentPaidCourier + PercentUnPaidCourier + PercentTotalMerchantGivenToCourierM1 + PercentUnderVerificationM1 + PercentUnderVerification;

        first += "<tr class='success'><td>On Delivery : </td><td>" + OnDeliverySum.ToString("#.##") + "%<br />Packaged Wait For Delivery =" + PercentPackagedWaitForDelivery.ToString("#.##") + " %<br />";
        first += "Paid to courier (Not Phone) =" + PercentPaidCourier.ToString("#.##") + "%<br>UnPaid to courier (Not Phone) =" + PercentUnPaidCourier.ToString("#.##") + " %<br>";
        first += "Merchant given to courier (Not Phone) =" + PercentTotalMerchantGivenToCourierM1.ToString("#.##") + " %<br>";
        first += "Under Verification M1 (Phone) =" + PercentUnderVerificationM1.ToString("#.##") + " %<br>";
        first += "Under Verification M2 (Phone) =" + PercentUnderVerification.ToString("#.##") + " %<br></td></tr>";
        first += "<tr class='active'><td>Not Verify Yet M1 :</td><td>" + PercentNotVerifyYetM1.ToString("#.##") + " %</td></tr>";

        return first;
    }


    [WebMethod]
    public static string GetM2ReportTable(string Month, string Year)
    {
        string OrderBy = "CouponSold", transReport = string.Empty;
        double Sumation = 0;

        using (MonthlyTransactionReportGateway objMonthlyTransactionReportGateway = new MonthlyTransactionReportGateway())
        {
            DataTable dt = objMonthlyTransactionReportGateway.MonthlyTransactionReport(Month, Year, OrderBy);

            if (dt != null && dt.Rows.Count > 0)
            {
                int Count = 1;
                foreach (DataRow row in dt.Rows)
                {

                    // Deliverd Start
                    double Delivery = ((Convert.ToDouble(row["TotalConfirmed"]) / Convert.ToDouble(row["CouponSold"])) * 100);
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

                    // PaidDeliveryCourier Start
                    double PaidDeliveryCourier = ((Convert.ToDouble(row["PaidCourier"]) / Convert.ToDouble(row["CouponSold"])) * 100);
                    string CalPaidDeliveryCourier = String.Format("{0:0.##}", PaidDeliveryCourier);

                    if (CalPaidDeliveryCourier == "0")
                    {
                        CalPaidDeliveryCourier = "0 %";
                    }
                    else
                    {
                        CalPaidDeliveryCourier = CalPaidDeliveryCourier + "%";
                    }
                    // PaidDeliveryCourier End

                    // UnPaidDeliveryCourier Start
                    double UnPaidDeliveryCourier = ((Convert.ToDouble(row["UnPaidCourier"]) / Convert.ToDouble(row["CouponSold"])) * 100);
                    string CalUnPaidDeliveryCourier = String.Format("{0:0.##}", UnPaidDeliveryCourier);

                    if (CalUnPaidDeliveryCourier == "0")
                    {
                        CalUnPaidDeliveryCourier = "0 %";
                    }
                    else
                    {
                        CalUnPaidDeliveryCourier = CalUnPaidDeliveryCourier + "%";
                    }
                    // UnPaidDeliveryCourier End

                    // Not Yet Confirm By Merchant M2 Start
                    double NotYetConfirmByMerchantM2 = ((Convert.ToDouble(row["NotReceivedYetM2"]) / Convert.ToDouble(row["CouponSold"])) * 100);
                    string CalNotYetConfirmByMerchantM2 = String.Format("{0:0.##}", NotYetConfirmByMerchantM2);

                    if (CalNotYetConfirmByMerchantM2 == "0")
                    {
                        CalNotYetConfirmByMerchantM2 = "0 %";
                    }
                    else
                    {
                        CalNotYetConfirmByMerchantM2 = CalNotYetConfirmByMerchantM2 + "%";
                    }
                    // Not Yet Confirm By Merchant M2 End

                    // Merchant Confirm But Not Yet Deliverd To AD Start
                    double MerchantConfirmButNotYetDeliverdToAD = ((Convert.ToDouble(row["MerchantWaitForDelivery"]) / Convert.ToDouble(row["CouponSold"])) * 100);
                    string CalMerchantConfirmButNotYetDeliverdToAD = String.Format("{0:0.##}", MerchantConfirmButNotYetDeliverdToAD);

                    if (CalMerchantConfirmButNotYetDeliverdToAD == "0")
                    {
                        CalMerchantConfirmButNotYetDeliverdToAD = "0 %";
                    }
                    else
                    {
                        CalMerchantConfirmButNotYetDeliverdToAD = CalMerchantConfirmButNotYetDeliverdToAD + "%";
                    }
                    // Merchant Confirm But Not Yet Deliverd To AD End

                    // Product Wait For Delivery Start
                    double ProductWaitForDelivery = ((Convert.ToDouble(row["ProductWaitForDelivery"]) / Convert.ToDouble(row["CouponSold"])) * 100);
                    string CalProductWaitForDelivery = String.Format("{0:0.##}", ProductWaitForDelivery);

                    if (CalProductWaitForDelivery == "0")
                    {
                        CalProductWaitForDelivery = "0 %";
                    }
                    else
                    {
                        CalProductWaitForDelivery = CalProductWaitForDelivery + "%";
                    }
                    // Product Wait For Delivery End


                    // Merchant Refuse M2 Start
                    double MerchantRefuseM1 = ((Convert.ToDouble(row["MerchantCancle"]) / Convert.ToDouble(row["CouponSold"])) * 100);
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
                    // Merchant Refuse M2 End


                    // Merchant Refuse M2 Start
                    double MerchantRefuseM2 = ((Convert.ToDouble(row["MerchantCancle2"]) / Convert.ToDouble(row["CouponSold"])) * 100);
                    double RefuseNumber = 5.0;
                    string RefuseRed = "#ff0000";

                    string RefuseRedColour = "";
                    if (MerchantRefuseM2 > RefuseNumber)
                    {
                        RefuseRedColour = RefuseRed;
                    }

                    string CalMerchantRefuseM2 = String.Format("{0:0.##}", MerchantRefuseM2);
                    if (CalMerchantRefuseM2 == "0")
                    {
                        CalMerchantRefuseM2 = "0 %";
                    }
                    else
                    {
                        CalMerchantRefuseM2 = CalMerchantRefuseM2 + "%";
                    }
                    // Merchant Refuse M2 End


                    // Not Verify Yet M1 Start
                    double NotVerifyYetM1 = ((Convert.ToDouble(row["NotVerifyYetM1"]) / Convert.ToDouble(row["CouponSold"])) * 100);
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


                    // Ajkerdeal Refuse QC Start
                    double AjkerdealRefuseQC = ((Convert.ToDouble(row["AjkerdealRefuse"]) / Convert.ToDouble(row["CouponSold"])) * 100);
                    string CalAjkerdealRefuseQC = String.Format("{0:0.##}", AjkerdealRefuseQC);
                    if (CalAjkerdealRefuseQC == "0")
                    {
                        CalAjkerdealRefuseQC = "0 %";
                    }
                    else
                    {
                        CalAjkerdealRefuseQC = CalAjkerdealRefuseQC + "%";
                    }
                    // Ajkerdeal Refuse QC End


                    //Pre-Shipment Reject By Customer M1 Start
                    double PreShipmentRejectByCustomerM1 = ((Convert.ToDouble(row["Preshipmentm1"]) / Convert.ToDouble(row["CouponSold"])) * 100);
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

                    //Pre-Shipment Reject By Customer M2 Start
                    double PreShipmentRejectByCustomer = ((Convert.ToDouble(row["Preshipment"]) / Convert.ToDouble(row["CouponSold"])) * 100);
                    string CalPreShipmentRejectByCustomer = String.Format("{0:0.##}", PreShipmentRejectByCustomer);
                    if (CalPreShipmentRejectByCustomer == "0")
                    {
                        CalPreShipmentRejectByCustomer = "0 %";
                    }
                    else
                    {
                        CalPreShipmentRejectByCustomer = CalPreShipmentRejectByCustomer + "%";
                    }
                    //Pre-Shipment Reject By Customer M2 End

                    // Post-Shipment RTO Start M1
                    double PostShipmentRTOM1 = ((Convert.ToDouble(row["NoReach"]) / Convert.ToDouble(row["CouponSold"])) * 100);
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


                    // Post-Shipment RTO Start M2
                    double PostShipmentRTO = ((Convert.ToDouble(row["Reject"]) / Convert.ToDouble(row["CouponSold"])) * 100);
                    double Number = 10.0;
                    string Red = "#ff0000";

                    string RedColour = "";
                    if (PostShipmentRTO > Number)
                    {
                        RedColour = Red;
                    }
                    string CalPostShipmentRTO = String.Format("{0:0.##}", PostShipmentRTO);
                    if (CalPostShipmentRTO == "0")
                    {
                        CalPostShipmentRTO = "0 %";
                    }
                    else
                    {
                        CalPostShipmentRTO = CalPostShipmentRTO + "%";
                    }
                    // Post-Shipment RTO End M2



                    // Under Verification M1 Start
                    double UnderVerificationM1 = ((Convert.ToDouble(row["VerificationM1"]) / Convert.ToDouble(row["CouponSold"])) * 100);
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


                    // Under Verification M2 Start
                    double UnderVerificationM2 = ((Convert.ToDouble(row["VerificationM2"]) / Convert.ToDouble(row["CouponSold"])) * 100);
                    string CalUnderVerificationM2 = String.Format("{0:0.##}", UnderVerificationM2);
                    if (CalUnderVerificationM2 == "0")
                    {
                        CalUnderVerificationM2 = "0 %";
                    }
                    else
                    {
                        CalUnderVerificationM2 = CalUnderVerificationM2 + "%";
                    }
                    // Under Verification M2 End

                    // Merchant Given To Courier M1 Start
                    double MerchantGivenToCourierM1 = ((Convert.ToDouble(row["Courier"]) / Convert.ToDouble(row["CouponSold"])) * 100);
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

                    double ExtraAll = ((Convert.ToDouble(row["Extra"]) / Convert.ToDouble(row["CouponSold"])) * 100);



                    Sumation = Delivery + MerchantGivenToCourierM1 + PaidDeliveryCourier + UnPaidDeliveryCourier +
                        NotVerifyYetM1 + NotYetConfirmByMerchantM2 + MerchantConfirmButNotYetDeliverdToAD
                        + ProductWaitForDelivery + MerchantRefuseM1 + MerchantRefuseM2 + AjkerdealRefuseQC +
                        PreShipmentRejectByCustomerM1 + PreShipmentRejectByCustomer +
                        PostShipmentRTOM1 + PostShipmentRTO + UnderVerificationM1 + UnderVerificationM2 + ExtraAll;


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
                    string AvgPercentCommissionCoupon = String.Format("{0:0.00}", row["AvgPercentCommissionCoupon"]);
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
                    double SuccessfullyProcessed = Delivery + MerchantGivenToCourierM1 + UnPaidDeliveryCourier + PaidDeliveryCourier + ProductWaitForDelivery;
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


                    string ComProfileId = Convert.ToString(row["ProfileId"]);
                    string CompanyName = Convert.ToString(row["CompanyName"]);
                    string GetCompanyTime = string.Empty;
                    TimeSpan New, Medium, Old;
                    string Status = string.Empty;

                    // Delivery Speed for MonthlyTransaction Start
                    string CalAvgDeliverySpeedDhaka = string.Empty, CalAvgDeliverySpeed = string.Empty;

                    using (MonthlyTransactionReportGateway ObjMonthlyTransactionReportGateway = new MonthlyTransactionReportGateway())
                    {
                        int SumOfDiffDate = 0, SumOfDiffDateDhaka = 0, DeliverySpeedCount = 0, DeliverySpeedCountDhaka = 0,
                            AvgDeliverySpeedDhaka = 0, AvgDeliverySpeed = 0;
                        string Dhaka = "14", OutSideDhaka = "14";

                        DataTable DeliverySpeedDataTable = objMonthlyTransactionReportGateway.MonthlyDeliverySpeed(Month, Year, ComProfileId, Dhaka);
                        DataTable DataTableOutSideDhaka = objMonthlyTransactionReportGateway.MonthlyDeliverySpeed(Month, Year, ComProfileId, OutSideDhaka);
                        if (DeliverySpeedDataTable.Rows.Count > 0)
                        {
                            for (int i = 0; i < DeliverySpeedDataTable.Rows.Count; i++)
                            {
                                SumOfDiffDateDhaka += Convert.ToInt32(DeliverySpeedDataTable.Rows[i]["DiffDate"]);
                            }
                            DeliverySpeedCountDhaka = DeliverySpeedDataTable.Rows.Count;
                        }

                        if (DataTableOutSideDhaka.Rows.Count > 0)
                        {
                            for (int i = 0; i < DataTableOutSideDhaka.Rows.Count; i++)
                            {
                                SumOfDiffDate += Convert.ToInt32(DeliverySpeedDataTable.Rows[i]["DiffDate"]);
                            }

                            DeliverySpeedCount = DataTableOutSideDhaka.Rows.Count;
                        }

                        if (DeliverySpeedCountDhaka != 0)
                        {
                            AvgDeliverySpeedDhaka = SumOfDiffDateDhaka / DeliverySpeedCountDhaka;
                            CalAvgDeliverySpeedDhaka = String.Format("{0:0.##}", AvgDeliverySpeedDhaka);

                            if (CalAvgDeliverySpeedDhaka == "0")
                            {
                                CalAvgDeliverySpeedDhaka = "0 %";
                            }
                            else
                            {
                                CalAvgDeliverySpeedDhaka = CalAvgDeliverySpeedDhaka + "%";
                            }
                        }

                        if (DeliverySpeedCount != 0)
                        {
                            AvgDeliverySpeed = SumOfDiffDate / DeliverySpeedCount;
                            CalAvgDeliverySpeed = String.Format("{0:0.##}", AvgDeliverySpeed);

                            if (CalAvgDeliverySpeed == "0")
                            {
                                CalAvgDeliverySpeed = "0 %";
                            }
                            else
                            {
                                CalAvgDeliverySpeed = CalAvgDeliverySpeed + "%";
                            }
                        }

                    }
                    // Delivery Speed for MonthlyTransaction End


                    using (MonthlyTransactionReportGateway ObjMonthlyTransactionReportGateway = new MonthlyTransactionReportGateway())
                    {
                        GetCompanyTime = ObjMonthlyTransactionReportGateway.GetInsertedTime(ComProfileId);
                        DateTime Time = Convert.ToDateTime(GetCompanyTime);
                        string StrTime = string.Empty;
                        StrTime = Time.ToShortDateString();


                        DateTime Today = DateTime.Today;

                        string ToDate = DateTime.Now.ToShortDateString();

                        //string FromDate = DateTime.Now.AddMonths(-2).ToShortDateString();
                        string FromDate = DateTime.Now.AddDays(-29).ToShortDateString();

                        // string FromDateMedium = DateTime.Now.AddMonths(-5).ToShortDateString();
                        string FromDateMedium = DateTime.Now.AddDays(-89).ToShortDateString();

                        if (Convert.ToDateTime(StrTime) >= Convert.ToDateTime(FromDate) && Convert.ToDateTime(StrTime) <= Convert.ToDateTime(ToDate))
                        {
                            New = Today - Time;
                            //New = Today.Subtract(Time);
                            string New2 = Convert.ToString(New.TotalDays);
                            New2 = New2.Substring(0, 3);
                            //New2 = New2.Substring(0, New2.Length - 9);
                            Status = "<b>New</b> " + New2 + " Days";
                        }

                        else if (Convert.ToDateTime(StrTime) >= Convert.ToDateTime(FromDateMedium) && Convert.ToDateTime(StrTime) <= Convert.ToDateTime(FromDate))
                        {
                            Medium = Today - Time;
                            //Medium = Today.Subtract(Time);
                            string Medium2 = Convert.ToString(Medium.TotalDays);
                            Medium2 = Medium2.Substring(0, 3);
                            //Medium2 = Medium2.Substring(0, Medium2.Length - 9);
                            Status = "<b>Medium</b> " + Medium2 + " Days";
                        }

                        else
                        {
                            Old = Today - Time;
                            //Old = Today.Subtract(Time);
                            string Old2 = Convert.ToString(Old.TotalDays);
                            Old2 = Old2.Substring(0, 3);
                            //Old2 = Old2.Substring(0, Old2.Length - 9);
                            Status = "<b>Old</b> " + Old2 + " Days";
                        }
                    }

                    //transReport = transReport + "<tr data-toggle='modal' data-target='#myModal'><td>" + Count++ + "</td><td>" + row["CompanyName"] + "</td><td>" + Status + "</td><td><span style='cursor: pointer;' id ='" + row["ProfileId"] + "' onclick = 'GetReportsDetails(this.id);'>" + row["CouponSold"] + "</span></td><td>" + row["M1"] + "</td><td>" + row["M2"] + "</td><td><span style='cursor: pointer;' id ='" + row["ProfileId"] + "-9,10,109,23' onclick = 'GetReports(this.id);'>" + CalDeliverd + "</span></td><td><span style='cursor: pointer;' id ='" + row["ProfileId"] + "-111' onclick = 'GetReports(this.id);'>" + CalMerchantGivenToCourierM1 + "</span></td><td <span style='cursor: pointer;' id ='" + row["ProfileId"] + "-13,32' onclick = 'GetReports(this.id);'>" + CalProductWaitForDelivery + "</span></td><td <span style='cursor: pointer;' id ='" + row["ProfileId"] + "-1' onclick = 'GetReports(this.id);'>" + CalPaidDeliveryCourier + "</span></td><td <span style='cursor: pointer;' id ='" + row["ProfileId"] + "-11' onclick = 'GetReports(this.id);'>" + CalUnPaidDeliveryCourier + "</span></td><td <span style='cursor: pointer; color:" + color + "' id ='" + row["ProfileId"] + "-9,10,109,23,111,13,32,1,11' onclick = 'GetReports(this.id);'>" + CalSuccessfullyProcessed + "</span></td><td><span style='cursor: pointer;' id ='" + row["ProfileId"] + "-7,16,19' onclick = 'GetReports(this.id);'>" + CalNotVerifyYetM1 + "</span></td><td <span style='cursor: pointer;' id ='" + row["ProfileId"] + "-33,20,3,12' onclick = 'GetReports(this.id);'>" + CalNotYetConfirmByMerchantM2 + "</span></td><td <span style='cursor: pointer;' id ='" + row["ProfileId"] + "-15' onclick = 'GetReports(this.id);'>" + CalMerchantConfirmButNotYetDeliverdToAD + "</span></td><td <span style='cursor: pointer; color:" + RefuseRedColourM1 + "' id ='" + row["ProfileId"] + "-18,130,134' onclick = 'GetReports(this.id);'>" + CalMerchantRefuseM1 + "<span></td><td <span style='cursor: pointer; color:" + RefuseRedColour + "' id ='" + row["ProfileId"] + "-28,30,34' onclick = 'GetReports(this.id);'>" + CalMerchantRefuseM2 + "<span></td><td <span style='cursor: pointer;' id ='" + row["ProfileId"] + "-125' onclick = 'GetReports(this.id);'>" + CalAjkerdealRefuseQC + "<span></td><td <span style='cursor: pointer;' id ='" + row["ProfileId"] + "-155,35,104' onclick = 'GetReports(this.id);'>" + CalPreShipmentRejectByCustomerM1 + "</span></td><td <span style='cursor: pointer;' id ='" + row["ProfileId"] + "-5,55,204' onclick = 'GetReports(this.id);'>" + CalPreShipmentRejectByCustomer + "</span></td><td <span style='cursor: pointer;' id ='" + row["ProfileId"] + "-101' onclick = 'GetReports(this.id);'>" + CalUnderVerificationM1 + "</span></td><td <span style='cursor: pointer;' id ='" + row["ProfileId"] + "-201' onclick = 'GetReports(this.id);'>" + CalUnderVerificationM2 + "</span></td><td <span style='cursor: pointer; color:" + RedColourM1 + "' id ='" + row["ProfileId"] + "-24,17' onclick = 'GetReports(this.id);'>" + CalPostShipmentRTOM1 + "</span></td><td <span style='cursor: pointer; color:" + RedColour + "' id ='" + row["ProfileId"] + "-117,124,31' onclick = 'GetReports(this.id);'>" + CalPostShipmentRTO + "</span></td><td>" + CalSumation + "</td><td>" + row["EValuePerTransaction"] + "</td><td>" + AvgPercentCommissionCoupon + "</td><td>" + row["TotalTransaction"] + "</td></tr>";
                    transReport = transReport + "<tr data-toggle='modal' data-target='#myModal'><td>" + Count++ + "</td><td>" + row["CompanyName"] + "</td><td><span style='cursor: pointer;' id ='" + row["ProfileId"] + "' onclick = 'GetDeliverySpeed(this.id,14);'>" + CalAvgDeliverySpeedDhaka + "</span></td><td><span style='cursor: pointer;' id ='" + row["ProfileId"] + "' onclick = 'GetDeliverySpeed(this.id,100);'>" + CalAvgDeliverySpeed + "</span></td><td>" + Status + "</td><td><span style='cursor: pointer;' id ='" + row["ProfileId"] + "' onclick = 'GetReportsDetails(this.id);'>" + row["CouponSold"] + "</span></td><td>" + row["M1"] + "</td><td>" + row["M2"] + "</td><td><span style='cursor: pointer;' id ='" + row["ProfileId"] + "-9,10,109,23' onclick = 'GetReports(this.id);'>" + CalDeliverd + "</span></td><td><span style='cursor: pointer;' id ='" + row["ProfileId"] + "-111' onclick = 'GetReports(this.id);'>" + CalMerchantGivenToCourierM1 + "</span></td><td <span style='cursor: pointer;' id ='" + row["ProfileId"] + "-13,32' onclick = 'GetReports(this.id);'>" + CalProductWaitForDelivery + "</span></td><td <span style='cursor: pointer;' id ='" + row["ProfileId"] + "-1' onclick = 'GetReports(this.id);'>" + CalPaidDeliveryCourier + "</span></td><td <span style='cursor: pointer;' id ='" + row["ProfileId"] + "-11' onclick = 'GetReports(this.id);'>" + CalUnPaidDeliveryCourier + "</span></td><td <span style='cursor: pointer; color:" + color + "' id ='" + row["ProfileId"] + "-9,10,109,23,111,13,32,1,11' onclick = 'GetReports(this.id);'>" + CalSuccessfullyProcessed + "</span></td><td><span style='cursor: pointer;' id ='" + row["ProfileId"] + "-7,16,19' onclick = 'GetReports(this.id);'>" + CalNotVerifyYetM1 + "</span></td><td <span style='cursor: pointer;' id ='" + row["ProfileId"] + "-33,20,3,12' onclick = 'GetReports(this.id);'>" + CalNotYetConfirmByMerchantM2 + "</span></td><td <span style='cursor: pointer;' id ='" + row["ProfileId"] + "-15' onclick = 'GetReports(this.id);'>" + CalMerchantConfirmButNotYetDeliverdToAD + "</span></td><td <span style='cursor: pointer; color:" + RefuseRedColourM1 + "' id ='" + row["ProfileId"] + "-18,130,134' onclick = 'GetReports(this.id);'>" + CalMerchantRefuseM1 + "<span></td><td <span style='cursor: pointer; color:" + RefuseRedColour + "' id ='" + row["ProfileId"] + "-28,30,34' onclick = 'GetReports(this.id);'>" + CalMerchantRefuseM2 + "<span></td><td <span style='cursor: pointer;' id ='" + row["ProfileId"] + "-125' onclick = 'GetReports(this.id);'>" + CalAjkerdealRefuseQC + "<span></td><td <span style='cursor: pointer;' id ='" + row["ProfileId"] + "-155,35,104' onclick = 'GetReports(this.id);'>" + CalPreShipmentRejectByCustomerM1 + "</span></td><td <span style='cursor: pointer;' id ='" + row["ProfileId"] + "-5,55,204' onclick = 'GetReports(this.id);'>" + CalPreShipmentRejectByCustomer + "</span></td><td <span style='cursor: pointer;' id ='" + row["ProfileId"] + "-101' onclick = 'GetReports(this.id);'>" + CalUnderVerificationM1 + "</span></td><td <span style='cursor: pointer;' id ='" + row["ProfileId"] + "-201' onclick = 'GetReports(this.id);'>" + CalUnderVerificationM2 + "</span></td><td <span style='cursor: pointer; color:" + RedColourM1 + "' id ='" + row["ProfileId"] + "-24,17' onclick = 'GetReports(this.id);'>" + CalPostShipmentRTOM1 + "</span></td><td <span style='cursor: pointer; color:" + RedColour + "' id ='" + row["ProfileId"] + "-117,124,31' onclick = 'GetReports(this.id);'>" + CalPostShipmentRTO + "</span></td><td>" + CalSumation + "</td><td>" + row["EValuePerTransaction"] + "</td><td>" + AvgPercentCommissionCoupon + "</td><td>" + row["TotalTransaction"] + "</td></tr>";

                }
            }

            return transReport;
        }


    }

    [WebMethod]
    public static List<string> GetReportDetailsMain(string CompanyId, string Month, string Year, string CompanyName, string TotalQuantity)
    {
        List<string> ListArray = new List<string>();
        ListArray.Add(GetReportDetails2(CompanyId, Month, Year, CompanyName, TotalQuantity));
        ListArray.Add(GetReportDetails(CompanyId, Month, Year));
        return ListArray.ToList();
    }


    [WebMethod]
    public static string GetReportDetails2(string CompanyId, string Month, string Year, string CompanyName, string TotalQuantity)
    {
        //Month = "6";
        StringBuilder data = new StringBuilder();
        DataTable dataTable;

        data.Append("<h4 style='text-align:center;'>Company : " + CompanyName + " - " + TotalQuantity + "</h4>");
        data.Append("<div style='height: 250px; overflow: auto;'>");
        data.Append("<table class='table table-hover'>");
        data.Append("<thead>");
        data.Append("<tr>");
        data.Append("<th style='width: 83px;'>SNo.</th><th>Deal ID</th><th>Deal Title</th><th>Total</th>");
        data.Append("</tr></thead>");

        data.Append("<tbody>");
        using (BOC_Reports objConfirmOrderReports = new BOC_Reports())
        {
            dataTable = objConfirmOrderReports.GetRecord_MonthlyTransactionReportBasedOnConfirmOrderDealWiseForAdmin(Convert.ToInt32(CompanyId), Convert.ToInt32(Month), Convert.ToInt32(Year));
            //dataTable = objConfirmOrderReports.GetRecord_MonthlyTransactionReportBasedOnConfirmOrderDetailsForAdmin(Convert.ToInt32(CompanyId), Convert.ToInt32(Month), Convert.ToInt32(Year));
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
    public static string GetReportDetails(string CompanyId, string Month, string Year)
    {
        //Month = "6";
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
        using (BOC_Reports objConfirmOrderReports = new BOC_Reports())
        {
            dataTable = objConfirmOrderReports.GetRecord_MonthlyTransactionReportBasedOnConfirmOrderDetailsForAdmin(Convert.ToInt32(CompanyId), Convert.ToInt32(Month), Convert.ToInt32(Year));
            //dataTable = objConfirmOrderReports.GetRecord_MonthlyTransactionReportBasedOnConfirmOrderDetailsForAdmin(CompanyId, Month, Year);
        }

        if (dataTable != null && dataTable.Rows.Count > 0)
        {
            int count = 1;

            foreach (DataRow row in dataTable.Rows)
            {
                Quantity += (int)row["CouponQtn"];

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
    public static string GetReportMethod(string Month, string Year, string whichTypeOfCompany, string IsDone)
    {
        StringBuilder data = new StringBuilder();
        DataTable dataTable;

        data.Append("<table class='table table-hover'>");
        data.Append("<thead>");
        data.Append("<tr>");
        data.Append("<th style='width: 83px;'>SNo.</th><th>Booking Code</th><th>POD Number</th><th>Quantity</th><th>Deal Title</th><th>Company Name</th><th>Order From</th><th>Courier</th><th>Confirmation Date</th><th>Comments</th><th>Image</th>");
        data.Append("</tr></thead>");

        data.Append("<tbody>");
        using (MonthlyTransactionReportGateway objMonthlyTransactionReportGateway = new MonthlyTransactionReportGateway())
        {
            dataTable = objMonthlyTransactionReportGateway.GetMonthlyOrderReport(whichTypeOfCompany, Month, Year, IsDone);
        }

        if (dataTable != null && dataTable.Rows.Count > 0)
        {
            int count = 1;
            foreach (DataRow row in dataTable.Rows)
            {
                data.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{3}</td><td>{11}</td><td>{4}(<a href='http://www.ajkerdeal.com/dealdetails.aspx?DI={2}'target=_blank>{2}</a>)</td><td>{5}</td><td>{6}</td><td>{7}</td><td>{8}</td><td style='font-family: 'Segoe', 'Segoe UI', 'DejaVu Sans', 'Trebuchet MS', 'Verdana, sans-serif';'>{9}</td><td>{10}</td></tr>",
                count++, "<span data-toggle='modal' data-target='#DataModel2' onclick='GetDealDetailsPopup(this.id);' id='" + row["CouponId"] + "'><b style='color:#DEB887;cursor:pointer;'>" + row["CouponId"] + "</b></span>",
                row["DealId"], row["PODnumber"], row["DealTitle"], row["CompanyName"], row["OrderFrom"],
                row["Courier"], row["CrmConfirmationDate"], row["Comments"],
                "<img src='http://www.ajkerdeal.com/images/Deals/" + row["FolderName"] + "/dealdetails1.jpg' width='60px'>", row["CouponQtn"]);
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

        data.Append("<table class='table table-bordered'>");
        data.Append("<thead>");
        data.Append("<tr>");
        data.Append("<th>SNo.</th><th>User Statistics</th><th>Booking/Coupon Code</th><th>Coupon Qtn. / Payment Amount</th><th>Payment Status/Type</th><th>Recent Comments</th><th>Name/Mobile/Email/Address</th><th>Image</th>");
        data.Append("</tr></thead>");

        data.Append("<tbody>");

        string DealTitle = "-1";
        string FromDate = "";
        string ToDate = DateTime.Now.AddDays(1).ToString("MM/dd/yyyy");
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
                data.AppendFormat("<tr><td>{0}</td><td>Coupon Entry : {1}</td><td>Company Name : {2}<br/>{3}<br/>{4}<br/>{5}<br/>Model : {6}</td><td>Original Price: {7}<br/>{8}<br/>({9})<br/>Inside Dhaka: {10}<br/>Outside Dhaka: {11}</td><td>{12}<br/>({13} / {14})</td><td>{15}</td><td>{16} - {17}<br/>{18}<br/>{19}<br/>Mobile : {20}<br/>{21}<br/>{22}</td><td>{23}</td></tr>",
                    count++, row["CPostedOn"],
                    row["CompanyName"], row["ContactPerson"], row["Mobile"], row["LoginEmail"], row["BusinessModel"],
                    row["CouponPrice"], row["CouponQtn"], row["PaymentAmount"], row["DeliveryChargeAmount"], row["DeliveryChargeAmountOutSideDhaka"],
                    row["PaymentStatus"], row["PaymentType"], row["CardType"],
                    row["Comments"],
                    row["CName"], row["CMobile"], row["CEmail"], row["CAddress"], row["CustomerMobile"], row["CustomerBillingAddress"], row["District"],
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
    public static List<string> LoadComments(string CouponId)
    {
        List<string> ListArray = new List<string>();
        ListArray.Add(GetDealDetailsPopupMethod(CouponId));
        ListArray.Add(GetDealComments(CouponId));
        return ListArray.ToList();
    }


    [WebMethod]
    public static string GetDeliverySpeedDetails(string CompanyId, string Month, string Year, string District)
    {
        //Month = "6";
        StringBuilder data = new StringBuilder();
        DataTable DeliverySpeedDataTable;

        data.Append("<table class='table table-hover'>");
        data.Append("<thead>");
        data.Append("<tr>");
        data.Append("<th style='width: 83px;'>SNo.</th><th>Booking Code</th><th>Confirmation Date</th><th>Delivery Date</th><th>Difference Date</th><th>Image</th>");
        data.Append("</tr></thead>");

        data.Append("<tbody>");
        using (MonthlyTransactionReportGateway ObjMonthlyTransactionReportGateway = new MonthlyTransactionReportGateway())
        {
            DeliverySpeedDataTable = ObjMonthlyTransactionReportGateway.MonthlyDeliverySpeed(Month, Year, CompanyId, District);
        }

        if (DeliverySpeedDataTable != null && DeliverySpeedDataTable.Rows.Count > 0)
        {
            int count = 1;
            foreach (DataRow row in DeliverySpeedDataTable.Rows)
            {
                data.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td></tr>",
                count++, row["CouponId"], row["CrmConfirmationDate"], row["DeliveryDate"], row["DiffDate"],
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
                        else if (row["IsDone"].ToString() == "32")
                        {
                            IsDone = "Packaged-32";
                        }

                        else if (row["IsDone"].ToString() == "1")
                        {
                            IsDone = "Done";
                        }
                        else if (row["IsDone"].ToString() == "2")
                        {
                            IsDone = "FollowUp";
                        }
                        else if (row["IsDone"].ToString() == "3")
                        {
                            IsDone = "To Be Delivered";
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
                        else if (row["IsDone"].ToString() == "33")
                        {
                            IsDone = "To Be Delivered By Ajkerdeal Inventory Collected From Merchant-33(M2)";
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
                        else if (row["IsDone"].ToString() == "9")
                        {
                            IsDone = "Delivered To Customer-9";
                        }
                        else if (row["IsDone"].ToString() == "10")
                        {
                            IsDone = "Delivered to customer by Merchant-10";
                        }
                        else if (row["IsDone"].ToString() == "11")
                        {
                            IsDone = "UnPaid-Delivered To Curier-11";
                        }
                        else if (row["IsDone"].ToString() == "12")
                        {
                            IsDone = "Office Sell-12";
                        }
                        else if (row["IsDone"].ToString() == "13")
                        {
                            IsDone = "Product Collected From Merchant By Inventory-13";
                        }
                        else if (row["IsDone"].ToString() == "15")
                        {
                            IsDone = "Delivery Accepted By Merchant To Inventory-15";
                        }
                        else if (row["IsDone"].ToString() == "17")
                        {
                            IsDone = "Customer Reject Product-17";
                        }
                        else if (row["IsDone"].ToString() == "20")
                        {
                            IsDone = "Inventory Product Delivery Delayed By Merchant-20(M2)";
                        }
                        else if (row["IsDone"].ToString() == "28")
                        {
                            IsDone = "Inventory Product Delivery Cancelled By Merchant-28(M2)";
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
        ReportMethod(month, year, OrderBy);
    }
}