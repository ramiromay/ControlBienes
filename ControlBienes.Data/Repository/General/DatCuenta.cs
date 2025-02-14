using AutoMapper;
using ControlBienes.Data.Contrats.General;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.General.Cuenta;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Repository.General
{
	public class DatCuenta : DatProyeccion<EntCuenta>, IDatCuenta
	{
		public DatCuenta(AppDbContext context, ILogger<Dat<EntCuenta>> logger, IMapper mapper) : base(context, logger, mapper)
		{
		}
	}
}
