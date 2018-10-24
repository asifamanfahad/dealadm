using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

/// <summary>
/// Summary description for MonthlyTransactionReportM2Gateway
/// </summary>
public class MonthlyTransactionReportM2Gateway : ADGateway
{
	public MonthlyTransactionReportM2Gateway()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public DataTable MonthlyDeliverySpeed(string Month, string Year, string ProfileId, string District)
    {
        try
        {
            OpenConnection();

            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@MonthName", Month));
            arlSQLParameters.Add(new SqlParameter("@YearName", Year));
            arlSQLParameters.Add(new SqlParameter("@ProfileId", ProfileId));
            arlSQLParameters.Add(new SqlParameter("@DeliveryDist", District));

            DataTable objDataTable = new DataTable();

            objDataTable = this.ExecuteQuery("[Reports].[USP_DeliverySpeed_M2]", arlSQLParameters);
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



    public DataTable MonthlyDeliverySpeed_OutSideDhaka(string Month, string Year, string ProfileId, string District)
    {
        try
        {
            OpenConnection();

            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@MonthName", Month));
            arlSQLParameters.Add(new SqlParameter("@YearName", Year));
            arlSQLParameters.Add(new SqlParameter("@ProfileId", ProfileId));
            arlSQLParameters.Add(new SqlParameter("@DeliveryDist", District));

            DataTable objDataTable = new DataTable();

            objDataTable = this.ExecuteQuery("[Reports].[USP_DeliverySpeed_OutSideDhaka_M2]", arlSQLParameters);
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


    public DataTable LoadMonthlyTransactionReportBasedOnConfirmOrderM2(string Month, string Year, string OrderBy)
    {
        try
        {
            OpenConnection();

            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@MonthName", Month));
            arlSQLParameters.Add(new SqlParameter("@YearName", Year));
            arlSQLParameters.Add(new SqlParameter("@SortedBy", OrderBy));

            DataTable objDataTable = new DataTable();

            objDataTable = this.ExecuteQuery("[Reports].[USP_LoadMonthlyTransactionReportBasedOnConfirmOrderByPercentM2]", arlSQLParameters);
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


    public DataTable MonthlyTransactionReportM2(string Month, string Year, string OrderBy)
    {
        try
        {
            OpenConnection();

            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@MonthName", Month));
            arlSQLParameters.Add(new SqlParameter("@YearName", Year));
            arlSQLParameters.Add(new SqlParameter("@SortedBy", OrderBy));

            DataTable objDataTable = new DataTable();

            objDataTable = this.ExecuteQuery("[Reports].[USP_MonthlyTransactionReportM2]", arlSQLParameters);
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



    public DataTable MonthlyOrderUniqueDealM2(string Month, string Year)
    {
        try
        {
            OpenConnection();

            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@MonthName", Month));
            arlSQLParameters.Add(new SqlParameter("@YearName", Year));

            DataTable objDataTable = new DataTable();

            objDataTable = this.ExecuteQuery("[Reports].[USP_MonthlyOrderUniqueDealM2]", arlSQLParameters);
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


    public DataTable MonthlyTransactionReport_M2_DealWise(string ProfileId, string MonthName, string YearName)
    {
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@ProfileId", ProfileId));
            arlSQLParameters.Add(new SqlParameter("@MonthName", MonthName));
            arlSQLParameters.Add(new SqlParameter("@YearName", YearName));
            return this.ExecuteQuery("[Reports].[USP_MonthlyTransactionReport_M2_DealWise]", arlSQLParameters);
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

    public DataTable MonthlyTransactionReportfirmOrderDetailsM2(int ProfileId, int MonthName, int YearName)
    {
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@ProfileId", ProfileId));
            arlSQLParameters.Add(new SqlParameter("@MonthName", MonthName));
            arlSQLParameters.Add(new SqlParameter("@YearName", YearName));
            return this.ExecuteQuery("[Reports].[USP_MonthlyTransactionReportfirmOrderDetailsM2]", arlSQLParameters);
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
}