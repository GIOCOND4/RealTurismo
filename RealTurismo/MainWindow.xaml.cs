﻿using MahApps.Metro.Controls;
using Oracle.ManagedDataAccess.Client;
using System.Windows;

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
                    "(HOST=172.31.9.149)(PORT=1521))" +
                    "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=TurismoReal)));" +
                    "User Id = SYSTEM; Password = 1234;";

            OracleConnectionStringBuilder builder = new OracleConnectionStringBuilder();
            builder.DataSource = "172.31.9.149:1521/orcl";
            builder.UserID = "SYSTEM";
            builder.PersistSecurityInfo = true;
            builder.Password = "1234";
            builder.ConnectionTimeout = 250;
            //Crear conexion
            OracleConnection conexionOracle = new OracleConnection(builder.ConnectionString);
            // Conecta
            conexionOracle.Open();

            string query = $"SELECT l.USUARIO,l.CONTRASENIA,pl.descripcion FROM login l " +
                            "Inner Join persona p ON p.id_persona = l.id_persona " +
                            "Inner Join perfil pl On pl.id_perfil = p.id_perfil " +
                            "WHERE l.usuario = '" + Usuario + "' AND l.contrasenia = '" + Contrasenia + "'";

            OracleCommand Comando = new OracleCommand(query, conexionOracle);

            OracleDataReader lector = Comando.ExecuteReader();

            if (lector.Read())
            {
                if (lector.GetString(2) == "Administrador")
                {
                    txtUsuario.Text = "";
                    pbContrasenia.Password = "";
                    MenuAdministrador menuAdmin = new MenuAdministrador();
                    menuAdmin.ShowDialog();
                    this.Close();
                    conexionOracle.Close();
                }
                else if (lector.GetString(2) == "Empleado")
                {
                    txtUsuario.Text = "";
                    pbContrasenia.Password = "";
                    Menu menu = new Menu();
                    menu.ShowDialog();
                    this.Close();
                    conexionOracle.Close();
                }
                else
                {
                    txtUsuario.Text = "";
                    pbContrasenia.Password = "";
                    MessageBox.Show("Usted no esta autorizado para ingresar al sistema");
                    conexionOracle.Close();
                }
            }
            else
            {
                txtUsuario.Text = "";
                pbContrasenia.Password = "";
                MessageBox.Show("Las credenciales de usuario y/o contraseña son incorrectas");
                conexionOracle.Close();
            }


        }
    }
}
