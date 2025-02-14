using AutoMapper;
using ControlBienes.Data.Contrats.Patrimonio;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Patrimonio.Desincorporacion;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Repository.Patrimonio
{
	public class DatDetalleDesincorporacion : DatProyeccion<EntDetalleDesincorporacion>, IDatDetalleDesincorporacion
	{
		public DatDetalleDesincorporacion(AppDbContext context, ILogger<Dat<EntDetalleDesincorporacion>> logger, IMapper mapper) : base(context, logger, mapper)
		{
		}
	}
}
