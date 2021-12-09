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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cmbInformes.Items.Add("Mantenciones");
            cmbInformes.Items.Add("Egresos");
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnBuscarInforme_Click(object sender, EventArgs e)
        {
            string comboBox = cmbInformes.SelectedItem.ToString();

            if (comboBox == "Mantenciones")
            {
                Mantenciones mantenciones = new Mantenciones();
                mantenciones.Show();
            }
            if (comboBox == "Egresos")
            {
                Egresos egresos = new Egresos();
                egresos.Show();
            }
        }
    }
}
