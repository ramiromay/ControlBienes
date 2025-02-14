using AutoMapper;
using ControlBienes.Data.Contrats;
using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Catalogos.ConceptoMovimiento;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Repository.Catalogos
{
	public class DatConceptoMovimiento : DatCatalogoProyeccion<EntConceptoMovimiento>, IDatConceptoMovimiento
	{
		public DatConceptoMovimiento(AppDbContext context, ILogger<Dat<EntConceptoMovimiento>> logger, IMapper mapper, IDatCatalogoGenerico<EntConceptoMovimiento> repositorio) : base(context, logger, mapper, repositorio)
		{
		}
	}
}
