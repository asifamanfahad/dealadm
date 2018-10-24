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
/// Summary description for AdsManagement
/// </summary>
public class AdsManagement
{

    public int Id { get; set; }
    public string UniqueId { get; set; }
    public int UserId { get; set; }
    public int AdsType { get; set; }
    public int AdsFileType { get; set; }
    public string AdsUrl { get; set; }
    public string AdsPrice { get; set; }
    public string FolderName { get; set; }
    public string MerchantName { get; set; }
    public DateTime AdsRegistrationDate { get; set; }
    public DateTime AdsExpireDate { get; set; }
    public DateTime LastUpdateDate { get; set; }
    public int IsActive { get; set; }
    public int HitCount { get; set; }
    public int Height { get; set; }
    public int Width { get; set; }
    public int OrderBy { get; set; }


    public AdsManagement()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
