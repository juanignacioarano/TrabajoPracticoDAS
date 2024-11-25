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

        public int EliminarUsuario(int id)
        {
            return mapper.EliminarUsuario(id);
        }
        public int ModificarUsuario(Usuario usuario)
        {
            return mapper.ModificarUsuario(usuario);
        }
        public List<Usuario> ListarUsuarios()
        {
            return mapper.ListarUsuarios();
        }

        public bool LoginUsuario(string username, string password)
        {
            return mapper.LoginUsuario(username, password);
        }

        public void ExportarXML()
        {
            mapper.ExportarXML();
        }

    }
}
