using ControlBienes.Entities.Seguridad.UsuarioRol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Contrats.Seguridad
{
	public interface IDatUsuarioRol :IDat<EntUsuarioRol>
	{
		Task<int> DActualizarRolesUsuarioAsync(long idUsuario, List<long> nuevosRolesIds);
		Task<int> DCrearRolesUsuarioAsync(long idUsuario, List<long> nuevosRolesIds);
	}
}
