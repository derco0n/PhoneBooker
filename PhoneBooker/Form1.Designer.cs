namespace PhoneBooker
{
    partial class PhoneBooker
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpDevice = new System.Windows.Forms.GroupBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblPort = new System.Windows.Forms.Label();
            this.cboPort = new System.Windows.Forms.ComboBox();
            this.grpJobs = new System.Windows.Forms.GroupBox();
            this.rdbWritePB = new System.Windows.Forms.RadioButton();
            this.rdbReadPB = new System.Windows.Forms.RadioButton();
            this.btnRun = new System.Windows.Forms.Button();
            this.grpData = new System.Windows.Forms.GroupBox();
            this.lstEntries = new System.Windows.Forms.ListBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.grpDevice.SuspendLayout();
            this.grpJobs.SuspendLayout();
            this.grpData.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpDevice
            // 
            this.grpDevice.Controls.Add(this.btnConnect);
            this.grpDevice.Controls.Add(this.lblPort);
            this.grpDevice.Controls.Add(this.cboPort);
            this.grpDevice.Location = new System.Drawing.Point(13, 13);
            this.grpDevice.Name = "grpDevice";
            this.grpDevice.Size = new System.Drawing.Size(254, 461);
            this.grpDevice.TabIndex = 0;
            this.grpDevice.TabStop = false;
            this.grpDevice.Text = "Gerät";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(167, 43);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Verbinden";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(6, 19);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(64, 13);
            this.lblPort.TabIndex = 1;
            this.lblPort.Text = "Schnittstelle";
            // 
            // cboPort
            // 
            this.cboPort.FormattingEnabled = true;
            this.cboPort.Location = new System.Drawing.Point(76, 16);
            this.cboPort.Name = "cboPort";
            this.cboPort.Size = new System.Drawing.Size(166, 21);
            this.cboPort.TabIndex = 0;
            // 
            // grpJobs
            // 
            this.grpJobs.Controls.Add(this.rdbWritePB);
            this.grpJobs.Controls.Add(this.rdbReadPB);
            this.grpJobs.Controls.Add(this.btnRun);
            this.grpJobs.Enabled = false;
            this.grpJobs.Location = new System.Drawing.Point(273, 13);
            this.grpJobs.Name = "grpJobs";
            this.grpJobs.Size = new System.Drawing.Size(158, 97);
            this.grpJobs.TabIndex = 3;
            this.grpJobs.TabStop = false;
            this.grpJobs.Text = "Aufgaben";
            // 
            // rdbWritePB
            // 
            this.rdbWritePB.AutoSize = true;
            this.rdbWritePB.Location = new System.Drawing.Point(7, 39);
            this.rdbWritePB.Name = "rdbWritePB";
            this.rdbWritePB.Size = new System.Drawing.Size(134, 17);
            this.rdbWritePB.TabIndex = 4;
            this.rdbWritePB.TabStop = true;
            this.rdbWritePB.Text = "Telefonbuch schreiben";
            this.rdbWritePB.UseVisualStyleBackColor = true;
            // 
            // rdbReadPB
            // 
            this.rdbReadPB.AutoSize = true;
            this.rdbReadPB.Location = new System.Drawing.Point(7, 16);
            this.rdbReadPB.Name = "rdbReadPB";
            this.rdbReadPB.Size = new System.Drawing.Size(130, 17);
            this.rdbReadPB.TabIndex = 3;
            this.rdbReadPB.TabStop = true;
            this.rdbReadPB.Text = "Telefonbuch auslesen";
            this.rdbReadPB.UseVisualStyleBackColor = true;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(7, 62);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 2;
            this.btnRun.Text = "Ausführen";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // grpData
            // 
            this.grpData.Controls.Add(this.lstEntries);
            this.grpData.Location = new System.Drawing.Point(660, 12);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(433, 537);
            this.grpData.TabIndex = 4;
            this.grpData.TabStop = false;
            this.grpData.Text = "Daten";
            // 
            // lstEntries
            // 
            this.lstEntries.FormattingEnabled = true;
            this.lstEntries.Location = new System.Drawing.Point(6, 16);
            this.lstEntries.Name = "lstEntries";
            this.lstEntries.Size = new System.Drawing.Size(427, 485);
            this.lstEntries.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 549);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1105, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar1.Visible = false;
            this.toolStripProgressBar1.Click += new System.EventHandler(this.toolStripProgressBar1_Click);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Visible = false;
            // 
            // PhoneBooker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 571);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.grpData);
            this.Controls.Add(this.grpJobs);
            this.Controls.Add(this.grpDevice);
            this.Name = "PhoneBooker";
            this.Text = "PhoneBooker";
            this.Load += new System.EventHandler(this.PhoneBooker_Load);
            this.grpDevice.ResumeLayout(false);
            this.grpDevice.PerformLayout();
            this.grpJobs.ResumeLayout(false);
            this.grpJobs.PerformLayout();
            this.grpData.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpDevice;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.ComboBox cboPort;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.GroupBox grpJobs;
        private System.Windows.Forms.RadioButton rdbWritePB;
        private System.Windows.Forms.RadioButton rdbReadPB;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.GroupBox grpData;
        private System.Windows.Forms.ListBox lstEntries;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}

