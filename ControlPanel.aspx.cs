using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Web.Services;
using System.Web.Script.Services;

public partial class admin_ControlPanelAdmin : System.Web.UI.Page
{
    public static int userId = 0;
    public string Deal1 = string.Empty, Crazy1 = string.Empty, Delivery1 = string.Empty, DayWise1 = string.Empty;
    public string Bkash_Today = string.Empty;
    public string PerformingMerchant_Today = string.Empty, PerformingCategory_Today = string.Empty,
        PerformingCaCategory_Today = string.Empty;


    public string FollowUpBooking = "";
    public int Verified = 0;
    public int ToBeVerified = 0;
    public string NewOrderBooking = "";

    public string LinkAddress = String.Empty;

    public int intAdminType = 0;
    public int intUserId = 0;
    public string CurrentUser = "";
    public string EditUser = "";
    public string UserFullName = "";

    string strModel1 = string.Empty;
    string strModel2 = string.Empty;

    public string AdminLink = string.Empty;
    public string Ad2Link = string.Empty;
    public string Ad4Link = string.Empty;
    public string Ad5Link = string.Empty;
    public string Ad6Link = string.Empty;
    public string Ad7Link = string.Empty;
    public string Ad10Link = string.Empty;
    public string Ad11Link = string.Empty;

    public string AlertLink = string.Empty;
    public string StrReports = string.Empty;

    public string SaleStats = "";

    public string SaleStatsString = "";

    public string MonthName = DateTime.Now.Month.ToString();
    public string YearName = DateTime.Now.Year.ToString();

    public string FromDate = "0";
    public string ToDate = "0";
    public string CountOrderMainSite = "";
    public string CountOrderMobileSite = "";
    public string CountFavMainSite = "";
    public string CountFavMobileSite = "";
    public string CountFavMainSiteUnique = "";
    public string CountFavMobileSiteUnique = "";
    public string CountOrderMainSiteUnique = "";
    public string CountOrderMobileSiteUnique = "";

    public string Total_ReturnShopperRecord = "0";
    public string avgReturnShopper = "0";
    public string Shopper = "";
    public string NewMerchant = "";

    public string TotalOrderReports = "";
    public string NewOrderReports = "";
    public string FollowUpReports = "";
    public string CancelAjkerDealReports1 = "";
    public string CancelAjkerDealReports2 = "";
    public int CancelAjkerDealReports = 0;

    public int CancelMerchantReports = 0;
    public string CancelMerchantReports1 = "";
    public string CancelMerchantReports2 = "";
    public string CancelMerchantReports3 = "";
    public string CancelMerchantReports4 = "";

    public string COD_OutSideDhaka = "";

    public string CRM_Processed1 = "";
    public string CRM_Processed2 = "";
    public int CRM_Processed = 0;

    public string After_CRM_Processed1 = "";
    public string After_CRM_Processed2 = "";
    public string After_CRM_Processed3 = "";
    public string After_CRM_Processed4 = "";
    public string After_CRM_Processed5 = "";
    public string After_CRM_Processed6 = "";
    public string After_CRM_Processed7 = "";
    public string After_CRM_Processed8 = "";
    public string After_CRM_Processed9 = "";
    public string After_CRM_Processed10 = "";
    public string After_CRM_Processed11 = "";
    public string After_CRM_Processed12 = "";
    public string After_CRM_Processed13 = "";
    public string After_CRM_Processed14 = "";
    public string After_CRM_Processed15 = "";
    public string After_CRM_Processed16 = "";

    public int After_CRM_Processed = 0;

    public string CancelRepertedOrder = "";

    public string CRM_ProcessedModel1 = "";
    public int CRM_ProcessedModel2 = 0;

    public string StrOrderProcessing = string.Empty;
    public string StrOrderProcessingToday = string.Empty;
    public string StrOrderProcessingYes = string.Empty;

    public int Total_CRM_Order_Processing = 0;

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

        LinkAddress = HttpContext.Current.Request.Url.Host;

        if (Session["AD_ADMIN_TYPE"] == null)
        {
            Response.Redirect("Default.aspx");
            Response.End();
        }
        else
        {
            intAdminType = Convert.ToInt32(Session["AD_ADMIN_TYPE"]);
        }

        if (Session["AD_ADMIN_NAME"] == null)
        {
            //NeedToVerifyLabel.Text = "<a href='Default.aspx' >sign in</a>&nbsp;<img src='../../images/separator.gif' alt='|' />&nbsp;<a href='#'>sign up</a>";
        }
        else
        {
            // To show username in sign/signout section for admin panel
            CurrentUser = this.Session["AD_ADMIN_USERNAME"].ToString();

            EditUser = "<li><a href='UserSystem/UserEntry.aspx?UserId=" + this.Session["AD_ADMIN_ID"] + "'><i class='icon-user'></i>Profile Edit</a></li>";
            intUserId = Convert.ToInt32(this.Session["AD_ADMIN_ID"]);
            userId = Convert.ToInt32(this.Session["AD_ADMIN_ID"]);
        }

        //if (GetNeedToDealVerifyBySales() > 0 && intAdminType == 4)
        //{
        //    NeedToVerifyLabel.Text = "<div class='center'><h3 class='smaller lighter green'><strong>" + this.Session["AD_ADMIN_NAME"] + " you need to verify </strong><span><a class='label label-xlg label-pink arrowed arrowed-right' href='DealsVerify/DealsVerifyBySales/DealsVerifyBySales.aspx'>" + GetNeedToDealVerifyBySales() + "</a></span><strong> more deals.</strong></h3></div>";
        //}

        //if (GetNeedToDealVerifyByContent() > 0 && intAdminType == 10)
        //{
        //    NeedToVerifyLabel.Text = "<div class='center'><h3 class='smaller lighter green'><strong>" + this.Session["AD_ADMIN_NAME"] + " you need to verify </strong><span><a class='label label-xlg label-pink arrowed arrowed-right' href='DealsVerify/DealsVerifyBySales/DealsVerifyBySales.aspx'>" + GetNeedToDealVerifyByContent() + "</a></span><strong> more deals.</strong></h3></div>";
        //}

        //string month = DateTime.Now.AddMonths(-1).Month.ToString();
        //string year = DateTime.Now.Year.ToString();
        //DateTime firstDay = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), 1);
        //string PastDateToMonth = firstDay.ToShortDateString();

        //DateTime dtTo = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        //dtTo = dtTo.AddDays(-(dtTo.Day));

        //string PastDateToMonthEnd = dtTo.ToShortDateString();

        //MonthlyConfirmOrderDistrictWise("CouponSold");


        

        
        //SaleStats = "<div class='col-sm-6'><div class='widget-box transparent'><div class='widget-header widget-header-flat'><h4 class='lighter'><i class='icon-signal'></i>Order Stats</h4><div class='widget-toolbar'><a href='#' data-action='collapse'><i class='icon-chevron-up'></i></a></div></div><div class='widget-body'><div class='widget-main padding-4'><div id='Sales-Star'></div></div></div></div></div>";



        // New Crm Order function Start

        TotalCrmOrder();

        TotalCrmOrderM1M2();

        // New Crm Order function End


        PerformingMerchantMethodToday();

        PerformingSubCategoryMethodToday();

        PerformingCategoryMethodToday();

        //CodOpsBkashMethodToday();

        //TotalUniqueDealMerchantToday();

        //TotalUniqueCrazyDealToday();

        //TotalDeliverySummaryToday();


        //OrderStats();

        //graphChart();


        //WishListMethod();


