
namespace Report3
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cmbInformes = new System.Windows.Forms.ComboBox();
            this.btnBuscarInforme = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione informe";
            // 
            // cmbInformes
            // 
            this.cmbInformes.FormattingEnabled = true;
            this.cmbInformes.Location = new System.Drawing.Point(238, 54);
            this.cmbInformes.Name = "cmbInformes";
            this.cmbInformes.Size = new System.Drawing.Size(213, 24);
            this.cmbInformes.TabIndex = 1;
            // 
            // btnBuscarInforme
            // 
            this.btnBuscarInforme.Location = new System.Drawing.Point(508, 55);
            this.btnBuscarInforme.Name = "btnBuscarInforme";
            this.btnBuscarInforme.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarInforme.TabIndex = 2;
            this.btnBuscarInforme.Text = "Buscar";
            this.btnBuscarInforme.UseVisualStyleBackColor = true;
            this.btnBuscarInforme.Click += new System.EventHandler(this.btnBuscarInforme_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBuscarInforme);
            this.Controls.Add(this.cmbInformes);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbInformes;
        private System.Windows.Forms.Button btnBuscarInforme;
    }
}

