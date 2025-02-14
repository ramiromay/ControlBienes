using AutoMapper;
using ControlBienes.Data.Contrats;
using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Catalogos.MetodoAdquisicion;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Repository.Catalogos
{
	public class DatMetodoAdquisicion : DatCatalogoProyeccion<EntMetodoAdquisicion>, IDatMetodoAdquisicion
	{
		public DatMetodoAdquisicion(AppDbContext context, ILogger<Dat<EntMetodoAdquisicion>> logger, IMapper mapper, IDatCatalogoGenerico<EntMetodoAdquisicion> repositorio) : base(context, logger, mapper, repositorio)
		{
		}
	}
}
