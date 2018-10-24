using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Feedback
/// </summary>
public class Feedback
{
    public Feedback()
    {
        //
        // TODO: Add constructor logic here
        //
    }


        public string CouponId { get; set; }
        public string DeliveredDate { get; set; }
        public string ProductQuality { get; set; }
        public string OverAllExperience { get; set; }
        public string BadExperienceReason { get; set; }
        public string FurtherShopping { get; set; }
        public string CustomerQsn { get; set; }
        public int CommentedBy { get; set; }

}