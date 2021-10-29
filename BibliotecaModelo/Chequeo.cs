using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaModelo
{
    public class Chequeo
    {
        public int IdChequeo { get; set; }
        public DateTime FechaCheckIngreso { get; set; }
        public DateTime FechaCheckEgreso { get; set; }

        private long _totalMulta;


        //Get y Set con regla de negocio
        public long TotalMulta
        {
            get { return _totalMulta; }
            set
            {
                if (value >= 0 && value <= 9999999999)
                {
                    _totalMulta = value;
                }
                else
                {
                    throw new InvalidOperationException("- Campo Total Multa debe ser entre $0 y $9.999.999.999");
                }
            }
        }


        //constructor
        public Chequeo()
        {

        }
    }
}
