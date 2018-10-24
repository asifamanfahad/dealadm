using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProcessOrderParam
/// </summary>
public class ProcessOrderParam
{
    public ProcessOrderParam()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string couponId { get; set; }
    public string status { get; set; }
    public string comment { get; set; }
    public string isConfirmByMerchant { get; set; }
    public string pod { get; set; }
    public string delivered { get; set; }
    public string courierCharge { get; set; }
    public bool soldOut { get; set; }
    public string userId { get; set; }
    public string deliveryDate { get; set; }
}