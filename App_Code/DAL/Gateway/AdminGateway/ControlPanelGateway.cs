using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ControlPanelGateway
/// </summary>
public class ControlPanelGateway:ADGateway
{
    int actionResult = 0;

	public ControlPanelGateway()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetNeedToDealVerifyBySales(int intUserId)
    {
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@UserId", intUserId));
            return this.ExecuteQuery("Deal.USP_GetNeedToDealVerifyBySales", arlSQLParameters);
        }
        catch (Exception)
        {
            
            throw;
        }
        finally
        {
            CloseConnection();
        }
    }

    public DataTable GetNeedToDealVerifyByContent()
    {
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            return this.ExecuteQuery("Deal.USP_GetNeedToDealVerifyByContent", arlSQLParameters);
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            CloseConnection();
        }
    }

    public DataTable LoadUploadedDealByUser(int intUserId)
    {
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@UserId", intUserId));
            return this.ExecuteQuery("Deal.USP_LoadUploadedDealByUser", arlSQLParameters);
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

    public object StatusCountDateWiseFromCoupons(string DateFieldName, string MerchantId, string OrderStatus, string FromDate, string ToDate, string DealId)
    {
        actionResult = 0;
        int StatusCount = 0;
        DataTable objDataTable = new DataTable();
        try
        {
            using (CorporateGateway objCorporateGateway = new CorporateGateway())
            {
                objDataTable = objCorporateGateway.StatusCountDateWiseFromCoupons(DateFieldName, MerchantId, OrderStatus, FromDate, ToDate, DealId);

                if (objDataTable.Rows.Count > 0)
                {
                    StatusCount = Convert.ToInt32(objDataTable.Rows[0]["Total"]);
                }

                return StatusCount;

            }
        }
        catch (Exception exception)
        {
            throw exception;
        }
    }


    public DataTable SaleStatsMethod(string MonthName, string YearName)
    {
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@MonthName", MonthName));
            arlSQLParameters.Add(new SqlParameter("@YearName", YearName));
            DataTable objDataTable = new DataTable();
            objDataTable = this.ExecuteQuery("[Reports].[USP_SaleStats]", arlSQLParameters);
            return objDataTable;
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



    public DataTable PerformingMerchant(string Start, string End)
    {
        try
        {
            OpenConnection();

            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@FromDate", Start));
            arlSQLParameters.Add(new SqlParameter("@ToDate", End));
            DataTable objDataTable = new DataTable();
            objDataTable = this.ExecuteQuery("[Reports].[USP_LoadTransactionReportBasedOnConfirmOrder]", arlSQLParameters);
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


    public DataTable Unique_Deal_Merchant(string Start, string End)
    {
        try
        {
            OpenConnection();

            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@StartDate", Start));
            arlSQLParameters.Add(new SqlParameter("@EndDate", End));
            DataTable objDataTable = new DataTable();
            objDataTable = this.ExecuteQuery("[Reports].[USP_Unique_Deal_Merchant]", arlSQLParameters);
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



    public DataTable Unique_Crazy_Deal(string Start, string End)
    {
        try
        {
            OpenConnection();

            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@StartDate", Start));
            arlSQLParameters.Add(new SqlParameter("@EndDate", End));
            DataTable objDataTable = new DataTable();
            objDataTable = this.ExecuteQuery("[Reports].[USP_CrazyDealCountReport]", arlSQLParameters);
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


    public DataTable DeliverySummary(string fromDate, string toDate)
    {
        try
        {
            OpenConnection();

            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@fromDate", fromDate));
            arlSQLParameters.Add(new SqlParameter("@toDate", toDate));
            DataTable objDataTable = new DataTable();
            objDataTable = this.ExecuteQuery("[Reports].[USP_DeliverySummary]", arlSQLParameters);
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


    public DataTable GetModel(string IsDone, string YesNo)
    {
        DataTable dt = new DataTable();
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@IsDone", IsDone));
            arlSqlParameters.Add(new SqlParameter("@YesNo", YesNo)); 
            dt = this.ExecuteQuery("[Deal].[USP_OrderModel1]", arlSqlParameters);

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


    public DataTable CrmOrderPopUp(string fromDate, string toDate, string model)
    {
        DataTable dt = new DataTable();
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@fromDate", fromDate));
            arlSqlParameters.Add(new SqlParameter("@toDate", toDate));
            arlSqlParameters.Add(new SqlParameter("@model", model));
            dt = this.ExecuteQuery("[Reports].[USP_TotalCrmOrderPopUp]", arlSqlParameters);

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


    public DataTable ReportTransactions(string StartToDate, string EndToDate)
    {
        try
        {
            OpenConnection();

            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@StartDate", StartToDate));
            arlSQLParameters.Add(new SqlParameter("@EndDate", EndToDate));
            DataTable objDataTable = new DataTable();
            objDataTable = this.ExecuteQuery("[Reports].[USP_LoadMonthlyTransactionCodBkashCard]", arlSQLParameters);
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

    public DataTable GetTotalCountOfTransaction(string StartToDate, string EndToDate, string PaymentType, string InsideDhaka)
    {
        try
        {
            OpenConnection();

            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@StartDate", StartToDate));
            arlSQLParameters.Add(new SqlParameter("@EndDate", EndToDate));
            arlSQLParameters.Add(new SqlParameter("@PaymentType", PaymentType));
            arlSQLParameters.Add(new SqlParameter("@InsideDhaka", InsideDhaka));

            DataTable objDataTable = new DataTable();
            objDataTable = this.ExecuteQuery("[Reports].[USP_GetTotalCountOfTransaction]", arlSQLParameters);
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


    public DataTable PerformingSubCategory(string Start, string End)
    {
        try
        {
            OpenConnection();

            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@FromDate", Start));
            arlSQLParameters.Add(new SqlParameter("@ToDate", End));
            DataTable objDataTable = new DataTable();
            objDataTable = this.ExecuteQuery("[Reports].[USP_PerformingSubCategory]", arlSQLParameters);
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


    public DataTable PerformingCategory(string Start, string End)
    {
        try
        {
            OpenConnection();

            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@FromDate", Start));
            arlSQLParameters.Add(new SqlParameter("@ToDate", End));
            DataTable objDataTable = new DataTable();
            objDataTable = this.ExecuteQuery("[Reports].[USP_PerformingCategory]", arlSQLParameters);
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

    public DataTable ControlPanelStatus(string FromDate, string ToDate, string IsDone, string strBasedOn)
    {
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@FromDate", FromDate));
            arlSQLParameters.Add(new SqlParameter("@ToDate", ToDate));
            arlSQLParameters.Add(new SqlParameter("@IsDone", IsDone));
            arlSQLParameters.Add(new SqlParameter("@BasedOn", strBasedOn));

            DataTable objDataTable = this.ExecuteQuery("Reports.USP_LoadBookingReportsStatusCount", arlSQLParameters);

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


    public DataTable GetGetPerformingMerchantClick(string CompanyId, string startDate, string endDate)
    {
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@ProfileId", CompanyId));
            arlSQLParameters.Add(new SqlParameter("@StartDate", startDate));
            arlSQLParameters.Add(new SqlParameter("@EndDate", endDate));

            DataTable objDataTable = this.ExecuteQuery("[Deal].[USP_PerformingMerchantPopUp]", arlSQLParameters);

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

    public DataTable GetGetPerformingSubCategoryClick(string SubCategoryId, string startDate, string endDate)
    {
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@SubCategoryId", SubCategoryId));
            arlSQLParameters.Add(new SqlParameter("@StartDate", startDate));
            arlSQLParameters.Add(new SqlParameter("@EndDate", endDate));

            DataTable objDataTable = this.ExecuteQuery("[Deal].[USP_PerformingSubCategoryPopUp]", arlSQLParameters);

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


    public DataTable GetGetPerformingCategoryClick(string SubCategoryId, string startDate, string endDate)
    {
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@CategoryId", SubCategoryId));
            arlSQLParameters.Add(new SqlParameter("@StartDate", startDate));
            arlSQLParameters.Add(new SqlParameter("@EndDate", endDate));

            DataTable objDataTable = this.ExecuteQuery("[Deal].[USP_PerformingCategoryPopUp]", arlSQLParameters);

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




    // Control Panel Model

    public DataTable CrmOrderSummaryReport()
    {
        try
        {
            OpenConnection();

            DataTable objDataTable = new DataTable();

            objDataTable = this.ExecuteQuery("[Reports].[USP_TotalCrmOrder]", null);
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


    public DataTable CrmOrderSummaryReportM1M2(string status)
    {
        try
        {
            OpenConnection();

            DataTable objDataTable = new DataTable();
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@status", status));
            objDataTable = this.ExecuteQuery("[Reports].[USP_TotalCrmOrderM1M2]", arlSQLParameters);
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


    public DataTable DayWiseDeliverd(string fromDate, string toDate)
    {
        try
        {
            OpenConnection();

            DataTable objDataTable = new DataTable();
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@fromDate", fromDate));
            arlSQLParameters.Add(new SqlParameter("@toDate", toDate));
            objDataTable = this.ExecuteQuery("[Reports].[USP_DayWise_Deliverd]", arlSQLParameters);
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


    public DataTable DayWiseDeliverdModal(string StartDate, string EndDate, string DayFlag)
    {
        try
        {
            OpenConnection();

            DataTable objDataTable = new DataTable();
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@StartDate", StartDate));
            arlSQLParameters.Add(new SqlParameter("@EndDate", EndDate));
            arlSQLParameters.Add(new SqlParameter("@DayFlag", DayFlag));
            objDataTable = this.ExecuteQuery("[Reports].[USP_DayWise_DeliverdPopUp]", arlSQLParameters);
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


    public void SoldOutProduct_Update(string DealId)
    {
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@DealId", DealId));
            ExecuteQuery("[Deal].[USP_UpdateMultipleDealIdForDealSoldOut]", arlSQLParameters);
        }
        catch (Exception)
        {

            throw;
        }
        finally
        {
            CloseConnection();
        }
    }
}