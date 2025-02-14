using AutoMapper;
using ControlBienes.Data.Contrats.Patrimonio;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Patrimonio.Afectacion;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Repository.Patrimonio
{
	public class DatAfectacion : DatProyeccion<EntAfectacion>, IDatAfectacion
	{
		public DatAfectacion(AppDbContext context, ILogger<Dat<EntAfectacion>> logger, IMapper mapper) : base(context, logger, mapper)
		{
		}
	}
}
