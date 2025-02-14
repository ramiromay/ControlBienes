using AutoMapper;
using ControlBienes.Data.Contrats.Patrimonio;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Patrimonio.Modificacion;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Repository.Patrimonio
{
	public class DatDetalleModificacion : DatProyeccion<EntDetalleModificacion>, IDatDetalleModificacion
	{
		public DatDetalleModificacion(AppDbContext context, ILogger<Dat<EntDetalleModificacion>> logger, IMapper mapper) : base(context, logger, mapper)
		{
		}
	}
}
