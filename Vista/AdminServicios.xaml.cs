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
using Conexion;
using BibliotecaControlador;
using Oracle.ManagedDataAccess.Client;
using BibliotecaModelo;
using Microsoft.Win32;
using System.IO;

namespace Vista
{
    /// <summary>
    /// Lógica de interacción para AdminServicios.xaml
    /// </summary>
    public partial class AdminServicios : MetroWindow
    {
        int idservicio = 0;
        string imagePath = "";
        private OpenFileDialog ofdSeleccionar = new OpenFileDialog();
        public AdminServicios()
        {
            InitializeComponent();
            
            OracleConnection conexionOracle = new ConexionOracle().abrirConexion();
            string query = "SELECT NOMBRE FROM TIPO_SERVICIO";
            OracleCommand Comando = new OracleCommand(query, conexionOracle);
            OracleDataReader lector = Comando.ExecuteReader();
            while (lector.Read())
            {
                cbbTipoServico.Items.Add(lector["NOMBRE"].ToString());
            }
            cbbTipoServico.SelectedIndex = 0;
            //Cargar region
            string newquery = "SELECT NOMBRE FROM REGION";
            OracleCommand Comando2 = new OracleCommand(newquery, conexionOracle);
            OracleDataReader lector2 = Comando2.ExecuteReader();
            while (lector2.Read())
            {
                cbbRegion.Items.Add(lector2["NOMBRE"].ToString());
            }
            cbbRegion.SelectedIndex = 0;
            cbbProvincia.SelectedIndex = 0;
            cbbComuna.SelectedIndex = 0;
            pbImagen.Source = null;
            ControllerServicio serv = new ControllerServicio();
            dgListado.ItemsSource = serv.ListarServicios();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Servicio serv = new Servicio();
                serv.Nombre = txtNombre.Text;
                serv.Costo = int.Parse(txtCosto.Text);
                int disponible = 0;
                if (cbDisponible.IsChecked == true)
                {
                    disponible = 1;
                }
                serv.Descripcion = txtDescripcion.Text;
                if (pbImagen.Source != null)
                {
                    serv.UbicacionFoto = imagePath;
                    serv.Foto = obtenerByteImagen();
                }
                else
                {
                    serv.UbicacionFoto = "null";
                }
                ListarServicio listserv = new ListarServicio();
                listserv.IdReserva = int.Parse(txtIdReserva.Text);

                string tiposervicio = cbbTipoServico.SelectedItem.ToString();
                string comuna = cbbComuna.SelectedItem.ToString();

                ControllerServicio controlServicio = new ControllerServicio();
                int id = controlServicio.IdTipoServicio(tiposervicio);
                int id1 = controlServicio.BuscarComuna(comuna);
                if (id > 0 && id1 > 0)
                {
                    bool agregar = controlServicio.AgregarServicio(serv.Nombre, serv.Costo, disponible, serv.Descripcion, serv.UbicacionFoto, serv.Foto, listserv.IdReserva, id, id1);
                    if (agregar == true)
                    {
                        MessageBox.Show("El servicio ha sido ingresado con exito");
                        txtNombre.Text = "";
                        txtCosto.Text = "";
                        txtDescripcion.Text = "";
                        txtIdReserva.Text = "";
                        cbDisponible.IsChecked = false;
                        imagePath = "";
                        pbImagen.Source = null;
                    }
                    else
                    {
                        MessageBox.Show("Error: No se ha podido ingresar el servicio");
                    }
                }
                else
                {
                    MessageBox.Show("Error: No se ha podido ingresar el servicio");
                }
                
                dgListado.ItemsSource = controlServicio.ListarServicios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string idservicio = txtFechaServicio.Text;
                if (idservicio == "")
                {
                    ControllerServicio serv = new ControllerServicio();
                    dgListado.ItemsSource = serv.ListarServicios();
                }
                else
                {
                    ControllerServicio servi = new ControllerServicio();
                    dgListado.ItemsSource = servi.ListarServiciosID(int.Parse(idservicio));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ingrese un id servicio valido");
            }
            
        }

