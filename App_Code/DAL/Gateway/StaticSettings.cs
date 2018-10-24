using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Configuration;

using System.Configuration;

//namespace DAL
//{
    public class StaticSettings
    {
        public StaticSettings()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public class Database
        {
            //Real connection
            //public static string DbConnectionString = "Server=sql1908.mssqlservers.com;Database=borome;UID=borome;PWD=bd2345!123";

            //Desctop
            //public static string DbConnectionString = @"Data Source=IT2-RONY;Initial Catalog=AjkerDeal;UID=Rony;PWD=123";
            //Laptop
            //public static string DbConnectionString = @"Data Source=SAMSUNG-RONY;Initial Catalog=AjkerDeal;UID=Rony;PWD=123";
            public static string DbConnectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            
         
        }
    }
//}
