using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BrandNameGateWay
/// </summary>
public class BrandNameGateWay : ADGateway
{
	public BrandNameGateWay()
	{
		//
		// TODO: Add constructor logic here
		//
	}
   

    public DataTable LoadBrandName()
    {
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Clear();

            return this.ExecuteQuery("Deal.Load_Brands", arlSqlParameters);
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

    public int InsertBrandName(int BrandId,string brandnamebng, string brandnameeng)
    {
        int IsActive = 1;
        int ActionResult = 0;
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Clear();
            arlSqlParameters.Add(new SqlParameter("@BrandId", BrandId));
            arlSqlParameters.Add(new SqlParameter("@brandnamebng", brandnamebng));
            arlSqlParameters.Add(new SqlParameter("@brandnameeng", brandnameeng));
            arlSqlParameters.Add(new SqlParameter("@IsActive", IsActive));
            ActionResult = this.ExecuteActionQuery("Deal.BrandNameInsert", arlSqlParameters);
        }
        catch (Exception)
        {

            throw;
        }
        finally
        {
            CloseConnection();
        }
        return ActionResult;
    }

    public DataTable LoadRecoardForUpdate(int brandId)
    {
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Clear();
            arlSqlParameters.Add(new SqlParameter("@BrandId", brandId));
            return this.ExecuteQuery("Deal.USP_LoadBrandNameForUpdate", arlSqlParameters);
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

    public int UpdateBrandName(int brandId, string brandnamebng, string brandnameeng)
    {
        int ActionResult = 0;
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Clear();
            arlSqlParameters.Add(new SqlParameter("@BrandId", brandId));
            arlSqlParameters.Add(new SqlParameter("@BrandName", brandnamebng));
            arlSqlParameters.Add(new SqlParameter("@BrandNameEng", brandnameeng));
            ActionResult = this.ExecuteActionQuery("Deal.USP_BrandNameUpdate", arlSqlParameters);
        }
        catch (Exception)
        {

            throw;
        }
        finally
        {
            CloseConnection();
        } 
        return ActionResult;
    }

    public int MaxID(string columnName, string tableName)
    {

        try
        {
            OpenConnection();
            DataTable GetmaxID = new DataTable();
            int maxID = 0;

            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@ID", columnName));
            arlSQLParameters.Add(new SqlParameter("@TableName", tableName));


            GetmaxID = this.ExecuteQuery("Deal.USP_MaxId", arlSQLParameters);
            return Convert.ToInt32(GetmaxID.Rows[0][0]);

        }
        catch
        {
            throw;
        }
        finally
        {
            CloseConnection();
        }



    }
}