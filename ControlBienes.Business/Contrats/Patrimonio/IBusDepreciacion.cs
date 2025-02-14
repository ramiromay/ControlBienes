using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Patrimonio.Depreciacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Contrats.Patrimonio
{
	public interface IBusDepreciacion
	{
		Task<EntityResponse<EntResumenDepreciacionResponse>> BDepreciarBienes(long? periodo, long? mes, long? tipoBien, long? tipoDepreciacion, string unidadAdministrativa, string folioBien);
		Task<EntityResponse<IEnumerable<EntDepreciacionResponse>>> BObtenerDepreciacionPorBienAsync(long idBien);
	}
}
