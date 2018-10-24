using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BannerGateway
/// </summary>
public class AccountRedownload:ADGateway
{
    public AccountRedownload()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int UpdateChangeRedownload(string CouponId, string Businessmodel)
    {
        int ActionResult = 0;
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Clear();
            arlSqlParameters.Add(new SqlParameter("@CouponId", CouponId));
            arlSqlParameters.Add(new SqlParameter("@Businessmodel", Businessmodel));

            ActionResult = this.ExecuteActionQuery("Deal.USP_UpdateChangeRedownload", arlSqlParameters);
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

    public int UpdateRejectRedownload(string couponId, string businessmodel)
    {
        int ActionResult = 0;
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Clear();
            arlSqlParameters.Add(new SqlParameter("@CouponId", couponId));
            arlSqlParameters.Add(new SqlParameter("@Businessmodel", businessmodel));

            ActionResult = this.ExecuteActionQuery("Deal.USP_UpdateRejectRedownload", arlSqlParameters);
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