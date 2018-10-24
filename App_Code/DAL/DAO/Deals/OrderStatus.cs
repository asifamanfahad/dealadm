using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// OrderStatus History is using to keep
/// track of our booking status time to time.
/// each time CRM,Inventory change an order 
/// status from New to ToBeDelivered
/// ToBeDelivered to Delivered we insert the status with date,couponId and others parameter
/// OrderDate small datetime -keeps CouponEntry Date
/// /// ConfirmationDate small datetime -In which Date CRM /Inventory update the status
/// </summary>
public class OrderStatus
{
    public string Id { set; get; }
    public string CouponId { set; get; }
    public DateTime OrderDate { set; get; }
    public string Status { set; get; }
    public DateTime ConfirmationDate { set; get; }
    public string ConfirmedBy { set; get; }
    public string MerchantId { set; get; }
    public string DealId { set; get; }
    public int CustomerId { get; set; }
    public DateTime DeliveryConfirmationDate { get; set; }
    public int IsConfirmedByMerchant { get; set; }

    public OrderStatus()
    {
        
    }

}