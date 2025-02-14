using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Patrimonio.Etapa;

namespace ControlBienes.Business.Contrats.Patrimonio
{
	public interface IBusSolicitud
	{
		Task<EntityResponse<bool>> BSolicitudPermiteModificacionAsync(long idSolicitud);
		Task<EntityResponse<bool>> BSolicitudPermiteNuevosTramitesAsync(long idSolicitud);
		Task<EntityResponse<IEnumerable<EntEtapaResponse>>> BObtenerEtapasPorSolicitudAsync(long? idSolicitud);
		Task<EntityResponse<long>> BObtenerIDTipoTramitePorSolicitudAsync(long? idSolicitud);
	}
}
