﻿namespace CaptureTestConsole
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.tabContainer = new System.Windows.Forms.TabControl();
            this.tab_recorder = new System.Windows.Forms.TabPage();
            this.tab_gadacemebi = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colStartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGadacemisSaxeli = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gpboxAxaliGadacema = new System.Windows.Forms.GroupBox();
            this.lblAxaliGadacema = new System.Windows.Forms.Label();
            this.txtNextGadacemaName = new System.Windows.Forms.TextBox();
            this.btnStopAndStart = new System.Windows.Forms.Button();
            this.green_light = new System.Windows.Forms.PictureBox();
            this.tabContainer.SuspendLayout();
            this.tab_recorder.SuspendLayout();
            this.tab_gadacemebi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.gpboxAxaliGadacema.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.green_light)).BeginInit();
            this.SuspendLayout();
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
            this.tab_recorder.Controls.Add(this.gpboxAxaliGadacema);
            this.tab_recorder.Controls.Add(this.green_light);
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
            // gpboxAxaliGadacema
            // 
            this.gpboxAxaliGadacema.Controls.Add(this.lblAxaliGadacema);
            this.gpboxAxaliGadacema.Controls.Add(this.btnStopAndStart);
            this.gpboxAxaliGadacema.Controls.Add(this.txtNextGadacemaName);
            this.gpboxAxaliGadacema.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpboxAxaliGadacema.Location = new System.Drawing.Point(184, 98);
            this.gpboxAxaliGadacema.Name = "gpboxAxaliGadacema";
            this.gpboxAxaliGadacema.Size = new System.Drawing.Size(292, 149);
            this.gpboxAxaliGadacema.TabIndex = 4;
            this.gpboxAxaliGadacema.TabStop = false;
            this.gpboxAxaliGadacema.Text = "შემდეგი გადაცემის ჩაწერის დაწყება";
            // 
            // lblAxaliGadacema
            // 
            this.lblAxaliGadacema.AutoSize = true;
            this.lblAxaliGadacema.Location = new System.Drawing.Point(6, 44);
            this.lblAxaliGadacema.Name = "lblAxaliGadacema";
            this.lblAxaliGadacema.Size = new System.Drawing.Size(166, 18);
            this.lblAxaliGadacema.TabIndex = 6;
            this.lblAxaliGadacema.Text = "ახალი გადაცემის სახელი";
            // 
            // txtNextGadacemaName
            // 
            this.txtNextGadacemaName.Location = new System.Drawing.Point(9, 75);
            this.txtNextGadacemaName.Name = "txtNextGadacemaName";
            this.txtNextGadacemaName.Size = new System.Drawing.Size(153, 24);
            this.txtNextGadacemaName.TabIndex = 5;
            // 
            // btnStopAndStart
            // 
            this.btnStopAndStart.FlatAppearance.BorderSize = 0;
            this.btnStopAndStart.Image = global::CaptureTestConsole.Properties.Resources.stopplay_mini;
            this.btnStopAndStart.Location = new System.Drawing.Point(203, 44);
            this.btnStopAndStart.Name = "btnStopAndStart";
            this.btnStopAndStart.Size = new System.Drawing.Size(66, 56);
            this.btnStopAndStart.TabIndex = 4;
            this.btnStopAndStart.UseVisualStyleBackColor = true;
            this.btnStopAndStart.Click += new System.EventHandler(this.btnStopAndStart_Click);
            // 
            // green_light
            // 
            this.green_light.Image = global::CaptureTestConsole.Properties.Resources.green_light_still;
            this.green_light.Location = new System.Drawing.Point(47, 132);
            this.green_light.Name = "green_light";
            this.green_light.Size = new System.Drawing.Size(88, 91);
            this.green_light.TabIndex = 2;
            this.green_light.TabStop = false;
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
            this.tabContainer.ResumeLayout(false);
            this.tab_recorder.ResumeLayout(false);
            this.tab_gadacemebi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.gpboxAxaliGadacema.ResumeLayout(false);
            this.gpboxAxaliGadacema.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.green_light)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox green_light;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TabControl tabContainer;
        private System.Windows.Forms.TabPage tab_recorder;
        private System.Windows.Forms.TabPage tab_gadacemebi;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGadacemisSaxeli;
        private System.Windows.Forms.GroupBox gpboxAxaliGadacema;
        private System.Windows.Forms.Label lblAxaliGadacema;
        private System.Windows.Forms.Button btnStopAndStart;
        private System.Windows.Forms.TextBox txtNextGadacemaName;
    }
}