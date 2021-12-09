using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Report3
{
    public partial class Mantenciones : Form
    {
        public Mantenciones()
        {
            InitializeComponent();
        }

        private void Mantenciones_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'Ds.Mantenciones' Puede moverla o quitarla según sea necesario.
            this.MantencionesTableAdapter.Fill(this.Ds.Mantenciones);

            this.rwMantenciones.RefreshReport();
        }
    }
}
