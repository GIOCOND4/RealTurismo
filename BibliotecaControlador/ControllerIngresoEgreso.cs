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
    public class ControllerIngresoEgreso
    {
        public List<Ingreso> ListarIngresos()
        {
            try
            {
                OracleConnection conexionOracle = new ConexionOracle().abrirConexion();
                OracleCommand comando = new OracleCommand("SP_ESTADISTICAS_INGRESOS", conexionOracle);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("CURSOR_1", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
                comando.Parameters.Add("V_SALIDA", OracleDbType.Int32).Direction = System.Data.ParameterDirection.Output;
                OracleDataReader leer = comando.ExecuteReader();
                List<Ingreso> listaIngresos = new List<Ingreso>();
                while (leer.Read())
                {
                    Ingreso ingreso = new Ingreso();
                    ingreso.idDepto = int.Parse(leer["ID_DEPARTAMENTO"].ToString());
                    ingreso.nombreDepto = leer["NOMBRE_DEPTO"].ToString();
                    ingreso.nroDepto = int.Parse(leer["NRO_DEPTO"].ToString());
                    ingreso.montoIngresos = int.Parse(leer["MONTO_INGRESOS"].ToString());
                    ingreso.cantidadReservas = int.Parse(leer["CANT_RESERVAS"].ToString());
                    
                    listaIngresos.Add(ingreso);
                }
                conexionOracle.Close();
                return listaIngresos;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Ingreso> ListarIngresosDepto(string depto)
        {
            try
            {
                OracleConnection conexionOracle = new ConexionOracle().abrirConexion();
                OracleCommand comando = new OracleCommand("SP_ESTADISTICAS_INGRESOS_DEPTO", conexionOracle);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("CURSOR_1", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
                comando.Parameters.Add("V_NOMBRE_DEPTO", OracleDbType.Varchar2).Value = depto;
                comando.Parameters.Add("V_SALIDA", OracleDbType.Int32).Direction = System.Data.ParameterDirection.Output;
                OracleDataReader leer = comando.ExecuteReader();
                List<Ingreso> listaIngresos = new List<Ingreso>();
                while (leer.Read())
                {
                    Ingreso ingreso = new Ingreso();
                    ingreso.idDepto = int.Parse(leer["ID_DEPARTAMENTO"].ToString());
                    ingreso.nombreDepto = leer["NOMBRE_DEPTO"].ToString();
                    ingreso.nroDepto = int.Parse(leer["NRO_DEPTO"].ToString());
                    ingreso.montoIngresos = int.Parse(leer["MONTO_INGRESOS"].ToString());
                    ingreso.cantidadReservas = int.Parse(leer["CANT_RESERVAS"].ToString());

                    listaIngresos.Add(ingreso);
                }
                conexionOracle.Close();
                return listaIngresos;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<Egreso> ListarEgresos()
        {
            try
            {
                OracleConnection conexionOracle = new ConexionOracle().abrirConexion();
                OracleCommand comando = new OracleCommand("SP_ESTADISTICAS_EGRESOS", conexionOracle);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("CURSOR_1", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
                comando.Parameters.Add("V_SALIDA", OracleDbType.Int32).Direction = System.Data.ParameterDirection.Output;
                OracleDataReader leer = comando.ExecuteReader();
                List<Egreso> listaEgresos = new List<Egreso>();
                while (leer.Read())
                {
                    Egreso egreso = new Egreso();
                    egreso.idDepto = int.Parse(leer["IDENTIFICADOR"].ToString());
                    egreso.nombreDepto = leer["DEPARTAMENTO"].ToString();
                    egreso.numeroDepto = int.Parse(leer["NUMERO"].ToString());
                    egreso.montoEgresos = int.Parse(leer["MONTO_EGRESOS"].ToString());
                    egreso.cantidad = int.Parse(leer["CANTIDAD_EGRESOS"].ToString());

                    listaEgresos.Add(egreso);
                }
                conexionOracle.Close();
                return listaEgresos;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<Egreso> ListarEgresosDepto(string depto)
        {
            try
            {
                OracleConnection conexionOracle = new ConexionOracle().abrirConexion();
                OracleCommand comando = new OracleCommand("SP_ESTADISTICAS_EGRESOS_DEPTO", conexionOracle);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("CURSOR_1", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
                comando.Parameters.Add("V_NOMBRE_DEPTO", OracleDbType.Varchar2).Value = depto;
                comando.Parameters.Add("V_SALIDA", OracleDbType.Int32).Direction = System.Data.ParameterDirection.Output;
                OracleDataReader leer = comando.ExecuteReader();
                List<Egreso> listaEgresos = new List<Egreso>();
                while (leer.Read())
                {
                    Egreso egreso = new Egreso();
                    egreso.idDepto = int.Parse(leer["ID_DEPTO"].ToString());
                    egreso.nombreDepto = leer["NOMBRE_DEPTO"].ToString();
                    egreso.numeroDepto = int.Parse(leer["NRO DEPTO"].ToString());
                    egreso.montoEgresos = int.Parse(leer["MONTO EGRESOS"].ToString());
                    egreso.cantidad = int.Parse(leer["CANTIDAD EGRESOS"].ToString());

                    listaEgresos.Add(egreso);
                }
                conexionOracle.Close();
                return listaEgresos;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
    
}
