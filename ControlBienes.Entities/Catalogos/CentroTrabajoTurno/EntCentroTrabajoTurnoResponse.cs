namespace ControlBienes.Entities.Catalogos.CentroTrabajoTurno
{
    public class EntCentroTrabajoTurnoResponse
    {
        public long? IdCentroTrabajoTurno { get; set; } = null;
        public long? IdCentroTrabajo { get; set; } = null;
        public string CentroTrabajo { get; set; } = null;
        public long? IdTurno { get; set; } = null;
        public string Turno { get; set; } = null;
        public bool? Activo { get; set; } = null;
        public DateTime? FechaCreacion { get; set; } = null;
        public DateTime? FechaModificacion { get; set; } = null;
    }
}
