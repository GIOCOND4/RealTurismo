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
            MessageBox.Show(query2);
            OracleCommand Comando2 = new OracleCommand(query2, conexionOracle);
            OracleDataReader lector2 = Comando2.ExecuteReader();
            while (lector2.Read())
            {
                cbbProvincia.Items.Add(lector2["Descripcion"].ToString());
            }
        }
        
        private void cbbProvincia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*cbbComuna.DataContext = null;
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
            MessageBox.Show(query3);
            OracleCommand Comando3 = new OracleCommand(query3, conexionOracle);
            OracleDataReader lector3 = Comando3.ExecuteReader();
            while (lector3.Read())
            {
                cbbComuna.Items.Add(lector3["Descripcion"].ToString());
            }*/
        }
    }
}
