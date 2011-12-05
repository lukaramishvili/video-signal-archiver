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
            this.SuspendLayout();
            // 
            // btnStopAndStart
            // 
            this.btnStopAndStart.Location = new System.Drawing.Point(153, 28);
            this.btnStopAndStart.Name = "btnStopAndStart";
            this.btnStopAndStart.Size = new System.Drawing.Size(75, 23);
            this.btnStopAndStart.TabIndex = 0;
            this.btnStopAndStart.Text = "button1";
            this.btnStopAndStart.UseVisualStyleBackColor = true;
            this.btnStopAndStart.Click += new System.EventHandler(this.btnStopAndStart_Click);
            // 
            // txtNextGadacemaName
            // 
            this.txtNextGadacemaName.Location = new System.Drawing.Point(37, 31);
            this.txtNextGadacemaName.Name = "txtNextGadacemaName";
            this.txtNextGadacemaName.Size = new System.Drawing.Size(100, 20);
            this.txtNextGadacemaName.TabIndex = 1;
            // 
            // RecorderController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 396);
            this.Controls.Add(this.txtNextGadacemaName);
            this.Controls.Add(this.btnStopAndStart);
            this.Name = "RecorderController";
            this.Text = "RecorderController";
            this.Load += new System.EventHandler(this.RecorderController_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStopAndStart;
        private System.Windows.Forms.TextBox txtNextGadacemaName;
    }
}