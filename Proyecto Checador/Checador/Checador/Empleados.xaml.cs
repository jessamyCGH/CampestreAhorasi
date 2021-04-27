using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Media.Imaging;
using System.IO;

using Checador.Modelos;
using Checador.Servicios;


namespace Checador
{
    /// <summary>
    /// Lógica de interacción para Empleados.xaml
    /// </summary>
    public partial class Empleados : Window
    {
        public Empleados()
        {
            InitializeComponent();

            this.WindowState = WindowState.Maximized;
        }

        private void btnFoto_Click(object sender, RoutedEventArgs e)
        {
            if(tbNumero.Text == "")
            {
                MessageBox.Show("El numero de empleado debe ser definido.", "Error");
                return;
            }

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos de imagen (.jpg)|*.jpg|All Files (*.*)|*.*";
            ofd.FilterIndex = 1;
            ofd.Multiselect = false;

          if(ofd.ShowDialog() == true)
            {
                tbUrlFoto.Text = "";

                try
                {
                    BitmapImage foto = new BitmapImage();
                    foto.BeginInit();
                    foto.UriSource = new Uri(ofd.FileName);
                    foto.EndInit();
                    foto.Freeze();

                    imgFoto.Source = foto;
                    tbUrlFoto.Text = "foto_" + tbNumero.Text + ".jpg"; 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la imagen:" + ex.Message, "Error");
                }
            }

        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
           if(tbNombre.Text =="")
           {
                MessageBox.Show("El campo Nombre debe ser especificado", "Error");
                return;
           }

            if (tbApellidos.Text == "")
            {
                MessageBox.Show("El campo Apellidos debe ser especificado", "Error");
                return;
            }

            if (tbNumero.Text == "")
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
                Empleado empleado = new Empleado();
                empleado.Nombre = tbNombre.Text;
                empleado.Apellidos = tbApellidos.Text;
                empleado.Numero = tbNumero.Text;
                empleado.Foto = tbUrlFoto.Text;
                empleado.Huella = Template.Bytes;

                string destino = @"C:\Checador\";

                string recurso = imgFoto.Source.ToString().Replace("file:///", "");

                File.Copy(recurso, destino + tbUrlFoto.Text, true);

                int id = DatoEmpleado.AltaEmpleado(empleado);

                if(id > 0)
                {
                    MessageBox.Show("Empleado guardado correctamente", "Guardar");

                    tbNombre.Text = "";
                    tbApellidos.Text = "";
                    tbNumero.Text = "";
                    tbUrlFoto.Text = "";
                    imgFoto.Source = null;
                    dgEmpleados.DataContext = DatoEmpleado.MuestraEmpleados();
                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("No fue posible guardar el empleado: " + ex.Message, "Error en Guardar");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgEmpleados.DataContext = DatoEmpleado.MuestraEmpleados();
        }

        private void dgEmpleados_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Empleado empleado = (Empleado)dgEmpleados.SelectedItem;

            if(empleado == null)
            {
                return;
            }


            tbNombre.Text = empleado.Nombre;
            tbApellidos.Text = empleado.Apellidos;
            tbNumero.Text = empleado.Numero;
            tbUrlFoto.Text = empleado.Foto;

            if (empleado.Huella != null)
                imgVerHuella.Visibility = Visibility.Visible;
            else
                imgVerHuella.Visibility = Visibility.Hidden;

            if(empleado.Foto != "" && empleado.Foto != null)
            {
                BitmapImage foto = new BitmapImage();
                foto.BeginInit();
                foto.UriSource = new Uri(@"C:\Checador\" + empleado.Foto);
                foto.EndInit();
                imgFoto.Source = foto;
            }
            else
            {
                imgFoto.Source = null;
                tbUrlFoto.Text = "";
            }
        }

        private void btnCaptura_Click(object sender, RoutedEventArgs e)
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
    }
}
