using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ADInternalLiquidityGateway
/// </summary>
public class ADInternalLiquidityGateway:ADGateway
{
	public ADInternalLiquidityGateway()
	{
		//
		// TODO: Add constructor logic here
		//
	}

	public DataTable Load_CRM_Order_Report(string fromDate, string toDate)
    {
        DataTable objDataTable = new DataTable();
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@fromDate", fromDate));
            arlSQLParameters.Add(new SqlParameter("@toDate", toDate));

            objDataTable = this.ExecuteQuery("[Reports].[USP_CrmOrderReport]", arlSQLParameters);

        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
        finally
        {
            CloseConnection();
        }
        return objDataTable;
    }
	
    public DataTable Load_CRM_liquidity_Report(string fromDate, string toDate)
    {
        DataTable objDataTable = new DataTable();
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@fromDate", fromDate));
            arlSQLParameters.Add(new SqlParameter("@toDate", toDate));

            objDataTable = this.ExecuteQuery("Reports.USP_CRM_liquidity_Report", arlSQLParameters);

        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
        finally
        {
            CloseConnection();
        }
        return objDataTable;
    }
}