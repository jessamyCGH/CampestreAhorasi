using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TorneoAnual.Modelos
{
    class ConexionBD
    {
        string cadena = @"Data Source= localhost; initial Catalog=TorneoAnual; Integrated Security= True";
        public SqlConnection conectarBDT = new SqlConnection();

       
        public ConexionBD() {
            conectarBDT.ConnectionString = cadena;
        }

        /*public static int Alta(Usuario usuario)
        {

            

            SqlCommand command = new SqlCommand("SELECT * FROM Categoria", conectarBDT);



            int res = 0;

            try
            {
                using (var conn = new SqlConnection("Data Source = localhost; initial catalog = TorneoAnual; Integrated Security = True "))
                {
                    conn.Open();

                    using (var command = conn.CreateCommand())
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "Alta";
                        command.Parameters.AddWithValue("@nombre", usuario.nombre);
                        command.Parameters.AddWithValue("@apellidoP", usuario.apellidoP);
                        command.Parameters.AddWithValue("@apellidoM", usuario.apellidoM);
                        command.Parameters.AddWithValue("@correo", usuario.correo);
                        command.Parameters.AddWithValue("@tel", usuario.tel);
                        command.Parameters.AddWithValue("@club", usuario.club);

                        SqlCommand command = new SqlCommand("SELECT * FROM Categoria", conectarBDT);


                        command.Parameters.AddWithValue("@id_cat", usuario.id_cat);
                        command.Parameters.AddWithValue("@huella", usuario.huella);
                        command.Parameters.AddWithValue("@id_torneo", usuario.id_torneo );
                        command.Parameters.AddWithValue("fecha_registro", DateTime.Now);



                        SqlParameter param = new SqlParameter("Id", SqlDbType.Int);
                        param.Value = 0;
                        param.Direction = ParameterDirection.Output;
                        command.Parameters.Add(param);

                        res = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al dar de alta al empleado: " + ex.Message, "Error en Alta");
            }

            return res;

        }*/

        public int Alta(Usuario usuario)
        {
            try
            {
                cadena = cadena.Replace("{nombrePC}", Environment.MachineName);
                conectarBDT.ConnectionString = cadena;
                conectarBDT.Open();

                //Buscamos el id de la categoria indicada
                SqlCommand c1 = new SqlCommand("SELECT id_cat FROM Categoria WHERE descripcion = @categoria", conectarBDT);

                c1.Parameters.AddWithValue("@categoria", usuario.categoriaDescripcion);

                SqlDataReader reader = c1.ExecuteReader();

                int id_cat = 0;
                while (reader.Read())
                {
                    id_cat = (int)reader["id_cat"];
                }

                //Buscamos el id del torneo indicado
                SqlCommand c2 = new SqlCommand("SELECT id_torneo FROM Torneo WHERE descripcion = @descripcion", conectarBDT);

                c2.Parameters.AddWithValue("@descripcion", usuario.torneo);

                reader = c2.ExecuteReader();

                int id_torneo = 0;
                while (reader.Read())
                {
                    id_torneo = (int)reader["id_torneo"];
                }

                SqlCommand command = new SqlCommand("INSERT INTO Usuario(nombre,apellidoP,apellidoM,correo,tel,club,id_cat,huella,id_torneo,fecha_registro)VALUES(@nombre,@apellidoP,@apellidoM,@correo,@tel,@club,@id_cat,@huella,@id_torneo,@fecha_registro)", conectarBDT);

                command.Parameters.AddWithValue("@nombre", usuario.nombre);
                command.Parameters.AddWithValue("@apellidoP", usuario.apellidoP);
                command.Parameters.AddWithValue("@apellidoM", usuario.apellidoM);
                command.Parameters.AddWithValue("@correo", usuario.correo);
                command.Parameters.AddWithValue("@tel", usuario.tel);
                command.Parameters.AddWithValue("@club", usuario.club);
                command.Parameters.AddWithValue("@id_cat", id_cat);
                command.Parameters.AddWithValue("@huella", usuario.huella);
                command.Parameters.AddWithValue("@id_torneo", id_torneo);
                command.Parameters.AddWithValue("fecha_registro", DateTime.Now);

                command.ExecuteReader();

                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }



        //Obtenemos las categorias de Golf para mostrarla en el cmbBox
        public ObservableCollection<string> obtenerCategoriasGolf()
        {
            cadena = cadena.Replace("{nombrePC}", Environment.MachineName);
            conectarBDT.ConnectionString = cadena;
            conectarBDT.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM Categoria", conectarBDT);

            SqlDataReader reader = command.ExecuteReader();

            ObservableCollection<string> categorias = new ObservableCollection<string>();

            while (reader.Read())
            {
                if (reader["Tipo"].Equals("G"))
                {
                    categorias.Add((string)reader["descripcion"]);
                }
            }

            conectarBDT.Close();

            return categorias;

        }
        public ObservableCollection<string> obtenerCategoriasTennis()
        {
            cadena = cadena.Replace("{nombrePC}", Environment.MachineName);
            conectarBDT.ConnectionString = cadena;
            conectarBDT.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM Categoria", conectarBDT);

            SqlDataReader reader = command.ExecuteReader();

            ObservableCollection<string> categorias = new ObservableCollection<string>();

            while (reader.Read())
            {
                if (reader["Tipo"].Equals("T"))
                {
                    categorias.Add((string)reader["descripcion"]);
                }
            }

            conectarBDT.Close();

            return categorias;

        }



        // Se hace una peticion para seleccionar los Torneos que esten vigentes recientemente 
        public ObservableCollection<string> obtenerTorneosActuales()
        {
            cadena = cadena.Replace("{nombrePC}", Environment.MachineName);
            conectarBDT.ConnectionString = cadena;
            conectarBDT.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM Torneo", conectarBDT);

            SqlDataReader reader = command.ExecuteReader();

            ObservableCollection<string> torneos = new ObservableCollection<string>();

            while (reader.Read())
            {
                torneos.Add((string)reader["descripcion"]);
            }

            conectarBDT.Close();

            return torneos;
        }

        //Se hace un apeticion para obtener todo los nombre de los usuarios
        public ObservableCollection<string> getAllNamesUsers()
        {
            cadena = cadena.Replace("{nombrePC}", Environment.MachineName);
            conectarBDT.ConnectionString = cadena;
            conectarBDT.Open();

            SqlCommand command = new SqlCommand("SELECT nombre,apellidoP,apellidoM FROM Usuario", conectarBDT);

            SqlDataReader reader = command.ExecuteReader();

            ObservableCollection<string> nombres = new ObservableCollection<string>();

            while (reader.Read())
            {
                string nombre = "";

                nombre += (string)reader["nombre"] + " ";
                nombre += (string)reader["apellidoP"] + " ";
                nombre += (string)reader["apellidoM"];

                nombres.Add(nombre);
            }

            conectarBDT.Close();

            return nombres;
        }
        public int getIdUser(string nombre, string apellidop, string apellidom)
        {
            cadena = cadena.Replace("{nombrePC}", Environment.MachineName);
            conectarBDT.ConnectionString = cadena;
            conectarBDT.Open();

            SqlCommand command = new SqlCommand("SELECT id FROM Usuarios WHERE nombre = @nombre AND apellidoP = @apellidoP AND apellidoM = @apellidoM", conectarBDT);
            command.Parameters.AddWithValue("nombre", nombre);
            command.Parameters.AddWithValue("apellidoP", apellidop);
            command.Parameters.AddWithValue("apellidoM", apellidom);

            SqlDataReader reader = command.ExecuteReader();

            reader.Read();
            var x = (int)reader.GetValue(0);

            conectarBDT.Close();
            return x;
        }

        #region Inaguracion
        public bool getEntregadoInaguracion(int id_user)
        {
            cadena = cadena.Replace("{nombrePC}", Environment.MachineName);
            conectarBDT.ConnectionString = cadena;
            conectarBDT.Open();

            SqlCommand command = new SqlCommand("SELECT id_user,fecha FROM Inaguracion WHERE id_user = @id_user", conectarBDT);
            command.Parameters.AddWithValue("id_user", id_user);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                conectarBDT.Close();
                return true;
            }
            else
                conectarBDT.Close();
            {
                return false;
            }
        }

        public void setEntregadoInaguracion(int id)
        {
            cadena = cadena.Replace("{nombrePC}", Environment.MachineName);
            conectarBDT.ConnectionString = cadena;
            conectarBDT.Open();

            SqlCommand command = new SqlCommand("INSERT INTO [dbo].[Inaguracion]([id_user],[fecha])VALUES(@id_user, @fecha)", conectarBDT);
            command.Parameters.AddWithValue("id_user", id);
            command.Parameters.AddWithValue("fecha", DateTime.Now);

            command.ExecuteReader();
            conectarBDT.Close();
        }

        #endregion

        #region Alimentos

        public bool getEntregadoAlimentos(int id_user)
        {
            cadena = cadena.Replace("{nombrePC}", Environment.MachineName);
            conectarBDT.ConnectionString = cadena;
            conectarBDT.Open();

            SqlCommand command = new SqlCommand("SELECT id_user,fecha FROM Alimentos WHERE id_user = @id_user", conectarBDT);
            command.Parameters.AddWithValue("id_user", id_user);

            SqlDataReader reader = command.ExecuteReader();


            if (reader.HasRows)
            {
                conectarBDT.Close();
                return true;
            }
            else
            {
                conectarBDT.Close();
                return false;
            }
        }

        public void setEntregadoAlimentos(int id)
        {
            cadena = cadena.Replace("{nombrePC}", Environment.MachineName);
            conectarBDT.ConnectionString = cadena;
            conectarBDT.Open();

            SqlCommand command = new SqlCommand("INSERT INTO [dbo].[Alimentos]([id_user],[fecha])VALUES(@id_user, @fecha)", conectarBDT);
            command.Parameters.AddWithValue("id_user", id);
            command.Parameters.AddWithValue("fecha", DateTime.Now);

            command.ExecuteReader();
            conectarBDT.Close();
        }

        #endregion

        #region Cerveza

        public int getEntregadoCerveza(int id_user)
        {
            cadena = cadena.Replace("{nombrePC}", Environment.MachineName);
            conectarBDT.ConnectionString = cadena;
            conectarBDT.Open();

            SqlCommand command = new SqlCommand("SELECT id_user,countCervezas,fecha FROM Cerveza WHERE id_user = @id_user", conectarBDT);
            command.Parameters.AddWithValue("id_user", id_user);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();
                var i = (int)reader["countCervezas"];
                conectarBDT.Close();
                return i;
            }
            else
            {
                conectarBDT.Close();
                return 0;
            }
        }

        public void setEntregadoCerveza(int id, int countCervezas)
        {
            cadena = cadena.Replace("{nombrePC}", Environment.MachineName);
            conectarBDT.ConnectionString = cadena;
            conectarBDT.Open();

            SqlCommand command = new SqlCommand("SELECT id_user,countCervezas,fecha FROM Cerveza WHERE id_user = @id_user", conectarBDT);
            command.Parameters.AddWithValue("id_user", id);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Close();
                command = new SqlCommand("UPDATE [dbo].[Cerveza] SET [countCervezas] = @count WHERE id_user = @id", conectarBDT);
                command.Parameters.AddWithValue("id", id);
                command.Parameters.AddWithValue("count", countCervezas);

                command.ExecuteReader();
                conectarBDT.Close();
            }
            else
            {
                reader.Close();
                command = new SqlCommand("INSERT INTO [dbo].[Cerveza]([id_user],[countCervezas],[fecha])VALUES(@id_user,@countCervezas, @fecha)", conectarBDT);
                command.Parameters.AddWithValue("id_user", id);
                command.Parameters.AddWithValue("countCervezas", countCervezas);
                command.Parameters.AddWithValue("fecha", DateTime.Now);

                command.ExecuteReader();
                conectarBDT.Close();
            }
        }

        #endregion

        #region Tennis
        public bool getEntregadoTennis(int id_user)
        {
            cadena = cadena.Replace("{nombrePC}", Environment.MachineName);
            conectarBDT.ConnectionString = cadena;
            conectarBDT.Open();

            SqlCommand command = new SqlCommand("SELECT id_user,fecha FROM Tennis WHERE id_user = @id_user", conectarBDT);
            command.Parameters.AddWithValue("id_user", id_user);

            SqlDataReader reader = command.ExecuteReader();


            if (reader.HasRows)
            {
                conectarBDT.Close();
                return true;
            }
            else
            {
                conectarBDT.Close();
                return false;
            }
        }

        public void setEntregadoTennis(int id)
        {
            cadena = cadena.Replace("{nombrePC}", Environment.MachineName);
            conectarBDT.ConnectionString = cadena;
            conectarBDT.Open();

            SqlCommand command = new SqlCommand("INSERT INTO [dbo].[Tennis]([id_user],[fecha])VALUES(@id_user, @fecha)", conectarBDT);
            command.Parameters.AddWithValue("id_user", id);
            command.Parameters.AddWithValue("fecha", DateTime.Now);

            command.ExecuteReader();
            conectarBDT.Close();
        }

        #endregion

        #region Golf
        public bool getEntregadoGolf(int id_user)
        {
            cadena = cadena.Replace("{nombrePC}", Environment.MachineName);
            conectarBDT.ConnectionString = cadena;
            conectarBDT.Open();

            SqlCommand command = new SqlCommand("SELECT id_user,fecha FROM Golf WHERE id_user = @id_user", conectarBDT);
            command.Parameters.AddWithValue("id_user", id_user);

            SqlDataReader reader = command.ExecuteReader();


            if (reader.HasRows)
            {
                conectarBDT.Close();
                return true;
            }
            else
            {
                conectarBDT.Close();
                return false;
            }
        }

        public void setEntregadoGolf(int id)
        {
            cadena = cadena.Replace("{nombrePC}", Environment.MachineName);
            conectarBDT.ConnectionString = cadena;
            conectarBDT.Open();

            SqlCommand command = new SqlCommand("INSERT INTO [dbo].[Golf]([id_user],[fecha])VALUES(@id_user, @fecha)", conectarBDT);
            command.Parameters.AddWithValue("id_user", id);
            command.Parameters.AddWithValue("fecha", DateTime.Now);

            command.ExecuteReader();
            conectarBDT.Close();
        }

        #endregion

        #region Concierto
        public bool getEntregadoConcierto(int id_user)
        {
            cadena = cadena.Replace("{nombrePC}", Environment.MachineName);
            conectarBDT.ConnectionString = cadena;
            conectarBDT.Open();

            SqlCommand command = new SqlCommand("SELECT id_user,fecha FROM Concierto WHERE id_user = @id_user", conectarBDT);
            command.Parameters.AddWithValue("id_user", id_user);

            SqlDataReader reader = command.ExecuteReader();


            if (reader.HasRows)
            {
                conectarBDT.Close();
                return true;
            }
            else
            {
                conectarBDT.Close();
                return false;
            }
        }

        public void setEntregadoConcierto(int id)
        {
            cadena = cadena.Replace("{nombrePC}", Environment.MachineName);
            conectarBDT.ConnectionString = cadena;
            conectarBDT.Open();

            SqlCommand command = new SqlCommand("INSERT INTO [dbo].[Concierto]([id_user],[fecha])VALUES(@id_user, @fecha)", conectarBDT);
            command.Parameters.AddWithValue("id_user", id);
            command.Parameters.AddWithValue("fecha", DateTime.Now);

            command.ExecuteReader();
            conectarBDT.Close();
        }

        #endregion

        #region Clausura
        public bool getEntregadoClausura(int id_user)
        {
            cadena = cadena.Replace("{nombrePC}", Environment.MachineName);
            conectarBDT.ConnectionString = cadena;
            conectarBDT.Open();

            SqlCommand command = new SqlCommand("SELECT id_user,fecha FROM Clausura WHERE id_user = @id_user", conectarBDT);
            command.Parameters.AddWithValue("id_user", id_user);

            SqlDataReader reader = command.ExecuteReader();


            if (reader.HasRows)
            {
                conectarBDT.Close();
                return true;
            }
            else
            {
                conectarBDT.Close();
                return false;
            }
        }

        public void setEntregadoClausura(int id)
        {
            cadena = cadena.Replace("{nombrePC}", Environment.MachineName);
            conectarBDT.ConnectionString = cadena;
            conectarBDT.Open();

            SqlCommand command = new SqlCommand("INSERT INTO [dbo].[Clausura]([id_user],[fecha])VALUES(@id_user, @fecha)", conectarBDT);
            command.Parameters.AddWithValue("id_user", id);
            command.Parameters.AddWithValue("fecha", DateTime.Now);

            command.ExecuteReader();
            conectarBDT.Close();
        }

        #endregion

        #region mostrar
        //SE le hace la peticion al procedure de muestra y nos mostrara los datos deseados 
        public static List<Usuario> Muestra()
        {
            List<Usuario> listaUsuario = new List<Usuario>();

            try
            {
                using (var conn = new SqlConnection("Data Source = localhost; initial catalog = TorneoAnual; Integrated Security = True "))
                {
                    conn.Open();

                    using (var command = conn.CreateCommand())
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "Muestra";

                        using (DbDataReader dr = command.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    Usuario us = new Usuario();
                                   us.id = int.Parse(dr["id"].ToString());
                                    us.nombre = dr["nombre"].ToString();
                                    us.apellidoP = dr["apellidoP"].ToString();
                                    us.club = dr["club"].ToString();
                                    if (dr["huella"].ToString() != "")
                                        us.huella = (byte[])dr["huella"];
                                    else
                                        us.huella = null;

                                    listaUsuario.Add(us);

                                }
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al consultar Usuarios: " + ex.Message, "Error");
            }

            return listaUsuario;
        }
        #endregion

    }
}

