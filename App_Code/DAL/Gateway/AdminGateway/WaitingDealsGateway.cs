using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for WaitingDealsGateway
/// </summary>
public class WaitingDealsGateway:ADGateway
{
	public WaitingDealsGateway()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable LoadWaitingDeals(int uploadedBy)
    {
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Clear();
            arlSqlParameters.Add(new SqlParameter("@UploadedBy", uploadedBy));
            return this.ExecuteQuery("Deal.USP_LoadAllWaitingDealSalespersonWise", arlSqlParameters);
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

    public int LoadCountWaitingDeals(int uploadedBy)
    {
        int count = 0;
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Clear();
            DataTable dt = new DataTable();
            arlSqlParameters.Add(new SqlParameter("@UploadedBy", uploadedBy));
            dt = this.ExecuteQuery("[Deal].[USP_LoadCountAllWaitingDealSalespersonWise]", arlSqlParameters);
            count = Convert.ToInt32(dt.Rows[0]["CountWaitingDeals"]);
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            CloseConnection();
        }
        return count;
    }

}