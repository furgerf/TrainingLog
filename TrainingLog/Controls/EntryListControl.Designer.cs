namespace TrainingLog.Controls
{
    partial class EntryListControl
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
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.grpEntries = new System.Windows.Forms.GroupBox();
            this.cliEntries = new TrainingLog.Controls.ControlList();
            this.grpEntries.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpFilter
            // 
            this.grpFilter.Location = new System.Drawing.Point(0, 0);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Size = new System.Drawing.Size(600, 10);
            this.grpFilter.TabIndex = 0;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "Filter";
            // 
            // grpEntries
            // 
            this.grpEntries.Controls.Add(this.cliEntries);
            this.grpEntries.Location = new System.Drawing.Point(0, 100);
            this.grpEntries.Name = "grpEntries";
            this.grpEntries.Size = new System.Drawing.Size(600, 300);
            this.grpEntries.TabIndex = 1;
            this.grpEntries.TabStop = false;
            this.grpEntries.Text = "Entries";
            // 
            // gliEntries
            // 
            this.cliEntries.ItemHeight = 20;
            this.cliEntries.Location = new System.Drawing.Point(2, 12);
            this.cliEntries.Name = "gliEntries";
            this.cliEntries.Size = new System.Drawing.Size(596, 286);
            this.cliEntries.TabIndex = 0;
            // 
            // EntryListControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpEntries);
            this.Controls.Add(this.grpFilter);
            this.Name = "EntryListControl";
            this.Size = new System.Drawing.Size(600, 400);
            this.SizeChanged += new System.EventHandler(this.EntryListControlSizeChanged);
            this.grpEntries.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.GroupBox grpEntries;
        private ControlList cliEntries;
    }
}
