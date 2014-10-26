namespace TrainingLog.Controls
{
    partial class RunningRaceEntryControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtExactTime = new TrainingLog.Controls.TimeSpanTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtExactDistanceKm = new TrainingLog.Controls.DecimalTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numOverallRank = new System.Windows.Forms.NumericUpDown();
            this.numAgeGroupRank = new System.Windows.Forms.NumericUpDown();
            this.comCompetition = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRaceAverageHr = new TrainingLog.Controls.IntegerTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numOverallRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAgeGroupRank)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Exact Time:";
            // 
            // txtExactTime
            // 
            this.txtExactTime.BackColor = System.Drawing.Color.White;
            this.txtExactTime.Location = new System.Drawing.Point(88, 0);
            this.txtExactTime.Name = "txtExactTime";
            this.txtExactTime.Size = new System.Drawing.Size(62, 20);
            this.txtExactTime.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(156, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "[h:] min:s";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Exact Distance:";
            // 
            // txtExactDistanceKm
            // 
            this.txtExactDistanceKm.BackColor = System.Drawing.Color.White;
            this.txtExactDistanceKm.Location = new System.Drawing.Point(88, 26);
            this.txtExactDistanceKm.Name = "txtExactDistanceKm";
            this.txtExactDistanceKm.Size = new System.Drawing.Size(62, 20);
            this.txtExactDistanceKm.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(156, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "km";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Overall Rank:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(0, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Age Group Rank:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(0, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Competition:";
            // 
            // numOverallRank
            // 
            this.numOverallRank.Location = new System.Drawing.Point(88, 78);
            this.numOverallRank.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numOverallRank.Name = "numOverallRank";
            this.numOverallRank.Size = new System.Drawing.Size(117, 20);
            this.numOverallRank.TabIndex = 16;
            // 
            // numAgeGroupRank
            // 
            this.numAgeGroupRank.Location = new System.Drawing.Point(88, 104);
            this.numAgeGroupRank.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numAgeGroupRank.Name = "numAgeGroupRank";
            this.numAgeGroupRank.Size = new System.Drawing.Size(117, 20);
            this.numAgeGroupRank.TabIndex = 17;
            // 
            // comCompetition
            // 
            this.comCompetition.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comCompetition.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comCompetition.FormattingEnabled = true;
            this.comCompetition.Location = new System.Drawing.Point(88, 130);
            this.comCompetition.Name = "comCompetition";
            this.comCompetition.Size = new System.Drawing.Size(117, 21);
            this.comCompetition.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(0, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Avg. Race HR:";
            // 
            // txtRaceAverageHr
            // 
            this.txtRaceAverageHr.BackColor = System.Drawing.Color.White;
            this.txtRaceAverageHr.Location = new System.Drawing.Point(88, 52);
            this.txtRaceAverageHr.Name = "txtRaceAverageHr";
            this.txtRaceAverageHr.Size = new System.Drawing.Size(117, 20);
            this.txtRaceAverageHr.TabIndex = 20;
            // 
            // RunningRaceEntryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtRaceAverageHr);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comCompetition);
            this.Controls.Add(this.numAgeGroupRank);
            this.Controls.Add(this.numOverallRank);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtExactDistanceKm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtExactTime);
            this.Controls.Add(this.label1);
            this.Name = "RunningRaceEntryControl";
            this.Size = new System.Drawing.Size(205, 151);
            ((System.ComponentModel.ISupportInitialize)(this.numOverallRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAgeGroupRank)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private TimeSpanTextBox txtExactTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private DecimalTextBox txtExactDistanceKm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numOverallRank;
        private System.Windows.Forms.NumericUpDown numAgeGroupRank;
        private System.Windows.Forms.ComboBox comCompetition;
        private System.Windows.Forms.Label label8;
        private IntegerTextBox txtRaceAverageHr;
    }
}
