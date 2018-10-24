using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AdminDealsGateway
/// </summary>
public class AdminDealsGateway:ADGateway
{
	public AdminDealsGateway()
	{
		//
		// TODO: Add constructor logic here
		//
	}
	
	public DataTable UpdateMultipleDealIdForDealLive(string DealId)
    {
        DataTable objDatatable = new DataTable();
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@DealId", DealId));

            objDatatable = this.ExecuteQuery("Deal.USP_UpdateMultipleDealIdForDealLive", arlSQLParameters);
        }
        catch (Exception Ex)
        {
            throw new Exception(Ex.Message);
        }
        finally
        {
            CloseConnection();
        }
        return objDatatable;
    }
	
	public List<string> Get_Suggestion(string cityName)
    {
          DataTable objDatatable = new DataTable();

        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@keyword", cityName));

            objDatatable = this.ExecuteQuery("Deal.USP_LoadCompanyNameForDealsControlPanel", arlSQLParameters);            
            //objDatatable = this.ExecuteQuery("[Deal].[USP_GetDealsByKeyword]", arlSQLParameters);
            return (from data in objDatatable.AsEnumerable() select data.Field<string>("CompanyName")).ToList();
            //return (from data in objDatatable.AsEnumerable() select data.Field<string>("DealTitle")).ToList();
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
	
    public DataTable LoadCompanyDataMerchantWise(string companyname, string profileid, string topload, string fromdate, string toDate)
    {
        DataTable objDatatable = new DataTable();

        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@Companyname", companyname));
            arlSQLParameters.Add(new SqlParameter("@Profileid", profileid));
            arlSQLParameters.Add(new SqlParameter("@Top", topload));
            arlSQLParameters.Add(new SqlParameter("@fromDate", fromdate));
            arlSQLParameters.Add(new SqlParameter("@toDate", toDate));

            objDatatable = this.ExecuteQuery("Deal.USP_LoadMerchantAllInformation_New", arlSQLParameters);
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
    public DataTable LoadCompanyDataMerchantWise(string companyname, string profileid, string topload)
    {
        DataTable objDatatable = new DataTable();

        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@Companyname", companyname));
            arlSQLParameters.Add(new SqlParameter("@Profileid", profileid));
            arlSQLParameters.Add(new SqlParameter("@Top", topload));

            objDatatable = this.ExecuteQuery("Deal.USP_LoadMerchantAllInformation", arlSQLParameters);
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


	 public string Get_MarchantEMailAddress(string dealid)
    {
        string MarchantMail = "";
        DataTable objDatatable = new DataTable();
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@dealid", dealid));


            objDatatable = this.ExecuteQuery("Deal.USP_Get_MarchantMail", arlSQLParameters);
            MarchantMail = objDatatable.Rows[0]["LoginEMail"].ToString();

        }
        catch (Exception)
        {
            
            throw;
        }
        finally 
        {
            this.CloseConnection();
        }
        return MarchantMail;
    }
	
	public int AddRecord_DealsForAdmin(DealsManager dealsManager)
    {
        int intActionResult = 0;
        int DealId = 0;
        string dtmPostedOn = DateTime.Now.ToString();

        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@DealTitle", dealsManager.DealTitle));
            arlSQLParameters.Add(new SqlParameter("@ShortDescription", dealsManager.ShortDescription));
            arlSQLParameters.Add(new SqlParameter("@CouponStartingDate", dealsManager.CouponStartingDate));
            arlSQLParameters.Add(new SqlParameter("@CouponExpiryDate", dealsManager.CouponExpiryDate));
            arlSQLParameters.Add(new SqlParameter("@SignupStartingDate", dealsManager.SignupStartingDate));
            arlSQLParameters.Add(new SqlParameter("@SignupClosingDate", dealsManager.SignupClosingDate));
            arlSQLParameters.Add(new SqlParameter("@IsActive", dealsManager.IsActive));
            arlSQLParameters.Add(new SqlParameter("@InsertedOn", dealsManager.InsertedOn));
            arlSQLParameters.Add(new SqlParameter("@ProfileID", dealsManager.ProfileID));
            arlSQLParameters.Add(new SqlParameter("@RegularPrice", dealsManager.RegularPrice));
            arlSQLParameters.Add(new SqlParameter("@DealPrice", dealsManager.DealPrice));
            arlSQLParameters.Add(new SqlParameter("@CouponPrice", dealsManager.CouponPrice));
            arlSQLParameters.Add(new SqlParameter("@DealDiscount", dealsManager.DealDiscount));
            arlSQLParameters.Add(new SqlParameter("@DealQtn", dealsManager.DealQtn));
            arlSQLParameters.Add(new SqlParameter("@QtnLimitPerUser", dealsManager.QtnLimitPerUser));
            arlSQLParameters.Add(new SqlParameter("@FolderName", dealsManager.FolderName));
            arlSQLParameters.Add(new SqlParameter("@DealDiscountInPercent", dealsManager.DealDiscountInPercent));
            arlSQLParameters.Add(new SqlParameter("@IsPercent", dealsManager.ApplicableDiscount));
            arlSQLParameters.Add(new SqlParameter("@DealPriority", dealsManager.DealPriority));
            arlSQLParameters.Add(new SqlParameter("@Process", dealsManager.Process));
            arlSQLParameters.Add(new SqlParameter("@BulletDescription", dealsManager.BulletDescription));
            arlSQLParameters.Add(new SqlParameter("@SocialTitle", dealsManager.SocialTitle));
            arlSQLParameters.Add(new SqlParameter("@SocialDescription", dealsManager.SocialDescription));
            arlSQLParameters.Add(new SqlParameter("@ImageExt", dealsManager.ImageExt));
            arlSQLParameters.Add(new SqlParameter("@CategoryId", dealsManager.CategoryId));
            arlSQLParameters.Add(new SqlParameter("@SubCategoryId", dealsManager.SubCategoryId));
            arlSQLParameters.Add(new SqlParameter("@SubSubCategoryId", dealsManager.SubSubCategoryId));
            arlSQLParameters.Add(new SqlParameter("@IsUpto", dealsManager.IsUpto));
            arlSQLParameters.Add(new SqlParameter("@CustomizeRateChart", dealsManager.CustomizeRateChart));
            arlSQLParameters.Add(new SqlParameter("@IsSoldOut", dealsManager.IsSoldOut));
            arlSQLParameters.Add(new SqlParameter("@IsMainDeal", dealsManager.IsMainDeal));
            arlSQLParameters.Add(new SqlParameter("@UserId", dealsManager.UserId));
            arlSQLParameters.Add(new SqlParameter("@Sizes", dealsManager.Sizes));
            arlSQLParameters.Add(new SqlParameter("@Colors", dealsManager.Colors));
            arlSQLParameters.Add(new SqlParameter("@DeliveryCharge", dealsManager.DeliveryCharge));
            arlSQLParameters.Add(new SqlParameter("@UploadedBy", dealsManager.UploadedBy));
            arlSQLParameters.Add(new SqlParameter("@ImageCount", dealsManager.ImageCount));
            arlSQLParameters.Add(new SqlParameter("@DeliveryChargeAmount", dealsManager.DeliveryChargeAmount));
            arlSQLParameters.Add(new SqlParameter("@DeliveryPaymentProcess", dealsManager.DeliveryChargeText));
            arlSQLParameters.Add(new SqlParameter("@DeliveryChargeAmountOutSideDhaka", dealsManager.OutsideDhakaDeliveryChargeAmount));
            arlSQLParameters.Add(new SqlParameter("@BrandId", dealsManager.BrandId));
            arlSQLParameters.Add(new SqlParameter("@AccountsTitle", dealsManager.AccountsTitle));
            arlSQLParameters.Add(new SqlParameter("@CommissionPerCoupon", dealsManager.CommissionPerCoupon));
            arlSQLParameters.Add(new SqlParameter("@EventDescription", dealsManager.EventDealDescription));
            arlSQLParameters.Add(new SqlParameter("@BusinessModelType", dealsManager.BusinessModelType));
            arlSQLParameters.Add(new SqlParameter("@productSpecification", dealsManager.productSpecification));
            arlSQLParameters.Add(new SqlParameter("@ProductColor", dealsManager.ProductColor));
            arlSQLParameters.Add(new SqlParameter("@MotherDealId", dealsManager.MotherDealId));
            arlSQLParameters.Add(new SqlParameter("@IsDealRestricted", dealsManager.IsDealRestricted));
            arlSQLParameters.Add(new SqlParameter("@QtyAfterBooking", dealsManager.QtyAfterBooking));

            SqlParameter parameter = new SqlParameter("@NewId", SqlDbType.Int);

            //Set the parameter direction as output
            parameter.Direction = ParameterDirection.Output;

            arlSQLParameters.Add(parameter);



            intActionResult = this.ExecuteActionQuery("Deal.USP_InsertDealsForAdmin", arlSQLParameters);
            DealId = Convert.ToInt32(parameter.Value);
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
        finally
        {
            this.CloseConnection();
        }


        return DealId;
    }

    public int UpdateRecord_DealsForAdmin(DealsManager dealsManager)
    {
        int intActionResult = 0;
        string dtmPostedOn = DateTime.Now.ToString();

        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@DealId", dealsManager.DealId));
            arlSQLParameters.Add(new SqlParameter("@DealTitle", dealsManager.DealTitle));
            arlSQLParameters.Add(new SqlParameter("@ShortDescription", dealsManager.ShortDescription));
            arlSQLParameters.Add(new SqlParameter("@CouponStartingDate", dealsManager.CouponStartingDate));
            arlSQLParameters.Add(new SqlParameter("@CouponExpiryDate", dealsManager.CouponExpiryDate));
            arlSQLParameters.Add(new SqlParameter("@SignupStartingDate", dealsManager.SignupStartingDate));
            arlSQLParameters.Add(new SqlParameter("@SignupClosingDate", dealsManager.SignupClosingDate));
            arlSQLParameters.Add(new SqlParameter("@IsActive", dealsManager.IsActive));
            arlSQLParameters.Add(new SqlParameter("@UpdatedOn", dealsManager.UpdatedOn));
            arlSQLParameters.Add(new SqlParameter("@ProfileID", dealsManager.ProfileID));
            arlSQLParameters.Add(new SqlParameter("@RegularPrice", dealsManager.RegularPrice));
            arlSQLParameters.Add(new SqlParameter("@DealPrice", dealsManager.DealPrice));
            arlSQLParameters.Add(new SqlParameter("@CouponPrice", dealsManager.CouponPrice));
            arlSQLParameters.Add(new SqlParameter("@DealDiscount", dealsManager.DealDiscount));
            arlSQLParameters.Add(new SqlParameter("@DealQtn", dealsManager.DealQtn));
            arlSQLParameters.Add(new SqlParameter("@QtnLimitPerUser", dealsManager.QtnLimitPerUser));
            arlSQLParameters.Add(new SqlParameter("@FolderName", dealsManager.FolderName));
            arlSQLParameters.Add(new SqlParameter("@DealDiscountInPercent", dealsManager.DealDiscountInPercent));
            arlSQLParameters.Add(new SqlParameter("@IsPercent", dealsManager.ApplicableDiscount));
            arlSQLParameters.Add(new SqlParameter("@DealPriority", dealsManager.DealPriority));
            arlSQLParameters.Add(new SqlParameter("@Process", dealsManager.Process));
            arlSQLParameters.Add(new SqlParameter("@BulletDescription", dealsManager.BulletDescription));
            arlSQLParameters.Add(new SqlParameter("@SocialTitle", dealsManager.SocialTitle));
            arlSQLParameters.Add(new SqlParameter("@SocialDescription", dealsManager.SocialDescription));
            arlSQLParameters.Add(new SqlParameter("@ImageExt", dealsManager.ImageExt));
            arlSQLParameters.Add(new SqlParameter("@CategoryId", dealsManager.CategoryId));
            arlSQLParameters.Add(new SqlParameter("@SubCategoryId", dealsManager.SubCategoryId));
            arlSQLParameters.Add(new SqlParameter("@SubSubCategoryId", dealsManager.SubSubCategoryId));
            arlSQLParameters.Add(new SqlParameter("@IsUpto", dealsManager.IsUpto));
            arlSQLParameters.Add(new SqlParameter("@CustomizeRateChart", dealsManager.CustomizeRateChart));
            arlSQLParameters.Add(new SqlParameter("@IsSoldOut", dealsManager.IsSoldOut));
            arlSQLParameters.Add(new SqlParameter("@IsMainDeal", dealsManager.IsMainDeal));
            arlSQLParameters.Add(new SqlParameter("@UserId", dealsManager.UserId));
            arlSQLParameters.Add(new SqlParameter("@Sizes", dealsManager.Sizes));
            arlSQLParameters.Add(new SqlParameter("@Colors", dealsManager.Colors));
            arlSQLParameters.Add(new SqlParameter("@DeliveryCharge", dealsManager.DeliveryCharge));           
            arlSQLParameters.Add(new SqlParameter("@DeliveryChargeAmount", dealsManager.DeliveryChargeAmount));
            arlSQLParameters.Add(new SqlParameter("@DeliveryPaymentProcess", dealsManager.DeliveryChargeText));
            arlSQLParameters.Add(new SqlParameter("@DeliveryChargeAmountOutSideDhaka", dealsManager.OutsideDhakaDeliveryChargeAmount));
            arlSQLParameters.Add(new SqlParameter("@BrandId", dealsManager.BrandId));
            arlSQLParameters.Add(new SqlParameter("@AccountsTitle", dealsManager.AccountsTitle));
            arlSQLParameters.Add(new SqlParameter("@CommissionPerCoupon", dealsManager.CommissionPerCoupon));
            arlSQLParameters.Add(new SqlParameter("@ImageCount", dealsManager.ImageCount));
            arlSQLParameters.Add(new SqlParameter("@EventDescription", dealsManager.EventDealDescription));
            arlSQLParameters.Add(new SqlParameter("@BusinessModelType", dealsManager.BusinessModelType));
            arlSQLParameters.Add(new SqlParameter("@productSpecification", dealsManager.productSpecification));          
            arlSQLParameters.Add(new SqlParameter("@ProductColor", dealsManager.ProductColor));
            arlSQLParameters.Add(new SqlParameter("@MotherDealId", dealsManager.MotherDealId));
            arlSQLParameters.Add(new SqlParameter("@IsDealRestricted", dealsManager.IsDealRestricted));
            arlSQLParameters.Add(new SqlParameter("@QtyAfterBooking", dealsManager.QtyAfterBooking));
            arlSQLParameters.Add(new SqlParameter("@UpdatedBy", dealsManager.UploadedBy));


            intActionResult = this.ExecuteActionQuery("Deal.USP_UpdateDealsForAdmin", arlSQLParameters);
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
        finally
        {
            this.CloseConnection();
        }


        return intActionResult;
    }
   
   
	public int UpdateFulfilmentRating(string companyid, int UpdatedBy, int FulfilmentRating)
    {
        int actionResult = 0;
        try
        {
            OpenConnection();
            ArrayList arrSqlParameters = new ArrayList();
            arrSqlParameters.Add(new SqlParameter("@companyid", companyid));
            arrSqlParameters.Add(new SqlParameter("UpdatedBy", UpdatedBy));
            arrSqlParameters.Add(new SqlParameter("@FulfilmentRating", FulfilmentRating));

            actionResult = ExecuteActionQuery("[Deal].[USP_UpdateFulFilmentRating]", arrSqlParameters);
        }
        catch (Exception ex)
        {
            throw;
        }
        finally
        {
            CloseConnection();
        }
        return actionResult;
    }
	
	public int UpdateCompanyIdForLiveSoldOutClosed(string CompanyProfileId, int user_Id, int IsCategory)
    {
        int actionResult = 0;
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@CompanyProfileId", CompanyProfileId));
            arlSQLParameters.Add(new SqlParameter("@user_Id", user_Id));
            arlSQLParameters.Add(new SqlParameter("@IsCategorized", IsCategory));

            actionResult = this.ExecuteActionQuery("Deal.USP_UpdateCompanyIdForLiveSoldOutClosed", arlSQLParameters);
        }
        catch (Exception Ex)
        {
            throw new Exception(Ex.Message);
        }
        finally
        {
            CloseConnection();
        }
        return actionResult;
    }


	public int UpdateMultipleDealIdForDealDelete(string DealId, int DeletedBy)
    {
        int actionResult = 0;
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@DealId", DealId));
            arlSQLParameters.Add(new SqlParameter("@DeletedByid", DeletedBy));

            actionResult = this.ExecuteActionQuery("Deal.USP_UpdateMultipleDealIdForDealDelete", arlSQLParameters);
        }
        catch (Exception Ex)
        {
            throw new Exception(Ex.Message);
        }
        finally
        {
            CloseConnection();
        }
        return actionResult;
    }
	
	public int UpdateMultipleDealIdForDealClosed(string DealId)
    {
        int actionResult = 0;
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@DealId", DealId));

            actionResult = this.ExecuteActionQuery("Deal.USP_UpdateMultipleDealIdForDealClosed", arlSQLParameters);
        }
        catch (Exception Ex)
        {
            throw new Exception(Ex.Message);
        }
        finally
        {
            CloseConnection();
        }
        return actionResult;
    }

    public int UpdateMultipleDealIdForDealSoldOut(string DealId)
    {
        int actionResult = 0;
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@DealId", DealId));

            actionResult = this.ExecuteActionQuery("Deal.USP_UpdateMultipleDealIdForDealSoldOut", arlSQLParameters);
        }
        catch (Exception Ex)
        {
            throw new Exception(Ex.Message);
        }
        finally
        {
            CloseConnection();
        }
        return actionResult;
    }

    
 public int Insert_DealComment(string comments, string dealid)
    {
        int ActionResult = 0;
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@comments", comments));
            arlSQLParameters.Add(new SqlParameter("@dealid", dealid));
            ActionResult = this.ExecuteActionQuery("[Deal].[USP_InsertDealComments]", arlSQLParameters);
            return ActionResult;
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
	
	public DataTable LoadDealInfoDealdetailsModel(string dealId)
    {
        DataTable objDatatable = new DataTable();

        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@DealId", dealId));

            objDatatable = this.ExecuteQuery("Deal.USP_GetDealsInfo", arlSQLParameters);

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
	
	
	
    public int UpdateImageCount(int DealId,int ImageCount)
    {
        int ActionResult = 0;
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@DealID", DealId));
            arlSQLParameters.Add(new SqlParameter("@ImageCount", ImageCount));

            ActionResult = this.ExecuteActionQuery("[Deal].[USP_Update_Deal_ImageCounter]", arlSQLParameters);
            return ActionResult;
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
    public int DealActiveInActive(int DealId)
    {
        int ActionResult = 0;
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@DealID", DealId));
            ActionResult = this.ExecuteActionQuery("[Deal].[USP_Deal_ActivationStatus]", arlSQLParameters);
            return ActionResult;
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
    public DataTable GetDealsInfoForImageUpload(int DealId)
    {
        DataTable objDataTable = new DataTable();
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@DealId", DealId));
            objDataTable = this.ExecuteQuery("[Deal].[USP_GetDealsInfoForImageUpload]", arlSQLParameters);
            return objDataTable;
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


    public void AddRecord_DealMultipleCategoryInsert(int CategoryId, int SubCategoryId, int SubSubCategoryId, int DealId)
    {
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            
            arlSQLParameters.Add(new SqlParameter("@CategoryId", CategoryId));
            arlSQLParameters.Add(new SqlParameter("@SubCategoryId", SubCategoryId));
            arlSQLParameters.Add(new SqlParameter("@SubSubCategoryId", SubSubCategoryId));
            arlSQLParameters.Add(new SqlParameter("@DealId", DealId));


            ExecuteActionQuery("Deal.USP_InsertMultipleCategorySubSubCategory", arlSQLParameters);

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

    public DataTable LoadRecord_SubSubCategoryWithCategoryId(int CategoryId, int SubcategoryId)
    {

        string dtmPostedOn = DateTime.Now.ToString();
        DataTable objDataTable = new DataTable();

        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@CategoryId", CategoryId));
            arlSQLParameters.Add(new SqlParameter("@SubcategoryId", SubcategoryId));

            objDataTable = this.ExecuteQuery("Deal.USP_LoadSubSubCategory", arlSQLParameters);
            return objDataTable;
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
//****************Majedur*********************running*************
    public DataTable LoadRecord_Users()
    {
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            return this.ExecuteQuery("AD.USP_LoadSalesUsers", arlSQLParameters);

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


    public DataTable LoadDiscuntCompany(DiscountZone discountZone)
    {
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            
            arlSQLParameters.Add(new SqlParameter("@ProfileID", discountZone.ProfileID));

            return this.ExecuteQuery("USP_DRP_Common_Load_DiscountAdminCompany", arlSQLParameters);
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

    public DataTable LoadRecord_Category()
    {
        OpenConnection();
        ArrayList arlSQLParameters = new ArrayList();

        try
        {
            return this.ExecuteQuery("Deal.USP_LoadCategory", arlSQLParameters);
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

    public DataTable LoadRecord_Brands()
    {
        OpenConnection();
        ArrayList arlSQLParameters = new ArrayList();

        try
        {
            return this.ExecuteQuery("Deal.Load_Brands", arlSQLParameters);
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

    public int AddRecord_Deals(DealsManager dealsManager)
    {
        int intActionResult = 0;
        int DealId = 0;
        string dtmPostedOn = DateTime.Now.ToString();

        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@DealTitle", dealsManager.DealTitle));
            arlSQLParameters.Add(new SqlParameter("@ShortDescription", dealsManager.ShortDescription));
            arlSQLParameters.Add(new SqlParameter("@Description", dealsManager.Description));
            arlSQLParameters.Add(new SqlParameter("@CouponStartingDate", dealsManager.CouponStartingDate));
            arlSQLParameters.Add(new SqlParameter("@CouponExpiryDate", dealsManager.CouponExpiryDate));
            arlSQLParameters.Add(new SqlParameter("@TermsCondition", dealsManager.TermsCondition));

            arlSQLParameters.Add(new SqlParameter("@AboutSellers", dealsManager.AboutSellers));

            arlSQLParameters.Add(new SqlParameter("@SignupStartingDate", dealsManager.SignupStartingDate));
            arlSQLParameters.Add(new SqlParameter("@SignupClosingDate", dealsManager.SignupClosingDate));
            arlSQLParameters.Add(new SqlParameter("@IsActive", dealsManager.IsActive));
            arlSQLParameters.Add(new SqlParameter("@InsertedOn", dealsManager.InsertedOn));
            arlSQLParameters.Add(new SqlParameter("@UpdatedOn", dealsManager.UpdatedOn));
            arlSQLParameters.Add(new SqlParameter("@ProfileID", dealsManager.ProfileID));

            arlSQLParameters.Add(new SqlParameter("@RegularPrice", dealsManager.RegularPrice));
            arlSQLParameters.Add(new SqlParameter("@DealPrice", dealsManager.DealPrice));
            arlSQLParameters.Add(new SqlParameter("@CouponPrice", dealsManager.CouponPrice));
            arlSQLParameters.Add(new SqlParameter("@DealDiscount", dealsManager.DealDiscount));
            arlSQLParameters.Add(new SqlParameter("@DealQtn", dealsManager.DealQtn));
            arlSQLParameters.Add(new SqlParameter("@QtnLimitPerUser", dealsManager.QtnLimitPerUser));
            arlSQLParameters.Add(new SqlParameter("@DistrictsId", dealsManager.DistrictsId));
            arlSQLParameters.Add(new SqlParameter("@LocationId", dealsManager.LocationId));
            arlSQLParameters.Add(new SqlParameter("@FolderName", dealsManager.FolderName));
            arlSQLParameters.Add(new SqlParameter("@DealDiscountInPercent", dealsManager.DealDiscountInPercent));
            arlSQLParameters.Add(new SqlParameter("@IsPercent", dealsManager.ApplicableDiscount));
            arlSQLParameters.Add(new SqlParameter("@DealPriority", dealsManager.DealPriority));
            arlSQLParameters.Add(new SqlParameter("@Process", dealsManager.Process));
            //arlSQLParameters.Add(new SqlParameter("@RestOfPayment", dealsManager.RestOfPayment));

            arlSQLParameters.Add(new SqlParameter("@BulletAboutSellers", dealsManager.BulletAboutSellers));
            arlSQLParameters.Add(new SqlParameter("@BulletDescription", dealsManager.BulletDescription));
            arlSQLParameters.Add(new SqlParameter("@BulletTermsCondition", dealsManager.BulletTermsCondition));
            arlSQLParameters.Add(new SqlParameter("@DealType", dealsManager.DealType));

            arlSQLParameters.Add(new SqlParameter("@SocialTitle", dealsManager.SocialTitle));
            arlSQLParameters.Add(new SqlParameter("@SocialDescription", dealsManager.SocialDescription));

            arlSQLParameters.Add(new SqlParameter("@UseScanImage", dealsManager.UseScanImage));

            arlSQLParameters.Add(new SqlParameter("@CustomiseMsg", dealsManager.CustomiseMsg));
            arlSQLParameters.Add(new SqlParameter("@ImageExt", dealsManager.ImageExt));
            arlSQLParameters.Add(new SqlParameter("@CategoryId", dealsManager.CategoryId));
            //arlSQLParameters.Add(new SqlParameter("@IsShowStartingDate", dealsManager.IsShowStartingDate));
            arlSQLParameters.Add(new SqlParameter("@IsUpto", dealsManager.IsUpto));
            arlSQLParameters.Add(new SqlParameter("@CustomizeRateChart", dealsManager.CustomizeRateChart));
            arlSQLParameters.Add(new SqlParameter("@IsSoldOut", dealsManager.IsSoldOut));
            arlSQLParameters.Add(new SqlParameter("@IsMainDeal", dealsManager.IsMainDeal));
            arlSQLParameters.Add(new SqlParameter("@DealKeywords", dealsManager.DealKeywords));
            arlSQLParameters.Add(new SqlParameter("@UserId", dealsManager.UserId));
            arlSQLParameters.Add(new SqlParameter("@IsSubDeals", dealsManager.UserProfileID));

            arlSQLParameters.Add(new SqlParameter("@Sizes", dealsManager.Sizes));
            arlSQLParameters.Add(new SqlParameter("@Colors", dealsManager.Colors));
            arlSQLParameters.Add(new SqlParameter("@DeliveryCharge", dealsManager.DeliveryCharge));
            arlSQLParameters.Add(new SqlParameter("@CustomiseBuyCoupon", dealsManager.CustomizeBuyCoupon));
            arlSQLParameters.Add(new SqlParameter("@IsOnlyManual", dealsManager.IsOnlyManual));
            arlSQLParameters.Add(new SqlParameter("@ProductType", dealsManager.ProductType));

            arlSQLParameters.Add(new SqlParameter("@IsEventDeal", dealsManager.IsEventDeal));
            arlSQLParameters.Add(new SqlParameter("@EventDealTitle", dealsManager.EventDealTitle));
            arlSQLParameters.Add(new SqlParameter("@SubCategoryId", dealsManager.SubCategoryId));


            arlSQLParameters.Add(new SqlParameter("@IsOnlyFeatured", dealsManager.IsOnlyFeatured));
            arlSQLParameters.Add(new SqlParameter("@IsBangla", dealsManager.IsBangla));
            arlSQLParameters.Add(new SqlParameter("@UploadedBy", dealsManager.UploadedBy));
            arlSQLParameters.Add(new SqlParameter("@ImageCount", dealsManager.ImageCount));


            arlSQLParameters.Add(new SqlParameter("@DeliveryChargeAmount", dealsManager.DeliveryChargeAmount));
            arlSQLParameters.Add(new SqlParameter("@DeliveryPaymentProcess", dealsManager.DeliveryChargeText));
            arlSQLParameters.Add(new SqlParameter("@DeliveryChargeAmountOutSideDhaka", dealsManager.OutsideDhakaDeliveryChargeAmount));

            arlSQLParameters.Add(new SqlParameter("@BrandId", dealsManager.BrandId));
            arlSQLParameters.Add(new SqlParameter("@AccountsTitle", dealsManager.AccountsTitle));
            arlSQLParameters.Add(new SqlParameter("@CommissionPerCoupon", dealsManager.CommissionPerCoupon));


            arlSQLParameters.Add(new SqlParameter("@ProductDeliveredType", dealsManager.ProductDeliveredType));
            arlSQLParameters.Add(new SqlParameter("@ProductInventoryType", dealsManager.ProductInventoryType));

            arlSQLParameters.Add(new SqlParameter("@IsShowAtHomePage", dealsManager.IsShowAtHomePage));
            arlSQLParameters.Add(new SqlParameter("@EventDescription", dealsManager.EventDealDescription));

            arlSQLParameters.Add(new SqlParameter("@BusinessModelType", dealsManager.BusinessModelType));
            arlSQLParameters.Add(new SqlParameter("@productSpecification", dealsManager.productSpecification)); //productSpecification BusinessModelType
            arlSQLParameters.Add(new SqlParameter("@SubSubCategoryId", dealsManager.SubSubCategoryId));
            arlSQLParameters.Add(new SqlParameter("@ProductColor", dealsManager.ProductColor));
            arlSQLParameters.Add(new SqlParameter("@MotherDealId", dealsManager.MotherDealId));
            arlSQLParameters.Add(new SqlParameter("@IsDealRestricted", dealsManager.IsDealRestricted));


            SqlParameter parameter = new SqlParameter("@NewId", SqlDbType.Int);

            //Set the parameter direction as output
            parameter.Direction = ParameterDirection.Output;

            arlSQLParameters.Add(parameter);



            intActionResult = this.ExecuteActionQuery("Deal.USP_InsertDealsWithMultiCat", arlSQLParameters);
            DealId = Convert.ToInt32(parameter.Value);
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
        finally
        {
            this.CloseConnection();
        }


        return DealId;
    }

    public int UpdateRecord_Deals(DealsManager dealsManager)
    {
        int intActionResult = 0;
        string dtmPostedOn = DateTime.Now.ToString();

        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@DealTitle", dealsManager.DealTitle));
            arlSQLParameters.Add(new SqlParameter("@ShortDescription", dealsManager.ShortDescription));
            arlSQLParameters.Add(new SqlParameter("@Description", dealsManager.Description));
            arlSQLParameters.Add(new SqlParameter("@CouponStartingDate", dealsManager.CouponStartingDate));
            arlSQLParameters.Add(new SqlParameter("@CouponExpiryDate", dealsManager.CouponExpiryDate));
            arlSQLParameters.Add(new SqlParameter("@TermsCondition", dealsManager.TermsCondition));

            arlSQLParameters.Add(new SqlParameter("@AboutSellers", dealsManager.AboutSellers));

            arlSQLParameters.Add(new SqlParameter("@SignupStartingDate", dealsManager.SignupStartingDate));
            arlSQLParameters.Add(new SqlParameter("@SignupClosingDate", dealsManager.SignupClosingDate));
            arlSQLParameters.Add(new SqlParameter("@IsActive", dealsManager.IsActive));
            arlSQLParameters.Add(new SqlParameter("@UpdatedOn", dealsManager.UpdatedOn));
            arlSQLParameters.Add(new SqlParameter("@ProfileID", dealsManager.ProfileID));
            arlSQLParameters.Add(new SqlParameter("@RegularPrice", dealsManager.RegularPrice));
            arlSQLParameters.Add(new SqlParameter("@DealPrice", dealsManager.DealPrice));
            arlSQLParameters.Add(new SqlParameter("@CouponPrice", dealsManager.CouponPrice));
            arlSQLParameters.Add(new SqlParameter("@DealDiscount", dealsManager.DealDiscount));
            arlSQLParameters.Add(new SqlParameter("@DealQtn", dealsManager.DealQtn));
            arlSQLParameters.Add(new SqlParameter("@QtnLimitPerUser", dealsManager.QtnLimitPerUser));
            arlSQLParameters.Add(new SqlParameter("@DistrictsId", dealsManager.DistrictsId));
            arlSQLParameters.Add(new SqlParameter("@LocationId", dealsManager.LocationId));
            arlSQLParameters.Add(new SqlParameter("@FolderName", dealsManager.FolderName));
            arlSQLParameters.Add(new SqlParameter("@DealDiscountInPercent", dealsManager.DealDiscountInPercent));
            arlSQLParameters.Add(new SqlParameter("@IsPercent", dealsManager.ApplicableDiscount));
            arlSQLParameters.Add(new SqlParameter("@DealPriority", dealsManager.DealPriority));
            arlSQLParameters.Add(new SqlParameter("@Process", dealsManager.Process));
            //arlSQLParameters.Add(new SqlParameter("@RestOfPayment", dealsManager.RestOfPayment));
            arlSQLParameters.Add(new SqlParameter("@DealId", dealsManager.DealId));

            arlSQLParameters.Add(new SqlParameter("@BulletAboutSellers", dealsManager.BulletAboutSellers));
            arlSQLParameters.Add(new SqlParameter("@BulletDescription", dealsManager.BulletDescription));
            arlSQLParameters.Add(new SqlParameter("@BulletTermsCondition", dealsManager.BulletTermsCondition));
            arlSQLParameters.Add(new SqlParameter("@DealType", dealsManager.DealType));

            arlSQLParameters.Add(new SqlParameter("@SocialTitle", dealsManager.SocialTitle));
            arlSQLParameters.Add(new SqlParameter("@SocialDescription", dealsManager.SocialDescription));
            arlSQLParameters.Add(new SqlParameter("@UseScanImage", dealsManager.UseScanImage));

            arlSQLParameters.Add(new SqlParameter("@CustomiseMsg", dealsManager.CustomiseMsg));
            arlSQLParameters.Add(new SqlParameter("@ImageExt", dealsManager.ImageExt));
            arlSQLParameters.Add(new SqlParameter("@CategoryId", dealsManager.CategoryId));
            //arlSQLParameters.Add(new SqlParameter("@IsShowStartingDate", dealsManager.IsShowStartingDate));
            arlSQLParameters.Add(new SqlParameter("@IsUpto", dealsManager.IsUpto));
            arlSQLParameters.Add(new SqlParameter("@CustomizeRateChart", dealsManager.CustomizeRateChart));
            arlSQLParameters.Add(new SqlParameter("@IsSoldOut", dealsManager.IsSoldOut));
            arlSQLParameters.Add(new SqlParameter("@IsMainDeal", dealsManager.IsMainDeal));
            arlSQLParameters.Add(new SqlParameter("@DealKeywords", dealsManager.DealKeywords));
            arlSQLParameters.Add(new SqlParameter("@UserId", dealsManager.UserId));
            arlSQLParameters.Add(new SqlParameter("@IsSubDeals", dealsManager.UserProfileID));

            arlSQLParameters.Add(new SqlParameter("@Sizes", dealsManager.Sizes));
            arlSQLParameters.Add(new SqlParameter("@Colors", dealsManager.Colors));
            arlSQLParameters.Add(new SqlParameter("@DeliveryCharge", dealsManager.DeliveryCharge));
            arlSQLParameters.Add(new SqlParameter("@CustomiseBuyCoupon", dealsManager.CustomizeBuyCoupon));
            arlSQLParameters.Add(new SqlParameter("@IsOnlyManual", dealsManager.IsOnlyManual));
            arlSQLParameters.Add(new SqlParameter("@ProductType", dealsManager.ProductType));

            arlSQLParameters.Add(new SqlParameter("@IsEventDeal", dealsManager.IsEventDeal));
            arlSQLParameters.Add(new SqlParameter("@EventDealTitle", dealsManager.EventDealTitle));
            arlSQLParameters.Add(new SqlParameter("@SubCategoryId", dealsManager.SubCategoryId));
            arlSQLParameters.Add(new SqlParameter("@IsOnlyFeatured", dealsManager.IsOnlyFeatured));
            arlSQLParameters.Add(new SqlParameter("@IsBangla", dealsManager.IsBangla));

            arlSQLParameters.Add(new SqlParameter("@DeliveryChargeAmount", dealsManager.DeliveryChargeAmount));
            arlSQLParameters.Add(new SqlParameter("@DeliveryPaymentProcess", dealsManager.DeliveryChargeText));

            arlSQLParameters.Add(new SqlParameter("@DeliveryChargeAmountOutSideDhaka", dealsManager.OutsideDhakaDeliveryChargeAmount));
            arlSQLParameters.Add(new SqlParameter("@BrandId", dealsManager.BrandId));
            arlSQLParameters.Add(new SqlParameter("@AccountsTitle", dealsManager.AccountsTitle));
            arlSQLParameters.Add(new SqlParameter("@CommissionPerCoupon", dealsManager.CommissionPerCoupon));

            arlSQLParameters.Add(new SqlParameter("@ProductDeliveredType", dealsManager.ProductDeliveredType));
            arlSQLParameters.Add(new SqlParameter("@ProductInventoryType", dealsManager.ProductInventoryType));
            arlSQLParameters.Add(new SqlParameter("@ImageCount", dealsManager.ImageCount));
            arlSQLParameters.Add(new SqlParameter("@IsShowAtHomePage", dealsManager.IsShowAtHomePage));
            arlSQLParameters.Add(new SqlParameter("@EventDescription", dealsManager.EventDealDescription));

            arlSQLParameters.Add(new SqlParameter("@BusinessModelType", dealsManager.BusinessModelType));
            arlSQLParameters.Add(new SqlParameter("@productSpecification", dealsManager.productSpecification)); //productSpecification BusinessModelType
            arlSQLParameters.Add(new SqlParameter("@SubSubCategoryId", dealsManager.SubSubCategoryId));
            arlSQLParameters.Add(new SqlParameter("@ProductColor", dealsManager.ProductColor));
            arlSQLParameters.Add(new SqlParameter("@MotherDealId", dealsManager.MotherDealId));
            arlSQLParameters.Add(new SqlParameter("@IsDealRestricted", dealsManager.IsDealRestricted));


            intActionResult = this.ExecuteActionQuery("Deal.USP_UpdateDeals", arlSQLParameters);
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
        finally
        {
            this.CloseConnection();
        }


        return intActionResult;
    }

    public void Delete_DealMultipleCategoryByDealId(int intDealId)
    {
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@DealId", intDealId));
            ExecuteActionQuery("Deal.USP_DeleteMultipleCategorySubCategory", arlSQLParameters);

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


    public DataTable GetDealsInfo(int intDealId)
    {
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@DealId", intDealId));

            return this.ExecuteQuery("Deal.USP_GetDealsInfo", arlSQLParameters);
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

    public DataTable LoadRecord_SubCategoryWithCategoryId(int CategoryId)
    {

        string dtmPostedOn = DateTime.Now.ToString();
        DataTable objDataTable = new DataTable();

        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@CategoryId", CategoryId));

            objDataTable = this.ExecuteQuery("Deal.USP_LoadSubCategory", arlSQLParameters);

            return objDataTable;
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

    public DataTable GetDealsMultipleCategory(int intDealId)
    {
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@DealId", intDealId));

            return this.ExecuteQuery("Deal.USP_LoadMultiCatSubCat", arlSQLParameters);
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

    public DataTable GetCompanyData(int @ProfileID)
    {

        DataTable objDatatable = new DataTable();

        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@ProfileID", ProfileID));

            objDatatable = this.ExecuteQuery("Deal.USP_BringCompanyData", arlSQLParameters);

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
    
    
    public int UpdateDealsChooseColumn(string columnName,string columnValue,string dealId,int userId)
    {
        int actionResult = 0;
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@DealCategory", columnName));
            arlSQLParameters.Add(new SqlParameter("@DealIdList", dealId));
            arlSQLParameters.Add(new SqlParameter("@IsCategorized", columnValue));
            arlSQLParameters.Add(new SqlParameter("@UserId", userId));

            actionResult = ExecuteActionQuery("Deal.USP_Update_Deals_By_Id_List", arlSQLParameters);
            
        }
        catch (Exception ex)
        {
            throw;
        }
        finally
        {
            CloseConnection();
        }
        return actionResult;
    }


    public int UpdateDealSize(string dealId, string size)
    {
        int actionResult = 0;
        try
        {
            OpenConnection();
            ArrayList arrSqlParameters = new ArrayList();
            arrSqlParameters.Add(new SqlParameter("@DealId", dealId));
            arrSqlParameters.Add(new SqlParameter("@Size", size));

            actionResult = ExecuteActionQuery("[Deal].[USP_Update_DealsSizeByDealId]", arrSqlParameters);
        }
        catch (Exception ex)
        {
            throw;
        }
        finally
        {
            CloseConnection();
        }
        return actionResult;
    }

    public List<Tuple<string, string>> Get_SuggestionForDealsEntry(string cityName)
    {
        DataTable objDatatable = new DataTable();

        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@keyword", cityName));

            objDatatable = this.ExecuteQuery("Deal.USP_LoadCompanyNameForDealsEntry", arlSQLParameters);
            List<Tuple<string, string>> list = new List<Tuple<string, string>>();
            list = (from data in objDatatable.AsEnumerable() select (new Tuple<string, string>(data["CompanyName"].ToString(), data["ProfileId"].ToString())))
                    .ToList();
            return list;
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

    public int UpdateDisplayImageNumber(int dealId, int imageNumber)
    {
        int actionResult = 0;
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@DealId", dealId));
            arlSQLParameters.Add(new SqlParameter("@ImageNumber", imageNumber));
            actionResult = ExecuteActionQuery("[Deal].[USP_UpdateDisplayImageNumber]", arlSQLParameters);

        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
        finally
        {
            this.CloseConnection();
        }
        return actionResult;
    }

}