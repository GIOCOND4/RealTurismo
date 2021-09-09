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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace RealTurismo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            //Justo despues de iniciar el programa, realizara la conexion
            
        }

        
        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            string Usuario = txtUsuario.Text;
            string Contrasenia = pbContrasenia.Password;
            //ConexionOracle.ConexionDb();

            //el servicename es el nombre de la base de datos
            //por defecto es orcl
            string cadenaConexionOracle = "Data source=" +
                    "(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)" +
                    "(HOST=localhost)(PORT=1521))" +
                    "(CONNECT_DATA=(SERVICE_NAME=TurismoReal)));" +
                    "User Id = ADMINISTRADOR; Password = admin;";
            //Crear conexion
            OracleConnection conexionOracle = new OracleConnection(cadenaConexionOracle);
            // Conecta
            conexionOracle.Open();
            string query = $"SELECT * FROM login WHERE USUARIO = '{Usuario}' AND CONTRASENIA = '{Contrasenia}'";
            MessageBox.Show(query);

            OracleCommand Comando = new OracleCommand(query, conexionOracle);

            OracleDataReader lector = Comando.ExecuteReader();

            if(lector.Read())
            {
                Menu menu = new Menu();
                menu.Show();
            }
            else
            {
                MessageBox.Show("Error,el usuario no se encuentra en la base de datos");
            }
            
            
        }
    }
}
