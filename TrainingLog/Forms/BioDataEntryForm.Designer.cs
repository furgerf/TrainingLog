namespace TrainingLog.Forms
{
    partial class BioDataEntryForm
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
            this.grpRestingHeartRate = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numRestingHeartRate = new System.Windows.Forms.NumericUpDown();
            this.grpWeight = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numWeight = new System.Windows.Forms.NumericUpDown();
            this.grpNibbles = new System.Windows.Forms.GroupBox();
            this.txtNibbles = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.butOk = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.grpFeeling = new System.Windows.Forms.GroupBox();
            this.comFeeling = new System.Windows.Forms.ComboBox();
            this.grpSleep.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSleepDuration)).BeginInit();
            this.grpRestingHeartRate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRestingHeartRate)).BeginInit();
            this.grpWeight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWeight)).BeginInit();
            this.grpNibbles.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpFeeling.SuspendLayout();
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
            this.comSleepQuality.TabIndex = 4;
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
            this.numSleepDuration.Enter += new System.EventHandler(this.NumSleepDurationEnter);
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
            // grpRestingHeartRate
            // 
            this.grpRestingHeartRate.Controls.Add(this.label4);
            this.grpRestingHeartRate.Controls.Add(this.numRestingHeartRate);
            this.grpRestingHeartRate.Location = new System.Drawing.Point(182, 12);
            this.grpRestingHeartRate.Name = "grpRestingHeartRate";
            this.grpRestingHeartRate.Size = new System.Drawing.Size(114, 68);
            this.grpRestingHeartRate.TabIndex = 1;
            this.grpRestingHeartRate.TabStop = false;
            this.grpRestingHeartRate.Text = "Resting Heart Rate";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(81, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "bpm";
            // 
            // numRestingHeartRate
            // 
            this.numRestingHeartRate.Location = new System.Drawing.Point(6, 14);
            this.numRestingHeartRate.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numRestingHeartRate.Name = "numRestingHeartRate";
            this.numRestingHeartRate.Size = new System.Drawing.Size(69, 20);
            this.numRestingHeartRate.TabIndex = 2;
            this.numRestingHeartRate.Enter += new System.EventHandler(this.NumRestingHeartRateEnter);
            // 
            // grpWeight
            // 
            this.grpWeight.Controls.Add(this.label5);
            this.grpWeight.Controls.Add(this.numWeight);
            this.grpWeight.Location = new System.Drawing.Point(302, 12);
            this.grpWeight.Name = "grpWeight";
            this.grpWeight.Size = new System.Drawing.Size(110, 68);
            this.grpWeight.TabIndex = 3;
            this.grpWeight.TabStop = false;
            this.grpWeight.Text = "Weight";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(85, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "kg";
            // 
            // numWeight
            // 
            this.numWeight.DecimalPlaces = 1;
            this.numWeight.Location = new System.Drawing.Point(6, 14);
            this.numWeight.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numWeight.Name = "numWeight";
            this.numWeight.Size = new System.Drawing.Size(73, 20);
            this.numWeight.TabIndex = 2;
            this.numWeight.Enter += new System.EventHandler(this.NumWeightEnter);
            // 
            // grpNibbles
            // 
            this.grpNibbles.Controls.Add(this.txtNibbles);
            this.grpNibbles.Location = new System.Drawing.Point(12, 86);
            this.grpNibbles.Name = "grpNibbles";
            this.grpNibbles.Size = new System.Drawing.Size(510, 48);
            this.grpNibbles.TabIndex = 5;
            this.grpNibbles.TabStop = false;
            this.grpNibbles.Text = "Nibbles";
            // 
            // txtNibbles
            // 
            this.txtNibbles.Location = new System.Drawing.Point(9, 19);
            this.txtNibbles.Name = "txtNibbles";
            this.txtNibbles.Size = new System.Drawing.Size(495, 20);
            this.txtNibbles.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNotes);
            this.groupBox1.Location = new System.Drawing.Point(12, 140);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(510, 66);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Notes";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(9, 19);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(495, 37);
            this.txtNotes.TabIndex = 0;
            // 
            // butOk
            // 
            this.butOk.Location = new System.Drawing.Point(160, 212);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(75, 23);
            this.butOk.TabIndex = 7;
            this.butOk.Text = "OK";
            this.butOk.UseVisualStyleBackColor = true;
            this.butOk.Click += new System.EventHandler(this.ButOkClick);
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(302, 212);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 8;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.ButCancelClick);
            // 
            // grpFeeling
            // 
            this.grpFeeling.Controls.Add(this.comFeeling);
            this.grpFeeling.Location = new System.Drawing.Point(418, 12);
            this.grpFeeling.Name = "grpFeeling";
            this.grpFeeling.Size = new System.Drawing.Size(104, 68);
            this.grpFeeling.TabIndex = 4;
            this.grpFeeling.TabStop = false;
            this.grpFeeling.Text = "Feeling";
            // 
            // comFeeling
            // 
            this.comFeeling.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comFeeling.FormattingEnabled = true;
            this.comFeeling.Location = new System.Drawing.Point(6, 13);
            this.comFeeling.Name = "comFeeling";
            this.comFeeling.Size = new System.Drawing.Size(93, 21);
            this.comFeeling.TabIndex = 5;
            // 
            // BioDataEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 244);
            this.Controls.Add(this.grpFeeling);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpNibbles);
            this.Controls.Add(this.grpWeight);
            this.Controls.Add(this.grpRestingHeartRate);
            this.Controls.Add(this.grpSleep);
            this.Name = "BioDataEntryForm";
            this.Text = "Enter BioData";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BioDataEntryFormFormClosing);
            this.grpSleep.ResumeLayout(false);
            this.grpSleep.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSleepDuration)).EndInit();
            this.grpRestingHeartRate.ResumeLayout(false);
            this.grpRestingHeartRate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRestingHeartRate)).EndInit();
            this.grpWeight.ResumeLayout(false);
            this.grpWeight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWeight)).EndInit();
            this.grpNibbles.ResumeLayout(false);
            this.grpNibbles.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpFeeling.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSleep;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numSleepDuration;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comSleepQuality;
        private System.Windows.Forms.GroupBox grpRestingHeartRate;
        private System.Windows.Forms.NumericUpDown numRestingHeartRate;
        private System.Windows.Forms.GroupBox grpWeight;
        private System.Windows.Forms.NumericUpDown numWeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grpNibbles;
        private System.Windows.Forms.TextBox txtNibbles;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button butOk;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.GroupBox grpFeeling;
        private System.Windows.Forms.ComboBox comFeeling;
    }
}