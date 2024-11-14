namespace BE
{
    public class Usuario
    {
        private int _idUsuario;
        public int IdUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }

        private string _nombreUsuario;
        public string NombreUsuario
        {
            get { return _nombreUsuario; }
            set { _nombreUsuario = value; }
        }

        private string _contraseña;
        public string Contraseña
        {
            get { return _contraseña; }
            set { _contraseña = value; }
        }

        private string _rol;
        public string Rol
        {
            get { return _rol; }
            set { _rol = value; }
        }
    }
}
