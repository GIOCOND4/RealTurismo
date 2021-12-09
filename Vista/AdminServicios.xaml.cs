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
                serv.UbicacionFoto = imagePath;
                serv.Foto = obtenerByteImagen();
                ListarServicio listserv = new ListarServicio();
                listserv.IdReserva = int.Parse(txtIdReserva.Text);

                ControllerServicio controlServicio = new ControllerServicio();
                bool agregar = controlServicio.AgregarServicio(serv.Nombre, serv.Costo, disponible, serv.Descripcion, serv.UbicacionFoto, serv.Foto, listserv.IdReserva);
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
                    serv.UbicacionFoto = "";
                }
                else
                {
                    serv.UbicacionFoto = imagePath;
                }
                if (obtenerByteImagen() == null)
                {
                    serv.Foto = null;
                }
                else
                {
                    serv.Foto = obtenerByteImagen();
                }
                
                
                ListarServicio listserv = new ListarServicio();
                listserv.IdReserva = int.Parse(txtIdReserva.Text);

                ControllerServicio controlServicio = new ControllerServicio();
                if (MessageBox.Show("¿Esta seguro que desea modificar el siguiente servicio? : " + serv.IdServicio, "Advertencia", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    bool modificar = controlServicio.EditarServicio(serv.IdServicio, serv.Nombre, serv.Costo, disponible, serv.Descripcion, serv.UbicacionFoto, serv.Foto, listserv.IdReserva);
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
            using (MemoryStream ms = new MemoryStream())
            {
                var bmp = pbImagen.Source as BitmapImage;
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bmp));
                encoder.Save(ms);
                arr = ms.ToArray();
            }
            return arr;

        }
    }
}
