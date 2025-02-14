using ControlBienes.Entities.Seguridad.Permiso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Contrats.Seguridad
{
	public interface IBusUsuarioPermiso
	{
		Task<bool> HasPermisoAsync(long idUsuario, EnumPermiso[] permisosRequeridos);
	}
}
