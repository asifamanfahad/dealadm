using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RequisitionGateway
/// </summary>
public class RequisitionGateway:ADGateway
{
	public RequisitionGateway()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable LoadDealForRequisition(string FromDate, string ToDate, int CompanyId)
    {
        DataTable objDatatable = new DataTable();

        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@FromDate", FromDate));
            arlSQLParameters.Add(new SqlParameter("@ToDate", ToDate));
            arlSQLParameters.Add(new SqlParameter("@CompanyId", CompanyId));

            objDatatable = this.ExecuteQuery("Reports.USP_LoadRequisitionInfo", arlSQLParameters);

            return objDatatable;
        }

        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
        finally
        {
            this.CloseConnection();
        }
    }
}