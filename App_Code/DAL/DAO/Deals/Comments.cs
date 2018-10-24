using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///Comments is using to store All AD Office user like CRM,Inventory
///comments in Booking Report Against each order.
/// CommentId - int
/// CouponId - int
/// CommentedOn - small date time
/// CommentedBy - int
/// Comments - nvarchar
/// IsDone - tiny int
/// IsActive - bit
/// </summary>
public class Comments
{
	public string CommentId {set;get;}
    public string CouponId { set; get; }
    public string CommentedOn { set; get; }
    public string CommentedBy { set; get; }
    public string Comment { set; get; }
    public string IsDone { set; get; }
    public string IsActive { set; get; }
}