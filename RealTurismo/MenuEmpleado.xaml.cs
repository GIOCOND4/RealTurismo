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

namespace RealTurismo
{
    /// <summary>
    /// Lógica de interacción para MenuEmpleado.xaml
    /// </summary>
    public partial class MenuEmpleado : Window
    {
        public MenuEmpleado()
        {
            InitializeComponent();
        }

        private void btnADepartamentos_Click(object sender, RoutedEventArgs e)
        {
            MantDepartamento depto = new MantDepartamento();
            depto.Show();
        }

        private void btnIngresosEmp_Click(object sender, RoutedEventArgs e)
        {
            VisualizarIngresos ingresos = new VisualizarIngresos();
            ingresos.Show();
        }

    }
}
