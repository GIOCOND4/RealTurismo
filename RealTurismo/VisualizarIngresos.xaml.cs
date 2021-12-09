using MahApps.Metro.Controls;
using System.Windows;

namespace RealTurismo
{
    /// <summary>
    /// Lógica de interacción para VisualizarIngresos.xaml
    /// </summary>
    public partial class VisualizarIngresos : MetroWindow
    {
        public VisualizarIngresos()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
