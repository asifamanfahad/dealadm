using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DeliveryDetails
/// </summary>
public class DeliveryDetails
{
    /// <summary>
    /// DeliveryDetailsId - int
    /// CouponId - int
    /// ExpectedDeliveryDate - small date time
    /// CourierName - nvarchar
    /// ContactInfo - nvarchar
    /// </summary>
    public string DeliveryDetailsId { set; get; } 
    public string CouponId { set; get; }
    public string ExpectedDeliveryDate { set; get; }
    public string CourierName { set; get; }
    public string ContactInfo { set; get; }
}