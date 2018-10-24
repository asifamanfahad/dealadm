using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for QuickStatsGateway
/// </summary>
public class QuickStatsGateway:ADGateway
{
	public QuickStatsGateway()
	{
		//
		// TODO: Add constructor logic here
		//
	}



    public DataTable LoadMerchantDistribution(string StartDate, string EndDate)
    {
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@StartDate", StartDate));
            arlSQLParameters.Add(new SqlParameter("@EndDate", EndDate));
            DataTable objDataTable = new DataTable();
            objDataTable = this.ExecuteQuery("[Reports].[USP_LoadMerchantDistribution]", arlSQLParameters);

            return objDataTable;
        }
        catch
        {
            throw;
        }
        finally
        {
            CloseConnection();
        }
    }
}