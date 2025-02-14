using AutoMapper;
using ControlBienes.Data.Contrats;
using ControlBienes.Data.Contrats.Catalogos;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Catalogos.Almacen;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Repository.Catalogos
{
	public class DatAlmacen : DatCatalogoProyeccion<EntAlmacen>, IDatAlmacen
	{
		public DatAlmacen(AppDbContext context, ILogger<Dat<EntAlmacen>> logger, IMapper mapper, IDatCatalogoGenerico<EntAlmacen> repositorio) : base(context, logger, mapper, repositorio)
		{
		}
	}
}
