using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BE;

namespace DAL
{
    public class MPEspecialidad
    {
        Acceso Acceso = new Acceso();

        public void ExportarXmlEspecialidades()
        {
            Acceso.ExportarStoredProcedureAXml("SP_LISTAR_ESPECIALIDADES", "especialidades", null);
        }

        public int ActualizarEstadoEspecialidad(int IdEspecialidad, bool Activo)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@IdEspecialidad", IdEspecialidad);
            param[1] = new SqlParameter("@Activo", Activo);
            return Acceso.Escribir("SP_ACTUALIZAR_ESTADO_ESPECIALIDAD", param);
        }

        public int AgregarEspecialidad(string Descripcion)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Descripcion", Descripcion);
            return Acceso.Escribir("SP_INSERTAR_ESPECIALIDAD", param);
        }

        public int ModificarEspecialidad(Especialidad especialidad)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@IdEspecialidad", especialidad.IdEspecialidad);
            param[1] = new SqlParameter("@Descripcion", especialidad.Descripcion);
            return Acceso.Escribir("SP_ACTUALIZAR_ESPECIALIDAD", param);
        }

        public int EliminarEspecialidad(int IdEspecialidad)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IdEspecialidad", IdEspecialidad);
            return Acceso.Escribir("SP_ELIMINAR_ESPECIALIDAD", param);
        }

        public List<BE.Especialidad> ListarEspecialidades()
        {
            List<BE.Especialidad> especialidades = new List<BE.Especialidad>();
            var dt = Acceso.Leer("SP_LISTAR_ESPECIALIDADES", null);

            foreach (System.Data.DataRow item in dt.Rows)
            {
                BE.Especialidad especialidad = new BE.Especialidad
                {
                    IdEspecialidad = int.Parse(item["IdEspecialidad"].ToString()),
                    Descripcion = item["Descripcion"].ToString(),
                };
                especialidades.Add(especialidad);
            }
            return especialidades;
        }
    }
}
