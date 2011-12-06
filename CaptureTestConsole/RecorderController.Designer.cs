namespace CaptureTestConsole
{
    partial class RecorderController
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
            this.btnStopAndStart = new System.Windows.Forms.Button();
            this.txtNextGadacemaName = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.tabContainer = new System.Windows.Forms.TabControl();
            this.tab_recorder = new System.Windows.Forms.TabPage();
            this.tab_gadacemebi = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colStartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGadacemisSaxeli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabContainer.SuspendLayout();
            this.tab_recorder.SuspendLayout();
            this.tab_gadacemebi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStopAndStart
            // 
            this.btnStopAndStart.Location = new System.Drawing.Point(251, 19);
            this.btnStopAndStart.Name = "btnStopAndStart";
            this.btnStopAndStart.Size = new System.Drawing.Size(75, 23);
            this.btnStopAndStart.TabIndex = 0;
            this.btnStopAndStart.Text = "button1";
            this.btnStopAndStart.UseVisualStyleBackColor = true;
            this.btnStopAndStart.Click += new System.EventHandler(this.btnStopAndStart_Click);
            // 
            // txtNextGadacemaName
            // 
            this.txtNextGadacemaName.Location = new System.Drawing.Point(6, 106);
            this.txtNextGadacemaName.Name = "txtNextGadacemaName";
            this.txtNextGadacemaName.Size = new System.Drawing.Size(100, 20);
            this.txtNextGadacemaName.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(6, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(69, 67);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(6, 11);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // tabContainer
            // 
            this.tabContainer.Controls.Add(this.tab_recorder);
            this.tabContainer.Controls.Add(this.tab_gadacemebi);
            this.tabContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabContainer.Location = new System.Drawing.Point(0, 0);
            this.tabContainer.Name = "tabContainer";
            this.tabContainer.SelectedIndex = 0;
            this.tabContainer.Size = new System.Drawing.Size(1044, 623);
            this.tabContainer.TabIndex = 4;
            // 
            // tab_recorder
            // 
            this.tab_recorder.Controls.Add(this.pictureBox1);
            this.tab_recorder.Controls.Add(this.btnStopAndStart);
            this.tab_recorder.Controls.Add(this.txtNextGadacemaName);
            this.tab_recorder.Location = new System.Drawing.Point(4, 22);
            this.tab_recorder.Name = "tab_recorder";
            this.tab_recorder.Padding = new System.Windows.Forms.Padding(3);
            this.tab_recorder.Size = new System.Drawing.Size(1036, 597);
            this.tab_recorder.TabIndex = 0;
            this.tab_recorder.Text = "ვიდეოსიგნალი";
            this.tab_recorder.UseVisualStyleBackColor = true;
            // 
            // tab_gadacemebi
            // 
            this.tab_gadacemebi.Controls.Add(this.dataGridView1);
            this.tab_gadacemebi.Controls.Add(this.dateTimePicker1);
            this.tab_gadacemebi.Location = new System.Drawing.Point(4, 22);
            this.tab_gadacemebi.Name = "tab_gadacemebi";
            this.tab_gadacemebi.Padding = new System.Windows.Forms.Padding(3, 40, 3, 3);
            this.tab_gadacemebi.Size = new System.Drawing.Size(1036, 597);
            this.tab_gadacemebi.TabIndex = 1;
            this.tab_gadacemebi.Text = "გადაცემები";
            this.tab_gadacemebi.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colStartTime,
            this.colEndTime,
            this.colGadacemisSaxeli});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 40);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1030, 554);
            this.dataGridView1.TabIndex = 4;
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
            // RecorderController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 623);
            this.Controls.Add(this.tabContainer);
            this.Name = "RecorderController";
            this.Text = "RecorderController";
            this.Load += new System.EventHandler(this.RecorderController_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabContainer.ResumeLayout(false);
            this.tab_recorder.ResumeLayout(false);
            this.tab_recorder.PerformLayout();
            this.tab_gadacemebi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStopAndStart;
        private System.Windows.Forms.TextBox txtNextGadacemaName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TabControl tabContainer;
        private System.Windows.Forms.TabPage tab_recorder;
        private System.Windows.Forms.TabPage tab_gadacemebi;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGadacemisSaxeli;
    }
}