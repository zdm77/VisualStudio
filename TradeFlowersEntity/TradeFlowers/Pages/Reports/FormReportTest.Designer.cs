namespace TradeFlowers.Pages.Reports
{
    partial class FormReportTest
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.wwwunifloragroup_tradeDataSet = new TradeFlowers.wwwunifloragroup_tradeDataSet();
            this.viewproductBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.view_productTableAdapter = new TradeFlowers.wwwunifloragroup_tradeDataSetTableAdapters.view_productTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.wwwunifloragroup_tradeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewproductBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.viewproductBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "TradeFlowers.Pages.Reports.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(839, 501);
            this.reportViewer1.TabIndex = 0;
            // 
            // wwwunifloragroup_tradeDataSet
            // 
            this.wwwunifloragroup_tradeDataSet.DataSetName = "wwwunifloragroup_tradeDataSet";
            this.wwwunifloragroup_tradeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // viewproductBindingSource
            // 
            this.viewproductBindingSource.DataMember = "view_product";
            this.viewproductBindingSource.DataSource = this.wwwunifloragroup_tradeDataSet;
            // 
            // view_productTableAdapter
            // 
            this.view_productTableAdapter.ClearBeforeFill = true;
            // 
            // FormReportTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 501);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FormReportTest";
            this.Text = "FormReportTest";
            this.Load += new System.EventHandler(this.FormReportTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.wwwunifloragroup_tradeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewproductBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private wwwunifloragroup_tradeDataSet wwwunifloragroup_tradeDataSet;
        private System.Windows.Forms.BindingSource viewproductBindingSource;
        private wwwunifloragroup_tradeDataSetTableAdapters.view_productTableAdapter view_productTableAdapter;
    }
}