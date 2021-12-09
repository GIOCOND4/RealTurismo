using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaModelo
{
    public class Inventario2
    {        
        public int id { get; set; }
        public int activo { get; set; }

        private string _nombreCorto;

        public string nombreCorto
        {
            get { return _nombreCorto; }
            set 
            {
                if (value.Trim().Length > 0 && value.Length <= 150)
                {
                    _nombreCorto = value;
                }
                else
                {
                    throw new ArgumentException("- Campo 'Nombre corto' no debe estar vacío ni exceder los 150 caracteres");
                }


            }
        }
        private long _costo;

        public long costo
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
                    throw new InvalidOperationException("- El campo 'Costo' debe ser mayor a 0 y menor a 9999999999");
                    //throw new Exception("mensaje de prueba de error");
                }
            }
                 
        }
        private string _descripcion;

        public string descripcion
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
                    throw new ArgumentException("- El campo 'Descripción detallada' no debe estar vacío ni exceder el largo permitido de 1000 caracteres.");
                }
            }
        }
        
        private int _cantidad;

        public int cantidad
        {
            get { return _cantidad; }
            set 
            {
                if (value > 0 && value <= 999)
                {
                    _cantidad = value;
                }
                else
                {
                    throw new InvalidOperationException("- El campo 'Cantidad' no debe estar vacío ni ser mayor a 999.");
                }

                
            }
        }
    }
    public class InventarioListar
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public long costo { get; set; }
        public int stock { get; set; }
        
    }
}
