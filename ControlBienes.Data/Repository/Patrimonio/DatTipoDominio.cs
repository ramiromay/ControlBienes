using AutoMapper;
using ControlBienes.Data.Contrats.Patrimonio;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Patrimonio.TipoDominio;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Repository.Patrimonio
{
	public class DatTipoDominio : DatProyeccion<EntTipoDominio>, IDatTipoDominio
	{
		public DatTipoDominio(AppDbContext context, ILogger<Dat<EntTipoDominio>> logger, IMapper mapper) : base(context, logger, mapper)
		{
		}
	}
}
