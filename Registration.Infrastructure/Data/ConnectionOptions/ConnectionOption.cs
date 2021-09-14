using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

namespace Registration.Infrastructure.Data.ConnectionOptions
{
    public class ConnectionOption
    {
        public static string Create()
        {
            return SqlServerConnection();
        }

        private static string SqlServerConnection()
        {
            var builder = new SqlConnectionStringBuilder()
            {
                DataSource = @".",
                InitialCatalog = "Registration",
                ApplicationName = "Registration",
                IntegratedSecurity = true,
                MultipleActiveResultSets = true
            };
            return builder.ConnectionString;
        }

    }
}
