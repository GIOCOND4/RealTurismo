using MahApps.Metro.Controls;
using System.Windows;

namespace RealTurismo
{
    /// <summary>
    /// Lógica de interacción para AdminUsuario.xaml
    /// </summary>
    public partial class AdminUsuario : MetroWindow
    {
        public AdminUsuario()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
