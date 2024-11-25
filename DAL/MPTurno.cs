using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BE; // Namespace donde están las entidades como Turno, Medico, Paciente

namespace DAL
{
    public class DALTurno
    {
        private readonly Acceso acceso = new Acceso();

        public int InsertarTurno(Turno turno)
        {
            SqlParameter[] parametros = new SqlParameter[5];
            parametros[0] = new SqlParameter("@IdMedico", turno.IdMedico);
            parametros[1] = new SqlParameter("@IdPaciente", turno.IdPaciente);
            parametros[2] = new SqlParameter("@FechaHora", turno.FechaHora);
            parametros[3] = new SqlParameter("@Motivo", turno.Motivo);

            SqlParameter idTurnoOutput = new SqlParameter("@IdTurno", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            parametros[4] = idTurnoOutput;

            acceso.Escribir("SP_INSERTAR_TURNO", parametros);
            return (int)idTurnoOutput.Value;
        }

        public void ExportarXML()
        {
            acceso.ExportarStoredProcedureAXml("SP_LISTAR_TURNOS", "Turnos", null);
        }

        public List<Turno> ListarTurnos(DateTime? fechaInicio, DateTime? fechaFin, int? idMedico, int? idPaciente)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            if (fechaInicio.HasValue)
                parametros.Add(new SqlParameter("@FechaInicio", fechaInicio.Value));
            else
                parametros.Add(new SqlParameter("@FechaInicio", DBNull.Value));

            if (fechaFin.HasValue)
                parametros.Add(new SqlParameter("@FechaFin", fechaFin.Value));
            else
                parametros.Add(new SqlParameter("@FechaFin", DBNull.Value));

            parametros.Add(new SqlParameter("@IdMedico", idMedico ?? (object)DBNull.Value));
            parametros.Add(new SqlParameter("@IdPaciente", idPaciente ?? (object)DBNull.Value));

            DataTable dt = acceso.Leer("SP_LISTAR_TURNOS", parametros.ToArray());
            List<Turno> turnos = new List<Turno>();

            foreach (DataRow row in dt.Rows)
            {
                Turno turno = new Turno
                {
                    IdTurno = Convert.ToInt32(row["IdTurno"]),
                    Medico = row["NombreMedico"].ToString() + " " + row["ApellidoMedico"].ToString(),
                    DniMedico = Convert.ToInt32(row["DniMedico"]),
                    Paciente = row["NombrePaciente"].ToString() + " " + row["ApellidoPaciente"].ToString(),
                    DniPaciente = Convert.ToInt32(row["DniPaciente"]),
                    IdPaciente = Convert.ToInt32(row["IdPaciente"]),
                    IdMedico = Convert.ToInt32(row["IdMedico"]),
                    FechaHora = Convert.ToDateTime(row["FechaHora"]),
                    Motivo = row["Motivo"].ToString(),
                    Estado = row["Estado"].ToString(),
                    HoraLlegada = row["HoraLlegada"] as DateTime?
                };
                turnos.Add(turno);
            }

            return turnos;
        }

        public void RegistrarLlegada(int idTurno, DateTime horaLlegada)
        {
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = new SqlParameter("@IdTurno", idTurno);
            parametros[1] = new SqlParameter("@HoraLlegada", horaLlegada);

            acceso.Escribir("SP_REGISTRAR_LLEGADA", parametros);
        }

        public void CancelarTurno(int idTurno)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@IdTurno", idTurno);

            acceso.Escribir("SP_CANCELAR_TURNO", parametros);
        }

        public void EliminarTurno(int idTurno)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@IdTurno", idTurno);

            acceso.Escribir("SP_ELIMINAR_TURNO", parametros);
        }
    }
}
