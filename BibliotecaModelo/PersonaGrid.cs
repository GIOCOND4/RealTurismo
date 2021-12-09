using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaModelo
{
    public class PersonaGrid
    {
        public int IdPersona { get; set; }
        public string RutString { get; set; }
        //comentado para ver si se mantiene o se va
        //public string nombreCompleto { get; set; }
        //por mientras se mostrara los nombres y apellidos separados
        public string nombres { get; set; }
        public string apellidopat { get; set; }
        public string apellidomat { get; set; }
        public string ActivoEnLetras { get; set; }
        public string correo { get; set; }
        public string nombreUsuario { get; set; }
        public string nombrePerfil { get; set; }

        public PersonaGrid()
        {

        }

    }
}
