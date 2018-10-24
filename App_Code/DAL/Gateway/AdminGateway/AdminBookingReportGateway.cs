using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for AdminBookingReportGateway
/// </summary>
public class AdminBookingReportGateway : ADGateway
{
	public AdminBookingReportGateway()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    


	public DataTable ToBeVerifiedBookingReports(string FulFillmentRating, string Status)
    {
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@FulFillmentRating", FulFillmentRating));
            arlSQLParameters.Add(new SqlParameter("@Status", Status));
            return this.ExecuteQuery("[Reports].[USP_LoadToBeVerifiedBookingReportsCount]", arlSQLParameters);
        }
        catch (Exception exp)
        {
            throw new Exception("No data found ", exp);
        }
        finally
        {
            CloseConnection();
        }
    }

    public DataTable VerifiedBookingReports(string FulFillmentRating, string Status)
    {
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@FulFillmentRating", FulFillmentRating));
            arlSQLParameters.Add(new SqlParameter("@Status", Status));
            return this.ExecuteQuery("[Reports].[USP_LoadVerifiedBookingReportsCount]", arlSQLParameters);
        }
        catch (Exception exp)
        {
            throw new Exception("No data found ", exp);
        }
        finally
        {
            CloseConnection();
        }
    }
	
	public DataTable LoadToBeVerifiedBookingReports(string FulFillmentRating, string Status)
    {
        DataTable objDataTable = new DataTable();
        try
        {

            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@FulFillmentRating", FulFillmentRating));
            arlSQLParameters.Add(new SqlParameter("@Status", Status));

            objDataTable = this.ExecuteQuery("Reports.USP_LoadToBeVerifiedBookingReports", arlSQLParameters);

        }
        catch
        {
            throw;
        }
        finally
        {
            this.CloseConnection();
        }
        return objDataTable;
    }

    public DataTable LoadVerifiedBookingReports(string FulFillmentRating, string Status, string FromDate, string ToDate, string BookingCode, string Mobile, string Email, string Top)
    {
        DataTable objDataTable = new DataTable();
        try
        {

            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@FulFillmentRating", FulFillmentRating));
            arlSQLParameters.Add(new SqlParameter("@Status", Status));
            arlSQLParameters.Add(new SqlParameter("@FromDate", FromDate));
            arlSQLParameters.Add(new SqlParameter("@ToDate", ToDate));
            arlSQLParameters.Add(new SqlParameter("@BookingCode", BookingCode.Trim()));
            arlSQLParameters.Add(new SqlParameter("@Mobile", Mobile.Trim()));
            arlSQLParameters.Add(new SqlParameter("@Email", Email.Trim()));
            arlSQLParameters.Add(new SqlParameter("@Top", Top.Trim()));

            objDataTable = this.ExecuteQuery("Reports.USP_LoadVerifiedBookingReports_ByOrderDate", arlSQLParameters);

        }
        catch
        {
            throw;
        }
        finally
        {
            this.CloseConnection();
        }
        return objDataTable;
    }
	
    public DataTable LoadComments(int intCouponId)
    {
        try
        {
            OpenConnection();
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



	 public int Get_BusinessModel(string couponId)
    {
        DataTable objDataTable = new DataTable();
        int businessmodel = 0;
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@couponid", couponId));
            objDataTable = this.ExecuteQuery("[Reports].[USP_LoadBookingComments]", arlSQLParameters);
            businessmodel = Convert.ToInt32(objDataTable.Rows[0]["BusinessModel"]);
        }
        catch
        {
            throw;
        }
        finally
        {
            this.CloseConnection();
        }
        return businessmodel;
    }
	
	public int UpdateUserProfileWithComment(string ProfileId, string Comments, int intUserId)
    {
        int intActionResult = 0;
        try
        {

            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@ProfileId", ProfileId));
            arlSQLParameters.Add(new SqlParameter("@Comments", Comments));
            arlSQLParameters.Add(new SqlParameter("@intUserId", intUserId));


            intActionResult = this.ExecuteActionQuery("[Deal].[USP_UpdateUserProfileWithComment]", arlSQLParameters);

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
	
    public DataTable LoadUnverifiedBookingReports(string FulFillmentRating, string Status)
    {
        DataTable objDataTable = new DataTable();
        try
        {

            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
                        
            arlSQLParameters.Add(new SqlParameter("@FulFillmentRating", FulFillmentRating));
            arlSQLParameters.Add(new SqlParameter("@Status", Status));

            objDataTable = this.ExecuteQuery("Reports.USP_LoadUnverifiedBookingReports", arlSQLParameters);
            
        }
        catch
        {
            throw;
        }
        finally
        {
            this.CloseConnection();
        }
        return objDataTable;
    }

    public int UpdateTableByValue(string TableName, string FieldName, string FieldValue, string WhereFieldName, string WhereFieldValue)
    {
        int intActionResult = 0;
        try
        {

            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@TableName", TableName));
            arlSQLParameters.Add(new SqlParameter("@FieldName", FieldName));
            arlSQLParameters.Add(new SqlParameter("@FieldValue", FieldValue));
            arlSQLParameters.Add(new SqlParameter("@WhereFieldName", WhereFieldName));
            arlSQLParameters.Add(new SqlParameter("@WhereFieldValue", WhereFieldValue));

            intActionResult = this.ExecuteActionQuery("[Deal].[USP_UpdateTableByValue]", arlSQLParameters);
            
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
	
	public DataTable UpdateOrderSource(string couponid, string ordersourceid)
    {
        DataTable objDataTable = new DataTable();
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@couponid", couponid));
            arlSQLParameters.Add(new SqlParameter("@ordersourceid", ordersourceid));

            objDataTable = this.ExecuteQuery("[Deal].[USP_InsertOrderSource]", arlSQLParameters);
        }
        catch
        {
            throw;
        }
        finally
        {
            this.CloseConnection();
        }
        return objDataTable;
    }
	
	public DataTable GetDistrictNames()
    {
        DataTable dataTable = new DataTable();
        const string storedProcedureName = @"[Deal].[USP_LoadAllDistrictForSite]";

        try
        {
            OpenConnection();
            dataTable = this.ExecuteQuery(storedProcedureName, null);
            return dataTable.Rows.Count > 0 ? dataTable : null;

        }
        catch (Exception exception)
        {
            return null;
        }
        finally
        {
            CloseConnection();
        }
    }
    //public int FunctionName(string Parameter)
    //{
    //    int intActionResult = 0;

    //    try
    //    {
    //        OpenConnection();
    //        ArrayList arlSqlParameters = new ArrayList();
    //        arlSqlParameters.Add(new SqlParameter("@ExpectedDeliveryDate ", ExpectedDeliveryDate));
           

    //        intActionResult = this.ExecuteActionQuery("Deal.USP_AddCurierDeliveryInfo", arlSqlParameters);
    //        return intActionResult;
    //    }
    //    catch (Exception exception)
    //    {
    //        throw new Exception("Gateway Error:" + exception.Message, exception);
    //    }
    //    finally
    //    {
    //        CloseConnection();
    //    }
    //}

    public int AddRecordComments(Comments objComments)
    {
        int intActionResult = 0;

        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();

            arlSqlParameters.Add(new SqlParameter("@Comments", objComments.Comment));
            arlSqlParameters.Add(new SqlParameter("@CouponId", objComments.CouponId));
            arlSqlParameters.Add(new SqlParameter("@CommentedBy", objComments.CommentedBy));
            arlSqlParameters.Add(new SqlParameter("@IsDone", objComments.IsDone));
            intActionResult = this.ExecuteActionQuery("Reports.USP_InsertComments", arlSqlParameters);

            return intActionResult;
        }
        catch (Exception exception)
        {
            throw new Exception("AdminBookingReportGateway Error:" + exception.Message, exception);
        }
        finally
        {
            CloseConnection();
        }
    }
    public int UpdateCouponForComment(Comments objComments)
    {
        int intActionResult = 0;

        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@Comments", objComments.Comment));
            arlSqlParameters.Add(new SqlParameter("@CouponId", objComments.CouponId));
            arlSqlParameters.Add(new SqlParameter("@CommentedBy", objComments.CommentedBy));
            arlSqlParameters.Add(new SqlParameter("@IsDone", objComments.IsDone));
            intActionResult = this.ExecuteActionQuery("Reports.USP_SaveComments_2", arlSqlParameters);
            return intActionResult;
        }
        catch (Exception exception)
        {
            throw new Exception("AdminBookingReportGateway:" + exception.Message, exception);
        }
        finally
        {
            CloseConnection();
        }
    }


    public int UpdateCouponWithConfirmationDate(string FieldName, string intCouponId)
    {
        int intActionResult = 0;

        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@FieldName", FieldName));
            arlSqlParameters.Add(new SqlParameter("@intCouponId", intCouponId.ToString()));
           
            intActionResult = this.ExecuteActionQuery("Deal.USP_UpdateCouponConfirmationDate", arlSqlParameters);
            return intActionResult;
        }
        catch (Exception exception)
        {
            throw new Exception("AdminBookingReportGateway:" + exception.Message, exception);
        }
        finally
        {
            CloseConnection();
        }
    }

    public int InsertOrderStatus(OrderStatus objOrderStatus)
    {
        int intActionResult = 0;

        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@OrderDate", objOrderStatus.OrderDate));
            arlSqlParameters.Add(new SqlParameter("@CouponId", objOrderStatus.CouponId));
            arlSqlParameters.Add(new SqlParameter("@OrderStatus", objOrderStatus.Status));
            arlSqlParameters.Add(new SqlParameter("@ConfirmationDate", objOrderStatus.ConfirmationDate));
            arlSqlParameters.Add(new SqlParameter("@ConfirmedBy", objOrderStatus.ConfirmedBy));
            arlSqlParameters.Add(new SqlParameter("@MerchantId", objOrderStatus.MerchantId));
            arlSqlParameters.Add(new SqlParameter("@DealId", objOrderStatus.DealId));
            arlSqlParameters.Add(new SqlParameter("@CustomerId", objOrderStatus.CustomerId));
            arlSqlParameters.Add(new SqlParameter("@DeliveryConfirmationDate", objOrderStatus.DeliveryConfirmationDate));
            arlSqlParameters.Add(new SqlParameter("@IsConfirmedByMerchant", objOrderStatus.IsConfirmedByMerchant));

            intActionResult = this.ExecuteActionQuery("Deal.USP_Insert_OrderStatusHistory", arlSqlParameters);
            return intActionResult;
        }
        catch (Exception exception)
        {
            throw new Exception("AdminBookingReportGateway:" + exception.Message, exception);
        }
        finally
        {
            CloseConnection();
        }
    }

    public DataTable GetBookingDetails(int intCouponId)
    {
        DataTable objDataTable = new DataTable();

        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@CouponId", intCouponId));

            objDataTable = this.ExecuteQuery("Merchant.USP_LoadBookingInfoThroughCouponId", arlSqlParameters);

            if (objDataTable.Rows.Count > 0)
            {
                return objDataTable;
            }
            else
            {
                return null;
            }
           
        }
        catch (Exception exception)
        {
            throw new Exception("AdminBookingReportGateway:" + exception.Message, exception);
        }
        finally
        {
            CloseConnection();
        }
    }

    public bool UpdateCouponDetails(string updateQuery, int couponId)
    {
        bool result = false;
        const string storedProcedureName = @"[AD].[USP_UpdateCouponDetails]";
        ArrayList values = new ArrayList()
        {            
            new SqlParameter("@updateQuery", updateQuery),
            new SqlParameter("@couponId", couponId)
        };

        try
        {
            OpenConnection();
            ExecuteActionQuery(storedProcedureName, values);
            result = true;
        }
        catch (Exception)
        {
            result = false;
        }
        finally
        {
            CloseConnection();
        }
        return result;
    }

    public bool UpdatePaymentDetails(string updateQuery, int couponId)
    {
        bool result = false;
        const string storedProcedureName = @"[AD].[USP_UpdatePaymentDetails]";
        ArrayList values = new ArrayList()
        {            
            new SqlParameter("@updateQuery", updateQuery),
            new SqlParameter("@couponId", couponId)
        };

        try
        {
            OpenConnection();
            ExecuteActionQuery(storedProcedureName, values);
            result = true;
        }
        catch (Exception)
        {
            result = false;
        }
        finally
        {
            CloseConnection();
        }
        return result;
    }

    public DataTable LoadBookingReportsWithTopRows(EOC_PropertyBean eocPropertyBean, string topRow)
    {
        DataTable objDataTable = new DataTable();
        try
        {
            
            OpenConnection();
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

            objDataTable = this.ExecuteQuery("Reports.USP_LoadBookingReports", arlSQLParameters);

           

        }
        catch
        {
            throw;
        }
        finally
        {
            this.CloseConnection();
        }
        return objDataTable;
    }

    public DataTable LoadBookingReportsOPSUniqueUserCount(string FromDate, string ToDate, string p, string strBasedOn)
    {
        DataTable objDataTable = new DataTable();
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();


            arlSQLParameters.Add(new SqlParameter("@FromDate", FromDate));
            arlSQLParameters.Add(new SqlParameter("@ToDate", ToDate));
            arlSQLParameters.Add(new SqlParameter("@Status", p));
            arlSQLParameters.Add(new SqlParameter("@BasedOn", p));

            objDataTable = this.ExecuteQuery("Reports.USP_LoadBookingReportsOPSUniqueUserCount", arlSQLParameters);

        }
        catch(Exception ex)
        {
            
        }
        finally
        {
            this.CloseConnection();
        }
        return objDataTable;
    }

    public DataTable LoadBookingReportsUniqueUserCount(string FromDate, string ToDate, string p, string strBasedOn)
    {
        try
        {
            OpenConnection();
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
        finally
        {
            this.CloseConnection();
        }
    }

    public DataTable LoadBookingReportsNewUniqueUserCount(string FromDate, string ToDate, string p, string strBasedOn)
    {
        DataTable objDataTable = new DataTable();
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();


            arlSQLParameters.Add(new SqlParameter("@FromDate", FromDate));
            arlSQLParameters.Add(new SqlParameter("@ToDate", ToDate));
            arlSQLParameters.Add(new SqlParameter("@Status", p));
            arlSQLParameters.Add(new SqlParameter("@BasedOn", strBasedOn));

            objDataTable = this.ExecuteQuery("Reports.USP_LoadBookingReportsNewUniqueUserCount", arlSQLParameters);


        }
        catch
        {
            throw;
        }
        finally
        {
            this.CloseConnection();
        }


        return objDataTable;
    }

    public DataTable LoadRecord_DealtitleWithIdOrTitle(int IsDealId, string SearchData)
    {
        try
        {
            OpenConnection();

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

    public DataTable LoadBookingReportsStatusCountWithDateRange(string FromDate, string ToDate, string IsDone, string strBasedOn)
    {
        DataTable objDataTable = new DataTable();
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@FromDate", FromDate));
            arlSQLParameters.Add(new SqlParameter("@ToDate", ToDate));
            arlSQLParameters.Add(new SqlParameter("@IsDone", IsDone));
            arlSQLParameters.Add(new SqlParameter("@BasedOn", strBasedOn));

            objDataTable = this.ExecuteQuery("Reports.USP_LoadBookingReportsStatusCount", arlSQLParameters);

          

        }
        catch
        {
            throw;
        }
        finally
        {
            this.CloseConnection();
        }
        return objDataTable;
    }

    public DataTable GetLastBookingInfo(string FromDate, string ToDate, string DealId, string Top)
    {
        DataTable objDataTable = new DataTable();
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@FromDate", FromDate));
            arlSQLParameters.Add(new SqlParameter("@ToDate", ToDate));
            arlSQLParameters.Add(new SqlParameter("@DealId", DealId));
            arlSQLParameters.Add(new SqlParameter("@Top", DealId));

            objDataTable = this.ExecuteQuery("[Reports].[USP_GetLastBookingInfoForAdmin]", arlSQLParameters);



        }
        catch
        {
            throw;
        }
        finally
        {
            this.CloseConnection();
        }
        return objDataTable;
    }
	
	public DataTable GetTotalOrder(string DealTitle, string FromDate, string ToDate, string MobileNo, string Email, string BookingCode, string CustomerName, string PaymentType, string PaymentStatus, string IsDone, string CompanyID, string BasedOn, string TopRow, bool IsMotherDeal)
    {
        DataTable objDataTable = new DataTable();
        try
        {

            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@DealTitle", DealTitle));
            arlSQLParameters.Add(new SqlParameter("@FromDate", FromDate));
            arlSQLParameters.Add(new SqlParameter("@ToDate", ToDate));
            arlSQLParameters.Add(new SqlParameter("@Mobile", MobileNo));
            arlSQLParameters.Add(new SqlParameter("@Email", Email));
            arlSQLParameters.Add(new SqlParameter("@BookingCode", BookingCode));
            arlSQLParameters.Add(new SqlParameter("@CustomerName", CustomerName));
            arlSQLParameters.Add(new SqlParameter("@PaymentType", PaymentType));
            arlSQLParameters.Add(new SqlParameter("@PaymentStatus", PaymentStatus));
            arlSQLParameters.Add(new SqlParameter("@IsMotherDeal", IsMotherDeal));
            arlSQLParameters.Add(new SqlParameter("@IsDone", IsDone));
            arlSQLParameters.Add(new SqlParameter("@Top", TopRow));
            arlSQLParameters.Add(new SqlParameter("@Company", CompanyID));
            arlSQLParameters.Add(new SqlParameter("@BasedOn", BasedOn));

            objDataTable = this.ExecuteQuery("Reports.USP_LoadBookingReports", arlSQLParameters);



        }
        catch
        {
            throw;
        }
        finally
        {
            this.CloseConnection();
        }
        return objDataTable;
    }


    public bool UpdateCrmOrder(string CouponId, string GSizes, string GColors, int GCouponQtn, string GCustomerBillingAddress, string GCustomerMobile, int GDeliveryDist, int NDeliveryCharge, string UpdatedBy, string GPaymentType, string GCardType, string GPaymentStatus, int NPaymentAmount)
    {
        int isUpdated = 0;
        try
        {

            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@CouponId", CouponId));
            arlSQLParameters.Add(new SqlParameter("@Sizes", GSizes));
            arlSQLParameters.Add(new SqlParameter("@Colors", GColors));
            arlSQLParameters.Add(new SqlParameter("@CouponQtn", GCouponQtn));
            arlSQLParameters.Add(new SqlParameter("@CustomerBillingAddress", GCustomerBillingAddress));
            arlSQLParameters.Add(new SqlParameter("@CustomerMobile", GCustomerMobile));
            arlSQLParameters.Add(new SqlParameter("@DeliveryDist", GDeliveryDist));
            arlSQLParameters.Add(new SqlParameter("@DeliveryCharge", NDeliveryCharge));
            arlSQLParameters.Add(new SqlParameter("@UpdatedBy", UpdatedBy));
            arlSQLParameters.Add(new SqlParameter("@PaymentType", GPaymentType));
            arlSQLParameters.Add(new SqlParameter("@CardType", GCardType));
            arlSQLParameters.Add(new SqlParameter("@PaymentStatus", GPaymentStatus));
            arlSQLParameters.Add(new SqlParameter("@PaymentAmount", NPaymentAmount));

            isUpdated = this.ExecuteActionQuery("Deal.USP_UpdateCRMOrder", arlSQLParameters);



        }
        catch
        {
            throw;
        }
        finally
        {
            this.CloseConnection();
        }
        if (isUpdated > 0)
        {
            return true;
        }
        else
        {
            return false;
        }


    }




}