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
	public class DatDetalleDestinoFinal : DatProyeccion<EntDetalleDestinoFinal>, IDatDetalleDestinoFinal
	{
		public DatDetalleDestinoFinal(AppDbContext context, ILogger<Dat<EntDetalleDestinoFinal>> logger, IMapper mapper) : base(context, logger, mapper)
		{
		}
	}
}
