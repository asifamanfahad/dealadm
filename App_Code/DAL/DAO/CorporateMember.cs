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
/// Summary description for CorporateMember
/// </summary>
public class CorporateMember
{
	public CorporateMember()
	{
		//
		// TODO: Add constructor logic here
		//


	}
    private int id;
    private int dealUsedQuantity;

    public int Id { get; set; }
    public int CorporateId{get;set;}
    public int CMType { get; set; }
    public DateTime CMRegistrationDate { get; set; }
    public DateTime CMExpireDate { get; set; }
    public int DealQuantity { get; set; }
    public int DealUsedQuantity { get { return dealUsedQuantity; } }
    public string FolderName { get; set; }
    public int IsActive { get; set; }
    public int IsRenewed { get; set; }
    public int IsDeleted { get; set; }
    public int UserId { get; set; }


}
