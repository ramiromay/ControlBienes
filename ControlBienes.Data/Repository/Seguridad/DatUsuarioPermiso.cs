using ControlBienes.Data.Contrats.Seguridad;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Seguridad.UsuarioPermiso;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Repository.Seguridad
{
    public class DatUsuarioPermiso : Dat<EntUsuarioPermiso>, IDatUsuarioPermiso
    {
        public DatUsuarioPermiso(AppDbContext context, ILogger<Dat<EntUsuarioPermiso>> logger) : base(context, logger)
        {
        }

		public async Task<int> DActualizarPermisosUsuarioAsync(long idUsuario, List<long> nuevosPermisosIds)
		{
			nuevosPermisosIds = nuevosPermisosIds.Distinct().ToList();
			var usuarioPermisos = await _context.UsuariosPermisos
				.AsNoTracking()
				.Where(u => u.iIdUsuario == idUsuario)
				.ToListAsync();

			var permisosActualesIds = usuarioPermisos.Select(up => up.iIdPermiso).ToList();
			var permisosParaEliminar = usuarioPermisos
				.Where(up => !nuevosPermisosIds.Contains(up.iIdPermiso))
				.ToList();

			_context.UsuariosPermisos.RemoveRange(permisosParaEliminar);

			var permisosParaAgregar = nuevosPermisosIds
				.Where(id => !permisosActualesIds.Contains(id))
				.Select(id => new EntUsuarioPermiso
				{
					iIdUsuario = idUsuario,
					iIdPermiso = id
				}).ToList();

			_context.UsuariosPermisos.AddRange(permisosParaAgregar);
			return await _context.SaveChangesAsync();
		}

		public async Task<int> DCrearPermisosUsuariosAsync(long idUsuario, List<long> nuevosPermisosIds)
		{
			nuevosPermisosIds = nuevosPermisosIds.Distinct().ToList();
			var permisosParaAgregar = nuevosPermisosIds.Select(id => new EntUsuarioPermiso
			{
				iIdUsuario = idUsuario,
				iIdPermiso = id
			}).ToList();

			await _context.UsuariosPermisos.AddRangeAsync(permisosParaAgregar);
			return await _context.SaveChangesAsync();
		}

	}
}
