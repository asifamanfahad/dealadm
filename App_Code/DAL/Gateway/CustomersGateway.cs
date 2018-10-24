using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for CustomersGateway
/// </summary>
public class CustomersGateway : ADGateway
{
    private string email;

	public CustomersGateway()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public CustomersGateway(string email)
    {
        this.email = email;
    }        

    public bool InsertNewToken(string token)
    {   
        bool result = false;        
        const string storedProcedureName = @"[Deal].[USP_Update_InsertPasswordResetToken]";
        ArrayList values = new ArrayList()
        {
            new SqlParameter("@email", email), 
            new SqlParameter("@token", token)
        };

        try
        {            
            OpenConnection();
            ExecuteActionQuery(storedProcedureName, values);
            result = true;
        }
        catch (Exception)
        {
            result = false;
        }
        finally
        {
            CloseConnection();            
        }
        return result;
    }    

    public bool IsValidToken(string token)
    {
        bool isValid = false;
        const string storedProcedureName = @"[Deal].[USP_IsValidPasswordResetToken]";
        ArrayList values = new ArrayList()
        {
            new SqlParameter("@token", token)
        };
                
        try
        {
            OpenConnection();
            var dataTable = ExecuteQuery(storedProcedureName, values);
            isValid = ((int) dataTable.Rows[0][0]) == 1;
        }
        catch (Exception)
        {
            isValid = false;
        }
        finally
        {
            CloseConnection();
        }
                               
        return isValid;
    }

    public bool UpdatePassword(string newPassword, string token)
    {
        bool result = false;
        const string storedProcedureName = @"[Deal].[USP_UpdatePasswordRemoveToken]";
        ArrayList values = new ArrayList()
        {            
            new SqlParameter("@token", token),
            new SqlParameter("@password", newPassword)
        };

        try
        {
            OpenConnection();
            ExecuteActionQuery(storedProcedureName, values);
            result = true;
        }
        catch (Exception)
        {
            result = false;
        }
        finally
        {
            CloseConnection();   
        }
        return result;
    }

    /*  Code Added on 25-April-2015 For My Ajkerdeal;  */

    public DataTable GetCustomerInfo(int customerId)
    {
        DataTable dataTable = new DataTable();
        const string storedProcedureName = @"[Deal].[USP_CustomerInfo]";
        ArrayList values = new ArrayList()
        {            
            new SqlParameter("@CustomerId", customerId)
        };

        try
        {
            OpenConnection();
            dataTable = this.ExecuteQuery(storedProcedureName, values);
            return dataTable.Rows.Count > 0 ? dataTable : null;

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

    public DataTable GetDistrictNames()
    {
        DataTable dataTable = new DataTable();
        const string storedProcedureName = @"[Deal].[USP_LoadAllDistrictForSite]";

        try
        {
            OpenConnection();
            dataTable = this.ExecuteQuery(storedProcedureName, null);
            return dataTable.Rows.Count > 0 ? dataTable : null;

        }
        catch (Exception exception)
        {
            return null;
        }
        finally
        {
            CloseConnection();
        }
    }

    public DataTable GetLocationNames()
    {
        DataTable dataTable = new DataTable();
        const string storedProcedureName = @"[USP_LoadLocations]";

        try
        {
            OpenConnection();
            dataTable = ExecuteQuery(storedProcedureName, null);
            return dataTable.Rows.Count > 0 ? dataTable : null;

        }
        catch (Exception exception)
        {
            return null;
        }
        finally
        {
            CloseConnection();
        }
    }

    public bool UpdateAccount(ArrayList values)
    {
        bool result = false;
        const string storedProcedureName = @"[Deal].[USP_MyAjkerDeal_UpdateRecord_2]";
        try
        {
            OpenConnection();
            ExecuteActionQuery(storedProcedureName, values);
            result = true;
        }
        catch (Exception)
        {
            result = false;
        }
        finally
        {
            CloseConnection();
        }
        return result;
    }

    public DataTable RetrievePassword()
    {
        DataTable dataTable = new DataTable();
        const string storedProcedureName = @"[Deal].[USP_RetrievePassword]";
        ArrayList values = new ArrayList()
        {            
            new SqlParameter("@CEmail", email)
        };

        try
        {
            OpenConnection();
            dataTable = this.ExecuteQuery(storedProcedureName, values);
            return dataTable.Rows.Count > 0 ? dataTable : null;

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

    public bool ChangePassword(string newPassword)
    {
        bool result = false;
        const string storedProcedureName = @"[Deal].[USP_MyAjkerDeal_ChangePassword]";
        string updatedOn = DateTime.Now.ToString();
        ArrayList values = new ArrayList()
        {            
            new SqlParameter("@CEmail", email),
            new SqlParameter("@Passwrd", newPassword),
            new SqlParameter("@UpdatedOn", updatedOn)
        };

        try
        {
            OpenConnection();
            ExecuteActionQuery(storedProcedureName, values);
            result = true;
        }
        catch (Exception)
        {
            result = false;
        }
        finally
        {
            CloseConnection();
        }
        return result;
    }

    /*  Code Added on 26-April-2015 For Babli Apu;  */

    public int UpdateCustomerAddress(string customerID, string customerAddress)
    {
        int result = 0;
        const string storedProcedureName = @"[Deal].[USP_UpdateCustomerAddress]";
        ArrayList values = new ArrayList()
        {            
            new SqlParameter("@CustomerId", customerID),
            new SqlParameter("@CAddress", customerAddress)
        };

        try
        {
            OpenConnection();
            result = ExecuteActionQuery(storedProcedureName, values);
        }
        catch (Exception)
        {
            result = 0;
        }
        finally
        {
            CloseConnection();
        }
        return result;
    }
}