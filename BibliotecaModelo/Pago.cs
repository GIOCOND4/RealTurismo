using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaModelo
{
    public class Pago
    {
        public int IdPago { get; set; }
        public string CodigoTransaccion { get; set; } //se hace internamente
        public DateTime Fecha { get; set; } //se saca del sistema
        public string Comentario { get; set; }

        private long _monto;
        public int IdEstado { get; set; }
        public int IdTipoPago { get; set; }


        //Get y Set con regla de negocio
        public long Monto
        {
            get { return _monto; }

            set
            {
                if (value > 0 && value <= 9999999999)
                {
                    _monto = value;
                }
                else
                {
                    throw new InvalidOperationException("- Campo Monto debe ser entre $1 y $9.999.999.999");
                }
            }
        }

        //constructor
        public Pago()
        {

        }
    }
}
