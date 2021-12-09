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
    public class ControllerInventario2
    {
        public List<InventarioListar> ListarTodos()
        {
            try
            {
                OracleConnection conexionOracle = new ConexionOracle().abrirConexion();
                OracleCommand comando = new OracleCommand("BUSCAR_INVENTARIO_TODOS", conexionOracle);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("CURSOR_T", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
                //comando.Parameters.Add("V_SALIDA", OracleDbType.Int32).Direction = System.Data.ParameterDirection.Output;
                OracleDataReader leer = comando.ExecuteReader();
                List<InventarioListar> listaInventario = new List<InventarioListar>();
                while (leer.Read())
                {
                    InventarioListar inventario = new InventarioListar();
                    inventario.id = int.Parse(leer["ID_INVENTARIO"].ToString());
                    inventario.nombre = leer["NOMBRE"].ToString();
                    inventario.costo = long.Parse(leer["COSTO"].ToString());
                    inventario.descripcion = leer["DESCRIPCION"].ToString();                    
                    inventario.stock = int.Parse(leer["STOCK_GENERAL"].ToString());

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

        public List<InventarioListar> ListarPorNombre(string objeto)
        {
            try
            {
                OracleConnection conexionOracle = new ConexionOracle().abrirConexion();
                OracleCommand comando = new OracleCommand("BUSCAR_INVENTARIO_NOMBRE", conexionOracle);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("V_NOMBRE", OracleDbType.Varchar2).Value = objeto;
                comando.Parameters.Add("CURSOR_T", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;                
                OracleDataReader leer = comando.ExecuteReader();
                List<InventarioListar> listaInventario = new List<InventarioListar>();
                while (leer.Read())
                {
                    InventarioListar inventario = new InventarioListar();
                    inventario.id = int.Parse(leer["ID_INVENTARIO"].ToString());
                    inventario.nombre = leer["NOMBRE"].ToString();
                    inventario.descripcion = leer["DESCRIPCION"].ToString();
                    inventario.costo = int.Parse(leer["COSTO"].ToString());
                    inventario.stock = int.Parse(leer["STOCK_GENERAL"].ToString());

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

        public bool AgregarInventario(Inventario2 inventario)
        {
            try
            {
                OracleConnection conexionOracle = new ConexionOracle().abrirConexion();
                OracleCommand comando = new OracleCommand("AGREGAR_INVENTARIO", conexionOracle);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("NOMBRE", OracleDbType.Varchar2).Value = inventario.nombreCorto;
                comando.Parameters.Add("COSTO", OracleDbType.Int32).Value = inventario.costo;
                comando.Parameters.Add("DESCRIPCION", OracleDbType.Varchar2).Value = inventario.descripcion;
                comando.Parameters.Add("CANTIDAD", OracleDbType.Int32).Value = inventario.cantidad;
                
                comando.ExecuteNonQuery();

                //se cierrra la conexion a BD
                conexionOracle.Close();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        public int EliminarInventario(string idObjeto)
        {
            int variableSalida = 0;
            try
            {
                OracleConnection conexionOracle = new ConexionOracle().abrirConexion();
                OracleCommand comando = new OracleCommand("ELIMINAR_INVENTARIO", conexionOracle);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("V_ID_INVENTARIO", OracleDbType.Int32).Value = int.Parse(idObjeto);
                comando.Parameters.Add("V_SALIDA", OracleDbType.Int32).Direction = System.Data.ParameterDirection.Output;               
                
                comando.ExecuteScalar();

                variableSalida = int.Parse(comando.Parameters["V_SALIDA"].Value.ToString());               

                //se cierrra la conexion a BD
                conexionOracle.Close();
                return variableSalida;
            }
            catch (Exception e)
            {
                return variableSalida;
                
            }
        }

        public bool EditarInventario( Inventario2 inventario)
        {
            try
            {
                OracleConnection conexionOracle = new ConexionOracle().abrirConexion();
                OracleCommand comando = new OracleCommand("EDITAR_INVENTARIO", conexionOracle);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("V_ID_INVENTARIO", OracleDbType.Int32).Value = inventario.id;
                comando.Parameters.Add("V_NOMBRE", OracleDbType.Varchar2).Value = inventario.nombreCorto;
                comando.Parameters.Add("V_COSTO", OracleDbType.Int32).Value = inventario.costo;
                comando.Parameters.Add("V_DESCRIPCION", OracleDbType.Varchar2).Value = inventario.descripcion;
                comando.Parameters.Add("V_CANTIDAD", OracleDbType.Int32).Value = inventario.cantidad;                

                comando.ExecuteNonQuery();

                //se cierrra la conexion a BD
                conexionOracle.Close();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }
    }
}
