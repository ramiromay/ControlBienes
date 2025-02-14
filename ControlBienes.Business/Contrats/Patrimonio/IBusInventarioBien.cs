using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Patrimonio.Historial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Contrats.Patrimonio
{
	public interface IBusInventarioBien<T>
	{
		Task<EntityResponse<IEnumerable<T>>> BObtenerBienesPorFiltroAsync(
			long? periodo, 
			string unidadAdministrativa,
			bool? estadoBien,
			bool? busquedaPorTipoBien,
			long? idBusqueda, 
			long? nivelArticulo,
			bool? busquedaPorFecha,
			DateTime? fechaInicio,
			DateTime? fechaFin
			);

		Task<EntityResponse<T>> BObtenerBienPorIdAsync(long idBien);
		Task<EntityResponse<IEnumerable<EntHistorialReponse>>> BObtenerHistorialBienPorIdAsync(long idBien);

	}
}
