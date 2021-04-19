using System;
using System.Collections.Generic;
using System.IO;
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
using TorneoAnual.Modelos;

namespace TorneoAnual
{
    /// <summary>
    /// Lógica de interacción para Check.xaml
    /// </summary>
    public partial class Check : Window, DPFP.Capture.EventHandler
    {
      //  private DPFP.Template Template;
        private DPFP.Verification.Verification Verificator;
        private DPFP.Capture.Capture Capturer;
    
        //Generamos un objeto de la clase Conexion para por der hacer llamadas a la base de datos
        ConexionBD conexion;

        //Generamos una variable la cual nos ayudara a conocer en que menu estamos
        //La variable empezara con el valor Inaguracion debido a que el Frame inica en ese Menu
        string menuSeleccionado = "Inaguracion";

        //La siguiente variable guardara el nombre del usuario seleccionado
        string itemSeleccionado = "";

        //La siguiente variable guardara el id del usuario seleccionado en los Menus
        int id;

        //Esta variable solo se utilizara en el menu de Cerveza para llevar la cuenta del usuario
        int countCervezas;



        public Check()
        {
            InitializeComponent();
           
            btnEntregado.Visibility = Visibility.Hidden;

            conexion = new ConexionBD();
            

            //Con el metodo getAllUsers() obtendremos todos los nombres registrados en la base de datos
            //para acomodarlos en nuestro comboBox
            cbBoxNombre.ItemsSource = conexion.getAllNamesUsers().ToArray();

        }

        private void CbBoxNombre_SelectedValueChanged(object sender, EventArgs e)
        {
            //Tomaremos el nombre seleccionado en el comboBox
            itemSeleccionado = (string)cbBoxNombre.SelectedItem;

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
                id = conexion.getIdUser(nombres, array[array.Length - 2], array[array.Length - 1]);

                //Usaremos un switch para conocer en que Menu se encuentra
                bool res;
                switch (menuSeleccionado)
                {
                    case "Inaguracion":
                        //Verificaremos si ya la fue entregado Inaguracion
                        res = conexion.getEntregadoInaguracion(id);
                        ChecarEntregado(res);
                        break;

                    case "Alimentos":
                        //Verificaremos si ya la fue entregado Alimentos
                        res = conexion.getEntregadoAlimentos(id);
                        ChecarEntregado(res);
                        break;

                    case "Cerveza":
                        //Verificaremos si ya la fue entregado Alimentos
                        countCervezas = conexion.getEntregadoCerveza(id);
                        if (countCervezas == 0)
                        {
                            ChecarEntregado(false);
                        }
                        else
                        {
                            ChecarEntregado(true);
                            btnEntregado.Content = "Tomara otras 2";
                            btnEntregado.Visibility = Visibility.Visible;
                            btnEntregado.IsEnabled = true;
                        }
                        break;

                    case "Tennis":
                        //Verificaremos si ya la fue entregado Tennis
                        res = conexion.getEntregadoTennis(id);
                        ChecarEntregado(res);
                        break;

                    case "Golf":
                        //Verificaremos si ya la fue entregado Golf
                        res = conexion.getEntregadoGolf(id);
                        ChecarEntregado(res);
                        break;

                    case "Concierto":
                        //Verificaremos si ya la fue entregado Concierto
                        res = conexion.getEntregadoConcierto(id);
                        ChecarEntregado(res);
                        break;

                    case "Clausura":
                        //Verificaremos si ya la fue entregado Clausura
                        res = conexion.getEntregadoClausura(id);
                        ChecarEntregado(res);
                        break;
                }
            }
            
        }

