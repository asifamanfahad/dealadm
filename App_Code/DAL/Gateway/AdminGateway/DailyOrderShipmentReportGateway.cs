using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DailyOrderShipmentReportGateway
/// </summary>
public class DailyOrderShipmentReportGateway:ADGateway
{
	public DailyOrderShipmentReportGateway()
	{
		//
		// TODO: Add constructor logic here
		//
	}
	
	public DataTable LoadSundarbon(string fromDate, string toDate)
    {
        DataTable dt = new DataTable();
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@FromDate", fromDate));
            arlSqlParameters.Add(new SqlParameter("@ToDate", toDate));

            dt = this.ExecuteQuery("[Reports].[USP_DailyOrderShipmentReport_Sundarbon]", arlSqlParameters);

            return dt;
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
	
    public DataTable Load_DailyShipmentOrder(string fromDate, string toDate)
    {
        DataTable dt = new DataTable();
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@FromDate", fromDate));
            arlSqlParameters.Add(new SqlParameter("@ToDate", toDate));

            dt = this.ExecuteQuery("[Reports].[USP_DailyOrderShipmentReport]", arlSqlParameters);

            return dt;
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

    public DataTable Load_AddedBackLogs(string fromDate, string toDate)
    {
        DataTable dt = new DataTable();
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@FromDate", fromDate));
            arlSqlParameters.Add(new SqlParameter("@ToDate", toDate));

            dt = this.ExecuteQuery("[Reports].[AddedBackLogs_DailyOrderShipmentReport]", arlSqlParameters);

            return dt;
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

    public DataTable ConfirmedOrderByCrm(string fromDate, string toDate)
    {
        DataTable dt = new DataTable();
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@FromDate", fromDate));
            arlSqlParameters.Add(new SqlParameter("@ToDate", toDate));

            dt = this.ExecuteQuery("[Reports].[USP_DailyOrderShipmentReport_ConfirmedOrderByCrm]", arlSqlParameters);

            return dt;
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

    public DataTable TotalM1(string fromDate, string toDate)
    {
        DataTable dt = new DataTable();
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@FromDate", fromDate));
            arlSqlParameters.Add(new SqlParameter("@ToDate", toDate));

            dt = this.ExecuteQuery("[Reports].[USP_DailyOrderShipmentReport_TotalM1]", arlSqlParameters);

            return dt;
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

    public DataTable TotalM2(string fromDate, string toDate)
    {
        DataTable dt = new DataTable();
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@FromDate", fromDate));
            arlSqlParameters.Add(new SqlParameter("@ToDate", toDate));

            dt = this.ExecuteQuery("[Reports].[USP_DailyOrderShipmentReport_TotalM2]", arlSqlParameters);

            return dt;
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

    public DataTable BindLoadTotalShipment(string fromDate, string toDate)
    {
        DataTable dt = new DataTable();
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@FromDate", fromDate));
            arlSqlParameters.Add(new SqlParameter("@ToDate", toDate));

            dt = this.ExecuteQuery("[Reports].[USP_DailyOrderShipmentReport_TotalShipment]", arlSqlParameters);

            return dt;
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

    public DataTable LoadShipMentOfPreviousDay(string fromDate, string toDate)
    {
        DataTable dt = new DataTable();
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@FromDate", fromDate));
            arlSqlParameters.Add(new SqlParameter("@ToDate", toDate));

            dt = this.ExecuteQuery("[Reports].[USP_DailyOrderShipmentReport_ShipMentOfPreviousDay]", arlSqlParameters);

            return dt;
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

    public DataTable Load_SaCourier(string fromDate, string toDate)
    {
        DataTable dt = new DataTable();
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@FromDate", fromDate));
            arlSqlParameters.Add(new SqlParameter("@ToDate", toDate));

            dt = this.ExecuteQuery("[Reports].[USP_DailyOrderShipmentReport_SaCourier]", arlSqlParameters);

            return dt;
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

    public DataTable Load_ECourier(string fromDate, string toDate)
    {
        DataTable dt = new DataTable();
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@FromDate", fromDate));
            arlSqlParameters.Add(new SqlParameter("@ToDate", toDate));

            dt = this.ExecuteQuery("[Reports].[USP_DailyOrderShipmentReport_ECourier]", arlSqlParameters);

            return dt;
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

    public DataTable LoadContinental(string fromDate, string toDate)
    {
        DataTable dt = new DataTable();
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@FromDate", fromDate));
            arlSqlParameters.Add(new SqlParameter("@ToDate", toDate));

            dt = this.ExecuteQuery("[Reports].[USP_DailyOrderShipmentReport_Continental]", arlSqlParameters);

            return dt;
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

    public DataTable LoadOthers(string fromDate, string toDate)
    {
        DataTable dt = new DataTable();
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@FromDate", fromDate));
            arlSqlParameters.Add(new SqlParameter("@ToDate", toDate));

            dt = this.ExecuteQuery("[Reports].[USP_DailyOrderShipmentReport_Others]", arlSqlParameters);

            return dt;
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