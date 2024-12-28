namespace ControlBienes.Entities.Catalogos.EstadoGeneral
{
    public class EntEstadoGeneralResponse
    {
        public long? IdEstadoGeneral { get; set; } = null;
        public string? Nombre { get; set; } = null;
        public bool? Activo { get; set; } = null;
        public DateTime? FechaCreacion { get; set; } = null;
        public DateTime? FechaModificacion { get; set; } = null;
    }
}
