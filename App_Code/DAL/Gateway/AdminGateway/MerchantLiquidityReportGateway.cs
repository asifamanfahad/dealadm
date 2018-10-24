using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for MerchantLiquidityGateway
/// </summary>
public class MerchantLiquidityReportGateway:ADGateway
{
	public MerchantLiquidityReportGateway()
	{
		//
		// TODO: Add constructor logic here
		//
	}

	
	 public DataTable GetLiveMerchantNames()
    {
        DataTable dataTable;
        const string storedProcedureName = @"[Reports].[USP_MerchantLiveNames]";

        try
        {
            OpenConnection();
            dataTable = ExecuteQuery(storedProcedureName, null);
            return dataTable.Rows.Count > 0 ? dataTable : null;

        }
        catch (Exception)
        {
            return null;
        }
        finally
        {
            CloseConnection();
        }
    }

    public DataTable GetActiveMerchantNames(string fromDate, string toDate)
    {
        DataTable dataTable;
        const string storedProcedureName = @"[Reports].[USP_MerchantActiveNames]";
        ArrayList values = new ArrayList()
        {            
            new SqlParameter("@FromDate", fromDate),
            new SqlParameter("@ToDate", toDate)
        };

        try
        {
            OpenConnection();
            dataTable = ExecuteQuery(storedProcedureName, values);
            return dataTable.Rows.Count > 0 ? dataTable : null;

        }
        catch (Exception)
        {
            return null;
        }
        finally
        {
            CloseConnection();
        }
    }

    public DataTable GetNewMerchantNames(string fromDate, string toDate)
    {
        DataTable dataTable;
        const string storedProcedureName = @"[Reports].[USP_MerchantJoinedNewNames]";
        ArrayList values = new ArrayList()
        {            
            new SqlParameter("@FromDate", fromDate),
            new SqlParameter("@ToDate", toDate)
        };

        try
        {
            OpenConnection();
            dataTable = ExecuteQuery(storedProcedureName, values);
            return dataTable.Rows.Count > 0 ? dataTable : null;

        }
        catch (Exception)
        {
            return null;
        }
        finally
        {
            CloseConnection();
        }
    }
	
public DataTable LoadMerchantLiquidityInMerchantPanelData(string strStatus, string strFromDate, string strToDate, string strCompanyId,string strModel)
    {
        DataTable dtReport = new DataTable();
        try
        {
            OpenConnection();

            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@status", strStatus));
            arlSqlParameters.Add(new SqlParameter("@fromDate", strFromDate));
            arlSqlParameters.Add(new SqlParameter("@toDate", strToDate));
            arlSqlParameters.Add(new SqlParameter("@merchantId", strCompanyId));
            arlSqlParameters.Add(new SqlParameter("@model", strModel));

            dtReport = this.ExecuteQuery("Reports.USP_MerchantLiquidityInMerchantPanel", arlSqlParameters);

            return dtReport;


        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            CloseConnection();
        }
    }

    public string CountLiveMerchant(string dateFrom, string dateTo)
    {
        string liveMerchant = "";
        DataTable objDataTable = new DataTable();
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@FromDate", dateFrom));
            arlSqlParameters.Add(new SqlParameter("@ToDate", dateTo));

            objDataTable = this.ExecuteQuery("Reports.USP_CountMerchantLive", arlSqlParameters);

            liveMerchant = objDataTable.Rows[0][0].ToString();

            return liveMerchant;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

        finally
        {
            CloseConnection();
        }


    }

    public string CountNewMerchant(string dateFrom, string dateTo)
    {
        string newMerchant = "";
        DataTable objDataTable = new DataTable();
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@FromDate", dateFrom));
            arlSqlParameters.Add(new SqlParameter("@ToDate", dateTo));

            objDataTable = this.ExecuteQuery("Reports.USP_CountMerchantJoinedNew", arlSqlParameters);

            newMerchant = objDataTable.Rows[0][0].ToString();

            return newMerchant;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

        finally
        {
            CloseConnection();
        }


    }

    public string CountActiveMerchant(string dateFrom, string dateTo)
    {
        string activeMerchant = "";
        DataTable objDataTable = new DataTable();
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@FromDate", dateFrom));
            arlSqlParameters.Add(new SqlParameter("@ToDate", dateTo));

            objDataTable = this.ExecuteQuery("Reports.USP_CountMerchantActive", arlSqlParameters);

            activeMerchant = objDataTable.Rows[0][0].ToString();

            return activeMerchant;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

        finally
        {
            CloseConnection();
        }


    }



    public string CountTotalDeals()
    {
        string countDeals = "";
        DataTable objDataTable = new DataTable();
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            //arlSqlParameters.Add(new SqlParameter("@FromDate", dateFrom));
            //arlSqlParameters.Add(new SqlParameter("@ToDate", dateTo));

            objDataTable = this.ExecuteQuery("Reports.USP_CountTotalDeals", arlSqlParameters);

            countDeals = objDataTable.Rows[0][0].ToString();

            return countDeals;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

        finally
        {
            CloseConnection();
        }


    }


    public DataTable GetMerchantDailyTransactionDetail(string formDate, string toDate, string transactionCounter, string profileID)
    {

        DataTable dtReport = new DataTable();
        try
        {
            OpenConnection();

            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@FromDate", formDate));
            arlSqlParameters.Add(new SqlParameter("@ToDate", toDate));
            arlSqlParameters.Add(new SqlParameter("@TransactionQtn", transactionCounter));
            arlSqlParameters.Add(new SqlParameter("@ProfileID", profileID));

            dtReport = this.ExecuteQuery("Reports.USP_GetMerchantDailyTransaction", arlSqlParameters);

            return dtReport;


        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            CloseConnection();
        }
        
    }
}