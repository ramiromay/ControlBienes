namespace ControlBienes.Entities.Catalogos.Ubicacion
{
    public class EntUbicacionResponse
    {
        public long? IdUbicacion { get; set; } = null;
        public string? Descripcion { get; set; } = null;
        public bool? Activo { get; set; } = null;
        public DateTime? FechaCreacion { get; set; } = null;
        public DateTime? FechaModificacion { get; set; } = null;
    }
}
