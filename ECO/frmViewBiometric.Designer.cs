namespace ECO
{
    partial class frmViewBiometric
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViewBiometric));
            this.btnClose = new System.Windows.Forms.Button();
            this.picPinky = new System.Windows.Forms.PictureBox();
            this.picRing = new System.Windows.Forms.PictureBox();
            this.picMiddle = new System.Windows.Forms.PictureBox();
            this.picIndex = new System.Windows.Forms.PictureBox();
            this.picThumb = new System.Windows.Forms.PictureBox();
            this.lblEmpID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnDeleteThumb = new System.Windows.Forms.Button();
            this.btnIndex = new System.Windows.Forms.Button();
            this.btnMiddle = new System.Windows.Forms.Button();
            this.btnRing = new System.Windows.Forms.Button();
            this.btnPinky = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picPinky)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMiddle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picThumb)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Green;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(378, 228);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(119, 42);
            this.btnClose.TabIndex = 89;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // picPinky
            // 
            this.picPinky.BackgroundImage = global::ECO.Properties.Resources.BiometricsUnavailable;
            this.picPinky.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picPinky.Location = new System.Drawing.Point(417, 70);
            this.picPinky.Margin = new System.Windows.Forms.Padding(2);
            this.picPinky.Name = "picPinky";
            this.picPinky.Size = new System.Drawing.Size(80, 80);
            this.picPinky.TabIndex = 88;
            this.picPinky.TabStop = false;
            this.picPinky.Click += new System.EventHandler(this.picPinky_Click);
            // 
            // picRing
            // 
            this.picRing.BackgroundImage = global::ECO.Properties.Resources.BiometricsUnavailable;
            this.picRing.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picRing.Location = new System.Drawing.Point(324, 70);
            this.picRing.Margin = new System.Windows.Forms.Padding(2);
            this.picRing.Name = "picRing";
            this.picRing.Size = new System.Drawing.Size(80, 80);
            this.picRing.TabIndex = 87;
            this.picRing.TabStop = false;
            this.picRing.Click += new System.EventHandler(this.picRing_Click);
            // 
            // picMiddle
            // 
            this.picMiddle.BackgroundImage = global::ECO.Properties.Resources.BiometricsUnavailable;
            this.picMiddle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picMiddle.Location = new System.Drawing.Point(231, 70);
            this.picMiddle.Margin = new System.Windows.Forms.Padding(2);
            this.picMiddle.Name = "picMiddle";
            this.picMiddle.Size = new System.Drawing.Size(80, 80);
            this.picMiddle.TabIndex = 86;
            this.picMiddle.TabStop = false;
            this.picMiddle.Click += new System.EventHandler(this.picMiddle_Click);
            // 
            // picIndex
            // 
            this.picIndex.BackgroundImage = global::ECO.Properties.Resources.BiometricsUnavailable;
            this.picIndex.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picIndex.Location = new System.Drawing.Point(138, 70);
            this.picIndex.Margin = new System.Windows.Forms.Padding(2);
            this.picIndex.Name = "picIndex";
            this.picIndex.Size = new System.Drawing.Size(80, 80);
            this.picIndex.TabIndex = 85;
            this.picIndex.TabStop = false;
            this.picIndex.Click += new System.EventHandler(this.picIndex_Click);
            // 
            // picThumb
            // 
            this.picThumb.BackgroundImage = global::ECO.Properties.Resources.BiometricsUnavailable;
            this.picThumb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picThumb.Location = new System.Drawing.Point(45, 70);
            this.picThumb.Margin = new System.Windows.Forms.Padding(2);
            this.picThumb.Name = "picThumb";
            this.picThumb.Size = new System.Drawing.Size(80, 80);
            this.picThumb.TabIndex = 84;
            this.picThumb.TabStop = false;
            this.picThumb.Click += new System.EventHandler(this.picThumb_Click);
            // 
            // lblEmpID
            // 
            this.lblEmpID.AutoSize = true;
            this.lblEmpID.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpID.Location = new System.Drawing.Point(115, 18);
            this.lblEmpID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmpID.Name = "lblEmpID";
            this.lblEmpID.Size = new System.Drawing.Size(21, 18);
            this.lblEmpID.TabIndex = 83;
            this.lblEmpID.Text = "ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(21, 18);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 18);
            this.label3.TabIndex = 82;
            this.label3.Text = "Employee ID:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(115, 36);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(45, 18);
            this.lblName.TabIndex = 81;
            this.lblName.Text = "Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(62, 36);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 18);
            this.label5.TabIndex = 80;
            this.label5.Text = "Name:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(445, 152);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(32, 13);
            this.label18.TabIndex = 94;
            this.label18.Text = "Pinky";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(354, 152);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(27, 13);
            this.label16.TabIndex = 93;
            this.label16.Text = "Ring";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(255, 152);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 13);
            this.label14.TabIndex = 92;
            this.label14.Text = "Middle";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(165, 152);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(33, 13);
            this.label12.TabIndex = 91;
            this.label12.Text = "Index";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(67, 152);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 90;
            this.label8.Text = "Thumb";
            // 
            // btnDeleteThumb
            // 
            this.btnDeleteThumb.BackColor = System.Drawing.Color.Red;
            this.btnDeleteThumb.FlatAppearance.BorderSize = 0;
            this.btnDeleteThumb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteThumb.ForeColor = System.Drawing.Color.White;
            this.btnDeleteThumb.Location = new System.Drawing.Point(70, 168);
            this.btnDeleteThumb.Name = "btnDeleteThumb";
            this.btnDeleteThumb.Size = new System.Drawing.Size(30, 28);
            this.btnDeleteThumb.TabIndex = 95;
            this.btnDeleteThumb.Text = "x";
            this.btnDeleteThumb.UseVisualStyleBackColor = false;
            this.btnDeleteThumb.Click += new System.EventHandler(this.btnDeleteThumb_Click);
            // 
            // btnIndex
            // 
            this.btnIndex.BackColor = System.Drawing.Color.Red;
            this.btnIndex.FlatAppearance.BorderSize = 0;
            this.btnIndex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIndex.ForeColor = System.Drawing.Color.White;
            this.btnIndex.Location = new System.Drawing.Point(164, 168);
            this.btnIndex.Name = "btnIndex";
            this.btnIndex.Size = new System.Drawing.Size(30, 28);
            this.btnIndex.TabIndex = 96;
            this.btnIndex.Text = "x";
            this.btnIndex.UseVisualStyleBackColor = false;
            this.btnIndex.Click += new System.EventHandler(this.btnIndex_Click);
            // 
            // btnMiddle
            // 
            this.btnMiddle.BackColor = System.Drawing.Color.Red;
            this.btnMiddle.FlatAppearance.BorderSize = 0;
            this.btnMiddle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMiddle.ForeColor = System.Drawing.Color.White;
            this.btnMiddle.Location = new System.Drawing.Point(258, 168);
            this.btnMiddle.Name = "btnMiddle";
            this.btnMiddle.Size = new System.Drawing.Size(30, 28);
            this.btnMiddle.TabIndex = 97;
            this.btnMiddle.Text = "x";
            this.btnMiddle.UseVisualStyleBackColor = false;
            this.btnMiddle.Click += new System.EventHandler(this.btnMiddle_Click);
            // 
            // btnRing
            // 
            this.btnRing.BackColor = System.Drawing.Color.Red;
            this.btnRing.FlatAppearance.BorderSize = 0;
            this.btnRing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRing.ForeColor = System.Drawing.Color.White;
            this.btnRing.Location = new System.Drawing.Point(350, 168);
            this.btnRing.Name = "btnRing";
            this.btnRing.Size = new System.Drawing.Size(30, 28);
            this.btnRing.TabIndex = 98;
            this.btnRing.Text = "x";
            this.btnRing.UseVisualStyleBackColor = false;
            this.btnRing.Click += new System.EventHandler(this.btnRing_Click);
            // 
            // btnPinky
            // 
            this.btnPinky.BackColor = System.Drawing.Color.Red;
            this.btnPinky.FlatAppearance.BorderSize = 0;
            this.btnPinky.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPinky.ForeColor = System.Drawing.Color.White;
            this.btnPinky.Location = new System.Drawing.Point(443, 168);
            this.btnPinky.Name = "btnPinky";
            this.btnPinky.Size = new System.Drawing.Size(30, 28);
            this.btnPinky.TabIndex = 99;
            this.btnPinky.Text = "x";
            this.btnPinky.UseVisualStyleBackColor = false;
            this.btnPinky.Click += new System.EventHandler(this.btnPinky_Click);
            // 
            // frmViewBiometric
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 281);
            this.Controls.Add(this.btnPinky);
            this.Controls.Add(this.btnRing);
            this.Controls.Add(this.btnMiddle);
            this.Controls.Add(this.btnIndex);
            this.Controls.Add(this.btnDeleteThumb);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.picPinky);
            this.Controls.Add(this.picRing);
            this.Controls.Add(this.picMiddle);
            this.Controls.Add(this.picIndex);
            this.Controls.Add(this.picThumb);
            this.Controls.Add(this.lblEmpID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmViewBiometric";
            this.ShowInTaskbar = false;
            this.Text = "View Biometric";
            this.Load += new System.EventHandler(this.frmViewBiometric_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picPinky)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMiddle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picThumb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.PictureBox picPinky;
        public System.Windows.Forms.PictureBox picRing;
        public System.Windows.Forms.PictureBox picMiddle;
        public System.Windows.Forms.PictureBox picIndex;
        public System.Windows.Forms.PictureBox picThumb;
        public System.Windows.Forms.Label lblEmpID;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label18;
        public System.Windows.Forms.Label label16;
        public System.Windows.Forms.Label label14;
        public System.Windows.Forms.Label label12;
        public System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnDeleteThumb;
        private System.Windows.Forms.Button btnIndex;
        private System.Windows.Forms.Button btnMiddle;
        private System.Windows.Forms.Button btnRing;
        private System.Windows.Forms.Button btnPinky;
    }
}