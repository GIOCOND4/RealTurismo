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
            Contrasenia = Encriptado.GetSHA256(Contrasenia);

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

            string query = $"SELECT l.USUARIO,l.CONTRASENIA,pl.descripcion FROM login l " +
                            "Inner Join persona p ON p.id_persona = l.id_persona " +
                            "Inner Join perfil pl On pl.id_perfil = p.id_perfil " +
                            "WHERE l.usuario = '" + Usuario + "' AND l.contrasenia = '" + Contrasenia + "'";

            OracleCommand Comando = new OracleCommand(query, conexionOracle);

            OracleDataReader lector = Comando.ExecuteReader();

            if(lector.Read())
            {
                if(lector.GetString(2) == "Administrador"){
                    txtUsuario.Text = "";
                    pbContrasenia.Password = "";
                    MenuAdministrador menuAdmin = new MenuAdministrador();
                    menuAdmin.ShowDialog();
                }
                else if (lector.GetString(2) == "Empleado")
                {
                    txtUsuario.Text = "";
                    pbContrasenia.Password = "";
                    Menu menu = new Menu();
                    menu.ShowDialog();
                }
                else
                {
                    txtUsuario.Text = "";
                    pbContrasenia.Password = "";
                    MessageBox.Show("Usted no esta autorizado para ingresar al sistema");
                }
            }
            else
            {
                txtUsuario.Text = "";
                pbContrasenia.Password = "";
                MessageBox.Show("Las credenciales de usuario y/o contraseña son incorrectas");
            }
            
            
        }
    }
}
