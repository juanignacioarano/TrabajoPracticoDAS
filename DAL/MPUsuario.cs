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
    public class MPUsuario
    {
        Acceso acceso = new Acceso();

        public int RegistrarUsuario(string username, string password)
        {
            SqlParameter[] parametros = new SqlParameter[2]
            {
                new SqlParameter("@username", username),
                new SqlParameter("@password", password)
            };

            return acceso.Escribir("SP_INSERTAR_USUARIO", parametros);
        }

        public int EliminarUsuario(int id)
        {
            SqlParameter[] parametros = new SqlParameter[1]
            {
                new SqlParameter("@IdUsuario", id)
            };

            return acceso.Escribir("SP_ELIMINAR_USUARIO", parametros);
        }

        public int ModificarUsuario(Usuario usuario)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
    {
        new SqlParameter("@Id", usuario.IdUsuario),
        new SqlParameter("@Username", usuario.NombreUsuario)
    };

            if (!string.IsNullOrWhiteSpace(usuario.Contraseña))
            {
                parametros.Add(new SqlParameter("@Password", usuario.Contraseña));
            }
            else
            {
                parametros.Add(new SqlParameter("@Password", DBNull.Value));
            }

            return acceso.Escribir("SP_ACTUALIZAR_USUARIO", parametros.ToArray());
        }


        public List<Usuario> ListarUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            DataTable dt = new DataTable();
            dt = acceso.Leer("SP_LISTAR_USUARIOS", null);

            foreach (DataRow item in dt.Rows)
            {
                Usuario usuario = new Usuario();
                usuario.IdUsuario = Convert.ToInt32(item["IdUsuario"]);
                usuario.NombreUsuario = item["NombreUsuario"].ToString();
                usuarios.Add(usuario);
            }
            return usuarios;
        }

        public void ExportarXML()
        {
            acceso.ExportarStoredProcedureAXml("SP_LISTAR_USUARIOS", "Usuarios", null);
        }

        public bool LoginUsuario(string username, string password)
        {
            SqlParameter[] parametros = new SqlParameter[3]
            {
                new SqlParameter("@Username", username),
                new SqlParameter("@Password", password),
                
                new SqlParameter("@IsAuthenticated", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                }
            };

            acceso.Leer("SP_LOGIN_USUARIO", parametros);

            return (bool)parametros[2].Value;
        }

    }
}
