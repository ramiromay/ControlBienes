using ControlBienes.Entities.Patrimonio.DetalleSolicitud;

namespace ControlBienes.Data.Contrats.Patrimonio
{
	public interface IDatDetalleSolicitud : IDatProyeccion<EntDetalleSolicitud>
	{
		Task<int> DCambiarEtapaAsync(long idDetalleSolicitud, long idEtapa);
	}
}
