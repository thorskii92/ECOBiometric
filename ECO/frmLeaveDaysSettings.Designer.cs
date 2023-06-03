namespace ECO
{
    partial class frmLeaveDaysSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLeaveDaysSettings));
            this.label1 = new System.Windows.Forms.Label();
            this.txtLeavePerMonth = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLeavePerYear = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaternityLeave = new System.Windows.Forms.TextBox();
            this.txtPaternity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Leave Days Per Month\r\n(Sick/Vacation Leave)";
            // 
            // txtLeavePerMonth
            // 
            this.txtLeavePerMonth.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLeavePerMonth.Location = new System.Drawing.Point(152, 24);
            this.txtLeavePerMonth.Margin = new System.Windows.Forms.Padding(2);
            this.txtLeavePerMonth.Name = "txtLeavePerMonth";
            this.txtLeavePerMonth.Size = new System.Drawing.Size(76, 25);
            this.txtLeavePerMonth.TabIndex = 1;
            this.txtLeavePerMonth.TextChanged += new System.EventHandler(this.txtLeavePerMonth_TextChanged);
            this.txtLeavePerMonth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLeavePerMonth_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Total Leave Days Per Year";
            // 
            // txtLeavePerYear
            // 
            this.txtLeavePerYear.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLeavePerYear.Location = new System.Drawing.Point(81, 80);
            this.txtLeavePerYear.Margin = new System.Windows.Forms.Padding(2);
            this.txtLeavePerYear.Name = "txtLeavePerYear";
            this.txtLeavePerYear.ReadOnly = true;
            this.txtLeavePerYear.Size = new System.Drawing.Size(76, 30);
            this.txtLeavePerYear.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(45, 222);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(76, 36);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(126, 222);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(76, 36);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(46, 145);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Maternity Leave";
            // 
            // txtMaternityLeave
            // 
            this.txtMaternityLeave.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaternityLeave.Location = new System.Drawing.Point(152, 142);
            this.txtMaternityLeave.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaternityLeave.Name = "txtMaternityLeave";
            this.txtMaternityLeave.Size = new System.Drawing.Size(76, 25);
            this.txtMaternityLeave.TabIndex = 7;
            this.txtMaternityLeave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaternityLeave_KeyPress);
            // 
            // txtPaternity
            // 
            this.txtPaternity.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaternity.Location = new System.Drawing.Point(152, 171);
            this.txtPaternity.Margin = new System.Windows.Forms.Padding(2);
            this.txtPaternity.Name = "txtPaternity";
            this.txtPaternity.Size = new System.Drawing.Size(76, 25);
            this.txtPaternity.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(46, 174);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "Paternity Leave";
            // 
            // frmLeaveDaysSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 280);
            this.Controls.Add(this.txtPaternity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMaternityLeave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtLeavePerYear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLeavePerMonth);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmLeaveDaysSettings";
            this.Text = "Leave Days Settings";
            this.Load += new System.EventHandler(this.frmLeaveDaysSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLeavePerMonth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLeavePerYear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaternityLeave;
        private System.Windows.Forms.TextBox txtPaternity;
        private System.Windows.Forms.Label label4;
    }
}