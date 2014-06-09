using TrainingLog.Controls;

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
            this.datDate = new System.Windows.Forms.DateTimePicker();
            this.label20 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.comSport = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.chkRace = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comTrainingType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.grpNotes = new System.Windows.Forms.GroupBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.grpDistance = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.comFeeling = new System.Windows.Forms.ComboBox();
            this.labSpeed = new System.Windows.Forms.Label();
            this.labPace = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.butCancel = new System.Windows.Forms.Button();
            this.butOk = new System.Windows.Forms.Button();
            this.grpHeartRate = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.butParseHtml = new System.Windows.Forms.Button();
            this.butClear = new System.Windows.Forms.Button();
            this.butParseXml = new System.Windows.Forms.Button();
            this.txtAvgHR = new TrainingLog.Controls.IntegerTextBox();
            this.txtZone1 = new TrainingLog.Controls.TimeSpanTextBox();
            this.txtZone2 = new TrainingLog.Controls.TimeSpanTextBox();
            this.txtZone3 = new TrainingLog.Controls.TimeSpanTextBox();
            this.txtZone4 = new TrainingLog.Controls.TimeSpanTextBox();
            this.txtZone5 = new TrainingLog.Controls.TimeSpanTextBox();
            this.txtDistance = new TrainingLog.Controls.DecimalTextBox();
            this.txtCalories = new TrainingLog.Controls.IntegerTextBox();
            this.txtDuration = new TrainingLog.Controls.TimeSpanTextBox();
            this.grpBase.SuspendLayout();
            this.grpNotes.SuspendLayout();
            this.grpDistance.SuspendLayout();
            this.grpHeartRate.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBase
            // 
            this.grpBase.Controls.Add(this.txtCalories);
            this.grpBase.Controls.Add(this.txtDuration);
            this.grpBase.Controls.Add(this.datDate);
            this.grpBase.Controls.Add(this.label20);
            this.grpBase.Controls.Add(this.label17);
            this.grpBase.Controls.Add(this.comSport);
            this.grpBase.Controls.Add(this.label18);
            this.grpBase.Controls.Add(this.label7);
            this.grpBase.Controls.Add(this.chkRace);
            this.grpBase.Controls.Add(this.label2);
            this.grpBase.Controls.Add(this.label1);
            this.grpBase.Controls.Add(this.comTrainingType);
            this.grpBase.Controls.Add(this.label5);
            this.grpBase.Location = new System.Drawing.Point(12, 12);
            this.grpBase.Name = "grpBase";
            this.grpBase.Size = new System.Drawing.Size(202, 181);
            this.grpBase.TabIndex = 0;
            this.grpBase.TabStop = false;
            this.grpBase.Text = "Base Information";
            // 
            // datDate
            // 
            this.datDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datDate.Location = new System.Drawing.Point(75, 22);
            this.datDate.Name = "datDate";
            this.datDate.Size = new System.Drawing.Size(121, 20);
            this.datDate.TabIndex = 0;
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
            // chkRace
            // 
            this.chkRace.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkRace.Location = new System.Drawing.Point(4, 152);
            this.chkRace.Name = "chkRace";
            this.chkRace.Size = new System.Drawing.Size(85, 17);
            this.chkRace.TabIndex = 5;
            this.chkRace.Text = "Race:";
            this.chkRace.UseVisualStyleBackColor = true;
            this.chkRace.CheckedChanged += new System.EventHandler(this.ChkRaceCheckedChanged);
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(144, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "[h.] min.s";
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
            this.grpDistance.Controls.Add(this.txtDistance);
            this.grpDistance.Controls.Add(this.label21);
            this.grpDistance.Controls.Add(this.comFeeling);
            this.grpDistance.Controls.Add(this.labSpeed);
            this.grpDistance.Controls.Add(this.labPace);
            this.grpDistance.Controls.Add(this.label6);
            this.grpDistance.Location = new System.Drawing.Point(426, 12);
            this.grpDistance.Name = "grpDistance";
            this.grpDistance.Size = new System.Drawing.Size(125, 181);
            this.grpDistance.TabIndex = 1;
            this.grpDistance.TabStop = false;
            this.grpDistance.Text = "Distance/Feeling";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(6, 130);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(44, 13);
            this.label21.TabIndex = 10;
            this.label21.Text = "Feeling:";
            // 
            // comFeeling
            // 
            this.comFeeling.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comFeeling.FormattingEnabled = true;
            this.comFeeling.Location = new System.Drawing.Point(9, 152);
            this.comFeeling.Name = "comFeeling";
            this.comFeeling.Size = new System.Drawing.Size(103, 21);
            this.comFeeling.TabIndex = 9;
            // 
            // labSpeed
            // 
            this.labSpeed.AutoSize = true;
            this.labSpeed.Location = new System.Drawing.Point(6, 80);
            this.labSpeed.Name = "labSpeed";
            this.labSpeed.Size = new System.Drawing.Size(38, 13);
            this.labSpeed.TabIndex = 3;
            this.labSpeed.Text = "Speed";
            // 
            // labPace
            // 
            this.labPace.AutoSize = true;
            this.labPace.Location = new System.Drawing.Point(6, 54);
            this.labPace.Name = "labPace";
            this.labPace.Size = new System.Drawing.Size(32, 13);
            this.labPace.TabIndex = 2;
            this.labPace.Text = "Pace";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(91, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "km";
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(112, 271);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 4;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.ButCancelClick);
            // 
            // butOk
            // 
            this.butOk.Location = new System.Drawing.Point(12, 271);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(75, 23);
            this.butOk.TabIndex = 3;
            this.butOk.Text = "OK";
            this.butOk.UseVisualStyleBackColor = true;
            this.butOk.Click += new System.EventHandler(this.ButOkClick);
            // 
            // grpHeartRate
            // 
            this.grpHeartRate.Controls.Add(this.txtAvgHR);
            this.grpHeartRate.Controls.Add(this.txtZone1);
            this.grpHeartRate.Controls.Add(this.txtZone2);
            this.grpHeartRate.Controls.Add(this.txtZone3);
            this.grpHeartRate.Controls.Add(this.txtZone4);
            this.grpHeartRate.Controls.Add(this.txtZone5);
            this.grpHeartRate.Controls.Add(this.label19);
            this.grpHeartRate.Controls.Add(this.label15);
            this.grpHeartRate.Controls.Add(this.label16);
            this.grpHeartRate.Controls.Add(this.label13);
            this.grpHeartRate.Controls.Add(this.label14);
            this.grpHeartRate.Controls.Add(this.label11);
            this.grpHeartRate.Controls.Add(this.label12);
            this.grpHeartRate.Controls.Add(this.label9);
            this.grpHeartRate.Controls.Add(this.label10);
            this.grpHeartRate.Controls.Add(this.label3);
            this.grpHeartRate.Controls.Add(this.label4);
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
            this.label15.Text = "[h.] min.s";
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
            this.label13.Text = "[h.] min.s";
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
            this.label11.Text = "[h.] min.s";
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
            this.label9.Text = "[h.] min.s";
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
            this.label3.Text = "[h.] min.s";
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Avg. HR:";
            // 
            // butParseHtml
            // 
            this.butParseHtml.Location = new System.Drawing.Point(448, 271);
            this.butParseHtml.Name = "butParseHtml";
            this.butParseHtml.Size = new System.Drawing.Size(103, 23);
            this.butParseHtml.TabIndex = 7;
            this.butParseHtml.Text = "Add Info from html";
            this.butParseHtml.UseVisualStyleBackColor = true;
            this.butParseHtml.Click += new System.EventHandler(this.ButParseFileClick);
            // 
            // butClear
            // 
            this.butClear.Location = new System.Drawing.Point(212, 271);
            this.butClear.Name = "butClear";
            this.butClear.Size = new System.Drawing.Size(75, 23);
            this.butClear.TabIndex = 5;
            this.butClear.Text = "Clear";
            this.butClear.UseVisualStyleBackColor = true;
            this.butClear.Click += new System.EventHandler(this.ButClearClick);
            // 
            // butParseXml
            // 
            this.butParseXml.Location = new System.Drawing.Point(320, 271);
            this.butParseXml.Name = "butParseXml";
            this.butParseXml.Size = new System.Drawing.Size(103, 23);
            this.butParseXml.TabIndex = 6;
            this.butParseXml.Text = "Add Info from XML";
            this.butParseXml.UseVisualStyleBackColor = true;
            this.butParseXml.Click += new System.EventHandler(this.ButParseXmlClick);
            // 
            // txtAvgHR
            // 
            this.txtAvgHR.BackColor = System.Drawing.Color.White;
            this.txtAvgHR.Location = new System.Drawing.Point(76, 22);
            this.txtAvgHR.Name = "txtAvgHR";
            this.txtAvgHR.Size = new System.Drawing.Size(62, 20);
            this.txtAvgHR.TabIndex = 1;
            // 
            // txtZone1
            // 
            this.txtZone1.Location = new System.Drawing.Point(76, 154);
            this.txtZone1.Name = "txtZone1";
            this.txtZone1.Size = new System.Drawing.Size(62, 20);
            this.txtZone1.TabIndex = 6;
            // 
            // txtZone2
            // 
            this.txtZone2.Location = new System.Drawing.Point(76, 127);
            this.txtZone2.Name = "txtZone2";
            this.txtZone2.Size = new System.Drawing.Size(62, 20);
            this.txtZone2.TabIndex = 5;
            // 
            // txtZone3
            // 
            this.txtZone3.Location = new System.Drawing.Point(76, 100);
            this.txtZone3.Name = "txtZone3";
            this.txtZone3.Size = new System.Drawing.Size(62, 20);
            this.txtZone3.TabIndex = 4;
            // 
            // txtZone4
            // 
            this.txtZone4.Location = new System.Drawing.Point(76, 73);
            this.txtZone4.Name = "txtZone4";
            this.txtZone4.Size = new System.Drawing.Size(62, 20);
            this.txtZone4.TabIndex = 3;
            // 
            // txtZone5
            // 
            this.txtZone5.Location = new System.Drawing.Point(76, 46);
            this.txtZone5.Name = "txtZone5";
            this.txtZone5.Size = new System.Drawing.Size(62, 20);
            this.txtZone5.TabIndex = 2;
            // 
            // txtDistance
            // 
            this.txtDistance.BackColor = System.Drawing.Color.White;
            this.txtDistance.Location = new System.Drawing.Point(9, 22);
            this.txtDistance.Name = "txtDistance";
            this.txtDistance.Size = new System.Drawing.Size(76, 20);
            this.txtDistance.TabIndex = 11;
            this.txtDistance.TextChanged += new System.EventHandler(this.DistanceTimeChanged);
            // 
            // txtCalories
            // 
            this.txtCalories.BackColor = System.Drawing.Color.White;
            this.txtCalories.Location = new System.Drawing.Point(75, 127);
            this.txtCalories.Name = "txtCalories";
            this.txtCalories.Size = new System.Drawing.Size(62, 20);
            this.txtCalories.TabIndex = 4;
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(75, 100);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(62, 20);
            this.txtDuration.TabIndex = 3;
            // 
            // TrainingEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 304);
            this.Controls.Add(this.butParseXml);
            this.Controls.Add(this.butClear);
            this.Controls.Add(this.butParseHtml);
            this.Controls.Add(this.grpHeartRate);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.grpDistance);
            this.Controls.Add(this.grpNotes);
            this.Controls.Add(this.grpBase);
            this.KeyPreview = true;
            this.Name = "TrainingEntryForm";
            this.Text = "Enter Training Information";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TrainingEntryFormFormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TrainingEntryFormKeyDown);
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grpNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.CheckBox chkRace;
        private System.Windows.Forms.GroupBox grpDistance;
        private System.Windows.Forms.Label labSpeed;
        private System.Windows.Forms.Label labPace;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butOk;
        private System.Windows.Forms.ComboBox comTrainingType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox grpHeartRate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox comFeeling;
        private System.Windows.Forms.DateTimePicker datDate;
        private System.Windows.Forms.Button butParseHtml;
        private System.Windows.Forms.Button butClear;
        private TimeSpanTextBox txtDuration;
        private TimeSpanTextBox txtZone5;
        private TimeSpanTextBox txtZone4;
        private TimeSpanTextBox txtZone1;
        private TimeSpanTextBox txtZone2;
        private TimeSpanTextBox txtZone3;
        private IntegerTextBox txtCalories;
        private IntegerTextBox txtAvgHR;
        private DecimalTextBox txtDistance;
        private System.Windows.Forms.Button butParseXml;
    }
}