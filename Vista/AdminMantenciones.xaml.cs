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
    /// Lógica de interacción para AdminMantenciones.xaml
    /// </summary>
    public partial class AdminMantenciones : MetroWindow
    {
        public AdminMantenciones()
        {
            InitializeComponent();
        }

        private void btnSalirs_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
