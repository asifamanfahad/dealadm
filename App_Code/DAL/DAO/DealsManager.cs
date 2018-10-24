using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;


/// <summary>
/// Summary description for DealsManager
/// </summary>
public class DealsManager
{
    public DealsManager()
	{
		//
		// TODO: Add constructor logic here
		//
	}
	
	public int QtyAfterBooking { get; set; }
	
	public int IsDealRestricted { get; set; }
	 
	public string _ProductColor { get; set; }

    public string ProductColor 
    {
        get { return _ProductColor; }
        set { _ProductColor = value; }
    }
	
	public int BusinessModelType { get; set; }

    public string productSpecification { get; set; }
	
	public string EventDealDescription { get; set; }
	
    public string ProductDeliveredType { get; set; }
    public string ProductInventoryType { get; set; }

    public int BrandId { get; set; }

    private string _Sizes;

    public string Sizes
    {
        get { return _Sizes; }
        set { _Sizes = value; }
    }

    private string _Colors;

    public string Colors
    {
        get { return _Colors; }
        set { _Colors = value; }
    }

    private int _DeliveryCharge;

    public int DeliveryCharge
    {
        get { return _DeliveryCharge; }
        set { _DeliveryCharge = value; }
    }

    private int _MotherDealId;

    public int MotherDealId
    {
        get { return _MotherDealId; }
        set { _MotherDealId = value; }
    }
    
    private int _UserId;

    public int UserId
    {
        get { return _UserId; }
        set { _UserId = value; }
    }
    
    private int _DealId;

    public int DealId
    {
        get { return _DealId; }
        set { _DealId = value; }
    }

    private int _UseScanImage;

    public int UseScanImage
    {
        get { return _UseScanImage; }
        set { _UseScanImage = value; }
    }

    private int _IsSoldOut;

    public int IsSoldOut
    {
        get { return _IsSoldOut; }
        set { _IsSoldOut = value; }
    }

    private int _IsMainDeal;

    public int IsMainDeal
    {
        get { return _IsMainDeal; }
        set { _IsMainDeal = value; }
    }

    private int _IsShowStartingDate;

    public int IsShowStartingDate
    {
        get { return _IsShowStartingDate; }
        set { _IsShowStartingDate = value; }
    }

    private int _IsUpto;

    public int IsUpto
    {
        get { return _IsUpto; }
        set { _IsUpto = value; }
    }

    private int _CategoryId;

    public int CategoryId
    {
        get { return _CategoryId; }
        set { _CategoryId = value; }
    }
    
    private int _LocationId;

    public int LocationId
    {
        get { return _LocationId; }
        set { _LocationId = value; }
    }

    private int _DistrictsId;

    public int DistrictsId
    {
        get { return _DistrictsId; }
        set { _DistrictsId = value; }
    }


    private int _QtnLimitPerUser;

    public int QtnLimitPerUser
    {
        get { return _QtnLimitPerUser; }
        set { _QtnLimitPerUser = value; }
    }

    private int _DealQtn;

    public int DealQtn
    {
        get { return _DealQtn; }
        set { _DealQtn = value; }
    }

    private int _DealPriority;

    public int DealPriority
    {
        get { return _DealPriority; }
        set { _DealPriority = value; }
    }

    private string _DealKeywords;

    public string DealKeywords
    {
        get { return _DealKeywords; }
        set { _DealKeywords = value; }
    }

    private string _CustomiseMsg;

    public string CustomiseMsg
    {
        get { return _CustomiseMsg; }
        set { _CustomiseMsg = value; }
    }

    private string _ImageExt;

    public string ImageExt
    {
        get { return _ImageExt; }
        set { _ImageExt = value; }
    }

    private string _CustomizeRateChart;

    public string CustomizeRateChart
    {
        get { return _CustomizeRateChart; }
        set { _CustomizeRateChart = value; }
    }

    private string _SocialTitle;

    public string SocialTitle
    {
        get { return _SocialTitle; }
        set { _SocialTitle = value; }
    }

    private string _SocialDescription;

    public string SocialDescription
    {
        get { return _SocialDescription; }
        set { _SocialDescription = value; }
    }

    private string _BulletDescription;

    public string BulletDescription
    {
        get { return _BulletDescription; }
        set { _BulletDescription = value; }
    }

    private string _BulletAboutSellers;

    public string BulletAboutSellers
    {
        get { return _BulletAboutSellers; }
        set { _BulletAboutSellers = value; }
    }

    private string _BulletTermsCondition;

    public string BulletTermsCondition
    {
        get { return _BulletTermsCondition; }
        set { _BulletTermsCondition = value; }
    }

    private string _Process;

    public string Process
    {
        get { return _Process; }
        set { _Process = value; }
    }

    private string _DealType;

    public string DealType
    {
        get { return _DealType; }
        set { _DealType = value; }
    }

    private string _RestOfPayment;

    public string RestOfPayment
    {
        get { return _RestOfPayment; }
        set { _RestOfPayment = value; }
    }

    private string _FolderName;

    public string FolderName
    {
        get { return _FolderName; }
        set { _FolderName = value; }
    }

    private string _ShortDescription;

    public string ShortDescription
    {
        get { return _ShortDescription; }
        set { _ShortDescription = value; }
    }

    private string _DealDiscount;

    public string DealDiscount
    {
        get { return _DealDiscount; }
        set { _DealDiscount = value; }
    }

