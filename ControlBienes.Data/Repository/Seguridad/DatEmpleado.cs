using AutoMapper;
using ControlBienes.Data.Contrats;
using ControlBienes.Data.Contrats.Seguridad;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Seguridad.Empleado;
using Microsoft.Extensions.Logging;

namespace ControlBienes.Data.Repository.Seguridad
{
	public class DatEmpleado : DatCatalogoProyeccion<EntEmpleado>, IDatEmpleado
	{
		public DatEmpleado(AppDbContext context, ILogger<Dat<EntEmpleado>> logger, IMapper mapper, IDatCatalogoGenerico<EntEmpleado> repositorio) : base(context, logger, mapper, repositorio)
		{
		}
	}
}
