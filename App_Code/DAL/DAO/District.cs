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
/// Summary description for District
/// </summary>
public class District
{
	public District()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int DistrictID { get; set; }
    public string DeliveryDistrict { get; set; }
    public int DeliveryCharge { get; set; }
    public int IsActive { get; set; }
    public int UpdatedBy { get; set; }
    public string UpdatedOn { get; set; }
}
