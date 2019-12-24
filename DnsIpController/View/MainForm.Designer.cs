namespace DnsIpController
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.omega_button = new System.Windows.Forms.Button();
            this.info_label = new System.Windows.Forms.Label();
            this.file_button = new System.Windows.Forms.Button();
            this.internet_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // omega_button
            // 
            this.omega_button.Location = new System.Drawing.Point(12, 21);
            this.omega_button.Name = "omega_button";
            this.omega_button.Size = new System.Drawing.Size(94, 36);
            this.omega_button.TabIndex = 0;
            this.omega_button.Text = "Загрузить из Омеги";
            this.omega_button.UseVisualStyleBackColor = true;
            this.omega_button.Click += new System.EventHandler(this.omega_button_Click);
            // 
            // info_label
            // 
            this.info_label.AutoSize = true;
            this.info_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.info_label.Location = new System.Drawing.Point(12, 78);
            this.info_label.Name = "info_label";
            this.info_label.Size = new System.Drawing.Size(53, 20);
            this.info_label.TabIndex = 1;
            this.info_label.Text = "Инфо";
            // 
            // file_button
            // 
            this.file_button.Location = new System.Drawing.Point(134, 21);
            this.file_button.Name = "file_button";
            this.file_button.Size = new System.Drawing.Size(94, 36);
            this.file_button.TabIndex = 2;
            this.file_button.Text = "Загрузить из файла";
            this.file_button.UseVisualStyleBackColor = true;
            // 
            // internet_button
            // 
            this.internet_button.Location = new System.Drawing.Point(257, 21);
            this.internet_button.Name = "internet_button";
            this.internet_button.Size = new System.Drawing.Size(94, 36);
            this.internet_button.TabIndex = 3;
            this.internet_button.Text = "Загрузить из интернета";
            this.internet_button.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 646);
            this.Controls.Add(this.internet_button);
            this.Controls.Add(this.file_button);
            this.Controls.Add(this.info_label);
            this.Controls.Add(this.omega_button);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button omega_button;
        private System.Windows.Forms.Label info_label;
        private System.Windows.Forms.Button file_button;
        private System.Windows.Forms.Button internet_button;
    }
}

