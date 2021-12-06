using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaModelo;
using Conexion;
using Oracle.ManagedDataAccess.Client;

namespace BibliotecaControlador
{
    public class ControllerPersona
    {
        //Listar perfiles
        public List<Perfil> ListarPerfiles()
        {
            try
            {
                OracleConnection conexionOracle = new ConexionOracle().abrirConexion();

                OracleCommand comando = new OracleCommand("LISTAR_PERFIL", conexionOracle);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("CURSOR_T", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
                OracleDataReader leer = comando.ExecuteReader();
                List<Perfil> listPerfil = new List<Perfil>();
                while (leer.Read())
                {
                    Perfil perfil = new Perfil();
                    perfil.idPerfil = int.Parse(leer["ID_PERFIL"].ToString());
                    perfil.descripcion = leer["DESCRIPCION"].ToString();
                    listPerfil.Add(perfil);
                }
                conexionOracle.Close();
                return listPerfil;
            }
            catch (Exception)
            {
                return null;
            }
        }
        //Listar todos los usuarios
        public List<Persona> ListarTodasPersonas()
        {
            try
            {
                //Crear conexion y conectar
                OracleConnection conexionOracle = new ConexionOracle().abrirConexion();

                OracleCommand comando = new OracleCommand("LISTAR_TODAS_PERSONAS", conexionOracle);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("CURSOR_T", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
                OracleDataReader leer = comando.ExecuteReader();
                List<Persona> listPersonas = new List<Persona>();
                while (leer.Read())
                {
                    Persona persona = new Persona();
                    persona.IdPersona = int.Parse(leer["ID_PERSONA"].ToString());
                    persona.Rut = int.Parse(leer["RUT"].ToString());
                    persona.Dv = leer["DV"].ToString();
                    persona.Nombres = leer["NOMBRES"].ToString();
                    persona.ApellidoPat = leer["APE_PATERNO"].ToString();
                    persona.ApellidoMat = leer["APE_MATERNO"].ToString();
                    persona.IdPerfil = int.Parse(leer["ID_PERFIL"].ToString());
                    persona.nombrePerfil = leer["NOMBRE_PERFIL"].ToString();
                    persona.Correo = leer["CORREO"].ToString();
                    persona.Activo = Int32.Parse(leer["ACTIVO"].ToString());
                    persona.NombreUsuario = leer["NOMBRE_USUARIO"].ToString();
                    persona.Contrasenia = leer["CONTRASENIA"].ToString();

                    listPersonas.Add(persona);

                }

                //se cierra la conexion a la BD cada vez que se abre
                conexionOracle.Close();

                return listPersonas;

            }
            catch (Exception e)
            {
                return null;
            }
        }
        //Listar usuarios de la grid
        public List<PersonaGrid> ListarPersonasGrid1()
        {
            try
            {
                //Crear conexion y conectar
                OracleConnection conexionOracle = new ConexionOracle().abrirConexion();

                OracleCommand comando = new OracleCommand("LISTAR_TODAS_PERSONAS", conexionOracle);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("CURSOR_T", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
                OracleDataReader leer = comando.ExecuteReader();
                List<PersonaGrid> listPersonas = new List<PersonaGrid>();
                while (leer.Read())
                {
                    PersonaGrid persona = new PersonaGrid();
                    persona.IdPersona = int.Parse(leer["ID_PERSONA"].ToString());
                    persona.RutString = leer["RUT"].ToString();
                    //persona.nombreCompleto = leer["NOMBRE COMPLETO"].ToString();
                    persona.nombres = leer["NOMBRES"].ToString();
                    persona.apellidopat = leer["APELLIDO PATERNO"].ToString();
                    persona.apellidomat = leer["APELLIDO MATERNO"].ToString();
                    persona.nombres = leer["NOMBRES"].ToString();
                    persona.correo = leer["CORREO"].ToString();
                    persona.nombrePerfil = leer["PERFIL"].ToString();
                    persona.ActivoEnLetras = leer["ACTIVO"].ToString();
                    persona.nombreUsuario = leer["NOMBRE USUARIO"].ToString();                    

                    listPersonas.Add(persona);

                }

                //se cierra la conexion a la BD cada vez que se abre
                conexionOracle.Close();

                return listPersonas;

            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<PersonaGrid> ListarPersonasGridPorRut(int rut,string dv)
        {
            try
            {
                //Crear conexion y conectar
                OracleConnection conexionOracle = new ConexionOracle().abrirConexion();

                OracleCommand comando = new OracleCommand("BUSCAR_USUARIO_RUT", conexionOracle);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("CURSOR_T", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
                comando.Parameters.Add("V_RUT", OracleDbType.Int32).Value = rut;
                comando.Parameters.Add("V_DV", OracleDbType.Varchar2).Value = dv;
                OracleDataReader leer = comando.ExecuteReader();
                List<PersonaGrid> listPersonas = new List<PersonaGrid>();
                while (leer.Read())
                {
                    PersonaGrid persona = new PersonaGrid();
                    persona.IdPersona = int.Parse(leer["ID_PERSONA"].ToString());
                    persona.RutString = leer["RUT"].ToString();
                    //persona.nombreCompleto = leer["NOMBRE COMPLETO"].ToString();
                    persona.nombres = leer["NOMBRES"].ToString();
                    persona.apellidopat = leer["APELLIDO PATERNO"].ToString();
                    persona.apellidomat = leer["APELLIDO MATERNO"].ToString();
                    persona.nombres = leer["NOMBRES"].ToString();
                    persona.correo = leer["CORREO"].ToString();
                    persona.nombrePerfil = leer["PERFIL"].ToString();
                    persona.ActivoEnLetras = leer["ACTIVO"].ToString();
                    persona.nombreUsuario = leer["NOMBRE USUARIO"].ToString();

                    listPersonas.Add(persona);

                }

                //se cierra la conexion a la BD cada vez que se abre
                conexionOracle.Close();

                return listPersonas;

            }
            catch (Exception e)
            {
                return null;
            }
        }

        public DataSet ListarPersonasGrid()
        {
            try
            {
                //Crear conexion y conectar
                OracleConnection conexionOracle = new ConexionOracle().abrirConexion();

                string query = @"SELECT P.ID_PERSONA AS ID_PERSONA, P.RUT||'-'||P.DV AS RUT,p.id_perfil AS ID_PERFIL, UPPER(pf.descripcion) AS PERFIL,"
                                +"UPPER(P.NOMBRES) || ' ' || UPPER(P.APELLIDO_PAT) || ' ' || UPPER(P.APELLIDO_MAT) AS NOMBRE_COMPLETO, UPPER(P.CORREO) AS CORREO,"
                                +"CASE P.ACTIVO WHEN 1 THEN 'SÍ' WHEN 0 THEN 'INACTIVO' END AS ACTIVO, L.USUARIO AS NOMBRE_USUARIO FROM PERSONA P JOIN PERFIL PF ON P.ID_PERFIL = PF.ID_PERFIL JOIN LOGIN L ON L.ID_PERSONA = P.ID_PERSONA";

                OracleCommand comando = new OracleCommand("LISTAR_TODAS_PERSONAS", conexionOracle);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("CURSOR_T", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.Output;
                OracleDataReader leer = comando.ExecuteReader();
                //List<PersonaGrid> listPersonas = new List<PersonaGrid>();
                OracleDataAdapter da = new OracleDataAdapter(query, conexionOracle);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;

                //while (leer.Read())
                //{
                //    PersonaGrid persona = new PersonaGrid();
                //    persona.IdPersona = int.Parse(leer["ID_PERSONA"].ToString());
                //    persona.RutString = leer["RUT"].ToString();
                //    persona.nombreCompleto = leer["NOMBRE COMPLETO"].ToString();
                //    persona.correo = leer["CORREO"].ToString();
                //    persona.nombrePerfil = leer["PERFIL"].ToString();
                //    persona.ActivoEnLetras = leer["ACTIVO"].ToString();
                //    persona.nombreUsuario = leer["NOMBRE USUARIO"].ToString();

                //    listPersonas.Add(persona);

                //}

                //se cierra la conexion a la BD cada vez que se abre
                //conexionOracle.Close();

                //return listPersonas;

            }
            catch (Exception e)
            {
                return null;
            }
        }
        public bool AgregarUsuario(Persona persona)
        {
            try
            {
                OracleConnection conexionOracle = new ConexionOracle().abrirConexion();
                OracleCommand comando = new OracleCommand("AGREGAR_PERSONA", conexionOracle);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("P_RUT", OracleDbType.Int32).Value = persona.Rut2;
                comando.Parameters.Add("DIGITOV", OracleDbType.Varchar2).Value = persona.Dv;
                comando.Parameters.Add("NOMBRES", OracleDbType.Varchar2).Value = persona.Nombres;
                comando.Parameters.Add("APE_PAT", OracleDbType.Varchar2).Value = persona.ApellidoPat;
                comando.Parameters.Add("APE_MAT", OracleDbType.Varchar2).Value = persona.ApellidoMat;
                comando.Parameters.Add("ID_PERFIL", OracleDbType.Int32).Value = persona.IdPerfil;
                comando.Parameters.Add("CORREO", OracleDbType.Varchar2).Value = persona.Correo;
                comando.Parameters.Add("ACTIVO", OracleDbType.Int32).Value = Int32.Parse(persona.Activo.ToString());
                comando.Parameters.Add("NOMBRE_USUARIO", OracleDbType.Varchar2).Value = persona.NombreUsuario;
                comando.Parameters.Add("CONTRASENIA", OracleDbType.Varchar2).Value = Encriptado.GetSHA256(persona.Contrasenia);
                comando.Parameters.Add("OUT_SALIDA", OracleDbType.Int32).Direction = System.Data.ParameterDirection.Output;
                comando.ExecuteNonQuery();

                conexionOracle.Close();

                return true;


            }
            catch (Exception e)
            {
                return false;                
            }
        }

        public bool EditarUsuario(Persona persona)
        {
            try
            {
                OracleConnection conexionOracle = new ConexionOracle().abrirConexion();
                OracleCommand comando = new OracleCommand("EDITAR_USUARIO", conexionOracle);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("V_ID_PERSONA", OracleDbType.Int32).Value = persona.IdPersona;
                comando.Parameters.Add("V_RUT", OracleDbType.Int32).Value = persona.Rut2;
                comando.Parameters.Add("V_DV", OracleDbType.Varchar2).Value = persona.Dv;
                comando.Parameters.Add("V_NOMBRES", OracleDbType.Varchar2).Value = persona.Nombres;
                comando.Parameters.Add("V_APELLIDO_PAT", OracleDbType.Varchar2).Value = persona.ApellidoPat;
                comando.Parameters.Add("V_APELLIDO_MAT", OracleDbType.Varchar2).Value = persona.ApellidoMat;
                comando.Parameters.Add("V_CORREO", OracleDbType.Varchar2).Value = persona.Correo;
                comando.Parameters.Add("V_ID_PERFIL", OracleDbType.Int32).Value = persona.IdPerfil;
                comando.Parameters.Add("V_ACTIVO", OracleDbType.Int32).Value = Int32.Parse(persona.Activo.ToString());
                comando.Parameters.Add("V_USUARIO", OracleDbType.Varchar2).Value = persona.NombreUsuario;
                comando.Parameters.Add("V_CONTRASENIA", OracleDbType.Varchar2).Value = Encriptado.GetSHA256(persona.Contrasenia);
                //comando.Parameters.Add("OUT_SALIDA", OracleDbType.Int32).Direction = System.Data.ParameterDirection.Output;
                comando.ExecuteNonQuery();

                conexionOracle.Close();

                return true;


            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool EliminarPersona(int rut)
        {
            try
            {
                OracleConnection conexionOracle = new ConexionOracle().abrirConexion();
                OracleCommand comando = new OracleCommand("ELIMINAR_PERSONA", conexionOracle);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("P_RUT", OracleDbType.Int32).Value = rut;
                comando.ExecuteNonQuery();

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
