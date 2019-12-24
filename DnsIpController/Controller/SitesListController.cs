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
        public List<Site> List { get; private set; }
        public Site CurrentSite { get; set; }
        public string Message { get; private set; }

        private FileInfo file;

        public SitesListController(string filePath)
        {
            SitesList = new SitesList();
            List = SitesList.Items;
            Message = SitesList.InfoMessage;
            file = new FileInfo(filePath);
        }

        public void Load()
        {
            if (File.Exists(file.FullName))
                SitesList.LoadTasksFromFile(file.FullName, ";");
            else
                Message = $"Файла {file.FullName} не сущестует. Сначала загрузите его через базу Омеги";
        }

        public bool LoadFromOmega()
        {
            var b = SitesList.LoadTasksFromOmega(file.FullName);
            Message = SitesList.InfoMessage;
            return b;
        }
    }
}
