using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ReferrerReportGateway
/// </summary>
public class ReferrerReportGateway : ADGateway
{
    public ReferrerReportGateway()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetSiteReferrerClickData(ArrayList parameters)
    {
        try
        {
            OpenConnection();
            return ExecuteQuery(
                strProcedureName: @"[Reports].[USP_GetSiteReferrerClickData]",
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
}