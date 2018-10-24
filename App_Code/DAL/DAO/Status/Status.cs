using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OrderStatus
/// </summary>
public class Status
{
    public int OrderStatusId { set; get; }
    public string StatusId { get; set; }
    public string OrderStatus { get; set; }
    public string StatusBng { get; set; }
    public string StatusGroup { get; set; }
    public string Model { get; set; }
    public string StatusType { get; set; }

    public int StatusGroupId { get; set; }
    public string StatusGroupName { get; set; }

    public string Postedon { get; set; }
    public int UpdateBy { get; set; }
    public int Postedby { get; set; }
    public bool IsActive { get; set; }
}