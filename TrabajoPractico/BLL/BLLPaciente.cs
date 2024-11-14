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

        public int AgregarPaciente(Paciente paciente)
        {
            return mpPaciente.AgregarPaciente(paciente);
        }
    }
}
