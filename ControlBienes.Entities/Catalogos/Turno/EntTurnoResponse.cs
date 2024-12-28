namespace ControlBienes.Entities.Catalogos.Turno
{
    public class EntTurnoResponse
    {
        public long? IdTurno { get; set; } = null;
        public string? Nombre { get; set; } = null;
        public bool? Activo { get; set; } = null;
        public DateTime? FechaCreacion { get; set; } = null;
        public DateTime? FechaModificacion { get; set; } = null;
    }
}
