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
    }
}