        //if (intAdminType == 4)
        //{
        //    UploadedDealsLabel.Text = this.Session["AD_ADMIN_NAME"] + "  Uploaded Deals of Last Three Month";
        //    LoadUploadedDealByUser();
        //}    
    }

    private void PerformingCategoryMethodToday()
    {
        
        String Today = DateTime.Now.ToShortDateString();
        String Yesterday = DateTime.Now.Date.AddDays(-1).ToShortDateString();
        String CheckCategory = "000";


        using (ControlPanelGateway ObjControlGateway = new ControlPanelGateway())
        {
            Dictionary<int, int> objDicCategory = new Dictionary<int, int>();
            DataTable dt = new DataTable();
            dt = ObjControlGateway.PerformingCategory(Yesterday, Yesterday);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int MerchantId = Convert.ToInt32(dt.Rows[i][0]);
                    objDicCategory[MerchantId] = Convert.ToInt32(dt.Rows[i][2]);
                }
            }

            
            dt = ObjControlGateway.PerformingCategory(Today, Today);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string arrow = String.Empty;
                    int MerchantId = Convert.ToInt32(dt.Rows[i][0]);

                    if (objDicCategory.ContainsKey(MerchantId))
                    {
                        if (objDicCategory[MerchantId] < Convert.ToInt32(dt.Rows[i][2]))
                        {
                            arrow = "<span style='color: #0310FF'>↑</span>";
                        }
                        else if (objDicCategory[MerchantId] > Convert.ToInt32(dt.Rows[i][2]))
                        {
                            arrow = "<span style='color: #FF0000'>↓</span>";
                        }
                        else if (objDicCategory[MerchantId] == Convert.ToInt32(dt.Rows[i][2]))
                        {
                            arrow = "<span style='color: #000000'>↓↑</span>";
                        }
                    }

                    PerformingCaCategory_Today += "<tr><td><b class='black'>" + dt.Rows[i]["CategoryName"] + "</b></td><td data-toggle='modal' data-target='#Model1'><span style='cursor: pointer;' id ='" + dt.Rows[i]["CategoryId"] + "-" + Today + "-" + Today + "-" + CheckCategory + "' onclick = 'GetPerformingMerchantPopUp(this.id);' class='green'>" + dt.Rows[i]["CouponSold"] + arrow + "</span></td><td><b class='pink'>" + dt.Rows[i]["TotalConfirmed"] + "</b></td><td><b class='pink'>" + dt.Rows[i]["TotalMerchant"] + "</b></td><td><b class='blue'>" + dt.Rows[i]["AvgValueOfTrans"] + "</b></td></tr>";

                }
            }
        }
    }


    public String tableShowM1 = String.Empty;
    public String tableShowM2 = String.Empty;
    private void TotalCrmOrderM1M2()
    {
        String statusM1 = "7,10,16,19,111,18,17,24,155,35,104";
        String statusM2 = "1,9,11,13,15,20,109,32,33,28,124,117,125,55,204";
        using (ControlPanelGateway ObjControlGateway = new ControlPanelGateway())
        {
            // Crm Order M1 Section

            DataTable CrmTableM1 = ObjControlGateway.CrmOrderSummaryReportM1M2(statusM1);

            if (CrmTableM1.Rows.Count > 0)
            {
                string onClickfunction = "GetOrderModelStatus(this.id);";

                foreach (DataRow row in CrmTableM1.Rows)
                {
                    string resultColor = Convert.ToString(row["StatusId"]) == "18" ? "red"
                                  : Convert.ToString(row["StatusId"]) == "17" ? "red"
                                  : Convert.ToString(row["StatusId"]) == "24" ? "red"
                                  : Convert.ToString(row["StatusId"]) == "155" ? "red"
                                  : Convert.ToString(row["StatusId"]) == "35" ? "red"
                                  : Convert.ToString(row["StatusId"]) == "104" ? "red"
                                  : "green";

                    String last5 = "<td data-toggle='modal' data-target='#Model1'><span id='" + row["StatusId"] + "-Last5th' onclick='" + onClickfunction + "'><b style='color: " + resultColor + "; cursor: pointer;'>" + row["Last5th"] + "</b></span></td>";

                    String last4 = "<td data-toggle='modal' data-target='#Model1'><span id='" + row["StatusId"] + "-Last4th' onclick='" + onClickfunction + "'><b style='color: " + resultColor + "; cursor: pointer;'>" + row["Last4th"] + "</b></span></td>";

                    String last3 = "<td data-toggle='modal' data-target='#Model1'><span id='" + row["StatusId"] + "-Last3rd' onclick='" + onClickfunction + "'><b style='color: " + resultColor + "; cursor: pointer;'>" + row["Last3rd"] + "</b></span></td>";

                    String Yesterday = "<td data-toggle='modal' data-target='#Model1'><span id='" + row["StatusId"] + "-Yesterday' onclick='" + onClickfunction + "'><b style='color: " + resultColor + "; cursor: pointer;'>" + row["YesterDay"] + "</b></span></td>";

                    String Today = "<td data-toggle='modal' data-target='#Model1'><span id='" + row["StatusId"] + "-Today' onclick='" + onClickfunction + "'><b style='color: " + resultColor + "; cursor: pointer;'>" + row["Today"] + "</b></span></td>";

                    tableShowM1 = tableShowM1 + "<tr style='color: " + resultColor + "'><td>" + row["StatusTitle"] + "</td>" + last5 + "" + last4 + "" + last3 + "" + Yesterday + "" + Today + "</tr>";
                }
            }


            // Crm Order M2 Section
            DataTable CrmTableM2 = ObjControlGateway.CrmOrderSummaryReportM1M2(statusM2);

            if (CrmTableM2.Rows.Count > 0)
            {
                string onClickfunction = "GetOrderModelStatus(this.id);";

                foreach (DataRow row in CrmTableM2.Rows)
                {
                    string resultColor = Convert.ToString(row["StatusId"]) == "28" ? "red"
                                  : Convert.ToString(row["StatusId"]) == "117" ? "red"
                                  : Convert.ToString(row["StatusId"]) == "124" ? "red"
                                  : Convert.ToString(row["StatusId"]) == "55" ? "red"
                                  : Convert.ToString(row["StatusId"]) == "5" ? "red"
                                  : Convert.ToString(row["StatusId"]) == "204" ? "red"
                                  : Convert.ToString(row["StatusId"]) == "125" ? "red"
                                  : "green";

                    String last5 = "<td data-toggle='modal' data-target='#Model1'><span id='" + row["StatusId"] + "-Last5th' onclick='" + onClickfunction + "'><b style='color: " + resultColor + "; cursor: pointer;'>" + row["Last5th"] + "</b></span></td>";

                    String last4 = "<td data-toggle='modal' data-target='#Model1'><span id='" + row["StatusId"] + "-Last4th' onclick='" + onClickfunction + "'><b style='color: " + resultColor + "; cursor: pointer;'>" + row["Last4th"] + "</b></span></td>";

                    String last3 = "<td data-toggle='modal' data-target='#Model1'><span id='" + row["StatusId"] + "-Last3rd' onclick='" + onClickfunction + "'><b style='color: " + resultColor + "; cursor: pointer;'>" + row["Last3rd"] + "</b></span></td>";

                    String Yesterday = "<td data-toggle='modal' data-target='#Model1'><span id='" + row["StatusId"] + "-Yesterday' onclick='" + onClickfunction + "'><b style='color: " + resultColor + "; cursor: pointer;'>" + row["YesterDay"] + "</b></span></td>";

                    String Today = "<td data-toggle='modal' data-target='#Model1'><span id='" + row["StatusId"] + "-Today' onclick='" + onClickfunction + "'><b style='color: " + resultColor + "; cursor: pointer;'>" + row["Today"] + "</b></span></td>";

                    tableShowM2 = tableShowM2 + "<tr style='color: " + resultColor + "'><td>" + row["StatusTitle"] + "</td>" + last5 + "" + last4 + "" + last3 + "" + Yesterday + "" + Today + "</tr>";
                }
            }

        }
    }

    public int totalOrderToday = 0, successOrderToday = 0, successOrderM1Today = 0, successOrderM2Today = 0,
        totalOrderYesterday = 0, successOrderYesterday = 0, successOrderM1Yesterday = 0, successOrderM2Yesterday = 0,
        totalOrderLast3rd = 0, successOrderLast3rd = 0, successOrderM1Last3rd = 0, successOrderM2Last3rd = 0,
        totalOrderLast4th = 0, successOrderLast4th = 0, successOrderM1Last4th = 0, successOrderM2Last4th = 0,
        totalOrderLast5th = 0, successOrderLast5th = 0, successOrderM1Last5th = 0, successOrderM2Last5th = 0,
        SuccessCustomerToday = 0, SuccessCustomerYesterday = 0, SuccessCustomerLast3rd = 0, SuccessCustomerLast4th = 0,
        SuccessCustomerLast5th = 0;

    public int TodayConversion = 0, YesterdayConversion = 0, 
        Last3rdConversion = 0, Last4thConversion = 0, Last5thConversion = 0;

    public int TodayCustomer = 0, YesterdayCustomer = 0, Last3rdCustomer = 0, Last4thCustomer = 0, Last5thCustomer = 0;

    private void TotalCrmOrder()
    {
        using (ControlPanelGateway ObjControlGateway = new ControlPanelGateway())
        {
            DataTable CrmTable = ObjControlGateway.CrmOrderSummaryReport();

            if (CrmTable.Rows.Count > 0)
            {
                totalOrderToday = Convert.ToInt32(CrmTable.Rows[0]["TotalOrderToday"]);
                successOrderToday = Convert.ToInt32(CrmTable.Rows[0]["SuccessOrderToday"]);
                successOrderM1Today = Convert.ToInt32(CrmTable.Rows[0]["SuccessOrderM1Today"]);
                successOrderM2Today = Convert.ToInt32(CrmTable.Rows[0]["SuccessOrderM2Today"]);

                totalOrderYesterday = Convert.ToInt32(CrmTable.Rows[0]["TotalOrderYesterday"]);
                successOrderYesterday = Convert.ToInt32(CrmTable.Rows[0]["SuccessOrderYesterday"]);
                successOrderM1Yesterday = Convert.ToInt32(CrmTable.Rows[0]["SuccessOrderM1Yesterday"]);
                successOrderM2Yesterday = Convert.ToInt32(CrmTable.Rows[0]["SuccessOrderM2Yesterday"]);

                totalOrderLast3rd = Convert.ToInt32(CrmTable.Rows[0]["TotalOrderLast3rd"]);
                successOrderLast3rd = Convert.ToInt32(CrmTable.Rows[0]["SuccessOrderLast3rd"]);
                successOrderM1Last3rd = Convert.ToInt32(CrmTable.Rows[0]["SuccessOrderM1Last3rd"]);
                successOrderM2Last3rd = Convert.ToInt32(CrmTable.Rows[0]["SuccessOrderM2Last3rd"]);

                totalOrderLast4th = Convert.ToInt32(CrmTable.Rows[0]["TotalOrderLast4th"]);
                successOrderLast4th = Convert.ToInt32(CrmTable.Rows[0]["SuccessOrderLast4th"]);
                successOrderM1Last4th = Convert.ToInt32(CrmTable.Rows[0]["SuccessOrderM1Last4th"]);
                successOrderM2Last4th = Convert.ToInt32(CrmTable.Rows[0]["SuccessOrderM2Last4th"]);


                totalOrderLast5th = Convert.ToInt32(CrmTable.Rows[0]["TotalOrderLast5th"]);
                successOrderLast5th = Convert.ToInt32(CrmTable.Rows[0]["SuccessOrderLast5th"]);
                successOrderM1Last5th = Convert.ToInt32(CrmTable.Rows[0]["SuccessOrderM1Last5th"]);
                successOrderM2Last5th = Convert.ToInt32(CrmTable.Rows[0]["SuccessOrderM2Last5th"]);


                TodayConversion = Convert.ToInt32(CrmTable.Rows[0]["TodayConversion"]);
                YesterdayConversion = Convert.ToInt32(CrmTable.Rows[0]["YesterdayConversion"]);
                Last3rdConversion = Convert.ToInt32(CrmTable.Rows[0]["Last3rdConversion"]);
                Last4thConversion = Convert.ToInt32(CrmTable.Rows[0]["Last4thConversion"]);
                Last5thConversion = Convert.ToInt32(CrmTable.Rows[0]["Last5thConversion"]);


                TodayCustomer = Convert.ToInt32(CrmTable.Rows[0]["TodayCustomer"]);
                YesterdayCustomer = Convert.ToInt32(CrmTable.Rows[0]["YesterdayCustomer"]);
                Last3rdCustomer = Convert.ToInt32(CrmTable.Rows[0]["Last3rdCustomer"]);
                Last4thCustomer = Convert.ToInt32(CrmTable.Rows[0]["Last4thCustomer"]);
                Last5thCustomer = Convert.ToInt32(CrmTable.Rows[0]["Last5thCustomer"]);

                SuccessCustomerToday = Convert.ToInt32(CrmTable.Rows[0]["SuccessCustomerToday"]);
                SuccessCustomerYesterday = Convert.ToInt32(CrmTable.Rows[0]["SuccessCustomerYesterday"]);
                SuccessCustomerLast3rd = Convert.ToInt32(CrmTable.Rows[0]["SuccessCustomerLast3rd"]);
                SuccessCustomerLast4th = Convert.ToInt32(CrmTable.Rows[0]["SuccessCustomerLast4th"]);
                SuccessCustomerLast5th = Convert.ToInt32(CrmTable.Rows[0]["SuccessCustomerLast5th"]);
            }
        }
    }



    private void TotalUniqueCrazyDealToday()
    {
        using (ControlPanelGateway ObjControlGateway = new ControlPanelGateway())
        {
            string startDate = DateTime.Now.ToShortDateString();
            string endDate = DateTime.Now.ToShortDateString();
            string pastStartDate = DateTime.Now.AddDays(-1).ToShortDateString();
            string pastEndDate = DateTime.Now.AddDays(-1).ToShortDateString();

            DataTable table = new DataTable();

            Dictionary<int, int> CrazyDealDic = new Dictionary<int, int>();
            Dictionary<int, int> CrazyTotalDealDic = new Dictionary<int, int>();
            Dictionary<int, int> CrazySumDealDic = new Dictionary<int, int>();

            table = ObjControlGateway.Unique_Crazy_Deal(pastStartDate, pastEndDate);
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    int TotalCrazy = Convert.ToInt32(table.Rows[i]["SNO"]);
                    CrazyDealDic[TotalCrazy] = Convert.ToInt32(table.Rows[i]["TotalDealWithActive"]);
                    CrazyTotalDealDic[TotalCrazy] = Convert.ToInt32(table.Rows[i]["TotalDealCrazyWithActive"]);
                    CrazySumDealDic[TotalCrazy] = Convert.ToInt32(table.Rows[i]["SumOfDealCrazy"]);
                }
            }

            table = ObjControlGateway.Unique_Crazy_Deal(startDate, endDate);

            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    string arrow1 = String.Empty, arrow2 = string.Empty, arrow3 = string.Empty;
                    int TotalCrazy = Convert.ToInt32(table.Rows[i]["SNO"]);

                    if (CrazyDealDic.ContainsKey(TotalCrazy))
                    {
                        if (CrazyDealDic[TotalCrazy] < Convert.ToInt32(table.Rows[i]["TotalDealWithActive"]))
                        {
                            arrow1 = "<span style='color: #0310FF'>↑</span>";
                        }
                        else if (CrazyDealDic[TotalCrazy] > Convert.ToInt32(table.Rows[i]["TotalDealWithActive"]))
                        {
                            arrow1 = "<span style='color: #FF0000'>↓</span>";
                        }
                        else if (CrazyDealDic[TotalCrazy] == Convert.ToInt32(table.Rows[i]["TotalDealWithActive"]))
                        {
                            arrow1 = "<span style='color: #000000'>↓↑</span>";
                        }
                    }

                    if (CrazyTotalDealDic.ContainsKey(TotalCrazy))
                    {

                        if (CrazyTotalDealDic[TotalCrazy] < Convert.ToInt32(table.Rows[i]["TotalDealCrazyWithActive"]))
                        {
                            arrow2 = "<span style='color: #0310FF'>↑</span>";
                        }
                        else if (CrazyTotalDealDic[TotalCrazy] > Convert.ToInt32(table.Rows[i]["TotalDealCrazyWithActive"]))
                        {
                            arrow2 = "<span style='color: #FF0000'>↓</span>";
                        }
                        else if (CrazyTotalDealDic[TotalCrazy] == Convert.ToInt32(table.Rows[i]["TotalDealCrazyWithActive"]))
                        {
                            arrow2 = "<span style='color: #000000'>↓↑</span>";
                        }
                    }

                    if (CrazySumDealDic.ContainsKey(TotalCrazy))
                    {

                        if (CrazySumDealDic[TotalCrazy] < Convert.ToInt32(table.Rows[i]["SumOfDealCrazy"]))
                        {
                            arrow3 = "<span style='color: #0310FF'>↑</span>";
                        }
                        else if (CrazySumDealDic[TotalCrazy] > Convert.ToInt32(table.Rows[i]["SumOfDealCrazy"]))
                        {
                            arrow3 = "<span style='color: #FF0000'>↓</span>";
                        }
                        else if (CrazySumDealDic[TotalCrazy] == Convert.ToInt32(table.Rows[i]["SumOfDealCrazy"]))
                        {
                            arrow3 = "<span style='color: #000000'>↓↑</span>";
                        }
                    }

                    Crazy1 = "<tr><td><span class='black'>" + table.Rows[i]["TotalDealWithActive"] + arrow1 + "</span></td><td><span class='green'>" + table.Rows[i]["TotalDealCrazyWithActive"] + arrow2 + "</span></td><td><b class='pink'>" + table.Rows[i]["SumOfDealCrazy"] + arrow3 + "</b></td></tr>";
                }
            }
        }
    }




    private void TotalDeliverySummaryToday()
    {
        using (ControlPanelGateway ObjControlGateway = new ControlPanelGateway())
        {
            string startDate = DateTime.Now.ToShortDateString();
            string endDate = DateTime.Now.ToShortDateString();
            string pastStartDate = DateTime.Now.AddDays(-1).ToShortDateString();
            string pastEndDate = DateTime.Now.AddDays(-1).ToShortDateString();

            DataTable table = new DataTable();

            Dictionary<int, int> TotalDeliveryDic = new Dictionary<int, int>();

            Dictionary<int, int> LateDeliveryDic = new Dictionary<int, int>();
            Dictionary<int, int> Avg_LateDeliveryDic = new Dictionary<int, int>();

            Dictionary<int, int> FastDeliveryDic = new Dictionary<int, int>();
            Dictionary<int, int> Avg_FastDeliveryDic = new Dictionary<int, int>();

            table = ObjControlGateway.DeliverySummary(pastStartDate, pastEndDate);
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    int TotalDelivery = Convert.ToInt32(table.Rows[i]["SNO"]);
                    TotalDeliveryDic[TotalDelivery] = Convert.ToInt32(table.Rows[i]["TotalDelivery"]);
                    LateDeliveryDic[TotalDelivery] = Convert.ToInt32(table.Rows[i]["LateDelivery"]);
                    Avg_LateDeliveryDic[TotalDelivery] = Convert.ToInt32(table.Rows[i]["Avg_LateDelivery"]);
                    FastDeliveryDic[TotalDelivery] = Convert.ToInt32(table.Rows[i]["FastDelivery"]);
                    Avg_FastDeliveryDic[TotalDelivery] = Convert.ToInt32(table.Rows[i]["Avg_FastDelivery"]);
                }
            }

            table = ObjControlGateway.DeliverySummary(startDate, endDate);

            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    string arrow1 = String.Empty, arrow2 = string.Empty, arrow3 = string.Empty;
                    String arrow4 = string.Empty, arrow5 = string.Empty;

                    int TotalDelivery = Convert.ToInt32(table.Rows[i]["SNO"]);

                    if (TotalDeliveryDic.ContainsKey(TotalDelivery))
                    {
                        if (TotalDeliveryDic[TotalDelivery] < Convert.ToInt32(table.Rows[i]["TotalDelivery"]))
                        {
                            arrow1 = "<span style='color: #0310FF'>↑</span>";
                        }
                        else if (TotalDeliveryDic[TotalDelivery] > Convert.ToInt32(table.Rows[i]["TotalDelivery"]))
                        {
                            arrow1 = "<span style='color: #FF0000'>↓</span>";
                        }
                        else if (TotalDeliveryDic[TotalDelivery] == Convert.ToInt32(table.Rows[i]["TotalDelivery"]))
                        {
                            arrow1 = "<span style='color: #000000'>↓↑</span>";
                        }
                    }

                    if (LateDeliveryDic.ContainsKey(TotalDelivery))
                    {

                        if (LateDeliveryDic[TotalDelivery] < Convert.ToInt32(table.Rows[i]["LateDelivery"]))
                        {
                            arrow2 = "<span style='color: #0310FF'>↑</span>";
                        }
                        else if (LateDeliveryDic[TotalDelivery] > Convert.ToInt32(table.Rows[i]["LateDelivery"]))
                        {
                            arrow2 = "<span style='color: #FF0000'>↓</span>";
                        }
                        else if (LateDeliveryDic[TotalDelivery] == Convert.ToInt32(table.Rows[i]["LateDelivery"]))
                        {
                            arrow2 = "<span style='color: #000000'>↓↑</span>";
                        }
                    }

                    if (Avg_LateDeliveryDic.ContainsKey(TotalDelivery))
                    {

                        if (Avg_LateDeliveryDic[TotalDelivery] < Convert.ToInt32(table.Rows[i]["Avg_LateDelivery"]))
                        {
                            arrow3 = "<span style='color: #0310FF'>↑</span>";
                        }
                        else if (Avg_LateDeliveryDic[TotalDelivery] > Convert.ToInt32(table.Rows[i]["Avg_LateDelivery"]))
                        {
                            arrow3 = "<span style='color: #FF0000'>↓</span>";
                        }
                        else if (Avg_LateDeliveryDic[TotalDelivery] == Convert.ToInt32(table.Rows[i]["Avg_LateDelivery"]))
                        {
                            arrow3 = "<span style='color: #000000'>↓↑</span>";
                        }
                    }


                    if (FastDeliveryDic.ContainsKey(TotalDelivery))
                    {

                        if (FastDeliveryDic[TotalDelivery] < Convert.ToInt32(table.Rows[i]["FastDelivery"]))
                        {
                            arrow4 = "<span style='color: #0310FF'>↑</span>";
                        }
                        else if (FastDeliveryDic[TotalDelivery] > Convert.ToInt32(table.Rows[i]["FastDelivery"]))
                        {
                            arrow4 = "<span style='color: #FF0000'>↓</span>";
                        }
                        else if (FastDeliveryDic[TotalDelivery] == Convert.ToInt32(table.Rows[i]["FastDelivery"]))
                        {
                            arrow4 = "<span style='color: #000000'>↓↑</span>";
                        }
                    }

                    if (Avg_FastDeliveryDic.ContainsKey(TotalDelivery))
                    {

                        if (Avg_FastDeliveryDic[TotalDelivery] < Convert.ToInt32(table.Rows[i]["Avg_FastDelivery"]))
                        {
                            arrow5 = "<span style='color: #0310FF'>↑</span>";
                        }
                        else if (Avg_FastDeliveryDic[TotalDelivery] > Convert.ToInt32(table.Rows[i]["Avg_FastDelivery"]))
                        {
                            arrow5 = "<span style='color: #FF0000'>↓</span>";
                        }
                        else if (Avg_FastDeliveryDic[TotalDelivery] == Convert.ToInt32(table.Rows[i]["Avg_FastDelivery"]))
                        {
                            arrow5 = "<span style='color: #000000'>↓↑</span>";
                        }
                    }

                    Delivery1 = "<tr><td><span class='black'>" + table.Rows[i]["TotalDelivery"] + arrow1 + "</span></td><td><span class='green'>" + table.Rows[i]["LateDelivery"] + arrow2 + "</span></td><td><b class='pink'>" + table.Rows[i]["Avg_LateDelivery"] + "%" + arrow3 + "</b></td><td><b class='pink'>" + table.Rows[i]["FastDelivery"] + arrow4 + "</b></td><td><b class='pink'>" + table.Rows[i]["Avg_FastDelivery"] + "%" + arrow5 + "</b></td></tr>";
                }
            }
        }
    }

    public decimal TransactionsPercentMetropolitan = 0, TransactionsPercentOfOutDhaka = 0;
    public decimal TotalCodPercent = 0, CodInOutDhakaPercent = 0, CODOutSideDhakaTotal = 0,
        PercentBkashOutside = 0, BkashInDhaka = 0, TransactionsPercentOfDhaka = 0;

    private void MonthlyConfirmOrderDistrictWise(string OrderBy)
    {
        int CheckDist = 0;
        decimal BkashDhaka = 0, CodDhaka = 0, TotalConfirmedDhaka = 0;
        decimal BkashTotal = 0, TotalConfirmed = 0, TotalCod = 0;
        decimal TotalMetropolitan = 0;
        using (BOC_Reports objBOCReports = new BOC_Reports())
        {
            string Month = DateTime.Now.Month.ToString();
            string Year = DateTime.Now.Year.ToString();
            DataTable dataTable = objBOCReports.MonthlyTransactionReportBasedOnConfirmOrderDistrictWise(Month, Year);
            if (dataTable.Rows.Count > 0)
            {
                BkashDhaka = Convert.ToDecimal(dataTable.Rows[0]["BkashTotal"]);
                CodDhaka = Convert.ToDecimal(dataTable.Rows[0]["CODTotal"]);
                TotalConfirmedDhaka = Convert.ToDecimal(dataTable.Rows[0]["TotalConfirmed"]);
                foreach (DataRow row in dataTable.Rows)
                {
                    BkashTotal += Convert.ToDecimal(row["BkashTotal"]);
                    TotalCod += Convert.ToDecimal(row["CODTotal"]);
                    TotalConfirmed += Convert.ToDecimal(row["TotalConfirmed"]);

                    CheckDist = Convert.ToInt32(row["DeliveryDist"]);
                    if (CheckDist == 65 || CheckDist == 66 || CheckDist == 67 ||
                            CheckDist == 68 || CheckDist == 69 || CheckDist == 70 ||
                            CheckDist == 71 || CheckDist == 72 || CheckDist == 73 ||
                            CheckDist == 74 || CheckDist == 75 || CheckDist == 19 || CheckDist == 43)
                    {
                        TotalMetropolitan += Convert.ToDecimal(row["TotalConfirmed"]);
                    }

                }

            }
        }

        if (TotalMetropolitan != 0)
        {
            TransactionsPercentMetropolitan = Math.Round((TotalMetropolitan / TotalConfirmed) * 100);
        }

        decimal TransactionsOfOutDhaka = (TotalConfirmed - TotalConfirmedDhaka);

        TransactionsOfOutDhaka = (TransactionsOfOutDhaka - TotalMetropolitan);

        if (TransactionsOfOutDhaka != 0)
        {
            TransactionsPercentOfOutDhaka = Math.Round((TransactionsOfOutDhaka / TotalConfirmed) * 100);
        }

        if (TotalConfirmedDhaka != 0)
        {
            TransactionsPercentOfDhaka = Math.Round((TotalConfirmedDhaka / TotalConfirmed) * 100);
        }

        if (TotalCod != 0)
        {
            TotalCodPercent = Math.Round((TotalCod / TotalConfirmed) * 100);
        }

        if (CodDhaka != 0)
        {
            CodInOutDhakaPercent = Math.Round((CodDhaka / TotalCod) * 100);
        }

        decimal CODOutSideDhaka = (TotalCod - CodDhaka);
        if (CODOutSideDhaka != 0)
        {
            CODOutSideDhakaTotal = Math.Round((CODOutSideDhaka / TotalCod) * 100);
        }

        if (BkashDhaka != 0)
        {
            BkashInDhaka = Math.Round((BkashDhaka / BkashTotal) * 100);
        }

        decimal BkashOutside = BkashTotal - BkashDhaka;
        if (BkashOutside != 0)
        {
            PercentBkashOutside = Math.Round((BkashOutside / BkashTotal) * 100);
        }
    }

    private void TotalUniqueDealMerchantToday()
    {
        using (ControlPanelGateway ObjControlGateway = new ControlPanelGateway())
        {
            string startDate = DateTime.Now.ToShortDateString();
            string endDate = DateTime.Now.ToShortDateString();
            string pastStartDate = DateTime.Now.AddDays(-1).ToShortDateString();
            string pastEndDate = DateTime.Now.AddDays(-1).ToShortDateString();

            DataTable table = new DataTable();

            Dictionary<int, int> uniqueDic = new Dictionary<int, int>();
            Dictionary<int, int> uniqueDealDic = new Dictionary<int, int>();
            Dictionary<int, int> uniqueMerchantDic = new Dictionary<int, int>();

            table = ObjControlGateway.Unique_Deal_Merchant(pastStartDate, pastEndDate);
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    int TotalDeal = Convert.ToInt32(table.Rows[i]["SNO"]);
                    uniqueDic[TotalDeal] = Convert.ToInt32(table.Rows[i]["TotalDealwiseOrder"]);
                    uniqueDealDic[TotalDeal] = Convert.ToInt32(table.Rows[i]["TotalDealwiseConfirmOrder"]);
                    uniqueMerchantDic[TotalDeal] = Convert.ToInt32(table.Rows[i]["TotalMerchantwiseOrder"]);
                }
            }

            table = ObjControlGateway.Unique_Deal_Merchant(startDate, endDate);

            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    string arrow1 = String.Empty, arrow2 = String.Empty, arrow3 = String.Empty;
                    int TotalDeal = Convert.ToInt32(table.Rows[i]["SNO"]);

                    if (uniqueDic.ContainsKey(TotalDeal))
                    {
                        if (uniqueDic[TotalDeal] < Convert.ToInt32(table.Rows[i]["TotalDealwiseOrder"]))
                        {
                            arrow1 = "<span style='color: #0310FF'>↑</span>";
                        }
                        else if (uniqueDic[TotalDeal] > Convert.ToInt32(table.Rows[i]["TotalDealwiseOrder"]))
                        {
                            arrow1 = "<span style='color: #FF0000'>↓</span>";
                        }
                        else if (uniqueDic[TotalDeal] == Convert.ToInt32(table.Rows[i]["TotalDealwiseOrder"]))
                        {
                            arrow1 = "<span style='color: #000000'>↓↑</span>";
                        }
                    }

                    if (uniqueDealDic.ContainsKey(TotalDeal))
                    {

                        if (uniqueDealDic[TotalDeal] < Convert.ToInt32(table.Rows[i]["TotalDealwiseConfirmOrder"]))
                        {
                            arrow2 = "<span style='color: #0310FF'>↑</span>";
                        }
                        else if (uniqueDealDic[TotalDeal] > Convert.ToInt32(table.Rows[i]["TotalDealwiseConfirmOrder"]))
                        {
                            arrow2 = "<span style='color: #FF0000'>↓</span>";
                        }
                        else if (uniqueDealDic[TotalDeal] == Convert.ToInt32(table.Rows[i]["TotalDealwiseConfirmOrder"]))
                        {
                            arrow2 = "<span style='color: #000000'>↓↑</span>";
                        }
                    }

                    if (uniqueMerchantDic.ContainsKey(TotalDeal))
                    {
                        if (uniqueMerchantDic[TotalDeal] < Convert.ToInt32(table.Rows[i]["TotalMerchantwiseOrder"]))
                        {
                            arrow3 = "<span style='color: #0310FF'>↑</span>";
                        }
                        else if (uniqueMerchantDic[TotalDeal] > Convert.ToInt32(table.Rows[i]["TotalMerchantwiseOrder"]))
                        {
                            arrow3 = "<span style='color: #FF0000'>↓</span>";
                        }
                        else if (uniqueMerchantDic[TotalDeal] == Convert.ToInt32(table.Rows[i]["TotalMerchantwiseOrder"]))
                        {
                            arrow3 = "<span style='color: #000000'>↓↑</span>";
                        }
                    }

                    Deal1 = "<tr><td><span class='black'>" + table.Rows[i]["TotalDealwiseOrder"] + arrow1 + "</span></td><td><span class='green'>" + table.Rows[i]["TotalDealwiseConfirmOrder"] + arrow2 + "</span></td><td><b class='pink'>" + table.Rows[i]["TotalMerchantwiseOrder"] + arrow3 + "</b></td></tr>";
                }
            }
        }

    }

    private void WishListMethod()
    {
        string FromPre30Days = DateTime.Now.AddDays(-30).ToShortDateString();
        string To30Days = DateTime.Now.ToShortDateString();

        using (MerchantLiquidityReportGateway objReport = new MerchantLiquidityReportGateway())
        {
            NewMerchant = objReport.CountNewMerchant(FromPre30Days, To30Days);
        }

        using (ShopperReportGateway objShopperReport = new ShopperReportGateway())
        {
            Shopper = objShopperReport.CountShopper(FromPre30Days, To30Days);
        }

        using (OrderFavReportGateway objReport = new OrderFavReportGateway())
        {
            CountOrderMainSite = objReport.CountOrderMainSite(FromPre30Days, To30Days);
            CountOrderMobileSite = objReport.CountOrderMobileSite(FromPre30Days, To30Days);

            CountOrderMainSiteUnique = objReport.CountOrderMainSiteUnique(FromPre30Days, To30Days);
            CountOrderMobileSiteUnique = objReport.CountOrderMobileSiteUnique(FromPre30Days, To30Days);

            CountFavMainSite = objReport.CountOrderFavMainSite(FromPre30Days, To30Days);
            CountFavMobileSite = objReport.CountOrderFavMobileSite(FromPre30Days, To30Days);

            CountFavMainSiteUnique = objReport.CountOrderFavMainSiteUnique(FromPre30Days, To30Days);
            CountFavMobileSiteUnique = objReport.CountFavMobileSiteUnique(FromPre30Days, To30Days);
        }

        using (ShopperReportGateway objShopperReport = new ShopperReportGateway())
        {
            int Limit1 = 1;
            DataTable ShopperDt = objShopperReport.ShopperTime(FromPre30Days, To30Days, Limit1);

            if (ShopperDt.Rows.Count > 0)
            {
                Total_ReturnShopperRecord = ShopperDt.Rows.Count.ToString();
            }
            else
            {
                Total_ReturnShopperRecord = "0";
            }
        }

        avgReturnShopper = GetReturnShopper(Shopper, Total_ReturnShopperRecord);
    }

    private void CodOpsBkashMethodToday()
    {
        using (ControlPanelGateway ObjControlGateway = new ControlPanelGateway())
        {
            int BkashTotal = 0, BkashDhaka = 0, CODTotal = 0, CODDhaka = 0, CardTotal = 0, CardDhaka = 0;

            DataTable dataTable = new DataTable();
            string StartToDate = DateTime.Now.ToShortDateString();
            string EndToDate = DateTime.Now.AddDays(1).ToShortDateString();

            string StrToday0 = string.Empty, StrToday1 = string.Empty, StrToday2 = string.Empty, StrToday3 = string.Empty;

            // Bkash Today
            dataTable = ObjControlGateway.GetTotalCountOfTransaction(StartToDate, EndToDate, "MPS", "");
            if (dataTable.Rows.Count > 0)
            {
                BkashTotal = Convert.ToInt32(dataTable.Rows[0]["Total"]);
            }

            dataTable = ObjControlGateway.GetTotalCountOfTransaction(StartToDate, EndToDate, "MPS", "14");
            if (dataTable.Rows.Count > 0)
            {
                BkashDhaka = Convert.ToInt32(dataTable.Rows[0]["Total"]);
            }

            // COD Today
            dataTable = ObjControlGateway.GetTotalCountOfTransaction(StartToDate, EndToDate, "COD", "");
            if (dataTable.Rows.Count > 0)
            {
                CODTotal = Convert.ToInt32(dataTable.Rows[0]["Total"]);
            }

            dataTable = ObjControlGateway.GetTotalCountOfTransaction(StartToDate, EndToDate, "COD", "14");
            if (dataTable.Rows.Count > 0)
            {
                CODDhaka = Convert.ToInt32(dataTable.Rows[0]["Total"]);
            }


            // OPS Today
            dataTable = ObjControlGateway.GetTotalCountOfTransaction(StartToDate, EndToDate, "OPS", "");
            if (dataTable.Rows.Count > 0)
            {
                CardTotal = Convert.ToInt32(dataTable.Rows[0]["Total"]);
            }

            dataTable = ObjControlGateway.GetTotalCountOfTransaction(StartToDate, EndToDate, "OPS", "14");
            if (dataTable.Rows.Count > 0)
            {
                CardDhaka = Convert.ToInt32(dataTable.Rows[0]["Total"]);
            }


            int BkashOutside = BkashTotal - BkashDhaka;
            int CODOutside = CODTotal - CODDhaka;
            int CardOutside = CardTotal - CardDhaka;

            StrToday0 = "<thead class='thin-border-bottom'><tr><th><i class='icon-caret-right blue'></i>Bkash</th><th><i class='icon-caret-right blue'></i>COD</th><th><i class='icon-caret-right blue'></i>OPS</th></tr></thead>";

            StrToday1 = "<tbody><tr><td><b class='black'> Inside Dhaka " + BkashDhaka + "</b></td><td><b class='green'> Inside Dhaka " + CODDhaka + "</b></td><td><b class='pink'> Inside Dhaka " + CardDhaka + "</b></td></tr></tbody>";
            StrToday2 = "<tbody><tr><td><b class='black'> Outside Dhaka " + BkashOutside + "</b></td><td><b class='green'> Outside Dhaka " + CODOutside + "</b></td><td><b class='pink'> Outside Dhaka " + CardOutside + "</b></td></tr></tbody>";
            StrToday3 = "<tbody><tr><td><b class='black'> Total " + BkashTotal + "</b></td><td><b class='green'> Total " + CODTotal + "</b></td><td><b class='pink'> Total " + CardTotal + "</b></td></tr></tbody>";

            Bkash_Today = StrToday0 + StrToday1 + StrToday2 + StrToday3;


        }
    }

    private void PerformingMerchantMethodToday()
    {
        String Today = DateTime.Now.ToShortDateString();
        String Yesterday = DateTime.Now.Date.AddDays(-1).ToShortDateString();
        String Check = "00";

        using (ControlPanelGateway ObjControlGateway = new ControlPanelGateway())
        {
            DataTable dt = new DataTable();

            Dictionary<int, int> objDic = new Dictionary<int, int>();

            dt = ObjControlGateway.PerformingMerchant(Yesterday, Yesterday);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int MerchantId = Convert.ToInt32(dt.Rows[i][0]);
                    objDic[MerchantId] = Convert.ToInt32(dt.Rows[i][2]);
                }
            }


            //Today = "12/01/2015";
            dt = ObjControlGateway.PerformingMerchant(Today, Today);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string arrow = String.Empty;
                    int MerchantId = Convert.ToInt32(dt.Rows[i][0]);

                    if (objDic.ContainsKey(MerchantId))
                    {
                        if (objDic[MerchantId] < Convert.ToInt32(dt.Rows[i][2]))
                        {
                            arrow = "<span style='color: #0310FF'>↑</span>";
                        }
                        else if (objDic[MerchantId] > Convert.ToInt32(dt.Rows[i][2]))
                        {
                            arrow = "<span style='color: #FF0000'>↓</span>";
                        }
                        else if (objDic[MerchantId] == Convert.ToInt32(dt.Rows[i][2]))
                        {
                            arrow = "<span style='color: #000000'>↓↑</span>";
                        }
                    }

                    PerformingMerchant_Today += "<tr><td><b class='black'>" + dt.Rows[i][1] + "</b></td><td data-toggle='modal' data-target='#Model1'><span style='cursor: pointer;' id ='" + dt.Rows[i][0] + "-" + Today + "-" + Today + "-" + Check + "' onclick = 'GetPerformingMerchantPopUp(this.id);' class='green'>" + dt.Rows[i][2] + arrow + "</span></td><td><b class='pink'>" + dt.Rows[i][3] + "</b></td></tr>";
                }
            }
        }
    }


    private void PerformingSubCategoryMethodToday()
    {
        String Today = DateTime.Now.ToShortDateString();
        String Yesterday = DateTime.Now.Date.AddDays(-1).ToShortDateString();
        String CheckCategory = "0";


        using (ControlPanelGateway ObjControlGateway = new ControlPanelGateway())
        {
            Dictionary<int, int> objDicCategory = new Dictionary<int, int>();
            DataTable dt = new DataTable();
            dt = ObjControlGateway.PerformingSubCategory(Yesterday, Yesterday);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int MerchantId = Convert.ToInt32(dt.Rows[i][0]);
                    objDicCategory[MerchantId] = Convert.ToInt32(dt.Rows[i][2]);
                }
            }

            
            dt = ObjControlGateway.PerformingSubCategory(Today, Today);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string arrow = String.Empty;
                    int MerchantId = Convert.ToInt32(dt.Rows[i][0]);

                    if (objDicCategory.ContainsKey(MerchantId))
                    {
                        if (objDicCategory[MerchantId] < Convert.ToInt32(dt.Rows[i][2]))
                        {
                            arrow = "<span style='color: #0310FF'>↑</span>";
                        }
                        else if (objDicCategory[MerchantId] > Convert.ToInt32(dt.Rows[i][2]))
                        {
                            arrow = "<span style='color: #FF0000'>↓</span>";
                        }
                        else if (objDicCategory[MerchantId] == Convert.ToInt32(dt.Rows[i][2]))
                        {
                            arrow = "<span style='color: #000000'>↓↑</span>";
                        }
                    }

                    PerformingCategory_Today += "<tr><td><b class='black'>" + dt.Rows[i]["SubCategoryName"] + "</b></td><td data-toggle='modal' data-target='#Model1'><span style='cursor: pointer;' id ='" + dt.Rows[i]["SubCategoryId"] + "-" + Today + "-" + Today + "-" + CheckCategory + "' onclick = 'GetPerformingMerchantPopUp(this.id);' class='green'>" + dt.Rows[i]["CouponSold"] + arrow + "</span></td><td><b class='pink'>" + dt.Rows[i]["TotalConfirmed"] + "</b></td><td><b class='pink'>" + dt.Rows[i]["TotalMerchant"] + "</b></td><td><b class='blue'>" + dt.Rows[i]["AvgValueOfTrans"] + "</b></td></tr>";

                }
            }
        }
    }

    private void LoadToBeVerifiedBookingReports(string FulFillmentRating, string Status)
    {
        using (AdminBookingReportGateway objAdminBookingReportGateway = new AdminBookingReportGateway())
        {
            DataTable dataTable = objAdminBookingReportGateway.ToBeVerifiedBookingReports(FulFillmentRating, Status);

            if (dataTable.Rows.Count > 0)
            {
                ToBeVerified = Convert.ToInt32(dataTable.Rows[0]["Total"]);
            }

            DataTable dt = objAdminBookingReportGateway.VerifiedBookingReports(FulFillmentRating, Status);
            if (dt.Rows.Count > 0)
            {
                Verified = Convert.ToInt32(dt.Rows[0]["Total"]);
            }
        }
    }


    private object GetReportSummary(string IsDone)
    {
        int Count = 0;
        string strBasedOn = "PostedOn";
        try
        {
            using (AdminBookingReportGateway ObjAdminBookingReportGateway = new AdminBookingReportGateway())
            {
                DataTable dataTable = ObjAdminBookingReportGateway.LoadBookingReportsStatusCountWithDateRange("", "", IsDone, strBasedOn);
                Count = Convert.ToInt32(dataTable.Rows[0]["Total"]);
            }
        }
        catch (Exception ex)
        {
            throw new Exception("No data found ", ex);
        }
        return Count;
    }

    private object GetReportSummaryNewOrder(string IsDone)
    {
        int Count = 0;
        string strBasedOn = "CrmConfirmationDate";
        try
        {
            using (AdminBookingReportGateway ObjAdminBookingReportGateway = new AdminBookingReportGateway())
            {
                DataTable dataTable = ObjAdminBookingReportGateway.LoadBookingReportsStatusCountWithDateRange("", "", IsDone, strBasedOn);
                Count = Convert.ToInt32(dataTable.Rows[0]["Total"]);
            }
        }
        catch (Exception ex)
        {
            throw new Exception("No data found ", ex);
        }
        return Count;
    }

    private object GetReport(string IsDone)
    {
        String Today = DateTime.Now.ToShortDateString();
        int Count = 0;
        string strBasedOn = "PostedOn";
        string GetReportToDate = DateTime.Now.Date.AddDays(1).ToShortDateString();

        try
        {
            using (AdminBookingReportGateway ObjAdminBookingReportGateway = new AdminBookingReportGateway())
            {
                DataTable dataTable = ObjAdminBookingReportGateway.LoadBookingReportsStatusCountWithDateRange(Today, GetReportToDate, IsDone, strBasedOn);
                Count = Convert.ToInt32(dataTable.Rows[0]["Total"]);
            }
        }
        catch (Exception ex)
        {
            throw new Exception("No data found ", ex);
        }
        return Count;
    }

    private string GetReturnShopper(string Shopper, string Total_ReturnShopperRecord)
    {
        double GetReturnShopperavg = 0;

        GetReturnShopperavg = (Convert.ToDouble(Total_ReturnShopperRecord) / Convert.ToDouble(Shopper)) * 100;
        return Math.Ceiling(GetReturnShopperavg).ToString();
    }

    //private void LoadUploadedDealByUser()
    //{
    //    try
    //    {
    //        using (ControlPanelGateway ObjControlPanelGateway = new ControlPanelGateway())
    //        {
    //            DataTable dataTable = ObjControlPanelGateway.LoadUploadedDealByUser(intUserId);
    //            if (dataTable.Rows.Count > 0)
    //            {
    //                DealsGridView.DataSource = dataTable;
    //                DealsGridView.DataBind();
    //            }
    //            else
    //            {
    //                UploadedDealsLabel.Text = "";
    //            }
    //        }
    //    }
    //    catch (Exception exp)
    //    {
    //        UploadedDealsLabel.Text = "";
    //    }
    //}

    private int GetNeedToDealVerifyByContent()
    {
        try
        {
            int intTotalCount = 0;

            using (ControlPanelGateway ObjControlPanelGateway = new ControlPanelGateway())
            {
                DataTable dataTable = ObjControlPanelGateway.GetNeedToDealVerifyByContent();
                if (dataTable.Rows.Count > 0)
                {
                    intTotalCount = Convert.ToInt32(dataTable.Rows[0]["TotalCount"].ToString());
                }
                else
                {
                    intTotalCount = 0;
                }
            }

            return intTotalCount;
        }
        catch
        {
            throw;
        }
    }

    private int GetNeedToDealVerifyBySales()
    {
        try
        {
            int intTotalCount = 0;

            using (ControlPanelGateway ObjControlPanelGateway = new ControlPanelGateway())
            {
                DataTable dataTable = ObjControlPanelGateway.GetNeedToDealVerifyBySales(intUserId);

                if (dataTable.Rows.Count > 0)
                {
                    intTotalCount = Convert.ToInt32(dataTable.Rows[0]["TotalCount"].ToString());
                }
                else
                {
                    intTotalCount = 0;
                }
            }

            return intTotalCount;
        }
        catch
        {
            throw;
        }
    }


    [WebMethod]
    public static string WishList()
    {
        string allString = "";
        string Shopper = "", Total_ReturnShopperRecord = "";
        string FromPre30Days = DateTime.Now.AddDays(-30).ToShortDateString();
        string To30Days = DateTime.Now.ToShortDateString();

        string NewMerchant = "", CountOrderMainSite = "", CountOrderMobileSite ="",
            CountOrderMainSiteUnique = "", CountOrderMobileSiteUnique = "", CountFavMainSite = "",
            CountFavMobileSite = "", CountFavMainSiteUnique = "", CountFavMobileSiteUnique = "";

        using (MerchantLiquidityReportGateway objReport = new MerchantLiquidityReportGateway())
        {
            NewMerchant = objReport.CountNewMerchant(FromPre30Days, To30Days);
        }

        using (ShopperReportGateway objShopperReport = new ShopperReportGateway())
        {
            Shopper = objShopperReport.CountShopper(FromPre30Days, To30Days);
        }

        using (OrderFavReportGateway objReport = new OrderFavReportGateway())
        {
            CountOrderMainSite = objReport.CountOrderMainSite(FromPre30Days, To30Days);
            CountOrderMobileSite = objReport.CountOrderMobileSite(FromPre30Days, To30Days);

            CountOrderMainSiteUnique = objReport.CountOrderMainSiteUnique(FromPre30Days, To30Days);
            CountOrderMobileSiteUnique = objReport.CountOrderMobileSiteUnique(FromPre30Days, To30Days);

            CountFavMainSite = objReport.CountOrderFavMainSite(FromPre30Days, To30Days);
            CountFavMobileSite = objReport.CountOrderFavMobileSite(FromPre30Days, To30Days);

            CountFavMainSiteUnique = objReport.CountOrderFavMainSiteUnique(FromPre30Days, To30Days);
            CountFavMobileSiteUnique = objReport.CountFavMobileSiteUnique(FromPre30Days, To30Days);
        }

        using (ShopperReportGateway objShopperReport = new ShopperReportGateway())
        {
            int Limit1 = 1;
            DataTable ShopperDt = objShopperReport.ShopperTime(FromPre30Days, To30Days, Limit1);

            if (ShopperDt.Rows.Count > 0)
            {
                Total_ReturnShopperRecord = ShopperDt.Rows.Count.ToString();
            }
            else
            {
                Total_ReturnShopperRecord = "0";
            }
        }

        string avgReturnShopper = GetReturnShopperStatic(Shopper, Total_ReturnShopperRecord);

        allString = CountOrderMainSite + "-" + CountOrderMobileSite + "-" + CountOrderMainSiteUnique + "-" + CountOrderMobileSiteUnique
            + "-" + NewMerchant + "-" + avgReturnShopper + "-" + CountFavMainSite + "-" + CountFavMobileSite
            + "-" + CountFavMainSiteUnique + "-" + CountFavMobileSiteUnique;

        return allString;
    }

    private static string GetReturnShopperStatic(string Shopper, string Total_ReturnShopperRecord)
    {
        double GetReturnShopperavg = 0;

        GetReturnShopperavg = (Convert.ToDouble(Total_ReturnShopperRecord) / Convert.ToDouble(Shopper)) * 100;
        return Math.Ceiling(GetReturnShopperavg).ToString();
    }

    [WebMethod]
    public static string GetOrderModel(string whichTypeOfModel)
    {
        StringBuilder data = new StringBuilder();
        DataTable dataTable;

        data.Append("<table class='table table-bordered'>");
        data.Append("<thead class='table-striped'>");
        data.Append("<tr class='odd gradeX'>");
        data.Append("<th style='width: 83px;'>SNo.</th><th>Booking Code</th><th>POD Number</th><th>Deal Title</th><th>Quantity</th><th>Price</th><th>Company Name</th><th>Order From</th><th>Courier</th><th>Order Date</th><th>Confirmation Date</th><th>Comments</th><th>Image</th><th>Sold Out</th>");
        data.Append("</th></tr></thead>");

        data.Append("<tbody>");
        using (ControlPanelGateway ObjControlPanelGateway = new ControlPanelGateway())
        {
            String model = "1,2", model1 = "1", model2 = "2";
            switch (whichTypeOfModel)
            {
                case "1":
                    String successOrderM1Today = DateTime.Now.ToShortDateString();
                    dataTable = ObjControlPanelGateway.CrmOrderPopUp(successOrderM1Today, successOrderM1Today, model1);
                    //dataTable = ObjControlPanelGateway.GetModel("7,16,19,10,111,18,24,17,109,155,104,101,102,105", "Today");
                    break;
                case "2":
                    String successOrderM2Today = DateTime.Now.ToShortDateString();
                    dataTable = ObjControlPanelGateway.CrmOrderPopUp(successOrderM2Today, successOrderM2Today, model2);
                    //dataTable = ObjControlPanelGateway.GetModel("1,9,11,13,15,20,32,33,117,124,28,55,204,201,202,205", "Today");
                    break;
                case "3":
                    String successOrderM1Yesterday = DateTime.Now.AddDays(-1).ToShortDateString();
                    dataTable = ObjControlPanelGateway.CrmOrderPopUp(successOrderM1Yesterday, successOrderM1Yesterday, model1);
                    //dataTable = ObjControlPanelGateway.GetModel("7,16,19,10,111,18,24,17,109,155,104,101,102,105", "Yesterday");
                    break;
                case "4":
                    String successOrderM2Yesterday = DateTime.Now.AddDays(-1).ToShortDateString();
                    dataTable = ObjControlPanelGateway.CrmOrderPopUp(successOrderM2Yesterday, successOrderM2Yesterday, model2);
                    //dataTable = ObjControlPanelGateway.GetModel("1,9,11,13,15,20,32,33,117,124,28,55,204,201,202,205", "Yesterday");
                    break;
                case "5":
                    String successOrderToday = DateTime.Now.ToShortDateString();
                    dataTable = ObjControlPanelGateway.CrmOrderPopUp(successOrderToday, successOrderToday, model);
                    //dataTable = ObjControlPanelGateway.GetModel("1,7,9,10,11,13,15,16,19,20,32,33,111,109,18,17,24,117,124,28,55,155,104,204,101,201,102,202,105,205", "Today");
                    break;
                case "6":
                    String successOrderYesterday = DateTime.Now.AddDays(-1).ToShortDateString();
                    dataTable = ObjControlPanelGateway.CrmOrderPopUp(successOrderYesterday, successOrderYesterday, model);
                    //dataTable = ObjControlPanelGateway.GetModel("1,7,9,10,11,13,15,16,19,20,32,33,111,109,18,17,24,117,124,28,55,155,104,204,101,201,102,202,105,205", "Yesterday");
                    break;
                case "7":
                    String successOrderLast3rd = DateTime.Now.AddDays(-2).ToShortDateString();
                    dataTable = ObjControlPanelGateway.CrmOrderPopUp(successOrderLast3rd, successOrderLast3rd, model);
                    //dataTable = ObjControlPanelGateway.GetModel("1,7,9,10,11,13,15,16,19,20,32,33,111,109,18,17,24,117,124,28,55,155,104,204,101,201,102,202,105,205", "Last3rd");
                    break;
                case "8":
                    String successOrderLast4th = DateTime.Now.AddDays(-3).ToShortDateString();
                    dataTable = ObjControlPanelGateway.CrmOrderPopUp(successOrderLast4th, successOrderLast4th, model);
                    //dataTable = ObjControlPanelGateway.GetModel("1,7,9,10,11,13,15,16,19,20,32,33,111,109,18,17,24,117,124,28,55,155,104,204,101,201,102,202,105,205", "Last4th");
                    break;
                case "9":
                    String successOrderLast5th = DateTime.Now.AddDays(-4).ToShortDateString();
                    dataTable = ObjControlPanelGateway.CrmOrderPopUp(successOrderLast5th, successOrderLast5th, model);
                    //dataTable = ObjControlPanelGateway.GetModel("1,7,9,10,11,13,15,16,19,20,32,33,111,109,18,17,24,117,124,28,55,155,104,204,101,201,102,202,105,205", "Last5th");
                    break;
                case "10":
                    String successOrderM1Last3rd = DateTime.Now.AddDays(-2).ToShortDateString();
                    dataTable = ObjControlPanelGateway.CrmOrderPopUp(successOrderM1Last3rd, successOrderM1Last3rd, model1);
                    //dataTable = ObjControlPanelGateway.GetModel("7,16,19,10,111,18,24,17,109,155,104,101,102,105", "Last3rd");
                    break;
                case "11":
                    String successOrderM2Last3rd = DateTime.Now.AddDays(-2).ToShortDateString();
                    dataTable = ObjControlPanelGateway.CrmOrderPopUp(successOrderM2Last3rd, successOrderM2Last3rd, model2);
                    //dataTable = ObjControlPanelGateway.GetModel("1,9,11,13,15,20,32,33,117,124,28,55,204,201,202,205", "Last3rd");
                    break;
                case "12":
                    String successOrderM1Last4th = DateTime.Now.AddDays(-3).ToShortDateString();
                    dataTable = ObjControlPanelGateway.CrmOrderPopUp(successOrderM1Last4th, successOrderM1Last4th, model1);
                    //dataTable = ObjControlPanelGateway.GetModel("7,16,19,10,111,18,24,17,109,155,104,101,102,105", "Last4th");
                    break;
                case "13":
                    String successOrderM2Last4th = DateTime.Now.AddDays(-3).ToShortDateString();
                    dataTable = ObjControlPanelGateway.CrmOrderPopUp(successOrderM2Last4th, successOrderM2Last4th, model2);
                    //dataTable = ObjControlPanelGateway.GetModel("1,9,11,13,15,20,32,33,117,124,28,55,204,201,202,205", "Last4th");
                    break;
                case "14":
                    String successOrderM1Last5th = DateTime.Now.AddDays(-4).ToShortDateString();
                    dataTable = ObjControlPanelGateway.CrmOrderPopUp(successOrderM1Last5th, successOrderM1Last5th, model1);
                    //dataTable = ObjControlPanelGateway.GetModel("7,16,19,10,111,18,24,17,109,155,104,101,102,105", "Last5th");
                    break;
                case "15":
                    String successOrderM2Last5th = DateTime.Now.AddDays(-4).ToShortDateString();
                    dataTable = ObjControlPanelGateway.CrmOrderPopUp(successOrderM2Last5th, successOrderM2Last5th, model2);
                    //dataTable = ObjControlPanelGateway.GetModel("1,9,11,13,15,20,32,33,117,124,28,55,204,201,202,205", "Last5th");
                    break;
                default:
                    dataTable = null;
                    break;
            }
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

                data.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{3}</td><td>{4}(<a href='http://www.ajkerdeal.com/Product/{2}/{14}' target=_blank>{2}</a>)</td><td>{13}</td><td>{12}</td><td>{5}</td><td>{6}</td><td>{7}</td><td>{8}</td><td>{9}</td><td>{10}</td><td>{11}</td><td>{15}</td></tr>",
                    count++, "<span data-toggle='modal' data-target='#GetDeal' onclick='GetDetailsPopup(this.id);' id='" + row["CouponId"] + "'><b style='color:#DEB887;cursor:pointer;'>" + row["CouponId"] + "</b></span>",
                    row["DealId"], row["PODnumber"], row["DealTitle"], row["CompanyName"], row["OrderFrom"],
                    row["Courier"], row["PostedOnDate"], row["CrmConfirmationDate"], row["Comments"],
                    "<img src='http://www.ajkerdeal.com/images/Deals/" + row["FolderName"] + "/dealdetails1.jpg' width='60px'>",
                    row["CouponPrice"], row["CouponQtn"], row["DealTitleEng"],
                    "<span onclick='SoldOutProduct(" + row["DealId"] + "," + userId + ");'><b style='color:#DEB887;cursor:pointer;'>" + IsSoldOut + "</b></span>");
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
    public static string GetOrderModelStatus(string whichTypeOfStatus, string Day)
    {
        StringBuilder data = new StringBuilder();
        DataTable dataTable;

        data.Append("<table class='table table-bordered'>");
        data.Append("<thead class='table-striped'>");
        data.Append("<tr class='odd gradeX'>");
        data.Append("<th style='width: 83px;'>SNo.</th><th>Booking Code</th><th>POD Number</th><th>Deal Title</th><th>Quantity</th><th>Price</th><th>Company Name</th><th>Order From</th><th>Courier</th><th>Confirmation Date</th><th>Recent Comments</th><th>Image</th>");
        data.Append("</th></tr></thead>");

        data.Append("<tbody>");
        using (ControlPanelGateway ObjControlPanelGateway = new ControlPanelGateway())
        {
            dataTable = ObjControlPanelGateway.GetModel(whichTypeOfStatus, Day);
        }


        if (dataTable != null && dataTable.Rows.Count > 0)
        {
            int count = 1;
            foreach (DataRow row in dataTable.Rows)
            {
                data.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{3}</td><td>{4}(<a href='http://www.ajkerdeal.com/Product/{2}/{4}'target=_blank>{2}</a>)</td><td>{12}</td><td>{11}</td><td>{5}</td><td>{6}</td><td>{7}</td><td>{8}</td><td>{9}</td><td>{10}</td></tr>",
                    count++, "<span data-toggle='modal' data-target='#GetDeal' onclick='GetDetailsPopup(this.id);' id='" + row["CouponId"] + "'><b style='color:#DEB887;cursor:pointer;'>" + row["CouponId"] + "</b></span>",
                        row["DealId"], row["PODnumber"], row["DealTitle"], row["CompanyName"], row["OrderFrom"],
                        row["Courier"], row["CrmConfirmationDate"], row["Comments"],
                        "<img src='http://www.ajkerdeal.com/images/Deals/" + row["FolderName"] + "/dealdetails1.jpg' width='60px'>", row["CouponPrice"], row["CouponQtn"]);
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
    public static string GetDetailsPopupMethod(string CouponId)
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
                    row["CompanyName"], row["ContactPerson"], row["Mobile"], row["LoginEmail"], row["BusinessModel"],// row["BusinessModelType"]
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

    [WebMethod]
    public static List<string> LoadComments(string CouponId)
    {
        List<string> ListArray = new List<string>();
        ListArray.Add(GetDetailsPopupMethod(CouponId));
        ListArray.Add(GetDealComments(CouponId));
        return ListArray.ToList();
    }


    [WebMethod]
    public static string LoadPerformingCategory(string strId)
    {
        String CheckCategoryCategory = "000";
        String PerformingCategory = string.Empty;

        string startDate = string.Empty, endDate = string.Empty;
        string past_StartDate = string.Empty, past_EndDate = string.Empty;

        if (strId == "dayToCa")
        {
            past_StartDate = DateTime.Now.Date.AddDays(-1).ToShortDateString();
            past_EndDate = DateTime.Now.Date.AddDays(-1).ToShortDateString();

            startDate = DateTime.Now.ToShortDateString();
            endDate = DateTime.Now.ToShortDateString();
        }

        else if (strId == "dayYesterCa")
        {
            past_StartDate = DateTime.Now.Date.AddDays(-2).ToShortDateString();
            past_EndDate = DateTime.Now.Date.AddDays(-2).ToShortDateString();

            startDate = DateTime.Now.Date.AddDays(-1).ToShortDateString();
            endDate = DateTime.Now.Date.AddDays(-1).ToShortDateString();
        }

        else if (strId == "daysLast3Ca")
        {
            past_StartDate = DateTime.Now.Date.AddDays(-5).ToShortDateString();
            past_EndDate = DateTime.Now.Date.AddDays(-3).ToShortDateString();

            startDate = DateTime.Now.Date.AddDays(-2).ToShortDateString();
            endDate = DateTime.Now.Date.AddDays(-0).ToShortDateString();
        }

        else if (strId == "weekLastCa")
        {
            past_StartDate = DateTime.Now.Date.AddDays(-13).ToShortDateString();
            past_EndDate = DateTime.Now.Date.AddDays(-7).ToShortDateString();

            startDate = DateTime.Now.Date.AddDays(-6).ToShortDateString();
            endDate = DateTime.Now.Date.AddDays(0).ToShortDateString();
        }


        // Check Performing Category
            using (ControlPanelGateway ObjControlGateway = new ControlPanelGateway())
            {
                Dictionary<int, int> objDic = new Dictionary<int, int>();

                DataTable dt = new DataTable();

                // Past Start Day
                dt = ObjControlGateway.PerformingCategory(past_StartDate, past_EndDate);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int MerchantId = Convert.ToInt32(dt.Rows[i][0]);
                        objDic[MerchantId] = Convert.ToInt32(dt.Rows[i][2]);
                    }
                }

                // Present Start Day
                dt = ObjControlGateway.PerformingCategory(startDate, endDate);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string arrow = String.Empty;
                        int MerchantId = Convert.ToInt32(dt.Rows[i][0]);

                        if (objDic.ContainsKey(MerchantId))
                        {
                            if (objDic[MerchantId] < Convert.ToInt32(dt.Rows[i][2]))
                            {
                                arrow = "<span style='color: #0310FF'>↑</span>";
                            }
                            else if (objDic[MerchantId] > Convert.ToInt32(dt.Rows[i][2]))
                            {
                                arrow = "<span style='color: #FF0000'>↓</span>";
                            }
                            else if (objDic[MerchantId] == Convert.ToInt32(dt.Rows[i][2]))
                            {
                                arrow = "<span style='color: #000000'>↓↑</span>";
                            }
                        }

                        PerformingCategory += "<tr><td><b class='black'>" + dt.Rows[i]["CategoryName"] + "</b></td><td data-toggle='modal' data-target='#Model1'><span style='cursor: pointer;' id ='" + dt.Rows[i]["CategoryId"] + "-" + startDate + "-" + endDate + "-" + CheckCategoryCategory + "' onclick = 'GetPerformingMerchantPopUp(this.id);' class='green'>" + dt.Rows[i]["CouponSold"] + arrow + "</span></td><td><b class='pink'>" + dt.Rows[i]["TotalConfirmed"] + "</b></td><td><b class='pink'>" + dt.Rows[i]["TotalMerchant"] + "</b></td><td><b class='blue'>" + dt.Rows[i]["AvgValueOfTrans"] + "</b></td></tr>";
                    }
                }

                return PerformingCategory;
            }


    }

    [WebMethod]
    public static string LoadPerformingMerchant(string strId, string Check)
    {
        String CheckMerchant = "00";
        String CheckCategory = "0";
        string Per = string.Empty;
        string PerformingMerchant = string.Empty, 
         PerformingSubCategory = string.Empty;
        string startDate = string.Empty, endDate = string.Empty;
        string past_StartDate = string.Empty, past_EndDate = string.Empty;

        if (strId == "dayTo")
        {
            past_StartDate = DateTime.Now.Date.AddDays(-1).ToShortDateString();
            past_EndDate = DateTime.Now.Date.AddDays(-1).ToShortDateString();

            startDate = DateTime.Now.ToShortDateString();
            endDate = DateTime.Now.ToShortDateString();
        }

        else if (strId == "100Day")
        {
            past_StartDate = DateTime.Now.AddDays(-200).ToShortDateString();
            past_EndDate = DateTime.Now.AddDays(-100).ToShortDateString();

            startDate = DateTime.Now.AddDays(-100).ToShortDateString();
            endDate = DateTime.Now.ToShortDateString();
        }

        else if (strId == "Month1")
        {
            string month = DateTime.Now.AddMonths(-1).Month.ToString();
            string year = DateTime.Now.Year.ToString();
            DateTime firstDay = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), 1);
            past_StartDate = firstDay.ToShortDateString();

            DateTime dtTo = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtTo = dtTo.AddDays(-(dtTo.Day));

            past_EndDate = dtTo.ToShortDateString();

            string monthCurrent = DateTime.Now.AddMonths(0).Month.ToString();
            DateTime firstDayCurrent = new DateTime(Convert.ToInt32(year), Convert.ToInt32(monthCurrent), 1);
            startDate = firstDayCurrent.ToShortDateString();
            endDate = DateTime.Now.ToShortDateString();
        }

        else if (strId == "weekLast")
        {
            past_StartDate = DateTime.Now.Date.AddDays(-13).ToShortDateString();
            past_EndDate = DateTime.Now.Date.AddDays(-7).ToShortDateString();

            startDate = DateTime.Now.Date.AddDays(-6).ToShortDateString();
            endDate = DateTime.Now.Date.AddDays(0).ToShortDateString();
        }

        else if (strId == "daysLast3")
        {
            past_StartDate = DateTime.Now.Date.AddDays(-5).ToShortDateString();
            past_EndDate = DateTime.Now.Date.AddDays(-3).ToShortDateString();

            startDate = DateTime.Now.Date.AddDays(-2).ToShortDateString();
            endDate = DateTime.Now.Date.AddDays(-0).ToShortDateString();
        }

        else if (strId == "dayYester")
        {
            past_StartDate = DateTime.Now.Date.AddDays(-2).ToShortDateString();
            past_EndDate = DateTime.Now.Date.AddDays(-2).ToShortDateString();

            startDate = DateTime.Now.Date.AddDays(-1).ToShortDateString();
            endDate = DateTime.Now.Date.AddDays(-1).ToShortDateString();

            
        }

        else if (strId == "dayTo2")
        {
            past_StartDate = DateTime.Now.Date.AddDays(-1).ToShortDateString();
            past_EndDate = DateTime.Now.Date.AddDays(-1).ToShortDateString();

            startDate = DateTime.Now.ToShortDateString();
            endDate = DateTime.Now.ToShortDateString();
        }

        else if (strId == "100Day2")
        {
            past_StartDate = DateTime.Now.AddDays(-200).ToShortDateString();
            past_EndDate = DateTime.Now.AddDays(-100).ToShortDateString();

            startDate = DateTime.Now.AddDays(-100).ToShortDateString();
            endDate = DateTime.Now.ToShortDateString();;
        }

        else if (strId == "Month2")
        {
            string month = DateTime.Now.AddMonths(-1).Month.ToString();
            string year = DateTime.Now.Year.ToString();
            DateTime firstDay = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), 1);
            past_StartDate = firstDay.ToShortDateString();

            DateTime dtTo = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtTo = dtTo.AddDays(-(dtTo.Day));

            past_EndDate = dtTo.ToShortDateString();

            string monthCurrent = DateTime.Now.AddMonths(0).Month.ToString();
            DateTime firstDayCurrent = new DateTime(Convert.ToInt32(year), Convert.ToInt32(monthCurrent), 1);
            startDate = firstDayCurrent.ToShortDateString();
            endDate = DateTime.Now.ToShortDateString();
        }
        else if (strId == "weekLast2")
        {
            past_StartDate = DateTime.Now.Date.AddDays(-13).ToShortDateString();
            past_EndDate = DateTime.Now.Date.AddDays(-7).ToShortDateString();

            startDate = DateTime.Now.Date.AddDays(-6).ToShortDateString();
            endDate = DateTime.Now.Date.AddDays(0).ToShortDateString();
        }

        else if (strId == "daysLast32")
        {
            past_StartDate = DateTime.Now.Date.AddDays(-5).ToShortDateString();
            past_EndDate = DateTime.Now.Date.AddDays(-3).ToShortDateString();

            startDate = DateTime.Now.Date.AddDays(-2).ToShortDateString();
            endDate = DateTime.Now.Date.AddDays(-0).ToShortDateString();
        }

        else if (strId == "dayYester2")
        {
            past_StartDate = DateTime.Now.Date.AddDays(-2).ToShortDateString();
            past_EndDate = DateTime.Now.Date.AddDays(-2).ToShortDateString();

            startDate = DateTime.Now.Date.AddDays(-1).ToShortDateString();
            endDate = DateTime.Now.Date.AddDays(-1).ToShortDateString();
        }


        // Check Performing Sub Category
        if (Check == "2")
        {

            using (ControlPanelGateway ObjControlGateway = new ControlPanelGateway())
            {
                Dictionary<int, int> objDic = new Dictionary<int, int>();

                DataTable dt = new DataTable();

                // Past Start Day
                dt = ObjControlGateway.PerformingSubCategory(past_StartDate, past_EndDate);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int MerchantId = Convert.ToInt32(dt.Rows[i][0]);
                        objDic[MerchantId] = Convert.ToInt32(dt.Rows[i][2]);
                    }
                }


                // Present Start Day
                dt = ObjControlGateway.PerformingSubCategory(startDate, endDate);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string arrow = String.Empty;
                        int MerchantId = Convert.ToInt32(dt.Rows[i][0]);

                        if (objDic.ContainsKey(MerchantId))
                        {
                            if (objDic[MerchantId] < Convert.ToInt32(dt.Rows[i][2]))
                            {
                                arrow = "<span style='color: #0310FF'>↑</span>";
                            }
                            else if (objDic[MerchantId] > Convert.ToInt32(dt.Rows[i][2]))
                            {
                                arrow = "<span style='color: #FF0000'>↓</span>";
                            }
                            else if (objDic[MerchantId] == Convert.ToInt32(dt.Rows[i][2]))
                            {
                                arrow = "<span style='color: #000000'>↓↑</span>";
                            }
                        }

                        PerformingSubCategory += "<tr><td><b class='black'>" + dt.Rows[i]["SubCategoryName"] + "</b></td><td data-toggle='modal' data-target='#Model1'><span style='cursor: pointer;' id ='" + dt.Rows[i]["SubCategoryId"] + "-" + startDate + "-" + endDate + "-"+ CheckCategory +"' onclick = 'GetPerformingMerchantPopUp(this.id);' class='green'>" + dt.Rows[i]["CouponSold"] + arrow + "</span></td><td><b class='pink'>" + dt.Rows[i]["TotalConfirmed"] + "</b></td><td><b class='pink'>" + dt.Rows[i]["TotalMerchant"] + "</b></td><td><b class='blue'>" + dt.Rows[i]["AvgValueOfTrans"] + "</b></td></tr>";
                    }
                }

                return PerformingSubCategory;
            }

        }

        // Check Performing Merchant
        else if (Check == "1")
        {
            using (ControlPanelGateway ObjControlGateway = new ControlPanelGateway())
            {

                Dictionary<int, int> objDic = new Dictionary<int, int>();

                DataTable dt = new DataTable();

                // Past Start Day
                dt = ObjControlGateway.PerformingMerchant(past_StartDate, past_EndDate);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int MerchantId = Convert.ToInt32(dt.Rows[i][0]);
                        objDic[MerchantId] = Convert.ToInt32(dt.Rows[i][2]);
                    }
                }

                // Present Start Day
                dt = ObjControlGateway.PerformingMerchant(startDate, endDate);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string arrow = String.Empty;
                        int MerchantId = Convert.ToInt32(dt.Rows[i][0]);

                        if (objDic.ContainsKey(MerchantId))
                        {
                            if (objDic[MerchantId] < Convert.ToInt32(dt.Rows[i][2]))
                            {
                                arrow = "<span style='color: #0310FF'>↑</span>";
                            }
                            else if (objDic[MerchantId] > Convert.ToInt32(dt.Rows[i][2]))
                            {
                                arrow = "<span style='color: #FF0000'>↓</span>";
                            }
                            else if (objDic[MerchantId] == Convert.ToInt32(dt.Rows[i][2]))
                            {
                                arrow = "<span style='color: #000000; cursor: pointer;'>↓↑</span>";
                            }
                        }

                        PerformingMerchant += "<tr><td><b class='black'>" + dt.Rows[i][1] + "</b></td><td data-toggle='modal' data-target='#Model1'><span style='cursor: pointer;' id ='" + dt.Rows[i][0] + "-" + startDate + "-" + endDate + "-" + CheckMerchant + "' onclick = 'GetPerformingMerchantPopUp(this.id);' class='green'>" + dt.Rows[i][2] + arrow + "</span></td><td><b class='pink'>" + dt.Rows[i][3] + "</b></td></tr>";
                    }
                }

                return PerformingMerchant;
            }

        }

        return Per;
    }


    [WebMethod]
    public static string LoadDealMerchant(string strId)
    {
        string uniqueDealMerchant = string.Empty;
        string startDate = string.Empty, endDate = string.Empty,
            pastStartDate = string.Empty, pastEndDate = string.Empty;

        if (strId == "todayDeal_First")
        {
            startDate = DateTime.Now.ToShortDateString();
            endDate = DateTime.Now.ToShortDateString();
            pastStartDate = DateTime.Now.AddDays(-1).ToShortDateString();
            pastEndDate = DateTime.Now.AddDays(-1).ToShortDateString();
        }

        else if (strId == "todayDeal")
        {
            startDate = DateTime.Now.ToShortDateString();
            endDate = DateTime.Now.ToShortDateString();
            pastStartDate = DateTime.Now.AddDays(-1).ToShortDateString();
            pastEndDate = DateTime.Now.AddDays(-1).ToShortDateString();
        }
        else if (strId == "yesterdayDeal")
        {
            startDate = DateTime.Now.AddDays(-1).ToShortDateString();
            endDate = DateTime.Now.AddDays(-1).ToShortDateString();
            pastStartDate = DateTime.Now.AddDays(-2).ToShortDateString();
            pastEndDate = DateTime.Now.AddDays(-2).ToShortDateString();
        }
        else if (strId == "last3dayDeal")
        {
            startDate = DateTime.Now.AddDays(-3).ToShortDateString();
            endDate = DateTime.Now.ToShortDateString();
            pastStartDate = DateTime.Now.AddDays(-6).ToShortDateString();
            pastEndDate = DateTime.Now.AddDays(-3).ToShortDateString();
        }

        else if (strId == "last7dayDeal")
        {
            startDate = DateTime.Now.AddDays(-7).ToShortDateString();
            endDate = DateTime.Now.ToShortDateString();
            pastStartDate = DateTime.Now.AddDays(-14).ToShortDateString();
            pastEndDate = DateTime.Now.AddDays(-7).ToShortDateString();
        }
        else if (strId == "last30dayDeal")
        {
            startDate = DateTime.Now.AddDays(-30).ToShortDateString();
            endDate = DateTime.Now.ToShortDateString();
            pastStartDate = DateTime.Now.AddDays(-60).ToShortDateString();
            pastEndDate = DateTime.Now.AddDays(-30).ToShortDateString();
        }
        else if (strId == "last100dayDeal")
        {
            startDate = DateTime.Now.AddDays(-100).ToShortDateString();
            endDate = DateTime.Now.ToShortDateString();
            pastStartDate = DateTime.Now.AddDays(-200).ToShortDateString();
            pastEndDate = DateTime.Now.AddDays(-100).ToShortDateString();
        }

        using (ControlPanelGateway ObjControlGateway = new ControlPanelGateway())
        {
            DataTable table = new DataTable();

            Dictionary<int, int> uniqueDic = new Dictionary<int, int>();
            Dictionary<int, int> uniqueDealDic = new Dictionary<int, int>();
            Dictionary<int, int> uniqueMerchantDic = new Dictionary<int, int>();

            table = ObjControlGateway.Unique_Deal_Merchant(pastStartDate, pastEndDate);
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    int TotalDeal = Convert.ToInt32(table.Rows[i]["SNO"]);
                    uniqueDic[TotalDeal] = Convert.ToInt32(table.Rows[i]["TotalDealwiseOrder"]);
                    uniqueDealDic[TotalDeal] = Convert.ToInt32(table.Rows[i]["TotalDealwiseConfirmOrder"]);
                    uniqueMerchantDic[TotalDeal] = Convert.ToInt32(table.Rows[i]["TotalMerchantwiseOrder"]);
                }

            }

            table = ObjControlGateway.Unique_Deal_Merchant(startDate, endDate);

            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    string arrow1 = String.Empty, arrow2 = string.Empty, arrow3 = string.Empty;
                    int TotalDeal = Convert.ToInt32(table.Rows[i]["SNO"]);

                    if (uniqueDic.ContainsKey(TotalDeal))
                    {
                        if (uniqueDic[TotalDeal] < Convert.ToInt32(table.Rows[i]["TotalDealwiseOrder"]))
                        {
                            arrow1 = "<span style='color: #0310FF'>↑</span>";
                        }
                        else if (uniqueDic[TotalDeal] > Convert.ToInt32(table.Rows[i]["TotalDealwiseOrder"]))
                        {
                            arrow1 = "<span style='color: #FF0000'>↓</span>";
                        }
                        else if (uniqueDic[TotalDeal] == Convert.ToInt32(table.Rows[i]["TotalDealwiseOrder"]))
                        {
                            arrow1 = "<span style='color: #000000'>↓↑</span>";
                        }
                    }

                    if (uniqueDealDic.ContainsKey(TotalDeal))
                    {

                        if (uniqueDealDic[TotalDeal] < Convert.ToInt32(table.Rows[i]["TotalDealwiseConfirmOrder"]))
                        {
                            arrow2 = "<span style='color: #0310FF'>↑</span>";
                        }
                        else if (uniqueDealDic[TotalDeal] > Convert.ToInt32(table.Rows[i]["TotalDealwiseConfirmOrder"]))
                        {
                            arrow2 = "<span style='color: #FF0000'>↓</span>";
                        }
                        else if (uniqueDealDic[TotalDeal] == Convert.ToInt32(table.Rows[i]["TotalDealwiseConfirmOrder"]))
                        {
                            arrow2 = "<span style='color: #000000'>↓↑</span>";
                        }
                    }

                    if (uniqueMerchantDic.ContainsKey(TotalDeal))
                    {
                        if (uniqueMerchantDic[TotalDeal] < Convert.ToInt32(table.Rows[i]["TotalMerchantwiseOrder"]))
                        {
                            arrow3 = "<span style='color: #0310FF'>↑</span>";
                        }
                        else if (uniqueMerchantDic[TotalDeal] > Convert.ToInt32(table.Rows[i]["TotalMerchantwiseOrder"]))
                        {
                            arrow3 = "<span style='color: #FF0000'>↓</span>";
                        }
                        else if (uniqueMerchantDic[TotalDeal] == Convert.ToInt32(table.Rows[i]["TotalMerchantwiseOrder"]))
                        {
                            arrow3 = "<span style='color: #000000'>↓↑</span>";
                        }
                    }

                    uniqueDealMerchant = "<tr><td><span class='black'>" + table.Rows[i]["TotalDealwiseOrder"] + arrow1 + "</span></td><td><span class='green'>" + table.Rows[i]["TotalDealwiseConfirmOrder"] + arrow2 + "</span></td><td><b class='pink'>" + table.Rows[i]["TotalMerchantwiseOrder"] + arrow3 + "</b></td></tr>";

                }
            }
        }


        return uniqueDealMerchant;
    }


    [WebMethod]
    public static string LoadDealCrazy(string strId)
    {

        string uniqueCrazyDeal = string.Empty;
        string startDate = string.Empty, endDate = string.Empty,
            pastStartDate = string.Empty, pastEndDate = string.Empty;


        if (strId == "todayCrazy_First")
        {
            startDate = DateTime.Now.ToShortDateString();
            endDate = DateTime.Now.ToShortDateString();
            pastStartDate = DateTime.Now.AddDays(-1).ToShortDateString();
            pastEndDate = DateTime.Now.AddDays(-1).ToShortDateString();
        }

        else if (strId == "todayCrazy")
        {
            startDate = DateTime.Now.ToShortDateString();
            endDate = DateTime.Now.ToShortDateString();
            pastStartDate = DateTime.Now.AddDays(-1).ToShortDateString();
            pastEndDate = DateTime.Now.AddDays(-1).ToShortDateString();
        }

        else if (strId == "yesterdayCrazy")
        {
            startDate = DateTime.Now.AddDays(-1).ToShortDateString();
            endDate = DateTime.Now.AddDays(-1).ToShortDateString();
            pastStartDate = DateTime.Now.AddDays(-2).ToShortDateString();
            pastEndDate = DateTime.Now.AddDays(-2).ToShortDateString();
        }
        else if (strId == "last3dayCrazy")
        {
            startDate = DateTime.Now.AddDays(-3).ToShortDateString();
            endDate = DateTime.Now.ToShortDateString();
            pastStartDate = DateTime.Now.AddDays(-6).ToShortDateString();
            pastEndDate = DateTime.Now.AddDays(-3).ToShortDateString();
        }

        else if (strId == "last7dayCrazy")
        {
            startDate = DateTime.Now.AddDays(-7).ToShortDateString();
            endDate = DateTime.Now.ToShortDateString();
            pastStartDate = DateTime.Now.AddDays(-14).ToShortDateString();
            pastEndDate = DateTime.Now.AddDays(-7).ToShortDateString();
        }
        else if (strId == "last30dayCrazy")
        {
            startDate = DateTime.Now.AddDays(-30).ToShortDateString();
            endDate = DateTime.Now.ToShortDateString();
            pastStartDate = DateTime.Now.AddDays(-60).ToShortDateString();
            pastEndDate = DateTime.Now.AddDays(-30).ToShortDateString();
        }
        else if (strId == "last100dayCrazy")
        {
            startDate = DateTime.Now.AddDays(-100).ToShortDateString();
            endDate = DateTime.Now.ToShortDateString();
            pastStartDate = DateTime.Now.AddDays(-200).ToShortDateString();
            pastEndDate = DateTime.Now.AddDays(-100).ToShortDateString();
        }

        using (ControlPanelGateway ObjControlGateway = new ControlPanelGateway())
        {
            DataTable table = new DataTable();

            Dictionary<int, int> CrazyDealDic = new Dictionary<int, int>();
            Dictionary<int, int> CrazyTotalDealDic = new Dictionary<int, int>();
            Dictionary<int, int> CrazySumDealDic = new Dictionary<int, int>();

            table = ObjControlGateway.Unique_Crazy_Deal(pastStartDate, pastEndDate);
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    int TotalCrazy = Convert.ToInt32(table.Rows[i]["SNO"]);
                    CrazyDealDic[TotalCrazy] = Convert.ToInt32(table.Rows[i]["TotalDealWithActive"]);
                    CrazyTotalDealDic[TotalCrazy] = Convert.ToInt32(table.Rows[i]["TotalDealCrazyWithActive"]);
                    CrazySumDealDic[TotalCrazy] = Convert.ToInt32(table.Rows[i]["SumOfDealCrazy"]);
                }

            }

            table = ObjControlGateway.Unique_Crazy_Deal(startDate, endDate);

            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    string arrow1 = String.Empty, arrow2 = string.Empty, arrow3 = string.Empty;
                    int TotalCrazy = Convert.ToInt32(table.Rows[i]["SNO"]);

                    if (CrazyDealDic.ContainsKey(TotalCrazy))
                    {
                        if (CrazyDealDic[TotalCrazy] < Convert.ToInt32(table.Rows[i]["TotalDealWithActive"]))
                        {
                            arrow1 = "<span style='color: #0310FF'>↑</span>";
                        }
                        else if (CrazyDealDic[TotalCrazy] > Convert.ToInt32(table.Rows[i]["TotalDealWithActive"]))
                        {
                            arrow1 = "<span style='color: #FF0000'>↓</span>";
                        }
                        else if (CrazyDealDic[TotalCrazy] == Convert.ToInt32(table.Rows[i]["TotalDealWithActive"]))
                        {
                            arrow1 = "<span style='color: #000000'>↓↑</span>";
                        }
                    }

                    if (CrazyTotalDealDic.ContainsKey(TotalCrazy))
                    {

                        if (CrazyTotalDealDic[TotalCrazy] < Convert.ToInt32(table.Rows[i]["TotalDealCrazyWithActive"]))
                        {
                            arrow2 = "<span style='color: #0310FF'>↑</span>";
                        }
                        else if (CrazyTotalDealDic[TotalCrazy] > Convert.ToInt32(table.Rows[i]["TotalDealCrazyWithActive"]))
                        {
                            arrow2 = "<span style='color: #FF0000'>↓</span>";
                        }
                        else if (CrazyTotalDealDic[TotalCrazy] == Convert.ToInt32(table.Rows[i]["TotalDealCrazyWithActive"]))
                        {
                            arrow2 = "<span style='color: #000000'>↓↑</span>";
                        }
                    }
                    if (CrazySumDealDic.ContainsKey(TotalCrazy))
                    {

                        if (CrazySumDealDic[TotalCrazy] < Convert.ToInt32(table.Rows[i]["SumOfDealCrazy"]))
                        {
                            arrow3 = "<span style='color: #0310FF'>↑</span>";
                        }
                        else if (CrazySumDealDic[TotalCrazy] > Convert.ToInt32(table.Rows[i]["SumOfDealCrazy"]))
                        {
                            arrow3 = "<span style='color: #FF0000'>↓</span>";
                        }
                        else if (CrazySumDealDic[TotalCrazy] == Convert.ToInt32(table.Rows[i]["SumOfDealCrazy"]))
                        {
                            arrow3 = "<span style='color: #000000'>↓↑</span>";
                        }
                    }

                    uniqueCrazyDeal = "<tr><td><span class='black'>" + table.Rows[i]["TotalDealWithActive"] + arrow1 + "</span></td><td><span class='green'>" + table.Rows[i]["TotalDealCrazyWithActive"] + arrow2 + "</span></td><td><b class='pink'>" + table.Rows[i]["SumOfDealCrazy"] + arrow3 + "</b></td><td><b class='blue'>" + table.Rows[i]["avgCrazyDeal"] + "%" + "</b></td></tr>";
                }
            }
        }
        return uniqueCrazyDeal;
    }


    [WebMethod]
    public static string LoadDeliverySummary(string strId)
    {

        string deliverySummary = string.Empty;
        string startDate = string.Empty, endDate = string.Empty,
            pastStartDate = string.Empty, pastEndDate = string.Empty;


        if (strId == "todayDelivery_First")
        {
            startDate = DateTime.Now.ToShortDateString();
            endDate = DateTime.Now.ToShortDateString();
            pastStartDate = DateTime.Now.AddDays(-1).ToShortDateString();
            pastEndDate = DateTime.Now.AddDays(-1).ToShortDateString();
        }

        else if (strId == "todayDelivery")
        {
            startDate = DateTime.Now.ToShortDateString();
            endDate = DateTime.Now.ToShortDateString();
            pastStartDate = DateTime.Now.AddDays(-1).ToShortDateString();
            pastEndDate = DateTime.Now.AddDays(-1).ToShortDateString();
        }
        else if (strId == "yesterdayDelivery")
        {
            startDate = DateTime.Now.AddDays(-1).ToShortDateString();
            endDate = DateTime.Now.AddDays(-1).ToShortDateString();
            pastStartDate = DateTime.Now.AddDays(-2).ToShortDateString();
            pastEndDate = DateTime.Now.AddDays(-2).ToShortDateString();
        }
        else if (strId == "last3dayDelivery")
        {
            startDate = DateTime.Now.AddDays(-3).ToShortDateString();
            endDate = DateTime.Now.ToShortDateString();
            pastStartDate = DateTime.Now.AddDays(-6).ToShortDateString();
            pastEndDate = DateTime.Now.AddDays(-3).ToShortDateString();
        }

        else if (strId == "last7dayDelivery")
        {
            startDate = DateTime.Now.AddDays(-7).ToShortDateString();
            endDate = DateTime.Now.ToShortDateString();
            pastStartDate = DateTime.Now.AddDays(-14).ToShortDateString();
            pastEndDate = DateTime.Now.AddDays(-7).ToShortDateString();
        }
        else if (strId == "last30dayDelivery")
        {
            startDate = DateTime.Now.AddDays(-30).ToShortDateString();
            endDate = DateTime.Now.ToShortDateString();
            pastStartDate = DateTime.Now.AddDays(-60).ToShortDateString();
            pastEndDate = DateTime.Now.AddDays(-30).ToShortDateString();
        }
        else if (strId == "last100dayDelivery")
        {
            startDate = DateTime.Now.AddDays(-100).ToShortDateString();
            endDate = DateTime.Now.ToShortDateString();
            pastStartDate = DateTime.Now.AddDays(-200).ToShortDateString();
            pastEndDate = DateTime.Now.AddDays(-100).ToShortDateString();
        }

        using (ControlPanelGateway ObjControlGateway = new ControlPanelGateway())
        {
            DataTable table = new DataTable();

            Dictionary<int, int> TotalDeliveryDic = new Dictionary<int, int>();

            Dictionary<int, int> LateDeliveryDic = new Dictionary<int, int>();
            Dictionary<int, int> Avg_LateDeliveryDic = new Dictionary<int, int>();

            Dictionary<int, int> FastDeliveryDic = new Dictionary<int, int>();
            Dictionary<int, int> Avg_FastDeliveryDic = new Dictionary<int, int>();

            table = ObjControlGateway.DeliverySummary(pastStartDate, pastEndDate);
            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    int TotalDelivery = Convert.ToInt32(table.Rows[i]["SNO"]);
                    TotalDeliveryDic[TotalDelivery] = Convert.ToInt32(table.Rows[i]["TotalDelivery"]);
                    LateDeliveryDic[TotalDelivery] = Convert.ToInt32(table.Rows[i]["LateDelivery"]);
                    Avg_LateDeliveryDic[TotalDelivery] = Convert.ToInt32(table.Rows[i]["Avg_LateDelivery"]);
                    FastDeliveryDic[TotalDelivery] = Convert.ToInt32(table.Rows[i]["FastDelivery"]);
                    Avg_FastDeliveryDic[TotalDelivery] = Convert.ToInt32(table.Rows[i]["Avg_FastDelivery"]);
                }

            }

            table = ObjControlGateway.DeliverySummary(startDate, endDate);

            if (table.Rows.Count > 0)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    string arrow1 = String.Empty, arrow2 = string.Empty, arrow3 = string.Empty;
                    String arrow4 = string.Empty, arrow5 = string.Empty;

                    int TotalDelivery = Convert.ToInt32(table.Rows[i]["SNO"]);

                    if (TotalDeliveryDic.ContainsKey(TotalDelivery))
                    {
                        if (TotalDeliveryDic[TotalDelivery] < Convert.ToInt32(table.Rows[i]["TotalDelivery"]))
                        {
                            arrow1 = "<span style='color: #0310FF'>↑</span>";
                        }
                        else if (TotalDeliveryDic[TotalDelivery] > Convert.ToInt32(table.Rows[i]["TotalDelivery"]))
                        {
                            arrow1 = "<span style='color: #FF0000'>↓</span>";
                        }
                        else if (TotalDeliveryDic[TotalDelivery] == Convert.ToInt32(table.Rows[i]["TotalDelivery"]))
                        {
                            arrow1 = "<span style='color: #000000'>↓↑</span>";
                        }
                    }

                    if (LateDeliveryDic.ContainsKey(TotalDelivery))
                    {

                        if (LateDeliveryDic[TotalDelivery] < Convert.ToInt32(table.Rows[i]["LateDelivery"]))
                        {
                            arrow2 = "<span style='color: #0310FF'>↑</span>";
                        }
                        else if (LateDeliveryDic[TotalDelivery] > Convert.ToInt32(table.Rows[i]["LateDelivery"]))
                        {
                            arrow2 = "<span style='color: #FF0000'>↓</span>";
                        }
                        else if (LateDeliveryDic[TotalDelivery] == Convert.ToInt32(table.Rows[i]["LateDelivery"]))
                        {
                            arrow2 = "<span style='color: #000000'>↓↑</span>";
                        }
                    }

                    if (Avg_LateDeliveryDic.ContainsKey(TotalDelivery))
                    {

                        if (Avg_LateDeliveryDic[TotalDelivery] < Convert.ToInt32(table.Rows[i]["Avg_LateDelivery"]))
                        {
                            arrow3 = "<span style='color: #0310FF'>↑</span>";
                        }
                        else if (Avg_LateDeliveryDic[TotalDelivery] > Convert.ToInt32(table.Rows[i]["Avg_LateDelivery"]))
                        {
                            arrow3 = "<span style='color: #FF0000'>↓</span>";
                        }
                        else if (Avg_LateDeliveryDic[TotalDelivery] == Convert.ToInt32(table.Rows[i]["Avg_LateDelivery"]))
                        {
                            arrow3 = "<span style='color: #000000'>↓↑</span>";
                        }
                    }


                    if (FastDeliveryDic.ContainsKey(TotalDelivery))
                    {

                        if (FastDeliveryDic[TotalDelivery] < Convert.ToInt32(table.Rows[i]["FastDelivery"]))
                        {
                            arrow4 = "<span style='color: #0310FF'>↑</span>";
                        }
                        else if (FastDeliveryDic[TotalDelivery] > Convert.ToInt32(table.Rows[i]["FastDelivery"]))
                        {
                            arrow4 = "<span style='color: #FF0000'>↓</span>";
                        }
                        else if (FastDeliveryDic[TotalDelivery] == Convert.ToInt32(table.Rows[i]["FastDelivery"]))
                        {
                            arrow4 = "<span style='color: #000000'>↓↑</span>";
                        }
                    }

                    if (Avg_FastDeliveryDic.ContainsKey(TotalDelivery))
                    {

                        if (Avg_FastDeliveryDic[TotalDelivery] < Convert.ToInt32(table.Rows[i]["Avg_FastDelivery"]))
                        {
                            arrow5 = "<span style='color: #0310FF'>↑</span>";
                        }
                        else if (Avg_FastDeliveryDic[TotalDelivery] > Convert.ToInt32(table.Rows[i]["Avg_FastDelivery"]))
                        {
                            arrow5 = "<span style='color: #FF0000'>↓</span>";
                        }
                        else if (Avg_FastDeliveryDic[TotalDelivery] == Convert.ToInt32(table.Rows[i]["Avg_FastDelivery"]))
                        {
                            arrow5 = "<span style='color: #000000'>↓↑</span>";
                        }
                    }

                    deliverySummary = "<tr><td><span class='black'>" + table.Rows[i]["TotalDelivery"] + arrow1 + "</span></td><td><span class='green'>" + table.Rows[i]["LateDelivery"] + arrow2 + "</span></td><td><b class='pink'>" + table.Rows[i]["Avg_LateDelivery"] + "%" + arrow3 + "</b></td><td><b class='pink'>" + table.Rows[i]["FastDelivery"] + arrow4 + "</b></td><td><b class='pink'>" + table.Rows[i]["Avg_FastDelivery"] + "%" + arrow5 + "</b></td></tr>";
                }

            }
            return deliverySummary;
        }
    }



    [WebMethod]
    public static string LoadBKashCODOPS(string strId)
    {
        string Per = string.Empty;
        string startDate = string.Empty, endDate = string.Empty;

        if (strId == "Bkash100")
        {

            using (ControlPanelGateway ObjControlGateway = new ControlPanelGateway())
            {
                startDate = DateTime.Now.AddDays(-100).ToShortDateString();
                endDate = DateTime.Now.ToShortDateString();

                string Last100days = string.Empty, Last100days0 = string.Empty, Last100days1 = string.Empty,
                    Last100days2 = string.Empty, Last100days3 = string.Empty;

                int BkashTotal100Todate = 0, BkashDhaka100Todate = 0, CODTotal100Todate = 0, CODDhaka100Todate = 0,
                    CardTotal100Todate = 0, CardDhaka100Todate = 0, BkashOutside100Todate = 0, CODOutside100Todate = 0,
                    CardOutside100Todate = 0;

                DataTable dataTable = new DataTable();

                // Bkash
                dataTable = ObjControlGateway.GetTotalCountOfTransaction(startDate, endDate, "MPS", "");
                if (dataTable.Rows.Count > 0)
                {
                    BkashTotal100Todate = Convert.ToInt32(dataTable.Rows[0]["Total"]);
                }

                dataTable = ObjControlGateway.GetTotalCountOfTransaction(startDate, endDate, "MPS", "14");
                if (dataTable.Rows.Count > 0)
                {
                    BkashDhaka100Todate = Convert.ToInt32(dataTable.Rows[0]["Total"]);
                }

                // COD 
                dataTable = ObjControlGateway.GetTotalCountOfTransaction(startDate, endDate, "COD", "");
                if (dataTable.Rows.Count > 0)
                {
                    CODTotal100Todate = Convert.ToInt32(dataTable.Rows[0]["Total"]);
                }

                dataTable = ObjControlGateway.GetTotalCountOfTransaction(startDate, endDate, "COD", "14");
                if (dataTable.Rows.Count > 0)
                {
                    CODDhaka100Todate = Convert.ToInt32(dataTable.Rows[0]["Total"]);
                }

                // OPS
                dataTable = ObjControlGateway.GetTotalCountOfTransaction(startDate, endDate, "OPS", "");
                if (dataTable.Rows.Count > 0)
                {
                    CardTotal100Todate = Convert.ToInt32(dataTable.Rows[0]["Total"]);
                }

                dataTable = ObjControlGateway.GetTotalCountOfTransaction(startDate, endDate, "OPS", "14");
                if (dataTable.Rows.Count > 0)
                {
                    CardDhaka100Todate = Convert.ToInt32(dataTable.Rows[0]["Total"]);
                }

                BkashOutside100Todate = BkashTotal100Todate - BkashDhaka100Todate;
                CODOutside100Todate = CODTotal100Todate - CODDhaka100Todate;
                CardOutside100Todate = CardTotal100Todate - CardDhaka100Todate;

                Last100days0 = "<thead class='thin-border-bottom'><tr><th><i class='icon-caret-right blue'></i>Bkash</th><th><i class='icon-caret-right blue'></i>COD</th><th><i class='icon-caret-right blue'></i>OPS</th></tr></thead>";

                Last100days1 = "<tbody><tr><td><b class='black'> Inside Dhaka " + BkashDhaka100Todate + "</b></td><td><b class='green'> Inside Dhaka " + CODDhaka100Todate + "</b></td><td><b class='pink'> Inside Dhaka " + CardDhaka100Todate + "</b></td></tr></tbody>";
                Last100days2 = "<tbody><tr><td><b class='black'> Outside Dhaka " + BkashOutside100Todate + "</b></td><td><b class='green'> Outside Dhaka " + CODOutside100Todate + "</b></td><td><b class='pink'> Outside Dhaka " + CardOutside100Todate + "</b></td></tr></tbody>";
                Last100days3 = "<tbody><tr><td><b class='black'> Total " + BkashTotal100Todate + "</b></td><td><b class='green'> Total " + CODTotal100Todate + "</b></td><td><b class='pink'> Total " + CardTotal100Todate + "</b></td></tr></tbody>";

                Last100days = Last100days0 + Last100days1 + Last100days2 + Last100days3;

                return Last100days;
            }
        }

        else if (strId == "BkashMonth")
        {

            using (ControlPanelGateway ObjControlGateway = new ControlPanelGateway())
            {
                startDate = DateTime.Now.AddDays(-30).ToShortDateString();
                endDate = DateTime.Now.ToShortDateString();

                string StrMonth = string.Empty, StrMonth0 = string.Empty, StrMonth1 = string.Empty, StrMonth2 = string.Empty, StrMonth3 = string.Empty;

                int BkashOutsideMonthTodate = 0, BkashTotalMonthTodate = 0, BkashDhakaMonthTodate = 0,
                CODOutsideMonthTodate = 0, CODTotalMonthTodate = 0, CODDhakaMonthTodate = 0,
                CardOutsideMonthTodate = 0, CardTotalMonthTodate = 0, CardDhakaMonthTodate = 0;

                DataTable dataTable = new DataTable();

                // Bkash
                dataTable = ObjControlGateway.GetTotalCountOfTransaction(startDate, endDate, "MPS", "");
                if (dataTable.Rows.Count > 0)
                {
                    BkashTotalMonthTodate = Convert.ToInt32(dataTable.Rows[0]["Total"]);

                }

                dataTable = ObjControlGateway.GetTotalCountOfTransaction(startDate, endDate, "MPS", "14");
                if (dataTable.Rows.Count > 0)
                {
                    BkashDhakaMonthTodate = Convert.ToInt32(dataTable.Rows[0]["Total"]);

                }

                // COD 
                dataTable = ObjControlGateway.GetTotalCountOfTransaction(startDate, endDate, "COD", "");
                if (dataTable.Rows.Count > 0)
                {
                    CODTotalMonthTodate = Convert.ToInt32(dataTable.Rows[0]["Total"]);

                }

                dataTable = ObjControlGateway.GetTotalCountOfTransaction(startDate, endDate, "COD", "14");
                if (dataTable.Rows.Count > 0)
                {
                    CODDhakaMonthTodate = Convert.ToInt32(dataTable.Rows[0]["Total"]);
                }


                // OPS 
                dataTable = ObjControlGateway.GetTotalCountOfTransaction(startDate, endDate, "OPS", "");
                if (dataTable.Rows.Count > 0)
                {
                    CardTotalMonthTodate = Convert.ToInt32(dataTable.Rows[0]["Total"]);
                }

                dataTable = ObjControlGateway.GetTotalCountOfTransaction(startDate, endDate, "OPS", "14");
                if (dataTable.Rows.Count > 0)
                {
                    CardDhakaMonthTodate = Convert.ToInt32(dataTable.Rows[0]["Total"]);
                }

                BkashOutsideMonthTodate = BkashTotalMonthTodate - BkashDhakaMonthTodate;
                CODOutsideMonthTodate = CODTotalMonthTodate - CODDhakaMonthTodate;
                CardOutsideMonthTodate = CardTotalMonthTodate - CardDhakaMonthTodate;

                StrMonth0 = "<thead class='thin-border-bottom'><tr><th><i class='icon-caret-right blue'></i>Bkash</th><th><i class='icon-caret-right blue'></i>COD</th><th><i class='icon-caret-right blue'></i>OPS</th></tr></thead>";

                StrMonth1 = "<tbody><tr><td><b class='black'> Inside Dhaka " + BkashDhakaMonthTodate + "</b></td><td><b class='green'> Inside Dhaka " + CODDhakaMonthTodate + "</b></td><td><b class='pink'> Inside Dhaka " + CardDhakaMonthTodate + "</b></td></tr></tbody>";
                StrMonth2 = "<tbody><tr><td><b class='black'> Outside Dhaka " + BkashOutsideMonthTodate + "</b></td><td><b class='green'> Outside Dhaka " + CODOutsideMonthTodate + "</b></td><td><b class='pink'> Outside Dhaka " + CardOutsideMonthTodate + "</b></td></tr></tbody>";
                StrMonth3 = "<tbody><tr><td><b class='black'> Total " + BkashTotalMonthTodate + "</b></td><td><b class='green'> Total " + CODTotalMonthTodate + "</b></td><td><b class='pink'> Total " + CardTotalMonthTodate + "</b></td></tr></tbody>";

                StrMonth = StrMonth0 + StrMonth1 + StrMonth2 + StrMonth3;

                return StrMonth;
            }
        }

        else if (strId == "BkashLastweek")
        {

            using (ControlPanelGateway ObjControlGateway = new ControlPanelGateway())
            {
                string StrLastWeek = string.Empty, StrLastWeek0 = string.Empty, StrLastWeek1 = string.Empty, StrLastWeek2 = string.Empty, StrLastWeek3 = string.Empty;

                startDate = DateTime.Now.AddDays(-7).ToShortDateString();
                endDate = DateTime.Now.ToShortDateString();

                int BkashOutsideLastWeek = 0, BkashTotalLastWeek = 0, BkashDhakaLastWeek = 0,
                CODOutsideLastWeek = 0, CODTotalLastWeek = 0, CODDhakaLastWeek = 0,
                CardOutsideLastWeek = 0, CardTotalLastWeek = 0, CardDhakaLastWeek = 0;

                DataTable dataTable = new DataTable();

                // Bkash LastWeek
                dataTable = ObjControlGateway.GetTotalCountOfTransaction(startDate, endDate, "MPS", "");
                if (dataTable.Rows.Count > 0)
                {
                    BkashTotalLastWeek = Convert.ToInt32(dataTable.Rows[0]["Total"]);
                }

                dataTable = ObjControlGateway.GetTotalCountOfTransaction(startDate, endDate, "MPS", "14");
                if (dataTable.Rows.Count > 0)
                {
                    BkashDhakaLastWeek = Convert.ToInt32(dataTable.Rows[0]["Total"]);

                }

                // COD LastWeek
                dataTable = ObjControlGateway.GetTotalCountOfTransaction(startDate, endDate, "COD", "");
                if (dataTable.Rows.Count > 0)
                {
                    CODTotalLastWeek = Convert.ToInt32(dataTable.Rows[0]["Total"]);

                }

                dataTable = ObjControlGateway.GetTotalCountOfTransaction(startDate, endDate, "COD", "14");
                if (dataTable.Rows.Count > 0)
                {
                    CODDhakaLastWeek = Convert.ToInt32(dataTable.Rows[0]["Total"]);

                }


                // OPS LastWeek
                dataTable = ObjControlGateway.GetTotalCountOfTransaction(startDate, endDate, "OPS", "");
                if (dataTable.Rows.Count > 0)
                {
                    CardTotalLastWeek = Convert.ToInt32(dataTable.Rows[0]["Total"]);

                }

                dataTable = ObjControlGateway.GetTotalCountOfTransaction(startDate, endDate, "OPS", "14");
                if (dataTable.Rows.Count > 0)
                {
                    CardDhakaLastWeek = Convert.ToInt32(dataTable.Rows[0]["Total"]);
                }


                BkashOutsideLastWeek = BkashTotalLastWeek - BkashDhakaLastWeek;
                CODOutsideLastWeek = CODTotalLastWeek - CODDhakaLastWeek;
                CardOutsideLastWeek = CardTotalLastWeek - CardDhakaLastWeek;

                StrLastWeek0 = "<thead class='thin-border-bottom'><tr><th><i class='icon-caret-right blue'></i>Bkash</th><th><i class='icon-caret-right blue'></i>COD</th><th><i class='icon-caret-right blue'></i>OPS</th></tr></thead>";

                StrLastWeek1 = "<tbody><tr><td><b class='black'> Inside Dhaka " + BkashDhakaLastWeek + "</b></td><td><b class='green'> Inside Dhaka " + CODDhakaLastWeek + "</b></td><td><b class='pink'> Inside Dhaka " + CardDhakaLastWeek + "</b></td></tr></tbody>";
                StrLastWeek2 = "<tbody><tr><td><b class='black'> Outside Dhaka " + BkashOutsideLastWeek + "</b></td><td><b class='green'> Outside Dhaka " + CODOutsideLastWeek + "</b></td><td><b class='pink'> Outside Dhaka " + CardOutsideLastWeek + "</b></td></tr></tbody>";
                StrLastWeek3 = "<tbody><tr><td><b class='black'> Total " + BkashTotalLastWeek + "</b></td><td><b class='green'> Total " + CODTotalLastWeek + "</b></td><td><b class='pink'> Total " + CardTotalLastWeek + "</b></td></tr></tbody>";

                StrLastWeek = StrLastWeek0 + StrLastWeek1 + StrLastWeek2 + StrLastWeek3;

                return StrLastWeek;
            }
        }

        else if (strId == "BkashToday")
        {
            using (ControlPanelGateway ObjControlGateway = new ControlPanelGateway())
            {
                string StrTodayy = string.Empty, StrToday0 = string.Empty, StrToday1 = string.Empty, StrToday2 = string.Empty, StrToday3 = string.Empty;

                startDate = DateTime.Now.ToShortDateString();
                endDate = DateTime.Now.AddDays(1).ToShortDateString();

                int BkashOutside = 0, BkashTotal = 0, BkashDhaka = 0,
                CODOutside = 0, CODTotal = 0, CODDhaka = 0,
                CardOutside = 0, CardTotal = 0, CardDhaka = 0;

                DataTable dataTable = new DataTable();

                // Bkash Today
                dataTable = ObjControlGateway.GetTotalCountOfTransaction(startDate, endDate, "MPS", "");
                if (dataTable.Rows.Count > 0)
                {
                    BkashTotal = Convert.ToInt32(dataTable.Rows[0]["Total"]);
                }

                dataTable = ObjControlGateway.GetTotalCountOfTransaction(startDate, endDate, "MPS", "14");
                if (dataTable.Rows.Count > 0)
                {
                    BkashDhaka = Convert.ToInt32(dataTable.Rows[0]["Total"]);
                }

                // COD Today
                dataTable = ObjControlGateway.GetTotalCountOfTransaction(startDate, endDate, "COD", "");
                if (dataTable.Rows.Count > 0)
                {
                    CODTotal = Convert.ToInt32(dataTable.Rows[0]["Total"]);
                }

                dataTable = ObjControlGateway.GetTotalCountOfTransaction(startDate, endDate, "COD", "14");
                if (dataTable.Rows.Count > 0)
                {
                    CODDhaka = Convert.ToInt32(dataTable.Rows[0]["Total"]);
                }


                // OPS Today
                dataTable = ObjControlGateway.GetTotalCountOfTransaction(startDate, endDate, "OPS", "");
                if (dataTable.Rows.Count > 0)
                {
                    CardTotal = Convert.ToInt32(dataTable.Rows[0]["Total"]);
                }

                dataTable = ObjControlGateway.GetTotalCountOfTransaction(startDate, endDate, "OPS", "14");
                if (dataTable.Rows.Count > 0)
                {
                    CardDhaka = Convert.ToInt32(dataTable.Rows[0]["Total"]);
                }


                BkashOutside = BkashTotal - BkashDhaka;
                CODOutside = CODTotal - CODDhaka;
                CardOutside = CardTotal - CardDhaka;

                StrToday0 = "<thead class='thin-border-bottom'><tr><th><i class='icon-caret-right blue'></i>Bkash</th><th><i class='icon-caret-right blue'></i>COD</th><th><i class='icon-caret-right blue'></i>OPS</th></tr></thead>";


                StrToday1 = "<tbody><tr><td><b class='black'> Inside Dhaka " + BkashDhaka + "</b></td><td><b class='green'> Inside Dhaka " + CODDhaka + "</b></td><td><b class='pink'> Inside Dhaka " + CardDhaka + "</b></td></tr></tbody>";
                StrToday2 = "<tbody><tr><td><b class='black'> Outside Dhaka " + BkashOutside + "</b></td><td><b class='green'> Outside Dhaka " + CODOutside + "</b></td><td><b class='pink'> Outside Dhaka " + CardOutside + "</b></td></tr></tbody>";
                StrToday3 = "<tbody><tr><td><b class='black'> Total " + BkashTotal + "</b></td><td><b class='green'> Total " + CODTotal + "</b></td><td><b class='pink'> Total " + CardTotal + "</b></td></tr></tbody>";

                StrTodayy = StrToday0 + StrToday1 + StrToday2 + StrToday3;

                return StrTodayy;
            }
        }


        else if (strId == "BkashToday_First")
        {
            using (ControlPanelGateway ObjControlGateway = new ControlPanelGateway())
            {
                string StrTodayy_First = string.Empty, StrToday0 = string.Empty, StrToday1 = string.Empty, StrToday2 = string.Empty, StrToday3 = string.Empty;

                startDate = DateTime.Now.ToShortDateString();
                endDate = DateTime.Now.AddDays(1).ToShortDateString();

                int BkashOutside = 0, BkashTotal = 0, BkashDhaka = 0,
                CODOutside = 0, CODTotal = 0, CODDhaka = 0,
                CardOutside = 0, CardTotal = 0, CardDhaka = 0;

                DataTable dataTable = new DataTable();

                // Bkash Today
                dataTable = ObjControlGateway.GetTotalCountOfTransaction(startDate, endDate, "MPS", "");
                if (dataTable.Rows.Count > 0)
                {
                    BkashTotal = Convert.ToInt32(dataTable.Rows[0]["Total"]);
                }

                dataTable = ObjControlGateway.GetTotalCountOfTransaction(startDate, endDate, "MPS", "14");
                if (dataTable.Rows.Count > 0)
                {
                    BkashDhaka = Convert.ToInt32(dataTable.Rows[0]["Total"]);
                }

                // COD Today
                dataTable = ObjControlGateway.GetTotalCountOfTransaction(startDate, endDate, "COD", "");
                if (dataTable.Rows.Count > 0)
                {
                    CODTotal = Convert.ToInt32(dataTable.Rows[0]["Total"]);
                }

                dataTable = ObjControlGateway.GetTotalCountOfTransaction(startDate, endDate, "COD", "14");
                if (dataTable.Rows.Count > 0)
                {
                    CODDhaka = Convert.ToInt32(dataTable.Rows[0]["Total"]);
                }


                // OPS Today
                dataTable = ObjControlGateway.GetTotalCountOfTransaction(startDate, endDate, "OPS", "");
                if (dataTable.Rows.Count > 0)
                {
                    CardTotal = Convert.ToInt32(dataTable.Rows[0]["Total"]);
                }

                dataTable = ObjControlGateway.GetTotalCountOfTransaction(startDate, endDate, "OPS", "14");
                if (dataTable.Rows.Count > 0)
                {
                    CardDhaka = Convert.ToInt32(dataTable.Rows[0]["Total"]);
                }


                BkashOutside = BkashTotal - BkashDhaka;
                CODOutside = CODTotal - CODDhaka;
                CardOutside = CardTotal - CardDhaka;

                StrToday0 = "<thead class='thin-border-bottom'><tr><th><i class='icon-caret-right blue'></i>Bkash</th><th><i class='icon-caret-right blue'></i>COD</th><th><i class='icon-caret-right blue'></i>OPS</th></tr></thead>";


                StrToday1 = "<tbody><tr><td><b class='black'> Inside Dhaka " + BkashDhaka + "</b></td><td><b class='green'> Inside Dhaka " + CODDhaka + "</b></td><td><b class='pink'> Inside Dhaka " + CardDhaka + "</b></td></tr></tbody>";
                StrToday2 = "<tbody><tr><td><b class='black'> Outside Dhaka " + BkashOutside + "</b></td><td><b class='green'> Outside Dhaka " + CODOutside + "</b></td><td><b class='pink'> Outside Dhaka " + CardOutside + "</b></td></tr></tbody>";
                StrToday3 = "<tbody><tr><td><b class='black'> Total " + BkashTotal + "</b></td><td><b class='green'> Total " + CODTotal + "</b></td><td><b class='pink'> Total " + CardTotal + "</b></td></tr></tbody>";

                StrTodayy_First = StrToday0 + StrToday1 + StrToday2 + StrToday3;

                return StrTodayy_First;
            }
        }
        
        else if (strId == "BkashYesterday")
        {
            using (ControlPanelGateway ObjControlGateway = new ControlPanelGateway())
            {
                string StrYesterday = string.Empty, StrYesterday0 = string.Empty, StrYesterday1 = string.Empty, StrYesterday2 = string.Empty, StrYesterday3 = string.Empty;

                startDate = DateTime.Now.AddDays(-1).ToShortDateString();
                endDate = DateTime.Now.ToShortDateString();

                int BkashOutsideYesterday = 0, BkashTotalYesterday = 0, BkashDhakaYesterday = 0,
                CODOutsideYesterday = 0, CODTotalYesterday = 0, CODDhakaYesterday = 0,
                CardOutsideYesterday = 0, CardTotalYesterday = 0, CardDhakaYesterday = 0;

                DataTable dataTable = new DataTable();

                // Bkash Yesterday
                dataTable = ObjControlGateway.GetTotalCountOfTransaction(startDate, endDate, "MPS", "");
                if (dataTable.Rows.Count > 0)
                {
                    BkashTotalYesterday = Convert.ToInt32(dataTable.Rows[0]["Total"]);
                }

                dataTable = ObjControlGateway.GetTotalCountOfTransaction(startDate, endDate, "MPS", "14");
                if (dataTable.Rows.Count > 0)
                {
                    BkashDhakaYesterday = Convert.ToInt32(dataTable.Rows[0]["Total"]);
                }

                // COD Yesterday
                dataTable = ObjControlGateway.GetTotalCountOfTransaction(startDate, endDate, "COD", "");
                if (dataTable.Rows.Count > 0)
                {
                    CODTotalYesterday = Convert.ToInt32(dataTable.Rows[0]["Total"]);
                }

                dataTable = ObjControlGateway.GetTotalCountOfTransaction(startDate, endDate, "COD", "14");
                if (dataTable.Rows.Count > 0)
                {
                    CODDhakaYesterday = Convert.ToInt32(dataTable.Rows[0]["Total"]);
                }


                // OPS Yesterday
                dataTable = ObjControlGateway.GetTotalCountOfTransaction(startDate, endDate, "OPS", "");
                if (dataTable.Rows.Count > 0)
                {
                    CardTotalYesterday = Convert.ToInt32(dataTable.Rows[0]["Total"]);

                }

                dataTable = ObjControlGateway.GetTotalCountOfTransaction(startDate, endDate, "OPS", "14");
                if (dataTable.Rows.Count > 0)
                {
                    CardDhakaYesterday = Convert.ToInt32(dataTable.Rows[0]["Total"]);
                }


                BkashOutsideYesterday = BkashTotalYesterday - BkashDhakaYesterday;
                CODOutsideYesterday = CODTotalYesterday - CODDhakaYesterday;
                CardOutsideYesterday = CardTotalYesterday - CardDhakaYesterday;

                StrYesterday0 = "<thead class='thin-border-bottom'><tr><th><i class='icon-caret-right blue'></i>Bkash</th><th><i class='icon-caret-right blue'></i>COD</th><th><i class='icon-caret-right blue'></i>OPS</th></tr></thead>";

                StrYesterday1 = "<tbody><tr><td><b class='black'> Inside Dhaka " + BkashDhakaYesterday + "</b></td><td><b class='green'> Inside Dhaka " + CODDhakaYesterday + "</b></td><td><b class='pink'> Inside Dhaka " + CardDhakaYesterday + "</b></td></tr></tbody>";
                StrYesterday2 = "<tbody><tr><td><b class='black'> Outside Dhaka " + BkashOutsideYesterday + "</b></td><td><b class='green'> Outside Dhaka " + CODOutsideYesterday + "</b></td><td><b class='pink'> Outside Dhaka " + CardOutsideYesterday + "</b></td></tr></tbody>";
                StrYesterday3 = "<tbody><tr><td><b class='black'> Total " + BkashTotalYesterday + "</b></td><td><b class='green'> Total " + CODTotalYesterday + "</b></td><td><b class='pink'> Total " + CardTotalYesterday + "</b></td></tr></tbody>";

                StrYesterday = StrYesterday0 + StrYesterday1 + StrYesterday2 + StrYesterday3;

                return StrYesterday;
            }

        }


        else if (strId == "BkashLast3days")
        {
            using (ControlPanelGateway ObjControlGateway = new ControlPanelGateway())
            {
                startDate = DateTime.Now.AddDays(-3).ToShortDateString();
                endDate = DateTime.Now.ToShortDateString();

                string StrLast3Days = string.Empty, StrLast3Days0 = string.Empty, StrLast3Days1 = string.Empty, StrLast3Days2 = string.Empty, StrLast3Days3 = string.Empty;

                int BkashOutsideLast3Days = 0, BkashTotalLast3Days = 0, BkashDhakaLast3Days = 0,
                CODOutsideLast3Days = 0, CODTotalLast3Days = 0, CODDhakaLast3Days = 0,
                CardOutsideLast3Days = 0, CardTotalLast3Days = 0, CardDhakaLast3Days = 0;

                DataTable dataTable = new DataTable();

                // Bkash Last3Days
                dataTable = ObjControlGateway.GetTotalCountOfTransaction(startDate, endDate, "MPS", "");
                if (dataTable.Rows.Count > 0)
                {
                    BkashTotalLast3Days = Convert.ToInt32(dataTable.Rows[0]["Total"]);
                }

                dataTable = ObjControlGateway.GetTotalCountOfTransaction(startDate, endDate, "MPS", "14");
                if (dataTable.Rows.Count > 0)
                {
                    BkashDhakaLast3Days = Convert.ToInt32(dataTable.Rows[0]["Total"]);
                }

                // COD Last3Days
                dataTable = ObjControlGateway.GetTotalCountOfTransaction(startDate, endDate, "COD", "");
                if (dataTable.Rows.Count > 0)
                {
                    CODTotalLast3Days = Convert.ToInt32(dataTable.Rows[0]["Total"]);
                }

                dataTable = ObjControlGateway.GetTotalCountOfTransaction(startDate, endDate, "COD", "14");
                if (dataTable.Rows.Count > 0)
                {
                    CODDhakaLast3Days = Convert.ToInt32(dataTable.Rows[0]["Total"]);

                }


                // OPS Last3Days
                dataTable = ObjControlGateway.GetTotalCountOfTransaction(startDate, endDate, "OPS", "");
                if (dataTable.Rows.Count > 0)
                {
                    CardTotalLast3Days = Convert.ToInt32(dataTable.Rows[0]["Total"]);

                }

                dataTable = ObjControlGateway.GetTotalCountOfTransaction(startDate, endDate, "OPS", "14");
                if (dataTable.Rows.Count > 0)
                {
                    CardDhakaLast3Days = Convert.ToInt32(dataTable.Rows[0]["Total"]);
                }


                BkashOutsideLast3Days = BkashTotalLast3Days - BkashDhakaLast3Days;
                CODOutsideLast3Days = CODTotalLast3Days - CODDhakaLast3Days;
                CardOutsideLast3Days = CardTotalLast3Days - CardDhakaLast3Days;

                StrLast3Days0 = "<thead class='thin-border-bottom'><tr><th><i class='icon-caret-right blue'></i>Bkash</th><th><i class='icon-caret-right blue'></i>COD</th><th><i class='icon-caret-right blue'></i>OPS</th></tr></thead>";

                StrLast3Days1 = "<tbody><tr><td><b class='black'> Inside Dhaka " + BkashDhakaLast3Days + "</b></td><td><b class='green'> Inside Dhaka " + CODDhakaLast3Days + "</b></td><td><b class='pink'> Inside Dhaka " + CardDhakaLast3Days + "</b></td></tr></tbody>";
                StrLast3Days2 = "<tbody><tr><td><b class='black'> Outside Dhaka " + BkashOutsideLast3Days + "</b></td><td><b class='green'> Outside Dhaka " + CODOutsideLast3Days + "</b></td><td><b class='pink'> Outside Dhaka " + CardOutsideLast3Days + "</b></td></tr></tbody>";
                StrLast3Days3 = "<tbody><tr><td><b class='black'> Total " + BkashTotalLast3Days + "</b></td><td><b class='green'> Total " + CODTotalLast3Days + "</b></td><td><b class='pink'> Total " + CardTotalLast3Days + "</b></td></tr></tbody>";

                StrLast3Days = StrLast3Days0 + StrLast3Days1 + StrLast3Days2 + StrLast3Days3;

                return StrLast3Days;
            }
        }

        return Per;
    }



    [WebMethod]
    public static string GetPerformingMerchantPopUp(string CompanyId, string startDate, string endDate, string Check)
    {

        StringBuilder data = new StringBuilder();
        DataTable dataTable;
        data.Append("<table class='table table-hover'>");
        data.Append("<thead>");
        data.Append("<tr>");
        data.Append("<th style='width: 83px;'>SNo.</th><th>Booking Code</th><th>POD Number</th><th>Deal Title</th><th>Quantity</th><th>Price</th><th>Company Name</th><th>Order From</th><th>Courier</th><th>Order Date</th><th>Comments</th><th>Commented By</th><th>Image</th><th>Sold Out</th>");
        data.Append("</tr></thead>");

        data.Append("<tbody>");

        using (ControlPanelGateway objControlPanelGateway = new ControlPanelGateway())
        {
            if (Check == "00")
            {
                dataTable = objControlPanelGateway.GetGetPerformingMerchantClick(CompanyId, startDate, endDate);
            }

            else if (Check == "000")
            {
                dataTable = objControlPanelGateway.GetGetPerformingCategoryClick(CompanyId, startDate, endDate);
            }
            else
            {
                dataTable = objControlPanelGateway.GetGetPerformingSubCategoryClick(CompanyId, startDate, endDate);
            }

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

                data.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{3}</td><td>{4}(<a href='http://www.ajkerdeal.com/Product/{2}/{4}' target=_blank>{2}</a>)</td><td>{12}</td><td>{11}</td><td>{5}</td><td>{6}</td><td>{7}</td><td>{8}</td><td style='font-family: 'Segoe', 'Segoe UI', 'DejaVu Sans', 'Trebuchet MS', 'Verdana, sans-serif';'>{9}</td><td>{13}</td><td>{10}</td><td>{14}</td></tr>",
                count++, "<span data-toggle='modal' data-target='#GetDeal' onclick='GetPerformingMerchantgCategoryDetails(this.id);' id='" + row["CouponId"] + "'><b style='color:#DEB887;cursor:pointer;'>" + row["CouponId"] + "</b></span>",
                row["DealId"], row["PODnumber"], row["DealTitle"], row["CompanyName"], row["OrderFrom"],
                row["Courier"], row["PostedOn"], row["Comments"],
                "<img src='http://www.ajkerdeal.com/images/Deals/" + row["FolderName"] + "/dealdetails1.jpg' width='60px'>", row["CouponPrice"], row["CouponQtn"], row["CommentedBy"],
                "<span onclick='SoldOutProduct(" + row["DealId"] + "," + userId + ");'><b style='color:#DEB887;cursor:pointer;'>" + IsSoldOut + "</b></span>");
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
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static List<PieChart> PieChartAnalysis()
    {
        List<PieChart> PieChartList = new List<PieChart>();
        DataTable table = GetTable();
        PieChartList = (from DataRow dr in table.Rows
                          select new PieChart()
                          {
                              Name = Convert.ToString(dr["name"]),
                              Value = Convert.ToInt32(dr["value"])
                          }).ToList();


        return PieChartList;

    }

    private static DataTable GetTable()
    {
        int CancelAjkerDealReports = 0, CancelMerchantReports = 0, CRM_ProcessedModel2 = 0, After_CRM_Processed =0;
        string NewOrderReports = "", FollowUpReports = "", CancelAjkerDealReports1 = "", CancelAjkerDealReports2 ="",
            CancelRepertedOrder = "", CancelMerchantReports1="",
            CancelMerchantReports2 = "", CancelMerchantReports3 = "", CancelMerchantReports4 = "", COD_OutSideDhaka ="",
            CRM_Processed1 = "", CRM_Processed2 = "", CRM_ProcessedModel1 = "", 
            After_CRM_Processed1 = "", After_CRM_Processed2 = "", After_CRM_Processed3 = "", After_CRM_Processed4="",
            After_CRM_Processed5 = "", After_CRM_Processed6 = "", After_CRM_Processed7 = "", After_CRM_Processed8="",
            After_CRM_Processed9 = "", After_CRM_Processed10 = "", After_CRM_Processed11 = "", After_CRM_Processed12="",
            After_CRM_Processed13 = "", After_CRM_Processed14 = "", After_CRM_Processed15 = "", After_CRM_Processed16="";

        NewOrderReports = GetReportString("0").ToString();
        FollowUpReports = GetReportString("2").ToString();
        CancelAjkerDealReports1 = GetReportString("4").ToString();
        CancelAjkerDealReports2 = GetReportString("5").ToString();
        CancelRepertedOrder = GetReportString("6").ToString();
        CancelAjkerDealReports = Convert.ToInt32(CancelAjkerDealReports1)
                               + Convert.ToInt32(CancelAjkerDealReports2);

        CancelMerchantReports1 = GetReportString("18").ToString();
        CancelMerchantReports2 = GetReportString("19").ToString();
        CancelMerchantReports3 = GetReportString("20").ToString();
        CancelMerchantReports4 = GetReportString("28").ToString();
        CancelMerchantReports = Convert.ToInt32(CancelMerchantReports1)
                                + Convert.ToInt32(CancelMerchantReports2)
                                + Convert.ToInt32(CancelMerchantReports3)
                                + Convert.ToInt32(CancelMerchantReports4);

        COD_OutSideDhaka = GetReportString("8").ToString();
        CRM_Processed1 = GetReportString("3").ToString();
        CRM_Processed2 = GetReportString("33").ToString();
        CRM_ProcessedModel1 = GetReportString("7").ToString();
        CRM_ProcessedModel2 = Convert.ToInt32(CRM_Processed1)
                        + Convert.ToInt32(CRM_Processed2);

        After_CRM_Processed1 = GetReportString("1").ToString();
        After_CRM_Processed2 = GetReportString("11").ToString();
        After_CRM_Processed3 = GetReportString("111").ToString();
        After_CRM_Processed4 = GetReportString("9").ToString();
        After_CRM_Processed5 = GetReportString("10").ToString();
        After_CRM_Processed6 = GetReportString("17").ToString();
        After_CRM_Processed7 = GetReportString("24").ToString();
        After_CRM_Processed8 = GetReportString("13").ToString();
        After_CRM_Processed9 = GetReportString("15").ToString();
        After_CRM_Processed10 = GetReportString("16").ToString();
        After_CRM_Processed11 = GetReportString("23").ToString();
        After_CRM_Processed12 = GetReportString("109").ToString();
        After_CRM_Processed13 = GetReportString("30").ToString();
        After_CRM_Processed14 = GetReportString("31").ToString();
        After_CRM_Processed15 = GetReportString("34").ToString();
        After_CRM_Processed16 = GetReportString("12").ToString();



        After_CRM_Processed = Convert.ToInt32(After_CRM_Processed1)
                                + Convert.ToInt32(After_CRM_Processed2)
                                + Convert.ToInt32(After_CRM_Processed3)
                                + Convert.ToInt32(After_CRM_Processed4)
                                + Convert.ToInt32(After_CRM_Processed5)
                                + Convert.ToInt32(After_CRM_Processed6)
                                + Convert.ToInt32(After_CRM_Processed7);


        //Total_CRM_Order_Processing = After_CRM_Processed + Convert.ToInt32(CRM_ProcessedModel1)
        //                            + CRM_ProcessedModel2 + Convert.ToInt32(COD_OutSideDhaka)
        //                            + CancelMerchantReports + CancelAjkerDealReports + Convert.ToInt32(CancelRepertedOrder)
        //                            + Convert.ToInt32(FollowUpReports) + Convert.ToInt32(NewOrderReports);

        DataTable table = new DataTable("PieChartAnalysis");
        table.Columns.Add("name", typeof(string));
        table.Columns.Add("value", typeof(int));

        // Here we add five DataRows.
        table.Rows.Add("Merchant Cancel", CancelMerchantReports);
        table.Rows.Add("New Order", NewOrderReports);
        table.Rows.Add("COD OutSide Dhaka", COD_OutSideDhaka);

        table.Rows.Add("Follow Up", FollowUpReports);
        table.Rows.Add("AjkerDeal Cancel", CancelAjkerDealReports);
        table.Rows.Add("Repeated Order", CancelRepertedOrder);

        table.Rows.Add("Follow Up", FollowUpReports);
        table.Rows.Add("AjkerDeal Cancel", CancelAjkerDealReports);
        table.Rows.Add("Repeated Order", CancelRepertedOrder);

        table.Rows.Add("CRM Processed Model1", CRM_ProcessedModel1);
        table.Rows.Add("CRM Processed Model2", CRM_ProcessedModel2);
        table.Rows.Add("After CRM Processed", After_CRM_Processed);

        return table;
    }

    private static string GetReportString(string IsDone)
    {
        String Today = DateTime.Now.ToShortDateString();
        string Count = "0";
        string strBasedOn = "PostedOn";
        string GetReportToDate = DateTime.Now.Date.AddDays(1).ToShortDateString();

        try
        {
            using (AdminBookingReportGateway ObjAdminBookingReportGateway = new AdminBookingReportGateway())
            {
                DataTable dataTable = ObjAdminBookingReportGateway.LoadBookingReportsStatusCountWithDateRange(Today, GetReportToDate, IsDone, strBasedOn);
                Count = Convert.ToString(dataTable.Rows[0]["Total"]);
            }
        }
        catch (Exception ex)
        {
            throw new Exception("No data found ", ex);
        }
        return Count;
    }


    public class PieChart
    {
        public string Name { get; set; }
        public int Value { get; set; }

    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public static object[] GetChartData()
    {
        string MonthName = DateTime.Now.Month.ToString();
        string YearName = DateTime.Now.Year.ToString();
        ControlPanelGateway ObjControlPanelGateway = new ControlPanelGateway();
        DataTable table = ObjControlPanelGateway.SaleStatsMethod(MonthName, YearName);
        List<SaleStatsData> Data = new List<SaleStatsData>();



        List<SaleStatsData> SaleStatsDataList = new List<SaleStatsData>();
        SaleStatsDataList = (from DataRow dr in table.Rows
                             select new SaleStatsData()
                             {
                                 day = Convert.ToInt32(dr["Day"]),
                                 totalOrder = Convert.ToInt32(dr["TotalOrder"]),
                                 confirmationDate = Convert.ToInt32(dr["TotalConfirmed"]),
                                 orderingDate = Convert.ToInt32(dr["CommentedOn"]),
                                 courier = Convert.ToInt32(dr["Courier"]),
                             }).ToList();



        // Data = SaleStatsDataList.ToList();

        var chartData = new object[SaleStatsDataList.Count + 1];
        chartData[0] = new object[]{
                "Day",
                "Total Order",
                "Courier",
                "By Confirmation Date",
                "By Ordering Date"

            };
        int j = 0;
        foreach (var i in SaleStatsDataList)
        {
            j++;
            chartData[j] = new object[] { i.day, i.totalOrder, i.courier, i.confirmationDate, i.orderingDate };
        }
        return chartData;
    }

    public class SaleStatsData
    {
        public int day { get; set; }
        public int totalOrder { get; set; }
        public int confirmationDate { get; set; }
        public int orderingDate { get; set; }
        public int courier { get; set; }
    }

    private void graphChart()
    {
        NewOrderReports = GetReport("0").ToString();
        FollowUpReports = GetReport("2").ToString();
        CancelAjkerDealReports1 = GetReport("4").ToString();
        CancelAjkerDealReports2 = GetReport("5").ToString();
        CancelRepertedOrder = GetReport("6").ToString();
        CancelAjkerDealReports = Convert.ToInt32(CancelAjkerDealReports1)
                               + Convert.ToInt32(CancelAjkerDealReports2);

        CancelMerchantReports1 = GetReport("18").ToString();
        CancelMerchantReports2 = GetReport("19").ToString();
        CancelMerchantReports3 = GetReport("20").ToString();
        CancelMerchantReports4 = GetReport("28").ToString();
        CancelMerchantReports = Convert.ToInt32(CancelMerchantReports1)
                                + Convert.ToInt32(CancelMerchantReports2)
                                + Convert.ToInt32(CancelMerchantReports3)
                                + Convert.ToInt32(CancelMerchantReports4);

        COD_OutSideDhaka = GetReport("8").ToString();
        CRM_Processed1 = GetReport("3").ToString();
        CRM_Processed2 = GetReport("33").ToString();
        CRM_ProcessedModel1 = GetReport("7").ToString();
        CRM_ProcessedModel2 = Convert.ToInt32(CRM_Processed1)
                        + Convert.ToInt32(CRM_Processed2);

        After_CRM_Processed1 = GetReport("1").ToString();
        After_CRM_Processed2 = GetReport("11").ToString();
        After_CRM_Processed3 = GetReport("111").ToString();
        After_CRM_Processed4 = GetReport("9").ToString();
        After_CRM_Processed5 = GetReport("10").ToString();
        After_CRM_Processed6 = GetReport("17").ToString();
        After_CRM_Processed7 = GetReport("24").ToString();
        After_CRM_Processed8 = GetReport("13").ToString();
        After_CRM_Processed9 = GetReport("15").ToString();
        After_CRM_Processed10 = GetReport("16").ToString();
        After_CRM_Processed11 = GetReport("23").ToString();
        After_CRM_Processed12 = GetReport("109").ToString();
        After_CRM_Processed13 = GetReport("30").ToString();
        After_CRM_Processed14 = GetReport("31").ToString();
        After_CRM_Processed15 = GetReport("34").ToString();
        After_CRM_Processed16 = GetReport("12").ToString();



        After_CRM_Processed = Convert.ToInt32(After_CRM_Processed1)
                                + Convert.ToInt32(After_CRM_Processed2)
                                + Convert.ToInt32(After_CRM_Processed3)
                                + Convert.ToInt32(After_CRM_Processed4)
                                + Convert.ToInt32(After_CRM_Processed5)
                                + Convert.ToInt32(After_CRM_Processed6)
                                + Convert.ToInt32(After_CRM_Processed7);


        Total_CRM_Order_Processing = After_CRM_Processed + Convert.ToInt32(CRM_ProcessedModel1)
                                    + CRM_ProcessedModel2 + Convert.ToInt32(COD_OutSideDhaka)
                                    + CancelMerchantReports + CancelAjkerDealReports + Convert.ToInt32(CancelRepertedOrder)
                                    + Convert.ToInt32(FollowUpReports) + Convert.ToInt32(NewOrderReports);


        StrOrderProcessing = "<div class='col-sm-6'>";
        StrOrderProcessing += "<div class='widget-box transparent'>";
        StrOrderProcessing += "<div class='widget-header widget-header-flat'><h4 class='lighter'>Pie Chart</h4><div class='widget-toolbar'><a href='#' data-action='collapse'><i class='icon-chevron-up'></i></a></div></div>";
        StrOrderProcessing += "<div class='widget-header widget-header-flat widget-header-small'>";
        StrOrderProcessing += "<h5>";
        StrOrderProcessing += "<i class='icon-bar-chart'></i>";
        StrOrderProcessing += "</h5>";
        StrOrderProcessing += "</div>";
        StrOrderProcessing += "<div class='widget-body'>";
        StrOrderProcessing += "<div class='widget-main'>";
        StrOrderProcessing += "<div id='piechart-status'>";
        StrOrderProcessing += "</div>";
        StrOrderProcessing += "</div>";
        StrOrderProcessing += "</div>";
        StrOrderProcessing += "</div>";
        StrOrderProcessing += "</div>";
    }

    private void OrderStats()
    {
        using (ControlPanelGateway ObjControlPanelGateway = new ControlPanelGateway())
        {
            DataTable dataTable1 = ObjControlPanelGateway.SaleStatsMethod(MonthName, YearName);
            if (dataTable1.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable1.Rows.Count; i++)
                {
                    SaleStatsString += "[" + (i + 1) + "," + Convert.ToInt32(dataTable1.Rows[i]["TotalOrder"]) + "," + Convert.ToInt32(dataTable1.Rows[i]["Courier"]) + "," + Convert.ToInt32(dataTable1.Rows[i]["TotalConfirmed"]) + "," + Convert.ToInt32(dataTable1.Rows[i]["CommentedOn"]) + "],";
                }
            }
        }

        //SaleStats = "<div class='col-sm-6'><div class='widget-box transparent'><div class='widget-header widget-header-flat'><h4 class='lighter'><i class='icon-signal'></i>Order Stats</h4><div class='widget-toolbar'><a href='#' data-action='collapse'><i class='icon-chevron-up'></i></a></div></div><div class='widget-body'><div class='widget-main padding-4'><div id='Sales-Star'></div></div></div></div></div>";

    }

}