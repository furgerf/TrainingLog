namespace TrainingLog.Forms
{
    partial class NonSportEntryForm
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
            this.lisEntries = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colColor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFrom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.butAdd = new System.Windows.Forms.Button();
            this.butEdit = new System.Windows.Forms.Button();
            this.butDelete = new System.Windows.Forms.Button();
            this.butExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lisEntries
            // 
            this.lisEntries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colColor,
            this.colFrom,
            this.colTo});
            this.lisEntries.FullRowSelect = true;
            this.lisEntries.GridLines = true;
            this.lisEntries.HideSelection = false;
            this.lisEntries.Location = new System.Drawing.Point(12, 12);
            this.lisEntries.MultiSelect = false;
            this.lisEntries.Name = "lisEntries";
            this.lisEntries.Size = new System.Drawing.Size(482, 292);
            this.lisEntries.TabIndex = 0;
            this.lisEntries.TabStop = false;
            this.lisEntries.UseCompatibleStateImageBehavior = false;
            this.lisEntries.View = System.Windows.Forms.View.Details;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 202;
            // 
            // colColor
            // 
            this.colColor.Text = "Color";
            this.colColor.Width = 100;
            // 
            // colFrom
            // 
            this.colFrom.Text = "Start Date";
            this.colFrom.Width = 80;
            // 
            // colTo
            // 
            this.colTo.Text = "End Date";
            this.colTo.Width = 80;
            // 
            // butAdd
            // 
            this.butAdd.Location = new System.Drawing.Point(500, 12);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(75, 23);
            this.butAdd.TabIndex = 1;
            this.butAdd.Text = "Add Entry";
            this.butAdd.UseVisualStyleBackColor = true;
            this.butAdd.Click += new System.EventHandler(this.ButAddClick);
            // 
            // butEdit
            // 
            this.butEdit.Location = new System.Drawing.Point(500, 90);
            this.butEdit.Name = "butEdit";
            this.butEdit.Size = new System.Drawing.Size(75, 23);
            this.butEdit.TabIndex = 2;
            this.butEdit.Text = "Edit Entry";
            this.butEdit.UseVisualStyleBackColor = true;
            this.butEdit.Click += new System.EventHandler(this.ButEditClick);
            // 
            // butDelete
            // 
            this.butDelete.Location = new System.Drawing.Point(500, 180);
            this.butDelete.Name = "butDelete";
            this.butDelete.Size = new System.Drawing.Size(75, 23);
            this.butDelete.TabIndex = 3;
            this.butDelete.Text = "Delete Entry";
            this.butDelete.UseVisualStyleBackColor = true;
            this.butDelete.Click += new System.EventHandler(this.ButDeleteClick);
            // 
            // butExit
            // 
            this.butExit.Location = new System.Drawing.Point(500, 281);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(75, 23);
            this.butExit.TabIndex = 4;
            this.butExit.Text = "Exit";
            this.butExit.UseVisualStyleBackColor = true;
            this.butExit.Click += new System.EventHandler(this.ButExitClick);
            // 
            // NonSportEntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 319);
            this.Controls.Add(this.butExit);
            this.Controls.Add(this.butDelete);
            this.Controls.Add(this.butEdit);
            this.Controls.Add(this.butAdd);
            this.Controls.Add(this.lisEntries);
            this.KeyPreview = true;
            this.Name = "NonSportEntryForm";
            this.Text = "Manage Non-Sport Entries";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NonSportEntryFormFormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NonSportEntryFormKeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lisEntries;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colColor;
        private System.Windows.Forms.ColumnHeader colFrom;
        private System.Windows.Forms.ColumnHeader colTo;
        private System.Windows.Forms.Button butAdd;
        private System.Windows.Forms.Button butEdit;
        private System.Windows.Forms.Button butDelete;
        private System.Windows.Forms.Button butExit;
    }
}