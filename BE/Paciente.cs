using System;

namespace BE
{
    public class Paciente
    {
        private int _idPaciente;
        public int IdPaciente
        {
            get { return _idPaciente; }
            set { _idPaciente = value; }
        }

        private string _nombre;
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private string _apellido;
        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }

        private string _dni;
        public string DNI
        {
            get { return _dni; }
            set { _dni = value; }
        }

        private DateTime _fechaNacimiento;
        public DateTime FechaNacimiento
        {
            get { return _fechaNacimiento; }
            set { _fechaNacimiento = value; }
        }

        private string _direccion;
        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        private string _telefono;
        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _genero;
        public string Genero
        {
            get { return _genero; }
            set { _genero = value; }
        }

        private string _numeroDeAfiliado;

        public string NumeroDeAfiliado
        {
            get { return _numeroDeAfiliado; }
            set { _numeroDeAfiliado = value; }
        }

        private bool activo;

        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
        }

    }
}
