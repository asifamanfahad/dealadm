using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

/// <summary>
/// Summary description for AD_Users_Gateway
/// </summary>
public class AD_Users_Gateway : ADGateway
{
    public AD_Users_Gateway()
        
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable Show_AllUsers(int UserId)
    {
        
        try
        {
            OpenConnection();
            ArrayList objArray = new ArrayList();
            objArray.Add(new SqlParameter("@UserId", UserId));
            DataTable objData = this.ExecuteQuery("AD.USP_User_ShowData", objArray);
            return objData;
        }
        catch (Exception ex)
        {
            throw new Exception("Gateway Error:", ex);
        }
        finally
        {
            CloseConnection();
        }
    }

    public int Insert_User(AD_Users objUser)
    {
        
        int result=0;
        try
        {
            OpenConnection();
            ArrayList objInsertionArray = new ArrayList();
            objInsertionArray.Add(new SqlParameter("@UserName", objUser.userName));
            objInsertionArray.Add(new SqlParameter("@FullName", objUser.fullName));
            objInsertionArray.Add(new SqlParameter("@Passwrd", objUser.passWord));
            objInsertionArray.Add(new SqlParameter("@PostedOn", objUser.postedOn));
            objInsertionArray.Add(new SqlParameter("@AdminType",objUser.adminType));
            objInsertionArray.Add(new SqlParameter("@IsActive", objUser.isActive));
            objInsertionArray.Add(new SqlParameter("@PostedBy", objUser.postedBy));
            //objInsertionArray.Add(new SqlParameter("@UpdatedBy", objUser.updateBy));
            objInsertionArray.Add(new SqlParameter("@PersonalEmail",objUser.email));
            objInsertionArray.Add(new SqlParameter("@Mobile", objUser.mobileNo));
            objInsertionArray.Add(new SqlParameter("@BloodGroup", objUser.bloodGroup));
            objInsertionArray.Add(new SqlParameter("@Address", objUser.address));
            objInsertionArray.Add(new SqlParameter("@Gender", objUser.gender));

            result = ExecuteActionQuery("AD.USP_User_InsertData", objInsertionArray);
            
        }
        catch(Exception ex)
        {
        }
        finally
            {
                CloseConnection();
            }
        return result;
    }

    public int Update_User(AD_Users objUser,int uId)
    {

        int result = 0;
        try
        {
            OpenConnection();
            ArrayList objUpdateArray = new ArrayList();
            objUpdateArray.Add(new SqlParameter("@UserName", objUser.userName));
            objUpdateArray.Add(new SqlParameter("@FullName", objUser.fullName));
            objUpdateArray.Add(new SqlParameter("@Passwrd", objUser.passWord));
            //objUpdateArray.Add(new SqlParameter("@PostedOn", objUser.postedOn));
            objUpdateArray.Add(new SqlParameter("@AdminType", objUser.adminType));
            objUpdateArray.Add(new SqlParameter("@IsActive", objUser.isActive));
            //objUpdateArray.Add(new SqlParameter("@PostedBy", objUser.postedBy));
            objUpdateArray.Add(new SqlParameter("@UpdatedBy", objUser.updateBy));
            objUpdateArray.Add(new SqlParameter("@PersonalEmail", objUser.email));
            objUpdateArray.Add(new SqlParameter("@Mobile", objUser.mobileNo));
            objUpdateArray.Add(new SqlParameter("@BloodGroup", objUser.bloodGroup));
            objUpdateArray.Add(new SqlParameter("@Address", objUser.address));
            //objUpdateArray.Add(new SqlParameter("@Gender", objUser.gender));
            objUpdateArray.Add(new SqlParameter("@UserId",uId));

            result = ExecuteActionQuery("AD.USP_User_UpdateData", objUpdateArray);

        }
        catch (Exception ex)
        {
        }
        finally
        {
            CloseConnection();
        }
        return result;
    }
}