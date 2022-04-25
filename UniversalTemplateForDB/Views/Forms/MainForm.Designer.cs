
namespace UniversalTemplateForDB
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.ProductBtn = new System.Windows.Forms.Button();
            this.MaterialBtn = new System.Windows.Forms.Button();
            this.MasterBtn = new System.Windows.Forms.Button();
            this.CompanyBtn = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(28)))), ((int)(((byte)(96)))));
            this.panel2.Controls.Add(this.ProductBtn);
            this.panel2.Controls.Add(this.MaterialBtn);
            this.panel2.Controls.Add(this.MasterBtn);
            this.panel2.Controls.Add(this.CompanyBtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(189, 596);
            this.panel2.TabIndex = 2;
            // 
            // ProductBtn
            // 
            this.ProductBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ProductBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.ProductBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ProductBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ProductBtn.Location = new System.Drawing.Point(0, 203);
            this.ProductBtn.Name = "ProductBtn";
            this.ProductBtn.Size = new System.Drawing.Size(189, 69);
            this.ProductBtn.TabIndex = 3;
            this.ProductBtn.Text = "Открыть продукты";
            this.ProductBtn.UseVisualStyleBackColor = false;
            // 
            // MaterialBtn
            // 
            this.MaterialBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.MaterialBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.MaterialBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MaterialBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.MaterialBtn.Location = new System.Drawing.Point(0, 134);
            this.MaterialBtn.Name = "MaterialBtn";
            this.MaterialBtn.Size = new System.Drawing.Size(189, 69);
            this.MaterialBtn.TabIndex = 2;
            this.MaterialBtn.Text = "Открыть материалы";
            this.MaterialBtn.UseVisualStyleBackColor = false;
            // 
            // MasterBtn
            // 
            this.MasterBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.MasterBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.MasterBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MasterBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.MasterBtn.Location = new System.Drawing.Point(0, 65);
            this.MasterBtn.Name = "MasterBtn";
            this.MasterBtn.Size = new System.Drawing.Size(189, 69);
            this.MasterBtn.TabIndex = 1;
            this.MasterBtn.Text = "Открыть мастеров";
            this.MasterBtn.UseVisualStyleBackColor = false;
            // 
            // CompanyBtn
            // 
            this.CompanyBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CompanyBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.CompanyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CompanyBtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.CompanyBtn.Location = new System.Drawing.Point(0, 0);
            this.CompanyBtn.Name = "CompanyBtn";
            this.CompanyBtn.Size = new System.Drawing.Size(189, 65);
            this.CompanyBtn.TabIndex = 0;
            this.CompanyBtn.Text = "Открыть компании";
            this.CompanyBtn.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1016, 596);
            this.Controls.Add(this.panel2);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Text = "Template";
            this.TransparencyKey = System.Drawing.SystemColors.AppWorkspace;
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button CompanyBtn;
        private System.Windows.Forms.Button MasterBtn;
        private System.Windows.Forms.Button MaterialBtn;
        private System.Windows.Forms.Button ProductBtn;
    }
}

