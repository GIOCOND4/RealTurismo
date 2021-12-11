using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Lógica de interacción para MenuAdministrador.xaml
    /// </summary>
    public partial class MenuAdministrador : MetroWindow
    {
        public MenuAdministrador()
        {
            InitializeComponent();
        }

        private void btnDepartamento_Click(object sender, RoutedEventArgs e)
        {
            AdminDepartamentos depto = new AdminDepartamentos();
            depto.Show();
        }

        private void btnAUsuario_Click(object sender, RoutedEventArgs e)
        {
            AdminUsuario usuario = new AdminUsuario();
            usuario.Show();
        }

        private void btnServicios_Click(object sender, RoutedEventArgs e)
        {
            AdminServicios servicios = new AdminServicios();
            servicios.Show();
        }

        private void btnMantenciones_Click(object sender, RoutedEventArgs e)
        {
            AdminMantenciones mantenciones = new AdminMantenciones();
            mantenciones.Show();

        }

        private void btnInventario_Click(object sender, RoutedEventArgs e)
        {
            AdminInventario2 inventario = new AdminInventario2();
            inventario.Show();
        }

        private void btnInforme_Click(object sender, RoutedEventArgs e)
        {
            //Ruta de ubicación del ejecutable del aplicativo reportes
            string ruta = "C:/Users/ELISE/source/repos/Reportes/Reportes/bin/Debug/Reportes.exe";
            Process.Start(ruta);
        }

        private void btnIngresos_Click(object sender, RoutedEventArgs e)
        {
            IngresoEgreso ingresoEgreso = new IngresoEgreso();
            ingresoEgreso.Show();
        }

        private void btnEgresos_Click(object sender, RoutedEventArgs e)
        {
            IngresoEgreso ingresoEgreso = new IngresoEgreso();
            ingresoEgreso.Show();
        }
    }
        
}

