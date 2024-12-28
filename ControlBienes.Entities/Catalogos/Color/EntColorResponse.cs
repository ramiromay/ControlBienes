namespace ControlBienes.Entities.Catalogos.Color
{
    public class EntColorResponse
    {
        public long? IdColor { get; set; } = null;
        public string? Nombre { get; set; } = null;
        public string? CodigoRGB { get; set; } = null;
        public bool? Activo { get; set; } = null;
        public DateTime? FechaCreacion { get; set; } = null;
        public DateTime? FechaModificacion { get; set; } = null;
    }
}
