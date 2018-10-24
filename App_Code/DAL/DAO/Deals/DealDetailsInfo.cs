using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DealsInfo
/// </summary>
public class DealDetailsInfo
{
    public int DealId { get; set; }
    public int MotherDealId { get; set; }
    public string DealTitle { get; set; }
    public string AccountsTitle { get; set; }
    public string ShortDescription { get; set; }
    
    public string QtnLimitPerUser { get; set; }
    public string Sizes { get; set; }
    public string Color { get; set; }
    public string Quantity { get; set; }

    public int RegularPrice { get; set; }
    public int DealPrice { get; set; }
    public int DealDiscount { get; set; }
    public int CouponPrice { get; set; }
    public string TotalPrice { get; set; }
    public int CommissionPerCoupon { get; set; }
    
    public string TermsCondition { get; set; }
    public string Process { get; set; }
    public string FolderName { get; set; }
    public int CompanyId { get; set; }
    public string CompanyName { get; set; }
    public string CompanyNameBng { get; set; }


    public int ImageCount { get; set; }
    public string ImageExt { get; set; }
    public string BulletDescription { get; set; }
    public string BulletAboutSellers { get; set; }
    public string BulletTermsCondition { get; set; }
    public string productSpecification { get; set; }
    public string DeliveryPaymentProcess { get; set; }
    public string CustomizeRateChart { get; set; }
   
    
    public int DeliveryCharge { get; set; }
    public int DeliveryChargeAmount { get; set; }
    public int DeliveryChargeAmountOutSideDhaka { get; set; }

    public bool IsUseScanImage { get; set; }
    public bool IsSoldOut { get; set; }
    public bool IsDealClosed { get; set; }
    public bool UseScanImage { get; set; }
    public bool IsHotDeal { get; set; }

	public int CategoryId { get; set; }
	public int SubCategoryId { get; set; }
	public int SubSubCategoryID { get; set; }
	
    public string Subcategory { get; set; }
    public string Category { get; set; }
    public string SubcategoryEng { get; set; }
    public string CategoryEng { get; set; }
   
  



}