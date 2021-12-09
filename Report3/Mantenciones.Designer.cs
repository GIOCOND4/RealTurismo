
namespace Report3
{
    partial class Mantenciones
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
            this.MantencionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Ds = new Report3.Ds();
            this.MantencionesTableAdapter = new Report3.DsTableAdapters.MantencionesTableAdapter();
            this.rwMantenciones = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.MantencionesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ds)).BeginInit();
            this.SuspendLayout();
            // 
            // MantencionesBindingSource
            // 
            this.MantencionesBindingSource.DataMember = "Mantenciones";
            this.MantencionesBindingSource.DataSource = this.Ds;
            // 
            // Ds
            // 
            this.Ds.DataSetName = "Ds";
            this.Ds.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // MantencionesTableAdapter
            // 
            this.MantencionesTableAdapter.ClearBeforeFill = true;
            // 
            // rwMantenciones
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.MantencionesBindingSource;
            this.rwMantenciones.LocalReport.DataSources.Add(reportDataSource1);
            this.rwMantenciones.LocalReport.ReportEmbeddedResource = "Report3.InformeMantenciones.rdlc";
            this.rwMantenciones.Location = new System.Drawing.Point(-2, -1);
            this.rwMantenciones.Name = "rwMantenciones";
            this.rwMantenciones.ServerReport.BearerToken = null;
            this.rwMantenciones.Size = new System.Drawing.Size(807, 454);
            this.rwMantenciones.TabIndex = 0;
            // 
            // Mantenciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rwMantenciones);
            this.Name = "Mantenciones";
            this.Text = "Mantenciones";
            this.Load += new System.EventHandler(this.Mantenciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MantencionesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ds)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource MantencionesBindingSource;
        private Ds Ds;
        private DsTableAdapters.MantencionesTableAdapter MantencionesTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer rwMantenciones;
    }
}