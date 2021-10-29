using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaModelo
{
    public class Comuna
    {
        public int IdComuna { get; set; }
        public string Nombre { get; set; }
        public int IdProvincia { get; set; }

        //constructor
        public Comuna()
        {
        
        }
    }
}
