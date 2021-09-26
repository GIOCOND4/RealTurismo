using MahApps.Metro.Controls;
using System.Windows;

namespace RealTurismo
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

        private void btnADepartamentos_Click(object sender, RoutedEventArgs e)
        {
            MantDepartamento depto = new MantDepartamento();
            depto.Show();
        }

        private void btnAUsuario_Click(object sender, RoutedEventArgs e)
        {
            AdminUsuario admiUsu = new AdminUsuario();
            admiUsu.Show();
        }

        private void btnAIngresos_Click(object sender, RoutedEventArgs e)
        {
            VisualizarIngresos ingresos = new VisualizarIngresos();
            ingresos.Show();
        }
    }
}
