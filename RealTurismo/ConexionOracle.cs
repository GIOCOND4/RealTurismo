using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Windows;

namespace RealTurismo
{
    class ConexionOracle
    {
        public static void ConexionDb()
        {
            try
            {
                //Creamos la cadena de conexion
                string cadenaConexionOracle = "Data source=" +
                    "(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)" +
                    "(HOST=localhost)(PORT=1521))" +
                    "(CONNECT_DATA=(SERVICE_NAME=TurismoReal)));" +
                    "User Id = ADMINISTRADOR; Password = admin;";
                //Crear conexion
                OracleConnection conexionOracle = new OracleConnection(cadenaConexionOracle);
                // Conecta
                conexionOracle.Open();
                MessageBox.Show("Conexion Abierta");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en la conexion: {ex}");
            }
            
        }
    }
}
