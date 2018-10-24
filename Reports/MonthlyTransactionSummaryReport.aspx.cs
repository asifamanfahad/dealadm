using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_MonthlyTransactionSummaryReport : System.Web.UI.Page
{
    public static string IsDone = string.Empty, Month = string.Empty, Year = string.Empty, SummaryName = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AD_ADMIN_TYPE"] == null)
        {
            Response.Redirect("../Default.aspx");
            Response.End();
        }
        else
        {

            int AdminType = Convert.ToInt32(Session["AD_ADMIN_TYPE"]);
        }

        IsDone = Request.QueryString["IsDone"];
        Month = Request.QueryString["Month"];
        Year = Request.QueryString["Year"];
        //SummaryName = Request.QueryString["Summary"];
    }

    [WebMethod]
    public static List<Summary> GetSummary()
    {
        using (MonthlyTransactionReportM1Gateway ObjMonthlyTransactionReportM1 = new MonthlyTransactionReportM1Gateway())
        {
            DataTable table = new DataTable();
            table = ObjMonthlyTransactionReportM1.MonthlySummaryReport(Month, Year, IsDone);

            List<Summary> lstSummary = new List<Summary>();

            lstSummary = (from DataRow dr in table.Rows
                          select new Summary()
                          {
                              couponId = Convert.ToString(dr["CouponId"]),
                              couponQtn = Convert.ToString(dr["CouponQtn"]),
                              dealId = Convert.ToString(dr["DealId"]),
                              dealTitle = Convert.ToString(dr["DealTitle"]),
                              podNumber = Convert.ToString(dr["PODnumber"]),
                              orderFrom = Convert.ToString(dr["OrderFrom"]),
                              courier = Convert.ToString(dr["Courier"]),
                              companyName = Convert.ToString(dr["CompanyName"]),
                              crmConfirmationDate = Convert.ToString(dr["CrmConfirmationDate"]),
                              folderName = Convert.ToString(dr["FolderName"]),
                              comments = Convert.ToString(dr["Comments"]),
                              couponPrice = Convert.ToInt32(dr["CouponPrice"]),
                              commentedBy = Convert.ToString(dr["CommentedBy"])


                          }).ToList();
            return lstSummary;
        }
    }



    [WebMethod]
    public static List<string> LoadComments(string CouponId)
    {
        List<string> ListArray = new List<string>();
        ListArray.Add(GetCouponsDetailsPopup(CouponId));
        ListArray.Add(GetDealComments(CouponId));
        return ListArray.ToList();
    }


    [WebMethod]
    public static string GetCouponsDetailsPopup(string CouponId)
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
                            count++, row["CommentedOn"], row["UserName"], IsDone,  row["Comments"]);
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

    public class Summary
    {
        public string couponId { get; set; }
        public string couponQtn { get; set; }
        public string dealId { get; set; }
        public string dealTitle { get; set; }
        public string podNumber { get; set; }
        public string orderFrom { get; set; }
        public string courier { get; set; }
        public string companyName { get; set; }
        public string crmConfirmationDate { get; set; }
        public string folderName { get; set; }
        public string comments { get; set; }
        public int couponPrice { get; set; }
        public string commentedBy { get; set; }
    }
}