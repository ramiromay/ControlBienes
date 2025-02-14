using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Almacen;
using ControlBienes.Entities.Almacen.MetodoCosteo;
using ControlBienes.Entities.Almacen.ProgramaOperativo;
using ControlBienes.Entities.Almacen.Proveedor;
using ControlBienes.Entities.Almacen.TipoMovimiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Contrats.Almacen
{
	public interface IBusAlmacenComplemento
	{
		Task<EntityResponse<IEnumerable<EntMetodoCosteoResponse>>> BObtenerMetodosCosteoAsync();
		Task<EntityResponse<IEnumerable<EntProgramaOperativoResponse>>> BObtenerProgramasOperativosAsync();
		Task<EntityResponse<IEnumerable<EntProveedorResponse>>> BObtenerProveedoresAsync();
		Task<EntityResponse<IEnumerable<EntTipoMovimientoResponse>>> BObtenerTiposMovimientosAsync();
	}
}
