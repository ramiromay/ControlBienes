using AutoMapper;
using ControlBienes.Data.Contrats.Seguridad;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Seguridad.Rol;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Repository.Seguridad
{
	public class DatRol : DatProyeccion<EntRol>, IDatRol
	{
		public DatRol(AppDbContext context, ILogger<Dat<EntRol>> logger, IMapper mapper) : base(context, logger, mapper)
		{
		}
	}
}
