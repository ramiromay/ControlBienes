using AutoMapper;
using ControlBienes.Data.Contrats.Patrimonio;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Patrimonio.DatoRegistral;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Repository.Patrimonio
{
	public class DatDatoRegistral : DatProyeccion<EntDatoRegistral>, IDatDatoRegistral
	{
		public DatDatoRegistral(AppDbContext context, ILogger<Dat<EntDatoRegistral>> logger, IMapper mapper) : base(context, logger, mapper)
		{
		}
	}
}
