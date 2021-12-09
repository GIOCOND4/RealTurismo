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
    /// Lógica de interacción para AdminInventarioDepto.xaml
    /// </summary>
    public partial class AdminInventarioDepto : Window
    {
        ControllerListaInventarioDpto cid = new ControllerListaInventarioDpto();
        
        public AdminInventarioDepto(string idDepto, string nombreDepto, string numeroDepto)
        {
            InitializeComponent();
            lbl_idDepto.Content = idDepto;
            txt_nombreDepto.Text = nombreDepto;
            txt_numeroDepto.Text = numeroDepto;

            dg_listadoInventario.ItemsSource = cid.ListarInventario(idDepto);
            
        }

        private void btnAtras_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void dg_listadoInventario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InventarioDepto2 inventario = (InventarioDepto2)dg_listadoInventario.SelectedItem;
            if (dg_listadoInventario.SelectedItem != null)
            {
                txt_cantidad.Text = inventario.cantidad.ToString();
                lbl_idInventario.Content = inventario.id.ToString();
                lbl_dañado.Content = inventario.dañado.ToString();                
            }
        }

        private void btn_editar_Click(object sender, RoutedEventArgs e)
        {           
            int cantidad = int.Parse(txt_cantidad.Text);
            int idInventario = int.Parse(lbl_idInventario.Content.ToString());
            int idDepartamento = int.Parse(lbl_idDepto.Content.ToString());
            string dañado = lbl_dañado.Content.ToString();
            string idDepto = lbl_idDepto.Content.ToString();            

            try
            {
                if (cantidad > 0 && dg_listadoInventario.ItemsSource != null && dañado == "NO")
                {
                    int editar = cid.EditarCantidad(idInventario, idDepartamento, cantidad);

                    if (editar == 1)
                    {
                        MessageBox.Show("La cantidad del inventario fue actualizada de forma correcta");
                        
                    }
                    else
                    {
                        MessageBox.Show("La cantidad no puede ser 0 o superar el stock disponible del inventario");
                    }

                    dg_listadoInventario.ItemsSource = cid.ListarInventario(idDepto);
                }
                else
                {
                    MessageBox.Show("No fue posible editar el objeto seleccionado");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Ocurrió un error");
            }
           
        }

        
    }
}
