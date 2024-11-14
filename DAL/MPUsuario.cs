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

            acceso.Escribir("SP_LOGIN_USUARIO", parametros);

            return (bool)parametros[2].Value;
        }

    }
}
