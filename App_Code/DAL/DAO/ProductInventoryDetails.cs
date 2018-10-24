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
/// Summary description for ProductInventoryDetails
/// </summary>
public class ProductInventoryDetails
{
    public int DealId { get; set; }
    public string Size { get; set; }
    public int InQtn { get; set; }
    public int OutQtn { get; set; }
    public int InvOnlineOutQtn { get; set; }
    public int RejectedQtn { get; set; }
    public int BalanceQtn { get; set; }
    public string Comments { get; set; }
    public string BookingCode { get; set; }
    public string PostedBy { get; set; }
    public string PostedOn { get; set; }
    public string UpdatedOn { get; set; }
    public int UpdatedBy { get; set; }
}
