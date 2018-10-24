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
/// Summary description for ProductInventory
/// </summary>
public class ProductInventory
{
    public int DealId { get; set; }
    public string Size { get; set; }
    public int InitialQtn { get; set; }
    public int ActualAvailableQtn { get; set; }
    public int StoreAvailableQtn { get; set; }
    public int RejectedQtn { get; set; }
    public string PaymentId { get; set; }
    public string BookingCode { get; set; }
    public string Comments { get; set; }
    public string PostedOn { get; set; }
    public int PostedBy { get; set; }
    public int UpdatedBy { get; set; }
    public string UpdatedOn { get; set; }
    public int IsActive { get; set; }
    public int IsDeleted { get; set; }
    
}
