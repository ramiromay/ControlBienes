using ControlBienes.Entities.Catalogos.Documento;
using ControlBienes.Entities.Genericos;
using ControlBienes.Entities.Patrimonio.Solicitud;
using ControlBienes.Entities.Patrimonio.TipoTramite;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Patrimonio.MotivoTramite;

public partial class EntMotivoTramite : EntRegistroGenerico
{
    public long iIdMotivoTramite { get; set; }

    public string sNombre { get; set; }

    public string sDescripcion { get; set; }

    public long iIdTipoTramite { get; set; }

    public bool bActivo { get; set; }

    public virtual ICollection<EntDocumento> Documentos { get; set; } = new List<EntDocumento>();

    public virtual EntTipoTramite TiposTramite { get; set; }

    public virtual ICollection<EntSolicitud> Solicitudes { get; set; } = new List<EntSolicitud>();
}
