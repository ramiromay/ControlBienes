using AutoMapper;
using ControlBienes.Data.Contrats.Seguridad;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Seguridad.Permiso;
using Microsoft.Extensions.Logging;

namespace ControlBienes.Data.Repository.Seguridad
{
	public class DatPermiso : DatProyeccion<EntPermiso>, IDatPermiso
	{
		public DatPermiso(AppDbContext context, ILogger<Dat<EntPermiso>> logger, IMapper mapper) : base(context, logger, mapper)
		{
		}
	}
}