        void ChecarEntregado(bool res)
        {
            //res contiene un bool (true / false) el cual lo retorna nuestra Conexion
            if (res)
            {
                //En dado caso de haber sido entregado 
                //Encenderemos el boton de Check y mostraremos un mensaje
                btnTrue.IsEnabled = true;
                lblEntregado.Content = "Producto entregado";
                btnFalse.IsEnabled = false;
                btnEntregado.Visibility = Visibility.Hidden;
                btnEntregado.IsEnabled = false;
            }
            else
            {
                //En dado caso de NO haber sido entregado 
                //Apagaremos el boton de Check y mostraremos un mensaje
                //Encenderemos el boton de la tacha
                //Habilitaremos un boton el cual nos dira cuando ya haya sido entregado
                btnEntregado.Visibility = Visibility.Visible;
                btnEntregado.IsEnabled = true;
                btnEntregado.Content = "Marcar como entregado";
                btnFalse.IsEnabled = true;
                lblEntregado.Content = "Producto NO entregado";
                btnTrue.IsEnabled = false;
            }
        }

        void reiniciarComponentes()
        {
            //Este metodo reiniciara los componentes tal y como empezaron al principio de abrir el Frame
            //Se utilizara para los cambios de Menus
            btnTrue.IsEnabled = false;
            btnFalse.IsEnabled = false;
            btnEntregado.Visibility = Visibility.Visible;
            btnEntregado.IsEnabled = false;
            lblEntregado.Content = "Verificando entrega";
            cbBoxNombre.Text = "";
        }

       

        private void btnInaguracion_Click(object sender, EventArgs e)
        {
            //Intercambiamos el texto del titulo por el texto del boton btnInaguracion
            lblTitulo.Content = btnInaguracion.Content;

            //Intercambiamos el valor de menuSeleccionado por Inaguracion
            menuSeleccionado = "Inaguracion";

            //Reiniciamos los componentes para los cambios de Menus
            reiniciarComponentes();
            Init();
        }

        private void btnAlimentos_Click(object sender, EventArgs e)
        {
            //Intercambiamos el texto del titulo por el texto del boton btnAlimentos
            lblTitulo.Content = btnAlimentos.Content;

            //Intercambiamos el valor de menuSeleccionado por Alimentos
            menuSeleccionado = "Alimentos";

            //Reiniciamos los componentes para los cambios de Menus
            reiniciarComponentes();
        }

        private void btnCerveza_Click(object sender, EventArgs e)
        {
            //Intercambiamos el texto del titulo por el texto del boton btnCerveza
            lblTitulo.Content = btnCerveza.Content;

            //Intercambiamos el valor de menuSeleccionado por Cerveza
            menuSeleccionado = "Cerveza";

            //Reiniciamos los componentes para los cambios de Menus
            reiniciarComponentes();
        }

        private void btnTennis_Click(object sender, EventArgs e)
        {
            //Intercambiamos el texto del titulo por el texto del boton btnTennis
            lblTitulo.Content = btnTennis.Content;

            //Intercambiamos el valor de menuSeleccionado por Tennis
            menuSeleccionado = "Tennis";

            //Reiniciamos los componentes para los cambios de Menus
            reiniciarComponentes();
        }

        private void btnGolf_Click(object sender, EventArgs e)
        {
            //Intercambiamos el texto del titulo por el texto del boton btnGolf
            lblTitulo.Content = btnGolf.Content;

            //Intercambiamos el valor de menuSeleccionado por Golf
            menuSeleccionado = "Golf";

            //Reiniciamos los componentes para los cambios de Menus
            reiniciarComponentes();
        }

        private void btnConcierto_Click(object sender, EventArgs e)
        {
            //Intercambiamos el texto del titulo por el texto del boton btnConcierto
            lblTitulo.Content = btnConcierto.Content;

            //Intercambiamos el valor de menuSeleccionado por Concierto
            menuSeleccionado = "Concierto";

            //Reiniciamos los componentes para los cambios de Menus
            reiniciarComponentes();
        }

        private void btnClausura_Click(object sender, EventArgs e)
        {
            //Intercambiamos el texto del titulo por el texto del boton btnClausura
            lblTitulo.Content = btnClausura.Content;

            //Intercambiamos el valor de menuSeleccionado por Clausura
            menuSeleccionado = "Clausura";

            //Reiniciamos los componentes para los cambios de Menus
            reiniciarComponentes();
        }

