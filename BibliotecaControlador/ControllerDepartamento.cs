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
        public List<Departamento> ListarDeptoID(int id)
        {
            try
            {
                //Crear conexion y conectar
                OracleConnection conexionOracle = new ConexionOracle().abrirConexion();

                OracleCommand comando = new OracleCommand("BUSCAR_DEPARTAMENTO", conexionOracle);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("CURSOR_T", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
                comando.Parameters.Add("V_ID_DEPARTAMENTO", OracleDbType.Int32).Value = id;
                OracleDataReader leer = comando.ExecuteReader();
                List<Departamento> listDepartamento = new List<Departamento>();
                while (leer.Read())
                {
                    Departamento depto = new Departamento();
                    depto.IdDepartamento = int.Parse(leer["ID_DEPARTAMENTO"].ToString());
                    depto.NombreDescriptivo = leer["NOMBRE_DESCRIPTIVO"].ToString();
                    depto.Direccion = leer["DIRECCION"].ToString();
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

        public bool AñadirDepto(string nombre, string direccion, int piso, int costo, int cable, int internet,
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
    }
}
