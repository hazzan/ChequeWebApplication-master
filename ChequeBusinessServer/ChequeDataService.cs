using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChequeBusinessData.Entity;
using ChequeBusinessData.Connection;
using System.Data.SqlClient;
using System.Data;

namespace ChequeBusinessData
{
    public static class ChequeDataService
    {
        public static List<MenuItem> loadMenuItem()
        {
            using (SqlConnection connt = new SqlConnection(ConnectionStirng.Connection()))
            {
                connt.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.tblMENU", connt))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<MenuItem> lstMenuItem = new List<MenuItem>();
                    while (reader.Read())
                    {
                        MenuItem menuItem = new MenuItem();
                        menuItem.Id = reader.GetInt64(0);
                        menuItem.MenuName = reader.GetString(1);
                        menuItem.MenuDescription = reader.GetString(2);
                        menuItem.Category = reader.GetString(3);
                        menuItem.Price = reader.GetDecimal(4);
                        lstMenuItem.Add(menuItem);
                    }

                    return lstMenuItem;
                }
            }
        }

        public static string saveBillingItem(BillingInformation billingInformation) 
        {
            foreach (var item in billingInformation.MenuItems)
            {
                InsertBillInformation(billingInformation.MenuItems, billingInformation.ChequeDate, billingInformation.ChequeNo);
            }
            return "success";
        }

        private static void InsertBillInformation(List<MenuItem> menuInfo, DateTime chequeDate, string chequeNo)  
        {
            foreach (var item in menuInfo)
	        {
                using (SqlConnection connt = new SqlConnection(ConnectionStirng.Connection()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = DataConstants.InsertBillProceture;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = connt;

                        cmd.Parameters.AddWithValue("@MenuID", item.Id);
                        cmd.Parameters.AddWithValue("@Price", item.Price);
                        cmd.Parameters.AddWithValue("@Category", item.Category);
                        cmd.Parameters.AddWithValue("@ChequeNo", chequeNo);
                        cmd.Parameters.AddWithValue("@ChequeDate", chequeDate);
                        connt.Open();
                        cmd.ExecuteNonQuery();
                    } connt.Close();
                }
            }
        }
    }
}
