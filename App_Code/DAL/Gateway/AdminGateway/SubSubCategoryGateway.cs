using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SubSubCategoryGateway
/// </summary>
public class SubSubCategoryGateway : ADGateway
{
	public SubSubCategoryGateway()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable LoadRecord_Category()
    {
        DataTable objDataTable = new DataTable();
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Clear();
            objDataTable = this.ExecuteQuery("Deal.USP_LoadCategory", arlSQLParameters);
            return objDataTable;
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

    public DataTable LoadRecord_SubCategoryWithCategoryId(int categoryId)
    {
        DataTable objDataTable = new DataTable();
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Clear();
            arlSqlParameters.Add(new SqlParameter("@CategoryId", categoryId));
            objDataTable = this.ExecuteQuery("Deal.USP_LoadSubCategory", arlSqlParameters);
            return objDataTable;

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

    public int InsertSubSubCategory(int categoryId, int subCategoryId, string subSubCategoryNameBng, string subSubCategoryEnglish, int isActive, string orderby, string hit)
    {
        int intActionResult = 0;
       
        try
        {
            ArrayList arlSqlParameters = new ArrayList();
            OpenConnection();
            arlSqlParameters.Add(new SqlParameter("@categoryId", categoryId));
            arlSqlParameters.Add(new SqlParameter("@subCategoryId", subCategoryId));
            arlSqlParameters.Add(new SqlParameter("@subSubCategoryNameBng", subSubCategoryNameBng));
            arlSqlParameters.Add(new SqlParameter("@subSubCategoryEnglish", subSubCategoryEnglish));
            arlSqlParameters.Add(new SqlParameter("@isActive", isActive));
            arlSqlParameters.Add(new SqlParameter("@orderby", orderby));
            arlSqlParameters.Add(new SqlParameter("@hit", hit));

            intActionResult = this.ExecuteActionQuery("Deal.SubSubCategoryInsert", arlSqlParameters);

        }
        catch (Exception )
        {           
            throw;
        }
        finally 
        {
           CloseConnection(); 
        }
        return intActionResult;
    }


    public DataTable LoadSubSubCategory(int categoryId, int subCategoryId)
    {
        try
        {
            DataTable objDataTable = new DataTable();
            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();
            arlSqlParameter.Clear();
            arlSqlParameter.Add(new SqlParameter("@categoryId", categoryId));
            arlSqlParameter.Add(new SqlParameter("@subCategoryId", subCategoryId));
            objDataTable = ExecuteQuery("Deal.LoadSubSubCategory",arlSqlParameter);
            return objDataTable;
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

    public DataTable UpdateInformation(int subSubCategoryId)
    {
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Clear();

            arlSqlParameters.Add(new SqlParameter("@subSubCategoryId", subSubCategoryId));

            return this.ExecuteQuery("Deal.LoadSubSubCategoryForUpdate", arlSqlParameters);
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

    public int UpdateSubSubCategory(int subSubCategoryId, int categoryId, int subCategoryId, string subSubCategoryNameBng, string subSubCategoryEnglish, int isActive, string @orderby, string hit)
    {
        int intActionResult = 0;

        try
        {
            ArrayList arlSqlParameters = new ArrayList();
            OpenConnection();
            arlSqlParameters.Add(new SqlParameter("@subSubCategoryId", subSubCategoryId));
            arlSqlParameters.Add(new SqlParameter("@categoryId", categoryId));
            arlSqlParameters.Add(new SqlParameter("@subCategoryId", subCategoryId));
            arlSqlParameters.Add(new SqlParameter("@subSubCategoryNameBng", subSubCategoryNameBng));
            arlSqlParameters.Add(new SqlParameter("@subSubCategoryEnglish", subSubCategoryEnglish));
            arlSqlParameters.Add(new SqlParameter("@isActive", isActive));
            arlSqlParameters.Add(new SqlParameter("@orderby", orderby));
            arlSqlParameters.Add(new SqlParameter("@hit", hit));

            intActionResult = this.ExecuteActionQuery("Deal.SubSubCategoryUpdate", arlSqlParameters);

        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            CloseConnection();
        }
        return intActionResult;
    }
}