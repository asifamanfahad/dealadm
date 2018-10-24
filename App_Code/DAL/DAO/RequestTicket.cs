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
/// Summary description for RequestTicket
/// </summary>
public class RequestTicket
{
	public RequestTicket()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int RequestID { get; set; }
    public int TicketID { get; set; }
    public string RequestDetails { get; set; }
    public string RequestOn { get; set; }
    
}
