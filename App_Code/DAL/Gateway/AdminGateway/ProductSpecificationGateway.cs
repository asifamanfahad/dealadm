using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductSpecificationGateway
/// </summary>
public class ProductSpecificationGateway:ADGateway
{
	public ProductSpecificationGateway()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable LoadAllProductSpecification()
    {
        try
        {
            OpenConnection();
            return ExecuteQuery(
                strProcedureName: @"[Deal].[USP_LoadAllProductSpecification]",
                arlSQLParameters: null);
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

    public bool AddNewProductSpecification(ArrayList parameters)
    {
        try
        {
            OpenConnection();
            ExecuteActionQuery(
                strProcedureName: @"[Deal].[USP_AddNewProductSpecification]",
                arlSQLParameters: parameters);
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

    public bool UpdateProductSpecification(ArrayList parameters)
    {
        try
        {
            OpenConnection();
            ExecuteActionQuery(
                strProcedureName: @"[Deal].[USP_UpdateProductSpecification]",
                arlSQLParameters: parameters);
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

    public DataTable LoadAllSpecification()
    {
        try
        {
            OpenConnection();
            return ExecuteQuery(
                strProcedureName: @"[Deal].[USP_LoadAllSpecification]",
                arlSQLParameters: null);
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

    public void AddMultipleSpecification(int specificationId, int dealId)
    {
        try
        {
            OpenConnection();

            ArrayList arlSqlArrayList = new ArrayList();
            arlSqlArrayList.Clear();
            arlSqlArrayList.Add(new SqlParameter("@specificationId", specificationId));
            arlSqlArrayList.Add(new SqlParameter("@dealId", dealId));

           ExecuteActionQuery("Deal.USP_InsertMultipleSpecification", arlSqlArrayList);
        }
        catch (Exception)
        {
           
        }
        finally
        {
            CloseConnection();
        }
    }

    public DataTable LoadSpecificationForUpdate(int intDealId)
    {
        DataTable aDataTable = new DataTable();
        try
        {
            OpenConnection();

            ArrayList arlSqlArrayList = new ArrayList();
            arlSqlArrayList.Clear();
            arlSqlArrayList.Add(new SqlParameter("@dealId", intDealId));

            aDataTable = ExecuteQuery("Deal.USP_LoadSpecificationById", arlSqlArrayList);
        }
        catch (Exception)
        {

        }
        finally
        {
            CloseConnection();
        }
        return aDataTable;
    }

    public void DeleteMultipleSpecification(int intDealId)
    {
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@DealId", intDealId));
            ExecuteActionQuery("Deal.USP_DeleteMultipleSpecification", arlSQLParameters);

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