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
using MahApps.Metro.Controls;

namespace Vista
{
    /// <summary>
    /// Lógica de interacción para MenuEmpleados.xaml
    /// </summary>
    public partial class MenuEmpleados : MetroWindow
    {
        public MenuEmpleados()
        {
            InitializeComponent();
        }

        private void btnDepartamento_Click(object sender, RoutedEventArgs e)
        {
            AdminDepartamentos depto = new AdminDepartamentos();
            depto.Show();
        }

        private void btnIngresos_Click(object sender, RoutedEventArgs e)
        {
            IngresoEgreso ingresoEgreso = new IngresoEgreso();
            ingresoEgreso.Show();
        }

        private void btnMantenciones_Click(object sender, RoutedEventArgs e)
        {
            AdminMantenciones mantenciones = new AdminMantenciones();
            mantenciones.Show();
        }

        private void btnInventario_Click(object sender, RoutedEventArgs e)
        {
            AdminInventario inventario = new AdminInventario();
            inventario.Show();
        }

        private void btnEgresos_Click(object sender, RoutedEventArgs e)
        {
            IngresoEgreso ingresoEgreso = new IngresoEgreso();
            ingresoEgreso.Show();
        }
    }
}
