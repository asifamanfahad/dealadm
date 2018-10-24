using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MultiCatDealGateway
/// </summary>
public class MultiCatDealGateway:ADGateway
{
	public MultiCatDealGateway()
	{
		//
		// TODO: Add constructor logic here
		//
	}
   	
	public int UpdateMultipleCommission(string commission, string dealId)
    {
        int ActionResult = 0;
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Clear();

            arlSqlParameters.Add(new SqlParameter("@dealId", dealId));
            arlSqlParameters.Add(new SqlParameter("@commission", commission));

            ActionResult = this.ExecuteActionQuery("Deal.USP_UpdateMultipleCommission", arlSqlParameters);
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
	
	public int UpdateRecord_DealCategory(string dealCategory, string strDealIdList, string isCategorized, string updatedBy)
    {
        int result = 0;
        const string storedProcedureName = @"[Deal].[USP_Update_Deals_By_Id_List]";

        ArrayList values = new ArrayList()
        {
            new SqlParameter("@DealCategory", dealCategory),
            new SqlParameter("@DealIdList", strDealIdList),
            new SqlParameter("@IsCategorized", isCategorized),
            new SqlParameter("@UserId", updatedBy)
        };

        try
        {
            OpenConnection();
            result = ExecuteActionQuery(storedProcedureName, values);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            CloseConnection();              
        }
        return result;
    }
	
    public int Multicat_DealId_Check(MultiCategory aMultiCategory, string dealId)
    {
        int ActionResult = 0;
        try
        {            
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Clear();
            arlSqlParameters.Add(new SqlParameter("@CategoryId", aMultiCategory.CategoryID));
            arlSqlParameters.Add(new SqlParameter("@SubCategoryId", aMultiCategory.SubCategoryID));
            arlSqlParameters.Add(new SqlParameter("@dealId", dealId));
            arlSqlParameters.Add(new SqlParameter("@SubSubCategoryId", aMultiCategory.SubSubCategoryID));
            

            DataTable dt = this.ExecuteQuery("Deal.USP_GetMultiCatDealId", arlSqlParameters);
            if (dt.Rows.Count>0)
            {
                ActionResult = Convert.ToInt32(dt.Rows[0][0]); 
            }
            else
            {
                ActionResult = 0;
            }
           
            
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

    public int Insert_MulticatDeal(MultiCategory aMultiCategory, string dealId)
    {
        int ActionResult = 0;
        try
        {
            OpenConnection();

            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Clear();
            arlSqlParameters.Add(new SqlParameter("@CategoryId", aMultiCategory.CategoryID));
            arlSqlParameters.Add(new SqlParameter("@SubCategoryId", aMultiCategory.SubCategoryID));
            arlSqlParameters.Add(new SqlParameter("@dealId", dealId));
            arlSqlParameters.Add(new SqlParameter("@SubSubCategoryId", aMultiCategory.SubSubCategoryID));
            

            ActionResult = this.ExecuteActionQuery("Deal.USP_InsertMultiCatDealId", arlSqlParameters);

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

    public int Delete_MulticatDeal(int dealId)
    {
        int ActionResult = 0;
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Clear();
          
            arlSqlParameters.Add(new SqlParameter("@MulticatId", dealId));
           
            ActionResult = this.ExecuteActionQuery("Deal.USP_DeleteMultiCatDealId", arlSqlParameters);

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
}