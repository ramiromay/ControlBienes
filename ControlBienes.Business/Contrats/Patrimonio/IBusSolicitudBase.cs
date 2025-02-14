using ControlBienes.Business.Genericos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Contrats.Patrimonio
{
	public interface IBusSolicitudBase<TRequest, TResponse>
		where TRequest : class
		where TResponse : class
	{
		Task<EntityResponse<int>> BCrearSolicitudAsync(TRequest request);
		Task<EntityResponse<int>> BActualizarSolicitudAsync(long idSolicitud, TRequest request);
		Task<EntityResponse<int>> BCambiarEtapaSolicitudAsync(long idSolicitud, long? etapa);
		Task<EntityResponse<IEnumerable<TResponse>>> BObtenerSolicitudesPorFiltroAsync(
			long? periodo,
			bool? busquedaPorFecha,
			DateTime? fechaInicio,
			DateTime? fechaFin,
			string unidadAdministrativa);
		Task<EntityResponse<TResponse>> BObtenerSolicitudAsync(long idSolicitud);
	}
}
