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
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using MahApps.Metro.Controls;

namespace RealTurismo.Vistas
{
    /// <summary>
    /// Lógica de interacción para AdministrarDepartamentos.xaml
    /// </summary>
    public partial class AdministrarDepartamentos : MetroWindow
    {
        string cadenaConexionOracle = "Data source=" +
                "(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)" +
                "(HOST=localhost)(PORT=1521))" +
                "(CONNECT_DATA=(SERVICE_NAME=TurismoReal)));" +
                "User Id = ADMINISTRADOR; Password = admin;";
        public AdministrarDepartamentos()
        {
            InitializeComponent();

            OracleConnection conexionOracle = new OracleConnection(cadenaConexionOracle);

            conexionOracle.Open();
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
        }
        //BuscarDepartamentos
        private void btnBuscarIdDepto_Click(object sender, RoutedEventArgs e)
        {
            string iddepto = txtIdDepto.Text;
            if (iddepto == "")
            {
                Controlador.ControladorDepartamento depto = new Controlador.ControladorDepartamento();
                dgListadoDep.ItemsSource = depto.ListarDepartamentos();
            }

        }
        private void dgListadoDep_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cbbRegion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbbProvincia.DataContext = null;
            cbbProvincia.Items.Clear();

            //Crear conexion
            OracleConnection conexionOracle = new OracleConnection(cadenaConexionOracle);
            // Conecta
            conexionOracle.Open();


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

            //Crear conexion
            OracleConnection conexionOracle = new OracleConnection(cadenaConexionOracle);
            // Conecta
            conexionOracle.Open();
            if (cbbProvincia.SelectedItem != null)
            {
                string provincia = cbbProvincia.SelectedItem.ToString();
                //cargar comunas
                string query3 = $"select c.descripcion from comuna c " +
                                "inner join provincia p " +
                                "on p.id_provincia = c.iid_provincia " +
                                "where p.descripcion = '" + provincia + "'";
                OracleCommand Comando3 = new OracleCommand(query3, conexionOracle);
                OracleDataReader lector3 = Comando3.ExecuteReader();
                while (lector3.Read())
                {
                    cbbComuna.Items.Add(lector3["Descripcion"].ToString());
                }
            }
            cbbComuna.SelectedIndex = 0;
            Controlador.ControladorDepartamento depto = new Controlador.ControladorDepartamento();
            dgListadoDep.ItemsSource = depto.ListarDepartamentos();
        }

        private void cbbRegion_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
