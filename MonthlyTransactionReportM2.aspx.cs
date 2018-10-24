using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Text;

public partial class admin_MonthlyTransactionReportM2 : System.Web.UI.Page
{
    public string transReport = string.Empty, first = string.Empty, second = string.Empty, CurrentUser = string.Empty, uniqueMerchant = string.Empty;
    public int TotalGmv = 0;
    public double TotalCouponSold = 0, PercentOfDelivery = 0, PercentAjkerdealRefuse = 0, PercentPreshipment = 0, PercentCommission = 0,
        PercentPaidCourier = 0, PercentUnPaidCourier = 0, PercentPackagedWaitForDelivery = 0, PercentUnderVerification = 0,
        PercentNotYetConfirmByMerchantM2 = 0, PercentMerchantConfirmButNotYetDeliverdToAD = 0, PercentPostShipmentRTO = 0,
        PercentReturnToMerchant = 0, PercentNotYetReturnToMerchant = 0, PercentPaymentRefund = 0, PercentMerchantRefuse = 0;

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
  
            ReportM2Method(Month, Year, OrderBy);
        }

    }

    private void ReportM2Method(string Month, string Year, string OrderBy)
    {
        double TotalConfirmed = 0, TotalAjkerdealRefuse = 0, TotalPreshipment = 0, TotalAmount = 0,
            TotalCommission = 0, TotalPaidCourier = 0, TotalUnPaidCourier = 0, TotalPackagedWaitForDelivery = 0,
            TotalUnderVerification = 0, ToatalNotYetConfirmByMerchantM2 = 0, TotalMerchantConfirmButNotYetDeliverdToAD = 0,
            TotalPostShipmentRTO = 0, TotalReturnToMerchant = 0, TotalNotYetReturnToMerchant = 0, TotalPaymentRefund = 0, 
            TotalMerchantRefuse =0;
        double Sumation = 0;
        string UniqueDealM2 = string.Empty;

        using (MonthlyTransactionReportM2Gateway objMonthlyTransactionReportM2Gateway = new MonthlyTransactionReportM2Gateway())
        {
            DataTable dt = objMonthlyTransactionReportM2Gateway.MonthlyTransactionReportM2(Month, Year, OrderBy);

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
                    TotalPreshipment += Convert.ToInt32(row["Preshipment"]);
                    TotalAmount += Convert.ToInt32(row["TotalTransaction"]);
                    TotalCommission += Convert.ToInt32(row["Commission"]);
                    TotalPaidCourier += Convert.ToInt32(row["PaidCourier"]);
                    TotalUnPaidCourier += Convert.ToInt32(row["UnPaidCourier"]);
                    TotalPackagedWaitForDelivery += Convert.ToInt32(row["ProductWaitForDelivery"]);
                    TotalUnderVerification += Convert.ToInt32(row["VerificationM2"]);
                    ToatalNotYetConfirmByMerchantM2 += Convert.ToInt32(row["NotReceivedYetM2"]);
                    TotalMerchantConfirmButNotYetDeliverdToAD  += Convert.ToInt32(row["MerchantWaitForDelivery"]);
                    //TotalPostShipmentRTO += Convert.ToInt32(row["Reject"]);
                    TotalReturnToMerchant += Convert.ToInt32(row["ReturnToMerchant"]);
                    TotalNotYetReturnToMerchant += Convert.ToInt32(row["NotYetReturnToMerchant"]);
                    TotalPaymentRefund += Convert.ToInt32(row["Refund"]);
                    TotalMerchantRefuse += Convert.ToInt32(row["MerchantRefuse"]);
                    // Total Calculation End


                    // Delivery Start
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

                    // Merchant Refuse Start
                    double MerchantRefuse = ((Convert.ToDouble(row["MerchantCancle2"]) / Convert.ToDouble(row["CouponSold"])) * 100);
                    double RefuseNumber = 5.0;
                    string RefuseRed = "#ff0000";

                    string RefuseRedColour = "";
                    if (MerchantRefuse > RefuseNumber)
                    {
                        RefuseRedColour = RefuseRed;
                    }

                    string CalMerchantRefuse = String.Format("{0:0.##}", MerchantRefuse);
                    if (CalMerchantRefuse == "0")
                    {
                        CalMerchantRefuse = "0 %";
                    }
                    else
                    {
                        CalMerchantRefuse = CalMerchantRefuse + "%";
                    }

                    // Merchant Refuse End

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

                    //Pre-Shipment Reject By Customer Start
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
                    //Pre-Shipment Reject By Customer End

                    // Post-Shipment RTO Start
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
                    // Post-Shipment RTO End

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


                    Sumation = Delivery + PaidDeliveryCourier + UnPaidDeliveryCourier + NotYetConfirmByMerchantM2 + MerchantConfirmButNotYetDeliverdToAD
                        + ProductWaitForDelivery + MerchantRefuse + AjkerdealRefuseQC + PreShipmentRejectByCustomer + PostShipmentRTO + UnderVerificationM2;

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
                    double SuccessfullyProcessed = Delivery + UnPaidDeliveryCourier + PaidDeliveryCourier + ProductWaitForDelivery + UnderVerificationM2;
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

                    string DateRange = Convert.ToString(row["InsertedOn"]);

                    // Deliverd Speed Start

                    string DiffDate = Convert.ToString(row["DiffDate"]);
                    if (DiffDate == "1")
                    {
                        DiffDate = DiffDate + " Day";
                    }
                    else if (DiffDate == "<b>No Record</b>")
                    {
                        DiffDate = Convert.ToString(row["DiffDate"]);
                    }
                    else
                    {
                        DiffDate = DiffDate + " Days";
                    }

                    string DhakaDiffDate = Convert.ToString(row["DhakaDiffDate"]);
                    if (DhakaDiffDate == "1")
                    {
                        DhakaDiffDate = DhakaDiffDate + " Day";
                    }
                    else if (DhakaDiffDate == "<b>No Record</b>")
                    {
                        DhakaDiffDate = Convert.ToString(row["DhakaDiffDate"]);
                    }
                    else
                    {
                        DhakaDiffDate = DhakaDiffDate + " Days";
                    }

                    // Deliverd Speed End


                    transReport = transReport + "<tr><td>" + Count++ + "</td><td>" + row["CompanyName"] + "</td><td data-toggle='modal' data-target='#myModal'> <span style='cursor: pointer;' id ='" + row["ProfileId"] + "-14-D-" + row["CompanyName"] + "' onclick = 'GetDeliverySpeed(this.id);'>" + DhakaDiffDate + "</span></td><td data-toggle='modal' data-target='#myModal'> <span style='cursor: pointer;' id ='" + row["ProfileId"] + "-14-O-" + row["CompanyName"] + "' onclick = 'GetDeliverySpeed(this.id);'>" + DiffDate + "</span></td><td>" + DateRange + "</td><td data-toggle='modal' data-target='#myModal'><span style='cursor: pointer;' id ='" + row["ProfileId"] + "-" + row["CompanyName"] + "-" + row["CouponSold"] + "' onclick = 'GetReportsDetails(this.id);'>" + row["CouponSold"] + "</span></td><td data-toggle='modal' data-target='#myModal'><span style='cursor: pointer;' id ='" + row["ProfileId"] + "-9' onclick = 'GetReports(this.id);'>" + CalDeliverd + "</span></td><td data-toggle='modal' data-target='#myModal'><span style='cursor: pointer;' id ='" + row["ProfileId"] + "-13,32' onclick = 'GetReports(this.id);'>" + CalProductWaitForDelivery + "</span></td><td data-toggle='modal' data-target='#myModal'><span style='cursor: pointer;' id ='" + row["ProfileId"] + "-1' onclick = 'GetReports(this.id);'>" + CalPaidDeliveryCourier + "</span></td><td data-toggle='modal' data-target='#myModal'><span style='cursor: pointer;' id ='" + row["ProfileId"] + "-11' onclick = 'GetReports(this.id);'>" + CalUnPaidDeliveryCourier + "</span></td><td data-toggle='modal' data-target='#myModal'><span style='cursor: pointer;' id ='" + row["ProfileId"] + "-201' onclick = 'GetReports(this.id);'>" + CalUnderVerificationM2 + "</span></td><td data-toggle='modal' data-target='#myModal'><span style='cursor: pointer; color:" + color + "' id ='" + row["ProfileId"] + "-9,13,32,1,11,201' onclick = 'GetReports(this.id);'>" + CalSuccessfullyProcessed + "</span></td><td data-toggle='modal' data-target='#myModal'><span style='cursor: pointer;' id ='" + row["ProfileId"] + "-33,20,3,12' onclick = 'GetReports(this.id);'>" + CalNotYetConfirmByMerchantM2 + "</span></td><td data-toggle='modal' data-target='#myModal'><span style='cursor: pointer;' id ='" + row["ProfileId"] + "-15' onclick = 'GetReports(this.id);'>" + CalMerchantConfirmButNotYetDeliverdToAD + "</span></td><td data-toggle='modal' data-target='#myModal'><span style='cursor: pointer; color:" + RefuseRedColour + "' id ='" + row["ProfileId"] + "-28,30,34' onclick = 'GetReports(this.id);'>" + CalMerchantRefuse + "<span></td><td data-toggle='modal' data-target='#myModal'><span style='cursor: pointer;' id ='" + row["ProfileId"] + "-125' onclick = 'GetReports(this.id);'>" + CalAjkerdealRefuseQC + "<span></td><td data-toggle='modal' data-target='#myModal'><span style='cursor: pointer;' id ='" + row["ProfileId"] + "-5,55,204,41,255' onclick = 'GetReports(this.id);'>" + CalPreShipmentRejectByCustomer + "</span></td><td data-toggle='modal' data-target='#myModal'><span style='cursor: pointer; color:" + RedColour + "' id ='" + row["ProfileId"] + "-117,124,31' onclick = 'GetReports(this.id);'>" + CalPostShipmentRTO + "</span></td><td>" + CalSumation + "</td><td>" + row["EValuePerTransaction"] + "</td><td>" + AvgPercentCommissionCoupon + "</td><td>" + row["TotalTransaction"] + "</td></tr>";
                    
                    //transReport = transReport + "<tr><td>" + Count++ + "</td><td>" + row["CompanyName"] + "</td><td>" + DateRange + "</td><td data-toggle='modal' data-target='#myModal'><span style='cursor: pointer;' id ='" + row["ProfileId"] + "-" + row["CompanyName"] + "-" + row["CouponSold"] + "' onclick = 'GetReportsDetails(this.id);'>" + row["CouponSold"] + "</span></td><td data-toggle='modal' data-target='#myModal'><span style='cursor: pointer;' id ='" + row["ProfileId"] + "-9' onclick = 'GetReports(this.id);'>" + CalDeliverd + "</span></td><td data-toggle='modal' data-target='#myModal'><span style='cursor: pointer;' id ='" + row["ProfileId"] + "-13,32' onclick = 'GetReports(this.id);'>" + CalProductWaitForDelivery + "</span></td><td data-toggle='modal' data-target='#myModal'><span style='cursor: pointer;' id ='" + row["ProfileId"] + "-1' onclick = 'GetReports(this.id);'>" + CalPaidDeliveryCourier + "</span></td><td data-toggle='modal' data-target='#myModal'><span style='cursor: pointer;' id ='" + row["ProfileId"] + "-11' onclick = 'GetReports(this.id);'>" + CalUnPaidDeliveryCourier + "</span></td><td data-toggle='modal' data-target='#myModal'><span style='cursor: pointer;' id ='" + row["ProfileId"] + "-201' onclick = 'GetReports(this.id);'>" + CalUnderVerificationM2 + "</span></td><td data-toggle='modal' data-target='#myModal'><span style='cursor: pointer; color:" + color + "' id ='" + row["ProfileId"] + "-9,13,32,1,11,201' onclick = 'GetReports(this.id);'>" + CalSuccessfullyProcessed + "</span></td><td data-toggle='modal' data-target='#myModal'><span style='cursor: pointer;' id ='" + row["ProfileId"] + "-33,20,3,12' onclick = 'GetReports(this.id);'>" + CalNotYetConfirmByMerchantM2 + "</span></td><td data-toggle='modal' data-target='#myModal'><span style='cursor: pointer;' id ='" + row["ProfileId"] + "-15' onclick = 'GetReports(this.id);'>" + CalMerchantConfirmButNotYetDeliverdToAD + "</span></td><td data-toggle='modal' data-target='#myModal'><span style='cursor: pointer; color:" + RefuseRedColour + "' id ='" + row["ProfileId"] + "-28,30,34' onclick = 'GetReports(this.id);'>" + CalMerchantRefuse + "<span></td><td data-toggle='modal' data-target='#myModal'><span style='cursor: pointer;' id ='" + row["ProfileId"] + "-125' onclick = 'GetReports(this.id);'>" + CalAjkerdealRefuseQC + "<span></td><td data-toggle='modal' data-target='#myModal'><span style='cursor: pointer;' id ='" + row["ProfileId"] + "-5,55,204,41,255' onclick = 'GetReports(this.id);'>" + CalPreShipmentRejectByCustomer + "</span></td><td data-toggle='modal' data-target='#myModal'><span style='cursor: pointer; color:" + RedColour + "' id ='" + row["ProfileId"] + "-117,124,31' onclick = 'GetReports(this.id);'>" + CalPostShipmentRTO + "</span></td><td>" + CalSumation + "</td><td>" + row["EValuePerTransaction"] + "</td><td>" + AvgPercentCommissionCoupon + "</td><td>" + row["TotalTransaction"] + "</td></tr>";
                
                }

                if (TotalCouponSold != 0)
                {
                    PercentOfDelivery = (TotalConfirmed / TotalCouponSold) * 100;
                    PercentAjkerdealRefuse = (TotalAjkerdealRefuse / TotalCouponSold) * 100;
                    PercentPreshipment = (TotalPreshipment / TotalCouponSold) * 100;
                    PercentCommission = (TotalCommission / TotalAmount) * 100;
                    PercentPaidCourier = (TotalPaidCourier / TotalCouponSold) * 100;
                    PercentUnPaidCourier = (TotalUnPaidCourier / TotalCouponSold) * 100;
                    PercentPackagedWaitForDelivery = (TotalPackagedWaitForDelivery / TotalCouponSold) * 100;
                    PercentUnderVerification = (TotalUnderVerification / TotalCouponSold) * 100;
                    PercentNotYetConfirmByMerchantM2 = (ToatalNotYetConfirmByMerchantM2 / TotalCouponSold) * 100;
                    PercentMerchantConfirmButNotYetDeliverdToAD = (TotalMerchantConfirmButNotYetDeliverdToAD / TotalCouponSold) * 100;
                    //PercentPostShipmentRTO = (TotalPostShipmentRTO / TotalCouponSold) * 100;
                    PercentReturnToMerchant = (TotalReturnToMerchant / TotalCouponSold) * 100;
                    PercentNotYetReturnToMerchant = (TotalNotYetReturnToMerchant / TotalCouponSold) * 100;
                    PercentPaymentRefund = (TotalPaymentRefund / TotalCouponSold) * 100;
                    PercentMerchantRefuse = (TotalMerchantRefuse / TotalCouponSold) * 100;
                }
            }

            DataTable UnqueDealDataTable = objMonthlyTransactionReportM2Gateway.MonthlyOrderUniqueDealM2(Month, Year);
            if (UnqueDealDataTable != null || UnqueDealDataTable.Rows.Count > 0)
            {
                foreach (DataRow rowUnique in UnqueDealDataTable.Rows)
                {
                    UniqueDealM2 = Convert.ToString(UnqueDealDataTable.Rows[0]["Deal_SKU"]);
                }
            }

        }

        string PercentAjkerdealRefuseString = "", PercentPackagedWaitForDeliveryString = "",
            PercentPaidCourierString = "", PercentUnPaidCourierString = "", PercentUnderVerificationString= "";

        if (PercentAjkerdealRefuse == 0)
        {
            PercentAjkerdealRefuseString = "0";
        }

        if (PercentPackagedWaitForDelivery == 0)
        {
            PercentPackagedWaitForDeliveryString = "0";
        }

        if (PercentPaidCourier == 0)
        {
            PercentPaidCourierString = "0";
        }

        if (PercentUnPaidCourier == 0)
        {
            PercentUnPaidCourierString = "0";
        }

        if (PercentUnderVerification == 0)
        {
            PercentUnderVerificationString = "0";
        }

        first = "<tr class='active'><td>Grand Total GMV :</td><td>Tk. " + TotalGmv + "</td></tr>";
        first += "<tr><td>Total Unique Merchant :</td><td>" + uniqueMerchant + "</td></tr>";
        first += "<tr class='active'><td>Grand Total Confirmed Orders :</td><td>" + TotalCouponSold + "</td></tr>";
        first += "<tr><td>Total Commission :</td><td>" + PercentCommission.ToString("#.##") + "%</td></tr>";
        first += "<tr class='active'><td>Total Unique Deal :</td><td>" + UniqueDealM2 + "</td></tr>";
        first += "<tr class='success'><td>Delivered :</td><td><a href='Reports/MonthlyTransactionSummaryReport.aspx?IsDone=9,109&Month=" + Month + "&Year=" + Year + "' target='_blank'>" + PercentOfDelivery.ToString("#.##") + "%</td></tr>";

        double OnDeliverySum = PercentPackagedWaitForDelivery + PercentPaidCourier + PercentUnPaidCourier + PercentUnderVerification;

        first += "<tr class='success'><td>On Delivery :</td><td><a href='Reports/MonthlyTransactionSummaryReport.aspx?IsDone=13,32,1,11,201&Month=" + Month + "&Year=" + Year + "' target='_blank'>" + OnDeliverySum.ToString("#.##") + "%</a><br>Packaged Wait For Delivery =<a href='Reports/MonthlyTransactionSummaryReport.aspx?IsDone=13,32&Month=" + Month + "&Year=" + Year + "' target='_blank'> " + PercentPackagedWaitForDelivery.ToString("#.##") + PercentPackagedWaitForDeliveryString + "%</a><br />";
        first += "Paid to courier (Not Phone) =<a href='Reports/MonthlyTransactionSummaryReport.aspx?IsDone=1&Month=" + Month + "&Year=" + Year + "' target='_blank'> " + PercentPaidCourier.ToString("#.##") + PercentPaidCourierString + "%</a><br>UnPaid to courier (Not Phone) =<a href='Reports/MonthlyTransactionSummaryReport.aspx?IsDone=11&Month=" + Month + "&Year=" + Year + "' target='_blank'> " + PercentUnPaidCourier.ToString("#.##") + PercentUnPaidCourierString + "%</a><br>";
        first += "Under Verification (Phone) =<a href='Reports/MonthlyTransactionSummaryReport.aspx?IsDone=201&Month=" + Month + "&Year=" + Year + "' target='_blank'> " + PercentUnderVerification.ToString("#.##") + PercentUnderVerificationString + "%</a></td></tr>";

        double PostShipmentRTOM2Sum = PercentReturnToMerchant + PercentNotYetReturnToMerchant;

        second = "<tr class='danger'><td>Post-Shipment RTO :</td><td><a href='Reports/MonthlyTransactionSummaryReport.aspx?IsDone=117,124,31&Month=" + Month + "&Year=" + Year + "' target='_blank'>" + PostShipmentRTOM2Sum.ToString("#.##") + "%</a><br>Not yet return to merchant =<a href='Reports/MonthlyTransactionSummaryReport.aspx?IsDone=117,124&Month=" + Month + "&Year=" + Year + "' target='_blank'>" + PercentNotYetReturnToMerchant.ToString("#.##") + " %</a><br />";
        second += "Return to merchant =<a href='Reports/MonthlyTransactionSummaryReport.aspx?IsDone=31&Month=" + Month + "&Year=" + Year + "' target='_blank'>" + PercentReturnToMerchant.ToString("#.##") + " %</a></td></tr>";

        double MerchantRefuseM2Sum = PercentMerchantRefuse + PercentPaymentRefund;
        second += "<tr class='warning'><td>Refuse :</td><td><a href='Reports/MonthlyTransactionSummaryReport.aspx?IsDone=28,30,34&Month=" + Month + "&Year=" + Year + "' target='_blank'>" + MerchantRefuseM2Sum.ToString("#.##") + "%</a><br>Merchant Refuse =<a href='Reports/MonthlyTransactionSummaryReport.aspx?IsDone=28&Month=" + Month + "&Year=" + Year + "' target='_blank'>" + PercentMerchantRefuse.ToString("#.##") + " %</a><br />";
        second += "Payment Refund =<a href='Reports/MonthlyTransactionSummaryReport.aspx?IsDone=30,34&Month=" + Month + "&Year=" + Year + "' target='_blank'>" + PercentPaymentRefund.ToString("#.##") + " %</a></td></tr>";
        second += "<tr class='warning'><td>Ajkerdeal Refuse (QC) :</td><td><a href='Reports/MonthlyTransactionSummaryReport.aspx?IsDone=125&Month=" + Month + "&Year=" + Year + "' target='_blank'>" + PercentAjkerdealRefuse.ToString("#.##") + PercentAjkerdealRefuseString + " %</a></td></tr>";
        second += "<tr><td>Pre-Shipment Rejected By Customer :</td><td><a href='Reports/MonthlyTransactionSummaryReport.aspx?IsDone=5,55,204,41,255&Month=" + Month + "&Year=" + Year + "' target='_blank'>" + PercentPreshipment.ToString("#.##") + " %</a></td></tr>";
        second += "<tr><td>Not Yet Confirm By Merchant :</td><td><a href='Reports/MonthlyTransactionSummaryReport.aspx?IsDone=33,20,3,12&Month=" + Month + "&Year=" + Year + "' target='_blank'>" + PercentNotYetConfirmByMerchantM2.ToString("#.##") + " %</a></td></tr>";
        second += "<tr class='info'><td>Merchant Confirm But Not YetDeliverd To AD :</td><td><a href='Reports/MonthlyTransactionSummaryReport.aspx?IsDone=15&Month=" + Month + "&Year=" + Year + "' target='_blank'>" + PercentMerchantConfirmButNotYetDeliverdToAD.ToString("#.##") + " %</a></td></tr>";

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

        if (Check == "D")
        {
            using (MonthlyTransactionReportM2Gateway ObjMonthlyTransactionReportM2Gateway = new MonthlyTransactionReportM2Gateway())
            {
                DeliverySpeedDataTable = ObjMonthlyTransactionReportM2Gateway.MonthlyDeliverySpeed(Month, Year, CompanyId, District);
            }

        }
        else
        {
            using (MonthlyTransactionReportM2Gateway ObjMonthlyTransactionReportM2Gateway = new MonthlyTransactionReportM2Gateway())
            {
                DeliverySpeedDataTable = ObjMonthlyTransactionReportM2Gateway.MonthlyDeliverySpeed_OutSideDhaka(Month, Year, CompanyId, District);
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
    public static List<string> GetReportDetailsM2(string CompanyId, string Month, string Year, string CompanyName, string TotalQuantity)
    {
        List<string> ListArray = new List<string>();
        ListArray.Add(GetReportDetails1(CompanyId, Month, Year, CompanyName, TotalQuantity));
        ListArray.Add(GetReportDetails2(CompanyId, Month, Year));
        return ListArray.ToList();
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
        using (MonthlyTransactionReportM2Gateway objMonthlyTransactionReportM2 = new MonthlyTransactionReportM2Gateway())
        {
            dataTable = objMonthlyTransactionReportM2.MonthlyTransactionReportfirmOrderDetailsM2(Convert.ToInt32(CompanyId), Convert.ToInt32(Month), Convert.ToInt32(Year));
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

        using (MonthlyTransactionReportM2Gateway objMonthlyTransactionReportM2 = new MonthlyTransactionReportM2Gateway())
        {
            dataTable = objMonthlyTransactionReportM2.MonthlyTransactionReport_M2_DealWise(CompanyId, Month, Year);
        }

        if (dataTable != null || dataTable.Rows.Count > 0)
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
        double TotalCouponSold = 0, PercentOfDelivery = 0, PercentAjkerdealRefuse = 0, PercentPreshipment = 0, PercentCommission = 0,
        PercentPaidCourier = 0, PercentUnPaidCourier = 0, PercentPackagedWaitForDelivery = 0, PercentUnderVerification = 0,
        PercentNotYetConfirmByMerchantM2 = 0, PercentMerchantConfirmButNotYetDeliverdToAD = 0, PercentPostShipmentRTO = 0,
        PercentReturnToMerchant = 0, PercentNotYetReturnToMerchant = 0, PercentPaymentRefund = 0, PercentMerchantRefuse = 0;

        double TotalConfirmed = 0, TotalAjkerdealRefuse = 0, TotalPreshipment = 0, TotalAmount = 0,
            TotalCommission = 0, TotalPaidCourier = 0, TotalUnPaidCourier = 0, TotalPackagedWaitForDelivery = 0,
            TotalUnderVerification = 0, ToatalNotYetConfirmByMerchantM2 = 0, TotalMerchantConfirmButNotYetDeliverdToAD = 0,
            TotalPostShipmentRTO = 0, TotalReturnToMerchant = 0, TotalNotYetReturnToMerchant = 0, TotalPaymentRefund = 0,
            TotalMerchantRefuse = 0;

        using (MonthlyTransactionReportM2Gateway objMonthlyTransactionReportM2Gateway = new MonthlyTransactionReportM2Gateway())
        {
            DataTable dt = objMonthlyTransactionReportM2Gateway.MonthlyTransactionReportM2(month, year, OrderBy);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    // Total Calculation Start
                    TotalGmv += Convert.ToInt32(row["TotalTransaction"]);
                    TotalCouponSold += Convert.ToInt32(row["CouponSold"]);
                    TotalConfirmed += Convert.ToInt32(row["TotalConfirmed"]);
                    TotalAjkerdealRefuse += Convert.ToInt32(row["AjkerdealRefuse"]);
                    TotalPreshipment += Convert.ToInt32(row["Preshipment"]);
                    TotalAmount += Convert.ToInt32(row["TotalTransaction"]);
                    TotalCommission += Convert.ToInt32(row["Commission"]);
                    TotalPaidCourier += Convert.ToInt32(row["PaidCourier"]);
                    TotalUnPaidCourier += Convert.ToInt32(row["UnPaidCourier"]);
                    TotalPackagedWaitForDelivery += Convert.ToInt32(row["ProductWaitForDelivery"]);
                    TotalUnderVerification += Convert.ToInt32(row["VerificationM2"]);
                    ToatalNotYetConfirmByMerchantM2 += Convert.ToInt32(row["NotReceivedYetM2"]);
                    TotalMerchantConfirmButNotYetDeliverdToAD += Convert.ToInt32(row["MerchantWaitForDelivery"]);
                    //TotalPostShipmentRTO += Convert.ToInt32(row["Reject"]);
                    TotalReturnToMerchant += Convert.ToInt32(row["ReturnToMerchant"]);
                    TotalNotYetReturnToMerchant += Convert.ToInt32(row["NotYetReturnToMerchant"]);
                    TotalPaymentRefund += Convert.ToInt32(row["Refund"]);
                    TotalMerchantRefuse += Convert.ToInt32(row["MerchantRefuse"]);
                    // Total Calculation End

                    if (TotalCouponSold != 0)
                    {
                        PercentOfDelivery = (TotalConfirmed / TotalCouponSold) * 100;
                        PercentAjkerdealRefuse = (TotalAjkerdealRefuse / TotalCouponSold) * 100;
                        PercentPreshipment = (TotalPreshipment / TotalCouponSold) * 100;
                        PercentCommission = (TotalCommission / TotalAmount) * 100;
                        PercentPaidCourier = (TotalPaidCourier / TotalCouponSold) * 100;
                        PercentUnPaidCourier = (TotalUnPaidCourier / TotalCouponSold) * 100;
                        PercentPackagedWaitForDelivery = (TotalPackagedWaitForDelivery / TotalCouponSold) * 100;
                        PercentUnderVerification = (TotalUnderVerification / TotalCouponSold) * 100;
                        PercentNotYetConfirmByMerchantM2 = (ToatalNotYetConfirmByMerchantM2 / TotalCouponSold) * 100;
                        PercentMerchantConfirmButNotYetDeliverdToAD = (TotalMerchantConfirmButNotYetDeliverdToAD / TotalCouponSold) * 100;
                        //PercentPostShipmentRTO = (TotalPostShipmentRTO / TotalCouponSold) * 100;
                        PercentReturnToMerchant = (TotalReturnToMerchant / TotalCouponSold) * 100;
                        PercentNotYetReturnToMerchant = (TotalNotYetReturnToMerchant / TotalCouponSold) * 100;
                        PercentPaymentRefund = (TotalPaymentRefund / TotalCouponSold) * 100;
                        PercentMerchantRefuse = (TotalMerchantRefuse / TotalCouponSold) * 100;
                    }
                }
            }
        }
       second = "<tr class='danger'><td>Post-Shipment RTO :</td><td>Not yet return to merchant ="+ PercentNotYetReturnToMerchant.ToString("#.##") + " %<br />";
       second += "Return to merchant =" + PercentReturnToMerchant.ToString("#.##") + " %</td></tr>";
       second +="<tr class='warning'><td>Refuse :</td><td>Merchant Refuse ="+ PercentMerchantRefuse.ToString("#.##") + " %<br />";
       second +="Payment Refund =" + PercentPaymentRefund.ToString("#.##") + " %</td></tr>";
       second += "<tr class='warning'><td>Ajkerdeal Refuse (QC) :</td><td>" + PercentAjkerdealRefuse.ToString("#.##") + " %</td></tr>";
       second += "<tr><td>Pre-Shipment Rejected By Customer :</td><td>" + PercentPreshipment.ToString("#.##") + " %</td></tr>";
       second +="<tr><td>Not Yet Confirm By Merchant :</td><td>" + PercentNotYetConfirmByMerchantM2.ToString("#.##") + " %</td></tr>";
       second += "<tr class='info'><td>Merchant Confirm But Not YetDeliverd To AD :</td><td>" + PercentMerchantConfirmButNotYetDeliverdToAD.ToString("#.##") + " %</td></tr>";

        return second;
    }


    [WebMethod]
    public static string GetM2ReportFirst(string month, string year)
    {
        string OrderBy = "CouponSold", first = string.Empty;
        int TotalGmv = 0;
        double TotalCouponSold = 0, PercentOfDelivery = 0, PercentAjkerdealRefuse = 0, PercentPreshipment = 0, PercentCommission = 0,
        PercentPaidCourier = 0, PercentUnPaidCourier = 0, PercentPackagedWaitForDelivery = 0, PercentUnderVerification = 0,
        PercentNotYetConfirmByMerchantM2 = 0, PercentMerchantConfirmButNotYetDeliverdToAD = 0, PercentPostShipmentRTO = 0,
        PercentReturnToMerchant = 0, PercentNotYetReturnToMerchant = 0, PercentPaymentRefund = 0, PercentMerchantRefuse = 0;

        double TotalConfirmed = 0, TotalAjkerdealRefuse = 0, TotalPreshipment = 0, TotalAmount = 0,
            TotalCommission = 0, TotalPaidCourier = 0, TotalUnPaidCourier = 0, TotalPackagedWaitForDelivery = 0,
            TotalUnderVerification = 0, ToatalNotYetConfirmByMerchantM2 = 0, TotalMerchantConfirmButNotYetDeliverdToAD = 0,
            TotalPostShipmentRTO = 0, TotalReturnToMerchant = 0, TotalNotYetReturnToMerchant = 0, TotalPaymentRefund = 0, 
            TotalMerchantRefuse =0;

        using (MonthlyTransactionReportM2Gateway objMonthlyTransactionReportM2Gateway = new MonthlyTransactionReportM2Gateway())
        {
            DataTable dt = objMonthlyTransactionReportM2Gateway.MonthlyTransactionReportM2(month, year, OrderBy);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    // Total Calculation Start
                    TotalGmv += Convert.ToInt32(row["TotalTransaction"]);
                    TotalCouponSold += Convert.ToInt32(row["CouponSold"]);
                    TotalConfirmed += Convert.ToInt32(row["TotalConfirmed"]);
                    TotalAjkerdealRefuse += Convert.ToInt32(row["AjkerdealRefuse"]);
                    TotalPreshipment += Convert.ToInt32(row["Preshipment"]);
                    TotalAmount += Convert.ToInt32(row["TotalTransaction"]);
                    TotalCommission += Convert.ToInt32(row["Commission"]);
                    TotalPaidCourier += Convert.ToInt32(row["PaidCourier"]);
                    TotalUnPaidCourier += Convert.ToInt32(row["UnPaidCourier"]);
                    TotalPackagedWaitForDelivery += Convert.ToInt32(row["ProductWaitForDelivery"]);
                    TotalUnderVerification += Convert.ToInt32(row["VerificationM2"]);
                    ToatalNotYetConfirmByMerchantM2 += Convert.ToInt32(row["NotReceivedYetM2"]);
                    TotalMerchantConfirmButNotYetDeliverdToAD += Convert.ToInt32(row["MerchantWaitForDelivery"]);
                    //TotalPostShipmentRTO += Convert.ToInt32(row["Reject"]);
                    TotalReturnToMerchant += Convert.ToInt32(row["ReturnToMerchant"]);
                    TotalNotYetReturnToMerchant += Convert.ToInt32(row["NotYetReturnToMerchant"]);
                    TotalPaymentRefund += Convert.ToInt32(row["Refund"]);
                    TotalMerchantRefuse += Convert.ToInt32(row["MerchantRefuse"]);
                    // Total Calculation End

                    if (TotalCouponSold != 0)
                    {
                        PercentOfDelivery = (TotalConfirmed / TotalCouponSold) * 100;
                        PercentAjkerdealRefuse = (TotalAjkerdealRefuse / TotalCouponSold) * 100;
                        PercentPreshipment = (TotalPreshipment / TotalCouponSold) * 100;
                        PercentCommission = (TotalCommission / TotalAmount) * 100;
                        PercentPaidCourier = (TotalPaidCourier / TotalCouponSold) * 100;
                        PercentUnPaidCourier = (TotalUnPaidCourier / TotalCouponSold) * 100;
                        PercentPackagedWaitForDelivery = (TotalPackagedWaitForDelivery / TotalCouponSold) * 100;
                        PercentUnderVerification = (TotalUnderVerification / TotalCouponSold) * 100;
                        PercentNotYetConfirmByMerchantM2 = (ToatalNotYetConfirmByMerchantM2 / TotalCouponSold) * 100;
                        PercentMerchantConfirmButNotYetDeliverdToAD = (TotalMerchantConfirmButNotYetDeliverdToAD / TotalCouponSold) * 100;
                        //PercentPostShipmentRTO = (TotalPostShipmentRTO / TotalCouponSold) * 100;
                        PercentReturnToMerchant = (TotalReturnToMerchant / TotalCouponSold) * 100;
                        PercentNotYetReturnToMerchant = (TotalNotYetReturnToMerchant / TotalCouponSold) * 100;
                        PercentPaymentRefund = (TotalPaymentRefund / TotalCouponSold) * 100;
                        PercentMerchantRefuse = (TotalMerchantRefuse / TotalCouponSold) * 100;
                    }
                }
            }
        }

        first = "<tr class='active'><td>Grand Total GMV :</td><td>" + TotalGmv + "Tk.</td></tr>";
        first +="<tr class='active'><td>Grand Total Confirmed Orders :</td><td>"+ TotalCouponSold +"</td></tr>";
        first += "<tr><td>Total Commission :</td><td>"+PercentCommission.ToString("#.##") +" %</td></tr>";
        //first +="<tr class='active'><td>Total Unique Merchant :</td><td>" + 0 + "</td></tr>";
        first +="<tr class='success'><td>Delivered :</td><td>" + PercentOfDelivery.ToString("#.##") + " %</td></tr>";
        first +="<tr class='success'><td>On Delivery :</td><td>Packaged Wait For Delivery ="+PercentPackagedWaitForDelivery.ToString("#.##") + " %<br />";
        first += "Paid to courier (Not Phone) =" + PercentPaidCourier.ToString("#.##") + " %<br>UnPaid to courier (Not Phone) =" + PercentUnPaidCourier.ToString("#.##") + " %<br>";
        first += "Under Verification (Phone) =" + PercentUnderVerification.ToString("#.##") + " %</td></tr>";

        return first;
    }


    [WebMethod]
    public static string GetM2ReportTable(string month, string year)
    {
        string OrderBy = "CouponSold", transReportM2 = string.Empty;
        double Sumation = 0;

        using (MonthlyTransactionReportM2Gateway objMonthlyTransactionReportM2Gateway = new MonthlyTransactionReportM2Gateway())
        {
            DataTable dt = objMonthlyTransactionReportM2Gateway.MonthlyTransactionReportM2(month, year, OrderBy);

            if (dt != null && dt.Rows.Count > 0)
            {
                int Count = 1;
                foreach (DataRow row in dt.Rows)
                {
                    // Delivery Start
                    double Delivery = ((Convert.ToDouble(row["TotalConfirmed"]) / Convert.ToDouble(row["CouponSold"])) * 100);
                    string CalDeliverd = String.Format("{0:0.##}", Delivery);

                    if (CalDeliverd == "0")
                    {
                        CalDeliverd = "0%";
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
                        CalPaidDeliveryCourier = "0%";
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
                        CalUnPaidDeliveryCourier = "0%";
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
                        CalNotYetConfirmByMerchantM2 = "0%";
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
                        CalMerchantConfirmButNotYetDeliverdToAD = "0%";
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
                        CalProductWaitForDelivery = "0%";
                    }
                    else
                    {
                        CalProductWaitForDelivery = CalProductWaitForDelivery + "%";
                    }
                    // Product Wait For Delivery End

                    // Merchant Refuse Start
                    double MerchantRefuse = ((Convert.ToDouble(row["MerchantCancle2"]) / Convert.ToDouble(row["CouponSold"])) * 100);
                    double RefuseNumber = 5.0;
                    string RefuseRed = "#ff0000";

                    string RefuseRedColour = "";
                    if (MerchantRefuse > RefuseNumber)
                    {
                        RefuseRedColour = RefuseRed;
                    }

                    string CalMerchantRefuse = String.Format("{0:0.##}", MerchantRefuse);
                    if (CalMerchantRefuse == "0")
                    {
                        CalMerchantRefuse = "0%";
                    }
                    else
                    {
                        CalMerchantRefuse = CalMerchantRefuse + "%";
                    }
                    // Merchant Refuse End

                    // Ajkerdeal Refuse QC Start
                    double AjkerdealRefuseQC = ((Convert.ToDouble(row["AjkerdealRefuse"]) / Convert.ToDouble(row["CouponSold"])) * 100);
                    string CalAjkerdealRefuseQC = String.Format("{0:0.##}", AjkerdealRefuseQC);
                    if (CalAjkerdealRefuseQC == "0")
                    {
                        CalAjkerdealRefuseQC = "0%";
                    }
                    else
                    {
                        CalAjkerdealRefuseQC = CalAjkerdealRefuseQC + "%";
                    }
                    // Ajkerdeal Refuse QC End

                    //Pre-Shipment Reject By Customer Start
                    double PreShipmentRejectByCustomer = ((Convert.ToDouble(row["Preshipment"]) / Convert.ToDouble(row["CouponSold"])) * 100);
                    string CalPreShipmentRejectByCustomer = String.Format("{0:0.##}", PreShipmentRejectByCustomer);
                    if (CalPreShipmentRejectByCustomer == "0")
                    {
                        CalPreShipmentRejectByCustomer = "0%";
                    }
                    else
                    {
                        CalPreShipmentRejectByCustomer = CalPreShipmentRejectByCustomer + "%";
                    }
                    //Pre-Shipment Reject By Customer End

                    // Post-Shipment RTO Start
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
                        CalPostShipmentRTO = "0%";
                    }
                    else
                    {
                        CalPostShipmentRTO = CalPostShipmentRTO + "%";
                    }
                    // Post-Shipment RTO End

                    // Under Verification M2 Start
                    double UnderVerificationM2 = ((Convert.ToDouble(row["VerificationM2"]) / Convert.ToDouble(row["CouponSold"])) * 100);
                    string CalUnderVerificationM2 = String.Format("{0:0.##}", UnderVerificationM2);
                    if (CalUnderVerificationM2 == "0")
                    {
                        CalUnderVerificationM2 = "0%";
                    }
                    else
                    {
                        CalUnderVerificationM2 = CalUnderVerificationM2 + "%";
                    }
                    // Under Verification M2 End


                    Sumation = Delivery + PaidDeliveryCourier + UnPaidDeliveryCourier + NotYetConfirmByMerchantM2 + MerchantConfirmButNotYetDeliverdToAD
                        + ProductWaitForDelivery + MerchantRefuse + AjkerdealRefuseQC + PreShipmentRejectByCustomer + PostShipmentRTO + UnderVerificationM2;

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
                        AvgPercentCommissionCoupon = "0%";
                    }
                    else
                    {
                        AvgPercentCommissionCoupon = AvgPercentCommissionCoupon + "%";
                    }
                    // Avg Percent Commission Coupon End

                    double SuccessfullyProcessed = Delivery + UnPaidDeliveryCourier + PaidDeliveryCourier + ProductWaitForDelivery + UnderVerificationM2;
                    string NoColor = "#333";
                    string GreenColor = "#019440";
                    string YellowColor = "#F4A535";
                    string RedColor = "#ff0000";
                    string color = NoColor;
                    int Day = DateTime.Now.Day;

                    if (Day >= 1 && Day <= 10 && Convert.ToInt32(month) == DateTime.Now.Month && Convert.ToInt32(year) == DateTime.Now.Year)
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

                    else if (Day >= 11 && Day <= 20 && Convert.ToInt32(month) == DateTime.Now.Month && Convert.ToInt32(year) == DateTime.Now.Year)
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

                    else if (Day >= 21 && Day <= 31 && Convert.ToInt32(month) == DateTime.Now.Month && Convert.ToInt32(year) == DateTime.Now.Year)
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

                    // Cal Successfully Processed Start
                    string CalSuccessfullyProcessed = String.Format("{0:0.##}", SuccessfullyProcessed);

                    if (CalSuccessfullyProcessed == "0")
                    {
                        CalSuccessfullyProcessed = "0%";
                    }
                    else
                    {
                        CalSuccessfullyProcessed = CalSuccessfullyProcessed + "%";
                    }
                    // Cal Successfully Processed End

                    transReportM2 = transReportM2 + "<tr data-toggle='modal' data-target='#myModal'><td>" + Count++ + "</td><td>" + row["CompanyName"] + "</td><td>" + row["CouponSold"] + "</td><td><span style='cursor: pointer;' id ='" + row["ProfileId"] + "-9' onclick = 'GetReports(this.id);'>" + CalDeliverd + "</span></td><td <span style='cursor: pointer;' id ='" + row["ProfileId"] + "-13,32' onclick = 'GetReports(this.id);'>" + CalProductWaitForDelivery + "</span></td><td <span style='cursor: pointer;' id ='" + row["ProfileId"] + "-1' onclick = 'GetReports(this.id);'>" + CalPaidDeliveryCourier + "</span></td><td <span style='cursor: pointer;' id ='" + row["ProfileId"] + "-11' onclick = 'GetReports(this.id);'>" + CalUnPaidDeliveryCourier + "</span></td><td <span style='cursor: pointer;' id ='" + row["ProfileId"] + "-201' onclick = 'GetReports(this.id);'>" + CalUnderVerificationM2 + "</span></td><td <span style='cursor: pointer; color:" + color + "' id ='" + row["ProfileId"] + "-9,13,32,1,11,201' onclick = 'GetReports(this.id);'>" + CalSuccessfullyProcessed + "</span></td><td <span style='cursor: pointer;' id ='" + row["ProfileId"] + "-33,20,3,12' onclick = 'GetReports(this.id);'>" + CalNotYetConfirmByMerchantM2 + "</span></td><td <span style='cursor: pointer;' id ='" + row["ProfileId"] + "-15' onclick = 'GetReports(this.id);'>" + CalMerchantConfirmButNotYetDeliverdToAD + "</span></td><td <span style='cursor: pointer; color:" + RefuseRedColour + "' id ='" + row["ProfileId"] + "-28,30,34' onclick = 'GetReports(this.id);'>" + CalMerchantRefuse + "<span></td><td <span style='cursor: pointer;' id ='" + row["ProfileId"] + "-125' onclick = 'GetReports(this.id);'>" + CalAjkerdealRefuseQC + "<span></td><td <span style='cursor: pointer;' id ='" + row["ProfileId"] + "-5,55,204' onclick = 'GetReports(this.id);'>" + CalPreShipmentRejectByCustomer + "</span></td><td <span style='cursor: pointer; color:" + RedColour + "' id ='" + row["ProfileId"] + "-117,124,31' onclick = 'GetReports(this.id);'>" + CalPostShipmentRTO + "</span></td><td>" + CalSumation + "</td><td>" + row["EValuePerTransaction"] + "</td><td>" + AvgPercentCommissionCoupon + "</td><td>" + row["TotalTransaction"] + "</td></tr>";
      
                    //transReportM2 = transReportM2 + "<tr><td>" + Count++ + "</td><td>" + row["CompanyName"] + "</td><td>" + row["CouponSold"] + "</td><td>" + CalDeliverd + "</td><td>" + CalProductWaitForDelivery + "</td><td>" + CalPaidDeliveryCourier + "</td><td>" + CalUnPaidDeliveryCourier + "</td><td>" + CalUnderVerificationM2 + "</td><td style='color:" + color + "'>" + CalSuccessfullyProcessed + "</td><td>" + CalNotYetConfirmByMerchantM2 + "</td><td>" + CalMerchantConfirmButNotYetDeliverdToAD + "</td><td style='color:" + RefuseRedColour + "'>" + CalMerchantRefuse + "</td><td>" + CalAjkerdealRefuseQC + "</td><td>" + CalPreShipmentRejectByCustomer + "</td><td style='color:" + RedColour + "'>" + CalPostShipmentRTO + "</td><td>" + row["EValuePerTransaction"] + "</td><td>" + AvgPercentCommissionCoupon + "</td><td>" + row["TotalTransaction"] + "</td></tr>";
                }
            }
            return transReportM2;
        }

    }

    [WebMethod]
    public static string GetReportMethod(string Month, string Year, string whichTypeOfCompany, string IsDone)
    {
        StringBuilder data = new StringBuilder();
        DataTable dataTable;

        data.Append("<table class='table table-hover'>");
        data.Append("<thead>");
        data.Append("<tr>");
        data.Append("<th style='width: 83px;'>SNo.</th><th>Booking Code</th><th>POD Number</th><th>Deal Title</th><th>Company Name</th><th>Order From</th><th>Courier</th><th>Confirmation Date</th><th>Comments</th><th>Image</th><th>Sold Out</th>");
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

                data.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{3}</td><td>{4}(<a href='http://www.ajkerdeal.com/dealdetails.aspx?DI={2}'target=_blank>{2}</a>)</td><td>{5}</td><td>{6}</td><td>{7}</td><td>{8}</td><td style='font-family: 'Segoe', 'Segoe UI', 'DejaVu Sans', 'Trebuchet MS', 'Verdana, sans-serif';'>{9}</td><td>{10}</td><td>{11}</td></tr>",
                count++, "<span data-toggle='modal' data-target='#DataModel2' onclick='GetDealDetailsPopup(this.id);' id='" + row["CouponId"] + "'><b style='color:#DEB887;cursor:pointer;'>" + row["CouponId"] + "</b></span>",
                row["DealId"], row["PODnumber"], row["DealTitle"], row["CompanyName"], row["OrderFrom"],
                row["Courier"], row["CrmConfirmationDate"], row["Comments"],
                "<img src='http://www.ajkerdeal.com/images/Deals/" + row["FolderName"] + "/dealdetails1.jpg' width='60px'>",
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
                            IsDone = "Confirmed Delivery by Merchant";
                        }
                        else if (row["IsDone"].ToString() == "18")
                        {
                            IsDone = "Order Cancelled by Merchant";
                        }
                        else if (row["IsDone"].ToString() == "19")
                        {
                            IsDone = "Merchant Delayed the delivery";
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
        ReportM2Method(month, year, OrderBy);
    }
}