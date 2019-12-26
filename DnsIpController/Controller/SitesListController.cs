using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnsIpController.Model;
using System.IO;
using DnsIpController.View;

namespace DnsIpController.Controller
{
    public class SitesListController
    {
        private SitesList SitesList;
        public List<Site> List { get; private set; }
        public int CountSites => List.Count;
        public Site CurrentSite { get; set; }
        public string Message { get; private set; }

        private FileInfo file;

        public SitesListController(string filePath)
        {
            SitesList = new SitesList();
            List = SitesList.Items;
            file = new FileInfo(filePath);
        }

        public void LoadFromFile()
        {
            if (File.Exists(file.FullName))
            {
                SitesList.LoadTasksFromFile(file.FullName, ";");
                Message = SitesList.InfoMessage;
                if (SitesList.Count > 0) List = SitesList.Items;
            }
                
            else
                Message = $"Файла {file.FullName} не сущестует. Сначала загрузите его через базу Омеги";
        }

        public void LoadFromOmega()
        {
            if (NetsConnection.CheckOmegaConnection())
            {
                SitesList.LoadTasksFromOmega(file.FullName);
                Message = SitesList.InfoMessage;
                if (SitesList.Count > 0) List = SitesList.Items;
            }
            else
                Message = "Нет подключения к сети Омега";
        }

        public void LoadFromInternet(SetInfoDelegate sid)
        {
            if (NetsConnection.CheckInternetConnection())
            {
                SitesList.LoadFromInternet(file.FullName, sid);
                Message = SitesList.InfoMessage;
                if (SitesList.Count > 0) List = SitesList.Items;
            }
            else
                Message = "Нет подключения к сети Интернет";
        }

        public void SetCurrent(int ruleId, int objId)
        {
            CurrentSite = List.FirstOrDefault(x => x.RuleID == ruleId && x.ObjectID == objId);
        }

        public bool SaveSiteInfoToOmega(ShowMessageDelegate showMessageDeleg)
        {
            if (NetsConnection.CheckOmegaConnection())
            {
                Tuple<bool, string> result = CurrentSite.SaveToOmega();
                if (!result.Item1)
                    showMessageDeleg(result.Item2);
                return result.Item1;
            }
            else
            {
                showMessageDeleg("Нет подключения к сети Омега");
                return false;
            }
                
        }

        public bool SaveSiteInfoToFile(ShowMessageDelegate showMessageDeleg)
        {
            try
            {
                List.Find(x => x.RuleID == CurrentSite.RuleID && x.ObjectID == CurrentSite.ObjectID).DomainName = CurrentSite.DomainName;
                List.Find(x => x.RuleID == CurrentSite.RuleID && x.ObjectID == CurrentSite.ObjectID).SiteName = CurrentSite.SiteName;
                SitesList.SaveTasksToFile(file.FullName, ";");
                return true;
            }
            catch (Exception ex)
            {
                showMessageDeleg(ex.Message);
                return false;
            }
        }
    }
}
