using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for ControlPanelService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
 [System.Web.Script.Services.ScriptService]
public class ControlPanelService : System.Web.Services.WebService {

    public ControlPanelService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string LoadDayWiseDeliverd(string DayWiseId)
    {
        String fromDate = string.Empty;
        String toDate = string.Empty;

        if (DayWiseId == "DayWiseL0")
        {
            fromDate = DateTime.Now.ToShortDateString();
            toDate = DateTime.Now.ToShortDateString();
        }

        else if ( DayWiseId == "DayWiseL1" )
        {
            fromDate = DateTime.Now.ToShortDateString();
            toDate = DateTime.Now.ToShortDateString();
        }

        else if (DayWiseId == "DayWiseL2")
        {
            fromDate = DateTime.Now.AddDays(-1).ToShortDateString();
            toDate = DateTime.Now.AddDays(-1).ToShortDateString();
        }

        else if (DayWiseId == "DayWiseL3")
        {
            fromDate = DateTime.Now.AddDays(-3).ToShortDateString();
            toDate = DateTime.Now.ToShortDateString();
        }

        else if (DayWiseId == "DayWiseL7")
        {
            fromDate = DateTime.Now.AddDays(-7).ToShortDateString();
            toDate = DateTime.Now.ToShortDateString();
        }

        String tableDays = string.Empty;

        using (ControlPanelGateway ObjControlGateway = new ControlPanelGateway())
        {
            DataTable table = ObjControlGateway.DayWiseDeliverd(fromDate, toDate);
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    String Days = "<td><b class='green'>" + row["Days"] + "</b></td>";
                    String Deliverd = "<td data-toggle='modal' data-target='#Model1'><a><b class='pink' id='" + fromDate + "@" + toDate + "@" + row["Days"] + "' style='cursor: pointer;' onclick='GetDayWisePop(this.id);'>" + row["Deliverd"] + "</b></a></td>";
                    tableDays = tableDays + "<tr>" + Days + Deliverd + "</tr>";
                }
            }
        }

        return tableDays;
    }

    [WebMethod]
    public string LoadDayWiseDeliverdPopUp(string StartDate, string EndDate, string DayFlag)
    {
        StringBuilder data = new StringBuilder();
        DataTable dataTable;

        data.Append("<div><h4 style='text-align:center;'>Day Wise Deliverd Details</h4></div>");
        data.Append("<table class='table table-bordered'>");
        data.Append("<thead class='table-striped'>");
        data.Append("<tr class='odd gradeX'>");
        data.Append("<th style='width: 83px;'>SNo.</th><th>Booking Code</th><th>POD Number</th><th>Deal Title</th><th>Quantity</th><th>Price</th><th>Company Name</th><th>Order From</th><th>Courier</th><th>Order Date</th><th>Confirmation Date</th><th>Comments</th><th>Commented By</th><th>Image</th>");
        data.Append("</th></tr></thead>");

        data.Append("<tbody>");
        using (ControlPanelGateway ObjControlPanelGateway = new ControlPanelGateway())
        {
            dataTable = ObjControlPanelGateway.DayWiseDeliverdModal(StartDate, EndDate, DayFlag);            
        }


        if (dataTable != null && dataTable.Rows.Count > 0)
        {
            int count = 1;
            foreach (DataRow row in dataTable.Rows)
            {
                data.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{3}</td><td>{4}(<a href='http://www.ajkerdeal.com/Product/{2}/{14}' target=_blank>{2}</a>)</td><td>{13}</td><td>{12}</td><td>{5}</td><td>{6}</td><td>{7}</td><td>{8}</td><td>{9}</td><td>{10}</td><td>{15}</td><td>{11}</td></tr>",
                    count++, "<span data-toggle='modal' data-target='#GetDeal' onclick='GetDetailsPopup(this.id);' id='" + row["CouponId"] + "'><b style='color:#DEB887;cursor:pointer;'>" + row["CouponId"] + "</b></span>",
                    row["DealId"], row["PODnumber"], row["DealTitle"], row["CompanyName"], row["OrderFrom"],
                    row["Courier"], row["PostedOn"], row["CrmConfirmationDate"], row["Comments"],
                    "<img src='http://www.ajkerdeal.com/images/Deals/" + row["FolderName"] + "/dealdetails1.jpg' width='60px'>", row["CouponPrice"], row["CouponQtn"], row["DealTitleEng"], row["CommentedBy"]);
            }
        }
        else
        {
            return null;
        }

        data.Append("</tbody></table>");
        return data.ToString();
    }


    [WebMethod]
    public string SoldOutProduct(string DealId,int userId)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("DealId", typeof(string));
        dt.Columns.Add("FieldType", typeof(string));
        dt.Columns.Add("OldValue", typeof(string));
        dt.Columns.Add("NewValue", typeof(string));
        dt.Columns.Add("UpdateBy", typeof(string));
        using (ControlPanelGateway ObjControlPanelGateway = new ControlPanelGateway())
        { 
            ObjControlPanelGateway.SoldOutProduct_Update(DealId);
           
        }
        dt.Rows.Add(DealId, "IsSoldOut", "", "", userId);
        DealTranctionGateway objDealsGateway = new DealTranctionGateway();
        objDealsGateway.InsertDealTranction(dt);

        return DealId;
    }

}
