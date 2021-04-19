using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorneoAnual.Modelos
{
   public class Usuario
    {

        public Usuario() { }

        public int id { get; set; }
        public string nombre { get; set; }

        public string apellidoP { get; set; }

        public string apellidoM { get; set; }

        public string club { get; set; }

        public string tel { get; set; }

        public string correo { get; set; }
        public string imagen { get; set; }

        public string fecha { get; set; }

        public string categoriaDescripcion { get; set; }

        public string categoriaTipo { get; set; }
        public string torneo { get; set; }

        public int id_cat { get; set; }

        public int id_torneo { get; set; }

        public byte[] huella { get; set; }
    }
}
