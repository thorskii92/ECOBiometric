namespace ECO
{
    partial class frmThirteenMonthPrint
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThirteenMonthPrint));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dset = new ECO.dset();
            this.tmonthbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.payrolldataset = new ECO.payrolldataset();
            ((System.ComponentModel.ISupportInitialize)(this.dset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmonthbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.payrolldataset)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "tmonthdset";
            reportDataSource1.Value = this.tmonthbindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ECO.rptThirteenthMonth.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(2);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 1;
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.FullPage;
            // 
            // dset
            // 
            this.dset.DataSetName = "dset";
            this.dset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tmonthbindingSource
            // 
            this.tmonthbindingSource.AllowNew = false;
            this.tmonthbindingSource.DataMember = "tmonth";
            this.tmonthbindingSource.DataSource = this.payrolldataset;
            // 
            // payrolldataset
            // 
            this.payrolldataset.DataSetName = "payrolldataset";
            this.payrolldataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // frmThirteenMonthPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmThirteenMonthPrint";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Thirteenth Month Salary Print";
            this.Load += new System.EventHandler(this.frmThirteenMonthPrint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tmonthbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.payrolldataset)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private dset dset;
        public System.Windows.Forms.BindingSource tmonthbindingSource;
        public payrolldataset payrolldataset;
    }
}