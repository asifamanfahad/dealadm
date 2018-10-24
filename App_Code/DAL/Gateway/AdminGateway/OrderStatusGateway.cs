using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OrderStatusGateway
/// </summary>
public class OrderStatusGateway : ADGateway
{
	public OrderStatusGateway()
	{
		//
		// TODO: Add constructor logic here
		//
	}
	
	 public DataTable LoadOrderStatusWithGroup(string StatusId, string StatusGroup, string Model, string StatusType, string ActiveForField, string ActiveForValue)
    {
        int intActionResult = 0;

        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@StatusId", StatusId));
            arlSqlParameters.Add(new SqlParameter("@StatusGroup", StatusGroup));
            arlSqlParameters.Add(new SqlParameter("@Model", Model));
            arlSqlParameters.Add(new SqlParameter("@StatusType", StatusType));
            arlSqlParameters.Add(new SqlParameter("@ActiveForField", ActiveForField));
            arlSqlParameters.Add(new SqlParameter("@ActiveForValue", ActiveForValue));

            return ExecuteQuery("[Deal].[USP_LoadOrderStatusByGroup]", arlSqlParameters);

        }
        catch (Exception exception)
        {
            throw new Exception("Gateway Error:" + exception.Message, exception);
        }
        finally
        {
            CloseConnection();
        }
    }
	
    public DataTable Load_StatusType()
    {
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Clear();

            return this.ExecuteQuery("Deal.LoadStatusType", arlSqlParameters);
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

    public int Status_Insert(int statusId, string status, string statusBng, int isActive, string postedDate, int adminId, int statusType)
    {
        int intActionResult = 0;

        try
        {
            ArrayList arlSqlParameters = new ArrayList();
            OpenConnection();
            arlSqlParameters.Add(new SqlParameter("@statusId", statusId));
            arlSqlParameters.Add(new SqlParameter("@status", status));
            arlSqlParameters.Add(new SqlParameter("@statusBng", statusBng));
            arlSqlParameters.Add(new SqlParameter("@isActive", isActive));
            arlSqlParameters.Add(new SqlParameter("@postedDate", postedDate));
            arlSqlParameters.Add(new SqlParameter("@adminId", adminId));
            arlSqlParameters.Add(new SqlParameter("@statusType", statusType));

            intActionResult = this.ExecuteActionQuery("Deal.Insert_Status", arlSqlParameters);

        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            CloseConnection();
        }
        return intActionResult;
    }

    public int StatusInsertion(OrderStatusProperties objStatus)
    {
        int intActionResult = 0;

        try
        {
            ArrayList arlSqlParameters = new ArrayList();
            OpenConnection();
            arlSqlParameters.Add(new SqlParameter("@statusId", objStatus.StatusId));
            arlSqlParameters.Add(new SqlParameter("@status", objStatus.Status));
            arlSqlParameters.Add(new SqlParameter("@statusBng", objStatus.StatusBng));
            arlSqlParameters.Add(new SqlParameter("@isActive", objStatus.IsActive));
            arlSqlParameters.Add(new SqlParameter("@postedDate", objStatus.Postedon));
            arlSqlParameters.Add(new SqlParameter("@adminId", objStatus.Postedby));
            arlSqlParameters.Add(new SqlParameter("@statusGroup", objStatus.StatusGroup));
            arlSqlParameters.Add(new SqlParameter("@model", objStatus.Model));
            arlSqlParameters.Add(new SqlParameter("@statusType", objStatus.StatusType));
            arlSqlParameters.Add(new SqlParameter("@customerStatusGroup", objStatus.CustomerStatusGroup));
            arlSqlParameters.Add(new SqlParameter("@merchantStatusGroup", objStatus.MerchantStatusGroup));
            arlSqlParameters.Add(new SqlParameter("@customerStatusBng", objStatus.CustomerStatusBng));
            arlSqlParameters.Add(new SqlParameter("@customerStatusEng", objStatus.CustomerStatusEng));
            arlSqlParameters.Add(new SqlParameter("@merchantStatusBng", objStatus.MerchantStatusBng));
            arlSqlParameters.Add(new SqlParameter("@merchantStatusEng", objStatus.MerchantStatusEng));
            arlSqlParameters.Add(new SqlParameter("@activeFroCrm", objStatus.ActiveForCrm));
            arlSqlParameters.Add(new SqlParameter("@activeForFulfillment", objStatus.ActiveForFulfillment));


            intActionResult = this.ExecuteActionQuery("[Deal].[USP_InsertStatus]", arlSqlParameters);

        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            CloseConnection();
        }
        return intActionResult;
    }


    public int UpdateOrderStatus(OrderStatusProperties objStatus)
    {
        int intActionResult = 0;

        try
        {
            ArrayList arlSqlParameters = new ArrayList();
            OpenConnection();
            arlSqlParameters.Add(new SqlParameter("@statusId", objStatus.StatusId));
            arlSqlParameters.Add(new SqlParameter("@status", objStatus.Status));
            arlSqlParameters.Add(new SqlParameter("@statusBng", objStatus.StatusBng));
            arlSqlParameters.Add(new SqlParameter("@isActive", objStatus.IsActive));
            arlSqlParameters.Add(new SqlParameter("@adminId", objStatus.Postedby));
            arlSqlParameters.Add(new SqlParameter("@statusGroup", objStatus.StatusGroup));
            arlSqlParameters.Add(new SqlParameter("@model", objStatus.Model));
            arlSqlParameters.Add(new SqlParameter("@statusType", objStatus.StatusType));
            arlSqlParameters.Add(new SqlParameter("@customerStatusGroup", objStatus.CustomerStatusGroup));
            arlSqlParameters.Add(new SqlParameter("@merchantStatusGroup", objStatus.MerchantStatusGroup));
            arlSqlParameters.Add(new SqlParameter("@customerStatusBng", objStatus.CustomerStatusBng));
            arlSqlParameters.Add(new SqlParameter("@customerStatusEng", objStatus.CustomerStatusEng));
            arlSqlParameters.Add(new SqlParameter("@merchantStatusBng", objStatus.MerchantStatusBng));
            arlSqlParameters.Add(new SqlParameter("@merchantStatusEng", objStatus.MerchantStatusEng));
            arlSqlParameters.Add(new SqlParameter("@activeFroCrm", objStatus.ActiveForCrm));
            arlSqlParameters.Add(new SqlParameter("@activeForFulfillment", objStatus.ActiveForFulfillment));

            intActionResult = this.ExecuteActionQuery("[Deal].[USP_UpdateOrderStatus]", arlSqlParameters);

        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            CloseConnection();
        }
        return intActionResult;
    }

    public DataTable Load_allStatus()
    {
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Clear();

            return this.ExecuteQuery("[Deal].[USP_LoadallStatus]", arlSqlParameters);
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

    public DataTable StatusLoadForUpdate(int statusId)
    {
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Clear();
            arlSqlParameters.Add(new SqlParameter("@statusId", statusId));
            return this.ExecuteQuery("Deal.LoadStatusForUpdate", arlSqlParameters);
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
    
    public int StatusUpdate(int statusOrderId, int statusId, string status, string statusBng, int isActive, int adminId, int statusType)
    {
        int intActionResult = 0;

        try
        {
            ArrayList arlSqlParameters = new ArrayList();
            OpenConnection();
            arlSqlParameters.Add(new SqlParameter("@statusOrderId", statusOrderId));
            arlSqlParameters.Add(new SqlParameter("@statusId", statusId));
            arlSqlParameters.Add(new SqlParameter("@status", status));
            arlSqlParameters.Add(new SqlParameter("@statusBng", statusBng));
            arlSqlParameters.Add(new SqlParameter("@isActive", isActive));
          
            arlSqlParameters.Add(new SqlParameter("@adminId", adminId));
            arlSqlParameters.Add(new SqlParameter("@statusType", statusType));

            intActionResult = this.ExecuteActionQuery("Deal.StatusUpdate", arlSqlParameters);

        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            CloseConnection();
        }
        return intActionResult;
    }

    public DataTable GetStatusType(int statusTypeId)
    {
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Clear();
            arlSqlParameters.Add(new SqlParameter("@statusTypeId", statusTypeId));
            return this.ExecuteQuery("Deal.GetStatusType", arlSqlParameters);
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

    public DataTable LoadOrderStatusWithParam(string StatusId, string StatusGroup, string Model, string StatusType)
    {
        int intActionResult = 0;

        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@StatusId", StatusId));
            arlSqlParameters.Add(new SqlParameter("@StatusGroup", StatusGroup));
            arlSqlParameters.Add(new SqlParameter("@Model", Model));
            arlSqlParameters.Add(new SqlParameter("@StatusType", StatusType));

            return ExecuteQuery("[Deal].[USP_LoadOrderStatusByParam]", arlSqlParameters);
            
        }
        catch (Exception exception)
        {
            throw new Exception("Gateway Error:" + exception.Message, exception);
        }
        finally
        {
            CloseConnection();
        }
    }
}