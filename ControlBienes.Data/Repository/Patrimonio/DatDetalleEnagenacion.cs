using AutoMapper;
using ControlBienes.Data.Contrats.Patrimonio;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Patrimonio.DestinoFinal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Repository.Patrimonio
{
	public class DatDetalleEnagenacion : DatProyeccion<EntDetalleEnagenacion>, IDatDetalleEnagenacion
	{
		public DatDetalleEnagenacion(AppDbContext context, ILogger<Dat<EntDetalleEnagenacion>> logger, IMapper mapper) : base(context, logger, mapper)
		{
		}
	}
}
