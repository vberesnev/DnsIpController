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
using DnsIpController.View;

namespace DnsIpController
{
    public delegate void SetInfoDelegate(string text);
    public delegate void SetDataSourceDelegate();

    public partial class MainForm : Form
    {
        SetInfoDelegate sid;
        SetDataSourceDelegate sds;

        private SitesListController controller; 

        public MainForm()
        {
            InitializeComponent();
            controller = new SitesListController(Path.Combine(System.Environment.CurrentDirectory, "tasks.csv"));
            sid = SetInfo;

            ToolStripMenuItem syncItem = new ToolStripMenuItem("Синхронизировать");
            syncItem.Click += SyncItem_Click;
            contextMenuStrip1.Items.Add(syncItem);
        }

        private async void SyncItem_Click(object sender, EventArgs e)
        {
            info_label.Text = "Синхронизация";
            foreach (DataGridViewRow row in sitesList_dataGridView.SelectedRows)
            {
                controller.SyncParametrs((int)row.Cells[0].Value, (int)row.Cells[1].Value, row.Cells[2].Value.ToString());
            }
            await SaveAllAsync(); 
            info_label.Text = controller.Message;
        }

        private Task SaveAllAsync()
        {
            return Task.Run(() => controller.SaveAllToFile());
        }

        private async void omega_button_Click(object sender, EventArgs e)
        {
            info_label.Text = "Загрузка данных с сервера Омеги . . .";
            await OmegaLoadAsync();
            info_label.Text = controller.Message;
        }

        private Task OmegaLoadAsync()
        {
            return Task.Run(() => controller.LoadFromOmega()); 
        }

        private async void file_button_Click(object sender, EventArgs e)
        {
            info_label.Text = "Загрузка данных из файла . . .";
            await FileLoadAsync();
            info_label.Text = controller.Message;
            SetDataSource();
        }

        private Task FileLoadAsync()
        {
            return Task.Run(() => controller.LoadFromFile());
        }

        private async void internet_button_Click(object sender, EventArgs e)
        {
            info_label.Text = "Загрузка данных из Internet . . .";
            await InternetLoadAsync(sid);
            info_label.Text = controller.Message;
            SetDataSource();
        }

        private Task InternetLoadAsync(SetInfoDelegate sid)
        {
            return Task.Run(() => controller.LoadFromInternet(sid));
        }

        private void SetDataSource()
        {
            var source = new BindingSource();
            source.DataSource = controller.List;
            sitesList_dataGridView.DataSource = source;
            SetDataGridView();
        }

        private void SetDataGridView()
        {
            sitesList_dataGridView.Columns[0].Visible = false;
            sitesList_dataGridView.Columns[1].Visible = false;

            sitesList_dataGridView.Columns[2].HeaderText = "Задание в Омеге";
            sitesList_dataGridView.Columns[2].Width = 150;
            sitesList_dataGridView.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            sitesList_dataGridView.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            sitesList_dataGridView.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;

            sitesList_dataGridView.Columns[3].Visible = false;
            sitesList_dataGridView.Columns[4].Visible = false;

            sitesList_dataGridView.Columns[5].HeaderText = "Параметр";
            sitesList_dataGridView.Columns[5].Width = 130;
            sitesList_dataGridView.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            sitesList_dataGridView.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            sitesList_dataGridView.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;

            sitesList_dataGridView.Columns[6].HeaderText = "Домен в Статистике";
            sitesList_dataGridView.Columns[6].Width = 200;
            sitesList_dataGridView.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            sitesList_dataGridView.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            sitesList_dataGridView.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;

            sitesList_dataGridView.Columns[7].HeaderText = "Домен в Омеге";
            sitesList_dataGridView.Columns[7].Width = 300;
            sitesList_dataGridView.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            sitesList_dataGridView.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            sitesList_dataGridView.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;

            sitesList_dataGridView.Columns[8].HeaderText = "IP адреса в Интернете";
            sitesList_dataGridView.Columns[8].Width = 150;
            sitesList_dataGridView.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            sitesList_dataGridView.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            sitesList_dataGridView.Columns[8].SortMode = DataGridViewColumnSortMode.NotSortable;

            sitesList_dataGridView.Columns[9].HeaderText = "Домен в Интернете";
            sitesList_dataGridView.Columns[9].Width = 300;
            sitesList_dataGridView.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            sitesList_dataGridView.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            sitesList_dataGridView.Columns[9].SortMode = DataGridViewColumnSortMode.NotSortable;

            sitesList_dataGridView.Refresh();

            
        }

        private void SetInfo(string text)
        {
            info_label.Invoke(new Action(() => { info_label.Text = text; }));
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            info_label.Text = "Загрузка данных из файла . . .";
            await FileLoadAsync();
            info_label.Text = controller.Message;
            SetDataSource();
        }

        private void OpenSiteForm(int ruleId, int objId)
        {
            controller.SetCurrent(ruleId, objId);
            if (controller.CurrentSite != null)
            {
                sds = SetDataSource;
                SiteForm SF = new SiteForm(controller, sds);
                SF.Owner = this;
                SF.ShowDialog();
            }
            else
                info_label.Text = "Не выбран сайт из списка сайтов";
        }

        private void sitesList_dataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            OpenSiteForm((int)sitesList_dataGridView.SelectedRows[0].Cells[0].Value, (int)sitesList_dataGridView.SelectedRows[0].Cells[1].Value);
        }

        private void sitesList_dataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                sitesList_dataGridView.Rows[sitesList_dataGridView.SelectedRows[0].Index].Selected = false;
                sitesList_dataGridView.Rows[e.RowIndex].Selected = true;
                sitesList_dataGridView.Rows[e.RowIndex].ContextMenuStrip = contextMenuStrip1;
                contextMenuStrip1.Show(Cursor.Position);
                sitesList_dataGridView.Rows[e.RowIndex].ContextMenuStrip = null;
            } 
        }
    }
}
