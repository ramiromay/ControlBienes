using AutoMapper;
using ControlBienes.Data.Contrats.Almacen;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Almacen;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Repository.Almacen
{
	public class DatTipoMovimiento : DatProyeccion<EntTipoMovimiento>, IDatTipoMovimiento
	{
		public DatTipoMovimiento(AppDbContext context, ILogger<Dat<EntTipoMovimiento>> logger, IMapper mapper) : base(context, logger, mapper)
		{
		}
	}
}
