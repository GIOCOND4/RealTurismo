using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaModelo
{
    public class Ingreso
    {
        public int idDepto { get; set; }
        public string nombreDepto { get; set; }
        public int nroDepto { get; set; }
        public int montoIngresos { get; set; }
        public int cantidadReservas { get; set; }
    }
}
