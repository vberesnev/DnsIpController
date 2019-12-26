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

namespace DnsIpController.View
{
    public partial class AddIpForm : Form
    {
        private byte oktet1;
        private byte oktet2;
        private byte oktet3;
        private byte oktet4;

        private AddIpDelegate addIpDeleg;

        public AddIpForm(AddIpDelegate addIpDeleg)
        {
            InitializeComponent();
            this.addIpDeleg = addIpDeleg;
        }

        private void ok_button_Click(object sender, EventArgs e)
        {
            if (CheckIp())
            {
                IPAddress ip = new IPAddress(new byte[4] { oktet1, oktet2, oktet3, oktet4 });
                addIpDeleg(ip);
                this.Close();
            }
            else
                info_label.Text = "Ошибка IP адреса";
            
        }

        private bool CheckIp()
        {
            if (!byte.TryParse(oktet1_textBox.Text, out oktet1))
                return false;
            if (!byte.TryParse(oktet2_textBox.Text, out oktet2))
                return false;
            if (!byte.TryParse(oktet3_textBox.Text, out oktet3))
                return false;
            if (!byte.TryParse(oktet4_textBox.Text, out oktet4))
                return false;
            return true;
        }
    }
}
