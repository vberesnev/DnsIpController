using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnsIpController.Model;
using System.IO;

namespace DnsIpController.Controller
{
    public class SitesListController
    {
        private SitesList SitesList;
        public List<Site> List;
        public Site CurrentSite;

        private string FILE_PATH = Path.Combine(System.Environment.CurrentDirectory, "tasks.csv");

        public SitesListController()
        {
            SitesList = new SitesList();
            List = SitesList.Items;
        }

        public void Load()
        {
            SitesList.LoadTasksFromFile(FILE_PATH, ";");
        }
    }
}
