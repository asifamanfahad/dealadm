using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OrderStatus
/// </summary>
public class OrderStatusProperties
{

    public int StatusId { get; set; }
    public string Status { get; set; }
    public string OrderStatus { get; set; }
    public string StatusBng { get; set; }
    public int IsActive { get; set; }
    public int UpdateBy { get; set; }
    public string Postedon { get; set; }
    public int Postedby { get; set; }
    public int StatusGroup { get; set; }
    public int Model { get; set; }
    public int StatusType { get; set; }
    public int CustomerStatusGroup { get; set; }
    public int MerchantStatusGroup { get; set; }
    public string CustomerStatusBng { get; set; }
    public string CustomerStatusEng { get; set; }
    public string MerchantStatusBng { get; set; }
    public string MerchantStatusEng { get; set; }
    public int ActiveForCrm { get; set; }
    public int ActiveForFulfillment { get; set; }
    
    public OrderStatusProperties()
	{
		//
		// TODO: Add constructor logic here
		//
	}

   
}