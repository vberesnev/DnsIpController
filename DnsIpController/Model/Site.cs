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
        public string OmegaTaskName { get; set; }
        public string OmegaRuleName { get; set; }
        public string OmegaRuleParametr { get; set; }

        public OmegaTaskType OmegaTaskType { get; private set; }

        public string OmegaSiteIP { get; set; }
        public string OmegaSiteName { get; set; }

        public string StatisticsSiteName { get; set; }

        public List<IPAddress> InternetSiteIPs { get; set; }
        public string InternetSiteDomain { get; set; }
        public List<string> InternetSiteAliases { get; set; }

        

        public Site()
        {

        }

        public void GetInternetDomain()
        {
            try
            {
                IPAddress ip = IPAddress.Parse(OmegaSiteIP);
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
            if (OmegaTaskType == OmegaTaskType.IP) return;

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
            return "";
        }
    }
}
