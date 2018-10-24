using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AD_Users
/// </summary>
public class AD_Users
{
	public AD_Users()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public string userName { get; set; }
    public string fullName { get; set; }
    public string passWord { get; set; }
    public string email { get; set; }
    public string address { get; set; }
    public string bloodGroup { get; set; }
    public string gender { get; set; }
    public string mobileNo { get; set; }
    public int adminType { get; set; }
    public int isActive { get; set; }
    public DateTime postedOn { get; set; }
    public int postedBy { get; set;}
    public int updateBy { get; set; }
}