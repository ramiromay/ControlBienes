using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Seguridad.Permiso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Contrats.Seguridad
{
	public interface IBusPermiso
	{
		Task<EntityResponse<IEnumerable<EntPermisoResponse>>> BObtenerTodosPermisoAsync();
	}
}
