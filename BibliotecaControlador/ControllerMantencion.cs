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
    public class ControllerMantencion
    {
        public bool AgregarMantencion(DateTime fecha_registro,DateTime fecha_mantencion,string descripcion,long costo,int id_mantencion,int id_depto)
        {
            try
            {
                OracleConnection conexionOracle = new ConexionOracle().abrirConexion();
                OracleCommand comando = new OracleCommand("AGREGAR_MANTENCION", conexionOracle);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("V_FECHA_REGISTRO", OracleDbType.Date).Value = fecha_registro;
                comando.Parameters.Add("V_FECHA_MANTENCION", OracleDbType.Date).Value = fecha_mantencion;
                comando.Parameters.Add("V_DESCRIPCION", OracleDbType.Varchar2).Value = descripcion;
                comando.Parameters.Add("V_COSTO", OracleDbType.Int32).Value = costo;
                comando.Parameters.Add("V_ID_TIPO_MANTENCION", OracleDbType.Int32).Value = id_mantencion;
                comando.Parameters.Add("V_ID_DEPARTAMENTO", OracleDbType.Int32).Value = id_depto;
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

        public bool ModificarMantencion(int id,DateTime fecha_registro, DateTime fecha_mantencion, string descripcion, long costo, int id_mantencion, int id_depto)
        {
            try
            {
                OracleConnection conexionOracle = new ConexionOracle().abrirConexion();
                OracleCommand comando = new OracleCommand("EDITAR_MANTENCION", conexionOracle);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("V_ID_MANTENCION", OracleDbType.Int32).Value = id;
                comando.Parameters.Add("V_FECHA_REGISTRO", OracleDbType.Date).Value = fecha_registro;
                comando.Parameters.Add("V_FECHA_MANTENCION", OracleDbType.Date).Value = fecha_mantencion;
                comando.Parameters.Add("V_DESCRIPCION", OracleDbType.Varchar2).Value = descripcion;
                comando.Parameters.Add("V_COSTO", OracleDbType.Int32).Value = costo;
                comando.Parameters.Add("V_ID_TIPO_MANTENCION", OracleDbType.Int32).Value = id_mantencion;
                comando.Parameters.Add("V_ID_DEPARTAMENTO", OracleDbType.Int32).Value = id_depto;
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

        public int BuscarTipoMantencion(string tipo_mantencion)
        {
            try
            {
                OracleConnection conn = new ConexionOracle().abrirConexion();
                string buscarIdTipoMantencion = "select id_tipo_mantencion from tipo_mantencion " +
                    "where nombre = '" + tipo_mantencion + "'";
                OracleCommand Comando = new OracleCommand(buscarIdTipoMantencion, conn);
                OracleDataReader buscarID = Comando.ExecuteReader();
                if (buscarID.Read())
                {
                    int id = int.Parse(buscarID.GetString(0));
                    return id;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public List<Mantencion> ListarMantencion()
        {
            try
            {
                //Crear conexion y conectar
                OracleConnection conexionOracle = new ConexionOracle().abrirConexion();

                OracleCommand comando = new OracleCommand("LISTAR_MANTENCION_NUEVO", conexionOracle);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("CURSOR_T", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
                OracleDataReader leer = comando.ExecuteReader();
                List<Mantencion> listMantencion = new List<Mantencion>();
                while (leer.Read())
                {
                    Mantencion man = new Mantencion();
                    man.IdMantencion = int.Parse(leer["ID_MANTENCION"].ToString());
                    man.FechaRegistro = DateTime.Parse(leer["FECHA_REGISTRO"].ToString());
                    man.FechaMantencion = DateTime.Parse(leer["FECHA_MANTENCION"].ToString());
                    man.Descripcion = leer["DESCRIPCION"].ToString();
                    man.Costo = long.Parse(leer["COSTO"].ToString());
                    man.IdTipoMantencion = int.Parse(leer["ID_TIPO_MANTENCION"].ToString());
                    listMantencion.Add(man);
                    
                }
                conexionOracle.Close();

                return listMantencion;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<Mantencion> ListarMantencionID(int id)
        {
            try
            {
                //Crear conexion y conectar
                OracleConnection conexionOracle = new ConexionOracle().abrirConexion();

                OracleCommand comando = new OracleCommand("LISTAR_MANTENCION_NUEVO_ID", conexionOracle);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("CURSOR_T", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
                comando.Parameters.Add("V_ID_MANTENCION", OracleDbType.Int32).Value = id;
                OracleDataReader leer = comando.ExecuteReader();
                List<Mantencion> listMantencion = new List<Mantencion>();
                while (leer.Read())
                {
                    Mantencion man = new Mantencion();
                    man.IdMantencion = int.Parse(leer["ID_MANTENCION"].ToString());
                    man.FechaRegistro = DateTime.Parse(leer["FECHA_REGISTRO"].ToString());
                    man.FechaMantencion = DateTime.Parse(leer["FECHA_MANTENCION"].ToString());
                    man.Descripcion = leer["DESCRIPCION"].ToString();
                    man.Costo = long.Parse(leer["COSTO"].ToString());
                    man.IdTipoMantencion = int.Parse(leer["ID_TIPO_MANTENCION"].ToString());
                    listMantencion.Add(man);

                }
                conexionOracle.Close();

                return listMantencion;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool eliminarMantencion(int id)
        {
            try
            {
                OracleConnection conexionOracle = new ConexionOracle().abrirConexion();

                OracleCommand comando = new OracleCommand("ELIMINAR_MANTENCION", conexionOracle);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("V_ID_MANTENEDOR", OracleDbType.Int64).Value = id;
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
