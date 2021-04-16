using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TorneoAnual.Modelos
{
    class ConexionBD
    {
        string cadena = @"Data Source= {nombrePC};Initial Catalog=TorneoAnual; Integrated Security= True";
        public SqlConnection conectarBDT = new SqlConnection();

       
        public ConexionBD() {
            conectarBDT.ConnectionString = cadena;
        }

        public static int AltaEmpleado(Usuario usuario)
        {
            int res = 0;

            try
            {
                using (var conn = new SqlConnection("Data Source = localhost; initial catalog = TorneoAnual; Integrated Security = True "))
                {
                    conn.Open();

                    using (var command = conn.CreateCommand())
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "AltaEmpleados";
                        command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                        command.Parameters.AddWithValue("@ApellidoP", usuario.ApellidoP);
                        command.Parameters.AddWithValue("@ApellidoM", usuario.ApellidoM);
                        command.Parameters.AddWithValue("@Numero", usuario.Tel);
                        command.Parameters.AddWithValue("@Foto", usuario.Foto);
                        command.Parameters.AddWithValue("@Huella", usuario.Huella);

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

        }
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

        public ObservableCollection<string> getAllNamesUsers()
        {
            cadena = cadena.Replace("{nombrePC}", Environment.MachineName);
            conectarBDT.ConnectionString = cadena;
            conectarBDT.Open();

            SqlCommand command = new SqlCommand("SELECT nombre,apellidoP,apellidoM FROM Usuarios", conectarBDT);

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


    }
}

