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
    public class ControllerInventario
    {
        //Agregar Inventario
        public bool AgregarInventario(string codigo,string nombre,long costo,string descripcion,int activo,int iddepto)
        {
            try
            {
                //Crear conexion y conectar
                OracleConnection conexionOracle = new ConexionOracle().abrirConexion();
                OracleCommand comando = new OracleCommand("AGREGAR_INVENTARIO", conexionOracle);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("CODIGO", OracleDbType.Varchar2).Value = codigo;
                comando.Parameters.Add("NOMBRE", OracleDbType.Varchar2).Value = nombre;
                comando.Parameters.Add("COSTO", OracleDbType.Int32).Value = costo;
                comando.Parameters.Add("DESCRIPCION", OracleDbType.Varchar2).Value = descripcion;
                comando.Parameters.Add("ACTIVO", OracleDbType.Int32).Value = activo;
                comando.Parameters.Add("ID_DEPARTAMENTO", OracleDbType.Int32).Value = iddepto;
                comando.ExecuteNonQuery();

                //se cierrra la conexion a BD
                conexionOracle.Close();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<InventarioPorDepto> ListarInventario()
        {
            try
            {
                //Crear conexion y conectar
                OracleConnection conexionOracle = new ConexionOracle().abrirConexion();

                OracleCommand comando = new OracleCommand("LISTAR_INVENTARIO", conexionOracle);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("CURSOR_T", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
                OracleDataReader leer = comando.ExecuteReader();
                List<InventarioPorDepto> Lisinventario = new List<InventarioPorDepto>();
                while (leer.Read())
                {
                    InventarioPorDepto inv = new InventarioPorDepto();
                    inv.IdDepartamento = int.Parse(leer["ID_DEPARTAMENTO"].ToString());
                    inv.NombreDescriptivo = leer["NOMBRE_DESCRIPTIVO"].ToString();
                    inv.IdInventario = int.Parse(leer["ID_INVENTARIO"].ToString());
                    inv.Codigo = leer["CODIGO"].ToString();
                    inv.Nombre = leer["NOMBRE"].ToString();
                    inv.Costo = int.Parse(leer["COSTO"].ToString());
                    inv.Descripcion = leer["DESCRIPCION"].ToString();
                    if (int.Parse(leer["ACTIVO"].ToString()) == 1)
                    {
                        inv.Disponible = true;
                    }
                    else
                    {
                        inv.Disponible = false;
                    }

                    Lisinventario.Add(inv);

                }
                conexionOracle.Close();
                return Lisinventario;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<InventarioPorDepto> ListarInventarioPorId(int iddepto)
        {
            try
            {
                //Crear conexion y conectar
                OracleConnection conexionOracle = new ConexionOracle().abrirConexion();

                OracleCommand comando = new OracleCommand("LISTAR_INVENTARIO_POR_DEPTO", conexionOracle);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("CURSOR_T", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
                comando.Parameters.Add("V_ID_DEPARTAMENTO", OracleDbType.Varchar2).Value = iddepto;
                OracleDataReader leer = comando.ExecuteReader();
                List<InventarioPorDepto> Lisinventario = new List<InventarioPorDepto>();
                while (leer.Read())
                {
                    InventarioPorDepto inv = new InventarioPorDepto();
                    inv.IdDepartamento = int.Parse(leer["ID_DEPARTAMENTO"].ToString());
                    inv.NombreDescriptivo = leer["NOMBRE_DESCRIPTIVO"].ToString();
                    inv.IdInventario = int.Parse(leer["ID_INVENTARIO"].ToString());
                    inv.Codigo = leer["CODIGO"].ToString();
                    inv.Nombre = leer["NOMBRE"].ToString();
                    inv.Costo = int.Parse(leer["COSTO"].ToString());
                    inv.Descripcion = leer["DESCRIPCION"].ToString();
                    if (int.Parse(leer["ACTIVO"].ToString()) == 1)
                    {
                        inv.Disponible = true;
                    }
                    else
                    {
                        inv.Disponible = false;
                    }

                    Lisinventario.Add(inv);

                }
                conexionOracle.Close();
                return Lisinventario;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool EliminarInventario(int idinventario)
        {
            try
            {
                //Crear conexion y conectar
                OracleConnection conexionOracle = new ConexionOracle().abrirConexion();

                OracleCommand comando = new OracleCommand("ELIMINAR_INVENTARIO", conexionOracle);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("V_ID_INVENTARIO", OracleDbType.Int64).Value = idinventario;
                comando.ExecuteNonQuery();

                //se cierrra la conexion a BD
                conexionOracle.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EditarInventario(int idinventario,string codigo, string nombre, long costo, string descripcion, int activo, int iddepto)
        {
            try
            {
                //Crear conexion y conectar
                OracleConnection conexionOracle = new ConexionOracle().abrirConexion();
                OracleCommand comando = new OracleCommand("EDITAR_INVENTARIO", conexionOracle);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("V_ID_INVENTARIO", OracleDbType.Varchar2).Value = idinventario;
                comando.Parameters.Add("V_CODIGO", OracleDbType.Varchar2).Value = codigo;
                comando.Parameters.Add("V_NOMBRE", OracleDbType.Varchar2).Value = nombre;
                comando.Parameters.Add("V_COSTO", OracleDbType.Int32).Value = costo;
                comando.Parameters.Add("V_DESCRIPCION", OracleDbType.Varchar2).Value = descripcion;
                comando.Parameters.Add("V_ACTIVO", OracleDbType.Int32).Value = activo;
                comando.Parameters.Add("V_ID_DEPARTAMENTO", OracleDbType.Int32).Value = iddepto;
                comando.ExecuteNonQuery();

                //se cierrra la conexion a BD
                conexionOracle.Close();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
