using AutoMapper;
using ControlBienes.Data.Contrats.Patrimonio;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Patrimonio.Depreciacion;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Repository.Patrimonio
{
	public class DatDepreciacion : DatProyeccion<EntDepreciacion>, IDatDepreciacion
	{
		public DatDepreciacion(AppDbContext context, ILogger<Dat<EntDepreciacion>> logger, IMapper mapper) : base(context, logger, mapper)
		{
		}
	}
}
