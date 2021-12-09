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
    public partial class Egresos : Form
    {
        public Egresos()
        {
            InitializeComponent();
        }

        private void Egresos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'Ds.Egresos' Puede moverla o quitarla según sea necesario.
            this.EgresosTableAdapter.Fill(this.Ds.Egresos);

            this.reportViewer1.RefreshReport();
        }
    }
}
