using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Banner
/// </summary>
public class Banner
{
	public Banner()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public string Pagename { get; set; }
    public string Position { get; set; }
    public string Category { get; set; }
    public string SubCategory { get; set; }
    public string Action_url { get; set; }
    public string Image_url { get; set; }
    public string Imagename { get; set; }
    public int Orderby { get; set; }
    public int IsActive { get; set; }
    public string Postedby { get; set; }
    public DateTime Date { get; set; }
    public string BannerImage { get; set; }
}