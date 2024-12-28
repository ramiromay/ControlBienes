namespace ControlBienes.Entities.Catalogos.TipoAdquisicion
{
    public class EntTipoAdquisicionResponse
    {
        public long? IdTipoAdquisicion { get; set; } = null;
        public string? Nombre { get; set; } = null;
        public bool? Activo { get; set; } = null;
        public DateTime? FechaCreacion { get; set; } = null;
        public DateTime? FechaModificacion { get; set; } = null;
    }
}
