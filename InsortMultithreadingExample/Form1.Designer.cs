namespace InsortMultithreadingExample
{
    partial class Insort
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
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.cbPause = new System.Windows.Forms.CheckBox();
            this.nudAcquisitionTime = new System.Windows.Forms.NumericUpDown();
            this.tbReport = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbLiveData = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudAcquisitionTime)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(38, 33);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(138, 33);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // cbPause
            // 
            this.cbPause.AutoSize = true;
            this.cbPause.Location = new System.Drawing.Point(38, 76);
            this.cbPause.Name = "cbPause";
            this.cbPause.Size = new System.Drawing.Size(56, 17);
            this.cbPause.TabIndex = 2;
            this.cbPause.Text = "Pause";
            this.cbPause.UseVisualStyleBackColor = true;
            this.cbPause.CheckedChanged += new System.EventHandler(this.cbPause_CheckedChanged);
            // 
            // nudAcquisitionTime
            // 
            this.nudAcquisitionTime.Location = new System.Drawing.Point(138, 76);
            this.nudAcquisitionTime.Name = "nudAcquisitionTime";
            this.nudAcquisitionTime.Size = new System.Drawing.Size(56, 20);
            this.nudAcquisitionTime.TabIndex = 3;
            this.nudAcquisitionTime.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // tbReport
            // 
            this.tbReport.Location = new System.Drawing.Point(38, 118);
            this.tbReport.Multiline = true;
            this.tbReport.Name = "tbReport";
            this.tbReport.Size = new System.Drawing.Size(222, 272);
            this.tbReport.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 411);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Processed objects:";
            // 
            // lbLiveData
            // 
            this.lbLiveData.Location = new System.Drawing.Point(115, 411);
            this.lbLiveData.Name = "lbLiveData";
            this.lbLiveData.Size = new System.Drawing.Size(179, 13);
            this.lbLiveData.TabIndex = 6;
            this.lbLiveData.Text = "0";
            // 
            // Insort
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 433);
            this.Controls.Add(this.lbLiveData);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbReport);
            this.Controls.Add(this.nudAcquisitionTime);
            this.Controls.Add(this.cbPause);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Name = "Insort";
            this.Text = "Insort Example";
            ((System.ComponentModel.ISupportInitialize)(this.nudAcquisitionTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.CheckBox cbPause;
        private System.Windows.Forms.NumericUpDown nudAcquisitionTime;
        private System.Windows.Forms.TextBox tbReport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbLiveData;
    }
}

