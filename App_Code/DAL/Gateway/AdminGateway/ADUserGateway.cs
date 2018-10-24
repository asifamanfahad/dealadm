using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ADUserGateway
/// </summary>
public class ADUserGateway : UTLDBHandler
{
    public ADUserGateway(): base(UTLUtilities.Database.DbConnectionString)
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int AddRecord_ADUsers(string UserName, string FullName, string Passwrd, string AdminType, string PostedBy)
    {
        int intActionResult = 0;
        int isActive = 1;
        int isDeleted = 0;
        try
        {
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@UserName ", UserName));
            arlSqlParameters.Add(new SqlParameter("@FullName ", FullName));
            arlSqlParameters.Add(new SqlParameter("@Passwrd ", Passwrd));
            arlSqlParameters.Add(new SqlParameter("@AdminType ", AdminType));
            arlSqlParameters.Add(new SqlParameter("@PostedBy", PostedBy));
           
            intActionResult = this.ExecuteActionQuery("AD.USP_AddADUsers", arlSqlParameters);
            return intActionResult;
        }
        catch (Exception ex)
        {
            throw new Exception("ADUserGateway Error:", ex);
        }
    }

    public int UpdateRecord_ADUsersByAdmin(string UserId,string UserName, string FullName, string Passwrd, string AdminType, string UpdatedBy, string IsActive)
    {
        int intActionResult = 0;
        int isActive = 1;
        int isDeleted = 0;
        try
        {
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@UserId", UserId));
            arlSqlParameters.Add(new SqlParameter("@UserName", UserName));
            arlSqlParameters.Add(new SqlParameter("@FullName", FullName));
            arlSqlParameters.Add(new SqlParameter("@Passwrd", Passwrd));
            arlSqlParameters.Add(new SqlParameter("@AdminType", AdminType));
            arlSqlParameters.Add(new SqlParameter("@UpdatedBy", UpdatedBy));
            arlSqlParameters.Add(new SqlParameter("@IsActive", IsActive));


            intActionResult = this.ExecuteActionQuery("AD.USP_UpdateADUsersByAdmin", arlSqlParameters);
            return intActionResult;
        }
        catch (Exception ex)
        {
            throw new Exception("ADUserGateway Error:", ex);
        }
    }


    public int UpdateRecord_ADUsersByUser(string UserId, string FullName, string Passwrd, string UpdatedBy)
    {
        int intActionResult = 0;
        int isActive = 1;
        int isDeleted = 0;
        try
        {
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@UserId", UserId));
            arlSqlParameters.Add(new SqlParameter("@FullName", FullName));
            arlSqlParameters.Add(new SqlParameter("@Passwrd", Passwrd));
            arlSqlParameters.Add(new SqlParameter("@UpdatedBy", UpdatedBy));

            intActionResult = this.ExecuteActionQuery("AD.USP_UpdateADUsersByUser", arlSqlParameters);
            return intActionResult;
        }
        catch (Exception ex)
        {
            throw new Exception("ADUserGateway Error:", ex);
        }
    }


    public DataTable GetADUsers(string UserId)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@UserId", UserId));

            return this.ExecuteQuery("AD.USP_GetADUsers", arlSQLParameters);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public DataTable LoadADUsers()
    {
        try
        {
            ArrayList arlSqlparameters = new ArrayList();
            
            DataTable objDatatable = this.ExecuteQuery("AD.USP_LoadADUsers", arlSqlparameters);
            return objDatatable;
        }
        catch (Exception exp)
        {
            throw new Exception("Gateway Error:", exp);
        }
    }

    public DataTable GetUserInfo(string RequestedId)
    {
        throw new NotImplementedException();
    }

    //public int GetMarchantReport(string mainIp, string localIp, string macAddress, string pcName, string userName, string passwrd, string url, string logType)
    //{
    //    int intActionResult = 0;

    //    try
    //    {
    //        ArrayList arlSqlParameters = new ArrayList();

    //        arlSqlParameters.Add(new SqlParameter("@main_ip ", mainIp));
    //        arlSqlParameters.Add(new SqlParameter("@local_ip", localIp));
    //        arlSqlParameters.Add(new SqlParameter("@mac_address", macAddress));
    //        arlSqlParameters.Add(new SqlParameter("@pc_name ", pcName));
    //        arlSqlParameters.Add(new SqlParameter("@username", userName));
    //        arlSqlParameters.Add(new SqlParameter("@passwrd", passwrd));
    //        arlSqlParameters.Add(new SqlParameter("@url", url));
    //        arlSqlParameters.Add(new SqlParameter("@log_type", logType));
    //        intActionResult = this.ExecuteActionQuery("Reports.USP_InsertLogs", arlSqlParameters);
    //        return intActionResult;
    //    }
    //    catch (Exception exp)
    //    {
    //        throw new Exception("Report Error:", exp); 
    //    }

    //}

    public DataTable CategorySubCategoryWiseCustomerEmail(string CategoryId, string subCategory)
    {
        try
        {
            ArrayList arlSqlparameters = new ArrayList();

            arlSqlparameters.Add(new SqlParameter("@CategoryId ", CategoryId));
            arlSqlparameters.Add(new SqlParameter("@SubCategoryId ", subCategory));

            DataTable objDatatable = this.ExecuteQuery("Reports.USP_LoadEmailAddressThroughCategory", arlSqlparameters);
            return objDatatable;
        }
        catch (Exception exp)
        {
            throw new Exception("Gateway Error:", exp);
        }
       
    } 
}