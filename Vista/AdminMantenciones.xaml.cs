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
    /// Lógica de interacción para AdminMantenciones.xaml
    /// </summary>
    public partial class AdminMantenciones : MetroWindow
    {
        int idmantencion = 0;
        public AdminMantenciones()
        {
            InitializeComponent();
            OracleConnection conexionOracle = new ConexionOracle().abrirConexion();
            string query = "SELECT NOMBRE FROM TIPO_MANTENCION";
            OracleCommand Comando = new OracleCommand(query, conexionOracle);
            OracleDataReader lector = Comando.ExecuteReader();
            while (lector.Read())
            {
                cbbTipo.Items.Add(lector["NOMBRE"].ToString());
            }
            cbbTipo.SelectedIndex = 0;
            ControllerMantencion mante = new ControllerMantencion();
            dgListadoMan.ItemsSource = mante.ListarMantencion();
        }

        private void btnSalirs_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Mantencion manten = new Mantencion();
                manten.FechaRegistro = DateTime.Parse(txtFechaRegistro.Text);
                manten.FechaMantencion = DateTime.Parse(txtFechaMantencion.Text);
                manten.Descripcion = txtDescripcion.Text;
                manten.Costo = long.Parse(txtCosto.Text);
                ListarMantenciones lisman = new ListarMantenciones();
                lisman.IdDepartamento = int.Parse(txtIDDepartamento.Text);
                ControllerMantencion Controlmanten = new ControllerMantencion();
                string tipomantencion = cbbTipo.SelectedItem.ToString();
                int id = Controlmanten.BuscarTipoMantencion(tipomantencion);
                if (id > 0)
                {
                    bool añadir = Controlmanten.AgregarMantencion(manten.FechaRegistro, manten.FechaMantencion, manten.Descripcion, manten.Costo, id, lisman.IdDepartamento);
                    if (añadir == true)
                    {
                        MessageBox.Show("La mantencion ha sido ingresado con exito");
                        txtFechaMantencion.Text = "";
                        txtFechaRegistro.Text = "";
                        txtIDDepartamento.Text = "";
                        txtDescripcion.Text = "";
                        txtCosto.Text = "";
                        cbbTipo.SelectedIndex = 0;
                    }
                }
                else
                {
                    MessageBox.Show("No se pudo ingresar la mantencion");
                }

                dgListadoMan.ItemsSource = Controlmanten.ListarMantencion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void btnBuscarIdDepto_Click(object sender, RoutedEventArgs e)
        {
            string id = txtBuscarID.Text;
            if (id == "")
            {
                ControllerMantencion mante = new ControllerMantencion();
                dgListadoMan.ItemsSource = mante.ListarMantencion();
            }
            else
            {
                ControllerMantencion mante = new ControllerMantencion();
                dgListadoMan.ItemsSource = mante.ListarMantencionID(int.Parse(id));
            }
        }

        private void dgListadoMan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Mantencion man = (Mantencion)dgListadoMan.SelectedItem;
            if (dgListadoMan.SelectedItem != null)
            {
                txtCosto.Text = man.Costo.ToString();
                txtDescripcion.Text = man.Descripcion.ToString();
                txtFechaRegistro.Text = man.FechaRegistro.ToString();
                txtFechaMantencion.Text = man.FechaMantencion.ToString();
                cbbTipo.SelectedIndex = 0;
                idmantencion = man.IdMantencion;
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = idmantencion;
                if (MessageBox.Show("¿Esta seguro que desea eliminar la siguente mantencion? : " + id, "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    MessageBox.Show("Operacion Abortada");
                }
                else
                {
                    ControllerMantencion controlmantenedor = new ControllerMantencion();
                    bool eliminar = controlmantenedor.eliminarMantencion(id);
                    if (eliminar == true)
                    {
                        MessageBox.Show("La mantencion ha sido eliminada con exito");
                        txtFechaMantencion.Text = "";
                        txtFechaRegistro.Text = "";
                        txtIDDepartamento.Text = "";
                        txtDescripcion.Text = "";
                        txtCosto.Text = "";
                        cbbTipo.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar la mantencion");
                    }
                    dgListadoMan.ItemsSource = controlmantenedor.ListarMantencion();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Mantencion manten = new Mantencion();
                manten.IdMantencion = idmantencion;
                manten.FechaRegistro = DateTime.Parse(txtFechaRegistro.Text);
                manten.FechaMantencion = DateTime.Parse(txtFechaMantencion.Text);
                manten.Descripcion = txtDescripcion.Text;
                manten.Costo = long.Parse(txtCosto.Text);
                ListarMantenciones lisman = new ListarMantenciones();
                lisman.IdDepartamento = int.Parse(txtIDDepartamento.Text);
                ControllerMantencion Controlmanten = new ControllerMantencion();
                string tipomantencion = cbbTipo.SelectedItem.ToString();
                int id = Controlmanten.BuscarTipoMantencion(tipomantencion);
                if (id > 0)
                {
                    if (MessageBox.Show("¿Esta seguro que desea modificar el siguiente departamento? : " + manten.IdMantencion, "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        bool modificar = Controlmanten.ModificarMantencion(manten.IdMantencion, manten.FechaRegistro, manten.FechaMantencion, manten.Descripcion, manten.Costo, id, lisman.IdDepartamento);
                        if (modificar == true)
                        {
                            MessageBox.Show("La mantencion ha sido editada con exito");
                            txtFechaMantencion.Text = "";
                            txtFechaRegistro.Text = "";
                            txtIDDepartamento.Text = "";
                            txtDescripcion.Text = "";
                            txtCosto.Text = "";
                            cbbTipo.SelectedIndex = 0;
                        }
                        else
                        {
                            MessageBox.Show("No se pudo editar la mantencion");
                        }
                        dgListadoMan.ItemsSource = Controlmanten.ListarMantencion();
                    }
                    else
                    {
                        MessageBox.Show("Operacion abortada");
                    }
                    
                }
                else
                {
                    MessageBox.Show("No se pudo ingresar la mantencion");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }
    }
}
