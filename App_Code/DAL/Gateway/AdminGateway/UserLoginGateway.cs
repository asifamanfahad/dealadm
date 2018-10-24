using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for UserLoginGateway
/// </summary>
public class UserLoginGateway : ADGateway
{
    public UserLoginGateway()
    {
        //
        // TODO: Add constructor logic here
        //
    }

	public DataTable CheckLogin(string UserName)
    {
        int Result = 0;
        try
        {
            OpenConnection();

            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Clear();
            arlSqlParameters.Add(new SqlParameter("@UserName", UserName));
            return this.ExecuteQuery("[AD].[USP_CheckAllowOutsideAccess]", arlSqlParameters);
            //return Result;
        }
        catch (Exception exception)
        {
            throw ;
        }
        finally
        {
            CloseConnection();
        }
    }


    public bool IsAdminLoginValid(UserLoginProperty ObjUserLoginProperty)
    {
        bool blnFlag = false;

        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@UserName", ObjUserLoginProperty.UserName));
            arlSQLParameters.Add(new SqlParameter("@Passwrd", ObjUserLoginProperty.Password));

            DataTable objDataTable = this.ExecuteQuery("AD.USP_Admin_GetLoginInfo", arlSQLParameters);

            if (objDataTable.Rows.Count > 0)
            {
                ObjUserLoginProperty.UserId = Convert.ToInt32(objDataTable.Rows[0]["UserId"].ToString());
                ObjUserLoginProperty.UserFullName = objDataTable.Rows[0]["FullName"].ToString();
                ObjUserLoginProperty.UserName = objDataTable.Rows[0]["UserName"].ToString();
                ObjUserLoginProperty.AdminType = Convert.ToInt32(objDataTable.Rows[0]["AdminType"].ToString());


                blnFlag = true;
            }
            else
            {
                blnFlag = false;
            }
        }
        catch
        {
            throw;
        }
        finally
        {
            CloseConnection();
        }

        return blnFlag;
    }
}