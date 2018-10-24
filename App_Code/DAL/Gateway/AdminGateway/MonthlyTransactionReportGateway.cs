using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for MonthlyTransactionReportGateway
/// </summary>
public class MonthlyTransactionReportGateway : ADGateway
{
    public MonthlyTransactionReportGateway()
    {
        //
        // TODO: Add constructor logic here
        //
    }





    public System.Data.DataTable LoadMonthlyTransactionReportDateRange(string FromDate, string ToDate, string Orderby)
    {
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@StartDate", FromDate));
            arlSQLParameters.Add(new SqlParameter("@EndDate", ToDate));
            arlSQLParameters.Add(new SqlParameter("@SortedBy", Orderby));
            DataTable objDataTable = new DataTable();
            objDataTable = this.ExecuteQuery("[Reports].[USP_LoadMonthlyTransactionReportBasedOnConfirmOrderByPercentDateRange]", arlSQLParameters);
            return objDataTable;

        }
        catch
        {
            throw;
        }
        finally
        {
            this.CloseConnection();
        }
    }


    public DataTable LoadMonthlyTransactionReportBasedOnConfirmOrder(string Month, string Year, string OrderBy)
    {
        try
        {
            OpenConnection();

            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@MonthName", Month));
            arlSQLParameters.Add(new SqlParameter("@YearName", Year));
            arlSQLParameters.Add(new SqlParameter("@SortedBy", OrderBy));

            DataTable objDataTable = new DataTable();

            objDataTable = this.ExecuteQuery("Reports.USP_LoadMonthlyTransactionReportBasedOnConfirmOrderByPercent", arlSQLParameters);
            return objDataTable;

        }
        catch
        {
            throw;
        }
        finally
        {
            this.CloseConnection();
        }
    }



    public DataTable ComparativeReport()
    {
        try
        {
            OpenConnection();

            DataTable objDataTable = new DataTable();

            objDataTable = this.ExecuteQuery("[Reports].[USP_Comparative_Monthly_Transaction_Report]", null);
            return objDataTable;

        }
        catch
        {
            throw;
        }
        finally
        {
            this.CloseConnection();
        }
    }


    public DataTable MonthlyDeliverySpeed(string Month, string Year, string ProfileId, string District)
    {
        try
        {
            OpenConnection();

            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@MonthName", Month));
            arlSQLParameters.Add(new SqlParameter("@YearName", Year));
            arlSQLParameters.Add(new SqlParameter("@ProfileId", ProfileId));
            arlSQLParameters.Add(new SqlParameter("@DeliveryDist", District));

            DataTable objDataTable = new DataTable();

            objDataTable = this.ExecuteQuery("[Reports].[USP_DeliverySpeed]", arlSQLParameters);
            return objDataTable;

        }
        catch
        {
            throw;
        }
        finally
        {
            this.CloseConnection();
        }
    }


    public DataTable SpeedCountByCouponId(string CouponId)
    {
        try
        {
            OpenConnection();

            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@CouponId", CouponId));
            DataTable objDataTable = new DataTable();

            objDataTable = this.ExecuteQuery("[Reports].[USP_SpeedCountByCouponId]", arlSQLParameters);
            return objDataTable;

        }
        catch
        {
            throw;
        }
        finally
        {
            this.CloseConnection();
        }
    }


    public DataTable MonthlyDeliverySpeedOutSideDhaka(string Month, string Year, string ProfileId, string District)
    {
        try
        {
            OpenConnection();

            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@MonthName", Month));
            arlSQLParameters.Add(new SqlParameter("@YearName", Year));
            arlSQLParameters.Add(new SqlParameter("@ProfileId", ProfileId));
            arlSQLParameters.Add(new SqlParameter("@DeliveryDist", District));

            DataTable objDataTable = new DataTable();

            objDataTable = this.ExecuteQuery("[Reports].[USP_DeliverySpeed_OutSideDhaka]", arlSQLParameters);
            return objDataTable;

        }
        catch
        {
            throw;
        }
        finally
        {
            this.CloseConnection();
        }
    }


    public DataTable MonthlyTransactionReport(string Month, string Year, string OrderBy)
    {
        try
        {
            OpenConnection();

            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@MonthName", Month));
            arlSQLParameters.Add(new SqlParameter("@YearName", Year));
            arlSQLParameters.Add(new SqlParameter("@SortedBy", OrderBy));

            DataTable objDataTable = new DataTable();

            objDataTable = this.ExecuteQuery("[Reports].[USP_MonthlyTransactionReport]", arlSQLParameters);
            return objDataTable;

        }
        catch
        {
            throw;
        }
        finally
        {
            this.CloseConnection();
        }
    }


    public string GetInsertedTime(string StrProfileId)
    {
        string ProfileId = "";
        DataTable objDataTable = new DataTable();

        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@Profileid", StrProfileId));
            objDataTable = this.ExecuteQuery("[Reports].[USP_GetInsertedTime]", arlSqlParameters);
            ProfileId = objDataTable.Rows[0][0].ToString();

            return ProfileId;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

        finally
        {
            CloseConnection();
        }
    }

    public int UserProfileUpdateForColor(int ProfileId, int transitionRating)
    {
        int intActionResult = 0;
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@profileId", ProfileId));
            arlSQLParameters.Add(new SqlParameter("@transitionRating", transitionRating));

            return intActionResult = this.ExecuteActionQuery("Deal.USP_UserProfileUpdateForColor", arlSQLParameters);
        }
        catch
        {
            throw;
        }

        finally
        {
            CloseConnection();
        }
    }


    public DataTable GetMonthlyOrderReport(string ProfileId, string Month, string Year, string IsDone)
    {
        DataTable dt = new DataTable();
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@ProfileId", ProfileId));
            arlSqlParameters.Add(new SqlParameter("@MonthName", Month));
            arlSqlParameters.Add(new SqlParameter("@YearName", Year));
            arlSqlParameters.Add(new SqlParameter("@IsDone", IsDone));

            dt = this.ExecuteQuery("[Deal].[USP_MonthlyOrderReport]", arlSqlParameters);
            return dt;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            CloseConnection();
        }
    }



    public DataTable GetMonthlyOrderReport_CompanyServiceExperince(string Month, string ProfileId)
    {
        DataTable dt = new DataTable();
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@Month", Month));
            arlSqlParameters.Add(new SqlParameter("@ProfileId", ProfileId));

            dt = this.ExecuteQuery("[Reports].[USP_CompanyServiceExperince]", arlSqlParameters);
            return dt;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            CloseConnection();
        }
    }


    public DataTable GetMonthlyOrderReport_CompanyServiceExperince_PopUp(string ProfileId, string Flag, string Month)
    {
        DataTable dt = new DataTable();
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@ProfileID", ProfileId));
            arlSqlParameters.Add(new SqlParameter("@Month", Month));
            arlSqlParameters.Add(new SqlParameter("@Status", Flag));
            dt = this.ExecuteQuery("[Reports].[USP_CompanyServiceExperincePopUp]", arlSqlParameters);
            return dt;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            CloseConnection();
        }
    }


    public DataTable GetMonthlyOrderReportPopup(string DealTitle, string FromDate, string ToDate, string Mobile, string Email, string CouponId, string CustomerName,
        string PaymentType, string PaymentStatus, bool IsMotherDeal, string IsDone, string Top, string Company, string BasedOn)
    {
         try
         {
             OpenConnection();
             ArrayList arlSQLParameters = new ArrayList();

             arlSQLParameters.Add(new SqlParameter("@DealTitle", DealTitle));
             arlSQLParameters.Add(new SqlParameter("@FromDate", FromDate));
             arlSQLParameters.Add(new SqlParameter("@ToDate", ToDate));
             arlSQLParameters.Add(new SqlParameter("@Mobile", Mobile));
             arlSQLParameters.Add(new SqlParameter("@Email", Email));
             arlSQLParameters.Add(new SqlParameter("@BookingCode", CouponId));
             arlSQLParameters.Add(new SqlParameter("@CustomerName", CustomerName));
             arlSQLParameters.Add(new SqlParameter("@PaymentType", PaymentType));
             arlSQLParameters.Add(new SqlParameter("@PaymentStatus", PaymentStatus));
             arlSQLParameters.Add(new SqlParameter("@IsMotherDeal", IsMotherDeal));
             arlSQLParameters.Add(new SqlParameter("@IsDone", IsDone));
             arlSQLParameters.Add(new SqlParameter("@Top", Top));
             arlSQLParameters.Add(new SqlParameter("@Company", Company));
             arlSQLParameters.Add(new SqlParameter("@BasedOn", BasedOn));

             DataTable objDataTable = this.ExecuteQuery("Reports.USP_LoadBookingReports", arlSQLParameters);

             return objDataTable;

         }
         catch
         {
             throw;
         }
         finally
         {
             this.CloseConnection();
         }
    }

    public DataTable MonthlyOrderUniqueDeal(string Month, string Year)
    {
        try
        {
            OpenConnection();

            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@MonthName", Month));
            arlSQLParameters.Add(new SqlParameter("@YearName", Year));

            DataTable objDataTable = new DataTable();

            objDataTable = this.ExecuteQuery("[Reports].[USP_MonthlyOrderUniqueDeal]", arlSQLParameters);
            return objDataTable;

        }
        catch
        {
            throw;
        }
        finally
        {
            this.CloseConnection();
        }
    }




    public DataTable District_Wise_Deliverd(string Month, string Year)
    {
        try
        {
            OpenConnection();

            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@MonthName", Month));
            arlSQLParameters.Add(new SqlParameter("@YearName", Year));

            DataTable objDataTable = new DataTable();

            objDataTable = this.ExecuteQuery("[Reports].[USP_District_Wise_Deliverd]", arlSQLParameters);
            return objDataTable;

        }
        catch
        {
            throw;
        }
        finally
        {
            this.CloseConnection();
        }
    }

}