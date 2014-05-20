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
            this.dfcTo = new TrainingLog.Controls.DateFilterControl();
            this.dfcFrom = new TrainingLog.Controls.DateFilterControl();
            this.grpFilter.SuspendLayout();
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
            this.grpFilter.Controls.Add(this.dfcTo);
            this.grpFilter.Controls.Add(this.dfcFrom);
            this.grpFilter.Location = new System.Drawing.Point(12, 12);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Size = new System.Drawing.Size(513, 45);
            this.grpFilter.TabIndex = 1;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "Filer";
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
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 445);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabTabs;
        private System.Windows.Forms.GroupBox grpFilter;
        private Controls.DateFilterControl dfcTo;
        private Controls.DateFilterControl dfcFrom;
    }
}