        private void dgListado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Servicio serv = (Servicio)dgListado.SelectedItem;
            if (dgListado.SelectedItem != null)
            {
                txtNombre.Text = serv.Nombre.ToString();
                txtCosto.Text = serv.Costo.ToString();
                txtDescripcion.Text = serv.Descripcion.ToString();
                if (serv.Disponible == false)
                {
                    cbDisponible.IsChecked = false;
                }
                else
                {
                    cbDisponible.IsChecked = true;
                }
                idservicio = serv.IdServicio;
                

            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = idservicio;
                if (MessageBox.Show("¿Esta seguro que desea eliminar el siguiente servicio? : " + id, "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    MessageBox.Show("Operacion Abortada");
                }
                else
                {
                    ControllerServicio serv = new ControllerServicio();
                    bool eliminar = serv.EliminarServicio(id);
                    if (eliminar == true)
                    {
                        MessageBox.Show("El servicio ha sido eliminado con exito");
                        txtNombre.Text = "";
                        txtCosto.Text = "";
                        txtDescripcion.Text = "";
                        txtIdReserva.Text = "";
                        cbDisponible.IsChecked = false;
                        imagePath = "";
                        pbImagen.Source = null;
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el servicio");
                    }
                    dgListado.ItemsSource = serv.ListarServicios();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Servicio serv = new Servicio();
                serv.IdServicio = idservicio;
                serv.Nombre = txtNombre.Text;
                serv.Costo = int.Parse(txtCosto.Text);
                int disponible = 0;
                if (cbDisponible.IsChecked == true)
                {
                    disponible = 1;
                }
                serv.Descripcion = txtDescripcion.Text;
                
                if (imagePath == "")
                {
                    serv.UbicacionFoto = "null";
                }
                else
                {
                    serv.UbicacionFoto = imagePath;
                }
                if (pbImagen.Source != null)
                {
                    serv.Foto = obtenerByteImagen();
                }
                string tiposervicio = cbbTipoServico.SelectedItem.ToString();
                string comuna = cbbComuna.SelectedItem.ToString();



                ListarServicio listserv = new ListarServicio();
                listserv.IdReserva = int.Parse(txtIdReserva.Text);

                ControllerServicio controlServicio = new ControllerServicio();
                int id = controlServicio.IdTipoServicio(tiposervicio);
                int id1 = controlServicio.BuscarComuna(comuna);
                if (id > 0 && id1 > 0)
                {
                    if (MessageBox.Show("¿Esta seguro que desea modificar el siguiente servicio? : " + serv.IdServicio, "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {

                        bool modificar = controlServicio.EditarServicio(serv.IdServicio, serv.Nombre, serv.Costo, disponible, serv.Descripcion, serv.UbicacionFoto, serv.Foto, listserv.IdReserva,id,id1);
                        if (modificar == true)
                        {
                            MessageBox.Show("El servicio ha sido modificado con exito");
                            txtNombre.Text = "";
                            txtCosto.Text = "";
                            txtDescripcion.Text = "";
                            txtIdReserva.Text = "";
                            cbDisponible.IsChecked = false;
                            imagePath = "";
                            pbImagen.Source = null;
                        }
                        else
                        {
                            MessageBox.Show("Error: No se ha podido modificado el servicio");
                        }
                        dgListado.ItemsSource = controlServicio.ListarServicios();
                    }
                    else
                    {
                        MessageBox.Show("Operacion abortada");
                    }
                }
                else
                {
                    MessageBox.Show("Error: No se ha podido modificado el servicio");
                }
               
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        private void btnImagenes_Click(object sender, RoutedEventArgs e)
        {
            ofdSeleccionar.Filter = "Imagenes|*.jpg; *.png; *.webp;*.jpeg";
            ofdSeleccionar.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            ofdSeleccionar.Title = "Seleccionar imagen";
            ofdSeleccionar.ShowDialog();
            imagePath = @"" + ofdSeleccionar.FileName;

            byte[] binaryData = obtenerByteRuta(imagePath);
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.StreamSource = new MemoryStream(binaryData);
            bi.EndInit();
            pbImagen.Source = bi;
        }

        protected static byte[] obtenerByteRuta(string imgPath)
        {
            byte[] imageBytes = System.IO.File.ReadAllBytes(imgPath);
            return imageBytes;
        }

        public byte[] obtenerByteImagen()
        {
            byte[] arr;
            if (pbImagen.Source != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    var bmp = pbImagen.Source as BitmapImage;
                    JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(bmp));
                    encoder.Save(ms);
                    arr = ms.ToArray();
                }
            }
            else
            {
                arr = null;
            }
            return arr;

        }

        private void cbbProvincia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbbComuna.DataContext = null;
            cbbComuna.Items.Clear();

            OracleConnection conexionOracle = new ConexionOracle().abrirConexion();

            if (cbbProvincia.SelectedItem != null)
            {
                string provincia = cbbProvincia.SelectedItem.ToString();
                //cargar comunas
                string query3 = $"select c.nombre from comuna c " +
                                "inner join provincia p " +
                                "on p.id_provincia = c.id_provincia " +
                                "where p.nombre = '" + provincia + "'";
                OracleCommand Comando3 = new OracleCommand(query3, conexionOracle);
                OracleDataReader lector3 = Comando3.ExecuteReader();
                while (lector3.Read())
                {
                    cbbComuna.Items.Add(lector3["NOMBRE"].ToString());
                }
            }
            cbbComuna.SelectedIndex = 0;
        }

        private void cbbRegion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbbProvincia.DataContext = null;
            cbbProvincia.Items.Clear();

            OracleConnection conexionOracle = new ConexionOracle().abrirConexion();

            string region = cbbRegion.SelectedItem.ToString();
            //cargar provincia
            string query2 = $"select p.nombre from provincia p " +
                        "inner join region r " +
                        "on r.id_region = p.id_region " +
                        "where r.nombre = '" + region + "'";
            OracleCommand Comando2 = new OracleCommand(query2, conexionOracle);
            OracleDataReader lector2 = Comando2.ExecuteReader();
            while (lector2.Read())
            {
                cbbProvincia.Items.Add(lector2["NOMBRE"].ToString());
            }

            cbbProvincia.SelectedIndex = 0;
        }
    }
}
