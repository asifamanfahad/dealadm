using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for GenarateSessionThroughtCoockie
/// </summary>
public class GenarateSessionThroughtCoockie :ADGateway
{
	public GenarateSessionThroughtCoockie()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public bool SessionCheck(int sessionType)
    {     
        bool isSessionExist = false;        
        if (sessionType == 1)
        {
            isSessionExist = GenerateSessionForCustomer();            
            return isSessionExist;
        }
        else if (sessionType == 2)
        {
            isSessionExist = GenerateSessionForMerchant();
            return isSessionExist;
        }

        else if (sessionType == 3)
        {
            isSessionExist = GenerateSessionForAdmin();
            return isSessionExist;
        }
        else
        {
            return isSessionExist;
        }

    }


    private bool GenerateSessionForCustomer()
    {
        string userCookies = "";
        string userSession = "";
        
        if (HttpContext.Current.Request.Cookies["CK_AD_CUSTOMER_ID"] != null)
        {
            userCookies = (string)HttpContext.Current.Request.Cookies["CK_AD_CUSTOMER_ID"].Value;
        }

        if (HttpContext.Current.Session["AD_CUSTOMER_ID"] != null)
        {
            userSession = HttpContext.Current.Session["AD_CUSTOMER_ID"].ToString();
        }

        if (userSession == null || userSession == "")
        {
            if (userCookies != null && userCookies != "")
            {
                using (CustomersGateway objCustomer = new CustomersGateway())
                {
                    DataTable dtCustomer = objCustomer.GetCustomerInfo(Convert.ToInt32(userSession));

                    if (dtCustomer.Rows.Count > 0)
                    {
                        HttpContext.Current.Session["AD_CUSTOMER_ID"] = dtCustomer.Rows[0]["CustomerId"].ToString();
                        HttpContext.Current.Session["AD_CUSTOMER_NAME"] = dtCustomer.Rows[0]["CName"].ToString();
                        HttpContext.Current.Session["AD_CUSTOMER_EMAIL"] = dtCustomer.Rows[0]["CEmail"].ToString();
                        HttpContext.Current.Session["AD_CUSTOMER_LOCATION"] = dtCustomer.Rows[0]["CAddress"].ToString();
                        HttpContext.Current.Session["AD_CUSTOMER_MOBILE"] = dtCustomer.Rows[0]["CMobile"].ToString();
                        HttpContext.Current.Session["AD_CUSTOMER_Gender"] = dtCustomer.Rows[0]["Gender"].ToString();

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
          }
            else
            {
                return false;
            }
        }
        else
        {
            return true;
        }
        
    }

    private bool GenerateSessionForMerchant()
    {
        string userCookies = "";
        string userSession = "";


        if (HttpContext.Current.Request.Cookies["CK_CORP_PROFILE_ID"] != null)
        {
            userCookies = (string)HttpContext.Current.Request.Cookies["CK_CORP_PROFILE_ID"].Value;
        }

        if (HttpContext.Current.Session["CORP_PROFILE_CODE"] != null)
        {
            userSession = HttpContext.Current.Session["CORP_PROFILE_CODE"].ToString();
        }

        if (userSession == null || userSession == "")
        {
            if (userCookies != null && userCookies != "")
            {
                using (BC_Corporate_ProductProfile objCorporate = new BC_Corporate_ProductProfile())
                {
                    DataTable dtCorporate = objCorporate.GetCorporateAccountInfo( Convert.ToInt32(userCookies));
                    if (dtCorporate.Rows.Count > 0)
                    {
                        HttpContext.Current.Session["CORP_PROFILE_CODE"] = userCookies;
                        HttpContext.Current.Session["LOGINEMAIL"] = dtCorporate.Rows[0]["LoginEmail"].ToString();
                        HttpContext.Current.Session["COMPANYNAME"] = dtCorporate.Rows[0]["CompanyName"].ToString();
                        HttpContext.Current.Session["ISADMIN"] = false;

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }



            }
            else
            {
                return false;
            }
        }
        else
        {
            return true;
        }
    }
    
    private bool GenerateSessionForAdmin()
    {
        string userCookies = "";
        string userSession = "";
        
        if (HttpContext.Current.Request.Cookies["CK_AD_ADMIN_ID"] != null)
        {
            userCookies = (string)HttpContext.Current.Request.Cookies["CK_AD_ADMIN_ID"].Value;
        }

        if (HttpContext.Current.Session["AD_ADMIN_ID"] != null)
        {
            userSession = HttpContext.Current.Session["AD_ADMIN_ID"].ToString();
        }

        if(userSession==null || userSession=="")
        {
            if (userCookies != null && userCookies != "")
            {
                using (AD_Users_Gateway objAdmin = new AD_Users_Gateway())
                {
                    DataTable dtAdmin = objAdmin.Show_AllUsers( Convert.ToInt32(userCookies));
                    if (dtAdmin.Rows.Count > 0)
                    {
                        HttpContext.Current.Session["AD_ADMIN_ID"] = dtAdmin.Rows[0]["UserId"].ToString();
                        HttpContext.Current.Session["AD_ADMIN_NAME"] = dtAdmin.Rows[0]["FullName"].ToString();
                        HttpContext.Current.Session["AD_ADMIN_USERNAME"] = dtAdmin.Rows[0]["UserName"].ToString();
                        HttpContext.Current.Session["AD_ADMIN_TYPE"] = dtAdmin.Rows[0]["AdminType"].ToString();

                        HttpContext.Current.Response.Cookies["CK_AD_ADMIN_ID"].Expires = DateTime.Now.AddDays(7);
                        
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
               
            }
            else
            {
                return false;
            }
        }
        else
        {
            return true;
        }
    }


}