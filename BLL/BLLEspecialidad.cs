
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class BLLEspecialidad
    {
        MPEspecialidad mapper = new MPEspecialidad();

        public int AgregarEspecialidad(string Descripcion)
        {
            return mapper.AgregarEspecialidad(Descripcion);
        }

        public int ActualizarEstadoEspecialidad(int IdEspecialidad, bool Activo)
        {
            return mapper.ActualizarEstadoEspecialidad(IdEspecialidad, Activo);
        }
        public int ModificarEspecialidad(BE.Especialidad especialidad)
        {
            return mapper.ModificarEspecialidad(especialidad);
        }

        public int EliminarEspecialidad(int IdEspecialidad)
        {
            return mapper.EliminarEspecialidad(IdEspecialidad);
        }

        public List<Especialidad> ListarEspecialidades()
        {
            return mapper.ListarEspecialidades();
        }

        public void ExportarXmlEspecialidades()
        {
            mapper.ExportarXmlEspecialidades();
        }

    }
}
