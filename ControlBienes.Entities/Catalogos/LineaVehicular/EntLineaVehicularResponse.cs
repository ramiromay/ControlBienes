using System.Text.Json.Serialization;

namespace ControlBienes.Entities.Catalogos.LineaVehicular
{
    public class EntLineaVehicularResponse
    {
        public long? IdLineaVehicular { get; set; } = null;
        public string? Nombre { get; set; } = null;
        public string? Descripcion { get; set; } = null;
        public bool? Activo { get; set; } = null;
        public DateTime? FechaCreacion { get; set; } = null;
        public DateTime? FechaModificacion { get; set; } = null;
    }
}
