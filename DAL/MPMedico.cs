using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MPMedico
    {
        Acceso acceso = new Acceso();

        public List<Especialidad> ListarEspecialidades()
        {
            List<Especialidad> especialidades = new List<Especialidad>();
            DataTable dt = new DataTable();
            dt = acceso.Leer("SP_LISTAR_ESPECIALIDADES", null);
            foreach (DataRow item in dt.Rows)
            {
                Especialidad especialidad = new Especialidad();
                especialidad.IdEspecialidad = int.Parse(item["IdEspecialidad"].ToString());
                especialidad.Descripcion = item["Descripcion"].ToString();
                especialidades.Add(especialidad);
            }
            return especialidades;
        }

        public List<Especialidad> ListarEspecialidadesPorMedico(int IdMedico)
        {
            List<Especialidad> especialidades = new List<Especialidad>();
            SqlParameter[] param = new SqlParameter[1]
            {
                new SqlParameter("@IdMedico", IdMedico)
            };
            
            DataTable dt = new DataTable();
            dt = acceso.Leer("SP_LISTAR_ESPECIALIDADES_POR_MEDICO", param);
            foreach (DataRow item in dt.Rows)
            {
                Especialidad especialidad = new Especialidad();
                especialidad.IdEspecialidad = int.Parse(item["IdEspecialidad"].ToString());
                especialidad.Descripcion = item["Descripcion"].ToString();
                especialidades.Add(especialidad);
            }
            return especialidades;

        }


        public int AgregarMedico(Medico medico)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@Nombre", medico.Nombre);
            param[1] = new SqlParameter("@Apellido", medico.Apellido);
            param[2] = new SqlParameter("@Matricula", medico.Matricula);
            param[3] = new SqlParameter("@Dni", medico.Dni);

            SqlParameter outputId = new SqlParameter("@IdMedico", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            param[4] = outputId;
            acceso.Escribir("SP_INSERTAR_MEDICO", param);
            return (int)outputId.Value;
        }

        public int AgregarEspecialidades(int IdMedico, List<int> especialidades)
        {
            int i = 0;
            foreach (int item in especialidades)
            {
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter("@IdMedico", IdMedico));
                parametros.Add(new SqlParameter("@IdEspecialidad", item));
                SqlParameter[] param = parametros.ToArray();
                i += acceso.Escribir("SP_INSERTAR_MEDICO_ESPECIALIDAD", param);
            }
            return i;
        }

        public List<Medico> ListarMedicos()
        {
            List<Medico> medicos = new List<Medico>();
            DataTable dt = new DataTable();
            dt = acceso.Leer("SP_LISTAR_MEDICOS", null);
            foreach (DataRow item in dt.Rows)
            {
                Medico medico = new Medico();
                medico.IdMedico = int.Parse(item["IdMedico"].ToString());
                medico.Nombre = item["Nombre"].ToString();
                medico.Apellido = item["Apellido"].ToString();
                medico.Matricula = item["Matricula"].ToString();
                medico.Dni = item["Dni"].ToString();
                medicos.Add(medico);
            }
            return medicos;
        }
    }
}
