namespace DnsIpController.View
{
    partial class SiteForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ruleID_textBox = new System.Windows.Forms.TextBox();
            this.objID_textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.omegaName_textBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.omegaControl_textBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.omegaParametr_textBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.omegaDomain_textBox = new System.Windows.Forms.TextBox();
            this.statisticsDomen_textBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.internetIP_listBox = new System.Windows.Forms.ListBox();
            this.addIP_button = new System.Windows.Forms.Button();
            this.removeIP_button = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.internetDomain_textBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.internetAlias_listBox = new System.Windows.Forms.ListBox();
            this.saveFile_button = new System.Windows.Forms.Button();
            this.saveOmega_button = new System.Windows.Forms.Button();
            this.sync_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id правила";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(157, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Id объекта";
            // 
            // ruleID_textBox
            // 
            this.ruleID_textBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ruleID_textBox.Location = new System.Drawing.Point(79, 18);
            this.ruleID_textBox.Name = "ruleID_textBox";
            this.ruleID_textBox.ReadOnly = true;
            this.ruleID_textBox.Size = new System.Drawing.Size(62, 20);
            this.ruleID_textBox.TabIndex = 2;
            this.ruleID_textBox.TabStop = false;
            // 
            // objID_textBox
            // 
            this.objID_textBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.objID_textBox.Location = new System.Drawing.Point(224, 14);
            this.objID_textBox.Name = "objID_textBox";
            this.objID_textBox.ReadOnly = true;
            this.objID_textBox.Size = new System.Drawing.Size(62, 20);
            this.objID_textBox.TabIndex = 3;
            this.objID_textBox.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Имя объекта в Омеге";
            // 
            // omegaName_textBox
            // 
            this.omegaName_textBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.omegaName_textBox.Location = new System.Drawing.Point(160, 59);
            this.omegaName_textBox.Name = "omegaName_textBox";
            this.omegaName_textBox.ReadOnly = true;
            this.omegaName_textBox.Size = new System.Drawing.Size(239, 20);
            this.omegaName_textBox.TabIndex = 5;
            this.omegaName_textBox.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Контроль объекта в Омеге";
            // 
            // omegaControl_textBox
            // 
            this.omegaControl_textBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.omegaControl_textBox.Location = new System.Drawing.Point(160, 96);
            this.omegaControl_textBox.Name = "omegaControl_textBox";
            this.omegaControl_textBox.ReadOnly = true;
            this.omegaControl_textBox.Size = new System.Drawing.Size(239, 20);
            this.omegaControl_textBox.TabIndex = 7;
            this.omegaControl_textBox.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Параметр контроля";
            // 
            // omegaParametr_textBox
            // 
            this.omegaParametr_textBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.omegaParametr_textBox.Location = new System.Drawing.Point(160, 131);
            this.omegaParametr_textBox.Name = "omegaParametr_textBox";
            this.omegaParametr_textBox.ReadOnly = true;
            this.omegaParametr_textBox.Size = new System.Drawing.Size(239, 20);
            this.omegaParametr_textBox.TabIndex = 9;
            this.omegaParametr_textBox.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 170);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Домен в Омеге";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 207);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Домен в Статистике";
            // 
            // omegaDomain_textBox
            // 
            this.omegaDomain_textBox.Location = new System.Drawing.Point(160, 167);
            this.omegaDomain_textBox.Name = "omegaDomain_textBox";
            this.omegaDomain_textBox.Size = new System.Drawing.Size(239, 20);
            this.omegaDomain_textBox.TabIndex = 12;
            this.omegaDomain_textBox.TabStop = false;
            // 
            // statisticsDomen_textBox
            // 
            this.statisticsDomen_textBox.Location = new System.Drawing.Point(160, 204);
            this.statisticsDomen_textBox.Name = "statisticsDomen_textBox";
            this.statisticsDomen_textBox.Size = new System.Drawing.Size(239, 20);
            this.statisticsDomen_textBox.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 302);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "IP адреса в интернете";
            // 
            // internetIP_listBox
            // 
            this.internetIP_listBox.FormattingEnabled = true;
            this.internetIP_listBox.Location = new System.Drawing.Point(160, 302);
            this.internetIP_listBox.Name = "internetIP_listBox";
            this.internetIP_listBox.Size = new System.Drawing.Size(206, 82);
            this.internetIP_listBox.TabIndex = 15;
            // 
            // addIP_button
            // 
            this.addIP_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addIP_button.Location = new System.Drawing.Point(373, 302);
            this.addIP_button.Name = "addIP_button";
            this.addIP_button.Size = new System.Drawing.Size(26, 23);
            this.addIP_button.TabIndex = 16;
            this.addIP_button.Text = "+";
            this.addIP_button.UseVisualStyleBackColor = true;
            this.addIP_button.Click += new System.EventHandler(this.addIP_button_Click);
            // 
            // removeIP_button
            // 
            this.removeIP_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.removeIP_button.Location = new System.Drawing.Point(373, 331);
            this.removeIP_button.Name = "removeIP_button";
            this.removeIP_button.Size = new System.Drawing.Size(26, 23);
            this.removeIP_button.TabIndex = 17;
            this.removeIP_button.Text = "-";
            this.removeIP_button.UseVisualStyleBackColor = true;
            this.removeIP_button.Click += new System.EventHandler(this.removeIP_button_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 243);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Домен в интернете";
            // 
            // internetDomain_textBox
            // 
            this.internetDomain_textBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.internetDomain_textBox.Location = new System.Drawing.Point(160, 240);
            this.internetDomain_textBox.Name = "internetDomain_textBox";
            this.internetDomain_textBox.ReadOnly = true;
            this.internetDomain_textBox.Size = new System.Drawing.Size(239, 20);
            this.internetDomain_textBox.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 415);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Алиас в интернете";
            // 
            // internetAlias_listBox
            // 
            this.internetAlias_listBox.FormattingEnabled = true;
            this.internetAlias_listBox.Location = new System.Drawing.Point(160, 415);
            this.internetAlias_listBox.Name = "internetAlias_listBox";
            this.internetAlias_listBox.Size = new System.Drawing.Size(206, 82);
            this.internetAlias_listBox.TabIndex = 21;
            // 
            // saveFile_button
            // 
            this.saveFile_button.Location = new System.Drawing.Point(268, 508);
            this.saveFile_button.Name = "saveFile_button";
            this.saveFile_button.Size = new System.Drawing.Size(131, 23);
            this.saveFile_button.TabIndex = 22;
            this.saveFile_button.Text = "Сохранить в файл";
            this.saveFile_button.UseVisualStyleBackColor = true;
            this.saveFile_button.Click += new System.EventHandler(this.saveFile_button_Click);
            // 
            // saveOmega_button
            // 
            this.saveOmega_button.Location = new System.Drawing.Point(10, 508);
            this.saveOmega_button.Name = "saveOmega_button";
            this.saveOmega_button.Size = new System.Drawing.Size(131, 23);
            this.saveOmega_button.TabIndex = 23;
            this.saveOmega_button.Text = "Сохранить в Омеге";
            this.saveOmega_button.UseVisualStyleBackColor = true;
            this.saveOmega_button.Click += new System.EventHandler(this.saveOmega_button_Click);
            // 
            // sync_button
            // 
            this.sync_button.Location = new System.Drawing.Point(268, 267);
            this.sync_button.Name = "sync_button";
            this.sync_button.Size = new System.Drawing.Size(131, 23);
            this.sync_button.TabIndex = 24;
            this.sync_button.Text = "Синхронизировать";
            this.sync_button.UseVisualStyleBackColor = true;
            this.sync_button.Click += new System.EventHandler(this.sync_button_Click);
            // 
            // SiteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 541);
            this.Controls.Add(this.sync_button);
            this.Controls.Add(this.saveOmega_button);
            this.Controls.Add(this.saveFile_button);
            this.Controls.Add(this.internetAlias_listBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.internetDomain_textBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.removeIP_button);
            this.Controls.Add(this.addIP_button);
            this.Controls.Add(this.internetIP_listBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.statisticsDomen_textBox);
            this.Controls.Add(this.omegaDomain_textBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.omegaParametr_textBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.omegaControl_textBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.omegaName_textBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.objID_textBox);
            this.Controls.Add(this.ruleID_textBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SiteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ruleID_textBox;
        private System.Windows.Forms.TextBox objID_textBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox omegaName_textBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox omegaControl_textBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox omegaParametr_textBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox omegaDomain_textBox;
        private System.Windows.Forms.TextBox statisticsDomen_textBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox internetIP_listBox;
        private System.Windows.Forms.Button addIP_button;
        private System.Windows.Forms.Button removeIP_button;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox internetDomain_textBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox internetAlias_listBox;
        private System.Windows.Forms.Button saveFile_button;
        private System.Windows.Forms.Button saveOmega_button;
        private System.Windows.Forms.Button sync_button;
    }
}