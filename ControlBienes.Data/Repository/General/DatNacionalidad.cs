using AutoMapper;
using ControlBienes.Data.Contrats.General;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.General.Nacionalidad;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Repository.General
{
	public class DatNacionalidad : DatProyeccion<EntNacionalidad>, IDatNacionalidad
	{
		public DatNacionalidad(AppDbContext context, ILogger<Dat<EntNacionalidad>> logger, IMapper mapper) : base(context, logger, mapper)
		{
		}
	}
}
