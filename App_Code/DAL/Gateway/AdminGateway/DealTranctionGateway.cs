using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DealTranctionGateway
/// </summary>
public class DealTranctionGateway:ADGateway
{
	public DealTranctionGateway()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int InsertDealTranction(DataTable dt)
    {
        int intActionResult = 0;

        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@dealType", dt));

            intActionResult = this.ExecuteActionQuery("[Deal].[USP_InsertDealTranction]", arlSqlParameters);
            return intActionResult;
        }
        catch (Exception exception)
        {
            throw new Exception("DealsGateway Error:" + exception.Message, exception);
        }
        finally
        {
            CloseConnection();
        }
    }
}