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
using BibliotecaControlador;
using System.Data;
using BibliotecaModelo;

namespace Vista
{
    /// <summary>
    /// Lógica de interacción para AdminUsuario.xaml
    /// </summary>
    public partial class AdminUsuario : MetroWindow
    {
        ControllerPersona cp = new ControllerPersona();
        int idpersona = 0;
        public AdminUsuario()
        {
            InitializeComponent();
            
            foreach (var item in cp.ListarPerfiles())
            {
                cbbPerfil.Items.Add(item.descripcion.ToString());
            }

            dgListadoUsuario.ItemsSource = cp.ListarPersonasGrid1();
            //dgListadoUsuario.ItemsSource = cp.ListarPersonasGrid();
            //dgListadoUsuario.BindingGroup.ToString();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            int activo = 0;
            int cbbIndexPerfil = 0;
            cbbIndexPerfil = cbbPerfil.SelectedIndex + 1;
            try
            {
                if (cbActivo.IsChecked==true)
                {
                    activo = 1;
                }
                else
                {
                    activo = 0;
                }
                Persona persona = new Persona()
                {
                    Rut2 = int.Parse(txtRut.Text),
                    Dv = txtDv.Text,
                    Nombres = txtNombre.Text,
                    ApellidoPat = txtApellidoP.Text,
                    ApellidoMat = txtApellidoM.Text,
                    Correo = txtCorreo.Text,
                    NombreUsuario = txtNombreUsuario.Text,
                    Contrasenia = pbContrasenia.Password,
                    IdPerfil = cbbIndexPerfil,
                    Activo = activo,                    
                };
                bool añadir = cp.AgregarUsuario(persona);
                if (añadir)
                {
                    MessageBox.Show("El usuario fue añadido correctamente.");
                    txtRut.Text = "";
                    txtDv.Text = "";
                    txtNombre.Text = "";
                    txtApellidoP.Text = "";
                    txtApellidoM.Text = "";
                    txtCorreo.Text = "";
                    txtNombreUsuario.Text = "";
                    pbContrasenia.Password = "";
                    cbbPerfil.SelectedIndex = 0;
                    cbActivo.IsChecked = false;
                    idpersona = 0;
                }
                else
                {
                    MessageBox.Show("No se pudo añadir al Usuario.");
                }
                dgListadoUsuario.ItemsSource = cp.ListarPersonasGrid1();
            }
            catch (Exception error)
            {
                MessageBox.Show("Ocurrió un error al intentar agregar el usuario: "+ error);
            }
        }

        private void btnBuscarRut_Click(object sender, RoutedEventArgs e)
        {
            string rut = txtRut.Text;
            string dv = txtDv.Text;
            if (rut != "" && dv != "")
            {
                dgListadoUsuario.ItemsSource = cp.ListarPersonasGridPorRut(int.Parse(rut),dv);
            }
            else
            {
                dgListadoUsuario.ItemsSource = cp.ListarPersonasGrid1();
            }
                /*
                string rut = txtRut.Text;
                DataTable dt = new DataTable();
                dt.Columns.Add("ID PERSONA");
                dt.Columns.Add("RUT");
                dt.Columns.Add("NOMBRE COMPLETO");
                dt.Columns.Add("CORREO");
                dt.Columns.Add("PERFIL");
                dt.Columns.Add("ACTIVO");
                dt.Columns.Add("NOMBRE USUARIO");
                //dt.Rows.Add();
                DataSet ds = new DataSet();
                ds = cp.ListarPersonasGrid();

                //dt.Rows.Add()

                //dgListadoUsuario.ItemsSource = dt.Rows.Add(ds.Tables[0].Rows);

                if (rut == "")
                {
                    //dgListadoUsuario(ds.Tables[0].Rows);
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        dt.Rows.Add(new object[] {row[0], row [1], row[2], row[3], row[4], row[5]});                   
                    }
                    //dgListadoUsuario.Data = dt;

                    //dgListadoUsuario.ItemsSource = cp.ListarPersonasGrid();
                }
                else
                {
                    //dgListadoUsuario.ItemsSource = cp.ListarPersonasRut(int.Parse(rut));                
                }
                */
            }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            int rut = int.Parse(txtRut.Text);

