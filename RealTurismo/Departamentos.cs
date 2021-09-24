using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RealTurismo
{
    public class Departamentos
    {

        /*
         <DataGrid.Columns>
                <DataGridTextColumn Binding="{Binding Path=id}" Header="ID"/>
                <DataGridTextColumn Binding="{Binding Path=nombre}" Header="Nombre"/>
                <DataGridTextColumn Binding="{Binding Path=direccion}" Header="Dirección"/>
                <DataGridTextColumn Binding="{Binding Path=costo}" Header="Costo"/>
                <DataGridTextColumn Binding="{Binding Path=piso}" Header="Piso"/>
                <DataGridCheckBoxColumn Binding="{Binding Path=cable}" Header="Cable"/>
                <DataGridCheckBoxColumn Binding="{Binding Path=internet}" Header="Internet"/>
                <DataGridCheckBoxColumn Binding="{Binding Path=calefacion}" Header="Calefacción"/>
                <DataGridCheckBoxColumn Binding="{Binding Path=amoblado}" Header="Amoblado"/>
                <DataGridCheckBoxColumn Binding="{Binding Path=aire}" Header="Aire Condicionado"/>
                <DataGridCheckBoxColumn Binding="{Binding Path=balcon}" Header="Balcón"/>
                <DataGridTextColumn Binding="{Binding Path=nhabitaciones}" Header="Nº Habitaciones"/>
                <DataGridTextColumn Binding="{Binding Path=nbanios}" Header="Nº Baños"/>
                <DataGridTextColumn Binding="{Binding Path=npersonas}" Header="Nº Personas"/>
                <DataGridCheckBoxColumn Binding="{Binding Path=disponible}" Header="Disponible"/>
                <DataGridTextColumn Binding="{Binding Path=idcomuna}" Header="ID Comuna"/>
            </DataGrid.Columns>
         */
        //atributos
        private int _idDepartamento;
        private string _nombreDescriptivo;
        private string _direccion;
        private int _piso;
        private int _costo;
        private bool _cable;
        private bool _internet;
        private bool _calefaccion;
        private bool _amoblado;
        private bool _aireAcondicionado;
        private bool _balcon;
        private int _nroHabitaciones;
        private int _nroBanios;
        private int _cantidadPersonas;
        private bool _disponible;
        private int _idComuna;

        //Get y Set
        public int IdDepartamento
        {
            get
            {
                return _idDepartamento;
            }

            set
            {
                _idDepartamento = value;
            }
        }

        public string NombreDescriptivo 
        {
            get
            {
                return _nombreDescriptivo;
            }

            set
            {
                if (value.Length > 100 || value.Length < 1)
                {
                    throw new InvalidOperationException("El nombre del departamento es muy largo o esta vacio");
                }
                _nombreDescriptivo = value;
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
                if (value.Length > 100 || value.Length < 1)
                {
                    throw new InvalidOperationException("La direccion es muy larga o esta vacio");
                }
                _direccion = value;
            }
        }

        public int Piso
        {
            get
            {
                return _piso;
            }

            set
            {
                if (value < 1 || value > 99) 
                {
                    throw new InvalidOperationException("El piso debe ser mayor que 0 y menor que 100");
                }
                _piso = value;
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
                if (value < 15000)
                {
                    throw new InvalidOperationException("El valor minimo de costo es de $15000 ");
                }
                _costo = value;
            }
        }

        public bool Cable
        {
            get
            {
                return _cable;
            }

            set
            {
                _cable = value;
            }
        }

        public bool Internet
        {
            get
            {
                return _internet;
            }

            set
            {
                _internet = value;
            }
        }

        public bool Calefaccion
        {
            get
            {
                return _calefaccion;
            }

            set
            {
                _calefaccion = value;
            }
        }

        public bool Amoblado
        {
            get
            {
                return _amoblado;
            }

            set
            {
                _amoblado = value;
            }
        }
        public bool AireAcondiconado
        {
            get
            {
                return _aireAcondicionado;
            }

            set
            {
                _aireAcondicionado = value;
            }
        }

        public bool Balcon
        {
            get
            {
                return _balcon;
            }

            set
            {
                _balcon = value;
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
                if (value < 1 || value > 99)
                {
                    throw new InvalidOperationException("El nro de habitaciones es muy grande o es nulo");
                }
                _nroHabitaciones = value;
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
                if (value < 1 || value > 99)
                {
                    throw new InvalidOperationException("El nro de bños es muy grande o es nulo");
                }
                _nroBanios = value;
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
                if (value < 1 || value > 99)
                {
                    throw new InvalidOperationException("La cantidad de personas es muy grande o es nulo");
                }
                _cantidadPersonas = value;
            }
        }

        public bool Disponible
        {
            get
            {
                return _disponible;
            }

            set
            {
                _disponible = value;
            }
        }

        public int IdComuna
        {
            get
            {
                return _idComuna;
            }

            set
            {
                _idComuna = value;
            }
        }
    }
}
