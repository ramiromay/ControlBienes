using ControlBienes.Business.Genericos;
using ControlBienes.Entities.Patrimonio.TipoDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Business.Contrats.Patrimonio
{
	public interface IBusTipoDominio
	{
		Task<EntityResponse<IEnumerable<EntTipoDominioResponse>>> BObtenerTiposDominioAsync();
	}
}
