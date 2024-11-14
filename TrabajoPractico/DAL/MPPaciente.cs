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

        public List<Paciente> ListarPacientes()
        {
            List<Paciente> listaPacientes = new List<Paciente>();
            DataTable dt = new DataTable();
            dt = acceso.Leer("SP_LISTAR_PACIENTES", null);
            foreach (DataRow item in dt.Rows)
            {
                Paciente paciente = new Paciente();
                paciente.IdPaciente = Convert.ToInt32(item["IdPaciente"]);
                paciente.Nombre = item["Nombre"].ToString();
                paciente.Apellido = item["Apellido"].ToString();
                paciente.DNI = item["Dni"].ToString();
                paciente.FechaNacimiento = Convert.ToDateTime(item["FechaNacimiento"]);
                paciente.Direccion = item["Direccion"].ToString();
                paciente.Telefono = item["Telefono"].ToString();
                paciente.Genero = item["Genero"].ToString();
                paciente.NumeroDeAfiliado = item["NumeroDeAfiliado"].ToString();
                paciente.Email = item["Email"].ToString();
                listaPacientes.Add(paciente);
            }
            return listaPacientes;
        }   

        public int AgregarPaciente(Paciente paciente)
        {
            SqlParameter[] parametros = new SqlParameter[9];
            parametros[0] = new SqlParameter("@Nombre", paciente.Nombre);
            parametros[1] = new SqlParameter("@Apellido", paciente.Apellido);
            parametros[2] = new SqlParameter("@Dni", paciente.DNI);
            parametros[3] = new SqlParameter("@FechaNacimiento", paciente.FechaNacimiento);
            parametros[4] = new SqlParameter("@Direccion", paciente.Direccion);
            parametros[5] = new SqlParameter("@Telefono", paciente.Telefono);
            parametros[6] = new SqlParameter("@Email", paciente.Email);
            parametros[7] = new SqlParameter("@NumeroDeAfiliado", paciente.NumeroDeAfiliado);
            parametros[8] = new SqlParameter("@Genero", paciente.Genero);
            return acceso.Escribir("SP_INSERTAR_PACIENTE", parametros);
        }

    }
}
