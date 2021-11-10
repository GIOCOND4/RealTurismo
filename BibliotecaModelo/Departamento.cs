using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaModelo
{
    public class Departamento
    {
        //atributos
        public int IdDepartamento { get; set; }

        private string _nombreDescriptivo;
        private string _direccion;
        private string _nroDepartamento;
        private int _piso;
        private int _costo;
        public bool Cable { get; set; }
        public bool Internet { get; set; }
        public bool Calefaccion { get; set; }
        public bool Amoblado { get; set; }
        public bool AireAcondicionado { get; set; }
        public bool Balcon { get; set; }

        private int _nroHabitaciones;
        private int _nroBanios;
        private int _cantidadPersonas;
        public bool Disponible { get; set; }
        public int IdComuna { get; set; }


        //Get y Set con condicional
        public string NombreDescriptivo
        {
            get { return _nombreDescriptivo; }

            set
            {
                if (value.Trim().Length > 0 && value.Length <= 100)
                {
                    _nombreDescriptivo = value;
                }
                else
                {
                    throw new InvalidOperationException("El Nombre del departamento es muy largo o esta vacio");
                }
                
            }
        }

        public string Direccion
        {
            get
            {
                return _direccion;
            }

            set
            {
                if (value.Trim().Length > 0 && value.Length <= 100)
                {
                    _direccion = value;
                }
                else
                {
                    throw new InvalidOperationException("La Dirección es muy largo o esta vacio");
                }
            }
        }

        public string NroDepartamento
        {
            get { return _nroDepartamento; }

            set
            {
                if (value.Trim().Length > 0 && value.Length < 10)
                {
                    _nroDepartamento = value;
                }
                else
                {
                    throw new InvalidOperationException("- El N° ddel Departamento es obligatorio");
                }
            }
        }

        public int Piso
        {
            get { return _piso; }

            set
            {
                if (value > 0 && value < 100)
                {
                    _piso = value;
                }
                else
                {
                    throw new InvalidOperationException("- El piso debe ser mayor que 0 y menor que 100");
                }
            }
        }
        
        public int Costo
        {
            get
            {
                return _costo;
            }

            set
            {
                if (value >= 15000 && value <=9999999999)
                {
                    _costo = value;
                }
                else
                {
                    throw new InvalidOperationException("- El valor minimo de Costo arriendo es de $15.000");
                }
            }
        }

        public int NroHabitaciones
        {
            get
            {
                return _nroHabitaciones;
            }

            set
            {
                if (value > 0 && value <= 20) //colocar un límite realista ¿?
                {
                    _nroHabitaciones = value;
                }
                else
                {
                    throw new InvalidOperationException("El N° de Habitaciones es muy grande o está vacío");
                }
            }
        }

        public int NroBanios
        {
            get
            {
                return _nroBanios;
            }

            set
            {
                if (value > 0 && value <= 10) //colocar un límite realista ¿?
                {
                    _nroBanios = value;
                }
                else
                {
                    throw new InvalidOperationException("El N° de Baños es muy grande o está vacío");
                }
            }
        }

        public int CantidadPersonas
        {
            get
            {
                return _cantidadPersonas;
            }

            set
            {
                if (value > 0 && value <= 99)
                {
                    _cantidadPersonas = value;
                }
                else
                {
                    throw new InvalidOperationException("La Cantidad de Personas para hospedar es muy grande o está vacío");
                }
            }
        }


        //Constructor
        public Departamento()
        {

        }
    }
}
