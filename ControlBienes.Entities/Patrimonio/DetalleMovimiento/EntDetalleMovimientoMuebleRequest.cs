using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Entities.Patrimonio.DetalleMovimiento
{
	public class EntDetalleMovimientoMuebleRequest
	{
		public long? IdSolicitud { get; set; } = 0;

		public string NivelUnidadAdministrativa { get; set; } = string.Empty;

		public string FolioBien { get; set; } = string.Empty;

		public string NivelNuevaUnidadAdministrativa { get; set; } = string.Empty;

		public long? IdMunicipio { get; set; } = 0;

		public long? IdUbicacion { get; set; } = 0;

		public string Responsable { get; set; } = string.Empty;

		public long? IdMotivoTramite { get; set; } = 0;
	}
}
