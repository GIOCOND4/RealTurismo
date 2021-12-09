using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaModelo
{
    public class Reserva
    {
        public int IdDepartamento { get; set; }
        public int IdReserva { get; set; }

        private long _montoAnticipo;

        public long MontoAnticipo
        {
            get { return _montoAnticipo; }
            set
            {
                if (value > 0 && value <= 9999999999)
                {
                    _montoAnticipo = value;
                }
                else
                {
                    throw new InvalidOperationException("- Campo Anticipo debe ser entre $1 y $9.999.999.999");
                }
            }
        }

        public DateTime FechaReserva { get; set; } //sacada del sistema

        private DateTime _fechaLlegada;
        private DateTime _fechaSalida;
        public DateTime FechaLlegada
        {
            get { return _fechaLlegada; }
            set
            {
                if (value != null)
                {
                    _fechaLlegada = value;
                }
                else
                {
                    throw new InvalidOperationException("- Campo Fecha Llegada no puede quedar vacío");
                }
            }
        }

        public DateTime FechaSalida
        {
            get { return _fechaSalida; }
            set
            {
                if (value != null)
                {
                    _fechaSalida = value;
                }
                else
                {
                    throw new InvalidOperationException("- Campo Fecha Salida no puede quedar vacío");
                }
            }
        }

        public int IdEstado { get; set; }


        //Get y Set con regla de negocio
        

        

        ////constructor
        //public Reserva()
        //{

        //}
    }
}
