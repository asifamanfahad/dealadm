using System;
using System.Activities.Statements;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ModelOneReportGateway
/// </summary>
public class ModelOneReportGateway : ADGateway
{
    public ModelOneReportGateway()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetModelOneProcessCount(ArrayList parameters)
    {
        try
        {
            OpenConnection();
            return ExecuteQuery(
                strProcedureName: @"[Reports].[USP_ModelOneProcessCount]",
                arlSQLParameters: parameters);
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

    public DataTable GetDetailsViaDate(ArrayList parameters)
    {
        try
        {
            OpenConnection();
            return ExecuteQuery(
                strProcedureName: @"[Reports].[USP_ModelOneProcessDetailsViaDate]",
                arlSQLParameters: parameters);
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

    public DataTable GetCouponDetails(ArrayList parameters)
    {
        try
        {
            OpenConnection();
            return ExecuteQuery(
                strProcedureName: @"[Reports].[USP_ServiceExperinceViaCouponId]",
                arlSQLParameters: parameters);
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

    public DataTable GetServiceExperienceViaDateRange(ArrayList parameters)
    {
        try
        {
            OpenConnection();
            return ExecuteQuery(
                strProcedureName: @"[Reports].[USP_ServiceExperinceViaDateRange]",
                arlSQLParameters: parameters);
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

    public DataTable GetServiceExperienceViaDateAndFlag(ArrayList parameters)
    {
        try
        {
            OpenConnection();
            return ExecuteQuery(
                strProcedureName: @"[Reports].[ServiceExperinceViaDateAndFlag]",
                arlSQLParameters: parameters);
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

    public bool SoldOutProduct(ArrayList parameters)
    {
        try
        {
            OpenConnection();
            ExecuteActionQuery(
                strProcedureName: @"[Deal].[USP_UpdateMultipleDealIdForDealSoldOut]",
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