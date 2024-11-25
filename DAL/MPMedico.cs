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

        public List<Medico> ListarMedicosActivos()
        {
            List<Medico> medicos = new List<Medico>();
            DataTable dt = acceso.Leer("SP_LISTAR_MEDICOS_ACTIVOS", null);
            foreach (DataRow item in dt.Rows)
            {
                Medico medico = new Medico
                {
                    IdMedico = int.Parse(item["IdMedico"].ToString()),
                    Nombre = item["Nombre"].ToString(),
                    Apellido = item["Apellido"].ToString(),
                    Matricula = item["Matricula"].ToString(),
                    Dni = item["Dni"].ToString(),
                    Especialidades = item["Especialidades"].ToString(),
                    Activo = Convert.ToBoolean(item["Activo"])
                };
                medicos.Add(medico);
            }
            return medicos;
        }
        public int ActualizarEstadoMedico(int IdMedico, bool Activo)
        {
            SqlParameter[] parametros = new SqlParameter[2]
            {
            new SqlParameter("@IdMedico", IdMedico),
            new SqlParameter("@Activo", Activo)
            };
            return acceso.Escribir("SP_ACTUALIZAR_ESTADO_MEDICO", parametros);
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
                especialidades.Add(especialidad);
            }
            return especialidades;

        }


        public int AgregarMedico(Medico medico, List<int> especialidades)
        {
            int idMedico;

            SqlParameter[] paramMedico = new SqlParameter[5];
            paramMedico[0] = new SqlParameter("@Nombre", medico.Nombre);
            paramMedico[1] = new SqlParameter("@Apellido", medico.Apellido);
            paramMedico[2] = new SqlParameter("@Matricula", medico.Matricula);
            paramMedico[3] = new SqlParameter("@Dni", medico.Dni);

            SqlParameter outputId = new SqlParameter("@IdMedico", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            paramMedico[4] = outputId;

            acceso.Escribir("SP_INSERTAR_MEDICO", paramMedico);

            idMedico = (int)outputId.Value;
            List<(string procedimiento, SqlParameter[] parametros)> operaciones = new List<(string, SqlParameter[])>();

            foreach (int idEspecialidad in especialidades)
            {
                SqlParameter[] paramEspecialidad = new SqlParameter[2];
                paramEspecialidad[0] = new SqlParameter("@IdMedico", idMedico);
                paramEspecialidad[1] = new SqlParameter("@IdEspecialidad", idEspecialidad);

                operaciones.Add(("SP_INSERTAR_MEDICO_ESPECIALIDAD", paramEspecialidad));
            }

            acceso.EscribirLista(operaciones);

            return idMedico;
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

        public void ActualizarEspecialidades(int idMedico, List<int> especialidades)
        {
            SqlParameter[] parametrosEliminar = new SqlParameter[1]
            {
        new SqlParameter("@IdMedico", idMedico)
            };

            acceso.Escribir("SP_ELIMINAR_ESPECIALIDADES_POR_MEDICO", parametrosEliminar);

            foreach (int idEspecialidad in especialidades)
            {
                SqlParameter[] parametrosAgregar = new SqlParameter[2]
                {
            new SqlParameter("@IdMedico", idMedico),
            new SqlParameter("@IdEspecialidad", idEspecialidad)
                };

                acceso.Escribir("SP_INSERTAR_MEDICO_ESPECIALIDAD", parametrosAgregar);
            }
        }


        public List<Medico> ListarMedicos()
        {
            List<Medico> medicos = new List<Medico>();
            DataTable dt = acceso.Leer("SP_LISTAR_MEDICOS", null);

            foreach (DataRow item in dt.Rows)
            {
                Medico medico = new Medico
                {
                    IdMedico = int.Parse(item["IdMedico"].ToString()),
                    Nombre = item["Nombre"].ToString(),
                    Apellido = item["Apellido"].ToString(),
                    Matricula = item["Matricula"].ToString(),
                    Especialidades = item["Especialidades"].ToString(),
                    Dni = item["Dni"].ToString(),
                    Activo = Convert.ToBoolean(item["Activo"])
                };
                medicos.Add(medico);
            }
            return medicos;
        }

        public void ExportarXML()
        {
            acceso.ExportarStoredProcedureAXml("SP_LISTAR_MEDICOS", "Medicos", null);
        }

        public int ModificarMedico(Medico medico)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@IdMedico", medico.IdMedico);
            param[1] = new SqlParameter("@Nombre", medico.Nombre);
            param[2] = new SqlParameter("@Apellido", medico.Apellido);
            param[3] = new SqlParameter("@Matricula", medico.Matricula);
            param[4] = new SqlParameter("@Dni", medico.Dni);
            return acceso.Escribir("SP_ACTUALIZAR_MEDICO", param);
        }

        public int EliminarMedico(int IdMedico)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@IdMedico", IdMedico);
            return acceso.Escribir("SP_ELIMINAR_MEDICO", param);
        }
    }
}
