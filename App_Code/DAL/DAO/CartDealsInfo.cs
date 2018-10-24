using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CartDealsInfo
/// </summary>
public class CartDealsInfo
{
    public string DealId { get; set; }
    public string DealTitle { get; set; }
    public string QtnLimitPerUser { get; set; }
    public string FolderName { get; set; }
    public int DealPrice { get; set; }
    public int DeliveryCharge { get; set; }
    public int DeliveryChargeAmount { get; set; }
    public int DeliveryChargeAmountOutSideDhaka { get; set; }
    public string ProfileId { get; set; }
    public string CompanyName { get; set; }
}