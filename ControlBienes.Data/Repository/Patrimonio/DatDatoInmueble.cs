using AutoMapper;
using ControlBienes.Data.Contrats.Patrimonio;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Patrimonio.DatoInmueble;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Repository.Patrimonio
{
	public class DatDatoInmueble : DatProyeccion<EntDatoInmueble>, IDatDatoInmueble
	{
		public DatDatoInmueble(AppDbContext context, ILogger<Dat<EntDatoInmueble>> logger, IMapper mapper) : base(context, logger, mapper)
		{
		}
	}
}
