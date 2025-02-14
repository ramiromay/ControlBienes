using AutoMapper;
using ControlBienes.Data.Contrats.Patrimonio;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Patrimonio.Historial;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Repository.Patrimonio
{
	public class DatHistorial : DatProyeccion<EntHistorial>, IDatHistorial
	{
		public DatHistorial(AppDbContext context, ILogger<Dat<EntHistorial>> logger, IMapper mapper) : base(context, logger, mapper)
		{
		}
	}
}