            try
            {

                if (rut == 0)
                {
                    MessageBox.Show("Debe ingresar un Rut antes de eliminar");
                }
                else
                {
                    if (MessageBox.Show("¿Esta seguro que desea eliminar el usuario? : " + rut, "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                    {
                        MessageBox.Show("Operacion Abortada");
                    }
                    else
                    {
                        bool eliminar = cp.EliminarPersona(rut);
                        if (eliminar)
                        {
                            MessageBox.Show("El usuario fue eliminado correctamente.");
                            txtRut.Text = "";
                            txtDv.Text = "";
                            txtNombre.Text = "";
                            txtApellidoP.Text = "";
                            txtApellidoM.Text = "";
                            txtCorreo.Text = "";
                            txtNombreUsuario.Text = "";
                            pbContrasenia.Password = "";
                            cbbPerfil.SelectedIndex = 0;
                            cbActivo.IsChecked = false;
                            idpersona = 0;
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar el usuario");
                        }
                    }
                }
                dgListadoUsuario.ItemsSource = cp.ListarPersonasGrid1();
            }
            catch (Exception error)
            {
                MessageBox.Show("Ocurrió un error al intentar eliminar el usuario: "+error);
            }
            
            }

        private void dgListadoUsuario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PersonaGrid pg =(PersonaGrid)dgListadoUsuario.SelectedItem;
            if (dgListadoUsuario.SelectedItem != null)
            {
                string rut = pg.RutString.ToString();
                //rescatar el digito verificador
                string dv = rut.Substring(rut.Length - 1);
                //eliminar lo que viene despues de -
                rut = rut.Remove(rut.IndexOf("-"));

                /*
                //este punto es para separar el nombre de los apellidos (en nombres solo rescata el primer nombre hasta el espacio)
                //no he descubirto como hacerlo en caso de que hayan mas de 2 nombres.
                //lo dejare asi porque si no me estare rompiendo el coco toda la tarde xd
                string nombrecompleto = pg.nombreCompleto.ToString();
                string nombre = nombrecompleto.Substring(0, nombrecompleto.IndexOf(" "));
                string apellidos = nombrecompleto.Substring(nombrecompleto.IndexOf(" ") + 1);
                string apematerno = apellidos.Substring(apellidos.IndexOf("") + 1);
                MessageBox.Show(nombre);
                MessageBox.Show(apellidos);
                MessageBox.Show(apematerno);
                Ver cual solucion es mejor*/




                txtRut.Text = rut;
                txtDv.Text = dv;
                txtNombre.Text = pg.nombres.ToString();
                txtApellidoP.Text = pg.apellidopat.ToString();
                txtApellidoM.Text = pg.apellidomat.ToString();
                txtCorreo.Text = pg.correo.ToString();
                if (pg.ActivoEnLetras == "SÍ")
                {
                    cbActivo.IsChecked = true;
                }
                else
                {
                    cbActivo.IsChecked = false;
                }
                cbbPerfil.SelectedIndex = 0;
                txtNombreUsuario.Text = pg.nombreUsuario.ToString();
                idpersona = pg.IdPersona;




            }
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (idpersona > 0)
            {
                int activo = 0;
                int cbbIndexPerfil = 0;
                cbbIndexPerfil = cbbPerfil.SelectedIndex + 1;
                try
                {
                    if (cbActivo.IsChecked == true)
                    {
                        activo = 1;
                    }
                    else
                    {
                        activo = 0;
                    }
                    Persona persona = new Persona()
                    {
                        IdPersona = idpersona,
                        Rut2 = int.Parse(txtRut.Text),
                        Dv = txtDv.Text,
                        Nombres = txtNombre.Text,
                        ApellidoPat = txtApellidoP.Text,
                        ApellidoMat = txtApellidoM.Text,
                        Correo = txtCorreo.Text,
                        NombreUsuario = txtNombreUsuario.Text,
                        Contrasenia = pbContrasenia.Password,
                        IdPerfil = cbbIndexPerfil,
                        Activo = activo,
                    };
                    if (MessageBox.Show("¿Esta seguro que desea modificar el siguiente departamento? : " + persona.IdPersona, "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        bool añadir = cp.EditarUsuario(persona);
                        if (añadir)
                        {
                            MessageBox.Show("El usuario fue modificado correctamente.");
                            txtRut.Text = "";
                            txtDv.Text = "";
                            txtNombre.Text = "";
                            txtApellidoP.Text = "";
                            txtApellidoM.Text = "";
                            txtCorreo.Text = "";
                            txtNombreUsuario.Text = "";
                            pbContrasenia.Password = "";
                            cbbPerfil.SelectedIndex = 0;
                            cbActivo.IsChecked = false;
                            idpersona = 0;
                        }
                        else
                        {
                            MessageBox.Show("No se pudo modificar al Usuario.");
                        }
                        dgListadoUsuario.ItemsSource = cp.ListarPersonasGrid1();
                    }
                    else
                    {
                        MessageBox.Show("Operacion abortada");
                    }
                    
                }
                catch (Exception error)
                {
                    MessageBox.Show("Ocurrió un error al intentar editar el usuario: " + error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un usuario de la lista");
            }
            
        }
    }
}
