using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TorneoAnual.Modelos;

namespace TorneoAnual
{
    /// <summary>
    /// Lógica de interacción para Modificar.xaml
    /// </summary>
    public partial class Modificar : Window, INotifyPropertyChanged
    {
        Usuario usuario = new Usuario();
        ConexionBD conexion = new ConexionBD();
        BitmapImage bi;

        public ObservableCollection<FilterInfo> VideoDevices { get; set; }

        public FilterInfo CurrentDevice
        {
            get { return _currentDevice; }
            set { _currentDevice = value; this.OnPropertyChanged("CurrentDevice"); }
        }
        private FilterInfo _currentDevice;


        ObservableCollection<string> TipoGolf = new ObservableCollection<string>();
        ObservableCollection<string> TipoTenis = new ObservableCollection<string>();
        ObservableCollection<string> Torneo = new ObservableCollection<string>();


        private IVideoSource _videoSource;
        SqlConnection cadena = new SqlConnection(@"Data Source= DESKTOP-JH5TK9;Initial Catalog=TorneoAnual; Integrated Security= True");

        public Modificar()
        {
            InitializeComponent();
            this.DataContext = this;
            GetVideoDevices();


            conexion = new ConexionBD();


            //Con el metodo getAllUsers() obtendremos todos los nombres registrados en la base de datos
            //para acomodarlos en nuestro comboBox
            cmbNombre.ItemsSource = conexion.getAllNamesUsers().ToArray();
            //       CmbTorneo.ItemTemplate.LoadContent(conexion.obtenerTorneosActuales().ToArray());

            cmbGolf.ItemsSource = conexion.obtenerCategoriasGolf().ToArray();
            cmbTenis.ItemsSource = conexion.obtenerCategoriasTennis().ToArray();
            CmbTorneo.ItemsSource = conexion.obtenerTorneosActuales().ToArray();
        }



        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {

            if (tbNombre.Text == "")
            {
                MessageBox.Show("El campo Nombre debe ser especificado", "Error");
                return;
            }

            if (tbApellidoP.Text == "")
            {
                MessageBox.Show("El campo Apellidos debe ser especificado", "Error");
                return;
            }
            if (tbApellidoM.Text == "")
            {
                MessageBox.Show("El campo Apellidos debe ser especificado", "Error");
                return;
            }
            if (tbCelular.Text == "")
            {
                MessageBox.Show("El campo Número de empleado debe ser especificado", "Error");
                return;
            }

          

            try
            {
                usuario.nombre = tbNombre.Text;
                usuario.apellidoP = tbApellidoP.Text;
                usuario.apellidoM = tbApellidoM.Text;
                usuario.correo = tbCorreo.Text;
                usuario.tel = tbCelular.Text;
                usuario.club = tbClub.Text;
                usuario.categoriaTipo = CmbTorneo.Text;
                //usuario.imagen = picFoto.Source;
              //  usuario.huella = Template.Bytes;


                int id = conexion.Alta(usuario);

                if (id > 0)
                {

                    MessageBox.Show("jugador guardado correctamente", "Guardar");

                    this.Close();
                    /* tbNombre.Text = "";
                     tbApellidoP.Text = "";
                     tbApellidoM.Text = "";
                     tbClub.Text = "";
                     tbCorreo.Text = "";
                     tbCelular.Text = "";*/

                    // picFoto.Source = null;
                    //  imgFoto.Source = null;
                    //  dgEmpleados.DataContext = DatoEmpleado.MuestraEmpleados();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("No fue posible guardar el Usuario: " + ex.Message, "Error en Guardar");
            }
        }

        private void chkTenis_CheckedChanged(object sender, EventArgs e)
        {
            if ((bool)(chkTenis.IsChecked = true))
            {
                cmbTenis.IsEnabled = true;
                cmbGolf.IsEnabled = false;
                usuario.categoriaTipo = "T";
                //usuario.categoriaDescripcion = (string)chkTenis.Content;
                chkGolf.IsChecked = false;

            }
        }

        //Desahbilita/ habilita el chkTenis, dependiendo del evento recibido
        private void chkGolf_CheckedChanged(object sender, EventArgs e)
        {
            if ((bool)(chkGolf.IsChecked = true))
            {
                cmbGolf.IsEnabled = true;
                cmbTenis.IsEnabled = false;
                usuario.categoriaTipo = "G";
                //usuario.categoriaDescripcion = (string)chkGolf.Content;
                chkTenis.IsChecked = false;

            }
        }

        #region CAMARA
        private void btnCamara_Click(object sender, RoutedEventArgs e)
        {

            //Camara camara = new Camara();
            //camara.Show();
            StartCamera();

        }
        private void btnCapturar_Click(object sender, RoutedEventArgs e)
        {
            StopCamera();
        }


        //Muestra la imagen en pantalla 
        private void video_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            try
            {
                // BitmapImage bi;
                using (var bitmap = (Bitmap)eventArgs.Frame.Clone())
                {

                    bi = bitmap.ToBitmapImage();
                }
                bi.Freeze(); // avoid cross thread operations and prevents leaks
                Dispatcher.BeginInvoke(new ThreadStart(delegate { picFoto.Source = bi; }));
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error" + exc.Message);
                StopCamera();
            }
        }




        private void StartCamera()
        {
            if (CurrentDevice != null)
            {
                _videoSource = new VideoCaptureDevice(CurrentDevice.MonikerString);
                _videoSource.NewFrame += video_NewFrame;
                _videoSource.Start();
            }
            else
            {
                _videoSource.WaitForStop();
            }
        }

