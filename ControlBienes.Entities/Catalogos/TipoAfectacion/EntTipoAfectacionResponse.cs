namespace ControlBienes.Entities.Catalogos.TipoAfectacion
{
    public class EntTipoAfectacionResponse
    {
        public long? IdTipoAfectacion { get; set; } = null;
        public string? Nombre { get; set; } = null;
        public bool? Activo { get; set; } = null;
        public DateTime? FechaCreacion { get; set; } = null;
        public DateTime? FechaModificacion { get; set; } = null;
    }
}
