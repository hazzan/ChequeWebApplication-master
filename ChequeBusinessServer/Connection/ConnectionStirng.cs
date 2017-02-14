using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;


namespace ChequeBusinessData.Connection 
{
    public static class ConnectionStirng
    {
        public static string Connection() 
        {
            string connectionString = @"Data Source=(local)\SQLEPR;Initial Catalog=ChequeDb;Integrated Security=True";
            return connectionString;
        }
    }
}
