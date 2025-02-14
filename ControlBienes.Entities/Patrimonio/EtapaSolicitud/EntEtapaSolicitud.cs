using ControlBienes.Entities.Patrimonio.Etapa;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Patrimonio.EtapaSolicitud;

public partial class EntEtapaSolicitud
{
    public long iIdEtapaSolicitud { get; set; }

    public long iIdEtapaOrigen { get; set; }

    public long iIdEtapaDestino { get; set; }

    public DateTime dtFechaCreacion { get; set; }

    public DateTime dtFechaModificacion { get; set; }

    public virtual EntEtapa EtapaDestino { get; set; }

    public virtual EntEtapa EtapaOrigen { get; set; }
}
