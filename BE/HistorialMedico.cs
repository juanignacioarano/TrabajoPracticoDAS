using System;

namespace BE
{
    public class HistorialMedico
    {
        private int _idHistorial;
        public int IdHistorial
        {
            get { return _idHistorial; }
            set { _idHistorial = value; }
        }

        private int _idPaciente;
        public int IdPaciente
        {
            get { return _idPaciente; }
            set { _idPaciente = value; }
        }

        private int _idMedico;
        public int IdMedico
        {
            get { return _idMedico; }
            set { _idMedico = value; }
        }

        private string _diagnostico;
        public string Diagnostico
        {
            get { return _diagnostico; }
            set { _diagnostico = value; }
        }

        private string _tratamiento;
        public string Tratamiento
        {
            get { return _tratamiento; }
            set { _tratamiento = value; }
        }

        private DateTime _fechaConsulta;
        public DateTime FechaConsulta
        {
            get { return _fechaConsulta; }
            set { _fechaConsulta = value; }
        }
    }
}

