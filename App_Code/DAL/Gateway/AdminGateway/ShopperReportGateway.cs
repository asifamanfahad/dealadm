using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ShopperReportGateway
/// </summary>
public class ShopperReportGateway:ADGateway
{
	public ShopperReportGateway()
	{
		//
		// TODO: Add constructor logic here
		//
	}


	 public DataTable CustomerSearchCollectionReport(string Keyword)
    {
     

        DataTable dtReport = new DataTable();
        try
        {
            OpenConnection();

            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@SearchKeyword", Keyword));
            dtReport = this.ExecuteQuery("[AD].[CustomerSearchCollection]", arlSqlParameters);

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

    public string CountShopper(string dateFrom, string dateTo)
    {
        string CountShopper = "";

        DateTime endDate = Convert.ToDateTime(dateTo).AddDays(1);
        dateTo = String.Format("{0:MM/dd/yyyy}", endDate);

        DataTable objDataTable = new DataTable();
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@FromDate", dateFrom));
            arlSqlParameters.Add(new SqlParameter("@ToDate", dateTo));

            objDataTable = this.ExecuteQuery("[Reports].[USP_CountShopper]", arlSqlParameters);


            CountShopper = objDataTable.Rows[0][0].ToString();

            return CountShopper;

            
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


    public DataTable ShopperTime(string dateFrom, string dateTo, int Limit)
    {
        DateTime endDate = Convert.ToDateTime(dateTo).AddDays(1);
        dateTo = String.Format("{0:MM/dd/yyyy}", endDate);

        DataTable dtReport = new DataTable();
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@FromDate", dateFrom));
            arlSqlParameters.Add(new SqlParameter("@ToDate", dateTo));
            arlSqlParameters.Add(new SqlParameter("@Limit", Limit));

            dtReport = this.ExecuteQuery("[Reports].[USP_ReturnShopper]", arlSqlParameters);

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


    public DataTable ShopperMultiProduct(string dateFrom, string dateTo)
    {
        DateTime endDate = Convert.ToDateTime(dateTo).AddDays(1);
        dateTo = String.Format("{0:MM/dd/yyyy}", endDate);

        DataTable dtReport = new DataTable();
        try
        {
            OpenConnection();

            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@FromDate", dateFrom));
            arlSqlParameters.Add(new SqlParameter("@ToDate", dateTo));

            dtReport = this.ExecuteQuery("[Reports].[USP_ShopperMultiProduct]", arlSqlParameters);

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