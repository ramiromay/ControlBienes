namespace ControlBienes.Entities.Catalogos.UsoInmueble
{
    public class EntUsoInmuebleResponse
    {
        public long? IdUsoInmueble { get; set; } = null;
        public string? Nombre { get; set; } = null;
        public bool? Activo { get; set; } = null;
        public DateTime? FechaCreacion { get; set; } = null;
        public DateTime? FechaModificacion { get; set; } = null;
    }
}
