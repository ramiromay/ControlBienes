using ControlBienes.Entities.Almacen.Movimiento;
using ControlBienes.Entities.Patrimonio.Solicitud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Contrats.Almacen
{
	public interface IDatMovimiento : IDatProyeccion<EntMovimiento>
	{
		Task<int> DActualizarArticulosAsync(long idMovimiento, List<long> idsArtculos);
		Task<int> DAsignarArticulosAMovimientoAsync(long idMovimiento, List<long> idsArticulos);
		Task<double> DObtenerImporteTotalAsync(List<long> idsArticulos);
		Task<int> DCambiarEtapaAsync(EntMovimiento entity, long idEtapaSiguiente);
	}
}
