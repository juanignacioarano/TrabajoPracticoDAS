using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLUsuario
    {

        MPUsuario mapper = new MPUsuario();
        public int RegistrarUsuario(string username, string password)
        {
            return mapper.RegistrarUsuario(username, password);
        }

        public bool LoginUsuario(string username, string password)
        {
            return mapper.LoginUsuario(username, password);
        }

    }
}
