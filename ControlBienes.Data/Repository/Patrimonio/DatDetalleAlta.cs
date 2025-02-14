using AutoMapper;
using ControlBienes.Data.Contrats.Patrimonio;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Patrimonio.Alta;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Repository.Patrimonio
{
	public class DatDetalleAlta : DatProyeccion<EntDetalleAlta>, IDatDetalleAlta
	{
		public DatDetalleAlta(AppDbContext context, ILogger<Dat<EntDetalleAlta>> logger, IMapper mapper) : base(context, logger, mapper)
		{
		}
	}
}
