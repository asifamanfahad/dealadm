using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ModelStatus
/// </summary>
public class ModelStatus
{
    public ModelStatus()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public string bookingCode { get; set; }
    public string cAddress { get; set; }
    public string cardType { get; set; }
    public string cEmail { get; set; }
    public string cMobile { get; set; }
    public string cName { get; set; }
    public string colors { get; set; }
    public string commentedBy { get; set; }
    public string commentedOn { get; set; }
    public string comments { get; set; }
    public string commissionPerCoupon { get; set; }
    public string companyName { get; set; }
    public string contactPerson { get; set; }
    public string couponId { get; set; }
    public string couponPrice { get; set; }
    public string couponQtn { get; set; }
    public string dealId { get; set; }
    public string dealTitle { get; set; }
    public string deliveryAddress { get; set; }
    public string deliveryDate { get; set; }
    public string deliveryMobile { get; set; }
    public string district { get; set; }
    public string isDone { get; set; }
    public string isSoldOut { get; set; }
    public string loginEmail { get; set; }
    public string mobile { get; set; }
    public string paymentAmount { get; set; }
    public string paymentStatus { get; set; }
    public string paymentType { get; set; }
    public string qtnAfterBooking { get; set; }
    public string quantityRestrict { get; set; }
    public string sizes { get; set; }
    public string folderName { get; set; }
    public string paymentMessage { get; set; }
    public string podNumber { get; set; }
    public string courierCharge { get; set; }
    public string customerQuery { get; set; }
    public string customerId { get; set; }
    public string totalAmount { get; set; }

    //Added by Majedur

    public string CustomerDeliveryPhone { get; set; }
    public string CustomerAlterPhone { get; set; }
}