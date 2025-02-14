using AutoMapper;
using ControlBienes.Data.Contrats.Patrimonio;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Patrimonio.Bien;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Repository.Patrimonio
{
	public class DatBienPatrimonio : DatProyeccion<EntBienPatrimonio>, IDatBienPatrimonio
	{
		public DatBienPatrimonio(AppDbContext context, ILogger<Dat<EntBienPatrimonio>> logger, IMapper mapper) : base(context, logger, mapper)
		{
		}
	}
}