        private void StopCamera()
        {
            if (_videoSource != null && _videoSource.IsRunning)
            {
                _videoSource.SignalToStop();
                _videoSource.NewFrame -= new NewFrameEventHandler(video_NewFrame);
                byte[] data;
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bi));
                using (System.IO.MemoryStream ms = new MemoryStream())
                {
                    encoder.Save(ms);
                    data = ms.ToArray();
                    usuario.imagen = data;
                }

            }
        }

        #region INotifyPropertyChanged members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }


        private void GetVideoDevices()
        {
            VideoDevices = new ObservableCollection<FilterInfo>();
            foreach (FilterInfo filterInfo in new FilterInfoCollection(FilterCategory.VideoInputDevice))
            {
                VideoDevices.Add(filterInfo);
            }
            if (VideoDevices.Any())
            {
                CurrentDevice = VideoDevices[0];
            }
            else
            {
                MessageBox.Show("Favor de conectar una camara");
            }
        }


        #endregion
        #endregion



        #region Registro Huella 
        private void BtnRegistro_Click(object sender, RoutedEventArgs e)
        {
            EnrollmentForm Enroller = new EnrollmentForm();
            Enroller.OnTemplate += this.OnTemplate;
            Enroller.ShowDialog();
        }

        private void OnTemplate(DPFP.Template template)
        {
            this.Dispatcher.Invoke(new Function(delegate ()
            {
                Template = template;
                //VerifyButton.Enabled = SaveButton.Enabled = (Template != null);
                if (Template != null)
                {
                    MessageBox.Show("La huella ha sido capturada correctamente", "Capturar huella.");
                    imgVerHuella.Visibility = Visibility.Visible;
                }
                else
                    MessageBox.Show("The fingerprint template is not valid. Repeat fingerprint enrollment.", "Fingerprint Enrollment");
            }));
        }

        private DPFP.Template Template;


        #endregion

        #region Documentacion
        #endregion

        private void cmbGolf_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Tomaremos el nombre seleccionado en el comboBox
            var itemSeleccionado = (string)cmbGolf.SelectedItem;

            if (itemSeleccionado != null)
            {
                usuario.categoriaDescripcion = itemSeleccionado;
            }
        }

        private void cmbTennis_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Tomaremos el nombre seleccionado en el comboBox
            var itemSeleccionado = (string)cmbTenis.SelectedItem;

            if (itemSeleccionado != null)
            {
                usuario.categoriaDescripcion = itemSeleccionado;
            }
        }

        private void CmbTorneo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var itemSeleccionado = (string)CmbTorneo.SelectedItem;

            if (itemSeleccionado != null)
            {
                usuario.torneo = itemSeleccionado;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Tomaremos el nombre seleccionado en el comboBox
            var itemSeleccionado = (string)cmbNombre.SelectedItem;

            if (itemSeleccionado != null)
            {
                //Le hacemos un split por espacios para que nos quede un arreglo con los nombres del usuario
                var array = itemSeleccionado.Split(' ');

                //Utilizaremos el siguiente for para conjuntar todos los nombres del usuario en un string
                //debido a que un usuario puede tener muchos nombres
                string nombres = "";
                for (int i = 0; i < array.Length - 2; i++)
                {
                    nombres += array[i] + " ";
                }

                //Le removemos el espacio que se le agrega al ultimo del for
                nombres = nombres.Remove(nombres.Length - 1, 1);

                //Buscamos en la base de datos su id y lo guardamos 
                //sabiendo que el penultimo valor del arreglo es el apellido paterno y el ultimo el materno
                int id = conexion.getIdUser(nombres, array[array.Length - 2], array[array.Length - 1]);
                usuario = conexion.GetdataUser(id);

                tbNombre.Text = usuario.nombre;
                tbApellidoP.Text = usuario.apellidoP;
                tbApellidoM.Text = usuario.apellidoM;
                tbCorreo.Text = usuario.correo;
                tbCelular.Text = usuario.tel;
                tbClub.Text = usuario.club;
                
                var categoria = conexion.categoria(usuario.id_cat);
                if (categoria.categoriaTipo == "T")
                {
                    cmbTenis.SelectedItem = categoria.categoriaDescripcion;
                    chkGolf.IsChecked = false;
                    chkTenis.IsChecked = true;
                }
                else
                {
                    cmbGolf.SelectedItem = categoria.categoriaDescripcion;
                    chkGolf.IsChecked = true;
                    chkTenis.IsChecked = false;
                }

                CmbTorneo.SelectedIndex = usuario.id_torneo - 1;

                picFoto.Source = ByteToImage(usuario.imagen);
                imgVerHuella.Visibility = Visibility.Visible;

                // picFoto.Source = usuario.imagen;


            }

        }
        public ImageSource ByteToImage(byte[] imageData)
        {
            BitmapImage biImg = new BitmapImage();
            MemoryStream ms = new MemoryStream(imageData);
            biImg.BeginInit();
            biImg.StreamSource = ms;
            biImg.EndInit();

            ImageSource imgSrc = biImg as ImageSource;

            return imgSrc;
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            cadena.Open();
            SqlCommand cmd = cadena.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from dbo.Usuario where nombre = '" + tbNombre.Text + "'";
            cmd.ExecuteNonQuery();
            cadena.Close();
            MessageBox.Show("Borrado Exitosamente");
        }
    }  

}


