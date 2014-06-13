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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea11 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea12 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea13 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea14 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea15 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.grpTotals = new System.Windows.Forms.GroupBox();
            this.chaTotals = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grpTrainingTypes = new System.Windows.Forms.GroupBox();
            this.chaTrainingTypes = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grpHeartZones = new System.Windows.Forms.GroupBox();
            this.chaHeartZones = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grpMonthlyTrainingTypes = new System.Windows.Forms.GroupBox();
            this.chaMonthlyTrainingTypes = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grpMonthlyHeartZones = new System.Windows.Forms.GroupBox();
            this.chaMonthlyHeartZones = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grpTotals.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chaTotals)).BeginInit();
            this.grpTrainingTypes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chaTrainingTypes)).BeginInit();
            this.grpHeartZones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chaHeartZones)).BeginInit();
            this.grpMonthlyTrainingTypes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chaMonthlyTrainingTypes)).BeginInit();
            this.grpMonthlyHeartZones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chaMonthlyHeartZones)).BeginInit();
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
            chartArea11.Name = "ChartArea1";
            this.chaTotals.ChartAreas.Add(chartArea11);
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
            chartArea12.Name = "ChartArea1";
            this.chaTrainingTypes.ChartAreas.Add(chartArea12);
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
            chartArea13.Name = "ChartArea1";
            this.chaHeartZones.ChartAreas.Add(chartArea13);
            this.chaHeartZones.Location = new System.Drawing.Point(6, 19);
            this.chaHeartZones.Name = "chaHeartZones";
            this.chaHeartZones.Size = new System.Drawing.Size(136, 168);
            this.chaHeartZones.TabIndex = 0;
            this.chaHeartZones.Text = "chart2";
            // 
            // grpMonthlyTrainingTypes
            // 
            this.grpMonthlyTrainingTypes.Controls.Add(this.chaMonthlyTrainingTypes);
            this.grpMonthlyTrainingTypes.Location = new System.Drawing.Point(304, 199);
            this.grpMonthlyTrainingTypes.Name = "grpMonthlyTrainingTypes";
            this.grpMonthlyTrainingTypes.Size = new System.Drawing.Size(148, 193);
            this.grpMonthlyTrainingTypes.TabIndex = 3;
            this.grpMonthlyTrainingTypes.TabStop = false;
            this.grpMonthlyTrainingTypes.Text = "Monthly Training Types";
            this.grpMonthlyTrainingTypes.Resize += new System.EventHandler(this.GroupBoxResize);
            // 
            // chaMonthlyTrainingTypes
            // 
            chartArea14.Name = "ChartArea1";
            this.chaMonthlyTrainingTypes.ChartAreas.Add(chartArea14);
            this.chaMonthlyTrainingTypes.Location = new System.Drawing.Point(6, 19);
            this.chaMonthlyTrainingTypes.Name = "chaMonthlyTrainingTypes";
            this.chaMonthlyTrainingTypes.Size = new System.Drawing.Size(136, 168);
            this.chaMonthlyTrainingTypes.TabIndex = 0;
            this.chaMonthlyTrainingTypes.Text = "chart2";
            // 
            // grpMonthlyHeartZones
            // 
            this.grpMonthlyHeartZones.Controls.Add(this.chaMonthlyHeartZones);
            this.grpMonthlyHeartZones.Location = new System.Drawing.Point(458, 199);
            this.grpMonthlyHeartZones.Name = "grpMonthlyHeartZones";
            this.grpMonthlyHeartZones.Size = new System.Drawing.Size(148, 193);
            this.grpMonthlyHeartZones.TabIndex = 4;
            this.grpMonthlyHeartZones.TabStop = false;
            this.grpMonthlyHeartZones.Text = "Monthly Heart Rate Zones";
            this.grpMonthlyHeartZones.Resize += new System.EventHandler(this.GroupBoxResize);
            // 
            // chaMonthlyHeartZones
            // 
            chartArea15.Name = "ChartArea1";
            this.chaMonthlyHeartZones.ChartAreas.Add(chartArea15);
            this.chaMonthlyHeartZones.Location = new System.Drawing.Point(6, 19);
            this.chaMonthlyHeartZones.Name = "chaMonthlyHeartZones";
            this.chaMonthlyHeartZones.Size = new System.Drawing.Size(136, 168);
            this.chaMonthlyHeartZones.TabIndex = 0;
            this.chaMonthlyHeartZones.Text = "chart2";
            // 
            // RunningStatisticsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpMonthlyHeartZones);
            this.Controls.Add(this.grpMonthlyTrainingTypes);
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
            this.grpMonthlyTrainingTypes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chaMonthlyTrainingTypes)).EndInit();
            this.grpMonthlyHeartZones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chaMonthlyHeartZones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpTotals;
        private System.Windows.Forms.DataVisualization.Charting.Chart chaTotals;
        private System.Windows.Forms.GroupBox grpTrainingTypes;
        private System.Windows.Forms.DataVisualization.Charting.Chart chaTrainingTypes;
        private System.Windows.Forms.GroupBox grpHeartZones;
        private System.Windows.Forms.DataVisualization.Charting.Chart chaHeartZones;
        private System.Windows.Forms.GroupBox grpMonthlyTrainingTypes;
        private System.Windows.Forms.DataVisualization.Charting.Chart chaMonthlyTrainingTypes;
        private System.Windows.Forms.GroupBox grpMonthlyHeartZones;
        private System.Windows.Forms.DataVisualization.Charting.Chart chaMonthlyHeartZones;
    }
}
