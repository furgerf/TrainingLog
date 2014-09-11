namespace TrainingLog.Forms
{
    partial class MainForm
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
            this.butAddTraining = new System.Windows.Forms.Button();
            this.butAddBiodata = new System.Windows.Forms.Button();
            this.butShowLog = new System.Windows.Forms.Button();
            this.butShowStatistics = new System.Windows.Forms.Button();
            this.butSettings = new System.Windows.Forms.Button();
            this.butExit = new System.Windows.Forms.Button();
            this.butManageNonsport = new System.Windows.Forms.Button();
            this.butManageEquipment = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // butAddTraining
            // 
            this.butAddTraining.Location = new System.Drawing.Point(12, 12);
            this.butAddTraining.Name = "butAddTraining";
            this.butAddTraining.Size = new System.Drawing.Size(200, 23);
            this.butAddTraining.TabIndex = 0;
            this.butAddTraining.Text = "Add Training Entry";
            this.butAddTraining.UseVisualStyleBackColor = true;
            this.butAddTraining.Click += new System.EventHandler(this.ButAddTrainingClick);
            // 
            // butAddBiodata
            // 
            this.butAddBiodata.Location = new System.Drawing.Point(12, 41);
            this.butAddBiodata.Name = "butAddBiodata";
            this.butAddBiodata.Size = new System.Drawing.Size(200, 23);
            this.butAddBiodata.TabIndex = 1;
            this.butAddBiodata.Text = "Add Biodata Entry";
            this.butAddBiodata.UseVisualStyleBackColor = true;
            this.butAddBiodata.Click += new System.EventHandler(this.ButAddBiodataClick);
            // 
            // butShowLog
            // 
            this.butShowLog.Location = new System.Drawing.Point(12, 128);
            this.butShowLog.Name = "butShowLog";
            this.butShowLog.Size = new System.Drawing.Size(200, 23);
            this.butShowLog.TabIndex = 4;
            this.butShowLog.Text = "Show Training Log";
            this.butShowLog.UseVisualStyleBackColor = true;
            this.butShowLog.Click += new System.EventHandler(this.ButShowLogClick);
            // 
            // butShowStatistics
            // 
            this.butShowStatistics.Location = new System.Drawing.Point(12, 157);
            this.butShowStatistics.Name = "butShowStatistics";
            this.butShowStatistics.Size = new System.Drawing.Size(200, 23);
            this.butShowStatistics.TabIndex = 5;
            this.butShowStatistics.Text = "Show Statistics";
            this.butShowStatistics.UseVisualStyleBackColor = true;
            this.butShowStatistics.Click += new System.EventHandler(this.ButShowStatisticsClick);
            // 
            // butSettings
            // 
            this.butSettings.Location = new System.Drawing.Point(12, 186);
            this.butSettings.Name = "butSettings";
            this.butSettings.Size = new System.Drawing.Size(200, 23);
            this.butSettings.TabIndex = 6;
            this.butSettings.Text = "Settings";
            this.butSettings.UseVisualStyleBackColor = true;
            this.butSettings.Click += new System.EventHandler(this.ButSettingsClick);
            // 
            // butExit
            // 
            this.butExit.Location = new System.Drawing.Point(12, 215);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(200, 23);
            this.butExit.TabIndex = 7;
            this.butExit.Text = "Exit";
            this.butExit.UseVisualStyleBackColor = true;
            this.butExit.Click += new System.EventHandler(this.ButExitClick);
            // 
            // butManageNonsport
            // 
            this.butManageNonsport.Location = new System.Drawing.Point(12, 70);
            this.butManageNonsport.Name = "butManageNonsport";
            this.butManageNonsport.Size = new System.Drawing.Size(200, 23);
            this.butManageNonsport.TabIndex = 2;
            this.butManageNonsport.Text = "Manage Non-Sport Entries";
            this.butManageNonsport.UseVisualStyleBackColor = true;
            this.butManageNonsport.Click += new System.EventHandler(this.ButManageNonsportClick);
            // 
            // butManageEquipment
            // 
            this.butManageEquipment.Location = new System.Drawing.Point(12, 99);
            this.butManageEquipment.Name = "butManageEquipment";
            this.butManageEquipment.Size = new System.Drawing.Size(200, 23);
            this.butManageEquipment.TabIndex = 3;
            this.butManageEquipment.Text = "Manage Equipment";
            this.butManageEquipment.UseVisualStyleBackColor = true;
            this.butManageEquipment.Click += new System.EventHandler(this.butManageEquipment_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 248);
            this.Controls.Add(this.butManageEquipment);
            this.Controls.Add(this.butManageNonsport);
            this.Controls.Add(this.butExit);
            this.Controls.Add(this.butSettings);
            this.Controls.Add(this.butShowStatistics);
            this.Controls.Add(this.butShowLog);
            this.Controls.Add(this.butAddBiodata);
            this.Controls.Add(this.butAddTraining);
            this.Name = "MainForm";
            this.Text = "Training Diary";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butAddTraining;
        private System.Windows.Forms.Button butAddBiodata;
        private System.Windows.Forms.Button butShowLog;
        private System.Windows.Forms.Button butShowStatistics;
        private System.Windows.Forms.Button butSettings;
        private System.Windows.Forms.Button butExit;
        private System.Windows.Forms.Button butManageNonsport;
        private System.Windows.Forms.Button butManageEquipment;
    }
}

