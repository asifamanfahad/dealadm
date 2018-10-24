using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for Deals
/// </summary>
public class Deals
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
    
    public Deals()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public List<Deals> GetDealList(string mail)
    {

        DataTable dtDealTitel = new DataTable();

        using (BOC_Reports bocMyAjkerDeal = new BOC_Reports())
        {
            dtDealTitel = bocMyAjkerDeal.LoadRecord_SearchDealTitle(mail);



        }
        //var fetchEmail = emp.GetEmployeeList().Where(m => m.Email.ToLower().StartsWith(mail.ToLower()));
        // datatable should contains datacolumns with Id,Name

        List<Deals> dealList = new List<Deals>();  // Employee should contain  EmployeeId, EmployeeName as properties

        foreach (DataRow dr in dtDealTitel.Rows)
        {


            
            string strSignupStartingDate = dr["SignupStartingDate"].ToString();
            string strSignupClosingDate = dr["SignupClosingDate"].ToString();

            
            bool IsSoldOut = Convert.ToBoolean(dr["IsSoldOut"]);
            string dealRemainingTime = String.Empty;
            //TimeSpan objTimeSpan = Convert.ToDateTime(strSignupClosingDate) - Convert.ToDateTime(strSignupStartingDate);

            TimeSpan objTimeSpan = Convert.ToDateTime(strSignupClosingDate) - DateTime.Now;
            int intRemainDays = objTimeSpan.Days;

            DateTime objDateTime;
            objDateTime = Convert.ToDateTime(strSignupStartingDate);
            strSignupStartingDate = objDateTime.ToString("MMM dd, yyyy");

            string categoryId = dr["CategoryId"].ToString();
            string subCategoryId = dr["SubCategoryId"].ToString();

            if (intRemainDays > 1)
            {
                dealRemainingTime = intRemainDays.ToString() + " Days Left";
            }
            else if (intRemainDays == 1)
            {
                dealRemainingTime = "1 Day Left";
            }
            else
            {
                TimeSpan objTempTimeSpan = Convert.ToDateTime(strSignupClosingDate) - DateTime.Now;

                //int intRemainDays = objTimeSpan.Days;
                int intTempRemainHours = objTempTimeSpan.Hours;
                intTempRemainHours = intTempRemainHours + 3;

                dealRemainingTime = intTempRemainHours + " Hour Left";
            }
            string dealPrice = string.Empty;
            if (Convert.ToDouble(dr["DealPrice"]) > 0)
            {
                dealPrice = "Tk. " + Convert.ToDouble(dr["DealPrice"]).ToString("#,##0") + "/-";
            }
            else
            {
                dealPrice = dr["CustomiseMsg"].ToString();
            }
            string subCategoryName = string.Empty;
            string categoryName = string.Empty;
            categoryName = dr["Category"].ToString();
            if (Convert.ToInt32(subCategoryId) > 0)
                subCategoryName = dr["Subcategory"] +" + ";
            else
                subCategoryName = dr["Category"] + " + ";

            dealList.Add(new Deals { DealTitle = dr["DealTitle"].ToString(), DealId = Convert.ToInt32(dr["DealId"]), FolderName = dr["FolderName"].ToString(), DealRemainingDays = dealRemainingTime, CategoryId = categoryId, SubCategoryId = subCategoryId, Soldout = IsSoldOut, DealPrice = dealPrice, SubCategoryName = subCategoryName, CategoryName = categoryName });
        }

        //List<Employee> empList = new List<Employee>();
        //empList.Add(new Employee() { ID = 1, Email = "Mary@somemail.com" });
        
        return dealList.ToList();
    }




}
