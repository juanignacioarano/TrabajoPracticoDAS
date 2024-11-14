using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Data.SqlClient;


namespace DAL
{
    public class MPTurno
    {
        Acceso acceso = new Acceso();

        public List<Turno> ListarTurnos()
        {
            List<Turno> turnos = new List<Turno>();
            DataTable dt = new DataTable();
            dt = acceso.Leer("SP_LISTAR_TURNOS", null);

            foreach (DataRow item in dt.Rows)
            {
                Turno turno = new BE.Turno();
                turno.IdTurno = Convert.ToInt32(item["IdTurno"]);
                turno.IdMedico = Convert.ToInt32(item["IdMedico"]);
                turno.IdPaciente = Convert.ToInt32(item["IdPaciente"]);
                turno.FechaTurno = Convert.ToDateTime(item["Fecha"]);
                turno.FechaLlegada = Convert.ToDateTime(item["FechaLlegada"]);
                turnos.Add(turno);
            }
            return turnos;
        }

        public int AgregarTurno(Turno turno)
        {
            SqlParameter[] parametros = new SqlParameter[3];
            parametros[0] = new SqlParameter("@IdMedico", turno.IdMedico);
            parametros[1] = new SqlParameter("@IdPaciente", turno.IdPaciente);
            parametros[2] = new SqlParameter("@Fecha", turno.FechaTurno);
            return acceso.Escribir("SP_INSERTAR_TURNO", parametros);
        }

        public int EliminarTurno(int IdTurno)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter("@IdTurno", IdTurno);
            return acceso.Escribir("SP_ELIMINAR_TURNO", parametros);
        }

        public int LlegadaTurno(int IdTurno, DateTime fechaLlegada)
        {
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = new SqlParameter("@IdTurno", IdTurno);
            parametros[1] = new SqlParameter("@FechaLlegada", fechaLlegada);
            return acceso.Escribir("SP_LLEGADA_TURNO", parametros);
        }

    }
}
