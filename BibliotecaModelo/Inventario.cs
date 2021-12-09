using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaModelo
{
    public class Inventario
    {
        public int IdInventario { get; set; }

        private string _codigo;
        public string Codigo
        {
            get { return _codigo; }
            set
            {
                if (value.Trim().Length > 0 && value.Length <= 50)
                {
                    _codigo = value;
                }
                else
                {
                    throw new ArgumentException("- Campo Código no puede estar vacío y no exceder 50 caracteres");
                }
            }
        }

        private string _nombre;
        public string Nombre
        {
            get { return _nombre; }
            set
            {
                if (value.Trim().Length > 2 && value.Length <= 150)
                {
                    _nombre = value;
                }
                else
                {
                    throw new ArgumentException("- El Nombre es muy corto o excede largo permitido");
                }
            }
        }

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

        private string _descripcion;
        public string Descripcion
        {
            get { return _descripcion; }
            set
            {
                if (value.Trim().Length > 0 && value.Length <= 1000)
                {
                    _descripcion = value;
                }
                else
                {
                    throw new ArgumentException("- La Descripción es muy corta o excede largo permitido");
                }
            }
        }
        public bool Disponible { get; set; }


        //Get y set con condicional
        

        


        //constructor
        //public Inventario()
        //{

        //}
    }
}
