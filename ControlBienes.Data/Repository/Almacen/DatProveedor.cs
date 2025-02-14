using AutoMapper;
using ControlBienes.Data.Contrats.Almacen;
using ControlBienes.Data.Persistence;
using ControlBienes.Entities.Almacen.Proveedor;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Repository.Almacen
{
	public class DatProveedor : DatProyeccion<EntProveedor>, IDatProveedor
	{
		public DatProveedor(AppDbContext context, ILogger<Dat<EntProveedor>> logger, IMapper mapper) : base(context, logger, mapper)
		{
		}
	}
}
