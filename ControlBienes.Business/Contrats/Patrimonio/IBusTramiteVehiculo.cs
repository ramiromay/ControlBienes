using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Patrimonio.DetalleAlta;
using ControlBienes.Entities.Patrimonio.DetalleBaja;
using ControlBienes.Entities.Patrimonio.DetalleDesincorporacion;
using ControlBienes.Entities.Patrimonio.DetalleDestinoFinal;
using ControlBienes.Entities.Patrimonio.DetalleModificacion;
using ControlBienes.Entities.Patrimonio.DetalleMovimiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Contrats.Patrimonio
{
	public interface IBusTramiteVehiculo
	{
	
		Task<EntityResponse<int>> BCrearTramiteAltaAsync(EntDetalleAltaVehiculoRequest request);
		Task<EntityResponse<int>> BActualizarTramiteAltaAsync(long idDetalleSolicitu, EntDetalleAltaVehiculoRequest request);
		Task<EntityResponse<EntDetalleAltaVehiculoResponse>> BObtenerTramiteAltaAsync(long idDetalleSolicitu);

		Task<EntityResponse<int>> BCrearTramiteModificacionAsync(EntDetalleModificacionVehiculoRequest request);
		Task<EntityResponse<int>> BActualizarTramiteModificacionAsync(long idDetalleSolicitu, EntDetalleModificacionVehiculoRequest request);
		Task<EntityResponse<EntDetalleModificacionVehiculoResponse>> BObtenerTramiteModificacionAsync(long idDetalleSolicitu);

		Task<EntityResponse<int>> BCrearTramiteBajaAsync(EntDetalleBajaVehiculoRequest request);
		Task<EntityResponse<int>> BActualizarTramiteBajaAsync(long idDetalleSolicitud, EntDetalleBajaVehiculoRequest request);
		Task<EntityResponse<EntDetalleBajaVehiculoResponse>> BObtenerTramiteBajaAsync(long idDetalleSolicitud);

		Task<EntityResponse<int>> BCrearTramiteMovimientoAsync(EntDetalleMovimientoVehiculoRequest request);
		Task<EntityResponse<int>> BActualizarTramiteMovimientoAsync(long idDetalleSolicitud, EntDetalleMovimientoVehiculoRequest request);
		Task<EntityResponse<EntDetalleMovimientoVehiculoResponse>> BObtenerTramiteMovimientoAsync(long idDetalleSolicitud);

		Task<EntityResponse<int>> BCrearTramiteDesincorporacionAsync(EntDetalleDesincorporacionVehiculoRequest request);
		Task<EntityResponse<int>> BActualizarTramiteDesincorporacionAsync(long idDetalleSolicitud, EntDetalleDesincorporacionVehiculoRequest request);
		Task<EntityResponse<EntDetalleDesincorporacionVehiculoResponse>> BObtenerTramiteDesincorporacionAsync(long idDetalleSolicitud);

		Task<EntityResponse<int>> BCrearTramiteDestinoFinalAsync(EntDetalleDestinoFinalVehiculoRequest request);
		Task<EntityResponse<int>> BActualizarTramiteDestinoFinalAsync(long idDetalleSolicitud, EntDetalleDestinoFinalVehiculoRequest request);
		Task<EntityResponse<EntDetalleDestinoFinalVehiculoResponse>> BObtenerTramiteDestinoFinalAsync(long idDetalleSolicitud);

		Task<EntityResponse<int>> BCambiarEtapaTramiteAsync(long idDetalleSolicitud, long? etapa);
	}
}
