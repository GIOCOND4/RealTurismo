using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client; //referencia a oracle, un cliente
using Oracle.ManagedDataAccess.Types; //referencia a oracle: tipos de dato de oracle
using System.Windows;

namespace Conexion
{
    public class ConexionOracle
    {
        OracleConnection conn = null;

        //string de conexion
        //el servicename es el nombre de la base de datos por defecto es orcl (en oracle 12)
        //string connectionString = "Data source=" +
        //            "(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)" +
        //            "(HOST=localhost)(PORT=1521))" +
        //            "(CONNECT_DATA=(SERVICE_NAME=orcl)));" +
        //            "User Id = C##_ADMINISTRADOR; Password = administrador;";


        //Conexion de elise
        //string connectionString = "Data source=" +
        //            "(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)" +
        //            "(HOST=localhost)(PORT=1521))" +
        //            "(CONNECT_DATA=(SERVICE_NAME=orcl)));" +
        //            "User Id = C##ADMINISTRADOR; Password = administrador;";

        //String Marcelo
        string connectionString = "Data source=" +
                    "(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)" +
                    "(HOST=localhost)(PORT=1521))" +
                    "(CONNECT_DATA=(SERVICE_NAME=TurismoReal)));" +
                    "User Id = ADMINISTRADOR; Password = admin;";

        public ConexionOracle()
        {
            if (true)
            {
                if (conn == null)
                {
                    conn = new OracleConnection(connectionString);
                }

            }
        }

        public OracleConnection abrirConexion()
        {
            try
            {
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al abrir la conexion");
            }
        }

        public void cerrarConexion()
        {
            try
            {
                conn.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cerrar la conexion");
            }
        }
        /*
        public static void ConexionDb()
        {
            try
            {
                //Creamos la cadena de conexion
                
                //Crear conexion
                OracleConnection conexionOracle = new OracleConnection(connectionString);
                // Conecta
                conexionOracle.Open();
                MessageBox.Show("Conexion Abierta");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en la conexion: {ex}");
            }
            
        }*/
    }
}