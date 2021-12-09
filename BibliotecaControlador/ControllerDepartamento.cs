using BibliotecaModelo;
using Conexion;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaControlador
{
    public class ControllerDepartamento
    {

        //Listar departamentos
        public List<Departamento> ListarDepartamentos()
        {
            try
            {
                //Crear conexion y conectar
                OracleConnection conexionOracle = new ConexionOracle().abrirConexion();

                OracleCommand comando = new OracleCommand("LISTAR_DEPARTAMENTO", conexionOracle);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("CURSOR_T", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
                OracleDataReader leer = comando.ExecuteReader();
                List<Departamento> listDepartamento = new List<Departamento>();
                while (leer.Read())
                {
                    Departamento depto = new Departamento();
                    depto.IdDepartamento = int.Parse(leer["ID_DEPARTAMENTO"].ToString());
                    depto.NombreDescriptivo = leer["NOMBRE_DESCRIPTIVO"].ToString();
                    depto.Direccion = leer["DIRECCION"].ToString();
                    depto.NroDepartamento = leer["NRO_DEPARTAMENTO"].ToString();
                    depto.Piso = int.Parse(leer["PISO"].ToString());
                    depto.Costo = int.Parse(leer["COSTO"].ToString());
                    if (int.Parse(leer["CABLE"].ToString()) == 1)
                    {
                        depto.Cable = true;
                    }
                    else
                    {
                        depto.Cable = false;
                    }
                    if (int.Parse(leer["INTERNET"].ToString()) == 1)
                    {
                        depto.Internet = true;
                    }
                    else
                    {
                        depto.Internet = false;
                    }
                    if (int.Parse(leer["CALEFACCION"].ToString()) == 1)
                    {
                        depto.Calefaccion = true;
                    }
                    else
                    {
                        depto.Calefaccion = false;
                    }
                    if (int.Parse(leer["AMOBLADO"].ToString()) == 1)
                    {
                        depto.Amoblado = true;
                    }
                    else
                    {
                        depto.Amoblado = false;
                    }
                    if (int.Parse(leer["AIRE_ACONDICIONADO"].ToString()) == 1)
                    {
                        depto.AireAcondicionado = true;
                    }
                    else
                    {
                        depto.AireAcondicionado = false;
                    }
                    if (int.Parse(leer["BALCON"].ToString()) == 1)
                    {
                        depto.Balcon = true;
                    }
                    else
                    {
                        depto.Balcon = false;
                    }
                    depto.NroHabitaciones = int.Parse(leer["NRO_HABITACIONES"].ToString());
                    depto.NroBanios = int.Parse(leer["NRO_BANIOS"].ToString());
                    depto.CantidadPersonas = int.Parse(leer["CANT_PERSONAS"].ToString());
                    if (int.Parse(leer["DISPONIBLE"].ToString()) == 1)
                    {
                        depto.Disponible = true;
                    }
                    else
                    {
                        depto.Disponible = false;
                    }
                    depto.IdComuna = int.Parse(leer["ID_COMUNA"].ToString());

                    listDepartamento.Add(depto);
                }

                //se cierra la conexion a la BD cada vez que se abre
                conexionOracle.Close(); 

                return listDepartamento;

            }
            catch (Exception)
            {
                return null;
            }
        }

        //Listar departamentos por id
        public List<Departamento> ListarDeptoConParametro(string valor)
        {
            try
            {
                //Crear conexion y conectar
                OracleConnection conexionOracle = new ConexionOracle().abrirConexion();

                OracleCommand comando = new OracleCommand("BUSCAR_DEPARTAMENTO", conexionOracle);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("CURSOR_T", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
                comando.Parameters.Add("V_ID_DEPARTAMENTO", OracleDbType.Varchar2).Value = valor;
                OracleDataReader leer = comando.ExecuteReader();
                List<Departamento> listDepartamento = new List<Departamento>();
                while (leer.Read())
                {
                    Departamento depto = new Departamento();
                    depto.IdDepartamento = int.Parse(leer["ID_DEPARTAMENTO"].ToString());
                    depto.NombreDescriptivo = leer["NOMBRE_DESCRIPTIVO"].ToString();
                    depto.Direccion = leer["DIRECCION"].ToString();
                    depto.NroDepartamento = leer["NRO_DEPARTAMENTO"].ToString();
                    depto.Piso = int.Parse(leer["PISO"].ToString());
                    depto.Costo = int.Parse(leer["COSTO"].ToString());
                    if (int.Parse(leer["CABLE"].ToString()) == 1)
                    {
                        depto.Cable = true;
                    }
                    else
                    {
                        depto.Cable = false;
                    }
                    if (int.Parse(leer["INTERNET"].ToString()) == 1)
                    {
                        depto.Internet = true;
                    }
                    else
                    {
                        depto.Internet = false;
                    }
                    if (int.Parse(leer["CALEFACCION"].ToString()) == 1)
                    {
                        depto.Calefaccion = true;
                    }
                    else
                    {
                        depto.Calefaccion = false;
                    }
                    if (int.Parse(leer["AMOBLADO"].ToString()) == 1)
                    {
                        depto.Amoblado = true;
                    }
                    else
                    {
                        depto.Amoblado = false;
                    }
                    if (int.Parse(leer["AIRE_ACONDICIONADO"].ToString()) == 1)
                    {
                        depto.AireAcondicionado = true;
                    }
                    else
                    {
                        depto.AireAcondicionado = false;
                    }
                    if (int.Parse(leer["BALCON"].ToString()) == 1)
                    {
                        depto.Balcon = true;
                    }
                    else
                    {
                        depto.Balcon = false;
                    }
                    depto.NroHabitaciones = int.Parse(leer["NRO_HABITACIONES"].ToString());
                    depto.NroBanios = int.Parse(leer["NRO_BANIOS"].ToString());
                    depto.CantidadPersonas = int.Parse(leer["CANT_PERSONAS"].ToString());
                    if (int.Parse(leer["DISPONIBLE"].ToString()) == 1)
                    {
                        depto.Disponible = true;
                    }
                    else
                    {
                        depto.Disponible = false;
                    }
                    depto.IdComuna = int.Parse(leer["ID_COMUNA"].ToString());

                    listDepartamento.Add(depto);
                }
                //se cierra la conexion a la BD cada vez que se abre
                conexionOracle.Close();

                return listDepartamento;
            }
            catch (Exception)
            {

                return null;
            }

        }

        public bool AñadirDepto(string nombre, string direccion,string nro_depto, int piso, long costo, int cable, int internet,
            int calefaccion, int amoblado, int aire_acondicionado, int balcon, int nro_habitaciones, int nro_banios,
            int cant_personas, int disponible, int id_comuna)
        {
            try
            {
                //Crear conexion y conectar
                OracleConnection conexionOracle = new ConexionOracle().abrirConexion();

                OracleCommand comando = new OracleCommand("AGREGAR_DEPARTAMENTO", conexionOracle);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("NOMBRE_DESCRIPTIVO", OracleDbType.Varchar2).Value = nombre;
                comando.Parameters.Add("DIRECCION", OracleDbType.Varchar2).Value = direccion;
                comando.Parameters.Add("NRO_DEPARTAMENTO", OracleDbType.Varchar2).Value = nro_depto;
                comando.Parameters.Add("PISO", OracleDbType.Int32).Value = piso;
                comando.Parameters.Add("COSTO", OracleDbType.Int32).Value = costo;
                comando.Parameters.Add("CABLE", OracleDbType.Int32).Value = cable;
                comando.Parameters.Add("INTERNET", OracleDbType.Int32).Value = internet;
                comando.Parameters.Add("CALEFACCION", OracleDbType.Int32).Value = calefaccion;
                comando.Parameters.Add("AMOBLADO", OracleDbType.Int32).Value = amoblado;
                comando.Parameters.Add("AIRE_ACONDICIONADO", OracleDbType.Int32).Value = aire_acondicionado;
                comando.Parameters.Add("BALCON", OracleDbType.Int32).Value = balcon;
                comando.Parameters.Add("NRO_HABITACIONES", OracleDbType.Int32).Value = nro_habitaciones;
                comando.Parameters.Add("NRO_BANIOS", OracleDbType.Int32).Value = nro_banios;
                comando.Parameters.Add("CANT_PERSONAS", OracleDbType.Int32).Value = cant_personas;
                comando.Parameters.Add("DISPONIBLE", OracleDbType.Int32).Value = disponible;
                comando.Parameters.Add("ID_COMUNA", OracleDbType.Int32).Value = id_comuna;
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

        public bool AñadirFoto(string descripcion,string ubicacion,byte[] foto,int id_depto)
        {
            try
            {
                OracleConnection conexionOracle = new ConexionOracle().abrirConexion();

                OracleCommand comando = new OracleCommand("INSERTAR_FOTO_DEPTO", conexionOracle);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("V_DESCRIPCION", OracleDbType.Varchar2).Value = descripcion;
                comando.Parameters.Add("V_UBICACION", OracleDbType.Varchar2).Value = ubicacion;
                comando.Parameters.Add("V_FOTO", OracleDbType.Blob).Value = foto;
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

        //Modificar Depto
        public bool modificarDepto(int id_depto, string nombre, string direccion, string nro_depto, int piso, long costo, int cable, int internet,
            int calefaccion, int amoblado, int aire_acondicionado, int balcon, int nro_habitaciones, int nro_banios,
            int cant_personas, int disponible, int id_comuna)
        {
            try
            {
                OracleConnection conexionOracle = new ConexionOracle().abrirConexion();
                OracleCommand comando = new OracleCommand("EDITAR_DEPARTAMENTO", conexionOracle);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("V_ID_DEPARTAMENTO", OracleDbType.Int32).Value = id_depto;
                comando.Parameters.Add("V_NOMBRE_DESCRIPTIVO", OracleDbType.Varchar2).Value = nombre;
                comando.Parameters.Add("V_DIRECCION", OracleDbType.Varchar2).Value = direccion;
                comando.Parameters.Add("V_NRO_DEPARTAMENTO", OracleDbType.Varchar2).Value = nro_depto;
                comando.Parameters.Add("V_PISO", OracleDbType.Int32).Value = piso;
                comando.Parameters.Add("V_COSTO", OracleDbType.Int32).Value = costo;
                comando.Parameters.Add("V_CABLE", OracleDbType.Int32).Value = cable;
                comando.Parameters.Add("V_INTERNET", OracleDbType.Int32).Value = internet;
                comando.Parameters.Add("V_CALEFACCION", OracleDbType.Int32).Value = calefaccion;
                comando.Parameters.Add("V_AMOBLADO", OracleDbType.Int32).Value = amoblado;
                comando.Parameters.Add("V_AIRE_ACONDICIONADO", OracleDbType.Int32).Value = aire_acondicionado;
                comando.Parameters.Add("V_BALCON", OracleDbType.Int32).Value = balcon;
                comando.Parameters.Add("V_NRO_HABITACIONES", OracleDbType.Int32).Value = nro_habitaciones;
                comando.Parameters.Add("V_NRO_BANIOS", OracleDbType.Int32).Value = nro_banios;
                comando.Parameters.Add("V_CANT_PERSONAS", OracleDbType.Int32).Value = cant_personas;
                comando.Parameters.Add("V_DISPONIBLE", OracleDbType.Int32).Value = disponible;
                comando.Parameters.Add("V_ID_COMUNA", OracleDbType.Int32).Value = id_comuna;
                comando.ExecuteNonQuery();
                conexionOracle.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool EliminarDepto(int id)
        {
            try
            {
                //Crear conexion y conectar
                OracleConnection conexionOracle = new ConexionOracle().abrirConexion();

                OracleCommand comando = new OracleCommand("ELIMINAR_DEPARTAMENTO", conexionOracle);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("V_ID_DEPARTAMENTO", OracleDbType.Int64).Value = id;
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

        //Listar Comunas
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
