using ControlBienes.Entities.Catalogos.Familia;
using ControlBienes.Entities.Catalogos.Subfamilia;

namespace ControlBienes.Entities.General.BMS
{
    public class EntBMSResponse
    {
        public long? IdBMS { get; set; } = null;
        public string? Nombre { get; set; } = null;
        public long? IdFamilia { get; set; } = null;
        public long? IdSubfamilia { get; set; } = null;
        public decimal? CodigoArmonizado { get; set; } = null;
        public double? PrecioUnitario { get; set; }

	}
}
