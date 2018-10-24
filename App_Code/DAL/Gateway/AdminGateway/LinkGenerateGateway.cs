using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LinkGenerateGateway
/// </summary>
public class LinkGenerateGateway:ADGateway
{
	public LinkGenerateGateway()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public void GeneratorIdentifyInsert(string GeneratePageName, int UserId)
    {

        string PostedDate = DateTime.Now.ToString();
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@GeneratePageName", GeneratePageName));
            arlSQLParameters.Add(new SqlParameter("@UserId", UserId));
            arlSQLParameters.Add(new SqlParameter("@PostedDate", PostedDate));

            this.ExecuteQuery("Deal.USP_GeneratorIdentifyInsert", arlSQLParameters);

        }

        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
        finally
        {
            this.CloseConnection();
        }
    }
	public DataTable LoadHtmlLinkGeneratorForbdjBanner(string bannerposition)
    {
        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@bannerposition", bannerposition));

            return this.ExecuteQuery("Deal.USP_LoadHTMLLinkGenerateForbdjBanner", arlSQLParameters);
        }

        catch (Exception exception)
        {
            return null;
        }
        finally
        {
            CloseConnection();
        }
    }
	
    public DataTable InsertLink(string linkname, string actionUrl, string postedOn, string postedBy, int isActive)
    {
        DataTable objDatatable = new DataTable();

        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@linkname", linkname));
            arlSQLParameters.Add(new SqlParameter("@actionUrl", actionUrl));
            arlSQLParameters.Add(new SqlParameter("@postedOn", postedOn));
            arlSQLParameters.Add(new SqlParameter("@postedBy", postedBy));
            arlSQLParameters.Add(new SqlParameter("@isActive", isActive));    

            objDatatable = this.ExecuteQuery("Deal.USP_InsertedGenerateLink", arlSQLParameters);

            return objDatatable;
        }

        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
        finally
        {
            this.CloseConnection();
        }
    }

    public DataTable UpdateLink(string linkName, string actionUrl, string updateOn, string updateBy, int isActive, int linkid)
    {
        DataTable objDatatable = new DataTable();

        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@linkName", linkName));
            arlSQLParameters.Add(new SqlParameter("@actionUrl", actionUrl));
            arlSQLParameters.Add(new SqlParameter("@updateOn", updateOn));
            arlSQLParameters.Add(new SqlParameter("@updateBy", updateBy));
            arlSQLParameters.Add(new SqlParameter("@isActive", isActive));
            arlSQLParameters.Add(new SqlParameter("@linkid", linkid));

            objDatatable = this.ExecuteQuery("Deal.USP_UpdateGenerateLink", arlSQLParameters);

            return objDatatable;
        }

        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
        finally
        {
            this.CloseConnection();
        }
    }

    public DataTable LoadLinkGeneratorData()
    {        
        try
        {
            OpenConnection();
            return ExecuteQuery(@"[Deal].[USP_LoadGenerateLink]", null);            
        }

        catch (Exception exception)
        {
            return null;
        }
        finally
        {
            CloseConnection();
        }
    }
    public DataTable LoadHtmlLinkGenerator()
    {
        try
        {
            OpenConnection();
            return ExecuteQuery(@"[Deal].[USP_LoadHTMLLinkGenerate]", null);
        }

        catch (Exception exception)
        {
            return null;
        }
        finally
        {
            CloseConnection();
        }
    }
}