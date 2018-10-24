using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using System.Collections;
using System.Data.SqlClient;

/// <summary>
/// Summary description for BOC_Reports
/// </summary>
public class BOC_Reports : UTLDBHandler
{
    public BOC_Reports()
        : base(UTLUtilities.Database.DbConnectionString)
	{
		//
		// TODO: Add constructor logic here
		//
	}
	
	
	
	public DataTable MonthlyTransactionReportBasedOnConfirmOrderDistrictWise(string Month, string Year) //, string OrderBy
     {
         try
         {
             ArrayList arlSQLParameters = new ArrayList();

             arlSQLParameters.Add(new SqlParameter("@MonthName", Month));
             arlSQLParameters.Add(new SqlParameter("@YearName", Year));
             //arlSQLParameters.Add(new SqlParameter("@SortedBy", OrderBy));


             DataTable objDataTable = new DataTable();


             objDataTable = this.ExecuteQuery("Reports.USP_LoadMonthlyTransactionReportBasedOnConfirmOrderDistrictWise", arlSQLParameters);


             return objDataTable;

         }
         catch
         {
             throw;
         }
         finally
         {
             this.CloseConnection();
         }
     }
	 
	public DataTable LoadMonthlyTransactionReportBasedOnConfirmOrderBySubcat(string Month, string Year, string OrderBy)
     {
         try
         {
             ArrayList arlSQLParameters = new ArrayList();

             arlSQLParameters.Add(new SqlParameter("@MonthName", Month));
             arlSQLParameters.Add(new SqlParameter("@YearName", Year));
             arlSQLParameters.Add(new SqlParameter("@SortedBy", OrderBy));


             DataTable objDataTable = new DataTable();


             objDataTable = this.ExecuteQuery("Reports.USP_LoadMonthlyTransactionReportBasedOnConfirmOrderBySubcat", arlSQLParameters);


             return objDataTable;

         }
         catch
         {
             throw;
         }
         finally
         {
             this.CloseConnection();
         }
     }
	 
	 public DataTable LoadMonthlyTransactionReportBasedOnConfirmOrder(string Month, string Year, string OrderBy)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@MonthName", Month));
            arlSQLParameters.Add(new SqlParameter("@YearName", Year));
            arlSQLParameters.Add(new SqlParameter("@SortedBy", OrderBy));


            DataTable objDataTable = new DataTable();


            objDataTable = this.ExecuteQuery("Reports.USP_LoadMonthlyTransactionReportBasedOnConfirmOrderByPercent", arlSQLParameters);


