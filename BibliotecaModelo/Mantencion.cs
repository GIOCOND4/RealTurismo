using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaModelo
{
    public class Mantencion
    {
        public int IdMantencion { get; set; }
        public DateTime FechaRegistro { get; set; } //esta fecha se saca del sistema

        private DateTime _fechaMantencion;

        //Get y Set con regla de negocio
        public DateTime FechaMantencion
        {
            get { return _fechaMantencion; }
            set
            {
                if (value != null)
                {
                    _fechaMantencion = value;
                }
                else
                {
                    throw new InvalidOperationException("- Campo Fecha Mantención no puede estar Vacío");
                }
            }
        }

        public string Descripcion { get; set; }

        private long _costo;
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
                    throw new InvalidOperationException("- Campo Costo debe ser entre $1 y $9.999.999.999");
                }
            }
        }
        public int IdTipoMantencion { get; set; }


       

        


        ////constructor
        //public Mantencion()
        //{

        //}

    }
}
