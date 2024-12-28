using ControlBienes.Entities.Genericos;
using ControlBienes.Entities.Patrimonio.MotivoTramite;
using ControlBienes.Entities.Patrimonio.TipoTramite;
using ControlBienes.Entities.Sistema.SubModulo;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Catalogos.Documento;

public partial class EntDocumento : EntCatalogoGenerico
{
    public long iIdDocumento { get; set; }

    public string sAbreviacion { get; set; }

    public string sNombre { get; set; }

    public long iIdSubModulo { get; set; }

    public long iIdTipoTramite { get; set; }

    public long iIdMotivoTramite { get; set; }

    public virtual EntMotivoTramite MotivoTramite { get; set; }

    public virtual EntSubModulo SubModulo { get; set; }

    public virtual EntTipoTramite TipoTramite { get; set; }
}
