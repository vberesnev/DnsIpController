using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DnsIpController.Controller;
using System.IO;

namespace DnsIpController
{
    public partial class MainForm : Form
    {

        private SitesListController controller; 

        public MainForm()
        {
            InitializeComponent();
            controller = new SitesListController(Path.Combine(System.Environment.CurrentDirectory, "tasks.csv"));
            
        }

        private async void omega_button_Click(object sender, EventArgs e)
        {
            await OmegaLoadAsync();
            info_label.Text = controller.Message;
        }

        private Task<bool> OmegaLoadAsync()
        {
            return Task.Run(() => controller.LoadFromOmega()); 
        }


    }
}
