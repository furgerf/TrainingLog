namespace TrainingLog.Controls
{
    partial class DateFilterControl
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
            this.cdpDate = new TrainingLog.Controls.ColorDatePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cdpDate
            // 
            this.cdpDate.BackDisabledColor = System.Drawing.SystemColors.Control;
            this.cdpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.cdpDate.Location = new System.Drawing.Point(70, 0);
            this.cdpDate.Name = "cdpDate";
            this.cdpDate.Size = new System.Drawing.Size(90, 20);
            this.cdpDate.TabIndex = 0;
            this.cdpDate.ValueChanged += new System.EventHandler(this.CdpDateValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "From:";
            // 
            // DateFilterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cdpDate);
            this.Name = "DateFilterControl";
            this.Size = new System.Drawing.Size(160, 20);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ColorDatePicker cdpDate;
        private System.Windows.Forms.Label label1;
    }
}
