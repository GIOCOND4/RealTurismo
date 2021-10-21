using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace RealTurismo.Controlador
{

    class ControladorDepartamento
    {
        string cadenaConexionOracle = "Data source=" +
                "(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)" +
                "(HOST=localhost)(PORT=1521))" +
                "(CONNECT_DATA=(SERVICE_NAME=TurismoReal)));" +
                "User Id = ADMINISTRADOR; Password = admin;";
        public List<Modelo.Departamentos> ListarDepartamentos()
        {
            try
            {
                //Crear conexion
                OracleConnection conexionOracle = new OracleConnection(cadenaConexionOracle);
                // Conecta
                conexionOracle.Open();
                OracleCommand comando = new OracleCommand("LISTAR_DEPARTAMENTO", conexionOracle);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("CURSOR_T", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
                OracleDataReader leer = comando.ExecuteReader();
                List<Modelo.Departamentos> listDepartamento = new List<Modelo.Departamentos>();
                while (leer.Read())
                {
                    Modelo.Departamentos depto = new Modelo.Departamentos();
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
                        depto.AireAcondiconado = true;
                    }
                    else
                    {
                        depto.AireAcondiconado = false;
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
                conexionOracle.Close();
                return listDepartamento;

            }
            catch (Exception)
            {
                return null;
            }
        }
    }

    
  }
