namespace TrainingLog.Controls
{
    partial class ControlList
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
            this.lisHeader = new System.Windows.Forms.ListView();
            this.vscScroll = new System.Windows.Forms.VScrollBar();
            this.panArea = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lisHeader
            // 
            this.lisHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lisHeader.Location = new System.Drawing.Point(0, 0);
            this.lisHeader.Name = "lisHeader";
            this.lisHeader.Size = new System.Drawing.Size(360, 18);
            this.lisHeader.TabIndex = 0;
            this.lisHeader.UseCompatibleStateImageBehavior = false;
            this.lisHeader.View = System.Windows.Forms.View.Details;
            this.lisHeader.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.LisHeaderColumnWidthChanging);
            // 
            // vscScroll
            // 
            this.vscScroll.Enabled = false;
            this.vscScroll.LargeChange = 1;
            this.vscScroll.Location = new System.Drawing.Point(360, 18);
            this.vscScroll.Maximum = 0;
            this.vscScroll.Name = "vscScroll";
            this.vscScroll.Size = new System.Drawing.Size(18, 100);
            this.vscScroll.TabIndex = 2;
            this.vscScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.VscScrollScroll);
            // 
            // panArea
            // 
            this.panArea.BackColor = System.Drawing.Color.White;
            this.panArea.Location = new System.Drawing.Point(0, 18);
            this.panArea.Name = "panArea";
            this.panArea.Size = new System.Drawing.Size(360, 100);
            this.panArea.TabIndex = 3;
            // 
            // ControlList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panArea);
            this.Controls.Add(this.vscScroll);
            this.Controls.Add(this.lisHeader);
            this.Name = "ControlList";
            this.Size = new System.Drawing.Size(378, 118);
            this.Resize += new System.EventHandler(this.ControlListResize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lisHeader;
        private System.Windows.Forms.VScrollBar vscScroll;
        private System.Windows.Forms.Panel panArea;

    }
}
