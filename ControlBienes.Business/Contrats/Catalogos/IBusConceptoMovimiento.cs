using ControlBienes.Business.Contrats.Catalogs;
using ControlBienes.Entities.Catalogos.ConceptoMovimiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Contrats.Catalogos
{
	public interface IBusConceptoMovimiento: IBusCatalogo<EntConceptoMovimientoRequest, EntConceptoMovimientoResponse>
	{
	}
}