            return objDataTable;

        }
        catch
        {
            throw;
        }
        finally
        {
            this.CloseConnection();
        }
    }
	
    public DataTable GetRecord_MonthlyTransactionReportBasedOnConfirmOrderDealWiseForAdmin(int ProfileId, int MonthName, int YearName)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@ProfileId", ProfileId));
            arlSQLParameters.Add(new SqlParameter("@MonthName", MonthName));
            arlSQLParameters.Add(new SqlParameter("@YearName", YearName));
            return this.ExecuteQuery("Reports.USP_LoadMonthlyTransactionReportBasedOnConfirmOrderDealWise", arlSQLParameters);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            this.CloseConnection();
        }
    }

	public DataTable GetRecord_MonthlyTransactionReportBasedOnConfirmOrderDetailsForAdmin(int ProfileId, int MonthName, int YearName)
     {
         try
         {
             ArrayList arlSQLParameters = new ArrayList();
             arlSQLParameters.Add(new SqlParameter("@ProfileId", ProfileId));
             arlSQLParameters.Add(new SqlParameter("@MonthName", MonthName));
             arlSQLParameters.Add(new SqlParameter("@YearName", YearName));
             return this.ExecuteQuery("Reports.USP_LoadMonthlyTransactionReportBasedOnConfirmOrderDetails", arlSQLParameters);
         }
         catch (Exception ex)
         {
             throw new Exception(ex.Message);
         }
     }
	 
	public int SaveMakeDeliverySheetWithModel(string strDeliveryDate, string strCollectionAddress, string strDeliveredBy, string strDeliveredType, string strCommentedBy, int intCouponId, string strComments, string strStatus, string strDeliveryTimeLimit, int BusinessModel)
     {
         int intActionResult = 0;

         try
         {
             ArrayList arlSQLParameters = new ArrayList();



             arlSQLParameters.Add(new SqlParameter("@DeliveryDate", strDeliveryDate));
             arlSQLParameters.Add(new SqlParameter("@CustomerBillingAddress", strCollectionAddress));
             arlSQLParameters.Add(new SqlParameter("@DeliveredBy", strDeliveredBy));
             arlSQLParameters.Add(new SqlParameter("@DeliveredType", strDeliveredType));
             arlSQLParameters.Add(new SqlParameter("@Comments", strComments));
             arlSQLParameters.Add(new SqlParameter("@CommentedBy", strCommentedBy));
             arlSQLParameters.Add(new SqlParameter("@CouponId", intCouponId.ToString()));
             arlSQLParameters.Add(new SqlParameter("@IsDone", strStatus));
             arlSQLParameters.Add(new SqlParameter("@DeliveryTimeLimit", strDeliveryTimeLimit));
             arlSQLParameters.Add(new SqlParameter("@BusinessModel", BusinessModel.ToString()));

             intActionResult = this.ExecuteActionQuery("AD.USP_SaveCommentsAndSetBusinessModel", arlSQLParameters);
         }
         catch (Exception exp)
         {
             throw new Exception("No data found ", exp);
         }
         finally
         {
             this.CloseConnection();
         }
         return intActionResult;
     }


    public DataTable LoadReport(string FromDate, string ToDate)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();


            arlSQLParameters.Add(new SqlParameter("@FromDate", FromDate));
            arlSQLParameters.Add(new SqlParameter("@ToDate", ToDate));

            DataTable objDataTable = new DataTable();


            objDataTable = this.ExecuteQuery("Reports.USP_LoadDeliveryStatusReports", arlSQLParameters);


            return objDataTable;

        }
        catch
        {
            throw;
        }
    }

    public DataTable LoadBookingReportsUniqueUserCount(string FromDate, string ToDate, string p, string strBasedOn)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();


            arlSQLParameters.Add(new SqlParameter("@FromDate", FromDate));
            arlSQLParameters.Add(new SqlParameter("@ToDate", ToDate));
            arlSQLParameters.Add(new SqlParameter("@Status", p));
            arlSQLParameters.Add(new SqlParameter("@BasedOn", strBasedOn));

            DataTable objDataTable = new DataTable();


            objDataTable = this.ExecuteQuery("Reports.USP_LoadBookingReportsUniqueUserCount", arlSQLParameters);


            return objDataTable;

        }
        catch
        {
            throw;
        }
    }

    public DataTable LoadBookingReportsNewUniqueUserCount(string FromDate, string ToDate, string p, string strBasedOn)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();


            arlSQLParameters.Add(new SqlParameter("@FromDate", FromDate));
            arlSQLParameters.Add(new SqlParameter("@ToDate", ToDate));
            arlSQLParameters.Add(new SqlParameter("@Status", p));
            arlSQLParameters.Add(new SqlParameter("@BasedOn", strBasedOn));

            DataTable objDataTable = new DataTable();


            objDataTable = this.ExecuteQuery("Reports.USP_LoadBookingReportsNewUniqueUserCount", arlSQLParameters);


            return objDataTable;

        }
        catch
        {
            throw;
        }
    }

    public DataTable LoadBookingReportsOPSUniqueUserCount(string FromDate, string ToDate, string p, string strBasedOn)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();


            arlSQLParameters.Add(new SqlParameter("@FromDate", FromDate));
            arlSQLParameters.Add(new SqlParameter("@ToDate", ToDate));
            arlSQLParameters.Add(new SqlParameter("@Status", p));
            arlSQLParameters.Add(new SqlParameter("@BasedOn", p));

            DataTable objDataTable = new DataTable();


            objDataTable = this.ExecuteQuery("Reports.USP_LoadBookingReportsOPSUniqueUserCount", arlSQLParameters);


            return objDataTable;

        }
        catch
        {
            throw;
        }
    }

    public DataTable LoadMonthlyTransactionReportBasedOnConfirmPayment(string Month, string Year, string OrderBy)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@MonthName", Month));
            arlSQLParameters.Add(new SqlParameter("@YearName", Year));
            arlSQLParameters.Add(new SqlParameter("@SortedBy", OrderBy));


            DataTable objDataTable = new DataTable();


            objDataTable = this.ExecuteQuery("Reports.USP_LoadMonthlyTransactionReportBasedOnConfirmPayment", arlSQLParameters);


            return objDataTable;

        }
        catch
        {
            throw;
        }
        finally
        {
            this.CloseConnection();
        }
    }

    

    public DataTable LoadBookingReportsStatusCountWithDateRange(string FromDate, string ToDate, string IsDone, string strBasedOn)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();


            arlSQLParameters.Add(new SqlParameter("@FromDate", FromDate));
            arlSQLParameters.Add(new SqlParameter("@ToDate", ToDate));
            arlSQLParameters.Add(new SqlParameter("@IsDone", IsDone));
            arlSQLParameters.Add(new SqlParameter("@BasedOn", strBasedOn));

            DataTable objDataTable = this.ExecuteQuery("Reports.USP_LoadBookingReportsStatusCount", arlSQLParameters);

            return objDataTable;

        }
        catch
        {
            throw;
        }
        finally
        {
            this.CloseConnection();
        }
    }

    public int UpdateBKash(string CouponId, string UID)
    {
        int actionResult = 0;
        try
        {
            ArrayList arlSQLParameters = new ArrayList();


            arlSQLParameters.Add(new SqlParameter("@CouponId", CouponId));
            arlSQLParameters.Add(new SqlParameter("@UpdatedBy ", UID));

            DataTable objDataTable = new DataTable();

            actionResult = this.ExecuteActionQuery("Deal.USP_Update_For_Bkash_Success", arlSQLParameters);

            return actionResult;

        }
        catch
        {
            throw;
        }
        finally
        {
            this.CloseConnection();
        }
    }

    public DataTable GetDeliverySheet(string paymentType, string commentedBy, string deliveryDate, string deliveredBy, string deliveredType, string customerId, string DeliveryTimeLimit, string IsDone)
    {
        int intActionResult = 0;
        DataTable objDataTable = new DataTable();

        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@PaymentType", paymentType));
            arlSQLParameters.Add(new SqlParameter("@CommentedBy", commentedBy));
            arlSQLParameters.Add(new SqlParameter("@DeliveryDate", deliveryDate));
            arlSQLParameters.Add(new SqlParameter("@DeliveredBy", deliveredBy));
            arlSQLParameters.Add(new SqlParameter("@DeliveredType", deliveredType));
            arlSQLParameters.Add(new SqlParameter("@CustomerId", customerId));
            arlSQLParameters.Add(new SqlParameter("@DeliveryTimeLimit", DeliveryTimeLimit));
            arlSQLParameters.Add(new SqlParameter("@IsDone", IsDone));

            objDataTable = this.ExecuteQuery("Reports.USP_LoadDeliverySheet", arlSQLParameters);
        }
        catch (Exception exp)
        {
            throw new Exception("No data found ", exp);
        }
        finally
        {
            this.CloseConnection();
        }
        return objDataTable;
    }

    public DataTable LoadBookingReportsForCorporate(string strFromDate, string strToDate, string CompanyID)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@FromDate", strFromDate));
            arlSQLParameters.Add(new SqlParameter("@ToDate", strToDate));
            arlSQLParameters.Add(new SqlParameter("@Company", CompanyID));

            DataTable objDataTable = this.ExecuteQuery("AD.[USP_LoadBookingReports4MerchantHome]", arlSQLParameters);

            return objDataTable;

        }
        catch (Exception ex)
        {
            throw;
        }
        finally
        {
            this.CloseConnection();
        }
    }

    public DataTable LoadRecord_Users()
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            return this.ExecuteQuery("AD.USP_LoadSalesUsers", arlSQLParameters);

        }

        catch
        {
            throw;

        }
        finally
        {
            this.CloseConnection();
        }
    }


    public DataTable LoadRecord_Dealtitle()
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            return this.ExecuteQuery("AD.USP_LoadDealTitle", arlSQLParameters);

        }

        catch
        {
            throw;

        }
        finally
        {
            this.CloseConnection();
        }
    }

    public DataTable LoadDealsReport()
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            //arlSQLParameters.Add(new SqlParameter("@CustomerId", intCustomerId));

            DataTable objDataTable = this.ExecuteQuery("Reports.USP_LoadDealsReport", arlSQLParameters);

            return objDataTable;
        }
        catch
        {
            throw;
        }
        finally
        {
            this.CloseConnection();
        }
    }

    public DataTable LoadCommissionReports(EOC_PropertyBean eocPropertyBean)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@DealTitle", eocPropertyBean.DealTitle));
            arlSQLParameters.Add(new SqlParameter("@FromDate", eocPropertyBean.StrFromDate));
            arlSQLParameters.Add(new SqlParameter("@ToDate", eocPropertyBean.StrToDate));
            arlSQLParameters.Add(new SqlParameter("@IsFirstDeal", eocPropertyBean.PaymentType));
            arlSQLParameters.Add(new SqlParameter("@IsSimilar", eocPropertyBean.PaymentStatus));
            arlSQLParameters.Add(new SqlParameter("@UserName", eocPropertyBean.Username));

            DataTable objDataTable = this.ExecuteQuery("Reports.USP_LoadCommissionReports", arlSQLParameters);

            return objDataTable;

        }
        catch
        {
            throw;
        }
        finally
        {
            this.CloseConnection();
        }
    }

    public DataTable LoadBookingReports(EOC_PropertyBean eocPropertyBean)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@DealTitle", eocPropertyBean.DealTitle));
            arlSQLParameters.Add(new SqlParameter("@FromDate", eocPropertyBean.StrFromDate));
            arlSQLParameters.Add(new SqlParameter("@ToDate", eocPropertyBean.StrToDate));
            arlSQLParameters.Add(new SqlParameter("@Mobile", eocPropertyBean.CustomerMobile));
            arlSQLParameters.Add(new SqlParameter("@Email", eocPropertyBean.CustomerEmail));
            arlSQLParameters.Add(new SqlParameter("@BookingCode", eocPropertyBean.BookingCode));
            arlSQLParameters.Add(new SqlParameter("@CustomerName", eocPropertyBean.CustomerName));
            arlSQLParameters.Add(new SqlParameter("@PaymentType", eocPropertyBean.PaymentType));
            arlSQLParameters.Add(new SqlParameter("@PaymentStatus", eocPropertyBean.PaymentStatus));
            arlSQLParameters.Add(new SqlParameter("@IsMotherDeal", eocPropertyBean.Business_UserProfile_IsActive));
            arlSQLParameters.Add(new SqlParameter("@IsDone", eocPropertyBean.DealItemSizes));

            DataTable objDataTable = this.ExecuteQuery("Reports.USP_LoadBookingReports", arlSQLParameters);

            return objDataTable;

        }
        catch
        {
            throw;
        }
        finally
        {
            this.CloseConnection();
        }
    }

    public DataTable GetCouponCount(EOC_PropertyBean eocPropertyBean)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@FromDate", eocPropertyBean.StrFromDate));
            arlSQLParameters.Add(new SqlParameter("@ToDate", eocPropertyBean.StrToDate));

            DataTable objDataTable = this.ExecuteQuery("Reports.USP_GetCouponSoldCount", arlSQLParameters);

            return objDataTable;

        }
        catch
        {
            throw;
        }
        finally
        {
            this.CloseConnection();
        }
    }

    public DataTable GetManualPaymentInfo(EOC_PropertyBean eocPropertyBean)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@BookingCode", eocPropertyBean.BookingCode));

            DataTable objDataTable = this.ExecuteQuery("AD.USP_GetManualPaymentInfo", arlSQLParameters);

            return objDataTable;

        }
        catch
        {
            throw;
        }
        finally
        {
            this.CloseConnection();
        }
    }


    public DataTable LoadCouponSoldReport(EOC_PropertyBean eocPropertyBean)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@DealTitle", eocPropertyBean.DealTitle));
            arlSQLParameters.Add(new SqlParameter("@FromDate", eocPropertyBean.StrFromDate));
            arlSQLParameters.Add(new SqlParameter("@ToDate", eocPropertyBean.StrToDate));

            DataTable objDataTable = new DataTable();

            if (eocPropertyBean.Business_UserProfile_IsActive)
            {
                objDataTable = this.ExecuteQuery("Reports.USP_LoadCouponSoldReportMotherDealwise", arlSQLParameters);
            }
            else
            {
                objDataTable = this.ExecuteQuery("Reports.USP_LoadCouponSoldReport", arlSQLParameters);
            }

            return objDataTable;

        }
        catch
        {
            throw;
        }
        finally
        {
            this.CloseConnection();
        }
    }
    /*
    public DataTable LoadBookingReports()
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            //arlSQLParameters.Add(new SqlParameter("@CustomerId", intCustomerId));

            DataTable objDataTable = this.ExecuteQuery("Reports.USP_LoadBookingReports", arlSQLParameters);

            return objDataTable;
            
        }
        catch
        {
            throw;
        }
    }
    */

    public DataTable LoadSubscribeReports()
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            //arlSQLParameters.Add(new SqlParameter("@CustomerId", intCustomerId));

            DataTable objDataTable = this.ExecuteQuery("Reports.USP_LoadSubscribeReports", arlSQLParameters);

            return objDataTable;
            
        }
        catch
        {
            throw;
        }
        finally
        {
            this.CloseConnection();
        }
    }

    public DataTable LoadUsersReports()
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            //arlSQLParameters.Add(new SqlParameter("@CustomerId", intCustomerId));

            DataTable objDataTable = this.ExecuteQuery("Reports.USP_UsersReports", arlSQLParameters);

            return objDataTable;
            
        }
        catch
        {
            throw;
        }
        finally
        {
            this.CloseConnection();
        }
    }

    public DataTable LoadCouponsReport()
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            //arlSQLParameters.Add(new SqlParameter("@CustomerId", intCustomerId));

            DataTable objDataTable = this.ExecuteQuery("Reports.USP_LoadCouponsReport", arlSQLParameters);

            
            return objDataTable;
        }
        catch
        {
            throw;
        }
        finally
        {
            this.CloseConnection();
        }
    }

    public DataTable LoadOPSReport()
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            //arlSQLParameters.Add(new SqlParameter("@CustomerId", intCustomerId));

            DataTable objDataTable = this.ExecuteQuery("Reports.USP_LoadOPSReport", arlSQLParameters);

            return objDataTable;
        }
        catch
        {
            throw;
        }
        finally
        {
            this.CloseConnection();
        }
    }

    public DataTable LoadDealwiseCouponCountReport()
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            //arlSQLParameters.Add(new SqlParameter("@CustomerId", intCustomerId));

            DataTable objDataTable = this.ExecuteQuery("Reports.USP_LoadDealwiseCouponCountReport", arlSQLParameters);

            return objDataTable;
        }
        catch
        {
            throw;
        }
        finally
        {
            this.CloseConnection();
        }
    }

    public DataTable LoadCustomerwiseCouponCountReport()
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            //arlSQLParameters.Add(new SqlParameter("@CustomerId", intCustomerId));

            DataTable objDataTable = this.ExecuteQuery("Reports.LoadCustomerwiseCouponCountReport", arlSQLParameters);

            return objDataTable;
        }
        catch
        {
            throw;
        }
        finally
        {
            this.CloseConnection();
        }
    }

    public DataTable GetCouponInfoThroughCode(string strCouponCode)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@BookingCode", strCouponCode));

            DataTable objDataTable = this.ExecuteQuery("Reports.USP_GetCouponInfoThroughCode", arlSQLParameters);

            return objDataTable;
        }
        catch
        {
            throw;
        }
        finally
        {
            this.CloseConnection();
        }
    }

    public DataTable LoadRecordReceiptBy()
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            return this.ExecuteQuery("AD.USP_LoadReceiptBy", arlSQLParameters);
        }
        catch
        {
            throw;
        }
        finally
        {
            this.CloseConnection();
        }
    }

    public DataTable LoadRecordCollectedBy()
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            return this.ExecuteQuery("AD.USP_LoadCollectedBy", arlSQLParameters);
        }
        catch
        {
            throw;
        }
        finally
        {
            this.CloseConnection();
        }
    }

    public int InsertManualPaymentCollectionInfo(EOC_PropertyBean eocPropertyBean)
    {
        int intActionResult = 0;
        //string dtmPostedOn = DateTime.Now.ToString();

        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@ReceiptBy", eocPropertyBean.ReceiptBy));
            arlSQLParameters.Add(new SqlParameter("@CollectedBy", eocPropertyBean.CollectedBy));
            arlSQLParameters.Add(new SqlParameter("@DeliveredTo", eocPropertyBean.CustomerName));
            arlSQLParameters.Add(new SqlParameter("@CheckNo", eocPropertyBean.CouponCode));
            arlSQLParameters.Add(new SqlParameter("@Amount", eocPropertyBean.CouponPrice));
            arlSQLParameters.Add(new SqlParameter("@BookingCode", eocPropertyBean.BookingCode));
            arlSQLParameters.Add(new SqlParameter("@UserId", eocPropertyBean.CustomerId));
            arlSQLParameters.Add(new SqlParameter("@ServiceCharge", eocPropertyBean.ServiceCharge));
            //arlSQLParameters.Add(new SqlParameter("@PostedOn", dtmPostedOn));

            intActionResult = this.ExecuteActionQuery("AD.USP_InsertRecord_ManualPaymentCollectionInfo", arlSQLParameters);
            
        }
        catch
        {
            throw;
        }
        finally
        {
            this.CloseConnection();
        }

        return intActionResult;
    }

    public bool IsAdminLoginValid(EOC_PropertyBean eocPropertyBean)
    {
        bool blnFlag = false;

        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@UserName", eocPropertyBean.CustomerEmail));
            arlSQLParameters.Add(new SqlParameter("@Passwrd", eocPropertyBean.CustomerPassword));

            DataTable objDataTable = this.ExecuteQuery("AD.USP_Admin_GetLoginInfo", arlSQLParameters);

            if (objDataTable.Rows.Count > 0)
            {
                eocPropertyBean.CustomerId = Convert.ToInt32(objDataTable.Rows[0]["UserId"].ToString());
                eocPropertyBean.CustomerName = objDataTable.Rows[0]["FullName"].ToString();
                eocPropertyBean.CustomerEmail = objDataTable.Rows[0]["UserName"].ToString();
                eocPropertyBean.DistrictId = Convert.ToInt32(objDataTable.Rows[0]["AdminType"].ToString());
                

                blnFlag = true;
            }
            else
            {
                blnFlag = false;
            }
        }
        catch
        {
            throw;
        }
        finally
        {
            this.CloseConnection();
        }

        return blnFlag;
    }

    public int SaveComments(string strComments, int intCouponId)
    {
        int intActionResult = 0;

        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@Comments", strComments));
            arlSQLParameters.Add(new SqlParameter("@CouponId", intCouponId));

            intActionResult = this.ExecuteActionQuery("Reports.USP_SaveComments", arlSQLParameters);
        }
        catch
        {
            throw;
        }
        finally
        {
            this.CloseConnection();
        }

        return intActionResult;
    }
    public int SaveComments_2(string strComments, int intCouponId, string strCommentedBy, int IsDone)
    {

        int intActionResult = 0;
        try
        {
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@Comments", strComments));
            arlSqlParameters.Add(new SqlParameter("@CouponId", intCouponId));
            arlSqlParameters.Add(new SqlParameter("@CommentedBy", strCommentedBy));
            arlSqlParameters.Add(new SqlParameter("@IsDone", IsDone));
            intActionResult = this.ExecuteActionQuery("Reports.USP_SaveComments_2", arlSqlParameters);

        }
        catch
        {
            throw;
        }
        finally
        {
            this.CloseConnection();
        }
        return intActionResult;
    }

    public DataTable LoadCorporateReport()
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            //arlSQLParameters.Add(new SqlParameter("@CustomerId", intCustomerId));

            DataTable objDataTable = this.ExecuteQuery("Reports.USP_LoadCorporateReports", arlSQLParameters);

            return objDataTable;
        }
        catch
        {
            throw;
        }
        finally
        {
            this.CloseConnection();
        }
    }

    public DataTable LoadMerchentReport()
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            //arlSQLParameters.Add(new SqlParameter("@CustomerId", intCustomerId));

            DataTable objDataTable = this.ExecuteQuery("Reports.USP_AskingHotDiscountReports", arlSQLParameters);

            return objDataTable;
        }
        catch
        {
            throw;
        }
        finally
        {
            this.CloseConnection();
        }
    }

    public int SaveDiscountComments(string strComments, int intDiscountId)
    {
        int intActionResult = 0;

        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@Comments", strComments));
            arlSQLParameters.Add(new SqlParameter("@DiscountId", intDiscountId));

            intActionResult = this.ExecuteActionQuery("Reports.USP_SaveDiscountComments", arlSQLParameters);
        }
        catch
        {
            throw;
        }
        finally
        {
            this.CloseConnection();
        }

        return intActionResult;
    }

    public DataTable LoadBookingComments(int intCouponId)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@CouponId", intCouponId));

            DataTable objDataTable = this.ExecuteQuery("Reports.USP_LoadBookingComments", arlSQLParameters);

            return objDataTable;
        }
        catch
        {
            throw;
        }
        finally
        {
            this.CloseConnection();
        }
    }
	
	 public DataTable LoadOnlinePaymentInfo(int intPaymentId)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@PaymentId", intPaymentId));

            DataTable objDataTable = this.ExecuteQuery("Reports.USP_OPSDetail", arlSQLParameters);

            return objDataTable;
        }
        catch
        {
            throw;
        }
        finally
        {
            this.CloseConnection();
        }
    }

     public DataTable LoadSliverCoustomerreports(EOC_PropertyBean eocpropertyBean)
     {
         try
         {
             ArrayList arlSqlparameters = new ArrayList();
             DataTable objDatatable = this.ExecuteQuery("AD.USP_LoadSilverCustomerReport", arlSqlparameters);
             return objDatatable;
         }
         catch (Exception exp)
         {
             throw new Exception("No data found ", exp);
         }
         finally
         {
             this.CloseConnection();
         }
     }

     public DataTable LoadGoldCoustomerreports(EOC_PropertyBean eocpropertyBean)
     {
         try
         {
             ArrayList arlSqlparameters = new ArrayList();
             DataTable objDatatable = this.ExecuteQuery("AD.USP_LoadGoldCustomerReport", arlSqlparameters);
             return objDatatable;
         }
         catch (Exception exp)
         {
             throw new Exception("No data found ", exp);
         }
     }

     public int MakeCouponUsedById(string strCouponId)
     {
         int intActionResult = 0;

         try
         {
             ArrayList arlSQLParameters = new ArrayList();

             arlSQLParameters.Add(new SqlParameter("@CouponId", strCouponId));

             intActionResult = this.ExecuteActionQuery("Deal.USP_MakeCouponUsedById", arlSQLParameters);
         }
         catch
         {
             throw;
         }
         finally
         {
             this.CloseConnection();
         }

         return intActionResult;
     }

     public DataTable GetTotalMarchents(EOC_PropertyBean eocPropertyBean)
     {
         try
         {

             ArrayList arlSQLParameters = new ArrayList();

             arlSQLParameters.Add(new SqlParameter("@FromDate", eocPropertyBean.StrFromDate));
             arlSQLParameters.Add(new SqlParameter("@ToDate", eocPropertyBean.StrToDate));
             arlSQLParameters.Add(new SqlParameter("@UserName", eocPropertyBean.Username));

             return this.ExecuteQuery("Reports.USP_GetTotalMarchents", arlSQLParameters);

         }

         catch
         {
             throw;

         }
         finally
         {
             this.CloseConnection();
         }
     }

     public DataTable GetTotalDeals(EOC_PropertyBean eocPropertyBean)
     {
         try
         {
             ArrayList arlSQLParameters = new ArrayList();

             arlSQLParameters.Add(new SqlParameter("@FromDate", eocPropertyBean.StrFromDate));
             arlSQLParameters.Add(new SqlParameter("@ToDate", eocPropertyBean.StrToDate));
             arlSQLParameters.Add(new SqlParameter("@UserName", eocPropertyBean.Username));

             return this.ExecuteQuery("Reports.USP_GetTotalDeals", arlSQLParameters);

         }

         catch
         {
             throw;

         }
         finally
         {
             this.CloseConnection();
         }
     }

     public DataTable GetTotalNewMerchant(EOC_PropertyBean eocPropertyBean)
     {
         try
         {
             ArrayList arlSQLParameters = new ArrayList();

             arlSQLParameters.Add(new SqlParameter("@FromDate", eocPropertyBean.StrFromDate));
             arlSQLParameters.Add(new SqlParameter("@ToDate", eocPropertyBean.StrToDate));
             arlSQLParameters.Add(new SqlParameter("@UserName", eocPropertyBean.Username));

             return this.ExecuteQuery("Reports.USP_GetTotalNewMarchents", arlSQLParameters);

         }

         catch
         {
             throw;

         }
         finally
         {
             this.CloseConnection();
         }
     }

     public DataTable GetTotalNewDeal(EOC_PropertyBean eocPropertyBean)
     {
         try
         {
             ArrayList arlSQLParameters = new ArrayList();

             arlSQLParameters.Add(new SqlParameter("@FromDate", eocPropertyBean.StrFromDate));
             arlSQLParameters.Add(new SqlParameter("@ToDate", eocPropertyBean.StrToDate));
             arlSQLParameters.Add(new SqlParameter("@UserName", eocPropertyBean.Username));

             return this.ExecuteQuery("Reports.USP_GetTotalFreshDeals", arlSQLParameters);

         }

         catch
         {
             throw;

         }
         finally
         {
             this.CloseConnection();
         }
     }

     public DataTable LoadBookingReportsWithTopRows(EOC_PropertyBean eocPropertyBean, string topRow)
     {
         try
         {
             ArrayList arlSQLParameters = new ArrayList();

             arlSQLParameters.Add(new SqlParameter("@DealTitle", eocPropertyBean.DealTitle));
             arlSQLParameters.Add(new SqlParameter("@FromDate", eocPropertyBean.StrFromDate));
             arlSQLParameters.Add(new SqlParameter("@ToDate", eocPropertyBean.StrToDate));
             arlSQLParameters.Add(new SqlParameter("@Mobile", eocPropertyBean.CustomerMobile));
             arlSQLParameters.Add(new SqlParameter("@Email", eocPropertyBean.CustomerEmail));
             arlSQLParameters.Add(new SqlParameter("@BookingCode", eocPropertyBean.BookingCode));
             arlSQLParameters.Add(new SqlParameter("@CustomerName", eocPropertyBean.CustomerName));
             arlSQLParameters.Add(new SqlParameter("@PaymentType", eocPropertyBean.PaymentType));
             arlSQLParameters.Add(new SqlParameter("@PaymentStatus", eocPropertyBean.PaymentStatus));
             arlSQLParameters.Add(new SqlParameter("@IsMotherDeal", eocPropertyBean.Business_UserProfile_IsActive));
             arlSQLParameters.Add(new SqlParameter("@IsDone", eocPropertyBean.DealItemSizes));
             arlSQLParameters.Add(new SqlParameter("@Top", topRow));
             arlSQLParameters.Add(new SqlParameter("@Company", eocPropertyBean.UserProfile_UserName));
             arlSQLParameters.Add(new SqlParameter("@BasedOn", eocPropertyBean.CouponCode));

             DataTable objDataTable = this.ExecuteQuery("Reports.USP_LoadBookingReports", arlSQLParameters);

             return objDataTable;

         }
         catch
         {
             throw;
         }
         finally
         {
             this.CloseConnection();
         }
     }

     public DataTable LoadRecord_DealtitleWithIdOrTitle(int IsDealId, string SearchData)
     {
         try
         {

             ArrayList arlSQLParameters = new ArrayList();

             arlSQLParameters.Add(new SqlParameter("@IsDealId", IsDealId));
             arlSQLParameters.Add(new SqlParameter("@SearchData", SearchData));

             return this.ExecuteQuery("AD.USP_GetDealTitleWithIdOrTitle", arlSQLParameters);

         }

         catch (Exception exp)
         {
             throw new Exception("No data found ", exp);
         }
         finally
         {
             this.CloseConnection();
         }
     }

     public DataTable LoadCollectedBy()
     {
         try
         {
             ArrayList arlSqlparameters = new ArrayList();
             DataTable objDatatable = this.ExecuteQuery("AD.USP_LoadCollectedBy", arlSqlparameters);
             return objDatatable;
         }
         catch (Exception exp)
         {
             throw new Exception("No data found ", exp);
         }
         finally
         {
             this.CloseConnection();
         }
     }

     public DataTable GetDeliverySheet(string paymentType, string commentedBy, string deliveryDate, string deliveredBy, string deliveredType)
     {
         int intActionResult = 0;
         DataTable objDataTable = new DataTable();

         try
         {
             ArrayList arlSQLParameters = new ArrayList();

             arlSQLParameters.Add(new SqlParameter("@PaymentType", paymentType));
             arlSQLParameters.Add(new SqlParameter("@CommentedBy", commentedBy));
             arlSQLParameters.Add(new SqlParameter("@DeliveryDate", deliveryDate));
             arlSQLParameters.Add(new SqlParameter("@DeliveredBy", deliveredBy));
             arlSQLParameters.Add(new SqlParameter("@DeliveredType", deliveredType));

             objDataTable = this.ExecuteQuery("Reports.USP_LoadDeliverySheet", arlSQLParameters);
         }
         catch (Exception exp)
         {
             throw new Exception("No data found ", exp);
         }
         finally
         {
             this.CloseConnection();
         }
         return objDataTable;
     }

     public int SaveMakeDeliverySheet(string strDeliveryDate, string strCollectionAddress, string strDeliveredBy, string strDeliveredType, string strCommentedBy, int intCouponId, string strComments, string strStatus, string strDeliveryTimeLimit)
     {
         int intActionResult = 0;

         try
         {
             ArrayList arlSQLParameters = new ArrayList();



             arlSQLParameters.Add(new SqlParameter("@DeliveryDate", strDeliveryDate));
             arlSQLParameters.Add(new SqlParameter("@CustomerBillingAddress", strCollectionAddress));
             arlSQLParameters.Add(new SqlParameter("@DeliveredBy", strDeliveredBy));
             arlSQLParameters.Add(new SqlParameter("@DeliveredType", strDeliveredType));
             arlSQLParameters.Add(new SqlParameter("@Comments", strComments));
             arlSQLParameters.Add(new SqlParameter("@CommentedBy", strCommentedBy));
             arlSQLParameters.Add(new SqlParameter("@CouponId", intCouponId.ToString()));
             arlSQLParameters.Add(new SqlParameter("@IsDone", strStatus));
             arlSQLParameters.Add(new SqlParameter("@DeliveryTimeLimit", strDeliveryTimeLimit));


             intActionResult = this.ExecuteActionQuery("AD.USP_UpdateCouponForDelivery", arlSQLParameters);
         }
         catch (Exception exp)
         {
             throw new Exception("No data found ", exp);
         }
         finally
         {
             this.CloseConnection();
         }
         return intActionResult;
     }


     /// <summary>
     /// Comments  Load and Insert function
     /// </summary>
     /// <param name="strComments"></param>
     /// <param name="intCouponId"></param>
     /// <param name="strCommentedBy"></param>
     /// <param name="IsDone"></param>


     public void InsertComments(string strComments, int intCouponId, string strCommentedBy, int IsDone)
     {
         try
         {
             ArrayList arlSqlParameters = new ArrayList();
             arlSqlParameters.Add(new SqlParameter("@Comments", strComments));
             arlSqlParameters.Add(new SqlParameter("@CouponId", intCouponId));
             arlSqlParameters.Add(new SqlParameter("@CommentedBy", strCommentedBy));
             arlSqlParameters.Add(new SqlParameter("@IsDone", IsDone));
             this.ExecuteActionQuery("Reports.USP_InsertComments", arlSqlParameters);

         }
         catch
         {
             throw;
         }
         finally
         {
             this.CloseConnection();
         }
     }

     public DataTable LoadBookingReportComments(int intCouponId)
     {
         try
         {

             ArrayList arlSQLParameters = new ArrayList();

             arlSQLParameters.Add(new SqlParameter("@CouponId", intCouponId));


             return this.ExecuteQuery("Reports.USP_LoadBookingReportComments", arlSQLParameters);

         }

         catch (Exception exp)
         {
             throw new Exception("No data found ", exp);
         }
         finally
         {
             this.CloseConnection();
         }
     }

     public DataTable LoadRecord_SearchDealTitle(string SearchData)
     {
         try
         {

             ArrayList arlSQLParameters = new ArrayList();


             arlSQLParameters.Add(new SqlParameter("@SearchData", SearchData));

             return this.ExecuteQuery("AD.USP_LoadDealsForSearch", arlSQLParameters);

         }

         catch (Exception exp)
         {
             throw new Exception("No data found ", exp);
         }
         finally
         {
             this.CloseConnection();
         }
     }

     public int MakeCouponUsedThroughCode(string strBookingCode)
     {
         int intActionResult = 0;

         try
         {
             ArrayList arlSQLParameters = new ArrayList();

             arlSQLParameters.Add(new SqlParameter("@BookingCode", strBookingCode));

             intActionResult = this.ExecuteActionQuery("Reports.USP_MakeCouponUsedThroughCode", arlSQLParameters);
         }
         catch
         {
             throw;
         }
         finally
         {
             this.CloseConnection();
         }

         return intActionResult;
     }

     /// <summary>
     /// Categorywise CouponSold Reports
     /// </summary>
     /// <param name="eocPropertyBean">FromDate and ToDate </param>
     /// <returns></returns>
     public DataTable LoadCouponSoldReportCategorywise(EOC_PropertyBean eocPropertyBean)
     {
         try
         {
             ArrayList arlSQLParameters = new ArrayList();


             arlSQLParameters.Add(new SqlParameter("@FromDate", eocPropertyBean.StrFromDate));
             arlSQLParameters.Add(new SqlParameter("@ToDate", eocPropertyBean.StrToDate));

             DataTable objDataTable = new DataTable();


             objDataTable = this.ExecuteQuery("Reports.USP_LoadCouponSoldReportCategorywise", arlSQLParameters);


             return objDataTable;

         }
         catch
         {
             throw;
         }
         finally
         {
             this.CloseConnection();
         }
     }

     /// <summary>
     /// SubCategorywise CouponSold Reports
     /// </summary>
     /// <param name="eocPropertyBean">FromDate and ToDate </param>
     /// <returns></returns>
     public DataTable LoadCouponSoldReportSubCategorywise(EOC_PropertyBean eocPropertyBean)
     {
         try
         {
             ArrayList arlSQLParameters = new ArrayList();


             arlSQLParameters.Add(new SqlParameter("@FromDate", eocPropertyBean.StrFromDate));
             arlSQLParameters.Add(new SqlParameter("@ToDate", eocPropertyBean.StrToDate));

             DataTable objDataTable = new DataTable();


             objDataTable = this.ExecuteQuery("Reports.USP_LoadCouponSoldReportSubCategorywise", arlSQLParameters);


             return objDataTable;

         }
         catch
         {
             throw;
         }
         finally
         {
             this.CloseConnection();
         }
     }


}