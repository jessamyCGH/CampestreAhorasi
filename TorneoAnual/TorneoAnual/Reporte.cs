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
        CrystalReports.CRAlimentos crA = new CrystalReports.CRAlimentos();

        public Reporte()
        {
            InitializeComponent();
            

        }

        


        SqlConnection con = new SqlConnection(@"Data Source= localhost; initial Catalog=TorneoAnual; Integrated Security= True");
     



        private void btnInaguracion_Click(object sender, EventArgs e)
        {
            dtf.Visible = false;
            dtini.Visible = false;
            lblDesde.Visible = false;
            lblHasta.Visible = false;

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
            cv.ReportSource = null;
            cv.ReportSource = CRI;
            
        }

        private void btnCerveza_Click(object sender, EventArgs e)
        {
            dtf.Visible = false;
            dtini.Visible = false;
            lblDesde.Visible = false;
            lblHasta.Visible = false;

            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlDataAdapter data = new SqlDataAdapter("Repo_Cerveza", con);
            data.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable dCerveza = new DataTable();
            data.Fill(dCerveza);

            TorneoAnual.CrystalReports.CRCerveza CRC = new CrystalReports.CRCerveza();
            CRC.Database.Tables["Repo_Cerveza"].SetDataSource(dCerveza);
            cv.ReportSource = null;
            cv.ReportSource = CRC;
        }

        private void btnClausura_Click(object sender, EventArgs e)
        {
            dtf.Visible = false;
            dtini.Visible = false;
            lblDesde.Visible = false;
            lblHasta.Visible = false;

            if (con.State == ConnectionState.Closed)
                con.Open();

            SqlDataAdapter data = new SqlDataAdapter("Repo_Clausura", con);
            data.SelectCommand.CommandType = CommandType.StoredProcedure;


            DataTable dClausura = new DataTable();
            data.Fill(dClausura);

            TorneoAnual.CrystalReports.CRClausura CRCla = new CrystalReports.CRClausura();
            CRCla.Database.Tables["Repo_Clausura"].SetDataSource(dClausura);
            cv.ReportSource = null;
            cv.ReportSource = CRCla;
        
        }

        private void btnConcierto_Click(object sender, EventArgs e)
        {
            dtf.Visible = false;
            dtini.Visible = false;
            lblDesde.Visible = false;
            lblHasta.Visible = false;

            if (con.State == ConnectionState.Closed)
                con.Open();

            SqlDataAdapter data = new SqlDataAdapter("Repo_Concierto", con);
            data.SelectCommand.CommandType = CommandType.StoredProcedure;


            DataTable dConcierto = new DataTable();
            data.Fill(dConcierto);

            TorneoAnual.CrystalReports.CRConcierto CRCon = new CrystalReports.CRConcierto();
            CRCon.Database.Tables["Repo_Concierto"].SetDataSource(dConcierto);
            cv.ReportSource = null;
            cv.ReportSource = CRCon;

        }

        private void btnKGolf_Click(object sender, EventArgs e)
        {
            dtf.Visible = true;
            dtini.Visible = true;
            lblDesde.Visible = true;
            lblHasta.Visible = true;

            TorneoAnual.CrystalReports.CRGolf cRGolf = new CrystalReports.CRGolf();
            cRGolf.SetParameterValue("@Inicial", dtini.Value.Date);
            cRGolf.SetParameterValue("@Final", dtf.Value.Date);
            cv.ReportSource = null;
            cv.ReportSource = cRGolf;
        
        }

       
        private void btnTenis_Click(object sender, EventArgs e)
        {

            dtf.Visible = true;
            dtini.Visible = true;
            lblDesde.Visible = true;
            lblHasta.Visible = true;

          

                TorneoAnual.CrystalReports.CRTenis cRTenis = new CrystalReports.CRTenis();
                cRTenis.SetParameterValue("@Inicio", dtini.Value.Date);
                cRTenis.SetParameterValue("@fin", dtf.Value.Date);
                cv.ReportSource = null;
                cv.ReportSource = cRTenis;
            
        }



        private void button1_Click(object sender, EventArgs e)
        {
            dtf.Visible = true;
            dtini.Visible = true;
            lblDesde.Visible = true;
            lblHasta.Visible = true;

            TorneoAnual.CrystalReports.CRAlimentos cRAlimentos = new CrystalReports.CRAlimentos();
            cRAlimentos.SetParameterValue("@Inicial", dtini.Value.Date );
            cRAlimentos.SetParameterValue("@Final", dtf.Value.Date);
            cv.ReportSource = null;
            cv.ReportSource = cRAlimentos;



        }

        

        private void Reporte_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }


}
