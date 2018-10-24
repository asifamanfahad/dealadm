using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OrderUpdateOutSourceGateway
/// </summary>
public class ServiceFeedbackGateway:ADGateway
{
    public ServiceFeedbackGateway()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public int InsertIntoServiceExperience(string productQuality,string experience,string shopNextTime,string comment,string couponId,string rcvDate, string customerQuery,int postedBy)
    {
        int actionResult = 0;
        
        
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@ProductQuality", productQuality));
            arlSQLParameters.Add(new SqlParameter("@OverAllExperience", experience));
            arlSQLParameters.Add(new SqlParameter("@FurtherShopping", shopNextTime));
            arlSQLParameters.Add(new SqlParameter("@FeedbackComment", comment));
            arlSQLParameters.Add(new SqlParameter("@CouponId", couponId));
            arlSQLParameters.Add(new SqlParameter("@ReceivedDate", rcvDate));
            arlSQLParameters.Add(new SqlParameter("@CustomerQuery", customerQuery));
            arlSQLParameters.Add(new SqlParameter("@PostedBy", postedBy));

            actionResult = this.ExecuteActionQuery("[AD].[USP_InsertIntoServiceExperience]", arlSQLParameters);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            CloseConnection();
        }
        return actionResult;
    }

    public DataTable ShowAllDataForModelOne(string dateField, string fromdate, string toDate, string orderStatus, string couponId, string dateover,string top,string mobile,string email,string orerBy)
    {
        int actionResult = 0;
        DataTable dt = new DataTable();


        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@DateFieldName", dateField));
            arlSQLParameters.Add(new SqlParameter("@FromDate", fromdate));
            arlSQLParameters.Add(new SqlParameter("@ToDate", toDate));
            arlSQLParameters.Add(new SqlParameter("@OrderStatus", orderStatus));
            arlSQLParameters.Add(new SqlParameter("@BookingCode", couponId));
            arlSQLParameters.Add(new SqlParameter("@Dateover", dateover));
            arlSQLParameters.Add(new SqlParameter("@Top", top));
            arlSQLParameters.Add(new SqlParameter("@Mobile", mobile));
            arlSQLParameters.Add(new SqlParameter("@Email", email));
            arlSQLParameters.Add(new SqlParameter("@OrderBy", orerBy));

            dt = this.ExecuteQuery("[Merchant].[USP_LoadBookingReportForModelOne]", arlSQLParameters);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            CloseConnection();
        }
        return dt;
    }

    public DataTable ShowAllDataForModelOne(string dateField, string fromdate, string toDate, string orderStatus, string couponId, string dateover, string top, string mobile, string email, string orerBy,int customerQuery, string merchantId)
    {
        int actionResult = 0;
        DataTable dt = new DataTable();


        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@DateFieldName", dateField));
            arlSQLParameters.Add(new SqlParameter("@FromDate", fromdate));
            arlSQLParameters.Add(new SqlParameter("@ToDate", toDate));
            arlSQLParameters.Add(new SqlParameter("@OrderStatus", orderStatus));
            arlSQLParameters.Add(new SqlParameter("@BookingCode", couponId));
            arlSQLParameters.Add(new SqlParameter("@Dateover", dateover));
            arlSQLParameters.Add(new SqlParameter("@Top", top));
            arlSQLParameters.Add(new SqlParameter("@Mobile", mobile));
            arlSQLParameters.Add(new SqlParameter("@Email", email));
            arlSQLParameters.Add(new SqlParameter("@OrderBy", orerBy));
            arlSQLParameters.Add(new SqlParameter("@CustomerQuery", customerQuery));
            arlSQLParameters.Add(new SqlParameter("@MerchantId", merchantId));

            dt = this.ExecuteQuery("[Merchant].[USP_LoadBookingReportForModelOne_New]", arlSQLParameters);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            CloseConnection();
        }
        return dt;
    }
}