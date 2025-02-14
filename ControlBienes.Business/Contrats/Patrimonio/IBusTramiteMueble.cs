using Azure;
using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Patrimonio.DetalleAlta;
using ControlBienes.Entities.Patrimonio.DetalleBaja;
using ControlBienes.Entities.Patrimonio.DetalleDesincorporacion;
using ControlBienes.Entities.Patrimonio.DetalleDestinoFinal;
using ControlBienes.Entities.Patrimonio.DetalleModificacion;
using ControlBienes.Entities.Patrimonio.DetalleMovimiento;
using ControlBienes.Entities.Patrimonio.DetalleSolicitud;
using ControlBienes.Entities.Patrimonio.Seguimiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Contrats.Patrimonio
{
	public interface IBusTramiteMueble
	{
		Task<EntityResponse<int>> BCrearTramiteAltaAsync(EntDetalleAltaMuebleRequest request);
		Task<EntityResponse<int>> BActualizarTramiteAltaAsync(long idDetalleSolicitu, EntDetalleAltaMuebleRequest request);
		Task<EntityResponse<EntDetalleAltaMuebleResponse>> BObtenerTramiteAltaAsync(long idDetalleSolicitu);

		Task<EntityResponse<int>> BCrearTramiteModificacionAsync(EntDetalleModificacionMuebleRequest request);
		Task<EntityResponse<int>> BActualizarTramiteModificacionAsync(long idDetalleSolicitu, EntDetalleModificacionMuebleRequest request);
		Task<EntityResponse<EntDetalleModificacionMuebleResponse>> BObtenerTramiteModificacionAsync(long idDetalleSolicitu);
		Task<EntityResponse<int>> BCrearTramiteBajaAsync(EntDetalleBajaMuebleRequest request);
		Task<EntityResponse<int>> BActualizarTramiteBajaAsync(long idDetalleSolicitud, EntDetalleBajaMuebleRequest request);
		Task<EntityResponse<EntDetalleBajaMuebleResponse>> BObtenerTramiteBajaAsync(long idDetalleSolicitud);

		Task<EntityResponse<int>> BCrearTramiteMovimientoAsync(EntDetalleMovimientoMuebleRequest request);
		Task<EntityResponse<int>> BActualizarTramiteMovimientoAsync(long idDetalleSolicitud, EntDetalleMovimientoMuebleRequest request);
		Task<EntityResponse<EntDetalleMovimientoMuebleResponse>> BObtenerTramiteMovimientoAsync(long idDetalleSolicitud);

		Task<EntityResponse<int>> BCrearTramiteDesincorporacionAsync(EntDetalleDesincorporacionMuebleRequest request);
		Task<EntityResponse<int>> BActualizarTramiteDesincorporacionAsync(long idDetalleSolicitud, EntDetalleDesincorporacionMuebleRequest request);
		Task<EntityResponse<EntDetalleDesincorporacionMuebleResponse>> BObtenerTramiteDesincorporacionAsync(long idDetalleSolicitud);

		Task<EntityResponse<int>> BCrearTramiteDestinoFinalAsync(EntDetalleDestinoFinalMuebleRequest request);
		Task<EntityResponse<int>> BActualizarTramiteDestinoFinalAsync(long idDetalleSolicitud, EntDetalleDestinoFinalMuebleRequest request);
		Task<EntityResponse<EntDetalleDestinoFinalMuebleResponse>> BObtenerTramiteDestinoFinalAsync(long idDetalleSolicitud);

		Task<EntityResponse<IEnumerable<EntDetalleSolicitudResponse>>> BObtenerTramitesPorSolicitudAsync(long idSolicitud);
		Task<EntityResponse<int>> BCambiarEtapaTramiteAsync(long idDetalleSolicitu, long? etapa);
		Task<EntityResponse<IEnumerable<EntSeguimientoResponse>>> BObtenerSeguimientoTramiteAsync(long idDetalleSolicitud);

	}
}
