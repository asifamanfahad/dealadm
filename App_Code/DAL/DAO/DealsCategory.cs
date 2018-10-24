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
/// Summary description for DealsCategory
/// </summary>
public class DealsCategory
{
	public DealsCategory()
	{
		//
		// TODO: Add constructor logic here
		//
	    Hit = 0;
	}
    public int CategoryID { get; set; }
    public string Category { get; set; }
    public string CategoryEng { get; set; }
    public int IsActive { get; set; }
    public int IsHit { get; set; }
    public int OrderBy { get; set; }
    public int Hit { get; set; }

}
