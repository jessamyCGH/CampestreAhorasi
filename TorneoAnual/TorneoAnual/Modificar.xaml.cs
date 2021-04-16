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
using TorneoAnual.Modelos;

namespace TorneoAnual
{
    /// <summary>
    /// Lógica de interacción para Modificar.xaml
    /// </summary>
    public partial class Modificar : Window
    {
        
        ConexionBD conexion;

        int id;
        string itemSeleccionado = "";
        public Modificar()
        {
            
            InitializeComponent();
            conexion = new ConexionBD();
            cbBoxNombre.ItemsSource = conexion.getAllNamesUsers().ToArray();
        }

        private void CbBoxNombre_SelectedValueChanged(object sender, SelectionChangedEventArgs e)
        {
           
            Usuario usuario = new Usuario();
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

                tbNombre.Text = usuario.nombre;
                tbApellidoP.Text = usuario.apellidoP;
                tbApellidoM.Text = usuario.apellidoM;
                tbCorreo.Text = usuario.correo;
                tbCelular.Text = usuario.tel;
                

            }
        }

        private void btnActualizar_(object sender, RoutedEventArgs e)
        {
            Usuario usuario = new Usuario();

            usuario.nombre = tbNombre.Text;
            usuario.apellidoP = tbApellidoP.Text;
            usuario.apellidoM = tbApellidoM.Text;
            usuario.correo = tbCorreo.Text;
            usuario.tel = tbCelular.Text;
            usuario.categoriaTipo = CmbCategorias.Text;
            // usuario.huella = 
            //  usuario.imagen = 
            usuario.torneo = CmbTorneo.Text;
           

        }
    }
}
