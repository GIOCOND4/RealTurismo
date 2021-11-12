using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaModelo
{
    public class Servicio
    {
        public int IdServicio { get; set; }

        private string _nombre;
        private long _costo;

        //Get y Set con regla de negocio
        public string Nombre
        {
            get { return _nombre; }
            set
            {
                if (value.Trim().Length > 0 && value.Length <= 150)
                {
                    _nombre = value;
                }
                else
                {
                    throw new InvalidOperationException("- Campo Nombre no puede estar Vacío");
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
                    throw new InvalidOperationException("- Campo Costo debe ser entre $1 y $9.999.999.999");
                }
            }
        }

        public bool Disponible { get; set; }

        private string _descripcion;

        private string _ubicacionFoto;

        public string Descripcion
        {
            get { return _descripcion; }
            set
            {
                if (value.Trim().Length > 0 && value.Length <= 150)
                {
                    _descripcion = value;
                }
                else
                {
                    throw new InvalidOperationException("- La Descripción no puede estar vacía");
                }
            }
        }

        public string UbicacionFoto
        {
            get { return _ubicacionFoto; }
            set
            {
                if (value.Length <= 1000)
                {
                    _ubicacionFoto = value;
                }
                else
                {
                    throw new InvalidOperationException("- La Ruta de la Foto supera los 1000 caracteres");
                }
            }
        }

        public byte Foto { get; set; } //ver si este es el tipo de dato correcto



    }
}
