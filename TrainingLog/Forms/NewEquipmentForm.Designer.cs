namespace TrainingLog.Forms
{
    partial class NewEquipmentForm
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.colPicker = new System.Windows.Forms.ColorDialog();
            this.butCancel = new System.Windows.Forms.Button();
            this.butOk = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comSport = new System.Windows.Forms.ComboBox();
            this.txtImageName = new System.Windows.Forms.TextBox();
            this.butChooseImage = new System.Windows.Forms.Button();
            this.picImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(76, 6);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(131, 20);
            this.txtName.TabIndex = 9;
            // 
            // colPicker
            // 
            this.colPicker.SolidColorOnly = true;
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(132, 265);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 17;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butOk
            // 
            this.butOk.Location = new System.Drawing.Point(15, 265);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(75, 23);
            this.butOk.TabIndex = 16;
            this.butOk.Text = "OK";
            this.butOk.UseVisualStyleBackColor = true;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Image:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Sport:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Name:";
            // 
            // comSport
            // 
            this.comSport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comSport.FormattingEnabled = true;
            this.comSport.Location = new System.Drawing.Point(76, 32);
            this.comSport.Name = "comSport";
            this.comSport.Size = new System.Drawing.Size(131, 21);
            this.comSport.TabIndex = 20;
            // 
            // txtImageName
            // 
            this.txtImageName.Enabled = false;
            this.txtImageName.Location = new System.Drawing.Point(15, 87);
            this.txtImageName.Name = "txtImageName";
            this.txtImageName.Size = new System.Drawing.Size(192, 20);
            this.txtImageName.TabIndex = 21;
            // 
            // butChooseImage
            // 
            this.butChooseImage.Location = new System.Drawing.Point(132, 61);
            this.butChooseImage.Name = "butChooseImage";
            this.butChooseImage.Size = new System.Drawing.Size(75, 20);
            this.butChooseImage.TabIndex = 22;
            this.butChooseImage.Text = "Choose...";
            this.butChooseImage.UseVisualStyleBackColor = true;
            this.butChooseImage.Click += new System.EventHandler(this.butChooseImage_Click);
            // 
            // picImage
            // 
            this.picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImage.Location = new System.Drawing.Point(15, 113);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(192, 144);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImage.TabIndex = 23;
            this.picImage.TabStop = false;
            // 
            // NewEquipmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 300);
            this.Controls.Add(this.picImage);
            this.Controls.Add(this.butChooseImage);
            this.Controls.Add(this.txtImageName);
            this.Controls.Add(this.comSport);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "NewEquipmentForm";
            this.Text = "NewEquipmentForm";
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ColorDialog colPicker;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butOk;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comSport;
        private System.Windows.Forms.TextBox txtImageName;
        private System.Windows.Forms.Button butChooseImage;
        private System.Windows.Forms.PictureBox picImage;
    }
}