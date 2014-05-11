namespace TrainingLog.Controls
{
    partial class ZoneDataBox
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
            this.labText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labText
            // 
            this.labText.AutoSize = true;
            this.labText.BackColor = System.Drawing.Color.Transparent;
            this.labText.Location = new System.Drawing.Point(0, 0);
            this.labText.Name = "labText";
            this.labText.Size = new System.Drawing.Size(0, 13);
            this.labText.TabIndex = 0;
            this.labText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ZoneDataBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labText);
            this.Name = "ZoneDataBox";
            this.SizeChanged += new System.EventHandler(this.ZoneDataBoxSizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ZoneDataBoxPaint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labText;

    }
}
