using ControlBienes.Entities.Almacen.EtapaMovimiento;
using ControlBienes.Entities.Almacen.Movimiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Contrats.Almacen
{
	public interface IDatEtapaMovimiento : IDatProyeccion<EntEtapaMovimiento>
	{
		Task<bool> DValidarCambioEtapaAsync(EntMovimiento entidad, long idEtapa);
	}
}
