using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AdminCompanyGateway
/// </summary>
public class AdminCompanyGateway:ADGateway
{
	public AdminCompanyGateway()
	{
		//
		// TODO: Add constructor logic here
		//
	}
	
	public DataTable LoadMerchantDetails(string profileid)
    {
        DataTable objDataTable = new DataTable();
        try
        {
            ArrayList arlSQLParameters = new ArrayList();           
            OpenConnection();
            arlSQLParameters.Add(new SqlParameter("@profileid", profileid));

            objDataTable = ExecuteQuery("Merchant.USP_LoadMerchantDetails", arlSQLParameters);
        }
        catch (Exception)
        {
             
        }
        finally
        {
            CloseConnection();
        }
        return objDataTable;
    }
	
	private int InsertCompanyForAdmin(EOC_PropertyBean eocPropertyBean)
    {
         int intActionResult = 0;
        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            OpenConnection();
           
                    arlSQLParameters.Clear();
                    arlSQLParameters.Add(new SqlParameter("@BusinessID", eocPropertyBean.BusinessCategory_BusinessID));
                    arlSQLParameters.Add(new SqlParameter("@LoginEmail", eocPropertyBean.Business_UserProfile_LoginEmail));
                    arlSQLParameters.Add(new SqlParameter("@CompanyName", eocPropertyBean.Business_UserProfile_CompanyName));
                    arlSQLParameters.Add(new SqlParameter("@CompanyNameBng", eocPropertyBean.Business_UserProfile_CompanyNameBng));
                    arlSQLParameters.Add(new SqlParameter("@Mobile", eocPropertyBean.Business_UserProfile_ContactPhone));
                    arlSQLParameters.Add(new SqlParameter("@ContactAddress",eocPropertyBean.Business_UserProfile_BusinessAddress));
                    arlSQLParameters.Add(new SqlParameter("@CompanyURL", eocPropertyBean.Business_UserProfile_CompanyURL));
                    arlSQLParameters.Add(new SqlParameter("@UpdatedOn", eocPropertyBean.UpdatedOn));
                    arlSQLParameters.Add(new SqlParameter("@LoginPassword",eocPropertyBean.Business_UserProfile_LoginPassword));
                    arlSQLParameters.Add(new SqlParameter("@DistrictId", eocPropertyBean.DistrictId));
                    arlSQLParameters.Add(new SqlParameter("@LocationId", eocPropertyBean.CustomerLocation));
                    arlSQLParameters.Add(new SqlParameter("@ContactPerson", eocPropertyBean.ContactPerson));
                  
                    

            arlSQLParameters.Add(new SqlParameter("@AboutSellers", eocPropertyBean.UserProfileMerchantInfo));
            arlSQLParameters.Add(new SqlParameter("@DeliveryPaymentProcess", eocPropertyBean.UserProfileDeliveryPaymentProcess));
            arlSQLParameters.Add(new SqlParameter("@DeliveryChargeAmount", eocPropertyBean.UserProfileDeliveryChargeAmount));
            arlSQLParameters.Add(new SqlParameter("@DeliveryChargeAmountOutSideDhaka", eocPropertyBean.UserProfileDeliveryChargeAmountOutSideDhaka));
            arlSQLParameters.Add(new SqlParameter("@DeliveryCharge", eocPropertyBean.UserProfileDeliveryCharge));
            arlSQLParameters.Add(new SqlParameter("@UserId", eocPropertyBean.UserProfileBringUser));
            arlSQLParameters.Add(new SqlParameter("@BusinessModelType", eocPropertyBean.UserProfileBusinessModelType));

            arlSQLParameters.Add(new SqlParameter("@MobileExtra1", eocPropertyBean.Business_UserProfile_ContactPhone_Extra1));
            arlSQLParameters.Add(new SqlParameter("@MobileExtra2", eocPropertyBean.Business_UserProfile_ContactPhone_Extra2));
            arlSQLParameters.Add(new SqlParameter("@CommissionComment", eocPropertyBean.CommissionComment));

            intActionResult = this.ExecuteActionQuery("Deal.USP_InsertCompanyForAdmin", arlSQLParameters);
        }
        catch(Exception ex)
        {

        }
        finally
        {
            CloseConnection();
        }
        return intActionResult;
    }

    private bool IfNotDuplicateCompanyNameExist(string CompanyName)
    {
        bool flag = true;

        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            OpenConnection();
            arlSQLParameters.Add(new SqlParameter("@CompanyName", CompanyName));

            //Case 02: Looking for duplicate company name before inserting record.
            if (this.ExecuteQuery("USP_CP_UsrPro_BeforeInsert_IsCompanyNameDuplicate", arlSQLParameters).Rows.Count == 0)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }
        }
        catch (Exception ex)
        {
        }
        finally
        {
            CloseConnection();
        }

        return flag;
    }

    public bool IfNotDuplicateLoginEmailExist(string LoginEmail)
    {
        bool flag = true;

        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            OpenConnection();
            arlSQLParameters.Add(new SqlParameter("@LoginEmail", LoginEmail));

            //Case 01: Looking for duplicate login email before inserting record.
            if (this.ExecuteQuery("USP_Common_UsrPro_BeforeInsert_IsLoginEmailDuplicate", arlSQLParameters).Rows.Count == 0)
            {
                flag = true;

            }
            else
            {
                flag = false;

            }

        }
        catch (Exception ex)
        {
        }
        finally
        {
            CloseConnection();
        }
        return flag;
    }
	
	public int AddRecord_AdminCompanyEntry(EOC_PropertyBean eocPropertyBean)
    {
        int intActionResult = 0;
        try
        {
                      
            if (IfNotDuplicateLoginEmailExist(eocPropertyBean.Business_UserProfile_LoginEmail))//Case 01: Looking for duplicate login email before inserting record.
            {
                
                if(IfNotDuplicateCompanyNameExist(eocPropertyBean.Business_UserProfile_CompanyName))//Case 02: Looking for duplicate company name before inserting record.
                {
                   intActionResult  = InsertCompanyForAdmin(eocPropertyBean);

                }
                else
                {
                     intActionResult= -2;
                }
            }
            else
            {
                intActionResult = -1;
            }
        }
        catch (Exception Ex)
        {
            throw;
        }
        

        return intActionResult;
    }
	
    public DataTable LoadDiscuntCompany(int CompanyProfileId)
    {
        DataTable objDataTable = new DataTable();
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Clear();
            arlSQLParameters.Add(new SqlParameter("@ProfileID", CompanyProfileId));
            return this.ExecuteQuery("Merchant.USP_LoadCompanyForAdmin", arlSQLParameters);
        
        }
        catch (Exception)
        {

            throw;
        }
        finally
        {
            CloseConnection();
        }
    }

    public DataTable LoadDiscuntCompany_New(int CompanyProfileId)
    {
        DataTable objDataTable = new DataTable();
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Clear();
            arlSQLParameters.Add(new SqlParameter("@ProfileID", CompanyProfileId));

            return this.ExecuteQuery("Merchant.USP_LoadCompanyReportForAdmin", arlSQLParameters);

        }
        catch (Exception)
        {

            throw;
        }
        finally
        {
            CloseConnection();
        }
    }
    public DataTable LoadCompanyReport_New(int CompanyProfileId, int Model)
    {
        DataTable objDataTable = new DataTable();
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Clear();
            arlSQLParameters.Add(new SqlParameter("@ProfileID", CompanyProfileId));
            arlSQLParameters.Add(new SqlParameter("@Model", Model));
            return this.ExecuteQuery("Merchant.USP_LoadCompanyReport", arlSQLParameters);

        }
        catch (Exception)
        {

            throw;
        }
        finally
        {
            CloseConnection();
        }
    }
    public DataTable LoadRecord_BusinessCategoey()
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            OpenConnection();
            return this.ExecuteQuery("USP_CP_UsrPro_LoadBusinessCategory", arlSQLParameters);
        }
        catch
        {
            throw;
        }
        finally
        {
            this.CloseConnection();
        }
    }

    public DataTable GetDealsInfo(int intDealId)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            OpenConnection();
            arlSQLParameters.Add(new SqlParameter("@DealId", intDealId));

            return this.ExecuteQuery("Deal.USP_GetDealsInfo", arlSQLParameters);
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
        finally
        {
            CloseConnection();
        }
    }

    public DataTable GetCorporateAccountInfo(int intProfileId)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            OpenConnection();
            arlSQLParameters.Add(new SqlParameter("@ProfileID", intProfileId));
            return this.ExecuteQuery("Deal.USP_GetCompanyAccountInfo", arlSQLParameters);
        }
        catch (Exception)
        {

            throw;
        }
        finally
        {
            CloseConnection();
        }
    }

    public DataTable LoadRecord_Users()
    {
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            return this.ExecuteQuery("AD.USP_LoadSalesUsers", arlSQLParameters);

        }

        catch
        {
            throw;

        }
        finally
        {
            this.CloseConnection();
        }
    }

    public DataTable LoadRecordDistricts()
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            OpenConnection();
            return this.ExecuteQuery("USP_LoadDistricts", arlSQLParameters);
        }
        catch
        {
            throw;
        }
        finally
        {
            CloseConnection();
        }
    }

    public DataTable LoadRecord_Locations()
    {
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            return this.ExecuteQuery("USP_LoadLocations", arlSQLParameters);
        }
        catch
        {
            throw;
        }
        finally
        {
            CloseConnection();
        }
    }

    public int UpdateRecord_UserProfileDiscountAdmin(EOC_PropertyBean eocPropertyBean)
    {
        int intActionResult = 0;
        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            OpenConnection();
            arlSQLParameters.Clear();
            arlSQLParameters.Add(new SqlParameter("@BusinessID", eocPropertyBean.BusinessCategory_BusinessID));
            arlSQLParameters.Add(new SqlParameter("@LoginEmail", eocPropertyBean.Business_UserProfile_LoginEmail));
            arlSQLParameters.Add(new SqlParameter("@CompanyName", eocPropertyBean.Business_UserProfile_CompanyName));
            arlSQLParameters.Add(new SqlParameter("@CompanyNameBng", eocPropertyBean.Business_UserProfile_CompanyNameBng));
            arlSQLParameters.Add(new SqlParameter("@ContactPerson", eocPropertyBean.ContactPerson));
            arlSQLParameters.Add(new SqlParameter("@Mobile", eocPropertyBean.Business_UserProfile_ContactPhone));
            arlSQLParameters.Add(new SqlParameter("@ContactAddress", eocPropertyBean.Business_UserProfile_BusinessAddress));
            arlSQLParameters.Add(new SqlParameter("@CompanyURL", eocPropertyBean.Business_UserProfile_CompanyURL));
            arlSQLParameters.Add(new SqlParameter("@UpdatedOn", eocPropertyBean.UpdatedOn));
            arlSQLParameters.Add(new SqlParameter("@LoginPassword", eocPropertyBean.Business_UserProfile_LoginPassword));
            arlSQLParameters.Add(new SqlParameter("@DistrictId", eocPropertyBean.DistrictId));
            arlSQLParameters.Add(new SqlParameter("@LocationId", eocPropertyBean.CustomerLocation));
            arlSQLParameters.Add(new SqlParameter("@ProfileId", eocPropertyBean.DealId));


            arlSQLParameters.Add(new SqlParameter("@AboutSellers", eocPropertyBean.UserProfileMerchantInfo));
            arlSQLParameters.Add(new SqlParameter("@DeliveryPaymentProcess", eocPropertyBean.UserProfileDeliveryPaymentProcess));
            arlSQLParameters.Add(new SqlParameter("@DeliveryChargeAmount", eocPropertyBean.UserProfileDeliveryChargeAmount));
            arlSQLParameters.Add(new SqlParameter("@DeliveryChargeAmountOutSideDhaka", eocPropertyBean.UserProfileDeliveryChargeAmountOutSideDhaka));
            arlSQLParameters.Add(new SqlParameter("@DeliveryCharge", eocPropertyBean.UserProfileDeliveryCharge));
            arlSQLParameters.Add(new SqlParameter("@UserId", eocPropertyBean.UserProfileBringUser));
            arlSQLParameters.Add(new SqlParameter("@BusinessModelType", eocPropertyBean.UserProfileBusinessModelType));

            arlSQLParameters.Add(new SqlParameter("@MobileExtra1", eocPropertyBean.Business_UserProfile_ContactPhone_Extra1));
            arlSQLParameters.Add(new SqlParameter("@MobileExtra2", eocPropertyBean.Business_UserProfile_ContactPhone_Extra2));
            arlSQLParameters.Add(new SqlParameter("@CommissionComment", eocPropertyBean.CommissionComment));

            intActionResult = this.ExecuteActionQuery("Deal.USP_UpdateCompanyForAdmin", arlSQLParameters);
        }
        catch
        {
            throw;
        }
        finally
        {
            this.CloseConnection();
        }

        return intActionResult;
    }

    public int AddRecord_UserProfileDiscountAdmin(EOC_PropertyBean eocPropertyBean)
    {
        int intActionResult = 0;
        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            OpenConnection();
            arlSQLParameters.Add(new SqlParameter("@LoginEmail", eocPropertyBean.Business_UserProfile_LoginEmail));

            //Case 01: Looking for duplicate login email before inserting record.
            if (
                this.ExecuteQuery("USP_Common_UsrPro_BeforeInsert_IsLoginEmailDuplicate", arlSQLParameters).Rows.Count ==
                0)
            {
                arlSQLParameters.Clear();
                arlSQLParameters.Add(new SqlParameter("@CompanyName", eocPropertyBean.Business_UserProfile_CompanyName));

                //Case 02: Looking for duplicate company name before inserting record.
                if (
                    this.ExecuteQuery("USP_CP_UsrPro_BeforeInsert_IsCompanyNameDuplicate", arlSQLParameters).Rows.Count ==
                    0)
                {
                    arlSQLParameters.Clear();
                    arlSQLParameters.Add(new SqlParameter("@BusinessID", eocPropertyBean.BusinessCategory_BusinessID));
                    arlSQLParameters.Add(new SqlParameter("@LoginEmail", eocPropertyBean.Business_UserProfile_LoginEmail));
                    arlSQLParameters.Add(new SqlParameter("@CompanyName", eocPropertyBean.Business_UserProfile_CompanyName));
                    arlSQLParameters.Add(new SqlParameter("@CompanyNameBng", eocPropertyBean.Business_UserProfile_CompanyNameBng));
                    arlSQLParameters.Add(new SqlParameter("@ContactPerson", eocPropertyBean.ContactPerson));
                    arlSQLParameters.Add(new SqlParameter("@Mobile", eocPropertyBean.Business_UserProfile_ContactPhone));
                    arlSQLParameters.Add(new SqlParameter("@ContactAddress",
                        eocPropertyBean.Business_UserProfile_BusinessAddress));
                    arlSQLParameters.Add(new SqlParameter("@CompanyURL", eocPropertyBean.Business_UserProfile_CompanyURL));
                    arlSQLParameters.Add(new SqlParameter("@UpdatedOn", eocPropertyBean.UpdatedOn));
                    arlSQLParameters.Add(new SqlParameter("@LoginPassword",
                        eocPropertyBean.Business_UserProfile_LoginPassword));
                    arlSQLParameters.Add(new SqlParameter("@DistrictId", eocPropertyBean.DistrictId));
                    arlSQLParameters.Add(new SqlParameter("@LocationId", eocPropertyBean.CustomerLocation));


                    intActionResult = this.ExecuteActionQuery("Deal.USP_InsertProfileCompany",arlSQLParameters);

                }
                else
                {
                    intActionResult = -2;
                }
            }
            else
            {
                intActionResult = -1;
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

        return intActionResult;
    }

    public int DeleteCompanyName(int companyProfileId, int userId)
    {
        int actionResult = 0;
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Clear();
            arlSQLParameters.Add(new SqlParameter("@companyProfileId", companyProfileId));
            arlSQLParameters.Add(new SqlParameter("@userId", userId));

            actionResult = this.ExecuteActionQuery("Deal.USP_DeleteCompanyName", arlSQLParameters);
        }
        catch (Exception)
        {

            throw;
        }
        finally
        {
            CloseConnection();
        }
        return actionResult;
    }
}