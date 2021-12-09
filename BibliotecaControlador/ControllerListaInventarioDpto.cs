using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaModelo;
using Conexion;
using Oracle.ManagedDataAccess.Client;

namespace BibliotecaControlador
{
    public class ControllerListaInventarioDpto
    {
        public List<InventarioDepto2> ListarInventario(string idDepto)
        {
            try
            {
                OracleConnection conexionOracle = new ConexionOracle().abrirConexion();
                OracleCommand comando = new OracleCommand("LISTAR_INVENTARIO_DEPTO", conexionOracle);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("V_ID_DEPTO", OracleDbType.Int32).Value = int.Parse(idDepto);
                comando.Parameters.Add("CURSOR_T", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;                
                OracleDataReader leer = comando.ExecuteReader();
                List<InventarioDepto2> listaInventario = new List<InventarioDepto2>();

                while (leer.Read())
                {
                    InventarioDepto2 inventario = new InventarioDepto2();

                    inventario.id = int.Parse(leer["ID_INVENTARIO"].ToString());
                    inventario.nombre = leer["NOMBRE"].ToString();
                    inventario.descripcion = leer["DESCRIPCION"].ToString();
                    inventario.cantidad = int.Parse(leer["CANTIDAD"].ToString());
                    inventario.dañado = leer["DAÑADO"].ToString();
                    inventario.disponibles = int.Parse(leer["DISPONIBLES"].ToString());
                    
                    listaInventario.Add(inventario);
                }
                conexionOracle.Close();
                return listaInventario;
            }
            
            catch (Exception e)
            {
                return null;
            }
        }
        public int EditarCantidad(int idInventario, int idDepartamento, int cantidad)
        {
            int variableSalida = 0;
            try
            {
                OracleConnection conexionOracle = new ConexionOracle().abrirConexion();
                OracleCommand comando = new OracleCommand("EDITAR_CANT_INVENTARIO_DEPTO", conexionOracle);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("V_ID_INVENTARIO", OracleDbType.Int32).Value = idInventario;
                comando.Parameters.Add("V_ID_DEPARTAMENTO", OracleDbType.Int32).Value = idDepartamento;
                comando.Parameters.Add("V_CANTIDAD", OracleDbType.Int32).Value = cantidad;
                comando.Parameters.Add("V_SALIDA", OracleDbType.Int32).Direction = System.Data.ParameterDirection.Output;

                comando.ExecuteScalar();

                variableSalida = int.Parse(comando.Parameters["V_SALIDA"].Value.ToString());
               
                conexionOracle.Close();
                return variableSalida;
            }

            catch (Exception e)
            {
                return variableSalida;
            }
        }
        
    }
}
