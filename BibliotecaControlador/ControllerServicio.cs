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
    public class ControllerServicio
    {

        //Agregar Servicio
        public bool AgregarServicio(string nombre,long costo,int disponible,string descripcion,string ubicacion,byte[] foto,int id_reserva)
        {
            try
            {
                OracleConnection conexionOracle = new ConexionOracle().abrirConexion();

                OracleCommand comando = new OracleCommand("AGREGAR_SERVICIO", conexionOracle);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("NOMBRE", OracleDbType.Varchar2).Value = nombre;
                comando.Parameters.Add("COSTO", OracleDbType.Int32).Value = costo;
                comando.Parameters.Add("DISPONIBLE", OracleDbType.Int32).Value = disponible;
                comando.Parameters.Add("DESCRIPCION", OracleDbType.Varchar2).Value = descripcion;
                comando.Parameters.Add("UBICACION_FOTO", OracleDbType.Varchar2).Value = ubicacion;
                comando.Parameters.Add("FOTO", OracleDbType.Blob).Value = foto;
                comando.Parameters.Add("ID_RESERVA", OracleDbType.Int32).Value = id_reserva;
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

        public List<Servicio> ListarServicios()
        {
            try
            {
                OracleConnection conexionOracle = new ConexionOracle().abrirConexion();
                OracleCommand comando = new OracleCommand("LISTAR_SERVICIO", conexionOracle);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("CURSOR_T", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
                OracleDataReader leer = comando.ExecuteReader();
                List<Servicio> listServicio = new List<Servicio>();
                while (leer.Read())
                {
                    Servicio serv = new Servicio();
                    serv.IdServicio = int.Parse(leer["ID_SERVICIO"].ToString());
                    serv.Nombre = leer["NOMBRE"].ToString();
                    serv.Costo = int.Parse(leer["COSTO"].ToString());
                    serv.Descripcion = leer["DESCRIPCION"].ToString();
                    if (int.Parse(leer["DISPONIBLE"].ToString()) == 1)
                    {
                        serv.Disponible = true;
                    }
                    else
                    {
                        serv.Disponible = false;
                    }
                    serv.UbicacionFoto = leer["UBICACION_FOTO"].ToString();
                    //serv.Foto = byte.Parse(leer["FOTO"].ToString());
                    //solucion parche
                    //serv.Foto = (byte[])leer["FOTO"];
                    listServicio.Add(serv);
                }
                conexionOracle.Close();
                return listServicio;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Servicio> ListarServiciosID(int ID)
        {
            try
            {
                OracleConnection conexionOracle = new ConexionOracle().abrirConexion();
                OracleCommand comando = new OracleCommand("LISTAR_SERVICIO", conexionOracle);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("CURSOR_T", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
                comando.Parameters.Add("V_ID_SERVICIO", OracleDbType.Int32).Value = ID;
                OracleDataReader leer = comando.ExecuteReader();
                List<Servicio> listServicio = new List<Servicio>();
                while (leer.Read())
                {
                    Servicio serv = new Servicio();
                    serv.IdServicio = int.Parse(leer["ID_SERVICIO"].ToString());
                    serv.Nombre = leer["NOMBRE"].ToString();
                    serv.Costo = int.Parse(leer["COSTO"].ToString());
                    serv.Descripcion = leer["DESCRIPCION"].ToString();
                    if (int.Parse(leer["DISPONIBLE"].ToString()) == 1)
                    {
                        serv.Disponible = true;
                    }
                    else
                    {
                        serv.Disponible = false;
                    }
                    serv.UbicacionFoto = leer["UBICACION_FOTO"].ToString();
                    //serv.Foto = byte.Parse(leer["FOTO"].ToString());
                    //solucion parche
                    //serv.Foto = (byte[])leer["FOTO"];
                    listServicio.Add(serv);
                }
                conexionOracle.Close();
                return listServicio;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool EliminarServicio(int id)
        {
            try
            {
                OracleConnection conexionOracle = new ConexionOracle().abrirConexion();
                OracleCommand comando = new OracleCommand("ELIMINAR_SERVICIO", conexionOracle);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("V_ID_SERVICIO", OracleDbType.Int64).Value = id;
                comando.ExecuteNonQuery();
                conexionOracle.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EditarServicio(int id,string nombre, long costo, int disponible, string descripcion, string ubicacion, byte[] foto, int id_reserva)
        {
            try
            {
                OracleConnection conexionOracle = new ConexionOracle().abrirConexion();

                OracleCommand comando = new OracleCommand("EDITAR_SERVICIO", conexionOracle);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("V_ID_SERVICIO", OracleDbType.Int32).Value = id;
                comando.Parameters.Add("V_NOMBRE", OracleDbType.Varchar2).Value = nombre;
                comando.Parameters.Add("V_COSTO", OracleDbType.Int32).Value = costo;
                comando.Parameters.Add("V_DISPONIBLE", OracleDbType.Int32).Value = disponible;
                comando.Parameters.Add("V_DESCRIPCION", OracleDbType.Varchar2).Value = descripcion;
                comando.Parameters.Add("V_UBICACION_FOTO", OracleDbType.Varchar2).Value = ubicacion;
                comando.Parameters.Add("V_FOTO", OracleDbType.Blob).Value = foto;
                comando.Parameters.Add("V_ID_RESERVA", OracleDbType.Int32).Value = id_reserva;
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
