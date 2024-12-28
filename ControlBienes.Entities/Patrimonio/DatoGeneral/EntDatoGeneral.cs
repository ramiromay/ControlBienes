using ControlBienes.Entities.Catalogos.ClaseVehicular;
using ControlBienes.Entities.Catalogos.ClaveVehicular;
using ControlBienes.Entities.Catalogos.Color;
using ControlBienes.Entities.Catalogos.CombustibleVehicular;
using ControlBienes.Entities.Catalogos.LineaVehicular;
using ControlBienes.Entities.Catalogos.Marca;
using ControlBienes.Entities.Catalogos.TipoVehicular;
using ControlBienes.Entities.Catalogos.VersionVehicular;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Patrimonio.DatoGeneral;

public partial class EntDatoGeneral
{
    public long iIdDatoGeneral { get; set; }

    public long? iIdClaveVehicular { get; set; }

    public long? iIdMarca { get; set; }

    public long? iIdLineaVehicular { get; set; }

    public long? iIdVersionVehicular { get; set; }

    public long? iIdClaseVehicular { get; set; }

    public long? iIdTipoVehicular { get; set; }

    public long? iIdColor { get; set; }

    public long? iIdCombustibleVehicular { get; set; }

    public virtual EntClaseVehicular ClaseVehicular { get; set; }

    public virtual EntClaveVehicular ClaveVehicular { get; set; }

    public virtual EntColor Color { get; set; }

    public virtual EntCombustibleVehicular CombustibleVehicular { get; set; }

    public virtual EntLineaVehicular LineaVehicular { get; set; }

    public virtual EntMarca Marca { get; set; }

    public virtual EntTipoVehicular TipoVehicular { get; set; }

    public virtual EntVersionVehicular VersionVehicular { get; set; }
}