    private string _CouponPrice;

    public string CouponPrice
    {
        get { return _CouponPrice; }
        set { _CouponPrice = value; }
    }

    private string _DealPrice;

    public string DealPrice
    {
        get { return _DealPrice; }
        set { _DealPrice = value; }
    }

    private string _RegularPrice;

    public string RegularPrice
    {
        get { return _RegularPrice; }
        set { _RegularPrice = value; }
    }

    private int _ApplicableDiscount;

    public int ApplicableDiscount
    {
        get { return _ApplicableDiscount; }
        set { _ApplicableDiscount = value; }
    }

    private int _DealDiscountInPercent;

    public int DealDiscountInPercent
    {
        get { return _DealDiscountInPercent; }
        set { _DealDiscountInPercent = value; }
    }

    private int _BoroMelaDiscountSpecialID;

    public int BoroMelaDiscountSpecialID
    {
        get { return _BoroMelaDiscountSpecialID; }
        set { _BoroMelaDiscountSpecialID = value; }
    }

    private string _UserName;

    public string UserName
    {
        get { return _UserName; }
        set { _UserName = value; }
    }

    private int _UserProfileID;

    public int UserProfileID
    {
        get { return _UserProfileID; }
        set { _UserProfileID = value; }
    }

    private int _CompanyProfileID;

    public int CompanyProfileID
    {
        get { return _CompanyProfileID; }
        set { _CompanyProfileID = value; }
    }

    private string _EmailAddress;

    public string EmailAddress
    {
        get { return _EmailAddress; }
        set { _EmailAddress = value; }
    }

    private string _DealTitle;

    public string DealTitle
    {
        get { return _DealTitle; }
        set { _DealTitle = value; }
    }

    private string _Description;

    public string Description
    {
        get { return _Description; }
        set { _Description = value; }
    }

    private DateTime _CouponStartingDate;

    public DateTime CouponStartingDate
    {
        get { return _CouponStartingDate; }
        set { _CouponStartingDate = value; }
    }


    private DateTime _CouponExpiryDate;

    public DateTime CouponExpiryDate
    {
        get { return _CouponExpiryDate; }
        set { _CouponExpiryDate = value; }
    }

    private string _CouponType;

    public string CouponType
    {
        get { return _CouponType; }
        set { _CouponType = value; }
    }


    private string _TermsCondition;

    public string TermsCondition
    {
        get { return _TermsCondition; }
        set { _TermsCondition = value; }
    }


    private int _RequiredSignups;

    public int RequiredSignups
    {
        get { return _RequiredSignups; }
        set { _RequiredSignups = value; }
    }

    private string _SignupsNotAchievedOffer;

    public string SignupsNotAchievedOffer
    {
        get { return _SignupsNotAchievedOffer; }
        set { _SignupsNotAchievedOffer = value; }
    }

    private string _ProductImage;

    public string ProductImage
    {
        get { return _ProductImage; }
        set { _ProductImage = value; }
    }

    private string _AboutSellers;

    public string AboutSellers
    {
        get { return _AboutSellers; }
        set { _AboutSellers = value; }
    }

    private string _WatchOutTitle;

    public string WatchOutTitle
    {
        get { return _WatchOutTitle; }
        set { _WatchOutTitle = value; }
    }


    private string _WatchOut;

    public string WatchOut
    {
        get { return _WatchOut; }
        set { _WatchOut = value; }
    }

    private DateTime _SignupStartingDate;

    public DateTime SignupStartingDate
    {
        get { return _SignupStartingDate; }
        set { _SignupStartingDate = value; }
    }

    private DateTime _SignupClosingDate;

    public DateTime SignupClosingDate
    {
        get { return _SignupClosingDate; }
        set { _SignupClosingDate = value; }
    }

    private bool _IsActive;

    public bool IsActive
    {
        get { return _IsActive; }
        set { _IsActive = value; }
    }

    private int _ProfileID;

    public int ProfileID
    {
        get { return _ProfileID; }
        set { _ProfileID = value; }
    }

    private DateTime _InsertedOn;

    public DateTime InsertedOn
    {
        get { return _InsertedOn; }
        set { _InsertedOn = value; }
    }

    private DateTime _UpdatedOn;

    public DateTime UpdatedOn
    {
        get { return _UpdatedOn; }
        set { _UpdatedOn = value; }
    }

    /*Added By Tanzila Akter(29-12-12)*/
    public int IsFirstDeal { get; set; }
    public int IsSimilar { get; set; }
    public int UploadedBy { get; set; }
    public string AmountOfFixedIncome { get; set; }
    public string CommissionPerCoupon { get; set; }
    public string CommentsOnRegularPrice { get; set; }
    public string CustomizeBuyCoupon { get; set; }
    public bool IsOnlyManual { get; set; }
    public int ProductType { get; set; }

    public int IsEventDeal { get; set; }
    public string EventDealTitle { get; set; }
    public int SubCategoryId { get; set; }
    public int SubSubCategoryId { get; set; }
    public int ImageCount { get; set; }

    public bool IsOnlyFeatured { get; set; }
    public int IsBangla { get; set; }

    public string DeliveryChargeText { get; set; }
    public int DeliveryChargeAmount { get; set; }

    public int OutsideDhakaDeliveryChargeAmount { get; set; }

    public string AccountsTitle { get; set; }
    public bool IsShowAtHomePage { get; set; }
    
}
