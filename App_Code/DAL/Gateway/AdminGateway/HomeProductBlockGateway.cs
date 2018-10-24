using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HomeProductBlockGateway
/// </summary>
public class HomeProductBlockGateway:ADGateway
{
	public HomeProductBlockGateway()
	{
		//
		// TODO: Add constructor logic here
		//
	}
	
	public DataTable GetHomeProduct()
    {
        const string storedProcedureName = @"[Deal].[USP_HomeProductLoad]";

        try
        {
            OpenConnection();
            DataTable dataTable = ExecuteQuery(storedProcedureName, null);
            return dataTable.Rows.Count > 0 ? dataTable : null;

        }
        catch (Exception)
        {
            return null;
        }
        finally
        {
            CloseConnection();
        }
    }

    public bool AddToProductBlock(int categoryId, int subCategoryId, string className, 
        string offerImageName, string routeCategoryNameEng, string banglaCategoryName, 
        int limit, int counter, int orderBy, int updatedBy, string dealIds)
    {
        const string storedProcedureName = @"[Deal].[USP_AddHomeProductBlock]";
        ArrayList values = new ArrayList()
        {
            new SqlParameter("@categoryId", categoryId),
            new SqlParameter("@subcategoryid", subCategoryId),
            new SqlParameter("@className", className),
            new SqlParameter("@offerImageName", offerImageName),
            new SqlParameter("@routeCategoryNameEng", routeCategoryNameEng),
            new SqlParameter("@banglaCategoryName", banglaCategoryName),
            new SqlParameter("@limit", limit),
            new SqlParameter("@counter", counter),
            new SqlParameter("@orderBy", orderBy),
            new SqlParameter("@updatedBy", updatedBy),
            new SqlParameter("@DealIds", dealIds),
        };

        try
        {
            OpenConnection();
            ExecuteActionQuery(storedProcedureName, values);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
        finally
        {
            CloseConnection();
        }
    }

    public bool UpdateProductBlock(int id, int categoryId, int subCategoryId, string className,
        string offerImageName, string routeCategoryNameEng, string banglaCategoryName,
        int orderBy, int updatedBy, string dealIds)
    {
        const string storedProcedureName = @"[Deal].[USP_UpdateHomeProductBlock]";
        ArrayList values = new ArrayList()
        {
            new SqlParameter("@id", id),
            new SqlParameter("@categoryId", categoryId),
            new SqlParameter("@subcategoryid", subCategoryId),
            new SqlParameter("@className", className),
            new SqlParameter("@offerImageName", offerImageName),
            new SqlParameter("@routeCategoryNameEng", routeCategoryNameEng),
            new SqlParameter("@banglaCategoryName", banglaCategoryName),
            new SqlParameter("@orderBy", orderBy),
            new SqlParameter("@updatedBy", updatedBy),
            new SqlParameter("@DealIds", dealIds),
        };

        try
        {
            OpenConnection();
            ExecuteActionQuery(storedProcedureName, values);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
        finally
        {
            CloseConnection();
        }
    }

    public bool DeleteFromProductBlock(int id)
    {
        const string storedProcedureName = @"[Deal].[USP_DeleteFromHomeProductBlock]";
        ArrayList values = new ArrayList()
        {
            new SqlParameter("@id", id)
        };

        try
        {
            OpenConnection();
            ExecuteActionQuery(storedProcedureName, values);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
        finally
        {
            CloseConnection();
        }
    }
	
    public DataTable LoadHomeProduct()
    {
        DataTable objDataTable = new DataTable();
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Clear();
            objDataTable = this.ExecuteQuery("Deal.HomeProductLoad", arlSQLParameters);
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

    public DataTable LoadCategoryName(string categoryid)
    {
        try
        {
         OpenConnection();
         ArrayList arlSqlParameters = new ArrayList();
         arlSqlParameters.Clear();
         arlSqlParameters.Add(new SqlParameter("@CategoryId", categoryid));
         DataTable dt = this.ExecuteQuery("Deal.HomeProductCategoryNameLoad", arlSqlParameters);
         return dt;
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

    public DataTable LoadSubCategoryName(string subcategoryid)
    {
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Clear();
            arlSqlParameters.Add(new SqlParameter("@SubCategoryId", subcategoryid));
            DataTable dt = this.ExecuteQuery("Deal.HomeProductSubCategoryNameLoad", arlSqlParameters);
            return dt;
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

    public void InsertHomeProduct(int categoryId, int subCategoryId, string classname, string banglacategoryname, int orderby, string offerimagename, string routecategorynameEng, int limit, int count, string updateby, string postedon, string dealIds)
    {
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();

            arlSqlParameters.Clear();
            arlSqlParameters.Add(new SqlParameter("@categoryId", categoryId));
            arlSqlParameters.Add(new SqlParameter("@subCategoryId", subCategoryId));
            arlSqlParameters.Add(new SqlParameter("@classname", classname));
            arlSqlParameters.Add(new SqlParameter("@banglacategoryname", banglacategoryname));
            arlSqlParameters.Add(new SqlParameter("@orderby", orderby));
            arlSqlParameters.Add(new SqlParameter("@offerimagename", offerimagename));
            arlSqlParameters.Add(new SqlParameter("@routecategorynameEng", routecategorynameEng));
            arlSqlParameters.Add(new SqlParameter("@limit", limit));
            arlSqlParameters.Add(new SqlParameter("@counts", count));
            arlSqlParameters.Add(new SqlParameter("@updateby", updateby));
            arlSqlParameters.Add(new SqlParameter("@postedon", postedon));
            arlSqlParameters.Add(new SqlParameter("@dealIds", dealIds));

            this.ExecuteQuery("Deal.HomeProductInsert", arlSqlParameters);
          
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

    public void DeleteHomeProduct()
    {
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();

            arlSqlParameters.Clear();

            this.ExecuteQuery("Deal.HomeProductDelete", arlSqlParameters);

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

    public DataTable GetEnglishCategoryName(int categoryId)
    {
        try
        {
            try
            {
                OpenConnection();
                ArrayList arlSqlParameters = new ArrayList();
                arlSqlParameters.Clear();
                arlSqlParameters.Add(new SqlParameter("@categoryId", categoryId));
                DataTable dt = this.ExecuteQuery("Deal.HomeProductEngCategoryNameLoad", arlSqlParameters);
                return dt;
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
        catch (Exception)
        {
            
            throw;
        }
    }
	
	// Kajal
	
	public DataTable GetHomeProductWithDealIds()
    {        
        const string storedProcedureName = @"[Deal].[USP_HomeProductLoadWithDealIds]";

        try
        {
            OpenConnection();
            DataTable dataTable = ExecuteQuery(storedProcedureName, null);
            return dataTable.Rows.Count > 0 ? dataTable : null;

        }
        catch (Exception)
        {
            return null;
        }
        finally
        {
            CloseConnection();
        }
    }

    public DataTable GetCategoriesFromHomeProductBlock()
    {
        const string storedProcedureName = @"[Deal].[USP_GetCategoriesFromHomeProductBlock]";

        try
        {
            OpenConnection();
            DataTable dataTable = ExecuteQuery(storedProcedureName, null);
            return dataTable.Rows.Count > 0 ? dataTable : null;

        }
        catch (Exception)
        {
            return null;
        }
        finally
        {
            CloseConnection();
        }
    }

    public DataTable GetSubCategoriesFromHomeProductBlock(string categoryId)
    {
        const string storedProcedureName = @"[Deal].[USP_GetSubCategoriesFromHomeProductBlock]";
        ArrayList values = new ArrayList()
        {
            new SqlParameter("@CategoryId", categoryId)
        };

        try
        {
            OpenConnection();
            DataTable dataTable = ExecuteQuery(storedProcedureName, values);
            return dataTable.Rows.Count > 0 ? dataTable : null;

        }
        catch (Exception)
        {
            return null;
        }
        finally
        {
            CloseConnection();
        }
    }

    public bool UpdateDealIdsForHomeProductBlock(int categoryId, int subcategoryId, string dealIds)
    {        
        const string storedProcedureName = @"[Deal].[USP_UpdateDealIdsForHomeProductBlock]";
        ArrayList values = new ArrayList()
        {
            new SqlParameter("@CategoryId", categoryId), 
            new SqlParameter("@SubcategoryId", subcategoryId),
            new SqlParameter("@DealIds", dealIds)
        };

        try
        {
            OpenConnection();
            ExecuteActionQuery(storedProcedureName, values);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
        finally
        {
            CloseConnection();
        }
    }
}