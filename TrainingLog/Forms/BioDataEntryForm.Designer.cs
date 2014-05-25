namespace TrainingLog.Forms
{
    partial class BiodataEntryForm
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
            this.grpSleep = new System.Windows.Forms.GroupBox();
            this.comSleepQuality = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numSleepDuration = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.grpHeartRate = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numOwnIndex = new System.Windows.Forms.NumericUpDown();
            this.numRestingHeartRate = new System.Windows.Forms.NumericUpDown();
            this.grpMisc = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comFeeling = new System.Windows.Forms.ComboBox();
            this.numWeight = new System.Windows.Forms.NumericUpDown();
            this.grpNiggles = new System.Windows.Forms.GroupBox();
            this.txtNiggles = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.butOk = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.grpSleep.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSleepDuration)).BeginInit();
            this.grpHeartRate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOwnIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRestingHeartRate)).BeginInit();
            this.grpMisc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWeight)).BeginInit();
            this.grpNiggles.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSleep
            // 
            this.grpSleep.Controls.Add(this.comSleepQuality);
            this.grpSleep.Controls.Add(this.label3);
            this.grpSleep.Controls.Add(this.label2);
            this.grpSleep.Controls.Add(this.numSleepDuration);
            this.grpSleep.Controls.Add(this.label1);
            this.grpSleep.Location = new System.Drawing.Point(12, 12);
            this.grpSleep.Name = "grpSleep";
            this.grpSleep.Size = new System.Drawing.Size(164, 68);
            this.grpSleep.TabIndex = 0;
            this.grpSleep.TabStop = false;
            this.grpSleep.Text = "Sleep";
            // 
            // comSleepQuality
            // 
            this.comSleepQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comSleepQuality.FormattingEnabled = true;
            this.comSleepQuality.Location = new System.Drawing.Point(62, 38);
            this.comSleepQuality.Name = "comSleepQuality";
            this.comSleepQuality.Size = new System.Drawing.Size(93, 21);
            this.comSleepQuality.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(145, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "h";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Quality:";
            // 
            // numSleepDuration
            // 
            this.numSleepDuration.DecimalPlaces = 1;
            this.numSleepDuration.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numSleepDuration.Location = new System.Drawing.Point(62, 14);
            this.numSleepDuration.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numSleepDuration.Name = "numSleepDuration";
            this.numSleepDuration.Size = new System.Drawing.Size(77, 20);
            this.numSleepDuration.TabIndex = 1;
            this.numSleepDuration.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numSleepDuration.Enter += new System.EventHandler(this.NumericEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Duration:";
            // 
            // grpHeartRate
            // 
            this.grpHeartRate.Controls.Add(this.label7);
            this.grpHeartRate.Controls.Add(this.label6);
            this.grpHeartRate.Controls.Add(this.numOwnIndex);
            this.grpHeartRate.Controls.Add(this.numRestingHeartRate);
            this.grpHeartRate.Location = new System.Drawing.Point(182, 12);
            this.grpHeartRate.Name = "grpHeartRate";
            this.grpHeartRate.Size = new System.Drawing.Size(164, 68);
            this.grpHeartRate.TabIndex = 1;
            this.grpHeartRate.TabStop = false;
            this.grpHeartRate.Text = "Resting Heart Rate";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Resting HR:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "OwnIndex:";
            // 
            // numOwnIndex
            // 
            this.numOwnIndex.Location = new System.Drawing.Point(77, 38);
            this.numOwnIndex.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numOwnIndex.Name = "numOwnIndex";
            this.numOwnIndex.Size = new System.Drawing.Size(81, 20);
            this.numOwnIndex.TabIndex = 5;
            this.numOwnIndex.Enter += new System.EventHandler(this.NumericEnter);
            // 
            // numRestingHeartRate
            // 
            this.numRestingHeartRate.Location = new System.Drawing.Point(77, 14);
            this.numRestingHeartRate.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numRestingHeartRate.Name = "numRestingHeartRate";
            this.numRestingHeartRate.Size = new System.Drawing.Size(81, 20);
            this.numRestingHeartRate.TabIndex = 2;
            this.numRestingHeartRate.Enter += new System.EventHandler(this.NumericEnter);
            // 
            // grpMisc
            // 
            this.grpMisc.Controls.Add(this.label8);
            this.grpMisc.Controls.Add(this.label5);
            this.grpMisc.Controls.Add(this.label4);
            this.grpMisc.Controls.Add(this.comFeeling);
            this.grpMisc.Controls.Add(this.numWeight);
            this.grpMisc.Location = new System.Drawing.Point(352, 12);
            this.grpMisc.Name = "grpMisc";
            this.grpMisc.Size = new System.Drawing.Size(164, 68);
            this.grpMisc.TabIndex = 2;
            this.grpMisc.TabStop = false;
            this.grpMisc.Text = "Miscellaneous";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Feeling:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(135, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "kg";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Weight:";
            // 
            // comFeeling
            // 
            this.comFeeling.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comFeeling.FormattingEnabled = true;
            this.comFeeling.Location = new System.Drawing.Point(56, 38);
            this.comFeeling.Name = "comFeeling";
            this.comFeeling.Size = new System.Drawing.Size(93, 21);
            this.comFeeling.TabIndex = 6;
            // 
            // numWeight
            // 
            this.numWeight.DecimalPlaces = 1;
            this.numWeight.Location = new System.Drawing.Point(56, 14);
            this.numWeight.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numWeight.Name = "numWeight";
            this.numWeight.Size = new System.Drawing.Size(73, 20);
            this.numWeight.TabIndex = 2;
            this.numWeight.Enter += new System.EventHandler(this.NumericEnter);
            // 
            // grpNiggles
            // 
            this.grpNiggles.Controls.Add(this.txtNiggles);
            this.grpNiggles.Location = new System.Drawing.Point(12, 86);
            this.grpNiggles.Name = "grpNiggles";
            this.grpNiggles.Size = new System.Drawing.Size(504, 48);
            this.grpNiggles.TabIndex = 3;
            this.grpNiggles.TabStop = false;
            this.grpNiggles.Text = "Niggles";
            // 
            // txtNiggles
            // 
            this.txtNiggles.Location = new System.Drawing.Point(9, 19);
            this.txtNiggles.Name = "txtNiggles";
            this.txtNiggles.Size = new System.Drawing.Size(489, 20);
            this.txtNiggles.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNotes);
            this.groupBox1.Location = new System.Drawing.Point(12, 140);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(504, 66);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Notes";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(9, 19);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(489, 37);
            this.txtNotes.TabIndex = 0;
            // 
            // butOk
            // 
            this.butOk.Location = new System.Drawing.Point(160, 212);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(75, 23);
            this.butOk.TabIndex = 5;
            this.butOk.Text = "OK";
            this.butOk.UseVisualStyleBackColor = true;
            this.butOk.Click += new System.EventHandler(this.ButOkClick);
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(302, 212);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 6;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.ButCancelClick);
            // 
            // BiodataEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 245);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpNiggles);
            this.Controls.Add(this.grpMisc);
            this.Controls.Add(this.grpHeartRate);
            this.Controls.Add(this.grpSleep);
            this.KeyPreview = true;
            this.Name = "BiodataEntryForm";
            this.Text = "Enter BioData";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BioDataEntryFormFormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BioDataEntryFormKeyDown);
            this.grpSleep.ResumeLayout(false);
            this.grpSleep.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSleepDuration)).EndInit();
            this.grpHeartRate.ResumeLayout(false);
            this.grpHeartRate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOwnIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRestingHeartRate)).EndInit();
            this.grpMisc.ResumeLayout(false);
            this.grpMisc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWeight)).EndInit();
            this.grpNiggles.ResumeLayout(false);
            this.grpNiggles.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSleep;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numSleepDuration;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comSleepQuality;
        private System.Windows.Forms.GroupBox grpHeartRate;
        private System.Windows.Forms.NumericUpDown numRestingHeartRate;
        private System.Windows.Forms.GroupBox grpMisc;
        private System.Windows.Forms.NumericUpDown numWeight;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grpNiggles;
        private System.Windows.Forms.TextBox txtNiggles;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button butOk;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numOwnIndex;
        private System.Windows.Forms.ComboBox comFeeling;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
    }
}