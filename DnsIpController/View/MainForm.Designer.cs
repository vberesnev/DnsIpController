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
            this.SuspendLayout();
            // 
            // omega_button
            // 
            this.omega_button.Location = new System.Drawing.Point(12, 12);
            this.omega_button.Name = "omega_button";
            this.omega_button.Size = new System.Drawing.Size(75, 23);
            this.omega_button.TabIndex = 0;
            this.omega_button.Text = "Омега";
            this.omega_button.UseVisualStyleBackColor = true;
            this.omega_button.Click += new System.EventHandler(this.omega_button_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 646);
            this.Controls.Add(this.omega_button);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button omega_button;
    }
}

