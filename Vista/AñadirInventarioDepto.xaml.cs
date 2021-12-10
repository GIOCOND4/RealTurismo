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
using BibliotecaModelo;

namespace Vista
{
    /// <summary>
    /// Lógica de interacción para AñadirInventarioDepto.xaml
    /// </summary>
    public partial class AñadirInventarioDepto : Window
    {
        ControllerInventario2 ci2 = new ControllerInventario2();
        ControllerListaInventarioDpto clid = new ControllerListaInventarioDpto();
        
        public AñadirInventarioDepto(string idDepto)
        {
            InitializeComponent();

            lbl_idDepto.Content = idDepto;
            dg_inventarioDispo.ItemsSource = ci2.ListarTodos();
        }

        private void btnAtras_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dg_inventarioDispo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InventarioListar inventario = (InventarioListar)dg_inventarioDispo.SelectedItem;
            if (dg_inventarioDispo.SelectedItem != null)
            {
                txt_cantidad.Text = inventario.stock.ToString();
                lbl_idInventario.Content = inventario.id.ToString();
                
            }
        }

        private void btn_BuscarInventario_Click(object sender, RoutedEventArgs e)
        {
            string objeto = txt_nombreInventario.Text;

            if (objeto == "")
            {
                dg_inventarioDispo.ItemsSource = ci2.ListarTodos();
            }
            else
            {
                dg_inventarioDispo.ItemsSource = ci2.ListarPorNombre(objeto);
            }
        }

        private void btn_agregar_Click(object sender, RoutedEventArgs e)
        {
            string idDepto = lbl_idDepto.Content.ToString();
            string idInventario = lbl_idInventario.Content.ToString();
            string cantidad = txt_cantidad.Text;

            try
            {
                if (cantidad != "0")
                {
                    bool agregar = clid.AñadirInventarioDepto(idDepto, idInventario, cantidad);
                    if (agregar)
                    {
                        MessageBox.Show("El elemento fue agregado al inventario del departamento.");
                        cantidad = "0";
                    }
                    else
                    {
                        MessageBox.Show("No fue posible añadir el objeto al inventario. El objeto ya pertenece al inventario del departamento o la cantidad supera el stock disponible.");
                    }
                }
                else
                {
                    MessageBox.Show("Debe ingresar una cantidad mayor a 0 para agregar el objeto al departamento.");
                }
                dg_inventarioDispo.ItemsSource = ci2.ListarTodos();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Ocurrió un error inesperado al intentar añadir el objeto al departamento.");
            }
            
        }
    }
}
