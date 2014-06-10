namespace TrainingLog.Statistics
{
    partial class RunningStatisticsControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea13 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea14 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea15 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.grpTotals = new System.Windows.Forms.GroupBox();
            this.chaTotals = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grpTrainingTypes = new System.Windows.Forms.GroupBox();
            this.chaTrainingTypes = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grpHeartZones = new System.Windows.Forms.GroupBox();
            this.chaHeartZones = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grpTotals.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chaTotals)).BeginInit();
            this.grpTrainingTypes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chaTrainingTypes)).BeginInit();
            this.grpHeartZones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chaHeartZones)).BeginInit();
            this.SuspendLayout();
            // 
            // grpTotals
            // 
            this.grpTotals.Controls.Add(this.chaTotals);
            this.grpTotals.Location = new System.Drawing.Point(0, 0);
            this.grpTotals.Name = "grpTotals";
            this.grpTotals.Size = new System.Drawing.Size(298, 193);
            this.grpTotals.TabIndex = 0;
            this.grpTotals.TabStop = false;
            this.grpTotals.Text = "Running Distance";
            this.grpTotals.Resize += new System.EventHandler(this.GroupBoxResize);
            // 
            // chaTotals
            // 
            chartArea13.Name = "ChartArea1";
            this.chaTotals.ChartAreas.Add(chartArea13);
            this.chaTotals.Location = new System.Drawing.Point(6, 19);
            this.chaTotals.Name = "chaTotals";
            this.chaTotals.Size = new System.Drawing.Size(286, 168);
            this.chaTotals.TabIndex = 0;
            this.chaTotals.Text = "chart1";
            // 
            // grpTrainingTypes
            // 
            this.grpTrainingTypes.Controls.Add(this.chaTrainingTypes);
            this.grpTrainingTypes.Location = new System.Drawing.Point(304, 0);
            this.grpTrainingTypes.Name = "grpTrainingTypes";
            this.grpTrainingTypes.Size = new System.Drawing.Size(148, 193);
            this.grpTrainingTypes.TabIndex = 1;
            this.grpTrainingTypes.TabStop = false;
            this.grpTrainingTypes.Text = "Types of Training";
            this.grpTrainingTypes.Resize += new System.EventHandler(this.GroupBoxResize);
            // 
            // chaTrainingTypes
            // 
            chartArea14.Name = "ChartArea1";
            this.chaTrainingTypes.ChartAreas.Add(chartArea14);
            this.chaTrainingTypes.Location = new System.Drawing.Point(6, 19);
            this.chaTrainingTypes.Name = "chaTrainingTypes";
            this.chaTrainingTypes.Size = new System.Drawing.Size(136, 168);
            this.chaTrainingTypes.TabIndex = 0;
            this.chaTrainingTypes.Text = "chart1";
            // 
            // grpHeartZones
            // 
            this.grpHeartZones.Controls.Add(this.chaHeartZones);
            this.grpHeartZones.Location = new System.Drawing.Point(458, 0);
            this.grpHeartZones.Name = "grpHeartZones";
            this.grpHeartZones.Size = new System.Drawing.Size(148, 193);
            this.grpHeartZones.TabIndex = 2;
            this.grpHeartZones.TabStop = false;
            this.grpHeartZones.Text = "Heart Rate Zones";
            this.grpHeartZones.Resize += new System.EventHandler(this.GroupBoxResize);
            // 
            // chaHeartZones
            // 
            chartArea15.Name = "ChartArea1";
            this.chaHeartZones.ChartAreas.Add(chartArea15);
            this.chaHeartZones.Location = new System.Drawing.Point(6, 19);
            this.chaHeartZones.Name = "chaHeartZones";
            this.chaHeartZones.Size = new System.Drawing.Size(136, 168);
            this.chaHeartZones.TabIndex = 0;
            this.chaHeartZones.Text = "chart2";
            // 
            // RunningStatisticsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpHeartZones);
            this.Controls.Add(this.grpTrainingTypes);
            this.Controls.Add(this.grpTotals);
            this.Name = "RunningStatisticsControl";
            this.Size = new System.Drawing.Size(872, 497);
            this.Resize += new System.EventHandler(this.RunningStatisticsControlResize);
            this.grpTotals.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chaTotals)).EndInit();
            this.grpTrainingTypes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chaTrainingTypes)).EndInit();
            this.grpHeartZones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chaHeartZones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpTotals;
        private System.Windows.Forms.DataVisualization.Charting.Chart chaTotals;
        private System.Windows.Forms.GroupBox grpTrainingTypes;
        private System.Windows.Forms.DataVisualization.Charting.Chart chaTrainingTypes;
        private System.Windows.Forms.GroupBox grpHeartZones;
        private System.Windows.Forms.DataVisualization.Charting.Chart chaHeartZones;
    }
}