        private void btnEntregado_Click(object sender, EventArgs e)
        {
            //Usaremos un switch para conocer en que Menu se encuentra
            switch (menuSeleccionado)
            {
                case "Inaguracion":
                    //Le agregaremos la entrega en la base de datos al usuario de Inaguracion
                    conexion.setEntregadoInaguracion(id);
                    ChecarEntregado(true);
                    break;

                case "Alimentos":
                    //Le agregaremos la entrega en la base de datos al usuario de Alimentos
                    conexion.setEntregadoAlimentos(id);
                    ChecarEntregado(true);
                    break;

                case "Cerveza":
                    //Le agregaremos la entrega en la base de datos al usuario de Cerveza
                    conexion.setEntregadoCerveza(id, countCervezas += 2);
                    ChecarEntregado(true);
                    btnEntregado.Content = "Tomara otras 2";
                    btnEntregado.Visibility = Visibility.Visible;
                    btnEntregado.IsEnabled = true;
                    break;

                case "Tennis":
                    //Le agregaremos la entrega en la base de datos al usuario de Tennis
                    conexion.setEntregadoTennis(id);
                    ChecarEntregado(true);
                    break;

                case "Golf":
                    //Le agregaremos la entrega en la base de datos al usuario de Golf
                    conexion.setEntregadoGolf(id);
                    ChecarEntregado(true);
                    break;

                case "Concierto":
                    //Le agregaremos la entrega en la base de datos al usuario de Concierto
                    conexion.setEntregadoConcierto(id);
                    ChecarEntregado(true);
                    break;

                case "Clausura":
                    //Le agregaremos la entrega en la base de datos al usuario de Clausura
                    conexion.setEntregadoClausura(id);
                    ChecarEntregado(true);
                    break;
            }
        }

        protected virtual void Init()
        {
            try
            {
                Capturer = new DPFP.Capture.Capture();				// Create a capture operation.

                if (null != Capturer)
                    Capturer.EventHandler = this;					// Subscribe for capturing events.
                else
                    lblReporte.Content = "Can't initiate capture operation!";
            }
            catch
            {
                MessageBox.Show("Can't initiate capture operation!", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
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

                List<Usuario> usuarios= ConexionBD.MuestraEmpleados();

                foreach (var usuario in usuarios)
                {
                    if (usuario.huella != null)
                    {
                        stream = new MemoryStream(usuario.huella);
                        template = new DPFP.Template(stream);

                        Verificator.Verify(features, template, ref result);
                        if (result.Verified)
                        {
                            this.Dispatcher.Invoke(new Function(delegate () {
                                Desplegar(usuario);
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
                    lblReporte.Content = "Using the fingerprint reader, scan your fingerprint.";
                }
                catch
                {
                    lblReporte.Content = "Can't initiate capture!";
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
                    lblReporte.Content = "Can't terminate capture!";
                }
            }
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


        public void Desplegar(Usuario usuario)
        {
          

            lblNom.Content = usuario.nombre;
            lblApellidos.Content = usuario.apellidoP;
            lblNumero.Content = usuario.club;
            cbBoxNombre.Text = usuario.nombre;
           
          

        }


        public void Reset()
        {
            lblNombre.Content = "¡Bienvenido!";
            lblApellidos.Content = "Que tengas buen día";
            lblNumero.Content = "Coloca tu dedo en el lector";
            lblReporte.Content = "kjkjj";

          
        }


        #region EventHandler Members:

        public void OnComplete(object Capture, string ReaderSerialNumber, DPFP.Sample Sample)
        {
            this.Dispatcher.Invoke(new Function(delegate () {
                lblReporte.Content = "Huella leida.";
             //   lblStatus.Content = "Espere por favor.";
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
                lblReporte.Content = "The finger was removed from the fingerprint reader.";

            }));
        }

        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {

            this.Dispatcher.Invoke(new Function(delegate () {
                lblReporte.Content = "The fingerprint reader was touched.";
            }));
        }

        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        {

            this.Dispatcher.Invoke(new Function(delegate () {
                lblReporte.Content = "The fingerprint reader was connected.";
            }));
        }

        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {

            this.Dispatcher.Invoke(new Function(delegate () {
                lblReporte.Content = "The fingerprint reader was disconnected.";
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


  

