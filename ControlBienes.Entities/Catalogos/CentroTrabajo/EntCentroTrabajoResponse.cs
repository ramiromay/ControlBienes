namespace ControlBienes.Entities.Catalogos.CentroTrabajo
{
    public class EntCentroTrabajoResponse
    {
        public long IdCentroTrabajo { get; set; } = 0;
        public long IdPeriodo { get; set; } = 0;
        public string Clave { get; set; } = null;
        public string Nombre { get; set; } = null;
        public string Direccion { get; set; } = null;
        public long IdMunicipio { get; set; } = 0;
        public string Municipio { get; set; } = null;
        public long IdUnidadAdministrativa { get; set; } = 0;
        public string UnidadAdministrativa { get; set; } = null;
        public bool? Activo { get; set; } = null;
        public DateTime? FechaCreacion { get; set; } = null;
        public DateTime? FechaModificacion { get; set; } = null;
    }
}
