using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ShoppingCart
/// </summary>
public class ShoppingCart
{
	public ShoppingCart()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public string CartID { get; set; }
    public string ShopCartDetailsID { get; set; }
    public string CartSessionID { get; set; }
    public string CartDealID { get; set; }
    public string CartDealTitle { get; set; }
    public string CartFolderName { get; set; }
    public string CartCustomerID { get; set; }
    public string CartQuantity { get; set; }
    public string CartSize { get; set; }
    public string CartColor { get; set; }
    public string CartUnitPrice { get; set; }
    public string CartTotalPrice { get; set; }
    public string CartCommissionPerCoupon { get; set; }
    public string CartDeliveryChargeType { get; set; }
    public string CartDeliveryChargeInsideDhaka { get; set; }
    public string CartDeliveryChargeOutsideDhaka { get; set; }
    public string CartDeliveryCharge { get; set; }
    public string CartCouponId { get; set; }
    public string CartCouponCode { get; set; }
    public string CartBookingCode { get; set; }
    public string CartCardType { get; set; }
    public string CartPaymentType { get; set; }
    public string CartCustomerMobile { get; set; }
    public string CartAlternateMobile { get; set; }
    public string CartCustomerAddress { get; set; }
    public string CartProductwisePaymentAmount { get; set; }
    public string CartPayableAmount { get; set; }

    public string CartAskingDeliveryDist { get; set; }
    public string CartAskingDeliveryStatus { get; set; }
    public string CartMerchantId { get; set; }
    public string OrderSource { get; set; }
    
        
}