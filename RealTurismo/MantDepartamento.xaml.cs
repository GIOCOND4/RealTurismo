using System;
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
            cbbProvincia.SelectedIndex = 0;
            cbbComuna.SelectedIndex = 0;

        }

        //Poblar combobox de provincia por region escogida
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

            cbbProvincia.SelectedIndex = 0;

            //cbbProvincia.SelectedItem = "";

        }

        //poblar combobox de region por provincia escogida
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
                OracleCommand Comando3 = new OracleCommand(query3, conexionOracle);
                OracleDataReader lector3 = Comando3.ExecuteReader();
                while (lector3.Read())
                {
                    cbbComuna.Items.Add(lector3["Descripcion"].ToString());
                }
            }
            cbbComuna.SelectedIndex = 0;
            dgListadoDep.ItemsSource = ListarDepartamentos();

        }

        //Agregar un departamento
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

                OracleCommand insertar = new OracleCommand(añadirDepto, conexionOracle);
                OracleDataReader CrearDepartamento = insertar.ExecuteReader();
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
                MessageBox.Show("El departamento ha sido ingresado con exito");
                dgListadoDep.ItemsSource = ListarDepartamentos();
            }
        }

        //busca de un departamento
        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            string iddepto = txtIdDepartamento.Text;
            //Crear conexion
            OracleConnection conexionOracle = new OracleConnection(cadenaConexionOracle);
            // Conecta
            conexionOracle.Open();
            if(iddepto != "")
            {
                dgListadoDep.ItemsSource = ListarDeptoPorID(int.Parse(iddepto));
            }
            else
            {
                dgListadoDep.ItemsSource = ListarDepartamentos();
            }
        }

        //metodo listar todos los departamentos
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

        //metodo listar todos los departamentos
        public List<Departamentos> ListarDeptoPorID(int idabuscar)
        {
            try
            {
                //Crear conexion
                OracleConnection conexionOracle = new OracleConnection(cadenaConexionOracle);
                // Conecta
                conexionOracle.Open();
                OracleCommand comando = new OracleCommand("select * from departamento where id_departamento = "+ idabuscar, conexionOracle);
                OracleDataReader leer = comando.ExecuteReader();
                List<Departamentos> listDepartamento = new List<Departamentos>();
                while (leer.Read())
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

        //eliminar departamento por id
        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if(txtIdDepartamento.Text != ""){
                try
                {
                    //Crear conexion
                    OracleConnection conexionOracle = new OracleConnection(cadenaConexionOracle);
                    // Conecta
                    conexionOracle.Open();
                    string id = txtIdDepartamento.Text;
                    if (MessageBox.Show("¿Esta seguro que desea eliminar el siguiente departamento? : "+id, "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                    {
                        //do no stuff
                        conexionOracle.Close();
                        MessageBox.Show("Operacion Abortada");
                    }
                    else
                    {
                        int flag = 0;
                        OracleCommand comando = new OracleCommand("delete from departamento where id_departamento = "+id, conexionOracle);
                        //OracleDataReader eliminar = comando.ExecuteReader();
                        flag = comando.ExecuteNonQuery(); // determina si existe la consul
                        if (flag == 1)
                        {
                            MessageBox.Show("El departamento escogido fue eliminado con exito");
                        }
                        else
                        {
                            MessageBox.Show("No se encontro el departamento");
                        }
                        
                    }
                }
                catch (Exception)
                {
                    return;
                }
            }
        }
        
        //poblar textbox por departamento escogido
        private void dgListadoDep_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Departamentos depto = (Departamentos)dgListadoDep.SelectedItem;
            if (dgListadoDep.SelectedItem != null)
            {
                txtIdDepartamento.Text = depto.IdDepartamento.ToString();
                txtNombre.Text = depto.NombreDescriptivo.ToString();
                txtDireccion.Text = depto.Direccion.ToString();
                txtCosto.Text = depto.Costo.ToString();
                txtPiso.Text = depto.Piso.ToString();
                if (depto.Cable == false)
                {
                    cbCable.IsChecked = false;
                }
                else{
                    cbCable.IsChecked = true;
                }
                if (depto.Internet == false)
                {
                    cbInternet.IsChecked = false;
                }
                else
                {
                    cbInternet.IsChecked = true;
                }
                if (depto.Calefaccion == false)
                {
                    cbCalefaccion.IsChecked = false;
                }
                else
                {
                    cbCalefaccion.IsChecked = true;
                }
                if (depto.Amoblado == false)
                {
                    cbAmoblado.IsChecked = false;
                }
                else
                {
                    cbAmoblado.IsChecked = true;
                }
                if (depto.AireAcondiconado == false)
                {
                    cbAire.IsChecked = false;
                }
                else
                {
                    cbAire.IsChecked = true;
                }
                if (depto.Balcon == false)
                {
                    cbBalcon.IsChecked = false;
                }
                else
                {
                    cbBalcon.IsChecked = true;
                }
                txtNHabitaciones.Text = depto.NroHabitaciones.ToString();
                txtNBanios.Text = depto.NroBanios.ToString();
                txtNPersonas.Text = depto.CantidadPersonas.ToString();
                if (depto.Disponible == false)
                {
                    cbDisponible.IsChecked = false;
                }
                else
                {
                    cbDisponible.IsChecked = true;
                }
                cbbRegion.SelectedIndex = 0;
            }
            
            
        }

        //modificar departamento por id
        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (txtIdDepartamento.Text != "")
            {
                
                try
                {
                    //Crear conexion
                    OracleConnection conexionOracle = new OracleConnection(cadenaConexionOracle);
                    // Conecta
                    conexionOracle.Open();
                    Departamentos depto = new Departamentos();
                    depto.IdDepartamento = int.Parse(txtIdDepartamento.Text);
                    depto.NombreDescriptivo = txtNombre.Text;
                    depto.Direccion = txtDireccion.Text;
                    depto.Costo = int.Parse(txtCosto.Text);
                    depto.Piso  = int.Parse(txtPiso.Text);
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
                    depto.NroHabitaciones = int.Parse(txtNHabitaciones.Text);
                    depto.NroBanios = int.Parse(txtNBanios.Text);
                    depto.CantidadPersonas = int.Parse(txtNPersonas.Text);
                    if (cbDisponible.IsChecked == true)
                    {
                        disponible = "1";
                    }
                    string comuna = cbbComuna.SelectedItem.ToString();

                    string buscarIdComuna = "select id_comuna from comuna " +
                    "where descripcion = '" + comuna + "'";

                    OracleCommand Comando = new OracleCommand(buscarIdComuna, conexionOracle);
                    OracleDataReader buscarID = Comando.ExecuteReader();
                    if (buscarID.Read())
                    {
                        string id = buscarID.GetString(0);
                        string sql = "UPDATE DEPARTAMENTO " +
                        "SET NOMBRE_DESCRIPTIVO = '" + depto.NombreDescriptivo + "', DIRECCION = '"+ depto.Direccion +"', PISO = "+ depto.Piso +", "+
                        "COSTO = "+ depto.Costo +", CABLE = "+ cable +", INTERNET = "+ internet +", CALEFACCION = "+ calefaccion +", "+
                        "AMOBLADO = "+ amoblado +", AIRE_ACONDICIONADO = "+ aire +", BALCON = "+ balcon +", NRO_HABITACIONES = "+ depto.NroHabitaciones + ", "+
                        "NRO_BANIOS = "+ depto.NroBanios +", CANT_PERSONAS = "+ depto.CantidadPersonas +", DISPONIBLE = "+ disponible +", ID_COMUNA = "+id+" "+
                        "WHERE ID_DEPARTAMENTO = "+ depto.IdDepartamento ;
                        OracleCommand consulta = new OracleCommand(sql,conexionOracle);

                        MessageBox.Show(sql);
                        if (MessageBox.Show("¿Esta seguro que desea modificar el siguiente departamento? : " + depto.IdDepartamento, "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                        {
                            int flag = 0;
                            flag = consulta.ExecuteNonQuery(); // determina si existe la consul
                            if (flag == 1)
                            {
                                MessageBox.Show("El departamento escogido fue modificado con exito");
                                dgListadoDep.ItemsSource = ListarDepartamentos();
                            }
                            else
                            {
                                MessageBox.Show("No se encontro el departamento");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Operacion abortada");
                        }
                    }
                }
                catch (Exception)
                {
                    return;
                }
            }
        }
    }
}
