using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaModelo
{
    public class Multa
    {
        public int IdMulta { get; set; }
        private string _descripcion;
        private long _costo;

        //Get y Set con condicional
        public string Descripcion
        {
            get { return _descripcion; }
            set
            {
                if (value.Trim().Length >0 && value.Length <= 500)
                {
                    _descripcion = value;
                }
                else
                {
                    throw new ArgumentException("- Campo Descripción no puede estar Vacío");
                }
            }
        }

        public long Costo
        {
            get { return _costo; }
            set
            {
                if (value > 0 && value <= 9999999999)
                {
                    _costo = value;
                }
                else
                {
                    throw new ArgumentException("- Campo Costo debe ser entre $1 y $9.999.999.999");
                }
            }
        }


        //constructor
        public Multa()
        {
        }
    }
}
