using AutoMapper;
using ControlBienes.Data.Contrats.Almacen;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Almacen.EtapaMovimiento;
using ControlBienes.Entities.Almacen.Movimiento;
using ControlBienes.Entities.Patrimonio.Solicitud;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Repository.Almacen
{
	public class DatEtapaMovimiento : DatProyeccion<EntEtapaMovimiento>, IDatEtapaMovimiento
	{
		public DatEtapaMovimiento(AppDbContext context, ILogger<Dat<EntEtapaMovimiento>> logger, IMapper mapper) : base(context, logger, mapper)
		{
		}
		public Task<bool> DValidarCambioEtapaAsync(EntMovimiento entidad, long idEtapa)
		{
			if (entidad == null) return Task.FromResult(false);
			return DExisteRegistroAsync(e =>
				e.iIdEtapaOrigen == entidad.iIdEtapa &&
				e.iIdEtapaDestino == idEtapa);
		}
	}
}
