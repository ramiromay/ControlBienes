namespace ControlBienes.Entities.Catalogos.VersionVehicular
{
    public class EntVersionVehicularResponse
    {
        public long? IdVersionVehicular { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public bool? Activo { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
