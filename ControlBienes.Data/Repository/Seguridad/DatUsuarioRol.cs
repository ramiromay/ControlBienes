using ControlBienes.Data.Contrats.Seguridad;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Seguridad.UsuarioRol;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Repository.Seguridad
{
	public class DatUsuarioRol : Dat<EntUsuarioRol>, IDatUsuarioRol
	{
		public DatUsuarioRol(AppDbContext context, ILogger<Dat<EntUsuarioRol>> logger) : base(context, logger)
		{
		}

		public async Task<int> DActualizarRolesUsuarioAsync(long idUsuario, List<long> nuevosRolesIds)
		{
			nuevosRolesIds = nuevosRolesIds.Distinct().ToList();
			var rolesActuales = await _context.UsuariosRoles
				.AsNoTracking()
				.Where(ur => ur.UserId == idUsuario)
				.ToListAsync();

			var rolesAEliminar = rolesActuales
				.Where(ur => !nuevosRolesIds.Contains(ur.RoleId))
				.ToList();

			_context.UsuariosRoles.RemoveRange(rolesAEliminar);

			var rolesExistentesIds = rolesActuales.Select(ur => ur.RoleId).ToList();
			var rolesParaAgregar = nuevosRolesIds
				.Where(id => !rolesExistentesIds.Contains(id))
				.Select(id => new EntUsuarioRol
				{
					UserId = idUsuario,
					RoleId = id
				}).ToList();

			await _context.UsuariosRoles.AddRangeAsync(rolesParaAgregar);
			return await _context.SaveChangesAsync();
		}

		public async Task<int> DCrearRolesUsuarioAsync(long idUsuario, List<long> nuevosRolesIds)
		{
			nuevosRolesIds = nuevosRolesIds.Distinct().ToList();
			var rolesParaAgregar = nuevosRolesIds.Select(id => new EntUsuarioRol
			{
				UserId = idUsuario,
				RoleId = id
			}).ToList();

			await _context.UsuariosRoles.AddRangeAsync(rolesParaAgregar);
			return await _context.SaveChangesAsync();
		}
	}
}
