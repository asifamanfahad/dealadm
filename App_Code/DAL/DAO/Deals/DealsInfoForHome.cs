using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DealsInfoForHome
/// </summary>
public class DealsInfoForHome
{
	
	public int DealId { get; set; }
    public string DealTitle { get; set; }
    public string AccountsTitle { get; set; }
    public string FolderName { get; set; }
    public string DealRemainingDays { get; set; }
    public string CategoryId { get; set; }
    public string SubCategoryId { get; set; }
    public bool Soldout { get; set; }
    public string DealPrice { get; set; }
    public string RegularPrice { get; set; }
    public string DealDiscount { get; set; }
    public string CategoryName { get; set; }
    public string SubCategoryName { get; set; }
    public string SignUpClosingDate { get; set; }
    public string SignUpStartingDate { get; set; }
	
}