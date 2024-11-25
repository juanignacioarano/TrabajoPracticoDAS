using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BLL
{
    public class BLLPaciente
    {
        MPPaciente mpPaciente = new MPPaciente();

        public List<Paciente> ListarPacientes()
        {
            return mpPaciente.ListarPacientes();
        }

        public List<Paciente> ListarPacientesActivos()
        {
            return mpPaciente.ListarPacientesActivos();
        }

        public int ActualizarEstadoPaciente(int IdPaciente, bool Activo)
        {
            return mpPaciente.ActualizarEstadoPaciente(IdPaciente, Activo);
        }
        public void ExportarXML()
        {
            mpPaciente.ExportarXML();
        }

        public int AgregarPaciente(Paciente paciente)
        {
            return mpPaciente.AgregarPaciente(paciente);
        }

        public int ModificarPaciente(Paciente paciente)
        {
            return mpPaciente.ModificarPaciente(paciente);
        }

        public int EliminarPaciente(int IdPaciente)
        {
            return mpPaciente.EliminarPaciente(IdPaciente);
        }

    }
}
