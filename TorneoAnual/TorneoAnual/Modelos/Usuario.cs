using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorneoAnual.Modelos
{
    class Usuario
    {

        public Usuario() { }

        public string Nombre { get; set; }

        public string ApellidoP { get; set; }

        public string ApellidoM { get; set; }

        public string Club { get; set; }

        public string Tel { get; set; }

        public string Correo { get; set; }
        public string Foto { get; set; }

        public string Fecha { get; set; }

        public string CategoriaDescripcion { get; set; }

        public string CategoriaTipo { get; set; }
        public string Torneo { get; set; }

        public byte[] Huella { get; set; }
    }
}
