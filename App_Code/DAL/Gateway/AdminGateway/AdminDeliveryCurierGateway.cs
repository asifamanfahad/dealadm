using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for AdminDeliveryCurierGateway
/// </summary>
public class AdminDeliveryCurierGateway:ADGateway
{
    public int AddRecordCurierDeliveryInfo(DeliveryDetails objDeliveryDetails)
    {
        int intActionResult = 0;
        
        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@ExpectedDeliveryDate ", objDeliveryDetails.ExpectedDeliveryDate));
            arlSqlParameters.Add(new SqlParameter("@CourierName", objDeliveryDetails.CourierName));
            arlSqlParameters.Add(new SqlParameter("@ContactInfo ", objDeliveryDetails.ContactInfo));
            arlSqlParameters.Add(new SqlParameter("@CouponId", objDeliveryDetails.CouponId));

            intActionResult = this.ExecuteActionQuery("Delivery.USP_AddCurierDeliveryInfo", arlSqlParameters);
            return intActionResult;
        }
        catch (Exception exception)
        {
            throw new Exception("AdminDeliveryCurierGateway Error:" + exception.Message, exception);
        }
        finally
        {
            CloseConnection();
        }
    }

    public DataTable LoadShippingDetailsByCouponId(int intCouponId)
    {
        DataTable objDataTable = new DataTable();

        try
        {
            OpenConnection();
            ArrayList arlSqlParameters = new ArrayList();
            arlSqlParameters.Add(new SqlParameter("@CouponId", intCouponId));

            objDataTable = this.ExecuteQuery("Delivery.USP_LoadCurierDeliveryInfoByCouponId", arlSqlParameters);
            return objDataTable;
        }
        catch (Exception exception)
        {
            throw new Exception("AdminDeliveryCurierGateway Error:" + exception.Message, exception);
        }
        finally
        {
            CloseConnection();
        }
    }
}