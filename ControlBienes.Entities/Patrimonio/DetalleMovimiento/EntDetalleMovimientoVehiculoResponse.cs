using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Entities.Patrimonio.DetalleMovimiento
{
	public class EntDetalleMovimientoVehiculoResponse
	{
		public long? IdSolicitud { get; set; }

		public string NivelUnidadAdministrativa { get; set; }

		public string FolioBien { get; set; }

		public string NivelNuevaUnidadAdministrativa { get; set; }

		public long? IdMunicipio { get; set; }

		public long? IdUbicacion { get; set; }

		public string Responsable { get; set; }
	}
}
