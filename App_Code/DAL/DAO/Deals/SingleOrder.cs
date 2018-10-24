using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SingleOrder
/// </summary>
public class SingleOrder
{
    public string DealId { get; set; }
    public string DealTitle { get; set; }
    public string FolderName { get; set; }
    public string CCouponId { get; set; }
    public string CustomerId { get; set; }
    public string CMobile { get; set; }
    public string CAlternateMobile { get; set; }

    public string CAddress { get; set; }
    public string CPaymentType { get; set; }
    public string CCardType { get; set; }
    public string CQuantity { get; set; }
    public string CPrice { get; set; }
    public string CDelivery { get; set; }
    public string CPaymentAmount { get; set; }

    public string CBookingCode { get; set; }
    public string CCouponCode { get; set; }
    public string CSize { get; set; }
    public string CColor { get; set; }
    public string CAskingDeliveryDist { get; set; }
    public string CAskingDeliveryStatus { get; set; }
    public string CCommissionPerCoupon { get; set; }

    public string CTransactionId { get; set; }
    public string CValidationId { get; set; }
    public string CPaymentMessage { get; set; }
    public string CPaymentStatus { get; set; }
    public string CName { get; set; }
    public string CEmail { get; set; }
    public string OrderSource { get; set; }
}