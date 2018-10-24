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
/// Summary description for TrackingSystemInboundCall
/// </summary>
public class TrackingSystemInboundCall
{
    public int Id { get; set; }
    public DateTime DateOfCall { get; set; }
    public int CallerContactType { get; set; }
    public string CallerName { get; set; }
    public string CallerEmail { get; set; }
    public string CallerPhone { get; set; }
    public int CallerIsRegister { get; set; }
    public int CallerContactReason { get; set; }
    public int AnswerBy { get; set; }
    public int IsIssueSolved { get; set; }
    public string Comments { get; set; }
    public int IsActive { get; set; }
    public int IsDeleted { get; set; }
	public TrackingSystemInboundCall()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
