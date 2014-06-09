namespace TrainingLog.Forms
{
    partial class SettingsForm
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
            this.grpLog = new System.Windows.Forms.GroupBox();
            this.butChangeLogPath = new System.Windows.Forms.Button();
            this.butOpenLog = new System.Windows.Forms.Button();
            this.txtLogPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.butExit = new System.Windows.Forms.Button();
            this.grpLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpLog
            // 
            this.grpLog.Controls.Add(this.butChangeLogPath);
            this.grpLog.Controls.Add(this.butOpenLog);
            this.grpLog.Controls.Add(this.txtLogPath);
            this.grpLog.Controls.Add(this.label1);
            this.grpLog.Location = new System.Drawing.Point(12, 12);
            this.grpLog.Name = "grpLog";
            this.grpLog.Size = new System.Drawing.Size(424, 68);
            this.grpLog.TabIndex = 0;
            this.grpLog.TabStop = false;
            this.grpLog.Text = "Log";
            // 
            // butChangeLogPath
            // 
            this.butChangeLogPath.Location = new System.Drawing.Point(343, 39);
            this.butChangeLogPath.Name = "butChangeLogPath";
            this.butChangeLogPath.Size = new System.Drawing.Size(75, 23);
            this.butChangeLogPath.TabIndex = 4;
            this.butChangeLogPath.Text = "Change...";
            this.butChangeLogPath.UseVisualStyleBackColor = true;
            this.butChangeLogPath.Click += new System.EventHandler(this.ButChangeLogPathClick);
            // 
            // butOpenLog
            // 
            this.butOpenLog.Location = new System.Drawing.Point(6, 39);
            this.butOpenLog.Name = "butOpenLog";
            this.butOpenLog.Size = new System.Drawing.Size(75, 23);
            this.butOpenLog.TabIndex = 2;
            this.butOpenLog.Text = "Open Log";
            this.butOpenLog.UseVisualStyleBackColor = true;
            this.butOpenLog.Click += new System.EventHandler(this.ButOpenLogClick);
            // 
            // txtLogPath
            // 
            this.txtLogPath.Enabled = false;
            this.txtLogPath.Location = new System.Drawing.Point(44, 13);
            this.txtLogPath.Name = "txtLogPath";
            this.txtLogPath.Size = new System.Drawing.Size(374, 20);
            this.txtLogPath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Path:";
            // 
            // butExit
            // 
            this.butExit.Location = new System.Drawing.Point(89, 160);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(75, 23);
            this.butExit.TabIndex = 1;
            this.butExit.Text = "Exit";
            this.butExit.UseVisualStyleBackColor = true;
            this.butExit.Click += new System.EventHandler(this.ButExitClick);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 318);
            this.Controls.Add(this.butExit);
            this.Controls.Add(this.grpLog);
            this.KeyPreview = true;
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsFormFormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SettingsFormKeyDown);
            this.grpLog.ResumeLayout(false);
            this.grpLog.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpLog;
        private System.Windows.Forms.Button butChangeLogPath;
        private System.Windows.Forms.Button butOpenLog;
        private System.Windows.Forms.TextBox txtLogPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butExit;
    }
}