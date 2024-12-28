namespace ControlBienes.Entities.Catalogos.OrigenValor
{
    public class EntOrigenValorResponse
    {
        public long? IdOrigenValor { get; set; } = null;
        public string? Origen { get; set; } = null;
        public string? Descripcion { get; set; } = null;
        public bool? Activo { get; set; } = null;
        public DateTime? FechaCreacion { get; set; } = null;
        public DateTime? FechaModificacion { get; set; } = null;
    }
}
