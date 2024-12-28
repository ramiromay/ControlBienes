using ControlBienes.Entities.Catalogos.Familia;
using ControlBienes.Entities.Catalogos.Subfamilia;

namespace ControlBienes.Entities.General.BMS
{
    public class EntBMSResponse
    {
        public long? iIdBMS { get; set; }
        public string? Nombre { get; set; }
        public EntFamilia? Familia { get; set; }
        public EntSubfamilia? Subfamilia { get; set; }
        public int? Cantidad { get; set; }
        public string? UnidadMedida { get; set; }
        public double? PrecioUnitario { get; set; }
        public decimal? nCodigoArmonizado { get; set; }
        public bool? Activo { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}
