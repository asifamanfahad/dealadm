using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

/// <summary>
/// Summary description for RatingReportGateway
/// </summary>
public class RatingReportGateway:ADGateway
{
	public RatingReportGateway()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public DataTable RatingReport()
    {
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Clear();
            return this.ExecuteQuery("[Reports].[USP_RatingReport]", arlSqlParameters);
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

    public void RatingActive(string id, string StatusType)
    {
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@Id", id));
            arlSQLParameters.Add(new SqlParameter("@StatusType", StatusType));
            ExecuteQuery("[Deal].[USP_RatingActiveInactive]", arlSQLParameters);
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
}