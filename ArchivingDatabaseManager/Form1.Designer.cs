namespace ArchivingDatabaseManager
{
    partial class frmGadacemebisMartva
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
            this.panel_main = new System.Windows.Forms.Panel();
            this.btnCopyToTomorrow = new System.Windows.Forms.Button();
            this.btnSaveGadacemebiToDatabase = new System.Windows.Forms.Button();
            this.dgvDgisPrograma = new System.Windows.Forms.DataGridView();
            this.colStartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGadacemisSaxeli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOnlyForName = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dttChooseDay = new System.Windows.Forms.DateTimePicker();
            this.btnCopyToNextWeek = new System.Windows.Forms.Button();
            this.panel_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDgisPrograma)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_main
            // 
            this.panel_main.Controls.Add(this.btnCopyToNextWeek);
            this.panel_main.Controls.Add(this.btnCopyToTomorrow);
            this.panel_main.Controls.Add(this.btnSaveGadacemebiToDatabase);
            this.panel_main.Controls.Add(this.dgvDgisPrograma);
            this.panel_main.Controls.Add(this.dttChooseDay);
            this.panel_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_main.Location = new System.Drawing.Point(0, 0);
            this.panel_main.Name = "panel_main";
            this.panel_main.Padding = new System.Windows.Forms.Padding(3, 40, 3, 3);
            this.panel_main.Size = new System.Drawing.Size(812, 558);
            this.panel_main.TabIndex = 0;
            // 
            // btnCopyToTomorrow
            // 
            this.btnCopyToTomorrow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopyToTomorrow.Location = new System.Drawing.Point(386, 9);
            this.btnCopyToTomorrow.Name = "btnCopyToTomorrow";
            this.btnCopyToTomorrow.Size = new System.Drawing.Size(157, 23);
            this.btnCopyToTomorrow.TabIndex = 12;
            this.btnCopyToTomorrow.Text = "ხვალისთვის კოპირება";
            this.btnCopyToTomorrow.UseVisualStyleBackColor = true;
            this.btnCopyToTomorrow.Click += new System.EventHandler(this.btnCopyToTomorrow_Click);
            // 
            // btnSaveGadacemebiToDatabase
            // 
            this.btnSaveGadacemebiToDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveGadacemebiToDatabase.Location = new System.Drawing.Point(213, 9);
            this.btnSaveGadacemebiToDatabase.Name = "btnSaveGadacemebiToDatabase";
            this.btnSaveGadacemebiToDatabase.Size = new System.Drawing.Size(157, 23);
            this.btnSaveGadacemebiToDatabase.TabIndex = 11;
            this.btnSaveGadacemebiToDatabase.Text = "გეგმის დამახსოვრება";
            this.btnSaveGadacemebiToDatabase.UseVisualStyleBackColor = true;
            this.btnSaveGadacemebiToDatabase.Click += new System.EventHandler(this.btnSaveGadacemebiToDatabase_Click);
            // 
            // dgvDgisPrograma
            // 
            this.dgvDgisPrograma.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDgisPrograma.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colStartTime,
            this.colEndTime,
            this.colGadacemisSaxeli,
            this.colOnlyForName});
            this.dgvDgisPrograma.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDgisPrograma.Location = new System.Drawing.Point(3, 40);
            this.dgvDgisPrograma.Name = "dgvDgisPrograma";
            this.dgvDgisPrograma.Size = new System.Drawing.Size(806, 515);
            this.dgvDgisPrograma.TabIndex = 10;
            // 
            // colStartTime
            // 
            this.colStartTime.HeaderText = "დაწყების დრო";
            this.colStartTime.Name = "colStartTime";
            this.colStartTime.Width = 120;
            // 
            // colEndTime
            // 
            this.colEndTime.HeaderText = "დასრულების დრო";
            this.colEndTime.Name = "colEndTime";
            this.colEndTime.Width = 120;
            // 
            // colGadacemisSaxeli
            // 
            this.colGadacemisSaxeli.HeaderText = "გადაცემის სახელი";
            this.colGadacemisSaxeli.Name = "colGadacemisSaxeli";
            this.colGadacemisSaxeli.Width = 250;
            // 
            // colOnlyForName
            // 
            this.colOnlyForName.HeaderText = "გამოიყენება მხოლოდ სახელისთვის";
            this.colOnlyForName.Name = "colOnlyForName";
            this.colOnlyForName.Width = 200;
            // 
            // dttChooseDay
            // 
            this.dttChooseDay.Location = new System.Drawing.Point(6, 11);
            this.dttChooseDay.Name = "dttChooseDay";
            this.dttChooseDay.Size = new System.Drawing.Size(200, 20);
            this.dttChooseDay.TabIndex = 9;
            this.dttChooseDay.ValueChanged += new System.EventHandler(this.dttChooseDay_ValueChanged);
            // 
            // btnCopyToNextWeek
            // 
            this.btnCopyToNextWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopyToNextWeek.Location = new System.Drawing.Point(563, 9);
            this.btnCopyToNextWeek.Name = "btnCopyToNextWeek";
            this.btnCopyToNextWeek.Size = new System.Drawing.Size(179, 23);
            this.btnCopyToNextWeek.TabIndex = 13;
            this.btnCopyToNextWeek.Text = "ერთი კვირისთვის კოპირება";
            this.btnCopyToNextWeek.UseVisualStyleBackColor = true;
            this.btnCopyToNextWeek.Click += new System.EventHandler(this.btnCopyToNextWeek_Click);
            // 
            // frmGadacemebisMartva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 558);
            this.Controls.Add(this.panel_main);
            this.Name = "frmGadacemebisMartva";
            this.Text = "გადაცემების მართვა";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmGadacemebisMartva_Load);
            this.panel_main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDgisPrograma)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_main;
        private System.Windows.Forms.Button btnSaveGadacemebiToDatabase;
        private System.Windows.Forms.DataGridView dgvDgisPrograma;
        private System.Windows.Forms.DateTimePicker dttChooseDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGadacemisSaxeli;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colOnlyForName;
        private System.Windows.Forms.Button btnCopyToTomorrow;
        private System.Windows.Forms.Button btnCopyToNextWeek;
    }
}

