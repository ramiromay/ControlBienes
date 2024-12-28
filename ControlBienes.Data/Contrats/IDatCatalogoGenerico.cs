using ControlBienes.Entities.Genericos;

namespace ControlBienes.Data.Contrats
{
	public interface IDatCatalogoGenerico<T> : IDat<T> where T : EntCatalogoGenerico
	{
		Task<int> DActualizarEstatusAsync(T entidad);
	}
}
