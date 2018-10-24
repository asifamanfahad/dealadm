using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

/// <summary>
/// Summary description for OrderPackagedGateway
/// </summary>
public class OrderPackagedGateway:ADGateway
{
	public OrderPackagedGateway()
	{
		//
		// TODO: Add constructor logic here
		//
	}
	
	public DataTable Load_RTOReport(string fromdate, string todate, string orderstatus, int companyprofileId, string rejectreson)
    {
        DataTable objDataTable = new DataTable();
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Clear();
            arlSQLParameters.Add(new SqlParameter("@fromdate", fromdate));
            arlSQLParameters.Add(new SqlParameter("@todate", todate));
            arlSQLParameters.Add(new SqlParameter("@orderstatus", orderstatus));
            arlSQLParameters.Add(new SqlParameter("@companyid", companyprofileId));
            arlSQLParameters.Add(new SqlParameter("@reason", rejectreson));

            objDataTable = this.ExecuteQuery("Reports.USP_RTOStatusReport", arlSQLParameters); //Reports.USP_PackagedBookingReport

        }
        catch (Exception Ex)
        {
            throw new Exception("No data found ", Ex);
        }
        finally
        {
            CloseConnection();
        }
        return objDataTable;
    }
	
	
	 public DataTable Load_CouponReport_New(string fromdate, string todate, string OrderStatus)
    {
        DataTable objDataTable = new DataTable();
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Clear();
            arlSQLParameters.Add(new SqlParameter("@fromdate", fromdate));
            arlSQLParameters.Add(new SqlParameter("@todate", todate));
            arlSQLParameters.Add(new SqlParameter("@orderstatus", OrderStatus));

            objDataTable = this.ExecuteQuery("Reports.USP_RTOStatusReport", arlSQLParameters); //Reports.USP_PackagedBookingReport

        }
        catch (Exception Ex)
        {
            throw new Exception("No data found ", Ex);
        }
        finally
        {
            CloseConnection();
        }
        return objDataTable;
    }
	
	 public DataTable Load_CouponReport(int hourDiff,string OrderStatus)
    {
        DataTable objDataTable = new DataTable();
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Clear();
            arlSQLParameters.Add(new SqlParameter("@hourDiff", hourDiff));
            arlSQLParameters.Add(new SqlParameter("@OrderStatus", OrderStatus));

            objDataTable = this.ExecuteQuery("Reports.USP_StatusReport", arlSQLParameters); //Reports.USP_PackagedBookingReport

        }
        catch (Exception Ex)
        {
            throw new Exception("No data found ", Ex);
        }
        finally
        {
            CloseConnection();
        }
        return objDataTable;
    }
	
	public DataTable Load_CouponReport(int hourDiff)
    {
        DataTable objDataTable = new DataTable();
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Clear();
            arlSQLParameters.Add(new SqlParameter("@hourDiff", hourDiff));
            objDataTable = this.ExecuteQuery("Reports.USP_PackagedBookingReport", arlSQLParameters);

        }
        catch (Exception Ex)
        {
            throw new Exception("No data found ", Ex);
        }
        finally
        {
            CloseConnection();
        }
        return objDataTable;
    }
	
    public DataTable GetPackagedSheet(string customerId, string IsDone)
    {
        int intActionResult = 0;
        DataTable objDataTable = new DataTable();

        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
                       
            arlSQLParameters.Add(new SqlParameter("@CustomerId", customerId));
            arlSQLParameters.Add(new SqlParameter("@IsDone", IsDone));

            objDataTable = this.ExecuteQuery("Reports.USP_LoadPackagedSheet", arlSQLParameters);
        }
        catch (Exception exp)
        {
            throw new Exception("No data found ", exp);
        }
        finally
        {
            CloseConnection();
        }
        return objDataTable;
    }

   

}