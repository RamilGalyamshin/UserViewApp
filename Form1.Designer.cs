namespace BarberShop
{
    partial class Menu
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
            this.buttonOpenClients = new System.Windows.Forms.Button();
            this.buttonOpenWorkers = new System.Windows.Forms.Button();
            this.buttonOpenRegistration = new System.Windows.Forms.Button();
            this.buttonOpenService = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonOpenClients
            // 
            this.buttonOpenClients.Location = new System.Drawing.Point(48, 57);
            this.buttonOpenClients.Name = "buttonOpenClients";
            this.buttonOpenClients.Size = new System.Drawing.Size(180, 41);
            this.buttonOpenClients.TabIndex = 0;
            this.buttonOpenClients.Text = "Клиенты";
            this.buttonOpenClients.UseVisualStyleBackColor = true;
            this.buttonOpenClients.Click += new System.EventHandler(this.buttonOpenClients_Click);
            // 
            // buttonOpenWorkers
            // 
            this.buttonOpenWorkers.Location = new System.Drawing.Point(48, 116);
            this.buttonOpenWorkers.Name = "buttonOpenWorkers";
            this.buttonOpenWorkers.Size = new System.Drawing.Size(180, 41);
            this.buttonOpenWorkers.TabIndex = 1;
            this.buttonOpenWorkers.Text = "Парикмахеры";
            this.buttonOpenWorkers.UseVisualStyleBackColor = true;
            this.buttonOpenWorkers.Click += new System.EventHandler(this.buttonOpenWorkers_Click);
            // 
            // buttonOpenRegistration
            // 
            this.buttonOpenRegistration.Location = new System.Drawing.Point(48, 228);
            this.buttonOpenRegistration.Name = "buttonOpenRegistration";
            this.buttonOpenRegistration.Size = new System.Drawing.Size(180, 41);
            this.buttonOpenRegistration.TabIndex = 2;
            this.buttonOpenRegistration.Text = "Записи";
            this.buttonOpenRegistration.UseVisualStyleBackColor = true;
            this.buttonOpenRegistration.Click += new System.EventHandler(this.buttonOpenRegistration_Click);
            // 
            // buttonOpenService
            // 
            this.buttonOpenService.Location = new System.Drawing.Point(48, 172);
            this.buttonOpenService.Name = "buttonOpenService";
            this.buttonOpenService.Size = new System.Drawing.Size(180, 41);
            this.buttonOpenService.TabIndex = 3;
            this.buttonOpenService.Text = "Услуги";
            this.buttonOpenService.UseVisualStyleBackColor = true;
            this.buttonOpenService.Click += new System.EventHandler(this.buttonOpenService_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 352);
            this.Controls.Add(this.buttonOpenService);
            this.Controls.Add(this.buttonOpenRegistration);
            this.Controls.Add(this.buttonOpenWorkers);
            this.Controls.Add(this.buttonOpenClients);
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOpenClients;
        private System.Windows.Forms.Button buttonOpenWorkers;
        private System.Windows.Forms.Button buttonOpenRegistration;
        private System.Windows.Forms.Button buttonOpenService;
    }
}

