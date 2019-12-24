﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace DnsIpController.Model
{
    public class Site
    {
        public int RuleID { get; set; }
        public int ObjectID { get; set; }
        public string OmegaTaskName { get; set; }
        public string OmegaRuleName { get; set; }
        public OmegaTaskType OmegaTaskType { get; private set; }
        public string OmegaRuleParametr { get; set; }
        public string DomainName { get; set; }
        public string SiteName { get; set; }

        public List<IPAddress> InternetSiteIPs { get; set; }
        public string InternetSiteDomain { get; set; }
        public List<string> InternetSiteAliases { get; set; }

        public Site(int ruleId, int objId, string omegaTaskName, string ruleName, string omegRuleParametr, string domainName, string siteName)
        {
            RuleID = ruleId;
            ObjectID = objId;
            OmegaTaskName = omegaTaskName;
            OmegaRuleName = ruleName;
            OmegaRuleParametr = omegRuleParametr;
            DomainName = domainName;
            SiteName = siteName;

            if (OmegaRuleName.ToLower() == "ip")
                OmegaTaskType = OmegaTaskType.IP;
            else if (OmegaRuleName.ToLower().Contains("http"))
                OmegaTaskType = OmegaTaskType.Domain;
            else
                OmegaTaskType = OmegaTaskType.Other;

            InternetSiteIPs = new List<IPAddress>();
            InternetSiteAliases = new List<string>();
        }

        public Site(int ruleId, int objId, string omegaTaskName, string ruleName, int omegataskType, string omegRuleParametr, string domainName, string siteName, string ipList, string internetDomain, string aliasesList)
        {
            RuleID = ruleId;
            ObjectID = objId;
            OmegaTaskName = omegaTaskName;
            OmegaRuleName = ruleName;
            OmegaTaskType = (OmegaTaskType)omegataskType;
            OmegaRuleParametr = omegRuleParametr;
            DomainName = domainName;
            SiteName = siteName;

            InternetSiteIPs = GetIpList(ipList);
            DomainName = domainName;
            InternetSiteAliases = aliasesList.Split('&').ToList();
        }

        public void GetInternetDomain()
        {
            try
            {
                IPAddress ip = IPAddress.Parse(OmegaRuleParametr);
                IPHostEntry entry = Dns.GetHostEntry(ip);
                InternetSiteDomain = entry.HostName;
                InternetSiteAliases = entry.Aliases.ToList();
            }
            catch (System.Net.Sockets.SocketException)
            {
                InternetSiteDomain = "unknown ip";
            }
            catch (System.ArgumentException)
            {
                InternetSiteDomain = "invalid ip";
            }
        }

        public void GetInternetIp()
        {
            if (OmegaTaskType != OmegaTaskType.Domain) return;

            try
            {
                IPHostEntry entry = Dns.GetHostEntry(OmegaRuleParametr);
                InternetSiteIPs = entry.AddressList.ToList();
                InternetSiteAliases = entry.Aliases.ToList();
            }
            catch (System.Net.Sockets.SocketException)
            {
                InternetSiteDomain = "unknown domain";
            }
            catch (System.ArgumentException)
            {
                InternetSiteDomain = "invalid domain";
            }
        }

        /// <summary>
        /// Метод возвращает строку, содержащую все параметры оьбъекта дял записи в csv
        /// </summary>
        /// <param name="separator">Разделить</param>
        /// <returns></returns>
        public string ToCsvString(string separator=";")
        {
            return  $"{RuleID}{separator}{ObjectID}{separator}{OmegaTaskName}{separator}{OmegaRuleName}{separator}{(int)OmegaTaskType}{separator}"+
                    $"{OmegaRuleParametr}{separator}{DomainName}{separator}{SiteName}{separator}{GetIpList(InternetSiteIPs)}{separator}"+
                    $"{InternetSiteDomain}{separator}{string.Join("&", InternetSiteAliases.ToArray())}";
        }

        /// <summary>
        /// Метод возвращает списко IP адресов в строчке, разделенной '&'
        /// </summary>
        /// <param name="addresses">Спиок IP адресов</param>
        /// <returns>Строка IP адресов</returns>
        private string GetIpList(List<IPAddress> addresses)
        {
            string result = "";
            if (addresses.Count == 0) return result;

            foreach (var ip in addresses)
                result += ip.ToString() + "&";
            return result.Remove(result.Length - 1);
        }

        /// <summary>
        /// Метод возвращает список IP адресов из строки (адреса должны быть разделены &)
        /// </summary>
        /// <param name="str">Входаня строка</param>
        /// <returns>Список IP адресов</returns>
        private List<IPAddress> GetIpList(string str)
        {
            List<IPAddress> list = new List<IPAddress>();
            if (string.IsNullOrEmpty(str) || str.ToLower() == "null") return list;

            int countSeparator = str.Count(x => x == '&');
            if (countSeparator == 0)
                list.Add(new IPAddress(GetIpFromString(str)));
            else
            {
                var ipStr = str.Split('&');
                for (int i = 0; i < ipStr.Length; i++)
                {
                    list.Add(new IPAddress(GetIpFromString(ipStr[i])));
                }
            }
            return list;
        }

        /// <summary>
        /// Метод возвращает массив байт октэтов IP адреса
        /// </summary>
        /// <param name="str">IP адрес в строке</param>
        /// <returns>Массив байт октэтов IP адреса </returns>
        private byte[] GetIpFromString(string str)
        {
            var ipArr = str.Split('.');
            if (ipArr.Length != 4) return null;
            byte[] ipByte = new byte[ipArr.Length];

            for (int i = 0; i < ipArr.Length; i++)
            {
                ipByte[i] = Convert.ToByte(ipArr[i]);
            }
            return ipByte;
        }
    }
}
