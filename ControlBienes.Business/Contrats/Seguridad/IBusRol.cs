using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Seguridad.Rol;

namespace ControlBienes.Business.Contrats.Seguridad
{
	public interface IBusRol
	{
		Task<EntityResponse<IEnumerable<EntRolResponse>>> BObtenerTodosRolesAsync();
	}
}
