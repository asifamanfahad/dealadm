using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data.SqlClient;

/// <summary>
/// Summary description for CommonStatusGateway
/// </summary>
public class CommonStatusGateway:ADGateway
{
	public CommonStatusGateway()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int CouponOrderStatusCommnetsUpdateInsert(string couponId, string comments, string status, string commentedBy, string isConfirmByMerchant, string pod, string delivered,string courierCharge)
    {
        int intActionResult = 0;

        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@CouponId", couponId));
            arlSqlParameters.Add(new SqlParameter("@Comments", comments));
            arlSqlParameters.Add(new SqlParameter("@Status", status));
            arlSqlParameters.Add(new SqlParameter("@CommentedBy", commentedBy));
            arlSqlParameters.Add(new SqlParameter("@IsConfirmedByMerchant", isConfirmByMerchant));
            arlSqlParameters.Add(new SqlParameter("@POD", pod));
            arlSqlParameters.Add(new SqlParameter("@Delivered", delivered));
            arlSqlParameters.Add(new SqlParameter("@CourierCharge", courierCharge));

            intActionResult = ExecuteActionQuery("AD.USP_Insert_OrderStatusHistory_Commnets_Update_Coupon", arlSqlParameters);
        }
        catch
        { }
        finally
        {
            CloseConnection();
        }

        return intActionResult;
    }
	
	public int CouponOrderStatusCommnetsUpdateInsert(string couponId, string comments, string status, string commentedBy, string isConfirmByMerchant, string pod, string delivered, string courierCharge, string deliveryDate)
    {
        int intActionResult = 0;

        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@CouponId", couponId));
            arlSqlParameters.Add(new SqlParameter("@Comments", comments));
            arlSqlParameters.Add(new SqlParameter("@Status", status));
            arlSqlParameters.Add(new SqlParameter("@CommentedBy", commentedBy));
            arlSqlParameters.Add(new SqlParameter("@IsConfirmedByMerchant", isConfirmByMerchant));
            arlSqlParameters.Add(new SqlParameter("@POD", pod));
            arlSqlParameters.Add(new SqlParameter("@Delivered", delivered));
            arlSqlParameters.Add(new SqlParameter("@CourierCharge", courierCharge));
            arlSqlParameters.Add(new SqlParameter("@DeliveryDateGiven", deliveryDate));

            intActionResult = ExecuteActionQuery("AD.USP_Insert_OrderStatusHistory_Commnets_Update_Coupon", arlSqlParameters);
        }
        catch (Exception ex)
        { }
        finally
        {
            CloseConnection();
        }

        return intActionResult;
    }
}