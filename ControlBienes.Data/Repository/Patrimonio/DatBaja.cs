using AutoMapper;
using ControlBienes.Data.Contrats.Patrimonio;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Patrimonio.Baja;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Repository.Patrimonio
{
	public class DatBaja : DatProyeccion<EntBaja>, IDatBaja
	{
		public DatBaja(AppDbContext context, ILogger<Dat<EntBaja>> logger, IMapper mapper) : base(context, logger, mapper)
		{
		}
	}
}
