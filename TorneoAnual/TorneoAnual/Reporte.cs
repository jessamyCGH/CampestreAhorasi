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

        private void btnClausura_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();

            SqlDataAdapter data = new SqlDataAdapter("Repo_Clausura", con);
            data.SelectCommand.CommandType = CommandType.StoredProcedure;


            DataTable dClausura = new DataTable();
            data.Fill(dClausura);

            TorneoAnual.CrystalReports.CRClausura CRCla = new CrystalReports.CRClausura();
            cvClausura.ReportSource = null;
            cvClausura.ReportSource = CRCla;
        
        }

        private void btnConcierto_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();

            SqlDataAdapter data = new SqlDataAdapter("Repo_Concierto", con);
            data.SelectCommand.CommandType = CommandType.StoredProcedure;


            DataTable dConcierto = new DataTable();
            data.Fill(dConcierto);

            TorneoAnual.CrystalReports.CRConcierto CRCon = new CrystalReports.CRConcierto();
            cvConcierto.ReportSource = null;
            cvConcierto.ReportSource = CRCon;

        }

        private void btnKGolf_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();

            SqlDataAdapter data = new SqlDataAdapter("Repo_Golf", con);
            data.SelectCommand.CommandType = CommandType.StoredProcedure;


            DataTable dGolf = new DataTable();
            data.Fill(dGolf);

            TorneoAnual.CrystalReports.CRGolf cRGolf = new CrystalReports.CRGolf();
            cvGolf.ReportSource = null;
            cvGolf.ReportSource = cRGolf;
        }

       
        private void btnTenis_Click(object sender, EventArgs e)
        {

            if (con.State == ConnectionState.Closed)
                con.Open();

            SqlDataAdapter data = new SqlDataAdapter("Repo_Tenis", con);
            data.SelectCommand.CommandType = CommandType.StoredProcedure;


            DataTable dTenis = new DataTable();
            data.Fill(dTenis);

            TorneoAnual.CrystalReports.CRTenis cRTenis = new CrystalReports.CRTenis();
            cvTenis.ReportSource = null;
            cvTenis.ReportSource = cRTenis;
        }
    }


}
