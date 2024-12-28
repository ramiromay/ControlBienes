namespace ControlBienes.Entities.Catalogos.ClaseVehicular
{
    public class EntClaseVehicularResponse
    {
        public long? IdClaseVehicular { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public bool? Activo { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
