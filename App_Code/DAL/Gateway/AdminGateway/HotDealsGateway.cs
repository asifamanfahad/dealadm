using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HotDealsGateway
/// </summary>
public class HotDealsGateway : ADGateway
{
    public HotDealsGateway()
    {        
    }

    public DataTable LoadAllCompanies()
    {
        try
        {
            OpenConnection();
            return ExecuteQuery(
                strProcedureName: @"[Deal].[USP_LoadAllCompanies]",
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

    public DataTable LoadAllHotDeals()
    {
        try
        {
            OpenConnection();
            return ExecuteQuery(
                strProcedureName: @"[Deal].[USP_LoadAllHotDeals]",
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

    public bool AddNewHotDeals(ArrayList parameters)
    {
        try
        {
            OpenConnection();
            ExecuteActionQuery(
                strProcedureName: @"[Deal].[USP_AddNewHotDeals]", 
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

    public bool UpdateHotDeals(ArrayList parameters)
    {
        try
        {
            OpenConnection();
            ExecuteActionQuery(
                strProcedureName: @"[Deal].[USP_UpdateHotDeals]",
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

    public bool DeleteHotDeals(ArrayList parameters)
    {
        try
        {
            OpenConnection();
            ExecuteActionQuery(
                strProcedureName: @"[Deal].[USP_DeleteHotDeals]",
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