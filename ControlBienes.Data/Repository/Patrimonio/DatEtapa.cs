using AutoMapper;
using ControlBienes.Data.Contrats.Patrimonio;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Patrimonio.Etapa;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Repository.Patrimonio
{
	public class DatEtapa : DatProyeccion<EntEtapa>, IDatEtapa
	{
		public DatEtapa(AppDbContext context, ILogger<Dat<EntEtapa>> logger, IMapper mapper) : base(context, logger, mapper)
		{
		}
	}
}
