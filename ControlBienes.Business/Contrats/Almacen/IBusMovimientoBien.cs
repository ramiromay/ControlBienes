using Azure;
using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Almacen.Movimiento;
using ControlBienes.Entities.Almacen.MovimientoBien;
using ControlBienes.Entities.Patrimonio.Etapa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Contrats.Almacen
{
	public interface IBusMovimientoBien
	{
		Task<EntityResponse<int>> BCrearMovimientoAsync(EntMovimientoBienRequest request);
		Task<EntityResponse<int>> BActualizarMovimientoAsync(long idMovimiento, EntMovimientoBienRequest request);
		Task<EntityResponse<int>> BCambiarEtapaMovimientoAsync(long idMovimiento, long? etapa);
		Task<EntityResponse<IEnumerable<EntMovimientoBienResponse>>> BObtenerMovimientosPorFiltroAsync(
			long? periodo,
			bool? busquedaPorFecha,
			DateTime? fechaInicio,
			DateTime? fechaFin,
			long? almacen);
		Task<EntityResponse<EntMovimientoBienResponse>> BObtenerMovimientoAsync(long idMovimiento);
		Task<EntityResponse<IEnumerable<EntEtapaResponse>>> BObtenerEtapasPorMovimientoAsync(long? idMovimiento);
	}
}
