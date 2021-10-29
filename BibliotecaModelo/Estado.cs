using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaModelo
{
    public class Estado
    {
        public int IdEstado { get; set; }
        private string _nombre;

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

        //constructor
        public Estado()
        {

        }
    }
}
