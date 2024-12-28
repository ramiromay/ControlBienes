using ControlBienes.Entities.Catalogos.Documento;
using ControlBienes.Entities.Genericos;
using ControlBienes.Entities.Patrimonio.EtapaTramite;
using ControlBienes.Entities.Patrimonio.MotivoTramite;
using ControlBienes.Entities.Patrimonio.Solicitud;
using ControlBienes.Entities.Sistema.SubModulo;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Patrimonio.TipoTramite;

public partial class EntTipoTramite : EntRegistroGenerico
{
    public long iIdTipoTramite { get; set; }

    public string sNombre { get; set; }

    public string sDescripcion { get; set; }

    public long iIdSubModulo { get; set; }

    public bool bActivo { get; set; }

    public virtual ICollection<EntDocumento> Documentos { get; set; } = new List<EntDocumento>();

    public virtual ICollection<EntEtapaTramite> EtapasTramites { get; set; } = new List<EntEtapaTramite>();

    public virtual EntSubModulo SubModulo { get; set; }

    public virtual ICollection<EntMotivoTramite> MotivosTramites { get; set; } = new List<EntMotivoTramite>();

    public virtual ICollection<EntSolicitud> Solicitudes { get; set; } = new List<EntSolicitud>();
}
