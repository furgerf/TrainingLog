namespace TrainingLog.Forms
{
    partial class TrainingLogForm
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
            this.grpMain = new System.Windows.Forms.GroupBox();
            this.chkUnified = new System.Windows.Forms.CheckBox();
            this.chkRace = new System.Windows.Forms.CheckBox();
            this.chkBiodata = new System.Windows.Forms.CheckBox();
            this.chkTraining = new System.Windows.Forms.CheckBox();
            this.butClose = new System.Windows.Forms.Button();
            this.grpMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpMain
            // 
            this.grpMain.Controls.Add(this.chkUnified);
            this.grpMain.Controls.Add(this.chkRace);
            this.grpMain.Controls.Add(this.chkBiodata);
            this.grpMain.Controls.Add(this.chkTraining);
            this.grpMain.Location = new System.Drawing.Point(12, 12);
            this.grpMain.Name = "grpMain";
            this.grpMain.Size = new System.Drawing.Size(271, 90);
            this.grpMain.TabIndex = 1;
            this.grpMain.TabStop = false;
            this.grpMain.Text = "Select data to display";
            // 
            // chkUnified
            // 
            this.chkUnified.AutoSize = true;
            this.chkUnified.Location = new System.Drawing.Point(136, 19);
            this.chkUnified.Name = "chkUnified";
            this.chkUnified.Size = new System.Drawing.Size(129, 17);
            this.chkUnified.TabIndex = 3;
            this.chkUnified.Text = "Show entries together";
            this.chkUnified.UseVisualStyleBackColor = true;
            this.chkUnified.CheckedChanged += new System.EventHandler(this.EntrySelectionChanged);
            // 
            // chkRace
            // 
            this.chkRace.AutoSize = true;
            this.chkRace.Location = new System.Drawing.Point(6, 65);
            this.chkRace.Name = "chkRace";
            this.chkRace.Size = new System.Drawing.Size(52, 17);
            this.chkRace.TabIndex = 2;
            this.chkRace.Text = "Race";
            this.chkRace.UseVisualStyleBackColor = true;
            this.chkRace.CheckedChanged += new System.EventHandler(this.EntrySelectionChanged);
            // 
            // chkBiodata
            // 
            this.chkBiodata.AutoSize = true;
            this.chkBiodata.Location = new System.Drawing.Point(6, 42);
            this.chkBiodata.Name = "chkBiodata";
            this.chkBiodata.Size = new System.Drawing.Size(67, 17);
            this.chkBiodata.TabIndex = 1;
            this.chkBiodata.Text = "Bio Data";
            this.chkBiodata.UseVisualStyleBackColor = true;
            this.chkBiodata.CheckedChanged += new System.EventHandler(this.EntrySelectionChanged);
            // 
            // chkTraining
            // 
            this.chkTraining.AutoSize = true;
            this.chkTraining.Location = new System.Drawing.Point(6, 19);
            this.chkTraining.Name = "chkTraining";
            this.chkTraining.Size = new System.Drawing.Size(64, 17);
            this.chkTraining.TabIndex = 0;
            this.chkTraining.Text = "Training";
            this.chkTraining.UseVisualStyleBackColor = true;
            this.chkTraining.CheckedChanged += new System.EventHandler(this.EntrySelectionChanged);
            // 
            // butClose
            // 
            this.butClose.Location = new System.Drawing.Point(289, 48);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(75, 23);
            this.butClose.TabIndex = 2;
            this.butClose.Text = "Close";
            this.butClose.UseVisualStyleBackColor = true;
            this.butClose.Click += new System.EventHandler(this.ButCloseClick);
            // 
            // TrainingLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 595);
            this.Controls.Add(this.butClose);
            this.Controls.Add(this.grpMain);
            this.KeyPreview = true;
            this.Name = "TrainingLogForm";
            this.Text = "Training Log";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TrainingLogFormFormClosing);
            this.SizeChanged += new System.EventHandler(this.TrainingLogFormSizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TrainingLogFormKeyDown);
            this.grpMain.ResumeLayout(false);
            this.grpMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMain;
        private System.Windows.Forms.CheckBox chkUnified;
        private System.Windows.Forms.CheckBox chkRace;
        private System.Windows.Forms.CheckBox chkBiodata;
        private System.Windows.Forms.CheckBox chkTraining;
        private System.Windows.Forms.Button butClose;
    }
}