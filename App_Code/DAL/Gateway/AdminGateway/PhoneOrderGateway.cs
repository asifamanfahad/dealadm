using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PhoneOrderGateway
/// </summary>
public class PhoneOrderGateway : ADGateway
{
	public PhoneOrderGateway()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable LoadPhoneOrderInformation(string emailAddress)
    {
        DataTable objDatatable = new DataTable();

        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@emailAddress", emailAddress));

            objDatatable = this.ExecuteQuery("Deal.USP_LoadCustomerInfoForCRMPhoneOrder", arlSQLParameters);

            return objDatatable;
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