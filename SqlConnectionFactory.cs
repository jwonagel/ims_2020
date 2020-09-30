using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Person
{
    internal static class SqlConnectionFactory
    {

        public static SqlConnection CreateConnection()
        {
            var connectionString =
                @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Example;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


            return new SqlConnection(connectionString);
        }

    }
}
