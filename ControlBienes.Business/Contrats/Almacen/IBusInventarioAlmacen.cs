using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Almacen.Bien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Contrats.Almacen
{
	public interface IBusInventarioAlmacen
	{
		Task<EntityResponse<IEnumerable<EntBienAlmacenResponse>>> BObtenerBienesPorFiltroAsync(
			long? periodo,
			long? almacen,
			bool? busquedaPorFecha,
			DateTime? fechaInicio,
			DateTime? fechaFin
			);

		Task<EntityResponse<EntBienAlmacenResponse>> BObtenerBienPorIdAsync(long idBien);
	}
}
