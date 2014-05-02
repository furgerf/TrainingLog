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
            this.comTrainingType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chkSweatData = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDurationSeconds = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDurationMinutes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDurationHours = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comSport = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpNotes = new System.Windows.Forms.GroupBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.grpDistance = new System.Windows.Forms.GroupBox();
            this.labSpeed = new System.Windows.Forms.Label();
            this.labPace = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDistance = new System.Windows.Forms.TextBox();
            this.butCancel = new System.Windows.Forms.Button();
            this.butOk = new System.Windows.Forms.Button();
            this.grpBase.SuspendLayout();
            this.grpNotes.SuspendLayout();
            this.grpDistance.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBase
            // 
            this.grpBase.Controls.Add(this.comTrainingType);
            this.grpBase.Controls.Add(this.label7);
            this.grpBase.Controls.Add(this.chkSweatData);
            this.grpBase.Controls.Add(this.label5);
            this.grpBase.Controls.Add(this.txtDurationSeconds);
            this.grpBase.Controls.Add(this.label4);
            this.grpBase.Controls.Add(this.txtDurationMinutes);
            this.grpBase.Controls.Add(this.label3);
            this.grpBase.Controls.Add(this.txtDurationHours);
            this.grpBase.Controls.Add(this.label2);
            this.grpBase.Controls.Add(this.comSport);
            this.grpBase.Controls.Add(this.label1);
            this.grpBase.Location = new System.Drawing.Point(12, 12);
            this.grpBase.Name = "grpBase";
            this.grpBase.Size = new System.Drawing.Size(202, 115);
            this.grpBase.TabIndex = 0;
            this.grpBase.TabStop = false;
            this.grpBase.Text = "Base Information";
            // 
            // comTrainingType
            // 
            this.comTrainingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comTrainingType.FormattingEnabled = true;
            this.comTrainingType.Location = new System.Drawing.Point(72, 40);
            this.comTrainingType.Name = "comTrainingType";
            this.comTrainingType.Size = new System.Drawing.Size(121, 21);
            this.comTrainingType.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Type:";
            // 
            // chkSweatData
            // 
            this.chkSweatData.AutoSize = true;
            this.chkSweatData.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkSweatData.Location = new System.Drawing.Point(2, 90);
            this.chkSweatData.Name = "chkSweatData";
            this.chkSweatData.Size = new System.Drawing.Size(85, 17);
            this.chkSweatData.TabIndex = 10;
            this.chkSweatData.Text = "Sweat Data:";
            this.chkSweatData.UseVisualStyleBackColor = true;
            this.chkSweatData.CheckedChanged += new System.EventHandler(this.ChkSweatDataCheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(181, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "s";
            // 
            // txtDurationSeconds
            // 
            this.txtDurationSeconds.Location = new System.Drawing.Point(161, 64);
            this.txtDurationSeconds.Name = "txtDurationSeconds";
            this.txtDurationSeconds.Size = new System.Drawing.Size(20, 20);
            this.txtDurationSeconds.TabIndex = 7;
            this.txtDurationSeconds.TextChanged += new System.EventHandler(this.DistanceTimeChanged);
            this.txtDurationSeconds.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericTextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(132, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "min";
            // 
            // txtDurationMinutes
            // 
            this.txtDurationMinutes.Location = new System.Drawing.Point(112, 64);
            this.txtDurationMinutes.Name = "txtDurationMinutes";
            this.txtDurationMinutes.Size = new System.Drawing.Size(20, 20);
            this.txtDurationMinutes.TabIndex = 5;
            this.txtDurationMinutes.TextChanged += new System.EventHandler(this.DistanceTimeChanged);
            this.txtDurationMinutes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericTextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "h";
            // 
            // txtDurationHours
            // 
            this.txtDurationHours.Location = new System.Drawing.Point(73, 64);
            this.txtDurationHours.Name = "txtDurationHours";
            this.txtDurationHours.Size = new System.Drawing.Size(20, 20);
            this.txtDurationHours.TabIndex = 3;
            this.txtDurationHours.TextChanged += new System.EventHandler(this.DistanceTimeChanged);
            this.txtDurationHours.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericTextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Duration:";
            // 
            // comSport
            // 
            this.comSport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comSport.FormattingEnabled = true;
            this.comSport.Location = new System.Drawing.Point(73, 13);
            this.comSport.Name = "comSport";
            this.comSport.Size = new System.Drawing.Size(121, 21);
            this.comSport.TabIndex = 1;
            this.comSport.SelectedIndexChanged += new System.EventHandler(this.ComSportSelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sport:";
            // 
            // grpNotes
            // 
            this.grpNotes.Controls.Add(this.txtNotes);
            this.grpNotes.Location = new System.Drawing.Point(12, 133);
            this.grpNotes.Name = "grpNotes";
            this.grpNotes.Size = new System.Drawing.Size(333, 66);
            this.grpNotes.TabIndex = 7;
            this.grpNotes.TabStop = false;
            this.grpNotes.Text = "Notes";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(9, 19);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(318, 37);
            this.txtNotes.TabIndex = 0;
            // 
            // grpDistance
            // 
            this.grpDistance.Controls.Add(this.labSpeed);
            this.grpDistance.Controls.Add(this.labPace);
            this.grpDistance.Controls.Add(this.label6);
            this.grpDistance.Controls.Add(this.txtDistance);
            this.grpDistance.Location = new System.Drawing.Point(220, 12);
            this.grpDistance.Name = "grpDistance";
            this.grpDistance.Size = new System.Drawing.Size(125, 115);
            this.grpDistance.TabIndex = 8;
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
            this.butCancel.Location = new System.Drawing.Point(198, 205);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 10;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.ButCancelClick);
            // 
            // butOk
            // 
            this.butOk.Location = new System.Drawing.Point(56, 205);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(75, 23);
            this.butOk.TabIndex = 9;
            this.butOk.Text = "OK";
            this.butOk.UseVisualStyleBackColor = true;
            this.butOk.Click += new System.EventHandler(this.ButOkClick);
            // 
            // TrainingEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 241);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBase;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comSport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDurationHours;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDurationSeconds;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDurationMinutes;
        private System.Windows.Forms.Label label3;
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
    }
}