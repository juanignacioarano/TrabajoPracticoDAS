using System;

namespace BE
{
    public class Turno
    {
        private int _idTurno;
        public int IdTurno
        {
            get { return _idTurno; }
            set { _idTurno = value; }
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

        private DateTime _fechaTurno;
        public DateTime FechaTurno
        {
            get { return _fechaTurno; }
            set { _fechaTurno = value; }
        }

        private DateTime _fechaLlegada;

        public DateTime FechaLlegada
        {
            get { return _fechaLlegada; }
            set { _fechaLlegada = value; }
        }

        private string _motivoConsulta;
        public string MotivoConsulta
        {
            get { return _motivoConsulta; }
            set { _motivoConsulta = value; }
        }
    }
}
