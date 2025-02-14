using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Patrimonio.Bien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Contrats.Patrimonio
{
	public interface IBusInventario
	{
		Task<EntityResponse<IEnumerable<EntBienPatrimonioResponse>>> BObtenerBienesInventarioAsync(long? idTipoBien, long? idDetalleSolicitud);

		Task<EntityResponse<IEnumerable<EntArticuloBienResponse>>> BObtenerArbolTiposBienesAsync(long? idTipoBien);

	}
}
