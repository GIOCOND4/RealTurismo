using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaModelo
{
    public class Persona
    {
        public int IdPersona { get; set; }

        private int _rut;        
        private string _dv;
        private string _nombres;
        private string _apellidoPat;
        public string ApellidoMat { get; set; }
        public string NombreCompleto { get; set; }       

        private string _correo;
        public int IdPerfil { get; set; }
        public int Activo { get; set; } //cuando uno lo cree, vendrá activo por defecto (no creo que deba mostrarse al usuario)

        private string _nombreUsuario;

        private string _contrasenia;

        public string nombrePerfil { get; set; }
        public string Contrasenia
        {
            get { return _contrasenia; }
            set {
                if (value.Trim().Length > 0 && value.Trim().Length < 101)
                {
                    _contrasenia = value;
                }
                else
                {
                    throw new InvalidOperationException("- Campo 'Contraseña' no debe estar vacío");
                }
                 }
        }
        public int Rut2 { get; set; }


        public string NombreUsuario
        {
            get { return _nombreUsuario; }
            set {
                if (value.Trim().Length > 0 && value.Trim().Length < 21)
                {
                    _nombreUsuario = value;
                }
                else
                {
                    throw new InvalidOperationException("- Campo 'Nombre Usuario' no debe estar vacío");
                }
            }
        }


        //Get y Set con regla de negocio
        public int Rut
        {
            get { return _rut; }
            set
            {
                if (value == 8)
                {
                    _rut = value;
                }
                else
                {
                    throw new InvalidOperationException("- Campo Rut debe ser de 8 digitos");
                    //throw new ArgumentException("- Campo Rut no puede estar Vacío");
                }
            }
        }

        public string Dv
        {
            get { return _dv; }
            set
            {
                if (value.Trim().Length == 1)
                {
                    _dv = value;
                }
                else
                {
                    throw new InvalidOperationException("- Campo DV no puede estar Vacío");
                }
            }
        }

        public string Nombres
        {
            get { return _nombres; }
            set
            {
                if (value.Trim().Length > 2 && value.Length <= 50)
                {
                    _nombres = value;
                }
                else
                {
                    throw new InvalidOperationException("- Campo Nombres es muy corto o supera el largo permitido");
                }
            }
        }

        public string ApellidoPat
        {
            get { return _apellidoPat; }
            set
            {
                if (value.Trim().Length > 2 && value.Length <= 30)
                {
                    _apellidoPat = value;
                }
                else
                {
                    throw new InvalidOperationException("- Campo Apellido Paterno es muy corto o supera el largo permitido");
                }
            }
        }

        public string Correo
        {
            get { return _correo; }
            set
            {
                if (value.Trim().Length > 0 && value.Length <= 250)
                {
                    _correo = value;
                }
                else
                {
                    throw new InvalidOperationException("- Campo Correo no puede estar Vacío");
                }
            }
        }


        //constructor
        public Persona()
        {

        }
    }
}
