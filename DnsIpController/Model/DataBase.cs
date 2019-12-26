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
                    SqlCommand command = new SqlCommand($"SELECT * FROM [omegaPU04].[dbo].[V_HttpIp_Objects] ORDER BY ObjectName ", sqlConn);
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
                    if (ex.HResult == -2146232060)
                        sitesList.InfoMessage = "Нет связи с базой данных Омега, првоерьте настройки подключения к базе";
                    else
                        sitesList.InfoMessage = ex.Message;
                    return false;
                }
            }
        }

        public static Tuple<bool, string> UpdateIP(Site site)
        {
            var ipArr = IpTointArray(site.OmegaRuleParametr);


            using (SqlConnection sqlConn = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    sqlConn.Open();

                    //обновить существующий сайт
                    if (IsIpExist(site, sqlConn, ipArr))
                    {
                        if (site.DomainName != "unknown ip" || site.DomainName != "invalid ip" || !string.IsNullOrEmpty(site.DomainName))
                        {
                            Tuple<int, string> domainId = GetDomainId(site.DomainName, sqlConn);
                            if (domainId.Item1 == 0) return new Tuple<bool, string>(false, domainId.Item2);

                            SqlCommand command = new SqlCommand($"UPDATE [omegaPU04].[dbo].[T_SITES] SET [site_name] = {domainId.Item1}  " +
                            $" WHERE ( [ip1] = {ipArr[0]} AND [ip2] = {ipArr[1]} AND [ip3] = {ipArr[2]} AND [ip4] = {ipArr[3]}) ", sqlConn);
                            command.ExecuteNonQuery();
                        }
                        if (!string.IsNullOrEmpty(site.SiteName))
                        {
                            SqlCommand command = new SqlCommand($"UPDATE [omegaPU04].[dbo].[T_SITES] SET [statistics_name] = '{site.SiteName}'  " +
                            $" WHERE ( [ip1] = {ipArr[0]} AND [ip2] = {ipArr[1]} AND [ip3] = {ipArr[2]} AND [ip4] = {ipArr[3]}) ", sqlConn);
                            command.ExecuteNonQuery();
                        }
                        return new Tuple<bool, string>(true, "ОК");
                    }
                    //вставить новый сайт
                    else
                    {
                        string domainName = string.Empty;
                        if (site.DomainName != "unknown ip" || site.DomainName != "invalid ip" || !string.IsNullOrEmpty(site.DomainName))
                        {
                            if (!string.IsNullOrEmpty(site.SiteName))
                                domainName = site.SiteName;
                        }
                        else
                            domainName = site.DomainName;

                        if (string.IsNullOrEmpty(domainName))
                        {
                            Tuple<int, string> domainId = GetDomainId(domainName, sqlConn);
                            if (domainId.Item1 == 0) return new Tuple<bool, string>(false, domainId.Item2);

                            SqlCommand command = new SqlCommand($"INSERT INTO  [omegaPU04].[dbo].[T_SITES] VALUES ({site.OmegaRuleParametr}, {domainId.Item1},  " +
                            $" {ipArr[0]}, {ipArr[1]}, {ipArr[2]}, {ipArr[3]}, {site.SiteName} )", sqlConn);
                            command.ExecuteNonQuery();
                            return new Tuple<bool, string>(true, "ОК");
                        }   
                        else
                            return new Tuple<bool, string>(false, "Нельзя вставить сайт без доменного имени (Домен в Омеге или Домен в Статистике). Пл");
                    }
                }
                catch (Exception ex)
                {
                    return new Tuple<bool, string>(false, ex.Message);
                }
            }
        }

        private static bool IsIpExist(Site site, SqlConnection sqlConn, int[] ipArr)
        {
            try
            {
                SqlCommand command = new SqlCommand($"SELECT count(*) FROM [omegaPU04].[dbo].[T_SITES] WHERE " +
                    $" [ip1]={ipArr[0]} AND [ip2]={ipArr[1]} AND [ip3]={ipArr[2]} AND[ip4]={ipArr[3]} ", sqlConn);
                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static Tuple<int, string> GetDomainId(string domain, SqlConnection sqlConn)
        {
            try
            {
                SqlCommand command = new SqlCommand($"SELECT TOP 1 id FROM [omegaPU04].[dbo].[T_SITES_NAMES]  WHERE [name] = '{domain}' ", sqlConn);
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    int id = 0;
                    while (reader.Read())
                    {
                        id = Convert.ToInt32(reader[0]);
                        break;
                    }
                    reader.Close();
                    return new Tuple<int, string>(id, "");
                }
                else
                {
                    reader.Close();
                    SqlCommand insertCommand = new SqlCommand($"INSERT INTO [omegaPU04].[dbo].[T_SITES_NAMES] ([name]) VALUES ('{domain}');  SELECT scope_identity();", sqlConn);
                    return new Tuple<int, string>(Convert.ToInt32(insertCommand.ExecuteScalar()), "");
                }
            }
            catch (Exception ex)
            {
                return new Tuple<int, string>(0, ex.Message);
            }
        }


        private static int[] IpTointArray(string ip)
        {
            var strArr = ip.Split('.');
            int[] ipArr = new int[4];
            for (int i = 0; i < ipArr.Length; i++)
            {
                ipArr[i] = Convert.ToInt32(strArr[i]);
            }
            return ipArr;
        }
    }
}
