using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Patrimonio.DetalleAlta;
using ControlBienes.Entities.Patrimonio.DetalleBaja;
using ControlBienes.Entities.Patrimonio.DetalleModificacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Contrats.Patrimonio
{
	public interface IBusTramiteInmueble
	{
		Task<EntityResponse<int>> BCrearTramiteAltaAsync(EntDetalleAltaInmuebleRequest request);
		Task<EntityResponse<int>> BActualizarTramiteAltaAsync(long idDetalleSolicitud, EntDetalleAltaInmuebleRequest request);
		Task<EntityResponse<EntDetalleAltaInmuebleResponse>> BObtenerTramiteAltaAsync(long idDetalleSolicitud);

		Task<EntityResponse<int>> BCrearTramiteModificacionAsync(EntDetalleModificacionInmuebleRequest request);
		Task<EntityResponse<int>> BActualizarTramiteModificacionAsync(long idDetalleSolicitud, EntDetalleModificacionInmuebleRequest request);
		Task<EntityResponse<EntDetalleModificacionInmuebleResponse>> BObtenerTramiteModificacionAsync(long idDetalleSolicitud);

		Task<EntityResponse<int>> BCrearTramiteBajaAsync(EntDetalleBajaInmuebleRequest request);
		Task<EntityResponse<int>> BActualizarTramiteBajaAsync(long idDetalleSolicitud, EntDetalleBajaInmuebleRequest request);
		Task<EntityResponse<EntDetalleBajaInmuebleResponse>> BObtenerTramiteBajaAsync(long idDetalleSolicitud);

		Task<EntityResponse<int>> BCambiarEtapaTramiteAsync(long idDetalleSolicitud, long? etapa);
	}
}
