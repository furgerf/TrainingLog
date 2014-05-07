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
            GlacialComponents.Controls.GLColumn glColumn1 = new GlacialComponents.Controls.GLColumn();
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.grpEntries = new System.Windows.Forms.GroupBox();
            this.gliEntries = new GlacialComponents.Controls.GlacialList();
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
            this.grpEntries.Controls.Add(this.gliEntries);
            this.grpEntries.Location = new System.Drawing.Point(0, 100);
            this.grpEntries.Name = "grpEntries";
            this.grpEntries.Size = new System.Drawing.Size(600, 300);
            this.grpEntries.TabIndex = 1;
            this.grpEntries.TabStop = false;
            this.grpEntries.Text = "Entries";
            // 
            // gliEntries
            // 
            this.gliEntries.AllowColumnResize = true;
            this.gliEntries.AllowMultiselect = false;
            this.gliEntries.AlternateBackground = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gliEntries.AlternatingColors = true;
            this.gliEntries.AutoHeight = true;
            this.gliEntries.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.gliEntries.BackgroundStretchToFit = true;
            glColumn1.ActivatedEmbeddedType = GlacialComponents.Controls.GLActivatedEmbeddedTypes.None;
            glColumn1.CheckBoxes = false;
            glColumn1.ImageIndex = -1;
            glColumn1.Name = "comDate";
            glColumn1.NumericSort = true;
            glColumn1.Text = "Date";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            glColumn1.Width = 75;
            this.gliEntries.Columns.AddRange(new GlacialComponents.Controls.GLColumn[] {
            glColumn1});
            this.gliEntries.ControlStyle = GlacialComponents.Controls.GLControlStyles.XP;
            this.gliEntries.FullRowSelect = false;
            this.gliEntries.GridColor = System.Drawing.Color.LightGray;
            this.gliEntries.GridLines = GlacialComponents.Controls.GLGridLines.gridBoth;
            this.gliEntries.GridLineStyle = GlacialComponents.Controls.GLGridLineStyles.gridNone;
            this.gliEntries.GridTypes = GlacialComponents.Controls.GLGridTypes.gridNormal;
            this.gliEntries.HeaderHeight = 16;
            this.gliEntries.HeaderVisible = true;
            this.gliEntries.HeaderWordWrap = false;
            this.gliEntries.HotColumnTracking = false;
            this.gliEntries.HotItemTracking = false;
            this.gliEntries.HotTrackingColor = System.Drawing.Color.LightGray;
            this.gliEntries.HoverEvents = false;
            this.gliEntries.HoverTime = 1;
            this.gliEntries.ImageList = null;
            this.gliEntries.ItemHeight = 17;
            this.gliEntries.ItemWordWrap = false;
            this.gliEntries.Location = new System.Drawing.Point(2, 12);
            this.gliEntries.Name = "gliEntries";
            this.gliEntries.Selectable = false;
            this.gliEntries.SelectedTextColor = System.Drawing.Color.White;
            this.gliEntries.SelectionColor = System.Drawing.Color.DarkBlue;
            this.gliEntries.ShowBorder = true;
            this.gliEntries.ShowFocusRect = false;
            this.gliEntries.Size = new System.Drawing.Size(596, 286);
            this.gliEntries.SortType = GlacialComponents.Controls.SortTypes.QuickSort;
            this.gliEntries.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.gliEntries.TabIndex = 0;
            this.gliEntries.ColumnClickedEvent += new GlacialComponents.Controls.GlacialList.ClickedEventHandler(this.GliEntriesColumnClickedEvent);
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
        private GlacialComponents.Controls.GlacialList gliEntries;
    }
}
