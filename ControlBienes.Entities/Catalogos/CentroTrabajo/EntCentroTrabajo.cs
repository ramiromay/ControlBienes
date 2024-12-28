using ControlBienes.Entities.Catalogos.CentroTrabajoTurno;
using ControlBienes.Entities.General.Municipio;
using ControlBienes.Entities.General.UnidadAdministrativa;
using ControlBienes.Entities.Genericos;


namespace ControlBienes.Entities.Catalogos.CentroTrabajo;

public partial class EntCentroTrabajo : EntCatalogoGenerico
{
    public long iIdCentroTrabajo { get; set; }

    public long iIdPeriodo { get; set; }

    public string sClave { get; set; }

    public string sNombre { get; set; }

    public string sDireccion { get; set; }

    public long iIdMunicipio { get; set; }

    public long iIdUnidadAdministrativa { get; set; }

    public virtual ICollection<EntCentroTrabajoTurno> CentroTrabajoTurnos { get; set; } = new List<EntCentroTrabajoTurno>();

    public virtual EntMunicipio Municipio { get; set; }

    public virtual EntUnidadAdministrativa UnidadAdministrativa { get; set; }
}
