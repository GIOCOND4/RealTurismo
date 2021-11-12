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

namespace Vista
{
    /// <summary>
    /// Lógica de interacción para AdminDepartamentos.xaml
    /// </summary>
    public partial class AdminDepartamentos : MetroWindow
    {
        public AdminDepartamentos()
        {
            InitializeComponent();

            OracleConnection conexionOracle = new ConexionOracle().abrirConexion();
            string query = "SELECT Descripcion FROM REGION";
            OracleCommand Comando = new OracleCommand(query, conexionOracle);
            OracleDataReader lector = Comando.ExecuteReader();
            while (lector.Read())
            {
                cbbRegion.Items.Add(lector["Descripcion"].ToString());
            }
            cbbRegion.SelectedIndex = 0;
            cbbProvincia.SelectedIndex = 0;
            cbbComuna.SelectedIndex = 0;
            //habrá que cerrar la conexión? ...........
        }

        //BuscarDepartamentos
        private void btnBuscarIdDepto_Click(object sender, RoutedEventArgs e)
        {
            string iddepto = txtIdDepto.Text;
            if (iddepto == "")
            {
                ControllerDepartamento depto = new ControllerDepartamento();
                dgListadoDep.ItemsSource = depto.ListarDepartamentos();
            }
            else
            {
                ControllerDepartamento depto = new ControllerDepartamento();
                dgListadoDep.ItemsSource = depto.ListarDeptoID(int.Parse(iddepto));
            }

        }
        private void dgListadoDep_SelectionChanged(object sender, SelectionChangedEventArgs e) //<-----------------se debe hacer con procedimientos almacenados
        {
            /*Modelo.Departamentos depto = (Modelo.Departamentos)dgListadoDep.SelectedItem;
            if (dgListadoDep.SelectedItem != null)
            {
                txtIdDepto.Text = depto.IdDepartamento.ToString();
                txtNombre.Text = depto.NombreDescriptivo.ToString();
                txtDireccion.Text = depto.Direccion.ToString();
                txtCosto.Text = depto.Costo.ToString();
                txtPiso.Text = depto.Piso.ToString();
                if (depto.Cable == false)
                {
                    cbCable.IsChecked = false;
                }
                else
                {
                    cbCable.IsChecked = true;
                }
                if (depto.Internet == false)
                {
                    cbInternet.IsChecked = false;
                }
                else
                {
                    cbInternet.IsChecked = true;
                }
                if (depto.Calefaccion == false)
                {
                    cbCalefaccion.IsChecked = false;
                }
                else
                {
                    cbCalefaccion.IsChecked = true;
                }
                if (depto.Amoblado == false)
                {
                    cbAmoblado.IsChecked = false;
                }
                else
                {
                    cbAmoblado.IsChecked = true;
                }
                if (depto.AireAcondiconado == false)
                {
                    cbAireAcondicionado.IsChecked = false;
                }
                else
                {
                    cbAireAcondicionado.IsChecked = true;
                }
                if (depto.Balcon == false)
                {
                    cbBalcon.IsChecked = false;
                }
                else
                {
                    cbBalcon.IsChecked = true;
                }
                txtNHabitaciones.Text = depto.NroHabitaciones.ToString();
                txtNBanios.Text = depto.NroBanios.ToString();
                txtNPersonas.Text = depto.CantidadPersonas.ToString();
                if (depto.Disponible == false)
                {
                    cbDisponible.IsChecked = false;
                }
                else
                {
                    cbDisponible.IsChecked = true;
                }
                cbbRegion.SelectedIndex = 0;

            }*/
        }

        private void cbbRegion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbbProvincia.DataContext = null;
            cbbProvincia.Items.Clear();

            OracleConnection conexionOracle = new ConexionOracle().abrirConexion();

            string region = cbbRegion.SelectedItem.ToString();
            //cargar provincia
            string query2 = $"select p.descripcion from provincia p " +
                        "inner join region r " +
                        "on r.id_region = p.id_region " +
                        "where r.descripcion = '" + region + "'";
            OracleCommand Comando2 = new OracleCommand(query2, conexionOracle);
            OracleDataReader lector2 = Comando2.ExecuteReader();
            while (lector2.Read())
            {
                cbbProvincia.Items.Add(lector2["Descripcion"].ToString());
            }

            cbbProvincia.SelectedIndex = 0;

            //cbbProvincia.SelectedItem = "";

        }

        // Actualizar lista de provincias
        private void cbbProvincia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbbComuna.DataContext = null;
            cbbComuna.Items.Clear();

            OracleConnection conexionOracle = new ConexionOracle().abrirConexion();

