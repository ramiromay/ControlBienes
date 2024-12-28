

namespace ControlBienes.Entities.Catalogos.Resguardante
{
    public class EntResguardanteRequest
    {
        public long? IdPeriodo { get; set; } = 0;
        public long? IdPersona { get; set; } = 0;
        public long? IdUnidadAdministrativa { get; set; } = 0;
        public string Observaciones { get; set; } = string.Empty;
        public int? NoConvenio { get; set; } = 0;
        public long? IdTipoResponsable { get; set; } = 0;
        public bool Responsable { get; set; } = false;
    }
}
