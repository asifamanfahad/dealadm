using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

/// <summary>
/// Summary description for CorporateGateway
/// </summary>
public class CorporateGateway : ADGateway
{
	public DataTable GetAllLiveCouriers(){

        DataTable objDatatable = new DataTable();

        try {

            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();

            objDatatable = this.ExecuteQuery("AD.USP_LoadAllCouriers", arlSqlParameters);
            return objDatatable;
        }
        catch (Exception exception)
        {
            throw new Exception("SiteCorporateGateway Error:" + exception.Message, exception);
        }
        finally
        {
            CloseConnection();
        }
    
    }



public DataTable GetCouriersInfo( string CourierId)
    {

        DataTable objDatatable = new DataTable();

        try
        {

            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@CourierId", CourierId));
            objDatatable = this.ExecuteQuery("AD.USP_GetCourierInfoToDeliver", arlSqlParameters);
            return objDatatable;
        }
        catch (Exception exception)
        {
            throw new Exception("SiteCorporateGateway Error:" + exception.Message, exception);
        }
        finally
        {
            CloseConnection();
        }

    }
	
	public DataTable StatusCountDateWiseFromCouponsOrderCount(string DateFieldName, string MerchantId, string OrderStatus, string FromDate, string ToDate, string DealId)
    {
        int intActionResult = 0;
        DataTable objDataTable = new DataTable();

        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@DateFieldName", DateFieldName));
            arlSqlParameters.Add(new SqlParameter("@MerchantId", MerchantId));
            arlSqlParameters.Add(new SqlParameter("@OrderStatus", OrderStatus));
            arlSqlParameters.Add(new SqlParameter("@FromDate", FromDate));
            arlSqlParameters.Add(new SqlParameter("@ToDate", ToDate));
            arlSqlParameters.Add(new SqlParameter("@DealId", DealId));

            objDataTable = this.ExecuteQuery("Merchant.USP_OrderStatusCountDateWiseFromCouponTableTotalDealCount", arlSqlParameters);
            return objDataTable;
        }
        catch (Exception exception)
        {
            throw new Exception("SiteCorporateGateway Error:" + exception.Message, exception);
        }
        finally
        {
            CloseConnection();
        }
    }
	
	public DataTable GetDealsInfoForMerchant(int intDealId)
    {
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@DealId", intDealId));

            return this.ExecuteQuery("Merchant.USP_GetDealsInfo", arlSQLParameters);

        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
        finally
        {
            CloseConnection();
        }
    }

    public int AddRecordDealsForMerchant(DealsManager dealsManager)
    {
        int intActionResult = 0;
        int DealId = 0;
        string dtmPostedOn = DateTime.Now.ToString();

        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@DealTitle", dealsManager.DealTitle));
            arlSQLParameters.Add(new SqlParameter("@BulletDescription", dealsManager.BulletDescription));

            arlSQLParameters.Add(new SqlParameter("@RegularPrice", dealsManager.RegularPrice));

            arlSQLParameters.Add(new SqlParameter("@DealPrice", dealsManager.DealPrice));

            arlSQLParameters.Add(new SqlParameter("@DealDiscount", dealsManager.DealDiscount));

            arlSQLParameters.Add(new SqlParameter("@CategoryId", dealsManager.CategoryId));

            arlSQLParameters.Add(new SqlParameter("@SubCategoryId", dealsManager.SubCategoryId));

            arlSQLParameters.Add(new SqlParameter("@ImageCount", dealsManager.ImageCount));

            arlSQLParameters.Add(new SqlParameter("@CommissionPerCoupon", dealsManager.CommissionPerCoupon));

            arlSQLParameters.Add(new SqlParameter("@FolderName", dealsManager.FolderName));

            arlSQLParameters.Add(new SqlParameter("@ProfileID", dealsManager.ProfileID));

            arlSQLParameters.Add(new SqlParameter("@UserId", dealsManager.UserId));
            arlSQLParameters.Add(new SqlParameter("@Sizes", dealsManager.Sizes));
            arlSQLParameters.Add(new SqlParameter("@ProductColor", dealsManager.ProductColor));
            arlSQLParameters.Add(new SqlParameter("@SubSubCategoryId", dealsManager.SubSubCategoryId));

            SqlParameter parameter = new SqlParameter("@DealId", SqlDbType.Int);

            //Set the parameter direction as output
            parameter.Direction = ParameterDirection.Output;

            arlSQLParameters.Add(parameter);

            intActionResult = this.ExecuteActionQuery("[Merchant].[USP_InsertDealsWithMultiCat]", arlSQLParameters);
            DealId = Convert.ToInt32(parameter.Value);




        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
        finally
        {
            CloseConnection();
        }


        return DealId;
    }


	public int UpdateRecord_Deals_ByCorporate(DealsManager dealsManager)
    {
        int intActionResult = 0;
        string dtmPostedOn = DateTime.Now.ToString();

        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@DealTitle", dealsManager.DealTitle));
            arlSQLParameters.Add(new SqlParameter("@BulletDescription", dealsManager.BulletDescription));

            arlSQLParameters.Add(new SqlParameter("@RegularPrice", dealsManager.RegularPrice));
            arlSQLParameters.Add(new SqlParameter("@DealPrice", dealsManager.DealPrice));
            arlSQLParameters.Add(new SqlParameter("@DealDiscount", dealsManager.DealDiscount));

            arlSQLParameters.Add(new SqlParameter("@DealId", dealsManager.DealId));

            arlSQLParameters.Add(new SqlParameter("@CategoryId", dealsManager.CategoryId));

            arlSQLParameters.Add(new SqlParameter("@SubCategoryId", dealsManager.SubCategoryId));

            arlSQLParameters.Add(new SqlParameter("@CommissionPerCoupon", dealsManager.CommissionPerCoupon));

            arlSQLParameters.Add(new SqlParameter("@ImageCount", dealsManager.ImageCount));
			arlSQLParameters.Add(new SqlParameter("@Sizes", dealsManager.Sizes));
			arlSQLParameters.Add(new SqlParameter("@ProductColor", dealsManager.ProductColor));
            arlSQLParameters.Add(new SqlParameter("@SubSubCategoryId", dealsManager.SubSubCategoryId));

            intActionResult = this.ExecuteActionQuery("Deal.USP_UpdateDeals_ByCorporateDealsEntry", arlSQLParameters);
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
        finally
        {
            CloseConnection();
        }

        return intActionResult;
    }
	
	public DataTable GetDealsInfo(int intDealId)
    {
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@DealId", intDealId));

            return this.ExecuteQuery("Deal.USP_GetDealInfoDealsEntry", arlSQLParameters);
            //return this.ExecuteQuery("Deal.USP_GetDealsInfo", arlSQLParameters);
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
        finally
        {
            CloseConnection();
        }
    }
	
	public int AddRecord_Deals_ByCorporate(DealsManager dealsManager)
    {
        int intActionResult = 0;
        int DealId = 0;
        string dtmPostedOn = DateTime.Now.ToString();

        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@DealTitle", dealsManager.DealTitle));
            arlSQLParameters.Add(new SqlParameter("@BulletDescription", dealsManager.BulletDescription));
            
            arlSQLParameters.Add(new SqlParameter("@RegularPrice", dealsManager.RegularPrice));

            arlSQLParameters.Add(new SqlParameter("@DealPrice", dealsManager.DealPrice));

            arlSQLParameters.Add(new SqlParameter("@DealDiscount", dealsManager.DealDiscount));

            arlSQLParameters.Add(new SqlParameter("@CategoryId", dealsManager.CategoryId));

            arlSQLParameters.Add(new SqlParameter("@SubCategoryId", dealsManager.SubCategoryId));

            arlSQLParameters.Add(new SqlParameter("@ImageCount", dealsManager.ImageCount));

            arlSQLParameters.Add(new SqlParameter("@CommissionPerCoupon", dealsManager.CommissionPerCoupon));

            arlSQLParameters.Add(new SqlParameter("@FolderName", dealsManager.FolderName));

            arlSQLParameters.Add(new SqlParameter("@ProfileID", dealsManager.ProfileID));

            arlSQLParameters.Add(new SqlParameter("@UserId", dealsManager.UserId));
          	arlSQLParameters.Add(new SqlParameter("@Sizes", dealsManager.Sizes));
			arlSQLParameters.Add(new SqlParameter("@ProductColor", dealsManager.ProductColor));
			
            intActionResult = this.ExecuteActionQuery("Deal.USP_InsertDealsWithMultiCat_ByCorporateDealsEntry", arlSQLParameters);

        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
        finally
        {
            CloseConnection();
        }


        return intActionResult;
    }
	
    public DataTable GetMerchantLiveDeals(string MerchantId)
    {
        int intActionResult = 0;
        DataTable objDataTable = new DataTable();

        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@MerchantId", MerchantId));

            objDataTable = this.ExecuteQuery("Merchant.USP_LoadLiveDeals", arlSqlParameters);
            return objDataTable;
        }
        catch (Exception exception)
        {
            throw new Exception("SiteCorporateGateway Error:" + exception.Message, exception);
        }
        finally
        {
            CloseConnection();
        }
    }
	
	public DataTable GetMerchantManagementSearch(int profileId, int liveSoldout, string dealtitleTextBox, string dealid,  int topShow)
    {
        int intActionResult = 0;
        DataTable objDataTable = new DataTable();

        try
        {
            OpenConnection(); 
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@ProfileId", profileId));
            arlSqlParameters.Add(new SqlParameter("@LiveSoldout", liveSoldout));
            arlSqlParameters.Add(new SqlParameter("@Dealtitle", dealtitleTextBox));
            arlSqlParameters.Add(new SqlParameter("@Dealid", dealid));
            arlSqlParameters.Add(new SqlParameter("@Top", topShow));
            objDataTable = this.ExecuteQuery("Merchant.USP_LoadDealManagementSearch", arlSqlParameters);
            return objDataTable;
        }
        catch (Exception exception)
        {
            throw new Exception("SiteCorporateGateway Error:" + exception.Message, exception);
        }
        finally
        {
            CloseConnection();
        }
    }
	
    public int CountSalesFeedDateWiseFromCouponTable(string DateFieldName, string CompanyId, string FromDate, string ToDate, string Order_Status, string DealId, string BookingCode)
    {
        int intActionResult = 0;

      DataTable objDataTable = new DataTable();

        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@DateFieldName", DateFieldName));
            arlSqlParameters.Add(new SqlParameter("@MerchantId", CompanyId));
            arlSqlParameters.Add(new SqlParameter("@FromDate", FromDate));
            arlSqlParameters.Add(new SqlParameter("@ToDate", ToDate));
            arlSqlParameters.Add(new SqlParameter("@OrderStatus", Order_Status));
            arlSqlParameters.Add(new SqlParameter("@DealId", DealId));
            arlSqlParameters.Add(new SqlParameter("@BookingCode", BookingCode));

            objDataTable = this.ExecuteQuery("Merchant.USP_CountSalesFeedFromCouponTable", arlSqlParameters);

            intActionResult = Convert.ToInt32(objDataTable.Rows[0][0]);

            return intActionResult;
        }
        catch (Exception exception)
        {
            throw new Exception("SiteCorporateGateway Error:" + exception.Message, exception);
        }
        finally
        {
            CloseConnection();
        }
    }

    public DataTable GetSiteCorporateProductStatusInfoProductWise(DateTime FromDate, DateTime ToDate, int OrderStatus, string CompanyId)
    {
        int intActionResult = 0;
        DataTable objDataTable = new DataTable();

        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@OrderDateFrom", FromDate));
            arlSqlParameters.Add(new SqlParameter("@OrderDateTo", ToDate));
            arlSqlParameters.Add(new SqlParameter("@OrderStatus ", OrderStatus));
            arlSqlParameters.Add(new SqlParameter("@MerchantId", CompanyId));


            objDataTable = this.ExecuteQuery("Deal.USP_Merchant_Date_Wise_OrderStatusCount", arlSqlParameters);
            return objDataTable;
        }
        catch (Exception exception)
        {
            throw new Exception("SiteCorporateGateway Error:" + exception.Message, exception);
        }
        finally
        {
            CloseConnection();
        }
    }

    public string GetCorporateTotalAmount(string CompanyId)
    {
        int intActionResult = 0;
        DataTable TotalAmount = new DataTable();
       
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@CompanyId", CompanyId));

            TotalAmount = this.ExecuteQuery("Merchant.USP_AddCurierDeliveryInfo", arlSqlParameters);
            return TotalAmount.Rows[0]["TotalAmount"].ToString();
        }
        catch (Exception exception)
        {
            throw new Exception("SiteCorporateGateway Error:" + exception.Message, exception);
        }
        finally
        {
            CloseConnection();
        }
    }

    public DataTable GetCheckName(string CompanyId)
    {
        int intActionResult = 0;
        DataTable CheckName = new DataTable();

        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@CompanyId", CompanyId));

            CheckName = this.ExecuteQuery("Merchant.USP_AddCurierDeliveryInfo", arlSqlParameters);
            return CheckName;
        }
        catch (Exception exception)
        {
            throw new Exception("SiteCorporateGateway Error:" + exception.Message, exception);
        }
        finally
        {
            CloseConnection();
        }
    }

    public DataTable GetTopSellingItem(string CompanyId)
    {
        int intActionResult = 0;
        DataTable objDataTable = new DataTable();

        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@ProfileId", CompanyId));


            objDataTable = this.ExecuteQuery("Merchant.USP_LoadTopSellingItems", arlSqlParameters);
            return objDataTable;
        }
        catch (Exception exception)
        {
            throw new Exception("SiteCorporateGateway Error:" + exception.Message, exception);
        }
        finally
        {
            CloseConnection();
        }
    }

    


    public DataTable StatusCountDateWise(string MerchantId, string OrderStatus, string FromDate, string ToDate)
    {
        int intActionResult = 0;
        DataTable objDataTable = new DataTable();

        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@MerchantId", MerchantId));
            arlSqlParameters.Add(new SqlParameter("@OrderStatus", OrderStatus));
            arlSqlParameters.Add(new SqlParameter("@FromDate", FromDate));
            arlSqlParameters.Add(new SqlParameter("@ToDate", ToDate));


            objDataTable = this.ExecuteQuery("Merchant.USP_OrderStatusCountDateWise", arlSqlParameters);
            return objDataTable;
        }
        catch (Exception exception)
        {
            throw new Exception("SiteCorporateGateway Error:" + exception.Message, exception);
        }
        finally
        {
            CloseConnection();
        }
    }

   

    public DataTable StatusCountDateWiseFromCoupons(string MerchantId, string OrderStatus, string FromDate, string ToDate, string DealId)
    {
        int intActionResult = 0;
        DataTable objDataTable = new DataTable();

        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@MerchantId", MerchantId));
            arlSqlParameters.Add(new SqlParameter("@OrderStatus", OrderStatus));
            arlSqlParameters.Add(new SqlParameter("@FromDate", FromDate));
            arlSqlParameters.Add(new SqlParameter("@ToDate", ToDate));
            arlSqlParameters.Add(new SqlParameter("@DealId", DealId));

            objDataTable = this.ExecuteQuery("Merchant.USP_OrderStatusCountDateWiseFromCouponTable", arlSqlParameters);
            return objDataTable;
        }
        catch (Exception exception)
        {
            throw new Exception("SiteCorporateGateway Error:" + exception.Message, exception);
        }
        finally
        {
            CloseConnection();
        }
    }

    public DataTable StatusCountDateWiseFromCoupons(string DateFieldName, string MerchantId, string OrderStatus, string FromDate, string ToDate, string DealId)
    {
        int intActionResult = 0;
        DataTable objDataTable = new DataTable();

        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@DateFieldName", DateFieldName));
            arlSqlParameters.Add(new SqlParameter("@MerchantId", MerchantId));
            arlSqlParameters.Add(new SqlParameter("@OrderStatus", OrderStatus));
            arlSqlParameters.Add(new SqlParameter("@FromDate", FromDate));
            arlSqlParameters.Add(new SqlParameter("@ToDate", ToDate));
            arlSqlParameters.Add(new SqlParameter("@DealId", DealId));

            objDataTable = this.ExecuteQuery("Merchant.USP_OrderStatusCountDateWiseFromCouponTable", arlSqlParameters);
            return objDataTable;
        }
        catch (Exception exception)
        {
            throw new Exception("SiteCorporateGateway Error:" + exception.Message, exception);
        }
        finally
        {
            CloseConnection();
        }
    }

    public DataTable SalesFeedDateWiseFromCouponTable(string DateFieldName, string CompanyId, string FromDate, string ToDate, string Order_Status, string DealId, string BookingCode)
    {
        int intActionResult = 0;
        DataTable objDataTable = new DataTable();

        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@DateFieldName", DateFieldName));
            arlSqlParameters.Add(new SqlParameter("@MerchantId", CompanyId));
            arlSqlParameters.Add(new SqlParameter("@FromDate", FromDate));
            arlSqlParameters.Add(new SqlParameter("@ToDate", ToDate));
            arlSqlParameters.Add(new SqlParameter("@OrderStatus", Order_Status));
            arlSqlParameters.Add(new SqlParameter("@DealId", DealId));
            arlSqlParameters.Add(new SqlParameter("@BookingCode", BookingCode));

            objDataTable = this.ExecuteQuery("Merchant.USP_LoadSalesFeedFromCouponTable", arlSqlParameters);
            return objDataTable;
        }
        catch (Exception exception)
        {
            throw new Exception("SiteCorporateGateway Error:" + exception.Message, exception);
        }
        finally
        {
            CloseConnection();
        }
    }

    public DataTable SalesFeedByOrderStatusAndDateWiseFromCouponTable(string DateFieldName, string MerchantId, string FromDate, string ToDate, string Order_Status, string DealId, string BookingCode)
    {
        int intActionResult = 0;
        DataTable objDataTable = new DataTable();

        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@DateFieldName", DateFieldName));
            arlSqlParameters.Add(new SqlParameter("@MerchantId", MerchantId));
            arlSqlParameters.Add(new SqlParameter("@FromDate", FromDate));
            arlSqlParameters.Add(new SqlParameter("@ToDate", ToDate));
            arlSqlParameters.Add(new SqlParameter("@OrderStatus", Order_Status));
            arlSqlParameters.Add(new SqlParameter("@DealId", DealId));
            arlSqlParameters.Add(new SqlParameter("@BookingCode", BookingCode));
            objDataTable = this.ExecuteQuery("Merchant.USP_LoadSalesFeedFromCouponTable", arlSqlParameters);
            return objDataTable;
        }
        catch (Exception exception)
        {
            throw new Exception("SiteCorporateGateway Error:" + exception.Message, exception);
        }
        finally
        {
            CloseConnection();
        }
    }

    public int UpdateAcknowledge( string CouponId)
    {
        int intActionResult = 0;
       
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@CouponId", CouponId));

            intActionResult = this.ExecuteActionQuery("Merchant.USP_UpdateAcknowledge", arlSqlParameters);
            return intActionResult;
        }
        catch (Exception exception)
        {
            throw new Exception("SiteCorporateGateway Error:" + exception.Message, exception);
        }
        finally
        {
            CloseConnection();
        }
    }
    public DataTable LoadBookingReportForAdmin(string DateFieldName, string CompanyId, string FromDate, string ToDate, string Order_Status, string DealId, string BookingCode, string MobileNumber, string toData, string podNumber)
    {
        int intActionResult = 0;
        DataTable objDataTable = new DataTable();

        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@DateFieldName", DateFieldName));
            arlSqlParameters.Add(new SqlParameter("@MerchantId", CompanyId));
            arlSqlParameters.Add(new SqlParameter("@FromDate", FromDate));
            arlSqlParameters.Add(new SqlParameter("@ToDate", ToDate));
            arlSqlParameters.Add(new SqlParameter("@OrderStatus", Order_Status));
            arlSqlParameters.Add(new SqlParameter("@DealId", DealId));
            arlSqlParameters.Add(new SqlParameter("@BookingCode", BookingCode));
            arlSqlParameters.Add(new SqlParameter("@Mobile", MobileNumber));
            arlSqlParameters.Add(new SqlParameter("@Top", toData));
            arlSqlParameters.Add(new SqlParameter("@PodNumber", podNumber));

            objDataTable = this.ExecuteQuery("Merchant.USP_LoadBookingReportForAdmin", arlSqlParameters);
            return objDataTable;
        }
        catch (Exception exception)
        {
            throw new Exception("SiteCorporateGateway Error:" + exception.Message, exception);
        }
        finally
        {
            CloseConnection();
        }
    }


    public DataTable SalesFeedDateWise(string CompanyId, string FromDate, string ToDate, string CouponId)
    {
        int intActionResult = 0;
        DataTable objDataTable = new DataTable();

        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@MerchantId", CompanyId));
            arlSqlParameters.Add(new SqlParameter("@FromDate", FromDate));
            arlSqlParameters.Add(new SqlParameter("@ToDate", ToDate));
            arlSqlParameters.Add(new SqlParameter("@CouponId", CouponId));

            objDataTable = this.ExecuteQuery("Merchant.USP_SalesFeedDateWise", arlSqlParameters);
            return objDataTable;
        }
        catch (Exception exception)
        {
            throw new Exception("SiteCorporateGateway Error:" + exception.Message, exception);
        }
        finally
        {
            CloseConnection();
        }
    }


    public DataTable SalesFeedDateWiseFromCouponTableWithLimit(string DateFieldName, string CompanyId, string FromDate, string ToDate, string Order_Status, string DealId, string BookingCode, string LowerLimit, string UpperLimit)
    {
        int intActionResult = 0;
        DataTable objDataTable = new DataTable();

        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@DateFieldName", DateFieldName));
            arlSqlParameters.Add(new SqlParameter("@MerchantId", CompanyId));
            arlSqlParameters.Add(new SqlParameter("@FromDate", FromDate));
            arlSqlParameters.Add(new SqlParameter("@ToDate", ToDate));
            arlSqlParameters.Add(new SqlParameter("@OrderStatus", Order_Status));
            arlSqlParameters.Add(new SqlParameter("@DealId", DealId));
            arlSqlParameters.Add(new SqlParameter("@BookingCode", BookingCode));
            arlSqlParameters.Add(new SqlParameter("@LowerLimit", LowerLimit));
            arlSqlParameters.Add(new SqlParameter("@UpperLimit", UpperLimit));

            objDataTable = this.ExecuteQuery("Merchant.USP_LoadSalesFeedFromCouponTableUsingLimit", arlSqlParameters);
            return objDataTable;
        }
        catch (Exception exception)
        {
            throw new Exception("SiteCorporateGateway Error:" + exception.Message, exception);
        }
        finally
        {
            CloseConnection();
        }
    }
}