using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ColorGateway
/// </summary>
public class ColorGateway:ADGateway
{
	public ColorGateway()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int InsertColor(string colorBangla, string colorEnglish, string IssuedBy, string colorCode)
    {
        int intActionResult = 0;
        try
        {
            OpenConnection();
            ArrayList arlSqlArrayList = new ArrayList();
            arlSqlArrayList.Clear();
            arlSqlArrayList.Add(new SqlParameter("@colorBangla", colorBangla));
            arlSqlArrayList.Add(new SqlParameter("@colorEnglish", colorEnglish));
            arlSqlArrayList.Add(new SqlParameter("@IssuedBy", IssuedBy));
            arlSqlArrayList.Add(new SqlParameter("@colorCode", colorCode));
            intActionResult = ExecuteActionQuery("Deal.USP_InsertColor", arlSqlArrayList);
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

    public DataTable LoadColor()
    {
        try
        {
            OpenConnection();
            ArrayList arlSqlArrayList = new ArrayList();
            arlSqlArrayList.Clear();
            return ExecuteQuery("Deal.USP_LoadColor", arlSqlArrayList);
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

    public DataTable Load_EditedColor(int colorId)
    {
        try
        {
            OpenConnection();
            ArrayList arlSqlArrayList = new ArrayList();
            arlSqlArrayList.Clear();
            arlSqlArrayList.Add(new SqlParameter("@colorId", colorId));
            return ExecuteQuery("Deal.USP_LoadEditColor", arlSqlArrayList);
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

    public int UpdateColor(string colorBangla, string colorEnglish, int colorId, string colorCode)
    {
        try
        {
            OpenConnection();
            ArrayList arlSqlArrayList = new ArrayList();
            arlSqlArrayList.Clear();
            arlSqlArrayList.Add(new SqlParameter("@colorBangla", colorBangla));
            arlSqlArrayList.Add(new SqlParameter("@colorEnglish", colorEnglish));
            arlSqlArrayList.Add(new SqlParameter("@colorId", colorId));
            arlSqlArrayList.Add(new SqlParameter("@colorCode", colorCode));
            return ExecuteActionQuery("Deal.USP_UpdateColor", arlSqlArrayList);
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