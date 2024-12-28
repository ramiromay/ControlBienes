namespace ControlBienes.Entities.Catalogos.TipoBien
{
    public class EntTipoBienResponse
    {
        public long? IdTipoBien { get; set; } = null;
        public string? Nombre { get; set; } = null;
        public bool? Activo { get; set; } = null;
        public DateTime? FechaCreacion { get; set; } = null;
        public DateTime? FechaModificacion { get; set; } = null; 
    }
}
