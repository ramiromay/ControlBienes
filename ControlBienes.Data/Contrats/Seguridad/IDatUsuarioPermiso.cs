using ControlBienes.Entities.Seguridad.UsuarioPermiso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Contrats.Seguridad
{
    public interface IDatUsuarioPermiso : IDat<EntUsuarioPermiso>
    {
		Task<int> DActualizarPermisosUsuarioAsync(long idUsuario, List<long> nuevosPermisosIds);
		Task<int> DCrearPermisosUsuariosAsync(long idUsuario, List<long> nuevosPermisosIds);
	}
}
