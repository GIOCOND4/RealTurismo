﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace RealTurismo
{
    /// <summary>
    /// Lógica de interacción para MantDepartamento.xaml
    /// </summary>
    public partial class MantDepartamento : MetroWindow
    {
        //el servicename es el nombre de la base de datos
        //por defecto es orcl
        string cadenaConexionOracle = "Data source=" +
                "(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)" +
                "(HOST=localhost)(PORT=1521))" +
                "(CONNECT_DATA=(SERVICE_NAME=TurismoReal)));" +
                "User Id = ADMINISTRADOR; Password = admin;";

        public MantDepartamento()
        {
            InitializeComponent();

            //Crear conexion
            OracleConnection conexionOracle = new OracleConnection(cadenaConexionOracle);
            // Conecta
            conexionOracle.Open();

            //cargar region
            string query = "SELECT Descripcion FROM REGION";
            OracleCommand Comando = new OracleCommand(query, conexionOracle);
            OracleDataReader lector = Comando.ExecuteReader();
            while (lector.Read())
            {
                cbbRegion.Items.Add(lector["Descripcion"].ToString());
            }
            cbbRegion.SelectedIndex = 0;

        }

        private void cbbRegion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbbProvincia.DataContext = null;
            cbbProvincia.Items.Clear();
            //Crear conexion
            OracleConnection conexionOracle = new OracleConnection(cadenaConexionOracle);
            // Conecta
            conexionOracle.Open();
 
            
            string region = cbbRegion.SelectedItem.ToString();
            //cargar provincia
            string query2 = $"select p.descripcion from provincia p " +
                        "inner join region r " +
                        "on r.id_region = p.id_region " +
                        "where r.descripcion = '" + region + "'";
            OracleCommand Comando2 = new OracleCommand(query2, conexionOracle);
            OracleDataReader lector2 = Comando2.ExecuteReader();
            while (lector2.Read())
            {
                cbbProvincia.Items.Add(lector2["Descripcion"].ToString());
            }
            
            cbbProvincia.SelectedItem = "";
            
        }
        
        private void cbbProvincia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbbComuna.DataContext = null;
            cbbComuna.Items.Clear();

            //Crear conexion
            OracleConnection conexionOracle = new OracleConnection(cadenaConexionOracle);
            // Conecta
            conexionOracle.Open();
            if(cbbProvincia.SelectedItem != null)
            {
                string provincia = cbbProvincia.SelectedItem.ToString();
                //cargar comunas
                string query3 = $"select c.descripcion from comuna c " +
                                "inner join provincia p " +
                                "on p.id_provincia = c.iid_provincia " +
                                "where p.descripcion = '" + provincia + "'";
                MessageBox.Show(query3);
                OracleCommand Comando3 = new OracleCommand(query3, conexionOracle);
                OracleDataReader lector3 = Comando3.ExecuteReader();
                while (lector3.Read())
                {
                    cbbComuna.Items.Add(lector3["Descripcion"].ToString());
                }
            }
            
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            //obtener datos
            string nombre = txtNombre.Text;
            string direccion = txtDireccion.Text;
            string costo = txtCosto.Text;
            string piso = txtPiso.Text;
            string cable = "0";
            string internet = "0";
            string calefaccion = "0";
            string amoblado = "0";
            string aire = "0";
            string balcon = "0";
            string disponible = "0";
            if (cbCable.IsChecked == true)
            {
                cable = "1";
            }
            if (cbInternet.IsChecked == true)
            {
                internet = "1";
            }
            if (cbCalefaccion.IsChecked == true)
            {
                calefaccion = "1";
            }
            if (cbAmoblado.IsChecked == true)
            {
                amoblado = "1";
            }
            if (cbAire.IsChecked == true)
            {
                aire = "1";
            }
            if (cbBalcon.IsChecked == true)
            {
                balcon = "1";
            }
            string nrohabitaciones = txtNHabitaciones.Text;
            string nrobaios = txtNBanios.Text;
            string nroPersonas = txtNPersonas.Text;
            if (cbDisponible.IsChecked == true)
            {
                disponible = "1";
            }

            string comuna = cbbComuna.SelectedItem.ToString();

            //Crear conexion
            OracleConnection conexionOracle = new OracleConnection(cadenaConexionOracle);
            // Conecta
            conexionOracle.Open();

            string buscarIdComuna = "select id_comuna from comuna "+
                "where descripcion = '"+ comuna +"'";

            OracleCommand Comando = new OracleCommand(buscarIdComuna, conexionOracle);

            OracleDataReader buscarID = Comando.ExecuteReader();

            if(buscarID.Read())
            {
                string id = buscarID.GetString(0);

                string añadirDepto = "INSERT INTO DEPARTAMENTO VALUES(" +
                "incremento_id_departamento.NextVal,'" + nombre + "','" + direccion + "'," + piso + "," + costo +
                "," + cable + "," + internet + "," + calefaccion + "," + amoblado + "," + aire + "," + balcon + "," + nrohabitaciones +
                "," + nrobaios + "," + nroPersonas + "," + disponible + "," + id+")";

                MessageBox.Show(añadirDepto);

                OracleCommand insertar = new OracleCommand(añadirDepto, conexionOracle);
                OracleDataReader CrearDepartamento = insertar.ExecuteReader();
                if (CrearDepartamento.Read())
                {
                    MessageBox.Show("El departamento ha sido ingresado con exito");
                    //colocador por motivos de prueba
                    txtNombre.Text = "";
                    txtDireccion.Text = "";
                    txtCosto.Text = "";
                    txtPiso.Text = "";
                    cbCable.IsChecked = false;
                    cbInternet.IsChecked = false;
                    cbCalefaccion.IsChecked = false;
                    cbAmoblado.IsChecked = false;
                    cbAire.IsChecked = false;
                    cbBalcon.IsChecked = false;
                    txtNHabitaciones.Text = "";
                    txtNBanios.Text = "";
                    txtNPersonas.Text = "";
                    cbDisponible.IsChecked = false;
                    cbbComuna.DataContext = null;
                    cbbComuna.Items.Clear();
                    cbbProvincia.DataContext = null;
                    cbbProvincia.Items.Clear();
                    cbbRegion.SelectedIndex = 0;

                }

                //pordia añadir un commit
                /*
                OracleCommand insertar = new OracleCommand(añadirDepto, conexionOracle);
                OracleTransaction transaccion;
                transaccion = conexionOracle.BeginTransaction(IsolationLevel.ReadCommitted);
                insertar.CommandText = añadirDepto;
                insertar.ExecuteNonQuery();
                transaccion.Commit();
                MessageBox.Show("Se inserto el departamento");*/
                

            }



        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            string iddepto = txtIdDepartamento.Text;
            //Crear conexion
            OracleConnection conexionOracle = new OracleConnection(cadenaConexionOracle);
            // Conecta
            conexionOracle.Open();
            if(iddepto != "")
            {
                MessageBox.Show("Item En Contruccion");
                conexionOracle.Close();

            }
            else
            {
                dgListadoDep.ItemsSource = ListarDepartamentos();
                /*string TodosLosId = "select * from departamento";
                OracleCommand comando = new OracleCommand(TodosLosId, conexionOracle);
                OracleDataAdapter da = new OracleDataAdapter(comando);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgListadoDep.DataContext = dt;*/

            }
        }

        public List<Departamentos> ListarDepartamentos()
        {
            try
            {
                //Crear conexion
                OracleConnection conexionOracle = new OracleConnection(cadenaConexionOracle);
                // Conecta
                conexionOracle.Open();
                OracleCommand comando = new OracleCommand("select * from departamento", conexionOracle);
                OracleDataReader leer = comando.ExecuteReader();
                List<Departamentos> listDepartamento = new List<Departamentos>();
                while(leer.Read())
                {
                    Departamentos depto = new Departamentos();
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

        private void dgListadoDep_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Departamentos depto = (Departamentos)dgListadoDep.SelectedItem;
            txtIdDepartamento.Text = depto.IdDepartamento.ToString();

            
        }


    }
}
