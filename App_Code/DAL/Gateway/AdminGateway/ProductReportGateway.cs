using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ProductReportGateway
/// </summary>
public class ProductReportGateway:ADGateway
{
	public ProductReportGateway()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public DataTable GetDealDailyTransaction(string dateFrom, string dateTo,int transactionQtn,string dealId)
    {
        DataTable dtReport = new DataTable();
        try
        {
            OpenConnection();
            ArrayList arrParameters = new ArrayList();
            arrParameters.Add(new SqlParameter("@fromDate", dateFrom));
            arrParameters.Add(new SqlParameter("@toDate", dateTo));
            arrParameters.Add(new SqlParameter("@transactionQtn", transactionQtn));
            arrParameters.Add(new SqlParameter("@dealId", dealId));

            dtReport = ExecuteQuery("Reports.USP_GetDealDailyTransaction", arrParameters);

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

    public int GetDealWatchCount(int dealID, string dateFrom, string dateTo)
    {
        int totatlWatch = 0;
        DataTable dtReport=new DataTable();
        try
        {
            OpenConnection();
            ArrayList arrParameters = new ArrayList();
            arrParameters.Add(new SqlParameter("@dealID",dealID));
            arrParameters.Add(new SqlParameter("@fromDate",dateFrom));
            arrParameters.Add(new SqlParameter("@toDate",dateTo));

            dtReport = ExecuteQuery("Reports.USP_CountDealWatchUsingDateRange", arrParameters);
            if (dtReport.Rows.Count > 0)
            {
                totatlWatch = Convert.ToInt32(dtReport.Rows[0][0]);
            }
            return totatlWatch;

        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            CloseConnection();
        }
    }
}