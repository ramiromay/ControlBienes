using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Contrats.Seguridad
{
	public interface IBusIdentityAccess
	{
		public long BObtenerIdUsuario();
		public long BObtenerIdUsuario(string token);
	}
}
