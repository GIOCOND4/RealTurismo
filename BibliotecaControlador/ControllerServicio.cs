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
        public bool AgregarServicio(string nombre,long costo,int disponible,string descripcion,string ubicacion,byte[] foto,int id_reserva,int tiposervicio,int comuna)
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
                comando.Parameters.Add("TIPO_SERVICIO", OracleDbType.Int32).Value = tiposervicio;
                comando.Parameters.Add("COMUNA", OracleDbType.Int32).Value = comuna;
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
                OracleCommand comando = new OracleCommand("LISTAR_SERVICIO_POR_ID", conexionOracle);
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

        public bool EditarServicio(int id,string nombre, long costo, int disponible, string descripcion, string ubicacion, byte[] foto, int id_reserva,int tiposervicio,int comuna)
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
                comando.Parameters.Add("V_ID_TIPO_SERVICIO", OracleDbType.Int32).Value = tiposervicio;
                comando.Parameters.Add("V_ID_COMUNA", OracleDbType.Int32).Value = comuna;
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

        public int IdTipoServicio(string servicio)
        {
            try
            {
                OracleConnection conn = new ConexionOracle().abrirConexion();

                //OracleConnection conexionOracle = new OracleConnection(cadenaConexionOracle);
                //conexionOracle.Open();
                string BuscarIdTipoServicio = "select id_tipo_servicio from tipo_servicio " +
                    "where nombre = '" + servicio + "'";
                OracleCommand Comando = new OracleCommand(BuscarIdTipoServicio, conn);
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

        public int BuscarComuna(string comuna)
        {
            try
            {

                OracleConnection conn = new ConexionOracle().abrirConexion();

                //OracleConnection conexionOracle = new OracleConnection(cadenaConexionOracle);
                //conexionOracle.Open();
                string buscarIdComuna = "select id_comuna from comuna " +
                    "where nombre = '" + comuna + "'";
                OracleCommand Comando = new OracleCommand(buscarIdComuna, conn);
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

    }
}
