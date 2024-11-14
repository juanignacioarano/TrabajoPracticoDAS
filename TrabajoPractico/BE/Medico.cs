using System.Collections.Generic;

namespace BE
{
    public class Medico
    {
        private int _idMedico;
        public int IdMedico
        {
            get { return _idMedico; }
            set { _idMedico = value; }
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

        public string Dni
        {
            get { return _dni; }
            set { _dni = value; }
        }

        private List<Especialidad> especialidades;
        public List<Especialidad> Especialidades
        {
            get { return especialidades; }
            set { especialidades = value; }
        }

        private string _matricula;
        public string Matricula
        {
            get { return _matricula; }
            set { _matricula = value; }
        }

    }

}
