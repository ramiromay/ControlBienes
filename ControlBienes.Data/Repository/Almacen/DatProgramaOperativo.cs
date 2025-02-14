using AutoMapper;
using ControlBienes.Data.Contrats.Almacen;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Almacen.ProgramaOperativo;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Repository.Almacen
{
	public class DatProgramaOperativo : DatProyeccion<EntProgramasOperativo>, IDatProgramaOperativo
	{
		public DatProgramaOperativo(AppDbContext context, ILogger<Dat<EntProgramasOperativo>> logger, IMapper mapper) : base(context, logger, mapper)
		{
		}
	}
}
