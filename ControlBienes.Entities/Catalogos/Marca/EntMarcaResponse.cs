namespace ControlBienes.Entities.Catalogos.Marca
{
    public class EntMarcaResponse
    {
        public long? IdMarca { get; set; } = null;
        public string? Nombre { get; set; } = null;
        public string? Observaciones { get; set; } = null;
        public bool? Activo { get; set; } = null;
        public DateTime? FechaCreacion { get; set; } = null;
        public DateTime? FechaModificacion { get; set; } = null;
    }
}
