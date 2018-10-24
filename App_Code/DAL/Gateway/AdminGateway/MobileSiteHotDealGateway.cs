using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


using System.Data.SqlClient;


/// <summary>
/// Summary description for MobileSiteHotDealGateway
/// </summary>
public class MobileSiteHotDealGateway:ADGateway
{
	public MobileSiteHotDealGateway()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable UpdateDealPriority(String dealId, String dealPriority)
    {
        try
        {
            OpenConnection();

            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@dealId", dealId));
            arlSQLParameters.Add(new SqlParameter("@dealPriority", dealPriority));

            DataTable objDataTable = new DataTable();

            objDataTable = this.ExecuteQuery("[Deal].[USP_Update_DealPriority]", arlSQLParameters);
            return objDataTable;

        }
        catch
        {
            throw;
        }
        finally
        {
            this.CloseConnection();
        }
    }


    public DataTable LoadAllMobileSiteHotDeals()
    {
        try
        {
            OpenConnection();
            return ExecuteQuery(
                strProcedureName: @"[Deal].[USP_LoadAllMobileSiteHotDeal]",
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

    public bool UpdateMobileSiteDeal(ArrayList parameters)
    {
        try
        {
            OpenConnection();
            ExecuteActionQuery(
                strProcedureName: @"[Deal].[USP_UpdateMobileSiteDeal]", 
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

    public bool AddNewHotDeals(ArrayList parameters)
    {
        try
        {
            OpenConnection();
            ExecuteActionQuery(
                strProcedureName: @"[Deal].[USP_UpdateHotDealForCrazyDeal]",
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
}