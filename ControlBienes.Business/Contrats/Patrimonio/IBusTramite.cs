using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Patrimonio.Etapa;

namespace ControlBienes.Business.Contrats.Patrimonio
{
	public interface IBusTramite
	{
		Task<EntityResponse<IEnumerable<EntEtapaResponse>>> BObtenerEtapasPorTramiteAsync(long? idTramite);
		Task<EntityResponse<bool>> BTramitePermiteModificacionAsync(long idTramite);
	}
}
