using AutoMapper;
using ControlBienes.Data.Contrats.General;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.General.BMS;
using Microsoft.Extensions.Logging;

namespace ControlBienes.Data.Repository.General
{
	public class DatBms : DatProyeccion<EntBms>, IDatBms
	{
		public DatBms(AppDbContext context, ILogger<Dat<EntBms>> logger, IMapper mapper) : base(context, logger, mapper)
		{
		}
	}
}
