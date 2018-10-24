using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OrderProcessGateway
/// </summary>
public class OrderProcessGateway:ADGateway
{
    public OrderProcessGateway()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public DataTable LoadDataForOrderProcess(string dateFieldName, string fromDate, string toDate, string orderStatus, string companyId, string dealId, string bookingCode, string paymentType,string paymentStatus, string mobileNumber, string email, string podNumber, string lowerLimit, string upperlimit)
    {
        int intActionResult = 0;
        DataTable dt = new DataTable();

        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@DateFieldName", dateFieldName));
            arlSqlParameters.Add(new SqlParameter("@FromDate", fromDate));
            arlSqlParameters.Add(new SqlParameter("@ToDate", toDate));
            arlSqlParameters.Add(new SqlParameter("@OrderStatus", orderStatus));
            arlSqlParameters.Add(new SqlParameter("@MerchantId", companyId));
            arlSqlParameters.Add(new SqlParameter("@DealId", dealId));
            arlSqlParameters.Add(new SqlParameter("@CouponId", bookingCode));
            arlSqlParameters.Add(new SqlParameter("@PaymentType", paymentType));
            arlSqlParameters.Add(new SqlParameter("@PaymentStatus", paymentStatus));
            arlSqlParameters.Add(new SqlParameter("@Mobile", mobileNumber));
            arlSqlParameters.Add(new SqlParameter("@Email", email));
            arlSqlParameters.Add(new SqlParameter("@PodNumber", podNumber));
            arlSqlParameters.Add(new SqlParameter("@LowerLimit", lowerLimit));
            arlSqlParameters.Add(new SqlParameter("@UpperLimit", upperlimit));


            dt = this.ExecuteQuery("[AD].[USP_LoadAllOrderForProcess]", arlSqlParameters);

            
        }
        catch (Exception exception)
        {
            //throw new Exception("Order Processing Error:" + exception.Message, exception);
        }
        finally
        {
            CloseConnection();
        }
        return dt;
    }
    public DataTable LoadDataForOrderProcess(string dateFieldName, string fromDate, string toDate, string orderStatus, string companyId, string dealId, string bookingCode, string paymentType, string paymentStatus, string mobileNumber, string email, string podNumber, string lowerLimit, string upperlimit, bool cross24hrs, bool isSoldOut, bool inActive)
    {
        int intActionResult = 0;
        DataTable dt = new DataTable();

        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@DateFieldName", dateFieldName));
            arlSqlParameters.Add(new SqlParameter("@FromDate", fromDate));
            arlSqlParameters.Add(new SqlParameter("@ToDate", toDate));
            arlSqlParameters.Add(new SqlParameter("@OrderStatus", orderStatus));
            arlSqlParameters.Add(new SqlParameter("@MerchantId", companyId));
            arlSqlParameters.Add(new SqlParameter("@DealId", dealId));
            arlSqlParameters.Add(new SqlParameter("@CouponId", bookingCode));
            arlSqlParameters.Add(new SqlParameter("@PaymentType", paymentType));
            arlSqlParameters.Add(new SqlParameter("@PaymentStatus", paymentStatus));
            arlSqlParameters.Add(new SqlParameter("@Mobile", mobileNumber));
            arlSqlParameters.Add(new SqlParameter("@Email", email));
            arlSqlParameters.Add(new SqlParameter("@PodNumber", podNumber));
            arlSqlParameters.Add(new SqlParameter("@LowerLimit", lowerLimit));
            arlSqlParameters.Add(new SqlParameter("@UpperLimit", upperlimit));
            arlSqlParameters.Add(new SqlParameter("@MakeDealSoldout", cross24hrs));
            arlSqlParameters.Add(new SqlParameter("@LoadSoldOut", isSoldOut));
            arlSqlParameters.Add(new SqlParameter("@LoadInactive", inActive));

            dt = this.ExecuteQuery("[AD].[USP_LoadAllOrderForProcess]", arlSqlParameters);


        }
        catch (Exception exception)
        {
            //throw new Exception("Order Processing Error:" + exception.Message, exception);
        }
        finally
        {
            CloseConnection();
        }
        return dt;
    }

    public DataTable LoadAllCompanies()
    {
        int intActionResult = 0;
        DataTable dt = new DataTable();

        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            dt = this.ExecuteQuery("[Deal].[USP_LoadAllCompanies]", arlSqlParameters);

            //return dt;
        }
        catch (Exception exception)
        {
            //throw new Exception("Order Processing Error:" + exception.Message, exception);
        }
        finally
        {
            CloseConnection();
        }
        return dt;
    }


    public DataTable LoadCompanyInformation(int CompanyProfileId)
    {
        DataTable objDataTable = new DataTable();
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Clear();
            arlSQLParameters.Add(new SqlParameter("@ProfileID", CompanyProfileId));

            return this.ExecuteQuery("Merchant.USP_LoadCompanyReportForAdmin", arlSQLParameters);

        }
        catch (Exception)
        {

            throw;
        }
        finally
        {
            CloseConnection();
        }
    }

    public DataTable LoadCompanyRequisition(string fromDate, string toDate, string companyId, string status)
    {
        DataTable objDatatable = new DataTable();

        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@FromDate", fromDate));
            arlSQLParameters.Add(new SqlParameter("@ToDate", toDate));
            arlSQLParameters.Add(new SqlParameter("@CompanyId", companyId));
            arlSQLParameters.Add(new SqlParameter("@Status", status));

            objDatatable = this.ExecuteQuery("[Reports].[USP_LoadMerchantRequisitionData]", arlSQLParameters);

            return objDatatable;
        }

        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
        finally
        {
            this.CloseConnection();
        }
    }


}