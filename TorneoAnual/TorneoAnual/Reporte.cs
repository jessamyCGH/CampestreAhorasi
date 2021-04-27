using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//using TorneoAnual.Reportes;


namespace TorneoAnual
{
    public partial class Reporte : MaterialSkin.Controls.MaterialForm
    {


        public Reporte()
        {
            InitializeComponent();
            
        }

        public DateTime fechaIn { get; set; }

        public DateTime fechaFin { get; set; }


        private void btnInaguracion_Click(object sender, EventArgs e)
        {

            DateTime fechaIn = dtInicio.Value;
            DateTime fechaFin = dtTerminacion.Value;

            this.Repo_InaguracionTableAdapter.Fill(this.DataInaguracion.Repo_Inaguracion, fechaIn, fechaFin);

        }

      
    }
}
