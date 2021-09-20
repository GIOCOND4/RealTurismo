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
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace RealTurismo
{
    /// <summary>
    /// Lógica de interacción para MantDepartamento.xaml
    /// </summary>
    public partial class MantDepartamento : MetroWindow
    {
        //el servicename es el nombre de la base de datos
        //por defecto es orcl
        string cadenaConexionOracle = "Data source=" +
                "(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)" +
                "(HOST=localhost)(PORT=1521))" +
                "(CONNECT_DATA=(SERVICE_NAME=TurismoReal)));" +
                "User Id = ADMINISTRADOR; Password = admin;";

        public MantDepartamento()
        {
            InitializeComponent();

            //Crear conexion
            OracleConnection conexionOracle = new OracleConnection(cadenaConexionOracle);
            // Conecta
            conexionOracle.Open();

            //cargar region
            string query = "SELECT Descripcion FROM REGION";
            OracleCommand Comando = new OracleCommand(query, conexionOracle);
            OracleDataReader lector = Comando.ExecuteReader();
            while (lector.Read())
            {
                cbbRegion.Items.Add(lector["Descripcion"].ToString());
            }

            
        }

        private void cbbRegion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
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
            
        }
        
        private void cbbProvincia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbbComuna.DataContext = null;
            cbbComuna.Items.Clear();

            //Crear conexion
            OracleConnection conexionOracle = new OracleConnection(cadenaConexionOracle);
            // Conecta
            conexionOracle.Open();
            string provincia = cbbProvincia.SelectedItem.ToString();
            //cargar comunas
            string query3 = $"select c.descripcion from comuna c "+
                            "inner join provincia p "+
                            "on p.id_provincia = c.iid_provincia "+
                            "where p.descripcion = '"+ provincia + "'";
            OracleCommand Comando3 = new OracleCommand(query3, conexionOracle);
            OracleDataReader lector3 = Comando3.ExecuteReader();
            while (lector3.Read())
            {
                cbbComuna.Items.Add(lector3["Descripcion"].ToString());
            }
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            //obtener datos
            string nombre = txtNombre.Text;
            string direccion = txtDireccion.Text;
            string costo = txtCosto.Text;
            string piso = txtPiso.Text;
            string cable = "0";
            string internet = "0";
            string calefaccion = "0";
            string amoblado = "0";
            string aire = "0";
            string balcon = "0";
            string disponible = "0";
            if (cbCable.IsChecked == true)
            {
                cable = "1";
            }
            if (cbInternet.IsChecked == true)
            {
                internet = "1";
            }
            if (cbCalefaccion.IsChecked == true)
            {
                calefaccion = "1";
            }
            if (cbAmoblado.IsChecked == true)
            {
                amoblado = "1";
            }
            if (cbAire.IsChecked == true)
            {
                aire = "1";
            }
            if (cbBalcon.IsChecked == true)
            {
                balcon = "1";
            }
            string nrohabitaciones = txtNHabitaciones.Text;
            string nrobaios = txtNBanios.Text;
            string nroPersonas = txtNPersonas.Text;
            if (cbDisponible.IsChecked == true)
            {
                disponible = "1";
            }

            string comuna = cbbComuna.SelectedItem.ToString();

            //Crear conexion
            OracleConnection conexionOracle = new OracleConnection(cadenaConexionOracle);
            // Conecta
            conexionOracle.Open();

            string buscarIdComuna = "select id_comuna from comuna "+
                "where descripcion = '"+ comuna +"'";

            OracleCommand Comando = new OracleCommand(buscarIdComuna, conexionOracle);

            OracleDataReader buscarID = Comando.ExecuteReader();

            if(buscarID.Read())
            {
                string id = buscarID.GetString(0);

                string añadirDepto = "INSERT INTO DEPARTAMENTO VALUES(" +
                "incremento_id_departamento.NextVal,'" + nombre + "','" + direccion + "'," + piso + "," + costo +
                "," + cable + "," + internet + "," + calefaccion + "," + amoblado + "," + aire + "," + balcon + "," + nrohabitaciones +
                "," + nrobaios + "," + nroPersonas + "," + disponible + "," + id+")";

                MessageBox.Show(añadirDepto);

                OracleCommand insertar = new OracleCommand(añadirDepto, conexionOracle);
                OracleDataReader CrearDepartamento = insertar.ExecuteReader();
                if (CrearDepartamento.Read())
                {
                    MessageBox.Show("Se añadio departamento");
                }

                //pordia añadir un commit
                /*
                OracleCommand insertar = new OracleCommand(añadirDepto, conexionOracle);
                OracleTransaction transaccion;
                transaccion = conexionOracle.BeginTransaction(IsolationLevel.ReadCommitted);
                insertar.CommandText = añadirDepto;
                insertar.ExecuteNonQuery();
                transaccion.Commit();
                MessageBox.Show("Se inserto el departamento");*/
                

            }



        }
    }
}
