using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TorneoAnual.Dataset;

//using TorneoAnual.Reportes;


namespace TorneoAnual
{
    public partial class Reporte : MaterialSkin.Controls.MaterialForm
    {


        public Reporte()
        {
            InitializeComponent();
            
        }

        SqlConnection con = new SqlConnection(@"Data Source= localhost; initial Catalog=TorneoAnual; Integrated Security= True");
     



        private void btnInaguracion_Click(object sender, EventArgs e)
        {

            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlDataAdapter data = new SqlDataAdapter("Repo_Inaguracion", con);
            data.SelectCommand.CommandType = CommandType.StoredProcedure;
            // DInaguracion dInaguracion = new DInaguracion();

            DataTable dInaguracion = new DataTable();
            data.Fill(dInaguracion);
            con.Close();
            TorneoAnual.CrystalReports.CRInaguracion CRI = new CrystalReports.CRInaguracion();
            CRI.Database.Tables["Repo_Inaguracion"].SetDataSource(dInaguracion);
            cvInaguracion.ReportSource = null;
            cvInaguracion.ReportSource = CRI;
        }

        private void btnCerveza_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlDataAdapter data = new SqlDataAdapter("Repo_Cerveza", con);
            data.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable dCerveza = new DataTable();
            data.Fill(dCerveza);

            TorneoAnual.CrystalReports.CRCerveza CRC = new CrystalReports.CRCerveza();
            CRC.Database.Tables["Repo_Cerveza"].SetDataSource(dCerveza);
            cvCerveza.ReportSource = null;
            cvCerveza.ReportSource = CRC;
        }


    }


}
