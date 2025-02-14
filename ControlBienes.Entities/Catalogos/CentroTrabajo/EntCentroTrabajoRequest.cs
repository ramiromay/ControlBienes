namespace ControlBienes.Entities.Catalogos.CentroTrabajo
{
    public class EntCentroTrabajoRequest
    {
        public long? IdPeriodo { get; set; } = null;
        public string Clave { get; set; } = null;
        public string Nombre { get; set; } = null;
        public string Direccion { get; set; } = null;
        public long? IdMunicipio { get; set; } = null;
        public string NivelUnidadAdministrativa { get; set; } = string.Empty;
    }
}
