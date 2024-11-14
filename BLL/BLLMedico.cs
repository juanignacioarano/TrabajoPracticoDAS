using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace BLL
{
    public class BLLMedico
    {
        MPMedico mapper = new MPMedico();

        public List<Especialidad> ListarEspecialidades()
        {
            return mapper.ListarEspecialidades();
        }

        public List<Especialidad> ListarEspecialidadesPorMedico(int IdMedico)
        {
            return mapper.ListarEspecialidadesPorMedico(IdMedico);
        }
        public int AgregarMedico(Medico medico)
        {
            return mapper.AgregarMedico(medico);
        }
        public int AgregarEspecialidades(int IdMedico, List<int> especialidades)
        {
            return mapper.AgregarEspecialidades(IdMedico, especialidades);
        }
        public List<Medico> ListarMedicos()
        {
            return mapper.ListarMedicos();
        }

    }
}
