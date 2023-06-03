namespace ECO
{
    partial class frmMAIN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMAIN));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAttendance = new System.Windows.Forms.ToolStripButton();
            this.btnBiometrics = new System.Windows.Forms.ToolStripButton();
            this.btnManageEmp = new System.Windows.Forms.ToolStripButton();
            this.btnPayroll = new System.Windows.Forms.ToolStripButton();
            this.btnCheckReq = new System.Windows.Forms.ToolStripButton();
            this.btnUserAccounts = new System.Windows.Forms.ToolStripButton();
            this.btnLeaveRequest = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tspSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.myProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tspLogoff = new System.Windows.Forms.ToolStripMenuItem();
            this.tspTools = new System.Windows.Forms.ToolStripMenuItem();
            this.tspAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.tspOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.stpLogged = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAttendance,
            this.btnBiometrics,
            this.btnManageEmp,
            this.btnPayroll,
            this.btnCheckReq,
            this.btnUserAccounts,
            this.btnLeaveRequest});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(161, 630);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAttendance
            // 
            this.btnAttendance.BackColor = System.Drawing.Color.Green;
            this.btnAttendance.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAttendance.Image = global::ECO.Properties.Resources.attandance_check;
            this.btnAttendance.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAttendance.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAttendance.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAttendance.Name = "btnAttendance";
            this.btnAttendance.Size = new System.Drawing.Size(158, 59);
            this.btnAttendance.Text = "Attendance";
            this.btnAttendance.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAttendance.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // btnBiometrics
            // 
            this.btnBiometrics.BackColor = System.Drawing.Color.Green;
            this.btnBiometrics.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBiometrics.Image = global::ECO.Properties.Resources.valid_fingerprint_5122;
            this.btnBiometrics.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnBiometrics.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBiometrics.Name = "btnBiometrics";
            this.btnBiometrics.Size = new System.Drawing.Size(158, 59);
            this.btnBiometrics.Text = "Biometrics";
            this.btnBiometrics.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBiometrics.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // btnManageEmp
            // 
            this.btnManageEmp.BackColor = System.Drawing.Color.Green;
            this.btnManageEmp.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageEmp.Image = global::ECO.Properties.Resources.useraccounts__1_1;
            this.btnManageEmp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnManageEmp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnManageEmp.Name = "btnManageEmp";
            this.btnManageEmp.Size = new System.Drawing.Size(158, 59);
            this.btnManageEmp.Text = "Manage Employee";
            this.btnManageEmp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnManageEmp.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // btnPayroll
            // 
            this.btnPayroll.BackColor = System.Drawing.Color.Green;
            this.btnPayroll.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPayroll.Image = global::ECO.Properties.Resources.img_2815852;
            this.btnPayroll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPayroll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPayroll.Name = "btnPayroll";
            this.btnPayroll.Size = new System.Drawing.Size(158, 59);
            this.btnPayroll.Text = "Payroll";
            this.btnPayroll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPayroll.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // btnCheckReq
            // 
            this.btnCheckReq.BackColor = System.Drawing.Color.Green;
            this.btnCheckReq.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckReq.Image = global::ECO.Properties.Resources.img_3780681;
            this.btnCheckReq.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCheckReq.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCheckReq.Name = "btnCheckReq";
            this.btnCheckReq.Size = new System.Drawing.Size(158, 59);
            this.btnCheckReq.Text = "Check Requests";
            this.btnCheckReq.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCheckReq.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // btnUserAccounts
            // 
            this.btnUserAccounts.BackColor = System.Drawing.Color.Green;
            this.btnUserAccounts.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserAccounts.Image = global::ECO.Properties.Resources.manageaccounticon1;
            this.btnUserAccounts.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnUserAccounts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUserAccounts.Name = "btnUserAccounts";
            this.btnUserAccounts.Size = new System.Drawing.Size(158, 59);
            this.btnUserAccounts.Text = "User Accounts";
            this.btnUserAccounts.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnUserAccounts.Click += new System.EventHandler(this.toolStripButton6_Click);
            // 
            // btnLeaveRequest
            // 
            this.btnLeaveRequest.BackColor = System.Drawing.Color.Green;
            this.btnLeaveRequest.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeaveRequest.Image = global::ECO.Properties.Resources.leaveicon32;
            this.btnLeaveRequest.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnLeaveRequest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLeaveRequest.Name = "btnLeaveRequest";
            this.btnLeaveRequest.Size = new System.Drawing.Size(158, 59);
            this.btnLeaveRequest.Text = "Leave Request";
            this.btnLeaveRequest.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLeaveRequest.Click += new System.EventHandler(this.btnLeaveRequest_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspSystem,
            this.tspTools});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1371, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tspSystem
            // 
            this.tspSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.myProfileToolStripMenuItem,
            this.tspLogoff});
            this.tspSystem.Name = "tspSystem";
            this.tspSystem.Size = new System.Drawing.Size(68, 24);
            this.tspSystem.Text = "&System";
            // 
            // myProfileToolStripMenuItem
            // 
            this.myProfileToolStripMenuItem.Name = "myProfileToolStripMenuItem";
            this.myProfileToolStripMenuItem.Size = new System.Drawing.Size(151, 26);
            this.myProfileToolStripMenuItem.Text = "My Profile";
            this.myProfileToolStripMenuItem.Click += new System.EventHandler(this.myProfileToolStripMenuItem_Click);
            // 
            // tspLogoff
            // 
            this.tspLogoff.Name = "tspLogoff";
            this.tspLogoff.Size = new System.Drawing.Size(151, 26);
            this.tspLogoff.Text = "&Logoff";
            this.tspLogoff.Click += new System.EventHandler(this.logoffToolStripMenuItem_Click);
            // 
            // tspTools
            // 
            this.tspTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspAdmin,
            this.tspOptions});
            this.tspTools.Name = "tspTools";
            this.tspTools.Size = new System.Drawing.Size(56, 24);
            this.tspTools.Text = "&Tools";
            // 
            // tspAdmin
            // 
            this.tspAdmin.Name = "tspAdmin";
            this.tspAdmin.Size = new System.Drawing.Size(185, 26);
            this.tspAdmin.Text = "A&dmin Settings";
            this.tspAdmin.Click += new System.EventHandler(this.tspAdmin_Click);
            // 
            // tspOptions
            // 
            this.tspOptions.Name = "tspOptions";
            this.tspOptions.Size = new System.Drawing.Size(185, 26);
            this.tspOptions.Text = "Options";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stpLogged});
            this.statusStrip1.Location = new System.Drawing.Point(0, 658);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 13, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1371, 28);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // stpLogged
            // 
            this.stpLogged.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stpLogged.Name = "stpLogged";
            this.stpLogged.Size = new System.Drawing.Size(114, 23);
            this.stpLogged.Text = "Logged User: ";
            // 
            // frmMAIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1371, 686);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmMAIN";
            this.Text = "MAIN";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMAIN_FormClosing);
            this.Load += new System.EventHandler(this.frmMAIN_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAttendance;
        private System.Windows.Forms.ToolStripButton btnBiometrics;
        private System.Windows.Forms.ToolStripButton btnManageEmp;
        private System.Windows.Forms.ToolStripButton btnPayroll;
        private System.Windows.Forms.ToolStripButton btnCheckReq;
        private System.Windows.Forms.ToolStripButton btnUserAccounts;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tspSystem;
        private System.Windows.Forms.ToolStripMenuItem tspLogoff;
        private System.Windows.Forms.ToolStripMenuItem tspTools;
        private System.Windows.Forms.ToolStripMenuItem tspAdmin;
        private System.Windows.Forms.ToolStripMenuItem tspOptions;
        private System.Windows.Forms.ToolStripButton btnLeaveRequest;
        private System.Windows.Forms.ToolStripMenuItem myProfileToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel stpLogged;
    }
}