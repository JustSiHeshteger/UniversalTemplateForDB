
namespace UniversalTemplateForDB.Views.Forms
{
    partial class ProductView
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Main = new System.Windows.Forms.TabPage();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.SearchTB = new System.Windows.Forms.TextBox();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.EditBtn = new System.Windows.Forms.Button();
            this.AddBtn = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.Info = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.InfoTB = new System.Windows.Forms.TextBox();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.IdMasterTB = new System.Windows.Forms.TextBox();
            this.NameTB = new System.Windows.Forms.TextBox();
            this.IdCompanyTB = new System.Windows.Forms.TextBox();
            this.IDTB = new System.Windows.Forms.TextBox();
            this.asd = new System.Windows.Forms.Label();
            this.NameColumn = new System.Windows.Forms.TextBox();
            this.DeleteColumnBtn = new System.Windows.Forms.Button();
            this.AddColumnBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.Info.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(838, 78);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(358, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Продукция";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Main);
            this.tabControl1.Controls.Add(this.Info);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 78);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(838, 398);
            this.tabControl1.TabIndex = 1;
            // 
            // Main
            // 
            this.Main.Controls.Add(this.dataGridView);
            this.Main.Controls.Add(this.panel3);
            this.Main.Controls.Add(this.panel2);
            this.Main.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Main.Location = new System.Drawing.Point(4, 22);
            this.Main.Name = "Main";
            this.Main.Padding = new System.Windows.Forms.Padding(3);
            this.Main.Size = new System.Drawing.Size(830, 372);
            this.Main.TabIndex = 0;
            this.Main.Text = "Список продуктов";
            this.Main.UseVisualStyleBackColor = true;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(3, 33);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(624, 336);
            this.dataGridView.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DimGray;
            this.panel3.Controls.Add(this.SearchTB);
            this.panel3.Controls.Add(this.SearchBtn);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(10, 5, 0, 0);
            this.panel3.Size = new System.Drawing.Size(624, 30);
            this.panel3.TabIndex = 2;
            // 
            // SearchTB
            // 
            this.SearchTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchTB.Location = new System.Drawing.Point(58, 5);
            this.SearchTB.Name = "SearchTB";
            this.SearchTB.Size = new System.Drawing.Size(491, 22);
            this.SearchTB.TabIndex = 3;
            // 
            // SearchBtn
            // 
            this.SearchBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.SearchBtn.Location = new System.Drawing.Point(549, 5);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(75, 25);
            this.SearchBtn.TabIndex = 2;
            this.SearchBtn.Text = "Найти";
            this.SearchBtn.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(10, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Поиск";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DimGray;
            this.panel2.Controls.Add(this.asd);
            this.panel2.Controls.Add(this.NameColumn);
            this.panel2.Controls.Add(this.DeleteColumnBtn);
            this.panel2.Controls.Add(this.AddColumnBtn);
            this.panel2.Controls.Add(this.DeleteBtn);
            this.panel2.Controls.Add(this.EditBtn);
            this.panel2.Controls.Add(this.AddBtn);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(627, 3);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10, 10, 10, 50);
            this.panel2.Size = new System.Drawing.Size(200, 366);
            this.panel2.TabIndex = 0;
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.DeleteBtn.Location = new System.Drawing.Point(10, 136);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(180, 40);
            this.DeleteBtn.TabIndex = 4;
            this.DeleteBtn.Text = "Удалить";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            // 
            // EditBtn
            // 
            this.EditBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.EditBtn.Location = new System.Drawing.Point(10, 96);
            this.EditBtn.Name = "EditBtn";
            this.EditBtn.Size = new System.Drawing.Size(180, 40);
            this.EditBtn.TabIndex = 3;
            this.EditBtn.Text = "Редактировать";
            this.EditBtn.UseVisualStyleBackColor = true;
            // 
            // AddBtn
            // 
            this.AddBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.AddBtn.Location = new System.Drawing.Point(10, 56);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(180, 40);
            this.AddBtn.TabIndex = 2;
            this.AddBtn.Text = "Добавить";
            this.AddBtn.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(10, 10);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(180, 46);
            this.panel4.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(46, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Команды";
            // 
            // Info
            // 
            this.Info.BackColor = System.Drawing.Color.DimGray;
            this.Info.Controls.Add(this.label8);
            this.Info.Controls.Add(this.InfoTB);
            this.Info.Controls.Add(this.CancelBtn);
            this.Info.Controls.Add(this.SaveBtn);
            this.Info.Controls.Add(this.label7);
            this.Info.Controls.Add(this.label6);
            this.Info.Controls.Add(this.label5);
            this.Info.Controls.Add(this.label4);
            this.Info.Controls.Add(this.IdMasterTB);
            this.Info.Controls.Add(this.NameTB);
            this.Info.Controls.Add(this.IdCompanyTB);
            this.Info.Controls.Add(this.IDTB);
            this.Info.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Info.Location = new System.Drawing.Point(4, 22);
            this.Info.Name = "Info";
            this.Info.Padding = new System.Windows.Forms.Padding(3);
            this.Info.Size = new System.Drawing.Size(830, 372);
            this.Info.TabIndex = 1;
            this.Info.Text = "Подробности";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label8.Location = new System.Drawing.Point(650, 86);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 16);
            this.label8.TabIndex = 11;
            this.label8.Text = "Информация";
            // 
            // InfoTB
            // 
            this.InfoTB.Location = new System.Drawing.Point(601, 106);
            this.InfoTB.Multiline = true;
            this.InfoTB.Name = "InfoTB";
            this.InfoTB.Size = new System.Drawing.Size(207, 131);
            this.InfoTB.TabIndex = 10;
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(379, 289);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(110, 49);
            this.CancelBtn.TabIndex = 9;
            this.CancelBtn.Text = "Отменить";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(74, 289);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(110, 49);
            this.SaveBtn.TabIndex = 8;
            this.SaveBtn.Text = "Сохранить";
            this.SaveBtn.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.Location = new System.Drawing.Point(392, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "Название";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Location = new System.Drawing.Point(90, 196);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Id мастера";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(392, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Id компании";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(114, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "ID";
            // 
            // IdMasterTB
            // 
            this.IdMasterTB.Location = new System.Drawing.Point(54, 215);
            this.IdMasterTB.Name = "IdMasterTB";
            this.IdMasterTB.Size = new System.Drawing.Size(147, 22);
            this.IdMasterTB.TabIndex = 3;
            // 
            // NameTB
            // 
            this.NameTB.Location = new System.Drawing.Point(359, 105);
            this.NameTB.Name = "NameTB";
            this.NameTB.Size = new System.Drawing.Size(147, 22);
            this.NameTB.TabIndex = 2;
            // 
            // IdCompanyTB
            // 
            this.IdCompanyTB.Location = new System.Drawing.Point(359, 215);
            this.IdCompanyTB.Name = "IdCompanyTB";
            this.IdCompanyTB.Size = new System.Drawing.Size(147, 22);
            this.IdCompanyTB.TabIndex = 1;
            // 
            // IDTB
            // 
            this.IDTB.Location = new System.Drawing.Point(54, 105);
            this.IDTB.Name = "IDTB";
            this.IDTB.ReadOnly = true;
            this.IDTB.Size = new System.Drawing.Size(147, 22);
            this.IDTB.TabIndex = 0;
            // 
            // asd
            // 
            this.asd.AutoSize = true;
            this.asd.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.asd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.asd.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.asd.Location = new System.Drawing.Point(10, 274);
            this.asd.Name = "asd";
            this.asd.Size = new System.Drawing.Size(155, 20);
            this.asd.TabIndex = 16;
            this.asd.Text = "Название стобца";
            // 
            // NameColumn
            // 
            this.NameColumn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.NameColumn.Location = new System.Drawing.Point(10, 294);
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.Size = new System.Drawing.Size(180, 22);
            this.NameColumn.TabIndex = 19;
            // 
            // DeleteColumnBtn
            // 
            this.DeleteColumnBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.DeleteColumnBtn.Location = new System.Drawing.Point(10, 216);
            this.DeleteColumnBtn.Name = "DeleteColumnBtn";
            this.DeleteColumnBtn.Size = new System.Drawing.Size(180, 40);
            this.DeleteColumnBtn.TabIndex = 18;
            this.DeleteColumnBtn.Text = "Удалить столбец";
            this.DeleteColumnBtn.UseVisualStyleBackColor = true;
            // 
            // AddColumnBtn
            // 
            this.AddColumnBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.AddColumnBtn.Location = new System.Drawing.Point(10, 176);
            this.AddColumnBtn.Name = "AddColumnBtn";
            this.AddColumnBtn.Size = new System.Drawing.Size(180, 40);
            this.AddColumnBtn.TabIndex = 17;
            this.AddColumnBtn.Text = "Добавить столбец";
            this.AddColumnBtn.UseVisualStyleBackColor = true;
            // 
            // ProductView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(53)))), ((int)(((byte)(185)))));
            this.ClientSize = new System.Drawing.Size(838, 476);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "ProductView";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.Main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.Info.ResumeLayout(false);
            this.Info.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Main;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabPage Info;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox SearchTB;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.Button EditBtn;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox IdMasterTB;
        private System.Windows.Forms.TextBox NameTB;
        private System.Windows.Forms.TextBox IdCompanyTB;
        private System.Windows.Forms.TextBox IDTB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox InfoTB;
        private System.Windows.Forms.Label asd;
        private System.Windows.Forms.TextBox NameColumn;
        private System.Windows.Forms.Button DeleteColumnBtn;
        private System.Windows.Forms.Button AddColumnBtn;
    }
}