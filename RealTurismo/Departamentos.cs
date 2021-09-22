using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
