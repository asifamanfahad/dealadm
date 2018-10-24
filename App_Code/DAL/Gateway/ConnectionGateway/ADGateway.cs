using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Collections;

/// <summary>
/// Summary description for ADGateway
/// </summary>
public class ADGateway : IDisposable
{

    private SqlDataAdapter objectDataAdapter;
    private string connectionString;
    private SqlConnection Connection;


    protected ADGateway()
    {
        SqlConnection.ClearAllPools();
    }

    private void Initialize(){}
    private string GetConnectionString()
    {
          connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
          return connectionString;
    }

    protected void OpenConnection()
    {
         objectDataAdapter = new SqlDataAdapter();
         objectDataAdapter.SelectCommand = new SqlCommand();
         objectDataAdapter.SelectCommand.Parameters.Clear();
         objectDataAdapter.SelectCommand.Connection = new SqlConnection(GetConnectionString());
         if (objectDataAdapter.SelectCommand.Connection != null && objectDataAdapter.SelectCommand.Connection.State == ConnectionState.Open)
             {
                 Connection.Close();
                 SqlConnection.ClearPool(objectDataAdapter.SelectCommand.Connection);
             }
         objectDataAdapter.SelectCommand.Connection.Open();
     }

        protected void CloseConnection()
        {
            if (objectDataAdapter.SelectCommand.Connection != null && objectDataAdapter.SelectCommand.Connection.State == ConnectionState.Open)
            {
                objectDataAdapter.SelectCommand.Connection.Close();
            }
            objectDataAdapter.SelectCommand.Connection.Dispose();
            SqlConnection.ClearPool(objectDataAdapter.SelectCommand.Connection);
            objectDataAdapter.SelectCommand.Dispose();
            objectDataAdapter.Dispose();
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(true);
        }

        protected virtual void Dispose(bool blnDisposing)
        {
            if (!blnDisposing)
            {
                return;
            }
            else
            {
                if (objectDataAdapter != null)
                {
                    if (objectDataAdapter.SelectCommand != null)
                    {
                        //if (objDataAdapter.SelectCommand.Connection != null)
                        //{
                        //    objDataAdapter.SelectCommand.Connection.Dispose();
                        //}

                        objectDataAdapter.SelectCommand.Dispose();
                    }
                    objectDataAdapter.Dispose();
                    objectDataAdapter = null;
                }
            }
        }

        protected DataTable ExecuteQuery(string strProcedureName, ArrayList arlSQLParameters)
        {
            if (objectDataAdapter == null)
            {
                throw new System.ObjectDisposedException(GetType().FullName);
            }
            this.Initialize();
            DataTable objDataTable = new DataTable();
            SqlCommand objCommand = objectDataAdapter.SelectCommand;
            objCommand.CommandText = strProcedureName;
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandTimeout = 1000;

        if (arlSQLParameters != null)
            {
                for (int i = 0; i < arlSQLParameters.Count; i++)
                {
                    objCommand.Parameters.Add(arlSQLParameters[i]);
                }
            }

            objectDataAdapter.Fill(objDataTable);
            return objDataTable;
        }
        protected int ExecuteActionQuery(string strProcedureName, ArrayList arlSQLParameters)
        {
            if (objectDataAdapter == null)
            {
                throw new System.ObjectDisposedException(GetType().FullName);
            }

            this.Initialize();

            int intResult = 0;

            SqlCommand objCommand = objectDataAdapter.SelectCommand;
            objCommand.CommandText = strProcedureName;
            objCommand.CommandType = CommandType.StoredProcedure;

            if (arlSQLParameters != null)
            {
                for (int i = 0; i < arlSQLParameters.Count; i++)
                {
                    objCommand.Parameters.Add(arlSQLParameters[i]);
                }
            }
            intResult = objCommand.ExecuteNonQuery();
            return intResult;
        }

        protected int ExecuteActionQuery(string strProcedureName, ArrayList arlSQLParameters, string strOutputParameterName)
        {
            string strOutputValue = string.Empty;
            if (objectDataAdapter == null)
            {
                throw new System.ObjectDisposedException(GetType().FullName);
            }
            this.Initialize();
            int intResult = 0;
            SqlCommand objCommand = objectDataAdapter.SelectCommand;
            objCommand.CommandText = strProcedureName;
            objCommand.CommandType = CommandType.StoredProcedure;

            if (arlSQLParameters != null)
            {
                for (int i = 0; i < arlSQLParameters.Count; i++)
                {
                    objCommand.Parameters.Add(arlSQLParameters[i]);
                }
            }
            SqlParameter outParameter = new SqlParameter();
            outParameter.ParameterName = strOutputParameterName;
            outParameter.Direction = ParameterDirection.Output;
            outParameter.DbType = DbType.Int32;
            objCommand.Parameters.Add(outParameter);

            intResult = objCommand.ExecuteNonQuery();

            if (intResult > 0)
            {
                strOutputValue = objCommand.Parameters[strOutputParameterName].Value.ToString();
            }
            else
            {
                strOutputValue = intResult.ToString();
            }

            return Convert.ToInt32(strOutputValue);
        }

        protected DataSet ExecuteQuerySet(string strProcedureName, ArrayList arlSQLParameters)
        {
            if (objectDataAdapter == null)
            {
                throw new System.ObjectDisposedException(GetType().FullName);
            }

            this.Initialize();

            DataSet objDataSet = new DataSet();

            SqlCommand objCommand = objectDataAdapter.SelectCommand;
            objCommand.CommandText = strProcedureName;
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandTimeout = 1000;

            if (arlSQLParameters != null)
            {
                for (int i = 0; i < arlSQLParameters.Count; i++)
                {
                    objCommand.Parameters.Add(arlSQLParameters[i]);
                }
            }

            objectDataAdapter.Fill(objDataSet);
            return objDataSet;
        }

}
