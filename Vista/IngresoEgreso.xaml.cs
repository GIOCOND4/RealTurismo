using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BibliotecaControlador;
using MahApps.Metro.Controls;

namespace Vista
{
    /// <summary>
    /// Lógica de interacción para IngresoEgreso.xaml
    /// </summary>
    public partial class IngresoEgreso : MetroWindow
    {
        ControllerIngresoEgreso cie = new ControllerIngresoEgreso();
        public IngresoEgreso()
        {
            InitializeComponent();
            
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_buscarIngresos_Click(object sender, RoutedEventArgs e)
        {
            string Depto = txt_buscarFechaIngresos.Text;
            try
            {
                if (rb_ingreso.IsChecked == true)
                {
                    if (Depto == "")
                    {
                        dg_listadoIngresos.ItemsSource = cie.ListarIngresos();
                    }
                    else
                    {
                        dg_listadoIngresos.ItemsSource = cie.ListarIngresosDepto(Depto);
                    }

                }
                else if (rb_egreso.IsChecked == true)
                {
                    if (Depto == "")
                    {
                        dg_listadoIngresos.ItemsSource = cie.ListarEgresos();
                    }
                    else
                    {
                        dg_listadoIngresos.ItemsSource = cie.ListarEgresosDepto(Depto);
                    }
                }
                
                
            }
            catch (Exception ex)
            {

                MessageBox.Show("Ocurrió un error: "+ex);
            }
                
            
            
        }
    }
}
