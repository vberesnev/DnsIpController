using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DnsIpController.Controller;

namespace DnsIpController.View
{
    public delegate void AddIpDelegate(IPAddress ip);
    public delegate void ShowMessageDelegate(string message);

    public partial class SiteForm : Form
    {
        private SitesListController controller;
        private AddIpDelegate AddIpDeleg;
        private ShowMessageDelegate ShowMessageDeleg;

        public SiteForm(SitesListController controller, SetDataSourceDelegate sds)
        {
            InitializeComponent();
            this.controller = controller;
            this.Text = controller.CurrentSite.OmegaTaskName;
            this.ruleID_textBox.Text = controller.CurrentSite.RuleID.ToString();
            this.objID_textBox.Text = controller.CurrentSite.ObjectID.ToString();
            this.omegaName_textBox.Text = controller.CurrentSite.OmegaTaskName;
            this.omegaControl_textBox.Text = controller.CurrentSite.OmegaRuleName;
            this.omegaParametr_textBox.Text = controller.CurrentSite.OmegaRuleParametr;
            this.omegaDomain_textBox.Text = controller.CurrentSite.DomainName;
            this.statisticsDomen_textBox.Text = controller.CurrentSite.SiteName;
            this.internetDomain_textBox.Text = controller.CurrentSite.InternetSiteDomain;
            this.internetIP_listBox.DataSource = GetIpList(controller.CurrentSite.InternetSiteIPs);
            this.internetAlias_listBox.DataSource = controller.CurrentSite.InternetSiteAliases;

            saveFile_button.Focus();
        }

        private List<string> GetIpList(List<IPAddress> ipAddresses)
        {
            List<string> list = new List<string>();
            foreach (var ip in ipAddresses)
                list.Add(ip.ToString());
            return list;
        }

        private void removeIP_button_Click(object sender, EventArgs e)
        {
            if (internetIP_listBox.SelectedItem == null) return;
            string removebleIp = internetIP_listBox.SelectedItem.ToString();
            IPAddress ip = controller.CurrentSite.InternetSiteIPs.FirstOrDefault(x => x.ToString() == removebleIp);
            if (ip != null)
            {
                controller.CurrentSite.InternetSiteIPs.Remove(ip);
                this.internetIP_listBox.DataSource = GetIpList(controller.CurrentSite.InternetSiteIPs);
            }
        }

        private void addIP_button_Click(object sender, EventArgs e)
        {
            if (controller.CurrentSite.OmegaTaskType == Model.OmegaTaskType.IP)
            {
                MessageBox.Show("Задание на контроле по IP, нельзя добавить еще IP к нему. Открой задание по домену");
            }
            else
            {
                AddIpDeleg = AddIp;
                AddIpForm AIF = new AddIpForm(AddIpDeleg);
                AIF.Owner = this;
                AIF.ShowDialog();
            }
           
        }

        private void AddIp(IPAddress ip)
        {
            controller.CurrentSite.InternetSiteIPs.Add(ip);
            internetIP_listBox.DataSource = null;
            internetIP_listBox.DataSource = GetIpList(controller.CurrentSite.InternetSiteIPs);
        }

        private void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        private async void saveOmega_button_Click(object sender, EventArgs e)
        {
            string domainTemp = controller.CurrentSite.DomainName;
            string siteTemp = controller.CurrentSite.SiteName;

            controller.CurrentSite.DomainName = omegaDomain_textBox.Text;
            controller.CurrentSite.SiteName = statisticsDomen_textBox.Text;
            ShowMessageDeleg = ShowMessage;
            bool result = await SaveSiteInfoToOmegaAsync(ShowMessageDeleg);
            if (result)
            {
                result = await SaveSiteInfoToFileAsync(ShowMessageDeleg);
                if (result)
                    this.Close();
            }
            else
            {
                controller.CurrentSite.DomainName = domainTemp;
                controller.CurrentSite.SiteName = siteTemp;
            }

        }

        private Task<bool> SaveSiteInfoToOmegaAsync(ShowMessageDelegate showMessageDeleg)
        {
            return Task.Run(() => controller.SaveSiteInfoToOmega(showMessageDeleg));
        }

        private void sync_button_Click(object sender, EventArgs e)
        {
            omegaDomain_textBox.Text = internetDomain_textBox.Text;
        }

        private async void saveFile_button_Click(object sender, EventArgs e)
        {
            controller.CurrentSite.DomainName = omegaDomain_textBox.Text;
            controller.CurrentSite.SiteName = statisticsDomen_textBox.Text;
            ShowMessageDeleg = ShowMessage;
            bool result = await SaveSiteInfoToFileAsync(ShowMessageDeleg);
            if (result)
                this.Close();
        }

        private Task<bool> SaveSiteInfoToFileAsync(ShowMessageDelegate showMessageDeleg)
        {
            return Task.Run(() => controller.SaveSiteInfoToFile(showMessageDeleg));
        }
    }
}
