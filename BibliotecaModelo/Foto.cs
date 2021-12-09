using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaModelo
{
     public class Foto
    {
        public int IdFoto { get; set; }
        private string _descripcion;
        
        private string _ubicacion;

        public string Descripcion
        {
            get
            {
                return _descripcion;
            }

            set
            {
                if (value.Trim().Length > 0 && value.Length <= 150)
                {
                    _descripcion = value;
                }
                else
                {
                    throw new InvalidOperationException("- La descripcion supera el largo del caracter o esta vacio");
                }
            }
        }

        public string Ubicacion
        {
            get
            {
                return _ubicacion;
            }

            set
            {
                if (value.Trim().Length > 0 && value.Length <= 1000)
                {
                    _ubicacion = value;
                }
                else
                {
                    throw new InvalidOperationException("- La ubicacion supera el largo del caracter o esta vacio");
                }
                
            }
        }
        public byte[] Imagen { get; set; }

    }
}
