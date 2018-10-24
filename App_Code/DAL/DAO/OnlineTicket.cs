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
/// Summary description for OnlineTicket
/// </summary>
public class OnlineTicket
{
	public OnlineTicket()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int TicketID { get; set; }
    public int CustomerId { get; set; }
    public string  CustomerEmail { get; set; }
    public string CustomerPhone { get; set; }
    public string TrackingNumber { get; set; }
    public int InquiryFor { get; set; }
    public int Status { get; set; }
    public int Priority { get; set; }
    public int IsSolved { get; set; }
    public int AssignedTo { get; set; }
    public int ClaimedBy { get; set; }
    public string ClaimedOn { get; set; }
    public string RequestDate { get; set; }
    public string RequestStartingDate { get; set; }
    public string RequestEndingDate { get; set; }
    public string TicketClosedOn { get; set; }
    public string PostedOn { get; set; }
    public int IsActive { get; set; }
    public int IsDelete { get; set; }
}
