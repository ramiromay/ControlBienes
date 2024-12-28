namespace ControlBienes.Entities.Catalogos.TipoInmueble
{
    public class EntTipoInmuebleResponse
    {
        public long? IdTipoInmueble { get; set; } = null;
        public string? Nombre { get; set; } = null;
        public string? Descripcion { get; set; } = null;
        public bool? Activo { get; set; } = null;
        public DateTime? FechaCreacion { get; set; } = null;
        public DateTime? FechaModificacion { get; set; } = null;
    }
}
