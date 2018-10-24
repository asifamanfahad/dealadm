using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BannerGateway
/// </summary>
public class BannerGateway:ADGateway
{
	public BannerGateway()
	{
		//
		// TODO: Add constructor logic here
		//
	}
   
    public int USP_InsertBanner(Banner aBanner)
    {
        int IsActive = 1;
        int ActionResult = 0;
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Clear();
            arlSqlParameters.Add(new SqlParameter("@Pagename", aBanner.Pagename));
            arlSqlParameters.Add(new SqlParameter("@Position", aBanner.Position));
            arlSqlParameters.Add(new SqlParameter("@Category", aBanner.Category));
            arlSqlParameters.Add(new SqlParameter("@Subcategory", aBanner.SubCategory));
            arlSqlParameters.Add(new SqlParameter("@Action_url", aBanner.Action_url));

            arlSqlParameters.Add(new SqlParameter("@Image_url", aBanner.Image_url));
            arlSqlParameters.Add(new SqlParameter("@Orderby", aBanner.Orderby));
            arlSqlParameters.Add(new SqlParameter("@IsActive", aBanner.IsActive));
            arlSqlParameters.Add(new SqlParameter("@Postedby", aBanner.Postedby));
            arlSqlParameters.Add(new SqlParameter("@postedDate", aBanner.Date));
            arlSqlParameters.Add(new SqlParameter("@BannerImage", aBanner.BannerImage));
            ActionResult = this.ExecuteActionQuery("Deal.USP_InsertBanner", arlSqlParameters);
        }
        catch (Exception)
        {

            throw;
        }
        finally
        {
            CloseConnection();
        }
        return ActionResult;
    }

    public DataTable Load_BannerInformation()
    {
        DataTable objDataTable = new DataTable();
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Clear();
            objDataTable = this.ExecuteQuery("Deal.USP_Load_BannerInformation", arlSqlParameters);
        }
        catch (Exception)
        {

            throw;
        }
        finally
        {
            CloseConnection();
        }
        return objDataTable;
    }

    public DataTable LoadBannerForUpdate(int bannerId)
    {
        DataTable objDataTable = new DataTable();
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Clear();
            arlSqlParameters.Add(new SqlParameter("@bannerId", bannerId));
            objDataTable = this.ExecuteQuery("Deal.USP_Load_BannerInformationForUpdate", arlSqlParameters);
        }
        catch (Exception)
        {

            throw;
        }
        finally
        {
            CloseConnection();
        }
        return objDataTable;
    }

    public int USP_UpdateBanner(Banner aBanner, int bannerId)
    {
        int IsActive = 1;
        int ActionResult = 0;
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Clear();
            arlSqlParameters.Add(new SqlParameter("@Pagename", aBanner.Pagename));
            arlSqlParameters.Add(new SqlParameter("@Position", aBanner.Position));
            arlSqlParameters.Add(new SqlParameter("@Category", aBanner.Category));
            arlSqlParameters.Add(new SqlParameter("@Subcategory", aBanner.SubCategory));
            arlSqlParameters.Add(new SqlParameter("@Action_url", aBanner.Action_url));

            arlSqlParameters.Add(new SqlParameter("@Image_url", aBanner.Image_url));
            arlSqlParameters.Add(new SqlParameter("@Orderby", aBanner.Orderby));
            arlSqlParameters.Add(new SqlParameter("@IsActive", aBanner.IsActive));
            arlSqlParameters.Add(new SqlParameter("@Postedby", aBanner.Postedby));
            arlSqlParameters.Add(new SqlParameter("@postedDate", aBanner.Date));
            arlSqlParameters.Add(new SqlParameter("@BannerImage", aBanner.BannerImage));
            arlSqlParameters.Add(new SqlParameter("@bannerId", bannerId));
            ActionResult = this.ExecuteActionQuery("Deal.USP_UpdateBanner", arlSqlParameters);
        }
        catch (Exception)
        {

            throw;
        }
        finally
        {
            CloseConnection();
        }
        return ActionResult;
    }

    public int DeleteBanner(int deleteId)
    {
        int ActionResult = 0;
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Clear();
            arlSqlParameters.Add(new SqlParameter("@deleteId", deleteId));
            ActionResult = this.ExecuteActionQuery("Deal.USP_DeleteBanner", arlSqlParameters);
        }
        catch (Exception)
        {

            throw;
        }
        finally
        {
            CloseConnection();
        }
        return ActionResult;
    }
}