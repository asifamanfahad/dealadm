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
/// Summary description for UpcommingDealsProperty
/// </summary>
public class UpcommingDealsProperty
{
	public UpcommingDealsProperty()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int UpcommingDealId{ set; get; }
    public string UpCommingDealTitle { set; get; }
    public string UpCommingDealDate { set; get; }
    public string UpCommingFolderName { set; get; }
    public int UpCommingDealPriority { set; get; }
    public string UpcommingDealsImage { set; get; }
}
