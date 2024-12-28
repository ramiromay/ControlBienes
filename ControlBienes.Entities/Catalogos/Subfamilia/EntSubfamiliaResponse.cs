namespace ControlBienes.Entities.Catalogos.Subfamilia
{
    public class EntSubfamiliaResponse
    {
        public long? IdSubfamilia { get; set; } = null;
        public string? Nombre { get; set; } = null;
        public long? IdFamilia { get; set; } = null;
        public string? Familia { get; set; } = null;
        public string? Descripcion { get; set; } = null;
        public int? NumeroCuenta { get; set; } = null;
        public double? ValorRecuperable { get; set; } = null;
        public bool? Activo { get; set; } = null;
        public DateTime? FechaCreacion { get; set; } = null;
        public DateTime? FechaModificacion { get; set; } = null;
    }
}
