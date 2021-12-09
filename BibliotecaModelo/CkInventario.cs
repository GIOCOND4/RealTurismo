using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaModelo
{
    public class CkInventario
    {
        public int IdChequeo { get; set; }
        public int IdInventario { get; set; }
        public bool CheckIngreso { get; set; }
        public bool CheckEgreso { get; set; }
        public int IdMulta { get; set; }


        //constructor
        public CkInventario()
        {

        }

    }
}
