using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnsIpController.Model
{
    public static class DataBase
    {
        private const string CONNECTION_STRING = @"Data Source=SQLSERVER\BILLING;Initial Catalog=omegaPU04;Integrated Security=True";

        public static bool LoadTasksFromOmega(SitesList sitesList)
        {
            using (SqlConnection sqlConn = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    sqlConn.Open();
                    SqlCommand command = new SqlCommand($"SELECT * FROM [omegaPU04].[dbo].[V_HttpIp_Objects]", sqlConn);
                    var reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        int count = 0;
                        while (reader.Read())
                        {
                            Site site = new Site(Convert.ToInt32(reader[0]),
                                                 Convert.ToInt32(reader[1]),
                                                 reader[2].ToString(),
                                                 reader[3].ToString(),
                                                 reader[4].ToString(),
                                                 reader[5].ToString(),
                                                 reader[6].ToString()
                                                 );
                            sitesList.Items.Add(site);
                            count++;
                        }
                        sitesList.InfoMessage = $"Загружено {count} заданий из базы Омеги";
                    }
                    else
                        sitesList.InfoMessage = $"Нет заданий с IP или доменными именами в базе Омеги";
                    reader.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    //if (ex.)
                    sitesList.InfoMessage = ex.Message;
                    return false;
                }
            }
        }
    }
}
