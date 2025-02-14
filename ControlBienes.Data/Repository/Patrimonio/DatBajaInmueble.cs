using AutoMapper;
using ControlBienes.Data.Contrats.Patrimonio;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Patrimonio.BajaInmueble;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Repository.Patrimonio
{
	public class DatBajaInmueble : DatProyeccion<EntBajaInmueble>, IDatBajaInmueble
	{
		public DatBajaInmueble(AppDbContext context, ILogger<Dat<EntBajaInmueble>> logger, IMapper mapper) : base(context, logger, mapper)
		{
		}
	}
}
