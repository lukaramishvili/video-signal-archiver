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
            this.tabContainer = new System.Windows.Forms.TabControl();
            this.tab_recorder = new System.Windows.Forms.TabPage();
            this.btnChooseCSVFile = new System.Windows.Forms.Button();
            this.lblCSVFile = new System.Windows.Forms.Label();
            this.txtPathToCSV = new System.Windows.Forms.TextBox();
            this.gpboxAxaliGadacema = new System.Windows.Forms.GroupBox();
            this.btn_stop = new System.Windows.Forms.Button();
            this.lblAxaliGadacema = new System.Windows.Forms.Label();
            this.btnStopAndStart = new System.Windows.Forms.Button();
            this.txtNextGadacemaName = new System.Windows.Forms.TextBox();
            this.green_light = new System.Windows.Forms.PictureBox();
            this.dlgChooseCSVFile = new System.Windows.Forms.OpenFileDialog();
            this.tabContainer.SuspendLayout();
            this.tab_recorder.SuspendLayout();
            this.gpboxAxaliGadacema.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.green_light)).BeginInit();
            this.SuspendLayout();
            // 
            // tabContainer
            // 
            this.tabContainer.Controls.Add(this.tab_recorder);
            this.tabContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabContainer.Location = new System.Drawing.Point(0, 0);
            this.tabContainer.Name = "tabContainer";
            this.tabContainer.SelectedIndex = 0;
            this.tabContainer.Size = new System.Drawing.Size(185, 209);
            this.tabContainer.TabIndex = 4;
            // 
            // tab_recorder
            // 
            this.tab_recorder.Controls.Add(this.btnChooseCSVFile);
            this.tab_recorder.Controls.Add(this.lblCSVFile);
            this.tab_recorder.Controls.Add(this.txtPathToCSV);
            this.tab_recorder.Controls.Add(this.gpboxAxaliGadacema);
            this.tab_recorder.Controls.Add(this.green_light);
            this.tab_recorder.Location = new System.Drawing.Point(4, 22);
            this.tab_recorder.Name = "tab_recorder";
            this.tab_recorder.Padding = new System.Windows.Forms.Padding(3);
            this.tab_recorder.Size = new System.Drawing.Size(177, 183);
            this.tab_recorder.TabIndex = 0;
            this.tab_recorder.Text = "ვიდეოსიგნალი";
            this.tab_recorder.UseVisualStyleBackColor = true;
            // 
            // btnChooseCSVFile
            // 
            this.btnChooseCSVFile.Location = new System.Drawing.Point(948, 14);
            this.btnChooseCSVFile.Name = "btnChooseCSVFile";
            this.btnChooseCSVFile.Size = new System.Drawing.Size(75, 23);
            this.btnChooseCSVFile.TabIndex = 10;
            this.btnChooseCSVFile.Text = "არჩევა";
            this.btnChooseCSVFile.UseVisualStyleBackColor = true;
            this.btnChooseCSVFile.Visible = false;
            this.btnChooseCSVFile.Click += new System.EventHandler(this.btnChooseCSVFile_Click);
            // 
            // lblCSVFile
            // 
            this.lblCSVFile.AutoSize = true;
            this.lblCSVFile.Location = new System.Drawing.Point(541, 19);
            this.lblCSVFile.Name = "lblCSVFile";
            this.lblCSVFile.Size = new System.Drawing.Size(119, 13);
            this.lblCSVFile.TabIndex = 9;
            this.lblCSVFile.Text = "CSV ფაილის მისამართი";
            this.lblCSVFile.Visible = false;
            // 
            // txtPathToCSV
            // 
            this.txtPathToCSV.Location = new System.Drawing.Point(678, 16);
            this.txtPathToCSV.Name = "txtPathToCSV";
            this.txtPathToCSV.Size = new System.Drawing.Size(270, 20);
            this.txtPathToCSV.TabIndex = 8;
            this.txtPathToCSV.Visible = false;
            // 
            // gpboxAxaliGadacema
            // 
            this.gpboxAxaliGadacema.Controls.Add(this.btn_stop);
            this.gpboxAxaliGadacema.Controls.Add(this.lblAxaliGadacema);
            this.gpboxAxaliGadacema.Controls.Add(this.btnStopAndStart);
            this.gpboxAxaliGadacema.Controls.Add(this.txtNextGadacemaName);
            this.gpboxAxaliGadacema.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpboxAxaliGadacema.Location = new System.Drawing.Point(184, 98);
            this.gpboxAxaliGadacema.Name = "gpboxAxaliGadacema";
            this.gpboxAxaliGadacema.Size = new System.Drawing.Size(389, 149);
            this.gpboxAxaliGadacema.TabIndex = 4;
            this.gpboxAxaliGadacema.TabStop = false;
            this.gpboxAxaliGadacema.Text = "შემდეგი გადაცემის ჩაწერის დაწყება";
            this.gpboxAxaliGadacema.Visible = false;
            // 
            // btn_stop
            // 
            this.btn_stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_stop.Location = new System.Drawing.Point(276, 44);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(96, 55);
            this.btn_stop.TabIndex = 7;
            this.btn_stop.Text = "Stop";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
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
            // btnStopAndStart
            // 
            this.btnStopAndStart.FlatAppearance.BorderSize = 0;
            this.btnStopAndStart.Image = global::CaptureTestConsole.Properties.Resources.stopplay_mini;
            this.btnStopAndStart.Location = new System.Drawing.Point(188, 43);
            this.btnStopAndStart.Name = "btnStopAndStart";
            this.btnStopAndStart.Size = new System.Drawing.Size(66, 56);
            this.btnStopAndStart.TabIndex = 4;
            this.btnStopAndStart.UseVisualStyleBackColor = true;
            this.btnStopAndStart.Click += new System.EventHandler(this.btnStopAndStart_Click);
            // 
            // txtNextGadacemaName
            // 
            this.txtNextGadacemaName.Location = new System.Drawing.Point(9, 75);
            this.txtNextGadacemaName.Name = "txtNextGadacemaName";
            this.txtNextGadacemaName.Size = new System.Drawing.Size(153, 24);
            this.txtNextGadacemaName.TabIndex = 5;
            // 
            // green_light
            // 
            this.green_light.Image = global::CaptureTestConsole.Properties.Resources.green_light_still;
            this.green_light.Location = new System.Drawing.Point(44, 48);
            this.green_light.Name = "green_light";
            this.green_light.Size = new System.Drawing.Size(88, 91);
            this.green_light.TabIndex = 2;
            this.green_light.TabStop = false;
            // 
            // dlgChooseCSVFile
            // 
            this.dlgChooseCSVFile.DefaultExt = "csv";
            this.dlgChooseCSVFile.FileName = "openFileDialog1";
            this.dlgChooseCSVFile.FileOk += new System.ComponentModel.CancelEventHandler(this.dlgChooseCSVFile_FileOk);
            // 
            // RecorderController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(185, 209);
            this.Controls.Add(this.tabContainer);
            this.Name = "RecorderController";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Video Recorder Controller";
            this.Load += new System.EventHandler(this.RecorderController_Load);
            this.tabContainer.ResumeLayout(false);
            this.tab_recorder.ResumeLayout(false);
            this.tab_recorder.PerformLayout();
            this.gpboxAxaliGadacema.ResumeLayout(false);
            this.gpboxAxaliGadacema.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.green_light)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox green_light;
        private System.Windows.Forms.TabControl tabContainer;
        private System.Windows.Forms.TabPage tab_recorder;
        private System.Windows.Forms.GroupBox gpboxAxaliGadacema;
        private System.Windows.Forms.Label lblAxaliGadacema;
        private System.Windows.Forms.Button btnStopAndStart;
        private System.Windows.Forms.TextBox txtNextGadacemaName;
        private System.Windows.Forms.OpenFileDialog dlgChooseCSVFile;
        private System.Windows.Forms.Button btnChooseCSVFile;
        private System.Windows.Forms.Label lblCSVFile;
        private System.Windows.Forms.TextBox txtPathToCSV;
        private System.Windows.Forms.Button btn_stop;
    }
}