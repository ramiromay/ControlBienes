using ControlBienes.Entities.Genericos;
using ControlBienes.Entities.Patrimonio.Etapa;
using ControlBienes.Entities.Patrimonio.TipoTramite;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Patrimonio.EtapaTramite;

public partial class EntEtapaTramite : EntRegistroGenerico
{
    public long iIdEtapaTramite { get; set; }

    public long iIdTipoTramite { get; set; }

    public long iIdEtapaOrigen { get; set; }

    public long iIdEtapaDestino { get; set; }

    public virtual EntEtapa EtapaOrigen { get; set; }

    public virtual EntEtapa EtapaDestino { get; set; }

    public virtual EntTipoTramite TipoTramite { get; set; }
}
