using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

/// <summary>
/// Summary description for OrderFavReportGateway
/// </summary>
public class OrderFavReportGateway:ADGateway
{
	public OrderFavReportGateway()
	{
		//
		// TODO: Add constructor logic here
		//
	}
	
	 public DataTable Load_DeliveryPartnerReport(string date, string deliveryPartner)
    {
        DataTable dt = new DataTable();
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@date", date));
            arlSqlParameters.Add(new SqlParameter("@courier", deliveryPartner));

            dt = this.ExecuteQuery("[Reports].[USP_DeliveryPartnerDayWise]", arlSqlParameters);

            return dt;
        }
        catch (Exception Ex)
        {
            throw new Exception(Ex.Message);
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
	
	public string CountOrderMainSiteUnique(string FromDate, string ToDate)
    {
        string CountOrderMainSiteUnique = "";
        DataTable objDataTable = new DataTable();

        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@StartDate", FromDate));
            arlSqlParameters.Add(new SqlParameter("@EndDate", ToDate));

            objDataTable = this.ExecuteQuery("[Reports].[USP_CountOrderMainSiteUnique]", arlSqlParameters);

            CountOrderMainSiteUnique = objDataTable.Rows[0][0].ToString();

            return CountOrderMainSiteUnique;
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





public string CountOrderMobileSiteUnique(string FromDate, string ToDate)
    {
        string CountOrderMobileSiteUnique = "";
        DataTable objDataTable = new DataTable();

        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@StartDate", FromDate));
            arlSqlParameters.Add(new SqlParameter("@EndDate", ToDate));

            objDataTable = this.ExecuteQuery("[Reports].[USP_CountOrderMobileSiteUnique]", arlSqlParameters);

            CountOrderMobileSiteUnique = objDataTable.Rows[0][0].ToString();

            return CountOrderMobileSiteUnique;
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






public string CountOrderFavMainSiteUnique(string FromDate, string ToDate)
    {
        string CountFavMainSiteUnique = "";
        DataTable objDataTable = new DataTable();

        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@StartDate", FromDate));
            arlSqlParameters.Add(new SqlParameter("@EndDate", ToDate));

            objDataTable = this.ExecuteQuery("[Reports].[USP_CountFavMainSiteUnique]", arlSqlParameters);

            CountFavMainSiteUnique = objDataTable.Rows[0][0].ToString();

            return CountFavMainSiteUnique;
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





public string CountFavMobileSiteUnique(string FromDate, string ToDate)
    {
        string CountFavMobileSiteUnique = "";
        DataTable objDataTable = new DataTable();

        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@StartDate", FromDate));
            arlSqlParameters.Add(new SqlParameter("@EndDate", ToDate));

            objDataTable = this.ExecuteQuery("[Reports].[USP_CountFavMobileSiteUnique]", arlSqlParameters);

            CountFavMobileSiteUnique = objDataTable.Rows[0][0].ToString();

            return CountFavMobileSiteUnique;
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


	public DataTable MainSiteFemale(string dateFrom, string dateTo)
    {
        DataTable dtReport = new DataTable();
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@StartDate", dateFrom));
            arlSqlParameters.Add(new SqlParameter("@EndDate", dateTo));

            dtReport = this.ExecuteQuery("[Reports].[USP_OrderMainSiteFemale]", arlSqlParameters);

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



    public DataTable MainSiteMale(string dateFrom, string dateTo)
    {
        DataTable dtReport = new DataTable();
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@StartDate", dateFrom));
            arlSqlParameters.Add(new SqlParameter("@EndDate", dateTo));

            dtReport = this.ExecuteQuery("[Reports].[USP_OrderMainSiteMale]", arlSqlParameters);

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



    public DataTable MobileSiteFemale(string dateFrom, string dateTo)
    {
        DataTable dtReport = new DataTable();
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@StartDate", dateFrom));
            arlSqlParameters.Add(new SqlParameter("@EndDate", dateTo));

            dtReport = this.ExecuteQuery("[Reports].[USP_OrderMobileSiteFemale]", arlSqlParameters);

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

    public DataTable MobileSiteMale(string dateFrom, string dateTo)
    {
        DataTable dtReport = new DataTable();
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@StartDate", dateFrom));
            arlSqlParameters.Add(new SqlParameter("@EndDate", dateTo));

            dtReport = this.ExecuteQuery("[Reports].[USP_OrderMobileSiteMale]", arlSqlParameters);

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
	
    public string CountOrderMainSite(string dateFrom, string dateTo)
    {
        string CountMainSite = "";
        DataTable objDataTable = new DataTable();

        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@StartDate", dateFrom));
            arlSqlParameters.Add(new SqlParameter("@EndDate", dateTo));

            objDataTable = this.ExecuteQuery("Reports.USP_CountOrderMainSite", arlSqlParameters);

            CountMainSite = objDataTable.Rows[0][0].ToString();

            return CountMainSite;
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

    public string CountOrderMobileSite(string dateFrom, string dateTo)
    {
        string CountMobileSite = "";
        DataTable objDataTable = new DataTable();

        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@StartDate", dateFrom));
            arlSqlParameters.Add(new SqlParameter("@EndDate", dateTo));

            objDataTable = this.ExecuteQuery("Reports.USP_CountOrderMobileSite", arlSqlParameters);

            CountMobileSite = objDataTable.Rows[0][0].ToString();

            return CountMobileSite;
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

    public string CountOrderFavMainSite(string dateFrom, string dateTo)
    {
        string CountFavMainSite = "";
        DataTable objDataTable = new DataTable();

        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@StartDate", dateFrom));
            arlSqlParameters.Add(new SqlParameter("@EndDate", dateTo));

            objDataTable = this.ExecuteQuery("Reports.USP_CountFavMainSite", arlSqlParameters);

            CountFavMainSite = objDataTable.Rows[0][0].ToString();

            return CountFavMainSite;
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

    public string CountOrderFavMobileSite(string dateFrom, string dateTo)
    {
        string CountFavMobileSite = "";
        DataTable objDataTable = new DataTable();

        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@StartDate", dateFrom));
            arlSqlParameters.Add(new SqlParameter("@EndDate", dateTo));

            objDataTable = this.ExecuteQuery("Reports.USP_CountFavMobileSite", arlSqlParameters);

            CountFavMobileSite = objDataTable.Rows[0][0].ToString();

            return CountFavMobileSite;
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