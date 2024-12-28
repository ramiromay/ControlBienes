using ControlBienes.Entities.Catalogos.TipoBien;
using ControlBienes.Entities.Catalogos.Ubicacion;
using ControlBienes.Entities.General.Municipio;
using ControlBienes.Entities.General.UnidadAdministrativa;
using ControlBienes.Entities.Patrimonio.Solicitud;
using System;
using System.Collections.Generic;

namespace ControlBienes.Entities.Patrimonio.Movimiento;

public partial class EntDetalleMovimiento
{
    public long iIdDetalleMovimiento { get; set; }

    public long iIdTipoBien { get; set; }

    public long iIdUnidadAdministrativa { get; set; }

    public string sFolioBien { get; set; }

    public long? iIdNuevaUnidadAdministrativa { get; set; }

    public long iIdMunicipio { get; set; }

    public long? iIdUbicacion { get; set; }

    public string sResponsable { get; set; }

    public virtual ICollection<EntDetalleSolicitud> DetallesSolicitudes { get; set; } = new List<EntDetalleSolicitud>();

    public virtual EntMunicipio Municipio { get; set; }

    public virtual EntUnidadAdministrativa NuevaUnidadAdministrativa { get; set; }

    public virtual EntTipoBien TipoBien { get; set; }

    public virtual EntUbicacion Ubicacion { get; set; }

    public virtual EntUnidadAdministrativa UnidadAdministrativa { get; set; }
}
