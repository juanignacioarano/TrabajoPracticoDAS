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

        public List<Medico> ListarMedicosActivos()
        {
            return mapper.ListarMedicosActivos();
        }

        public int ActualizarEstadoMedico(int IdMedico, bool Activo)
        {
            return mapper.ActualizarEstadoMedico(IdMedico, Activo);
        }

        public void ExportarXML()
        {
            mapper.ExportarXML();
        }

        public List<Especialidad> ListarEspecialidadesPorMedico(int IdMedico)
        {
            return mapper.ListarEspecialidadesPorMedico(IdMedico);
        }
        public int AgregarMedico(Medico medico, List<int> especialidades)
        {
            return mapper.AgregarMedico(medico, especialidades);
        }
        public int AgregarEspecialidades(int IdMedico, List<int> especialidades)
        {
            return mapper.AgregarEspecialidades(IdMedico, especialidades);
        }
        public List<Medico> ListarMedicos()
        {
            return mapper.ListarMedicos();
        }

        public int EliminarMedico(int IdMedico)
        {
            return mapper.EliminarMedico(IdMedico);
        }

        public int ModificarMedico(Medico medico)
        {
            return mapper.ModificarMedico(medico);
        }

        public void ActualizarEspecialidades(int IdMedico, List<int> especialidades)
        {
            mapper.ActualizarEspecialidades(IdMedico, especialidades);
        }


    }
}
