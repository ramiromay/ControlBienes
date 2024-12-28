namespace ControlBienes.Entities.Catalogos.ClaveVehicular
{
    public class EntClaveVehicularResponse
    {
        public long? IdClaveVehicular { get; set; } = null;
        public string? Nombre { get; set; } = null;
        public string? Descripcion { get; set; } = null;
        public bool? Activo { get; set; } = null;
        public DateTime? FechaCreacion { get; set; } = null;
        public DateTime? FechaModificacion { get; set; } = null;
    }
}
