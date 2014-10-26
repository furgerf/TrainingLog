namespace TrainingLog.Controls
{
    partial class SquashMatchEntryControl
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
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMatchTime = new TrainingLog.Controls.TimeSpanTextBox();
            this.comOpponent = new System.Windows.Forms.ComboBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMatchAverageHr = new TrainingLog.Controls.IntegerTextBox();
            this.comCompetition = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Opponent:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(156, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "[h:] min:s";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Match Time:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Result:";
            // 
            // txtMatchTime
            // 
            this.txtMatchTime.BackColor = System.Drawing.Color.White;
            this.txtMatchTime.Location = new System.Drawing.Point(88, 0);
            this.txtMatchTime.Name = "txtMatchTime";
            this.txtMatchTime.Size = new System.Drawing.Size(62, 20);
            this.txtMatchTime.TabIndex = 37;
            // 
            // comOpponent
            // 
            this.comOpponent.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comOpponent.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comOpponent.FormattingEnabled = true;
            this.comOpponent.Location = new System.Drawing.Point(88, 26);
            this.comOpponent.Name = "comOpponent";
            this.comOpponent.Size = new System.Drawing.Size(117, 21);
            this.comOpponent.TabIndex = 38;
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(88, 53);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(117, 20);
            this.txtResult.TabIndex = 39;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(0, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 13);
            this.label8.TabIndex = 40;
            this.label8.Text = "Avg. Match HR:";
            // 
            // txtMatchAverageHr
            // 
            this.txtMatchAverageHr.BackColor = System.Drawing.Color.White;
            this.txtMatchAverageHr.Location = new System.Drawing.Point(88, 79);
            this.txtMatchAverageHr.Name = "txtMatchAverageHr";
            this.txtMatchAverageHr.Size = new System.Drawing.Size(117, 20);
            this.txtMatchAverageHr.TabIndex = 41;
            // 
            // comCompetition
            // 
            this.comCompetition.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comCompetition.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comCompetition.FormattingEnabled = true;
            this.comCompetition.Location = new System.Drawing.Point(88, 105);
            this.comCompetition.Name = "comCompetition";
            this.comCompetition.Size = new System.Drawing.Size(117, 21);
            this.comCompetition.TabIndex = 42;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(0, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 43;
            this.label7.Text = "Competition:";
            // 
            // SquashMatchControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comCompetition);
            this.Controls.Add(this.txtMatchAverageHr);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.comOpponent);
            this.Controls.Add(this.txtMatchTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Name = "SquashMatchControl";
            this.Size = new System.Drawing.Size(205, 126);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private TimeSpanTextBox txtMatchTime;
        private System.Windows.Forms.ComboBox comOpponent;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label label8;
        private IntegerTextBox txtMatchAverageHr;
        private System.Windows.Forms.ComboBox comCompetition;
        private System.Windows.Forms.Label label7;

    }
}
