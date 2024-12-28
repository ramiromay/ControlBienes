using ControlBienes.Entities.Genericos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Data.Contrats
{
	public interface IDatCatalogoProyeccion<T> : IDatCatalogoGenerico<T>, IDatProyeccion<T> where T : EntCatalogoGenerico
	{
	}
}
