using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Lógica de interacción para Registro.xaml
    /// </summary>
    public partial class Registro : Window
    {
        Usuario usuario = new Usuario();
        ConexionBD conexion = new ConexionBD();
        int ida;
        int id_cat;

        ObservableCollection<string> TipoGolf = new ObservableCollection<string>();
        ObservableCollection<string> TipoTenis = new ObservableCollection<string>();
        ObservableCollection<string> Torneo = new ObservableCollection<string>();
        public Registro()
        {
            InitializeComponent();

            //       CmbTorneo.ItemTemplate.LoadContent(conexion.obtenerTorneosActuales().ToArray());
            conexion = new ConexionBD();
            cmbGolf.ItemsSource = conexion.obtenerCategoriasGolf().ToArray();
            cmbTenis.ItemsSource = conexion.obtenerCategoriasGolf().ToArray();

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
                usuario.club = tbCelular.Text;
                usuario.imagen = tbUrlFoto.Text;
                usuario.huella = Template.Bytes;

                /*  string destino = @"C:\Checador\";

                    string recurso = imgFoto.Source.ToString().Replace("file:///", "");

                    File.Copy(recurso, destino + tbUrlFoto.Text, true);*/

                int id = ConexionBD.AltaEmpleado(usuario,ida, id_cat);

                if (id > 0)
                {
                    MessageBox.Show("Empleado guardado correctamente", "Guardar");

                    tbNombre.Text = "";
                    tbApellidoP.Text = "";
                    tbApellidoM.Text = "";
                    tbClub.Text = "";
                    tbCorreo.Text = "";
                    tbCelular.Text = "";
                    tbUrlFoto.Text = "";
                    imgFoto.Source = null;
                    //  dgEmpleados.DataContext = DatoEmpleado.MuestraEmpleados();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("No fue posible guardar el empleado: " + ex.Message, "Error en Guardar");
            }
        }

        private void chkTenis_CheckedChanged(object sender, EventArgs e)
        {
            if ((bool)(chkTenis.IsChecked = true))
            {
                cmbTenis.IsEnabled = true;
                cmbGolf.IsEnabled = false;
               // usuario.categoriaDescripcion = chkTenis.t;
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
              //  usuario.categoriaDescripcion = ;
                chkTenis.IsChecked = false;
            }
        }

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

       
    }
}

