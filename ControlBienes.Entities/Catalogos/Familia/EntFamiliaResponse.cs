namespace ControlBienes.Entities.Catalogos.Familia
{
    public class EntFamiliaResponse
    {
        public long? IdFamilia { get; set; } = null;
        public string? Nombre { get; set; } = null;
        public string? Descripcion { get; set; } = null;
        public int? NumeroCuenta { get; set; } = null;
        public long? IdTipoBien { get; set; } = null;
        public string? TipoBien { get; set; } = null;
        public bool? Activo { get; set; } = null;
        public DateTime? FechaCreacion { get; set; } = null;
        public DateTime? FechaModificacion { get; set; } = null;
    }
}
