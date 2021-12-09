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
using Conexion;
using BibliotecaControlador;
using Oracle.ManagedDataAccess.Client;
using BibliotecaModelo;

namespace Vista
{
    /// <summary>
    /// Lógica de interacción para AdminInventario.xaml
    /// </summary>
    public partial class AdminInventario : MetroWindow
    {
        Inventario inv = new Inventario();
        ControllerInventario controlinv = new ControllerInventario();
        ListaInventario lisinv = new ListaInventario();
        int idinventario = 0;
        
        public AdminInventario()
        {
            
            InitializeComponent();
            dg_listadoInventario.ItemsSource = controlinv.ListarInventario();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_agregarInventario_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                inv.Codigo = txt_codigoInventario.Text;
                inv.Nombre = txt_nombreInventario.Text;
                inv.Costo = long.Parse(txt_costoInventario.Text);
                inv.Descripcion = txt_descripcion.Text;
                int activo = 0;
                if (cbDisponible.IsChecked == true)
                {
                    activo = 1;
                }
                lisinv.IdDepartamento = int.Parse(txt_idDepartamento.Text);
                bool añadir = controlinv.AgregarInventario(inv.Codigo, inv.Nombre, inv.Costo, inv.Descripcion,activo, lisinv.IdDepartamento);
                if (añadir == true)
                {
                    MessageBox.Show("El inventario ha sido añadido con exito");
                    txt_codigoInventario.Text = "";
                    txt_nombreInventario.Text = "";
                    txt_costoInventario.Text = "";
                    txt_descripcion.Text = "";
                    cbDisponible.IsChecked = false;
                    txt_idDepartamento.Text = "";
                    idinventario = 0;
                }
                else
                {
                    MessageBox.Show("No se ha podido añadir el inventario");
                }
                dg_listadoInventario.ItemsSource = controlinv.ListarInventario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void dg_listadoInventario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InventarioPorDepto li = (InventarioPorDepto)dg_listadoInventario.SelectedItem;
            if (dg_listadoInventario.SelectedItem != null)
            {
                txt_codigoInventario.Text = li.Codigo.ToString();
                txt_costoInventario.Text = li.Costo.ToString();
                txt_descripcion.Text = li.Descripcion.ToString();
                txt_idDepartamento.Text = li.IdDepartamento.ToString();
                txt_nombreInventario.Text = li.Nombre.ToString();
                if (li.Disponible == false)
                {
                    cbDisponible.IsChecked = false;
                }
                else
                {
                    cbDisponible.IsChecked = true;
                }
                idinventario = li.IdInventario;
            }
        }

        private void btn_buscarIdDepartamento_Click(object sender, RoutedEventArgs e)
        {
            string valor = txt_idDepartamentoBuscar.Text;
            if(valor != "")
            {
                dg_listadoInventario.ItemsSource = controlinv.ListarInventarioPorId(int.Parse(valor));
            }
            else
            {
                dg_listadoInventario.ItemsSource = controlinv.ListarInventario();
            }
        }

        private void btn_eliminarInventario_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = idinventario;
                if (MessageBox.Show("¿Esta seguro que desea eliminar el siguiente inventario? : " + id, "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    MessageBox.Show("Operacion Abortada");
                }
                else
                {
                    bool eliminar = controlinv.EliminarInventario(id);
                    if (eliminar == true)
                    {
                        MessageBox.Show("El inventario ha sido eliminado con exito");
                        txt_codigoInventario.Text = "";
                        txt_nombreInventario.Text = "";
                        txt_costoInventario.Text = "";
                        txt_descripcion.Text = "";
                        cbDisponible.IsChecked = false;
                        txt_idDepartamento.Text = "";
                        idinventario = 0;
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido eliminar el inventario");
                    }
                }
                dg_listadoInventario.ItemsSource = controlinv.ListarInventario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void btn_editarInventario_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                inv.Codigo = txt_codigoInventario.Text;
                inv.Nombre = txt_nombreInventario.Text;
                inv.Costo = long.Parse(txt_costoInventario.Text);
                inv.Descripcion = txt_descripcion.Text;
                int activo = 0;
                if (cbDisponible.IsChecked == true)
                {
                    activo = 1;
                }
                lisinv.IdDepartamento = int.Parse(txt_idDepartamento.Text);
                if (MessageBox.Show("¿Esta seguro que desea modificar el siguiente inventario? : " + idinventario, "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    bool editar = controlinv.EditarInventario(idinventario, inv.Codigo, inv.Nombre, inv.Costo, inv.Descripcion, activo, lisinv.IdDepartamento);
                    if (editar == true)
                    {
                        MessageBox.Show("El inventario ha sido añadido con exito");
                        txt_codigoInventario.Text = "";
                        txt_nombreInventario.Text = "";
                        txt_costoInventario.Text = "";
                        txt_descripcion.Text = "";
                        cbDisponible.IsChecked = false;
                        txt_idDepartamento.Text = "";
                        idinventario = 0;
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido editar el inventario");
                    }
                    dg_listadoInventario.ItemsSource = controlinv.ListarInventario();
                }
                else
                {
                    MessageBox.Show("Operacion abortada");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }
    }
}
