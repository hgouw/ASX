namespace ASX.DataLoader
{
    partial class DataLoaderForm
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
            this.components = new System.ComponentModel.Container();
            this.tmrLog = new System.Windows.Forms.Timer(this.components);
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // tmrLog
            // 
            this.tmrLog.Enabled = true;
            this.tmrLog.Interval = 1000;
            this.tmrLog.Tick += new System.EventHandler(this.tmrLog_Tick);
            // 
            // rtbLog
            // 
            this.rtbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLog.Location = new System.Drawing.Point(0, 0);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(584, 561);
            this.rtbLog.TabIndex = 0;
            this.rtbLog.Text = "";
            // 
            // DataLoaderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.rtbLog);
            this.Name = "DataLoaderForm";
            this.Text = "DataLoaderForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrLog;
        private System.Windows.Forms.RichTextBox rtbLog;
    }
}