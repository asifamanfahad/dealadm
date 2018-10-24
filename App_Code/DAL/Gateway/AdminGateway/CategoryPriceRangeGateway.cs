using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CategoryPriceRangeGateway
/// </summary>
public class CategoryPriceRangeGateway : ADGateway
{
	public CategoryPriceRangeGateway()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    public void AddRecord_InsertPriceRange(int categoryId, int subCategoryId, int miniRange, int maxRange, int order, string banglaMin, string banglaMax)
    {
        int intActionResult = 0;

        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            int IsActive = 1;
            arlSQLParameters.Add(new SqlParameter("@CategoryId", categoryId));
            arlSQLParameters.Add(new SqlParameter("@SubCategoryId", subCategoryId));
            arlSQLParameters.Add(new SqlParameter("@MinimumRange", miniRange));
            arlSQLParameters.Add(new SqlParameter("@MaximumRange", maxRange));
            arlSQLParameters.Add(new SqlParameter("@Order", order));
            arlSQLParameters.Add(new SqlParameter("@IsActive", IsActive));
            arlSQLParameters.Add(new SqlParameter("@BanglaMin", banglaMin));
            arlSQLParameters.Add(new SqlParameter("@BanglaMax", banglaMax));


            ExecuteActionQuery("Deal.USP_InsertPriceRange", arlSQLParameters);
        }
        catch (Exception exception)
        {
            throw new Exception("Gateway Error:" + exception.Message, exception);
        }
        finally
        {
            CloseConnection();
        }
    }
    
    public void AddRecord_UpdatePriceRange(int category, int subCategory, int minimumRange, int maximumRange, int orderRange, string bnqmin, string bnqmax, int rangeId)
    {
        int intActionResult = 0;

        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            int IsActive = 1;
            arlSQLParameters.Add(new SqlParameter("@CategoryId", category));
            arlSQLParameters.Add(new SqlParameter("@SubCategoryId", subCategory));
            arlSQLParameters.Add(new SqlParameter("@MinimumRange", minimumRange));
            arlSQLParameters.Add(new SqlParameter("@MaximumRange", maximumRange));
            arlSQLParameters.Add(new SqlParameter("@Order", orderRange));
            arlSQLParameters.Add(new SqlParameter("@IsActive", IsActive));
            arlSQLParameters.Add(new SqlParameter("@BanglaMin", bnqmin));
            arlSQLParameters.Add(new SqlParameter("@BanglaMax", bnqmax));
            arlSQLParameters.Add(new SqlParameter("@RangeId", rangeId));


            ExecuteActionQuery("Deal.USP_UpdatePriceRange", arlSQLParameters);
        }
        catch (Exception exception)
        {
            throw new Exception("Gateway Error:" + exception.Message, exception);
        }
        finally
        {
            CloseConnection();
        }
    }
    

    public DataTable PriceRangeLoad(int Category, int SubCategory)
    {
        int intActionResult = 0;
        DataTable objDataTable = new DataTable();

        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Clear();
            arlSqlParameters.Add(new SqlParameter("@CategoryId", Category));
            arlSqlParameters.Add(new SqlParameter("@SubCategoryId", SubCategory));
            objDataTable = this.ExecuteQuery("Deal.USP_GridLoadPriceRange", arlSqlParameters);
            return objDataTable;
        }
        catch (Exception exception)
        {
            throw new Exception("SiteCorporateGateway Error:" + exception.Message, exception);
        }
        finally
        {
            CloseConnection();
        }
    }
    
    public DataTable PriceRangeUpdate(int PriceRangeID)
    {
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Clear();

            arlSqlParameters.Add(new SqlParameter("@RangeID", PriceRangeID));

            return this.ExecuteQuery("Deal.USP_LoadUpdatePriceRange", arlSqlParameters);
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
        finally
        {
            CloseConnection();
        }
    }

    public int DeleteCategoryPriceRange(int RangeID)
    {
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Clear();

            arlSqlParameters.Add(new SqlParameter("@RangeID", RangeID));

            return this.ExecuteActionQuery("Deal.USP_DeletePriceRange", arlSqlParameters);
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
        finally
        {
            CloseConnection();
        }
    }
}