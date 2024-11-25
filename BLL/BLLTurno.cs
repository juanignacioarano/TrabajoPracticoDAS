using System;
using System.Collections.Generic;
using BE; 
using DAL; 

namespace BLL
{
    public class BLLTurno
    {
        private readonly DALTurno dalTurno = new DALTurno();

        public int AgregarTurno(Turno turno)
        {
            return dalTurno.InsertarTurno(turno);
        }

        public void ExportarXML()
        {
            dalTurno.ExportarXML();
        }

        public List<Turno> ObtenerTurnos(DateTime? fechaInicio, DateTime? fechaFin, int? idMedico, int? idPaciente)
        {
            return dalTurno.ListarTurnos(fechaInicio, fechaFin, idMedico, idPaciente);
        }

        public void RegistrarLlegada(int idTurno, DateTime horaLlegada)
        {
            dalTurno.RegistrarLlegada(idTurno, horaLlegada);
        }

        public void CancelarTurno(int idTurno)
        {
            dalTurno.CancelarTurno(idTurno);
        }

        public List<Turno> ListarTurnos()
        {
            return dalTurno.ListarTurnos(null, null, null, null);
        }

        public void EliminarTurno(int idTurno)
        {
            dalTurno.EliminarTurno(idTurno);
        }
    }
}
