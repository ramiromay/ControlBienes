using AutoMapper;
using ControlBienes.Data.Contrats.Patrimonio;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Patrimonio.DatoVehicular;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Repository.Patrimonio
{
	public class DatDatoVehicular : DatProyeccion<EntDatoVehicular>, IDatDatoVehicular
	{
		public DatDatoVehicular(AppDbContext context, ILogger<Dat<EntDatoVehicular>> logger, IMapper mapper) : base(context, logger, mapper)
		{
		}
	}
}