            if (cbbProvincia.SelectedItem != null)
            {
                string provincia = cbbProvincia.SelectedItem.ToString();
                //cargar comunas
                string query3 = $"select c.descripcion from comuna c " +
                                "inner join provincia p " +
                                "on p.id_provincia = c.id_provincia " +
                                "where p.descripcion = '" + provincia + "'";
                OracleCommand Comando3 = new OracleCommand(query3, conexionOracle);
                OracleDataReader lector3 = Comando3.ExecuteReader();
                while (lector3.Read())
                {
                    cbbComuna.Items.Add(lector3["Descripcion"].ToString());
                }
            }
            cbbComuna.SelectedIndex = 0;
            ControllerDepartamento depto = new ControllerDepartamento();
            dgListadoDep.ItemsSource = depto.ListarDepartamentos();
        }


        private void btnAgregar_Click(object sender, RoutedEventArgs e) //<-----------------se debe hacer con procedimientos almacenados
        {
            /*try
            {
                Modelo.Departamentos depto = new Modelo.Departamentos();
                depto.NombreDescriptivo = txtNombre.Text;
                depto.Direccion = txtDireccion.Text;
                depto.Costo = int.Parse(txtCosto.Text);
                depto.Piso = int.Parse(txtPiso.Text);
                int cable = 0;
                int internet = 0;
                int calefaccion = 0;
                int amoblado = 0;
                int aire = 0;
                int balcon = 0;
                int disponible = 0;
                if (cbCable.IsChecked == true)
                {
                    cable = 1;
                }
                if (cbInternet.IsChecked == true)
                {
                    internet = 1;
                }
                if (cbCalefaccion.IsChecked == true)
                {
                    calefaccion = 1;
                }
                if (cbAmoblado.IsChecked == true)
                {
                    amoblado = 1;
                }
                if (cbAireAcondicionado.IsChecked == true)
                {
                    aire = 1;
                }
                if (cbBalcon.IsChecked == true)
                {
                    balcon = 1;
                }
                depto.NroHabitaciones = int.Parse(txtNHabitaciones.Text);
                depto.NroBanios = int.Parse(txtNBanios.Text);
                depto.CantidadPersonas = int.Parse(txtNPersonas.Text);
                if (cbDisponible.IsChecked == true)
                {
                    disponible = 1;
                }
                string comuna = cbbComuna.SelectedItem.ToString();
                OracleConnection conexionOracle = new OracleConnection(cadenaConexionOracle);
                conexionOracle.Open();
                string buscarIdComuna = "select id_comuna from comuna " +
                    "where descripcion = '" + comuna + "'";
                OracleCommand Comando = new OracleCommand(buscarIdComuna, conexionOracle);
                OracleDataReader buscarID = Comando.ExecuteReader();
                if (buscarID.Read())
                {
                    int id = int.Parse(buscarID.GetString(0));
                    ControllerDepartamento ControlDepto = new ControllerDepartamento();
                    bool añadir = ControlDepto.AñadirDepto(depto.NombreDescriptivo, depto.Direccion, depto.Piso, depto.Costo,
                        cable, internet, calefaccion, amoblado, aire, balcon, depto.NroHabitaciones,
                        depto.NroBanios, depto.CantidadPersonas, disponible, id);
                    if (añadir == true)
                    {
                        MessageBox.Show("El departamento ha sido ingresado con exito");
                        txtIdDepto.Text = "";
                        txtNombre.Text = "";
                        txtDireccion.Text = "";
                        txtCosto.Text = "";
                        txtPiso.Text = "";
                        cbCable.IsChecked = false;
                        cbInternet.IsChecked = false;
                        cbCalefaccion.IsChecked = false;
                        cbAmoblado.IsChecked = false;
                        cbAireAcondicionado.IsChecked = false;
                        cbBalcon.IsChecked = false;
                        txtNHabitaciones.Text = "";
                        txtNBanios.Text = "";
                        txtNPersonas.Text = "";
                        cbDisponible.IsChecked = false;
                        cbbComuna.DataContext = null;
                        cbbComuna.Items.Clear();
                        cbbProvincia.DataContext = null;
                        cbbProvincia.Items.Clear();
                        cbbRegion.SelectedIndex = 0;
                        cbbProvincia.SelectedIndex = 0;
                        cbbComuna.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("No se pudo ingresar el departamento");
                    }

                    dgListadoDep.ItemsSource = ControlDepto.ListarDepartamentos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }*/
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e) //<-----------------se debe hacer con procedimientos almacenados
        {
            try
            {
                int id = int.Parse(txtIdDepto.Text);
                if (MessageBox.Show("¿Esta seguro que desea eliminar el siguiente departamento? : " + id, "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    MessageBox.Show("Operacion Abortada");
                }
                else
                {
                    ControllerDepartamento ControlDepto = new ControllerDepartamento();
                    bool eliminar = ControlDepto.EliminarDepto(id);
                    if (eliminar == true)
                    {
                        txtIdDepto.Text = "";
                        txtNombre.Text = "";
                        txtDireccion.Text = "";
                        txtCosto.Text = "";
                        txtPiso.Text = "";
                        cbCable.IsChecked = false;
                        cbInternet.IsChecked = false;
                        cbCalefaccion.IsChecked = false;
                        cbAmoblado.IsChecked = false;
                        cbAireAcondicionado.IsChecked = false;
                        cbBalcon.IsChecked = false;
                        txtNHabitaciones.Text = "";
                        txtNBanios.Text = "";
                        txtNPersonas.Text = "";
                        cbDisponible.IsChecked = false;
                        cbbComuna.DataContext = null;
                        cbbComuna.Items.Clear();
                        cbbProvincia.DataContext = null;
                        cbbProvincia.Items.Clear();
                        cbbRegion.SelectedIndex = 0;
                        cbbProvincia.SelectedIndex = 0;
                        cbbComuna.SelectedIndex = 0;
                        MessageBox.Show("El departamento escogido fue eliminado con exito");
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el departamento");
                    }



                    dgListadoDep.ItemsSource = ControlDepto.ListarDepartamentos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }
    }
}
