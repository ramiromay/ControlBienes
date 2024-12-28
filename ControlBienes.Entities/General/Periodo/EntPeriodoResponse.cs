namespace ControlBienes.Entities.General.Periodo
{
    public class EntPeriodoResponse
    {
        public long IdPeriodo { get; set; } = 0;
        public int Anio { get; set; } = 0;
        public DateTime? FechaInicio { get; set; } = null;
        public DateTime? FechaFinal { get; set; } = null;
    }
}
