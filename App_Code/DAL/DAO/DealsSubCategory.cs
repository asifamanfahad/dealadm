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
/// Summary description for DealsSubCategory
/// </summary>
public class DealsSubCategory
{
	public DealsSubCategory()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int SubcategoryID { get; set; }
    public string CategoryID { get; set; }
    public string Subcategory { get; set; }
    public string SubcategoryEng { get; set;}
    public int IsActive { get; set; }
    
    public int OrderBy { get; set; }
    public int Hit { get; set; }
}
