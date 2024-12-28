using ControlBienes.Entities.General.Periodo;
using ControlBienes.Entities.General.TipoResponsable;
using ControlBienes.Entities.General.UnidadAdministrativa;
using ControlBienes.Entities.Genericos;
using ControlBienes.Entities.Seguridad.Persona;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Catalogos.Resguardante;

public partial class EntResguardante : EntCatalogoGenerico
{
    public long iIdResguardante { get; set; }

    public long iIdPeriodo { get; set; }

    public long iIdPersona { get; set; }

    public long iIdUnidadAdministrativa { get; set; }

    public string sObservaciones { get; set; }

    public int iNoConvenio { get; set; }

    public long iIdTipoResponsable { get; set; }

    public bool bResponsable { get; set; }

    public virtual EntPeriodo Periodo { get; set; }

    public virtual EntPersona Persona { get; set; }

    public virtual EntTipoResponsable TipoResponsable { get; set; }

    public virtual EntUnidadAdministrativa UnidadAdministrativa { get; set; }
}
