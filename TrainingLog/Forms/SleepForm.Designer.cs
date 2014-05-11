namespace TrainingLog.Forms
{
    partial class SleepForm
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
            this.butOK = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.grpSleep.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSleepDuration)).BeginInit();
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
            this.grpSleep.TabIndex = 1;
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
            // butOK
            // 
            this.butOK.Location = new System.Drawing.Point(12, 86);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(75, 23);
            this.butOK.TabIndex = 2;
            this.butOK.Text = "OK";
            this.butOK.UseVisualStyleBackColor = true;
            this.butOK.Click += new System.EventHandler(this.ButOkClick);
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(101, 86);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 3;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.ButCancelClick);
            // 
            // SleepForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(188, 121);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOK);
            this.Controls.Add(this.grpSleep);
            this.Name = "SleepForm";
            this.Text = "Enter Sleep Data";
            this.grpSleep.ResumeLayout(false);
            this.grpSleep.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSleepDuration)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSleep;
        private System.Windows.Forms.ComboBox comSleepQuality;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numSleepDuration;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butOK;
        private System.Windows.Forms.Button butCancel;

    }
}