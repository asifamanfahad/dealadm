using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for DiscountZone
/// </summary>
public class DiscountZone
{
	public DiscountZone()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private int _CategoryID;

    public int CategoryID
    {
        get { return _CategoryID;}
        set { _CategoryID = value; }
    }

    private int _CouponID;

    public int CouponID
    {
        get { return _CouponID; }
        set { _CouponID = value; }
    }

    private int _SourceId;

    public int SourceId
    {
        get { return _SourceId; }
        set { _SourceId = value; }
    }

    private int _IsPaid;

    public int IsPaid
    {
        get { return _IsPaid; }
        set { _IsPaid = value; }
    }

    private int _WantInHotDiscount;

    public int WantInHotDiscount
    {
        get { return _WantInHotDiscount; }
        set { _WantInHotDiscount = value; }
    }

    private int _SubcategoryID;

    public int SubcategoryID
    {
        get { return _SubcategoryID; }
        set { _SubcategoryID = value; }
    }

    private int _ProfileID;

    public int ProfileID
    {
        get { return _ProfileID; }
        set { _ProfileID = value; }
    }


    private int _DiscountUserType;

    public int DiscountUserType
    {
        get { return _DiscountUserType;}
        set { _DiscountUserType = value; }
    }

    private DateTime _CouponEffectiveDate;

    public DateTime CouponEffectiveDate
    {
        get { return _CouponEffectiveDate; }
        set { _CouponEffectiveDate = value; }
    }

    private DateTime _CouponExpirydate;

    public DateTime CouponExpirydate
    {
        get { return _CouponExpirydate; }
        set { _CouponExpirydate = value; }
    }

    private string _Extension;

    public string Extension
    {
        get { return _Extension; }
        set { _Extension = value; }
    }

    private string _ExternalLink;

    public string ExternalLink
    {
        get { return _ExternalLink; }
        set { _ExternalLink = value; }
    }

    private bool _ImageSelection;

    public bool ImageSelection
    {
        get { return _ImageSelection; }
        set { _ImageSelection = value; }
    }

    private string _CouponTitle;

    public string CouponTitle
    {
        get { return _CouponTitle; }
        set {_CouponTitle=value;}
    }
    
    private string _FolderName;

    public string FolderName
    {
        get { return _FolderName; }
        set { _FolderName = value; }
    }

    private int _FromPercent;

    public int FromPercent
    {
        get { return _FromPercent; }
        set { _FromPercent = value; }
    }
    
    private int _ToPercent;

    public int ToPercent
    {
        get { return _ToPercent; }
        set { _ToPercent = value; }
    }

    private int _DiscountType;

    public int DiscountType
    {
        get { return _DiscountType; }
        set { _DiscountType = value; }
    }

    private int _UseHTML;

    public int UseHTML
    {
        get { return _UseHTML; }
        set { _UseHTML = value; }
    }

    private int _UseBrand;

    public int UseBrand
    {
        get { return _UseBrand; }
        set { _UseBrand = value; }
    }

    private string _BrandName;

    public string BrandName
    {
        get { return _BrandName; }
        set { _BrandName = value; }
    }

    private int _DiscountInTaka;

    public int DiscountInTaka
    {
        get { return _DiscountInTaka; }
        set { _DiscountInTaka = value; }
    }

    private int _ApplicableDiscount;

    public int ApplicableDiscount
    {
        get { return _ApplicableDiscount; }
        set { _ApplicableDiscount = value; }
    }

    private string _SpecialInstruction;

    public string SpecialInstruction
    {
        get { return _SpecialInstruction; }
        set { _SpecialInstruction = value; }
    }


    private string _DiscountSubcriptionEmail;

    public string DiscountSubcriptionEmail
    {
        get { return _DiscountSubcriptionEmail; }
        set { _DiscountSubcriptionEmail = value; }
    }


    private string _CouponDescription;

    public string CouponDescription
    {
        get { return _CouponDescription; }
        set { _CouponDescription = value; }
    }

    private string _CouponType;

    public string CouponType
    {
        get { return _CouponType; }
        set { _CouponType = value; }
    }
    private string _DiscountCouponURL;

    public string DiscountCouponURL
    {
        get { return _DiscountCouponURL; }
        set { _DiscountCouponURL = value; }
    }

    private string _CouponCode;

    public string CouponCode
    {
        get { return _CouponCode; }
        set { _CouponCode = value; }
    }

    private string _TermsCondition;

    public string TermsCondition
    {
        get { return _TermsCondition; }
        set { _TermsCondition = value; }
    }

     private bool _NeedToPrintCoupon;

    public bool NeedToPrintCoupon
    {
        get { return _NeedToPrintCoupon; }
        set { _NeedToPrintCoupon = value; }
    }

    private int _UseBoromelaCoupon;

    public int UseBoromelaCoupon
    {
        get { return _UseBoromelaCoupon; }
        set { _UseBoromelaCoupon = value; }
    }

    private string _UserUploadedCouponPath;

    public string UserUploadedCouponPath
    {
        get { return _UserUploadedCouponPath; }
        set { _UserUploadedCouponPath = value; }
    }

    private bool _IsActive;

    public bool IsActive
    {
        get { return _IsActive; }
        set {_IsActive=value;}
    }

    private bool _IsAdminAuthentication;

    public bool IsAdminAuthentication
    {
        get { return _IsAdminAuthentication; }
        set {_IsAdminAuthentication=value;}
    }


    private DateTime _UpdatedOn;

    public DateTime UpdatedOn
    {
        get { return _UpdatedOn; }
        set { _UpdatedOn = value; }
    }

    private bool _CheckAdminForListing;

    public bool CheckAdminForListing
    {
        get { return _CheckAdminForListing; }
        set { _CheckAdminForListing = value; }
    }

    private bool _CheckAdminForListingFeatureStore;

    public bool CheckAdminForListingFeatureStore
    {
        get { return _CheckAdminForListingFeatureStore; }
        set { _CheckAdminForListingFeatureStore = value; }
    }

    private bool _UserType;

    public bool UserType
    {
        get { return _UserType; }
        set { _UserType = value; }
    }

    private string _EmailAddress;

    public string EmailAddress
    {
        get { return _EmailAddress; }
        set {_EmailAddress=value;}
    }

    private string _Name;

    public string Name
    {
        get { return _Name; }
        set { _Name = value; }
    }

    private string _Subject;

    public string Subject
    {
        get { return _Subject; }
        set { _Subject = value; }
    }

    private string _Report;

    public string Report
    {
        get { return _Report; }
        set { _Report = value; }
    }


    private string _Comment;

    public string Comment
    {
        get { return _Comment; }
        set { _Comment = value; }
    }
}
