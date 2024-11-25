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

        private int _idMedico;
        public int IdMedico
        {
            get { return _idMedico; }
            set { _idMedico = value; }
        }

        private string _medico;

        public string Medico
        {
            get { return _medico; }
            set { _medico = value; }
        }

        private int dniMedico;

        public int DniMedico
        {
            get { return dniMedico; }
            set { dniMedico = value; }
        }


        private string paciente;

        public string Paciente
        {
            get { return paciente; }
            set { paciente = value; }
        }

        private int dniPaciente;

        public int DniPaciente
        {
            get { return dniPaciente; }
            set { dniPaciente = value; }
        }



        private int _idPaciente;
        public int IdPaciente
        {
            get { return _idPaciente; }
            set { _idPaciente = value; }
        }

        private DateTime _fechaHora;
        public DateTime FechaHora
        {
            get { return _fechaHora; }
            set { _fechaHora = value; }
        }

        private string _motivo;
        public string Motivo
        {
            get { return _motivo; }
            set { _motivo = value; }
        }

        private string _estado;
        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        private DateTime? _horaLlegada;
        public DateTime? HoraLlegada
        {
            get { return _horaLlegada; }
            set { _horaLlegada = value; }
        }
    }
}
