using System;
using System.IO;
using System.Windows;
using System.Collections.Generic;
using Checador.Modelos;
using Checador.Servicios;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Threading.Tasks;

namespace Checador
{
    /// <summary>
    /// Lógica de interacción para Check.xaml
    /// </summary>
    public partial class Check : Window, DPFP.Capture.EventHandler
    {
        private DPFP.Template Template;
        private DPFP.Verification.Verification Verificator;
        private DPFP.Capture.Capture Capturer;
        public Check()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
        }

        protected virtual void Init()
        {
            try
            {
                Capturer = new DPFP.Capture.Capture();				// Create a capture operation.

                if (null != Capturer)
                    Capturer.EventHandler = this;					// Subscribe for capturing events.
                else
                     lblReport.Content = "Can't initiate capture operation!";
            }
            catch
            {
                MessageBox.Show("Can't initiate capture operation!", "Error", System.Windows.MessageBoxButton.OK,System.Windows.MessageBoxImage.Error);
            }

            Verificator = new DPFP.Verification.Verification();
        }


        protected void Process(DPFP.Sample Sample)
        {
            
            // Process the sample and create a feature set for the enrollment purpose.
            DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification);

            // Check quality of the sample and start verification if it's good
            // TODO: move to a separate task
            if (features != null)
            {
                // Compare the feature set with our template
                DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();

                DPFP.Template template = new DPFP.Template();
                Stream stream;

                List<Empleado> empleados = DatoEmpleado.MuestraEmpleados();

                foreach( var empleado in empleados)
                {
                    if(empleado.Huella != null)
                    {
                        stream = new MemoryStream(empleado.Huella);
                        template = new DPFP.Template(stream);

                        Verificator.Verify(features, template, ref result);
                        if(result.Verified)
                        {
                           this.Dispatcher.Invoke(new Function(delegate() {                           
                            Desplegar(empleado);                               
                           }));

                            break;
                        }                                              
                    }
                }
                
            }
        }


        protected void Start()
        {
            if (null != Capturer)
            {
                try
                {
                    Capturer.StartCapture();
                   lblReport.Content = "Using the fingerprint reader, scan your fingerprint.";
                }
                catch
                {
                    lblReport.Content = "Can't initiate capture!";
                }
            }
        }

        protected void Stop()
        {
            if (null != Capturer)
            {
                try
                {
                    Capturer.StopCapture();
                }
                catch
                {
                   lblReport.Content = "Can't terminate capture!";
                }
            }
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Init();
            Start();
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            Stop();
        }


        protected DPFP.FeatureSet ExtractFeatures(DPFP.Sample Sample, DPFP.Processing.DataPurpose Purpose)
        {
            DPFP.Processing.FeatureExtraction Extractor = new DPFP.Processing.FeatureExtraction();  // Create a feature extractor
            DPFP.Capture.CaptureFeedback feedback = DPFP.Capture.CaptureFeedback.None;
            DPFP.FeatureSet features = new DPFP.FeatureSet();
            Extractor.CreateFeatureSet(Sample, Purpose, ref feedback, ref features);            // TODO: return features as a result?
            if (feedback == DPFP.Capture.CaptureFeedback.Good)
                return features;
            else
                return null;
        }


        public void Desplegar(Empleado empleado)
        {
            string url = "";
            
            lblNombre.Content = empleado.Nombre;
            lblApellidos.Content = empleado.Apellidos;
            lblNumero.Content = empleado.Numero;
            if (empleado.Foto != "" && empleado.Foto != null)
            {
                url = "C:/Checador/" + empleado.Foto;
            }
            else
                url = "C:/Checador/noimage.png";

            BitmapImage foto = new BitmapImage();
            foto.BeginInit();
            foto.UriSource = new Uri(url);
            foto.EndInit();
            foto.Freeze();

            imgPerfil.Source = foto;
           
        }
                  

        public void Reset()
        {
            lblNombre.Content = "¡Bienvenido!";
            lblApellidos.Content = "Que tengas buen día";
            lblNumero.Content = "Coloca tu dedo en el lector";
                       
            BitmapImage foto = new BitmapImage();
            foto.BeginInit();
            foto.UriSource = new Uri("../../Resources/perfil_generico.png", UriKind.Relative);
            foto.EndInit();
            foto.Freeze();

            imgPerfil.Source = foto;
        }
      

        #region EventHandler Members:

        public void OnComplete(object Capture, string ReaderSerialNumber, DPFP.Sample Sample)
        {
            this.Dispatcher.Invoke(new Function(delegate () {
                lblReport.Content = "Huella leida.";
                lblStatus.Content = "Espere por favor.";
                Process(Sample);
            }));

            System.Threading.Thread.Sleep(5000);

            this.Dispatcher.Invoke(new Function(delegate () {
                Reset();
            }));

        }

        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {

            this.Dispatcher.Invoke(new Function(delegate () {
            lblReport.Content = "The finger was removed from the fingerprint reader.";
               
            }));
        }

        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {

            this.Dispatcher.Invoke(new Function(delegate () {
                lblReport.Content = "The fingerprint reader was touched.";
            }));
        }

        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        {

            this.Dispatcher.Invoke(new Function(delegate () {
                lblReport.Content = "The fingerprint reader was connected.";
            }));
        }

        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {

            this.Dispatcher.Invoke(new Function(delegate () {
                lblReport.Content = "The fingerprint reader was disconnected.";
            }));
        }

        public void OnSampleQuality(object Capture, string ReaderSerialNumber, DPFP.Capture.CaptureFeedback CaptureFeedback)
        {
            /*
            if (CaptureFeedback == DPFP.Capture.CaptureFeedback.Good)
                MakeReport("The quality of the fingerprint sample is good.");
            else
                MakeReport("The quality of the fingerprint sample is poor.");*/
        }
        #endregion

    }
}
