namespace ECO
{
    partial class frmEmployeeManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmployeeManagement));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNewEmp = new System.Windows.Forms.ToolStripButton();
            this.btnViewDetails = new System.Windows.Forms.ToolStripButton();
            this.btnUpdateDetails = new System.Windows.Forms.ToolStripButton();
            this.btnResign = new System.Windows.Forms.ToolStripButton();
            this.btnOB = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lvwUsers = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.stpEmployees = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNewEmp,
            this.btnViewDetails,
            this.btnUpdateDetails,
            this.btnResign,
            this.btnOB,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(918, 35);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnNewEmp
            // 
            this.btnNewEmp.BackColor = System.Drawing.Color.Green;
            this.btnNewEmp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnNewEmp.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewEmp.Image = ((System.Drawing.Image)(resources.GetObject("btnNewEmp.Image")));
            this.btnNewEmp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewEmp.Margin = new System.Windows.Forms.Padding(4);
            this.btnNewEmp.Name = "btnNewEmp";
            this.btnNewEmp.Padding = new System.Windows.Forms.Padding(2);
            this.btnNewEmp.Size = new System.Drawing.Size(113, 27);
            this.btnNewEmp.Text = "New Employee";
            this.btnNewEmp.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // btnViewDetails
            // 
            this.btnViewDetails.BackColor = System.Drawing.Color.Green;
            this.btnViewDetails.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnViewDetails.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewDetails.Image = ((System.Drawing.Image)(resources.GetObject("btnViewDetails.Image")));
            this.btnViewDetails.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnViewDetails.Margin = new System.Windows.Forms.Padding(4);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Padding = new System.Windows.Forms.Padding(2);
            this.btnViewDetails.Size = new System.Drawing.Size(99, 27);
            this.btnViewDetails.Text = "View Details";
            this.btnViewDetails.Click += new System.EventHandler(this.btnViewDetails_Click);
            // 
            // btnUpdateDetails
            // 
            this.btnUpdateDetails.BackColor = System.Drawing.Color.Green;
            this.btnUpdateDetails.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnUpdateDetails.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateDetails.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateDetails.Image")));
            this.btnUpdateDetails.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpdateDetails.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdateDetails.Name = "btnUpdateDetails";
            this.btnUpdateDetails.Padding = new System.Windows.Forms.Padding(2);
            this.btnUpdateDetails.Size = new System.Drawing.Size(114, 27);
            this.btnUpdateDetails.Text = "Update Details";
            this.btnUpdateDetails.Click += new System.EventHandler(this.btnUpdateDetails_Click);
            // 
            // btnResign
            // 
            this.btnResign.BackColor = System.Drawing.Color.Green;
            this.btnResign.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnResign.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResign.Image = ((System.Drawing.Image)(resources.GetObject("btnResign.Image")));
            this.btnResign.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnResign.Margin = new System.Windows.Forms.Padding(4);
            this.btnResign.Name = "btnResign";
            this.btnResign.Padding = new System.Windows.Forms.Padding(2);
            this.btnResign.Size = new System.Drawing.Size(128, 27);
            this.btnResign.Text = "Resign Employee";
            this.btnResign.Click += new System.EventHandler(this.btnResign_Click);
            // 
            // btnOB
            // 
            this.btnOB.BackColor = System.Drawing.Color.Green;
            this.btnOB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnOB.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOB.Image = ((System.Drawing.Image)(resources.GetObject("btnOB.Image")));
            this.btnOB.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOB.Margin = new System.Windows.Forms.Padding(4);
            this.btnOB.Name = "btnOB";
            this.btnOB.Padding = new System.Windows.Forms.Padding(2);
            this.btnOB.Size = new System.Drawing.Size(126, 27);
            this.btnOB.Text = "Official Business";
            this.btnOB.Click += new System.EventHandler(this.btnOB_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1.BackColor = System.Drawing.Color.Green;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Margin = new System.Windows.Forms.Padding(4);
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Padding = new System.Windows.Forms.Padding(2);
            this.toolStripButton1.Size = new System.Drawing.Size(104, 27);
            this.toolStripButton1.Text = "Resigned List";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lvwUsers);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(918, 488);
            this.panel1.TabIndex = 1;
            // 
            // lvwUsers
            // 
            this.lvwUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvwUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwUsers.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwUsers.FullRowSelect = true;
            this.lvwUsers.GridLines = true;
            this.lvwUsers.Location = new System.Drawing.Point(0, 0);
            this.lvwUsers.MultiSelect = false;
            this.lvwUsers.Name = "lvwUsers";
            this.lvwUsers.Size = new System.Drawing.Size(918, 488);
            this.lvwUsers.TabIndex = 0;
            this.lvwUsers.UseCompatibleStateImageBehavior = false;
            this.lvwUsers.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Employee ID#";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 500;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Position";
            this.columnHeader3.Width = 200;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Contract Type";
            this.columnHeader4.Width = 200;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stpEmployees});
            this.statusStrip1.Location = new System.Drawing.Point(0, 523);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(918, 23);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // stpEmployees
            // 
            this.stpEmployees.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stpEmployees.Name = "stpEmployees";
            this.stpEmployees.Size = new System.Drawing.Size(90, 18);
            this.stpEmployees.Text = "Employees: 0";
            // 
            // frmEmployeeManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 546);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEmployeeManagement";
            this.Text = "Employee Management";
            this.Load += new System.EventHandler(this.frmEmployeeManagement_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lvwUsers;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ToolStripButton btnNewEmp;
        private System.Windows.Forms.ToolStripButton btnViewDetails;
        private System.Windows.Forms.ToolStripButton btnUpdateDetails;
        private System.Windows.Forms.ToolStripButton btnResign;
        private System.Windows.Forms.ToolStripButton btnOB;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel stpEmployees;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}