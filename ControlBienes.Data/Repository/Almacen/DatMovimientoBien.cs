using AutoMapper;
using ControlBienes.Data.Contrats.Almacen;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Almacen.MovimientoBien;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Repository.Almacen
{
	public class DatMovimientoBien : DatProyeccion<EntMovimientoBien>, IDatMovimientoBien
	{
		public DatMovimientoBien(AppDbContext context, ILogger<Dat<EntMovimientoBien>> logger, IMapper mapper) : base(context, logger, mapper)
		{
		}

		
	}
}
