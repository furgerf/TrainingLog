namespace TrainingLog.Forms
{
    partial class StatisticsForm
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
            this.tabTabs = new System.Windows.Forms.TabControl();
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.efcTrainingType = new TrainingLog.Controls.EnumFilterControl();
            this.efcSport = new TrainingLog.Controls.EnumFilterControl();
            this.dfcTo = new TrainingLog.Controls.DateFilterControl();
            this.dfcFrom = new TrainingLog.Controls.DateFilterControl();
            this.grpGrouping = new System.Windows.Forms.GroupBox();
            this.comGrouping = new System.Windows.Forms.ComboBox();
            this.grpFilter.SuspendLayout();
            this.grpGrouping.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabTabs
            // 
            this.tabTabs.Location = new System.Drawing.Point(12, 63);
            this.tabTabs.Name = "tabTabs";
            this.tabTabs.SelectedIndex = 0;
            this.tabTabs.Size = new System.Drawing.Size(513, 271);
            this.tabTabs.TabIndex = 0;
            // 
            // grpFilter
            // 
            this.grpFilter.Controls.Add(this.efcTrainingType);
            this.grpFilter.Controls.Add(this.efcSport);
            this.grpFilter.Controls.Add(this.dfcTo);
            this.grpFilter.Controls.Add(this.dfcFrom);
            this.grpFilter.Location = new System.Drawing.Point(116, 12);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Size = new System.Drawing.Size(634, 45);
            this.grpFilter.TabIndex = 1;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "Filer";
            // 
            // efcTrainingType
            // 
            this.efcTrainingType.DataFromEntry = null;
            this.efcTrainingType.EnumColumnIndex = 0;
            this.efcTrainingType.Items = null;
            this.efcTrainingType.LabelText = null;
            this.efcTrainingType.Location = new System.Drawing.Point(430, 18);
            this.efcTrainingType.Name = "efcTrainingType";
            this.efcTrainingType.Size = new System.Drawing.Size(150, 21);
            this.efcTrainingType.TabIndex = 3;
            // 
            // efcSport
            // 
            this.efcSport.DataFromEntry = null;
            this.efcSport.EnumColumnIndex = 0;
            this.efcSport.Items = null;
            this.efcSport.LabelText = null;
            this.efcSport.Location = new System.Drawing.Point(274, 18);
            this.efcSport.Name = "efcSport";
            this.efcSport.Size = new System.Drawing.Size(150, 21);
            this.efcSport.TabIndex = 2;
            // 
            // dfcTo
            // 
            this.dfcTo.DateColumnIndex = 0;
            this.dfcTo.IsMaxDate = true;
            this.dfcTo.IsMinDate = false;
            this.dfcTo.Location = new System.Drawing.Point(140, 19);
            this.dfcTo.Name = "dfcTo";
            this.dfcTo.Size = new System.Drawing.Size(128, 20);
            this.dfcTo.TabIndex = 1;
            // 
            // dfcFrom
            // 
            this.dfcFrom.DateColumnIndex = 0;
            this.dfcFrom.IsMaxDate = false;
            this.dfcFrom.IsMinDate = true;
            this.dfcFrom.Location = new System.Drawing.Point(6, 19);
            this.dfcFrom.Name = "dfcFrom";
            this.dfcFrom.Size = new System.Drawing.Size(128, 20);
            this.dfcFrom.TabIndex = 0;
            // 
            // grpGrouping
            // 
            this.grpGrouping.Controls.Add(this.comGrouping);
            this.grpGrouping.Location = new System.Drawing.Point(12, 12);
            this.grpGrouping.Name = "grpGrouping";
            this.grpGrouping.Size = new System.Drawing.Size(98, 45);
            this.grpGrouping.TabIndex = 2;
            this.grpGrouping.TabStop = false;
            this.grpGrouping.Text = "Group";
            // 
            // comGrouping
            // 
            this.comGrouping.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comGrouping.FormattingEnabled = true;
            this.comGrouping.Items.AddRange(new object[] {
            "1 day",
            "2 days",
            "3 days",
            "4 days",
            "5 days",
            "1 week",
            "2 weeks",
            "3 weeks",
            "1 month",
            "2 months",
            "3 months",
            "4 months",
            "5 months",
            "6 months",
            "1 year"});
            this.comGrouping.Location = new System.Drawing.Point(6, 18);
            this.comGrouping.Name = "comGrouping";
            this.comGrouping.Size = new System.Drawing.Size(85, 21);
            this.comGrouping.TabIndex = 0;
            // 
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 445);
            this.Controls.Add(this.grpGrouping);
            this.Controls.Add(this.grpFilter);
            this.Controls.Add(this.tabTabs);
            this.KeyPreview = true;
            this.Name = "StatisticsForm";
            this.Text = "Training Statistics";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StatisticsFormFormClosing);
            this.SizeChanged += new System.EventHandler(this.StatisticsFormSizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StatisticsFormKeyDown);
            this.grpFilter.ResumeLayout(false);
            this.grpGrouping.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabTabs;
        private System.Windows.Forms.GroupBox grpFilter;
        private Controls.DateFilterControl dfcTo;
        private Controls.DateFilterControl dfcFrom;
        private Controls.EnumFilterControl efcSport;
        private Controls.EnumFilterControl efcTrainingType;
        private System.Windows.Forms.GroupBox grpGrouping;
        private System.Windows.Forms.ComboBox comGrouping;
    }
}