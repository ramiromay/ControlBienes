using ControlBienes.Entities.Catalogos.Familia;
using ControlBienes.Entities.Catalogos.Subfamilia;

namespace ControlBienes.Entities.Catalogos.CaracteristicaBien
{
    public class EntCaracteristicaBienResponse
    {
        public long? IdCaracteristicaBien { get; set; } = null;
        public long? IdFamilia { get; set; } = null;
        public string? Familia { get; set; } = null;
        public long? IdSubfamilia { get; set; } = null;
        public string? Subfamilia { get; set; } = null;
        public string? Etiqueta { get; set; } = null;
        public string? Descripcion { get; set; } = null;
        public bool? Activo { get; set; } = null;
        public DateTime? FechaCreacion { get; set; } = null;
        public DateTime? FechaModificacion { get; set; } = null;
    }
}
