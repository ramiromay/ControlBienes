using AutoMapper;
using ControlBienes.Data.Contrats.Almacen;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Almacen.Movimiento;
using ControlBienes.Entities.Almacen.MovimientoBien;
using ControlBienes.Entities.Patrimonio.Solicitud;
using ControlBienes.Entities.Seguridad.UsuarioPermiso;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Repository.Almacen
{
	public class DatMovimiento : DatProyeccion<EntMovimiento>, IDatMovimiento
	{
		public DatMovimiento(AppDbContext context, ILogger<Dat<EntMovimiento>> logger, IMapper mapper) : base(context, logger, mapper)
		{
		}

		public async Task<int> DActualizarArticulosAsync(long idMovimiento, List<long> idsArtculos)
		{
			idsArtculos = idsArtculos.Distinct().ToList();
			var articulosMovimiento = await _context.MovimientosBienes
				.AsNoTracking()
				.Where(u => u.iIdMovimiento == idMovimiento)
				.ToListAsync();

			var articulosActuales = articulosMovimiento.Select(up => up.iIdBms).ToList();
			var articulosEliminar = articulosMovimiento
				.Where(up => !idsArtculos.Contains(up.iIdBms.Value))
				.ToList();

			_context.MovimientosBienes.RemoveRange(articulosEliminar);

			var articulosAgregar = idsArtculos
				.Where(id => !articulosActuales.Contains(id))
				.Select(id => new EntMovimientoBien
				{
					iIdMovimiento = idMovimiento,
					iIdBms = id
				}).ToList();

			_context.MovimientosBienes.AddRange(articulosAgregar);
			return await _context.SaveChangesAsync();
		}

		public async Task<int> DAsignarArticulosAMovimientoAsync(long idMovimiento, List<long> idsArticulos)
		{
			idsArticulos = idsArticulos.Distinct().ToList();
			var articulosAgregar = idsArticulos.Select(id => new EntMovimientoBien
			{
				iIdMovimiento = idMovimiento,
				iIdBms = id
			}).ToList();

			await _context.MovimientosBienes.AddRangeAsync(articulosAgregar);
			return await _context.SaveChangesAsync();
		}

		public async Task<double> DObtenerImporteTotalAsync(List<long> idsArticulos)
		{
			var articulo = await _context.Bms
					.AsNoTracking()
					.Where(u => idsArticulos.Contains(u.iIdBms))
					.ToListAsync();
			return articulo.Sum(u => u.dPrecioUnitario);
		}

		public async Task<int> DCambiarEtapaAsync(EntMovimiento entity, long idEtapaSiguiente)
		{
			entity.iIdEtapa = idEtapaSiguiente;
			return await base.DActualizarAsync(entity);
		}

		
	}
}
