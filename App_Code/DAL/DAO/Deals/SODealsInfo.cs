using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Single Order Deals Info -SODealsInfo
/// </summary>
public class SODealsInfo
{
    public string DealId { get; set; }
    public string DealTitle { get; set; }
    public int DealPrice { get; set; }
    public int CouponPrice { get; set; }
    public string TotalPrice { get; set; }
    public string QtnLimitPerUser { get; set; }
    public string Sizes { get; set; }
    public string Color { get; set; }
    public string Quantity { get; set; }
    public string FolderName { get; set; }
    public int DeliveryCharge { get; set; }
    public int DeliveryChargeAmount { get; set; }
    public int DeliveryChargeAmountOutSideDhaka { get; set; }
    public int CommissionPerCoupon { get; set; }
}