namespace DnsIpController.View
{
    partial class AddIpForm
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
            this.oktet1_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.oktet2_textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.oktet3_textBox = new System.Windows.Forms.TextBox();
            this.oktet4_textBox = new System.Windows.Forms.TextBox();
            this.ok_button = new System.Windows.Forms.Button();
            this.info_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // oktet1_textBox
            // 
            this.oktet1_textBox.Location = new System.Drawing.Point(13, 13);
            this.oktet1_textBox.Name = "oktet1_textBox";
            this.oktet1_textBox.Size = new System.Drawing.Size(52, 20);
            this.oktet1_textBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(145, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "-";
            // 
            // oktet2_textBox
            // 
            this.oktet2_textBox.Location = new System.Drawing.Point(87, 12);
            this.oktet2_textBox.Name = "oktet2_textBox";
            this.oktet2_textBox.Size = new System.Drawing.Size(52, 20);
            this.oktet2_textBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(219, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "-";
            // 
            // oktet3_textBox
            // 
            this.oktet3_textBox.Location = new System.Drawing.Point(161, 12);
            this.oktet3_textBox.Name = "oktet3_textBox";
            this.oktet3_textBox.Size = new System.Drawing.Size(52, 20);
            this.oktet3_textBox.TabIndex = 4;
            // 
            // oktet4_textBox
            // 
            this.oktet4_textBox.Location = new System.Drawing.Point(235, 12);
            this.oktet4_textBox.Name = "oktet4_textBox";
            this.oktet4_textBox.Size = new System.Drawing.Size(52, 20);
            this.oktet4_textBox.TabIndex = 6;
            // 
            // ok_button
            // 
            this.ok_button.Location = new System.Drawing.Point(235, 49);
            this.ok_button.Name = "ok_button";
            this.ok_button.Size = new System.Drawing.Size(52, 23);
            this.ok_button.TabIndex = 7;
            this.ok_button.Text = "ОК";
            this.ok_button.UseVisualStyleBackColor = true;
            this.ok_button.Click += new System.EventHandler(this.ok_button_Click);
            // 
            // info_label
            // 
            this.info_label.AutoSize = true;
            this.info_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.info_label.Location = new System.Drawing.Point(12, 54);
            this.info_label.Name = "info_label";
            this.info_label.Size = new System.Drawing.Size(0, 13);
            this.info_label.TabIndex = 8;
            // 
            // AddIpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 82);
            this.Controls.Add(this.info_label);
            this.Controls.Add(this.ok_button);
            this.Controls.Add(this.oktet4_textBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.oktet3_textBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.oktet2_textBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.oktet1_textBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddIpForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавить IP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox oktet1_textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox oktet2_textBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox oktet3_textBox;
        private System.Windows.Forms.TextBox oktet4_textBox;
        private System.Windows.Forms.Button ok_button;
        private System.Windows.Forms.Label info_label;
    }
}