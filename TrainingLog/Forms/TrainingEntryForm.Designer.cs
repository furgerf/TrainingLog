namespace TrainingLog.Forms
{
    partial class TrainingEntryForm
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
            this.grpBase = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.comSport = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.chkSweatData = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCalories = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comTrainingType = new System.Windows.Forms.ComboBox();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.grpNotes = new System.Windows.Forms.GroupBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.grpDistance = new System.Windows.Forms.GroupBox();
            this.labSpeed = new System.Windows.Forms.Label();
            this.labPace = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDistance = new System.Windows.Forms.TextBox();
            this.butCancel = new System.Windows.Forms.Button();
            this.butOk = new System.Windows.Forms.Button();
            this.grpHeartRate = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtZone1 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtZone2 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtZone3 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtZone4 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtZone5 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAvgHR = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.grpBase.SuspendLayout();
            this.grpNotes.SuspendLayout();
            this.grpDistance.SuspendLayout();
            this.grpHeartRate.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBase
            // 
            this.grpBase.Controls.Add(this.label20);
            this.grpBase.Controls.Add(this.txtDate);
            this.grpBase.Controls.Add(this.label17);
            this.grpBase.Controls.Add(this.comSport);
            this.grpBase.Controls.Add(this.label18);
            this.grpBase.Controls.Add(this.label7);
            this.grpBase.Controls.Add(this.chkSweatData);
            this.grpBase.Controls.Add(this.label2);
            this.grpBase.Controls.Add(this.txtCalories);
            this.grpBase.Controls.Add(this.label1);
            this.grpBase.Controls.Add(this.comTrainingType);
            this.grpBase.Controls.Add(this.txtDuration);
            this.grpBase.Controls.Add(this.label5);
            this.grpBase.Location = new System.Drawing.Point(12, 12);
            this.grpBase.Name = "grpBase";
            this.grpBase.Size = new System.Drawing.Size(202, 181);
            this.grpBase.TabIndex = 0;
            this.grpBase.TabStop = false;
            this.grpBase.Text = "Base Information";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 22);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(33, 13);
            this.label20.TabIndex = 15;
            this.label20.Text = "Date:";
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(75, 19);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(118, 20);
            this.txtDate.TabIndex = 0;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 129);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(44, 13);
            this.label17.TabIndex = 12;
            this.label17.Text = "Calories";
            // 
            // comSport
            // 
            this.comSport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comSport.FormattingEnabled = true;
            this.comSport.Location = new System.Drawing.Point(75, 46);
            this.comSport.Name = "comSport";
            this.comSport.Size = new System.Drawing.Size(121, 21);
            this.comSport.TabIndex = 1;
            this.comSport.SelectedIndexChanged += new System.EventHandler(this.ComSportSelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(144, 129);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(27, 13);
            this.label18.TabIndex = 14;
            this.label18.Text = "kcal";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Type:";
            // 
            // chkSweatData
            // 
            this.chkSweatData.AutoSize = true;
            this.chkSweatData.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkSweatData.Location = new System.Drawing.Point(4, 152);
            this.chkSweatData.Name = "chkSweatData";
            this.chkSweatData.Size = new System.Drawing.Size(85, 17);
            this.chkSweatData.TabIndex = 5;
            this.chkSweatData.Text = "Sweat Data:";
            this.chkSweatData.UseVisualStyleBackColor = true;
            this.chkSweatData.CheckedChanged += new System.EventHandler(this.ChkSweatDataCheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Duration:";
            // 
            // txtCalories
            // 
            this.txtCalories.Location = new System.Drawing.Point(75, 126);
            this.txtCalories.Name = "txtCalories";
            this.txtCalories.Size = new System.Drawing.Size(63, 20);
            this.txtCalories.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sport:";
            // 
            // comTrainingType
            // 
            this.comTrainingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comTrainingType.FormattingEnabled = true;
            this.comTrainingType.Location = new System.Drawing.Point(75, 73);
            this.comTrainingType.Name = "comTrainingType";
            this.comTrainingType.Size = new System.Drawing.Size(121, 21);
            this.comTrainingType.TabIndex = 2;
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(75, 100);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(62, 20);
            this.txtDuration.TabIndex = 3;
            this.txtDuration.TextChanged += new System.EventHandler(this.DistanceTimeChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(144, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "[h:] min:s";
            // 
            // grpNotes
            // 
            this.grpNotes.Controls.Add(this.txtNotes);
            this.grpNotes.Location = new System.Drawing.Point(12, 199);
            this.grpNotes.Name = "grpNotes";
            this.grpNotes.Size = new System.Drawing.Size(539, 66);
            this.grpNotes.TabIndex = 2;
            this.grpNotes.TabStop = false;
            this.grpNotes.Text = "Notes";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(9, 19);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(517, 37);
            this.txtNotes.TabIndex = 0;
            // 
            // grpDistance
            // 
            this.grpDistance.Controls.Add(this.labSpeed);
            this.grpDistance.Controls.Add(this.labPace);
            this.grpDistance.Controls.Add(this.label6);
            this.grpDistance.Controls.Add(this.txtDistance);
            this.grpDistance.Location = new System.Drawing.Point(426, 12);
            this.grpDistance.Name = "grpDistance";
            this.grpDistance.Size = new System.Drawing.Size(125, 181);
            this.grpDistance.TabIndex = 1;
            this.grpDistance.TabStop = false;
            this.grpDistance.Text = "Distance";
            // 
            // labSpeed
            // 
            this.labSpeed.AutoSize = true;
            this.labSpeed.Location = new System.Drawing.Point(6, 67);
            this.labSpeed.Name = "labSpeed";
            this.labSpeed.Size = new System.Drawing.Size(38, 13);
            this.labSpeed.TabIndex = 3;
            this.labSpeed.Text = "Speed";
            // 
            // labPace
            // 
            this.labPace.AutoSize = true;
            this.labPace.Location = new System.Drawing.Point(6, 43);
            this.labPace.Name = "labPace";
            this.labPace.Size = new System.Drawing.Size(32, 13);
            this.labPace.TabIndex = 2;
            this.labPace.Text = "Pace";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(97, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "m";
            // 
            // txtDistance
            // 
            this.txtDistance.Location = new System.Drawing.Point(6, 13);
            this.txtDistance.Name = "txtDistance";
            this.txtDistance.Size = new System.Drawing.Size(85, 20);
            this.txtDistance.TabIndex = 0;
            this.txtDistance.TextChanged += new System.EventHandler(this.DistanceTimeChanged);
            this.txtDistance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericTextChanged);
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(319, 271);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 4;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.ButCancelClick);
            // 
            // butOk
            // 
            this.butOk.Location = new System.Drawing.Point(177, 271);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(75, 23);
            this.butOk.TabIndex = 3;
            this.butOk.Text = "OK";
            this.butOk.UseVisualStyleBackColor = true;
            this.butOk.Click += new System.EventHandler(this.ButOkClick);
            // 
            // grpHeartRate
            // 
            this.grpHeartRate.Controls.Add(this.label19);
            this.grpHeartRate.Controls.Add(this.label15);
            this.grpHeartRate.Controls.Add(this.txtZone1);
            this.grpHeartRate.Controls.Add(this.label16);
            this.grpHeartRate.Controls.Add(this.label13);
            this.grpHeartRate.Controls.Add(this.txtZone2);
            this.grpHeartRate.Controls.Add(this.label14);
            this.grpHeartRate.Controls.Add(this.label11);
            this.grpHeartRate.Controls.Add(this.txtZone3);
            this.grpHeartRate.Controls.Add(this.label12);
            this.grpHeartRate.Controls.Add(this.label9);
            this.grpHeartRate.Controls.Add(this.txtZone4);
            this.grpHeartRate.Controls.Add(this.label10);
            this.grpHeartRate.Controls.Add(this.label3);
            this.grpHeartRate.Controls.Add(this.txtZone5);
            this.grpHeartRate.Controls.Add(this.label4);
            this.grpHeartRate.Controls.Add(this.txtAvgHR);
            this.grpHeartRate.Controls.Add(this.label8);
            this.grpHeartRate.Location = new System.Drawing.Point(220, 12);
            this.grpHeartRate.Name = "grpHeartRate";
            this.grpHeartRate.Size = new System.Drawing.Size(200, 181);
            this.grpHeartRate.TabIndex = 1;
            this.grpHeartRate.TabStop = false;
            this.grpHeartRate.Text = "Heart Rate";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(144, 22);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(27, 13);
            this.label19.TabIndex = 24;
            this.label19.Text = "bpm";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(144, 130);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(49, 13);
            this.label15.TabIndex = 23;
            this.label15.Text = "[h:] min:s";
            // 
            // txtZone1
            // 
            this.txtZone1.Location = new System.Drawing.Point(76, 154);
            this.txtZone1.Name = "txtZone1";
            this.txtZone1.Size = new System.Drawing.Size(62, 20);
            this.txtZone1.TabIndex = 6;
            this.txtZone1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DurationChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(26, 157);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(44, 13);
            this.label16.TabIndex = 21;
            this.label16.Text = "Zone 1:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(144, 102);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 13);
            this.label13.TabIndex = 20;
            this.label13.Text = "[h:] min:s";
            // 
            // txtZone2
            // 
            this.txtZone2.Location = new System.Drawing.Point(76, 127);
            this.txtZone2.Name = "txtZone2";
            this.txtZone2.Size = new System.Drawing.Size(62, 20);
            this.txtZone2.TabIndex = 5;
            this.txtZone2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DurationChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(26, 130);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 13);
            this.label14.TabIndex = 18;
            this.label14.Text = "Zone 2:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(144, 76);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "[h:] min:s";
            // 
            // txtZone3
            // 
            this.txtZone3.Location = new System.Drawing.Point(76, 100);
            this.txtZone3.Name = "txtZone3";
            this.txtZone3.Size = new System.Drawing.Size(62, 20);
            this.txtZone3.TabIndex = 4;
            this.txtZone3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DurationChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(26, 103);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 13);
            this.label12.TabIndex = 15;
            this.label12.Text = "Zone 3:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(144, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "[h:] min:s";
            // 
            // txtZone4
            // 
            this.txtZone4.Location = new System.Drawing.Point(76, 73);
            this.txtZone4.Name = "txtZone4";
            this.txtZone4.Size = new System.Drawing.Size(62, 20);
            this.txtZone4.TabIndex = 3;
            this.txtZone4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DurationChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(26, 76);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Zone 4:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(144, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "[h:] min:s";
            // 
            // txtZone5
            // 
            this.txtZone5.Location = new System.Drawing.Point(76, 46);
            this.txtZone5.Name = "txtZone5";
            this.txtZone5.Size = new System.Drawing.Size(62, 20);
            this.txtZone5.TabIndex = 2;
            this.txtZone5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DurationChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Zone 5:";
            // 
            // txtAvgHR
            // 
            this.txtAvgHR.Location = new System.Drawing.Point(76, 19);
            this.txtAvgHR.Name = "txtAvgHR";
            this.txtAvgHR.Size = new System.Drawing.Size(62, 20);
            this.txtAvgHR.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Avg. HR:";
            // 
            // TrainingEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 302);
            this.Controls.Add(this.grpHeartRate);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.grpDistance);
            this.Controls.Add(this.grpNotes);
            this.Controls.Add(this.grpBase);
            this.Name = "TrainingEntryForm";
            this.Text = "Enter Training Information";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TrainingEntryFormFormClosing);
            this.grpBase.ResumeLayout(false);
            this.grpBase.PerformLayout();
            this.grpNotes.ResumeLayout(false);
            this.grpNotes.PerformLayout();
            this.grpDistance.ResumeLayout(false);
            this.grpDistance.PerformLayout();
            this.grpHeartRate.ResumeLayout(false);
            this.grpHeartRate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBase;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comSport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grpNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.CheckBox chkSweatData;
        private System.Windows.Forms.GroupBox grpDistance;
        private System.Windows.Forms.TextBox txtDistance;
        private System.Windows.Forms.Label labSpeed;
        private System.Windows.Forms.Label labPace;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butOk;
        private System.Windows.Forms.ComboBox comTrainingType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox grpHeartRate;
        private System.Windows.Forms.TextBox txtAvgHR;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtCalories;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtZone1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtZone2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtZone3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtZone4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtZone5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Label label19;
    }
}