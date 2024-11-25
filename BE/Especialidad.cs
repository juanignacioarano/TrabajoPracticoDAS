using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
	public class Especialidad
	{
		private int _idEspecialidad;

		public int IdEspecialidad
		{
			get { return _idEspecialidad; }
			set { _idEspecialidad = value; }
		}

		private string _descripcion;
		public string Descripcion
		{
			get { return _descripcion; }
			set { _descripcion = value; }
		}

		//private bool activo;

		//public bool Activo
		//{
		//	get { return activo; }
		//	set { activo = value; }
		//}

	}

}
