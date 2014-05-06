namespace TrainingLog.Forms
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
            this.lisEntries = new System.Windows.Forms.ListView();
            this.grpEntries.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpFilter
            // 
            this.grpFilter.Location = new System.Drawing.Point(0, 0);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Size = new System.Drawing.Size(600, 100);
            this.grpFilter.TabIndex = 0;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "Filter";
            // 
            // grpEntries
            // 
            this.grpEntries.Controls.Add(this.lisEntries);
            this.grpEntries.Location = new System.Drawing.Point(0, 100);
            this.grpEntries.Name = "grpEntries";
            this.grpEntries.Size = new System.Drawing.Size(600, 300);
            this.grpEntries.TabIndex = 1;
            this.grpEntries.TabStop = false;
            this.grpEntries.Text = "Entries";
            // 
            // lisEntries
            // 
            this.lisEntries.GridLines = true;
            this.lisEntries.Location = new System.Drawing.Point(2, 12);
            this.lisEntries.Name = "lisEntries";
            this.lisEntries.Size = new System.Drawing.Size(596, 280);
            this.lisEntries.TabIndex = 0;
            this.lisEntries.UseCompatibleStateImageBehavior = false;
            this.lisEntries.View = System.Windows.Forms.View.Details;
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
        private System.Windows.Forms.ListView lisEntries;
    }
}
