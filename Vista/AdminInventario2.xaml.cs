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
    /// Lógica de interacción para AdminInventario2.xaml
    /// </summary>
    public partial class AdminInventario2 : Window
    {
        ControllerInventario2 ci2 = new ControllerInventario2();
        
        public AdminInventario2()
        {
            InitializeComponent();
            dg_mantInventario2.ItemsSource = ci2.ListarTodos();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_buscarInventario_Click(object sender, RoutedEventArgs e)
        {
            string objeto = txt_nombre.Text;

            if (objeto == "")
            {
                dg_mantInventario2.ItemsSource = ci2.ListarTodos();
            }
            else
            {
                dg_mantInventario2.ItemsSource = ci2.ListarPorNombre(objeto);
            }
        }

        private void btn_agregarInventario_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Inventario2 inventario = new Inventario2();

                inventario.nombreCorto = txt_nombre.Text;
                inventario.descripcion = txt_descripcion.Text;
                inventario.costo = long.Parse(txt_costo.Text);
                inventario.cantidad = int.Parse(txt_cantidad.Text);

                bool añadir = ci2.AgregarInventario(inventario);
                if (añadir == true)
                {
                    MessageBox.Show("El objeto fue añadido correctamente");

                    txt_cantidad.Text = "0";
                    txt_costo.Text = "0";
                    txt_descripcion.Text = "";
                    txt_nombre.Text = "";
                    lbl_id.Content = "Id";
                }
                else
                {
                    MessageBox.Show("No fue posible añadir el objeto al inventario");
                }

                dg_mantInventario2.ItemsSource = ci2.ListarTodos();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Ocurrió un error al intentar añadir el objeto: " +ex.Message);
            }
        }

        private void dg_mantInventario2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InventarioListar inventario = (InventarioListar)dg_mantInventario2.SelectedItem;
            if (dg_mantInventario2.SelectedItem != null)
            {
                txt_cantidad.Text = inventario.stock.ToString();
                txt_costo.Text = inventario.costo.ToString();
                txt_descripcion.Text = inventario.descripcion.ToString();
                txt_nombre.Text = inventario.nombre.ToString();
                lbl_id.Content = inventario.id.ToString();
            }
        }

        private void btn_eliminarInventario_Click(object sender, RoutedEventArgs e)
        {
            string idInventario = lbl_id.Content.ToString();

            if (idInventario == "Id")
            {
                MessageBox.Show("Debe seleccionar un ítem del inventario de la lista antes de eliminar.");
            }
            else
            {
                if (MessageBox.Show("¿Esta seguro que desea eliminar el elemento seleccionado?", "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    MessageBox.Show("La eliminación fue cancelada.");
                }
                else
                {
                    try
                    {
                        int eliminar = ci2.EliminarInventario(idInventario);

                        if (eliminar==1)
                        {
                            MessageBox.Show("El objeto fue eliminado correctamente.");

                            txt_cantidad.Text = "0";
                            txt_costo.Text = "0";
                            txt_descripcion.Text = "";
                            txt_nombre.Text = "";
                            lbl_id.Content = "Id";
                            
                        }
                        else
                        {
                            MessageBox.Show("El objeto no puede ser eliminado porque está asociado a un departamento. Favor, elimine todos los elementos asociados a departamentos antes de eliminar este objeto.");
                            
                            txt_cantidad.Text = "0";
                            txt_costo.Text = "0";
                            txt_descripcion.Text = "";
                            txt_nombre.Text = "";
                            lbl_id.Content = "Id";
                        }
                                                
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Ocurrió un error al eliminar el objeto: "+ex.Message);                       
                        
                    }

                    dg_mantInventario2.ItemsSource = ci2.ListarTodos();
                }
            }
        }

        private void btn_editarInventario_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Inventario2 inventario = new Inventario2();

                inventario.nombreCorto = txt_nombre.Text;
                inventario.descripcion = txt_descripcion.Text;
                inventario.costo = long.Parse(txt_costo.Text);
                inventario.cantidad = int.Parse(txt_cantidad.Text);
                inventario.id = int.Parse(lbl_id.Content.ToString());

                bool editar = ci2.EditarInventario(inventario);
                if (editar == true)
                {
                    MessageBox.Show("El objeto fue actualizado.");

                    txt_cantidad.Text = "0";
                    txt_costo.Text = "0";
                    txt_descripcion.Text = "";
                    txt_nombre.Text = "";
                    lbl_id.Content = "Id";
                }
                else
                {
                    MessageBox.Show("No fue posible actualizar el objeto");
                }

                dg_mantInventario2.ItemsSource = ci2.ListarTodos();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Ocurrió un error al intentar actualizar el objeto: " + ex.Message);
            }
        }
    }
}
