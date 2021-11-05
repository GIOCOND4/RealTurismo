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
using Oracle.ManagedDataAccess.Client;

namespace Vista
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : MetroWindow
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            string Usuario = txtUsuario.Text;
            string Contrasenia = pbContrasenia.Password;
            Contrasenia = BibliotecaModelo.Encriptado.GetSHA256(Contrasenia);

            OracleConnection conexionOracle = new ConexionOracle().abrirConexion();

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
                    //MenuAdministradorViejo menuAdmin = new MenuAdministradorViejo();
                    menuAdmin.ShowDialog();
                    this.Close();
                    conexionOracle.Close();
                }
                else if (lector.GetString(2) == "Empleado")
                {
                    txtUsuario.Text = "";
                    pbContrasenia.Password = "";
                    MenuEmpleados menu = new MenuEmpleados();
                    //Menu menu = new Menu();
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
