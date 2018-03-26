using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace KidAccidentPrecaution.Infrastructure
{
    public static class ConnectSql
    {
        public static string getConnectionString
        {
            
            get
            {
                return ConfigurationManager.ConnectionStrings["ConnectLocal"].ConnectionString.ToString();
            }
        }
    }
}