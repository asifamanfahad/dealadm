using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for MonthlyTransactionReportM1Gateway
/// </summary>
public class MonthlyTransactionReportM1Gateway : ADGateway
{
	public MonthlyTransactionReportM1Gateway()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable LoadMonthlyTransactionReportBasedOnConfirmOrderM1(string Month, string Year, string OrderBy)
    {
        try
        {
            OpenConnection();

            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@MonthName", Month));
            arlSQLParameters.Add(new SqlParameter("@YearName", Year));
            arlSQLParameters.Add(new SqlParameter("@SortedBy", OrderBy));

            DataTable objDataTable = new DataTable();

            objDataTable = this.ExecuteQuery("Reports.USP_LoadMonthlyTransactionReportBasedOnConfirmOrderByPercentM1", arlSQLParameters);
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


    public DataTable MonthlyTransactionReportM1(string Month, string Year, string OrderBy)
    {
        try
        {
            OpenConnection();

            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@MonthName", Month));
            arlSQLParameters.Add(new SqlParameter("@YearName", Year));
            arlSQLParameters.Add(new SqlParameter("@SortedBy", OrderBy));

            DataTable objDataTable = new DataTable();

            objDataTable = this.ExecuteQuery("[Reports].[USP_MonthlyTransactionReportM1]", arlSQLParameters);
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


    public DataTable MonthlyOrderUniqueDealM1(string Month, string Year)
    {
        try
        {
            OpenConnection();

            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@MonthName", Month));
            arlSQLParameters.Add(new SqlParameter("@YearName", Year));

            DataTable objDataTable = new DataTable();

            objDataTable = this.ExecuteQuery("[Reports].[USP_MonthlyOrderUniqueDealM1]", arlSQLParameters);
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


    public DataTable MonthlyTransactionReportfirmOrderDetailsM1(int ProfileId, int MonthName, int YearName)
    {
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@ProfileId", ProfileId));
            arlSQLParameters.Add(new SqlParameter("@MonthName", MonthName));
            arlSQLParameters.Add(new SqlParameter("@YearName", YearName));
            return this.ExecuteQuery("[Reports].[USP_MonthlyTransactionReportfirmOrderDetailsM1]", arlSQLParameters);
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

    public DataTable MonthlyTransactionReport_M1_DealWise(string ProfileId, string MonthName, string YearName)
    {
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@ProfileId", ProfileId));
            arlSQLParameters.Add(new SqlParameter("@MonthName", MonthName));
            arlSQLParameters.Add(new SqlParameter("@YearName", YearName));
            return this.ExecuteQuery("[Reports].[USP_MonthlyTransactionReport_M1_DealWise]", arlSQLParameters);
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

            objDataTable = this.ExecuteQuery("[Reports].[USP_DeliverySpeed]", arlSQLParameters);
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

            objDataTable = this.ExecuteQuery("[Reports].[USP_DeliverySpeed_OutSideDhaka]", arlSQLParameters);
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




    public DataTable MonthlySummaryReport(string Month, string Year, string IsDone)
    {
        try
        {
            OpenConnection();

            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@MonthName", Month));
            arlSQLParameters.Add(new SqlParameter("@YearName", Year));
            arlSQLParameters.Add(new SqlParameter("@IsDone", IsDone));

            DataTable objDataTable = new DataTable();

            objDataTable = this.ExecuteQuery("[Reports].[USP_MonthlySummaryReport]", arlSQLParameters);
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