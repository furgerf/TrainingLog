namespace TrainingLog.Forms
{
    partial class TrainingLogForm
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
            this.entryListControl1 = new TrainingLog.Forms.EntryListControl();
            this.SuspendLayout();
            // 
            // entryListControl1
            // 
            this.entryListControl1.Location = new System.Drawing.Point(12, 12);
            this.entryListControl1.Name = "entryListControl1";
            this.entryListControl1.Size = new System.Drawing.Size(600, 400);
            this.entryListControl1.TabIndex = 0;
            // 
            // TrainingLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 432);
            this.Controls.Add(this.entryListControl1);
            this.KeyPreview = true;
            this.Name = "TrainingLogForm";
            this.Text = "Training Log";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TrainingLogFormFormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TrainingLogFormKeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private EntryListControl entryListControl1;
    }
}