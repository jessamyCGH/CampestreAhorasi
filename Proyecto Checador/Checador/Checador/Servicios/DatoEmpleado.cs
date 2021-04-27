using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

using Checador.Modelos;
using System.Data.Common;

namespace Checador.Servicios
{
  public class DatoEmpleado
    {
        public DatoEmpleado() { }  

        public static List<Empleado> MuestraEmpleados()
        {
            List<Empleado> listaEmpleados = new List<Empleado>();

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
                            if(dr.HasRows)
                            {
                                while(dr.Read())
                                {
                                    Empleado emp = new Empleado();
                                    emp.Id = int.Parse(dr["id"].ToString());
                                    emp.Nombre = dr["nombre"].ToString();
                                    emp.Apellidos = dr["apellidoP"].ToString();
                                    emp.Numero = dr["club"].ToString();
                                    //emp.Foto = dr["Foto"].ToString();
                                    if (dr["huella"].ToString() != "")
                                        emp.Huella = (byte[])dr["huella"];
                                    else
                                        emp.Huella = null;

                                    listaEmpleados.Add(emp);

                                }
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al consultar Empleados: " + ex.Message, "Error");  
            }

            return listaEmpleados;
        }

        public static int AltaEmpleado(Empleado empleado)
        {
            int res = 0;

            try
            {
                using (var conn = new SqlConnection("Data Source = localhost; initial catalog = TorneAnual; Integrated Security = True "))
                {
                    conn.Open();

                    using (var command = conn.CreateCommand())
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "AltaEmpleados";
                        command.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                        command.Parameters.AddWithValue("@Apellidos", empleado.Apellidos);
                        command.Parameters.AddWithValue("@Numero", empleado.Numero);
                        command.Parameters.AddWithValue("@Foto", empleado.Foto);
                        command.Parameters.AddWithValue("@Huella", empleado.Huella);

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

     
    }
}
