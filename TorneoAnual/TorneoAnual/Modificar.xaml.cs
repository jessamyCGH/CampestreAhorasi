﻿using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
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

        public Modificar()
        {
            InitializeComponent();
            this.DataContext = this;
            GetVideoDevices();


            //       CmbTorneo.ItemTemplate.LoadContent(conexion.obtenerTorneosActuales().ToArray());
            conexion = new ConexionBD();
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

            if (Template == null)
            {
                MessageBox.Show("La huella del empleado debe ser capturada", "Error");
                return;
            }

            try
            {
                Usuario usuario = new Usuario();
                usuario.nombre = tbNombre.Text;
                usuario.apellidoP = tbApellidoP.Text;
                usuario.apellidoM = tbApellidoM.Text;
                usuario.correo = tbCorreo.Text;
                usuario.tel = tbCelular.Text;
                usuario.club = tbClub.Text;
                usuario.categoriaTipo = CmbTorneo.Text;
                //   usuario.imagen = picFoto.Source;
                usuario.huella = Template.Bytes;

                /*  string destino = @"C:\Checador\";

                    string recurso = imgFoto.Source.ToString().Replace("file:///", "");

                    File.Copy(recurso, destino + tbUrlFoto.Text, true);*/

                int id = ConexionBD.Alta(usuario);

                if (id > 0)
                {
                    MessageBox.Show("Empleado guardado correctamente", "Guardar");

                    tbNombre.Text = "";
                    tbApellidoP.Text = "";
                    tbApellidoM.Text = "";
                    tbClub.Text = "";
                    tbCorreo.Text = "";
                    tbCelular.Text = "";
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
                usuario.categoriaDescripcion = (string)chkTenis.Content;
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
                usuario.categoriaDescripcion = (string)chkGolf.Content;
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
                BitmapImage bi;
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




    }
}

