using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class MPPaciente
    {

        Acceso acceso = new Acceso();

        public List<Paciente> ListarPacientesActivos()
        {
            List<Paciente> pacientes = new List<Paciente>();
            DataTable dt = acceso.Leer("SP_LISTAR_PACIENTES_ACTIVOS", null);
            foreach (DataRow item in dt.Rows)
            {
                Paciente paciente = new Paciente
                {
                    IdPaciente = int.Parse(item["IdPaciente"].ToString()),
                    Nombre = item["Nombre"].ToString(),
                    Apellido = item["Apellido"].ToString(),
                    DNI = item["Dni"].ToString(),
                    FechaNacimiento = Convert.ToDateTime(item["FechaNacimiento"]),
                    Direccion = item["Direccion"].ToString(),
                    Telefono = item["Telefono"].ToString(),
                    Genero = item["Genero"].ToString(),
                    NumeroDeAfiliado = item["NumeroDeAfiliado"].ToString(),
                    Email = item["Email"].ToString(),
                    Activo = Convert.ToBoolean(item["Activo"])
                };
                pacientes.Add(paciente);
            }
            return pacientes;
        }


            public int ActualizarEstadoPaciente(int IdPaciente, bool Activo)
        {
            SqlParameter[] parametros = new SqlParameter[2]
            {
            new SqlParameter("@IdPaciente", IdPaciente),
            new SqlParameter("@Activo", Activo)
            };
            return acceso.Escribir("SP_ACTUALIZAR_ESTADO_PACIENTE", parametros);
        }

        public List<Paciente> ListarPacientes()
        {
            List<Paciente> listaPacientes = new List<Paciente>();
            DataTable dt = acceso.Leer("SP_LISTAR_PACIENTES", null);

            foreach (DataRow item in dt.Rows)
            {
                Paciente paciente = new Paciente
                {
                    IdPaciente = Convert.ToInt32(item["IdPaciente"]),
                    Nombre = item["Nombre"].ToString(),
                    Apellido = item["Apellido"].ToString(),
                    DNI = item["Dni"].ToString(),
                    FechaNacimiento = Convert.ToDateTime(item["FechaNacimiento"]),
                    Direccion = item["Direccion"].ToString(),
                    Telefono = item["Telefono"].ToString(),
                    Genero = item["Genero"].ToString(),
                    NumeroDeAfiliado = item["NumeroDeAfiliado"].ToString(),
                    Email = item["Email"].ToString(),
                    Activo = Convert.ToBoolean(item["Activo"])
                };
                listaPacientes.Add(paciente);
            }
            return listaPacientes;
        }

        public void ExportarXML()
        {
            acceso.ExportarStoredProcedureAXml("SP_LISTAR_PACIENTES", "Pacientes", null);
        }
        public int AgregarPaciente(Paciente paciente)
        {
            SqlParameter[] parametros = new SqlParameter[9]
            {
            new SqlParameter("@Nombre", paciente.Nombre),
            new SqlParameter("@Apellido", paciente.Apellido),
            new SqlParameter("@DNI", paciente.DNI),
            new SqlParameter("@FechaNacimiento", paciente.FechaNacimiento),
            new SqlParameter("@Direccion", paciente.Direccion),
            new SqlParameter("@Telefono", paciente.Telefono),
            new SqlParameter("@Email", paciente.Email),
            new SqlParameter("@NumeroDeAfiliado", paciente.NumeroDeAfiliado),
            new SqlParameter("@Genero", paciente.Genero)
            };
            return acceso.Escribir("SP_INSERTAR_PACIENTE", parametros);
        }

        public int ModificarPaciente(Paciente paciente)
        {
            SqlParameter[] parametros = new SqlParameter[10]
            {
        new SqlParameter("@IdPaciente", paciente.IdPaciente),
        new SqlParameter("@Nombre", paciente.Nombre),
        new SqlParameter("@Apellido", paciente.Apellido),
        new SqlParameter("@DNI", paciente.DNI),
        new SqlParameter("@FechaNacimiento", paciente.FechaNacimiento),
        new SqlParameter("@Direccion", paciente.Direccion),
        new SqlParameter("@Telefono", paciente.Telefono),
        new SqlParameter("@Email", paciente.Email),
        new SqlParameter("@Genero", paciente.Genero),
        new SqlParameter("@NumeroDeAfiliado", paciente.NumeroDeAfiliado)
            };

            return acceso.Escribir("SP_ACTUALIZAR_PACIENTE", parametros);
        }



        public int EliminarPaciente(int IdPaciente)
        {
            SqlParameter[] parametros = new SqlParameter[1]
            {
            new SqlParameter("@IdPaciente", IdPaciente)
            };
            return acceso.Escribir("SP_ELIMINAR_PACIENTE", parametros);
        }

    }
}
