using System;
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

        public Site(int ruleId, int objId, string omegaTaskName, string ruleName, string omegRuleParametr, string domainName, string siteName, string ipList, string internetDomain, string aliasesList)
        {
            //ЗАКОНЧИТЬ КОНСТРУКТОР
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

        public string ToCsvString(string separator)
        {
            return $"{RuleID};{ObjectID};{OmegaTaskName};{OmegaRuleName};{(int)OmegaTaskType};{OmegaRuleParametr};{DomainName};{SiteName};{GetIpList(InternetSiteIPs)};{InternetSiteDomain};{string.Join("&", InternetSiteAliases.ToArray())}";
        }

        private string GetIpList(List<IPAddress> addresses)
        {
            string result = "";
            if (addresses.Count == 0) return result;

            foreach (var ip in addresses)
                result += ip.ToString() + "&";
            return result.Remove(result.Length - 1);
        }
    }
}
