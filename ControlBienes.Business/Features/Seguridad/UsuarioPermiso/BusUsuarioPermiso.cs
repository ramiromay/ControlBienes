using ControlBienes.Business.Contrats.Seguridad;
using ControlBienes.Data.Contrats.Seguridad;
using ControlBienes.Entities.Seguridad.Permiso;

namespace ControlBienes.Business.Features.Seguridad.UsuarioPermiso
{
	public class BusUsuarioPermiso : IBusUsuarioPermiso
	{
		private readonly IDatUsuarioPermiso _repositorio;

		public BusUsuarioPermiso(IDatUsuarioPermiso repositorio)
		{
			_repositorio = repositorio;
		}

		public async Task<bool> HasPermisoAsync(long idUsuario, EnumPermiso[] permisosRequeridos)
		{
			var usuarioPermitido = false;
			try
			{
				var idsPermisos = permisosRequeridos.Select(e => (long)e).ToList();
				var permisosUsuario = await _repositorio.DObtenerTodosAsync(predicado: e =>
				 e.iIdUsuario == idUsuario && idsPermisos.Contains(e.iIdPermiso));
				usuarioPermitido = permisosUsuario.Count > 0;
			}
			catch (Exception ex)
			{
				usuarioPermitido = false;

			}
			return usuarioPermitido;
		}
	
	}
}
