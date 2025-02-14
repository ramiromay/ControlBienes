using AutoMapper;
using ControlBienes.Data.Contrats.Patrimonio;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Patrimonio.Seguimiento;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Repository.Patrimonio
{
	public class DatSeguimiento : DatProyeccion<EntSeguimiento>, IDatSeguimiento
	{
		public DatSeguimiento(AppDbContext context, ILogger<Dat<EntSeguimiento>> logger, IMapper mapper) : base(context, logger, mapper)
		{
		}
	}
}
