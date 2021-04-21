using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using DarrenLee.Media;


namespace TorneoAnual
{
    public partial class Camara : MaterialSkin.Controls.MaterialForm
    {
        Camera camara = new Camera();

        private bool existenDispositivos = false;
        private bool fotografiaHecha = false;
        private FilterInfoCollection dispositivosDeVideo;
        private VideoCaptureDevice fuenteDeVideo = null;
        public PictureBox pbFotoSocio = null;
        public Camara()
        {
            InitializeComponent();


            BuscarDispositivos();

            try
            {
                // camara = new Camera();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Por favor conecte una camara y reinicie el programa.");
                Environment.Exit(1);
            }

            //-------------------------------------------------------------------------
            //CAMARA
            GetInfo();
            camara.OnFrameArrived += camara_onFArameArrived;

            if (existenDispositivos)
            {
                fuenteDeVideo = new VideoCaptureDevice(dispositivosDeVideo[0].MonikerString);
                fuenteDeVideo.NewFrame += new NewFrameEventHandler(MostrarImagen);
                fuenteDeVideo.Start();
            }
            else
            {
                MessageBox.Show("No se encuentra ningún dispositivo de vídeo en el sistema", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
        }

        private void camara_onFArameArrived(object source, FrameArrivedEventArgs e)
        {
            Image img = e.GetFrame();
            picFoto2.Image = img;
        }

        private void btnCapturar_Click(object sender, EventArgs e)
        {
            Capturar();
            fotografiaHecha = true;
        }
        private void GetInfo()
        {
            var camaraDevices = camara.GetCameraSources();
            var cameraResolution = camara.GetSupportedResolutions();

        }
        private void btnCamara_Click(object sender, EventArgs eventArgs)
        {

            if (existenDispositivos)
            {
                fuenteDeVideo = new VideoCaptureDevice(dispositivosDeVideo[0].MonikerString);
                fuenteDeVideo.NewFrame += new NewFrameEventHandler(MostrarImagen);
                fuenteDeVideo.Start();
            }
            else
            {
                MessageBox.Show("No se encuentra ningún dispositivo de vídeo en el sistema", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
        }
        private void BuscarDispositivos()
        {
            dispositivosDeVideo = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (dispositivosDeVideo.Count == 0)
                existenDispositivos = false;
            else
                existenDispositivos = true;

        }

        //Metodo para captura la imagen 
        private void Capturar()
        {
            if (fuenteDeVideo != null)
            {
                if (fuenteDeVideo.IsRunning)
                {
                    picFoto2.Image = picFoto2.Image;

                }
            }
            if (fuenteDeVideo != null)
                fuenteDeVideo.Stop();
        }

        private void MostrarImagen(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap imagen = (Bitmap)eventArgs.Frame.Clone();
            picFoto2.Image = imagen;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

                Registro foto = new Registro();



                //Hacemos una conversión Cast del valor devuelto por la colección Controls.

               

            
        }
    }
}
