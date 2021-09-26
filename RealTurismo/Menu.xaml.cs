using MahApps.Metro.Controls;
using System.Windows;

namespace RealTurismo
{
    /// <summary>
    /// Lógica de interacción para Menu.xaml
    /// </summary>
    public partial class Menu : MetroWindow
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnDepartamento_Click(object sender, RoutedEventArgs e)
        {
            MantDepartamento depto = new MantDepartamento();
            depto.Show();
        }

        private void btnIngresos_Click(object sender, RoutedEventArgs e)
        {
            VisualizarIngresos verIngreso = new VisualizarIngresos();
            verIngreso.Show();
        }
    }
}
