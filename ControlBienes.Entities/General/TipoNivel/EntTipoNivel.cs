using ControlBienes.Entities.General.UnidadAdministrativa;
using ControlBienes.Entities.Genericos;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.General.TipoNivel;

public partial class EntTipoNivel : EntRegistroGenerico
{
    public long iIdTipoNivel { get; set; }

    public string sNombre { get; set; }

    public int iNivel { get; set; }

    public virtual ICollection<EntUnidadAdministrativa> UnidadesAdministrativas { get; set; } = new List<EntUnidadAdministrativa>();
}
