
namespace Report3
{
    partial class Egresos
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
            this.Ds = new Report3.Ds();
            this.EgresosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.EgresosTableAdapter = new Report3.DsTableAdapters.EgresosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.Ds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EgresosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet2";
            reportDataSource1.Value = this.EgresosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Report3.InformeEgresos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(2, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(795, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // Ds
            // 
            this.Ds.DataSetName = "Ds";
            this.Ds.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // EgresosBindingSource
            // 
            this.EgresosBindingSource.DataMember = "Egresos";
            this.EgresosBindingSource.DataSource = this.Ds;
            // 
            // EgresosTableAdapter
            // 
            this.EgresosTableAdapter.ClearBeforeFill = true;
            // 
            // Egresos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Egresos";
            this.Text = "Egresos";
            this.Load += new System.EventHandler(this.Egresos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Ds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EgresosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource EgresosBindingSource;
        private Ds Ds;
        private DsTableAdapters.EgresosTableAdapter EgresosTableAdapter;
    }
}